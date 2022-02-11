using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace AMCCCC.App_Code
{
    public class Utils
    {
        #region "!-- Variable Declarations --!"
        public Dictionary<string, object> dict;
        public IDictionary<object, object> lst;
        public string Message;
        public DataTable _DT;
        #endregion
        #region "!-- ShowMessage() --!"
        public void ShowMessage(string TYPE, string MESSAGE)
        {
            MESSAGE = MESSAGE.Replace("", "");
            
            //public Page page=new Page(); 
            //page = HttpContext.Current.CurrentHandler;
        }
        //    Public Shared Sub ShowMessage(ByVal TYPE As String, ByVal MESSAGE As String)
        //    MESSAGE = MESSAGE.Replace(vbCr, "").Replace(vbLf, "").Replace("'", "").Replace("""", "")
        //    Dim page As New Page
        //    page = HttpContext.Current.CurrentHandler
        //    ScriptManager.RegisterStartupScript(page, page.GetType(), "key", "ShowMessage('" & TYPE & "','" & MESSAGE & "');", True)
        //End Sub
        #endregion

    }
}