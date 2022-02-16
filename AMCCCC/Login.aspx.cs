using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using Entity;

namespace AMCCCC
{
    public partial class Login : System.Web.UI.Page
    {
        //LoginDBAccess ObjLogin = new LoginDBAccess();
        #region "Class Object"
        //private DataSet dsConStr;
        DataSet dsConStr = new DataSet();
        Login_Ent ObjEnt = new Login_Ent();
        LoginDBAccess ObjLogin = new LoginDBAccess();
        //private Login_Ent ObjEnt;
        //private LoginDBAccess ObjLogin;
        #endregion
        #region "Variable"
        private String Message = "";
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                Session["Message"] = null;
                lblMSG.Text = "";

                NameValueCollection coll;
                coll = Request.ServerVariables;
                if (Request.ServerVariables["REMOTE_ADDR"].ToString().Split('.').Length == 4)
                {
                    Session["ip"] = Request.ServerVariables["REMOTE_ADDR"];
                }
                else
                {
                    Session["ip"] = GetIP4Address();
                }
                lblIP.Text = "IP: " + Session["ip"];
            }
            //Dim dsConStr As New DataSet
            try
            {                
                dsConStr.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "Constr.xml");
                lblVersion.Text = dsConStr.Tables[0].Rows[0]["VERSION"].ToString();
            }
            catch (Exception ec)
            {
                var a = ec.Message;
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //Fill Entities
                    var objEnt = ObjEnt;
                    objEnt.USER_ID = txtUser.Text.Trim();
                    objEnt.USER_PWD = txtPassword.Text.Trim();
                    objEnt.LST_IP = Session["ip"].ToString();
                    // Call Method
                    Message = ObjLogin.LoginUser(ObjEnt);
                    if (Message.Substring(0, 3) == "100")
                    {
                        String[] StrArr = Message.Split('-');
                        Session["USER_ID"] = txtUser.Text.Trim();
                        Session["USER_NAME"] = StrArr[1] + "-" + StrArr[2];
                        Session["COUNTER_ID"] = StrArr[3];
                        Session["USER_ROLE"] = StrArr[4];
                        Session["USER_TYPE"] = StrArr[5];
                        Session["ROLE_DESC"] = StrArr[2];
                        Session["MENU"] = "";
                        Session["MOD_ID"] = "10";
                        Response.Redirect("~/Home.aspx");                      
                    }
                    else
                        lblMSG.Text = Message;
                }
            }
            catch (Exception ex)
            {
                lblMSG.Text = ex.Message.Replace("", "").Replace("", "");
            }
        }
        #region "!----GetIP4Address()----!"
        public string GetIP4Address()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(HttpContext.Current.Request.UserHostAddress))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            if (!String.IsNullOrEmpty(IP4Address))
                return IP4Address;
            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily.ToString() == "InterNetwork")
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }
            return IP4Address;
        }
        #endregion


    }
}