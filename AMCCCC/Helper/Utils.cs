using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AMCCCC.Helper
{
    public class Utils
    {
        #region variable

        private static Dictionary<object, object> _Dict;
        private static IDictionary<object, object> lst;
        private static string _message;

        #endregion

        public static void ShowMessage(string type, string message)
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