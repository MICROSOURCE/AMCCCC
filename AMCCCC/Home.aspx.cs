using AMCCCC.Helper;
using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC
{
    public partial class Home : System.Web.UI.Page
    {
            private List<Rights_Entities> listRights;
            public Action<object, EventArgs> Load { get; }
            //public object Session { get; private set; }
            protected void Page_Load(object sender, EventArgs e)
            {
                // For The Insert Rights
                using (var BLL = new MenuDBAccess())
                {
                    listRights = BLL.GetFormRights(Session["USER_ROLE"].ToString(), "029000", Session["MOD_ID"].ToString());
                }
                bool flg = Utils.verifyCheckDigit("05133310170001A");
                if (listRights.First().ACCESS == "N")
                {
                    Response.Redirect("Access_Denied.aspx");
                    Session.Abandon();
                }
            }
    }
}