using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.App_Code
{
    public static class Utils
    {
        #region Variable
        public static Dictionary<string, object> dict;
        public  static IDictionary<object, object> lst;
        public static string Message;
        public static DataTable _DT;
        private static IDictionary<object, object> _Dict;

        #endregion

        public static void ShowMessage(string TYPE, string MESSAGE)
        {
            
        }

        public static void FillCombo(DropDownList pCmb, string flag, string incExp)
        {
            lst = GetComboSql(flag, incExp);
            pCmb.DataSource = lst;
            pCmb.DataValueField = "Key";
            pCmb.DataTextField = "Value";
            pCmb.DataBind();
            pCmb.Items.Insert(0, "--SELECT--");
            pCmb.Items.FindByText("--SELECT--").Selected = true;
        }

        #region getComboSql
        public static IDictionary<object, object> GetComboSql(string Flag, string IncExp = null)
        {
            using (var ObjBll = new CommonDBAccess())
            {
                // ' Bind Table as per Query
                _Dict = new Dictionary<object, object>();
                _Dict.Clear();
                var records = ObjBll.GetDataTableForComboStr(Flag, IncExp, "").AsEnumerable();
                foreach (DataRow row in records)
                {
                    _Dict.Add(row[0].ToString(), row[1].ToString());
                }
            }
            // Return Filled Dictionary
            return _Dict;
        }
        #endregion
       

    }
}