using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;

namespace AMCCCC
{
    public partial class Login : System.Web.UI.Page
    {
        //LoginDBAccess ObjLogin = new LoginDBAccess();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session["Message"] = null;
                lblMSG.Text = "";
                // generate form;
            }
        }
    }
}