using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace DAL
{
    public sealed partial class DataUtil
    {
        private DataUtil()
        {
        }

        /// <summary>
        /// Convert an IList&lt;T&gt; into a DataTable schema
        /// </summary>
       
        public static DataTable CreateDataTable<T>() where T : class
        {
            var objType = typeof(T);
            var table = new DataTable(objType.Name);
            var properties = TypeDescriptor.GetProperties(objType);
            foreach (PropertyDescriptor property in properties)
            {
                var propertyType = property.PropertyType;
                if (!CanUseType(propertyType))
                {
                    continue;
                }
                // shallow only
                // nullables must use underlying types
                if (propertyType.IsGenericType && ReferenceEquals(propertyType.GetGenericTypeDefinition(), typeof(object)))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }
                // enums also need special treatment
                if (propertyType.IsEnum)
                {
                    propertyType = Enum.GetUnderlyingType(propertyType);
                }
                // probably Int32
                // if you have nested application classes, they just get added. Check if this is valid?
                Debug.WriteLine("table.Columns.Add(\"" + property.Name + "\", typeof(" + propertyType.Name + "));");
                table.Columns.Add(property.Name, propertyType);
            }

            return table;
        }

        /// <summary>
        /// Convert an IList into a DataTable
        /// </summary>
        /// <example><code>
        /// IList Person people = new List&lt;Person&gt;
        ///    {
        ///        new Person { Id= 1, DoB = DateTime.Now, Name = "Bob", Sex = Person.Sexes.Male }
        ///    };
        /// DataTable dt = DataUtil.ConvertToDataTable(people);
        /// </code></example>
       
        public static DataTable ConvertToDataTable<T>(IList<T> list) where T : class
        {
            var table = CreateDataTable<T>();
            var objType = typeof(T);
            var properties = TypeDescriptor.GetProperties(objType);
            // Debug.WriteLine("foreach (" + objType.Name + " item in list) {");
            foreach (T item in list)
            {
                var row = table.NewRow();
                foreach (PropertyDescriptor property in properties)
                {
                    if (!CanUseType(property.PropertyType))
                    {
                        continue;
                    }
                    // shallow only
                    // Debug.WriteLine("row[\"" + property.Name + "\"] = item." + property.Name + "; //.HasValue ? (object)item." + property.Name + ": DBNull.Value;");
                    // can't use null
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }

                Debug.WriteLine("//===");
                table.Rows.Add(row);
            }

            return table;
        }

        public static IDictionary ConvertToDictionary<T>(IList<T> list) where T : class
        {
            var objType = typeof(T);
            var vList = new Dictionary<string, object>();
            var properties = TypeDescriptor.GetProperties(objType);
            // Debug.WriteLine("foreach (" + objType.Name + " item in list) {");
            foreach (T item in list)
            {
                foreach (PropertyDescriptor property in properties)
                {
                    if (!CanUseType(property.PropertyType))
                    {
                        continue;
                    }
                    // shallow only
                    // Debug.WriteLine("row[\"" + property.Name + "\"] = item." + property.Name + "; //.HasValue ? (object)item." + property.Name + ": DBNull.Value;");
                    // can't use null

                    // vList.Add("@P_" & [property].Name.ToUpper, If([property].GetValue(item), DBNull.Value))
                    vList.Add(property.Name.ToUpper(), property.GetValue(item) ?? DBNull.Value);
                }

                Debug.WriteLine("//===");
            }

            return vList;
        }

        public static IDictionary ConvertToDict<T>(T list) where T : class
        {
            var objType = typeof(T);
            var vList = new Dictionary<string, object>();
            var properties = TypeDescriptor.GetProperties(objType);
            // Debug.WriteLine("foreach (" + objType.Name + " item in list) {");
            foreach (PropertyDescriptor property in properties)
            {
                if (!CanUseType(property.PropertyType))
                {
                    continue;
                }
                // shallow only
                // Debug.WriteLine("row[\"" + property.Name + "\"] = item." + property.Name + "; //.HasValue ? (object)item." + property.Name + ": DBNull.Value;");
                // can't use null

                vList.Add("P_" + property.Name.ToUpper(), property.GetValue(list) ?? DBNull.Value);
            }

            return vList;
        }

        private static bool CanUseType(Type propertyType)
        {
            // only strings and value types
            if (propertyType.IsArray)
            {
                return false;
            }

            if (!propertyType.IsValueType && !ReferenceEquals(propertyType, typeof(string)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Convert DataTable to IList&lt;T&gt;. Some column names should match property names- or you'll have a list of empty T entities.
        /// </summary>
        /// <example><code>
        /// IList&lt;Person&gt; people = new List&lt;Person&gt;
        ///    {
        ///        new Person { Id= 1, DoB = DateTime.Now, Name = "Bob", Sex = Person.Sexes.Male }
        ///    };
        /// DataTable dt = DataUtil.ConvertToDataTable(people);
        /// IList&lt;Person&gt; people2 = DataUtil.ConvertToList&lt;Person&gt;(dt); //round trip
        /// //Note that people2 is a list of cloned Person objects
        /// </code></example>
       
        public static IList<T> ConvertToList<T>(DataTable dt) where T : class, new()
        {
            IList<T> list = new List<T>();
            if (dt is null || dt.Rows.Count == 0)
            {
                return null;
            }

            foreach (DataRow row in dt.Rows)
            {
                var obj = ConvertDataRowToEntity<T>(row);
                list.Add(obj);
            }

            return list;
        }

        public static BindingList<T> ConvertToBindingList<T>(DataTable dt) where T : class, new()
        {
            if (dt is null || dt.Rows.Count == 0)
            {
                return null;
            }

            var list = new BindingList<T>();
            foreach (DataRow row in dt.Rows)
            {
                var obj = ConvertDataRowToEntity<T>(row);
                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// Convert a single DataRow into an object of type T.
        /// </summary>
       
        public static T ConvertDataRowToEntity<T>(DataRow row) where T : class, new()
        {
            var objType = typeof(T);
            var obj = Activator.CreateInstance<T>();
            // hence the new() contsraint
            // Debug.WriteLine(objType.Name + " = new " + objType.Name + "();");
            foreach (DataColumn column in row.Table.Columns)
            {
                // may error if no match
                var property = objType.GetProperty(column.ColumnName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                if (property is null || !property.CanWrite)
                {
                    // Debug.WriteLine("//Property " + column.ColumnName + " not in object");
                    // or throw
                    continue;
                }

                var value = row[column.ColumnName];
                if (ReferenceEquals(value, DBNull.Value))
                {
                    value = null;
                }

                property.SetValue(obj, value, null);
                Debug.WriteLine("obj." + property.Name + " = row[\"" + column.ColumnName + "\"];");
            }

            return obj;
        }
    }
}