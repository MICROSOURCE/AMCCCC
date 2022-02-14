using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.MasterPages
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        #region "Variable"        
        private Boolean _IsPageRefresh;
        private List<Menu_Entities> lstMenu;// =new List<Menu_Entities>();
        private List<Rights_Entities> listRights;
        private String Message = "";
        public bool IsPageRefresh { get { return _IsPageRefresh; } }
        //Form Rights Property
        private string _R_ADD { get; set; }
        public string R_ADD { get { return _R_ADD; } set { _R_ADD = value; } }
        private string _R_EDIT { get; set; }
        public string R_EDIT { get { return _R_EDIT; } set { _R_EDIT = value; } }
        private string _R_DEL { get; set; }
        public string R_DEL { get { return _R_DEL; } set { _R_DEL = value; } }
        private string _R_READ { get; set; }
        public string R_READ { get { return _R_READ; } set { _R_READ = value; } }
        private string _S_EDIT { get; set; }
        public string S_EDIT { get { return _S_EDIT; } set { _S_EDIT = value; } }
        private string _S_DEL { get; set; }
        public string S_DEL { get { return _S_DEL; } set { _S_DEL = value; } }
        private string _ACCESS { get; set; }
        public string ACCESS { get { return _ACCESS; } set { _ACCESS = value; } }

        public string LST_USER { get { return lblLST_USER.Text; } set { lblLST_USER.Text = value; } }
        public string LST_DATE { get { return lblLST_DATE.Text; } set { lblLST_DATE.Text = value; } }
        public string LST_IP { get { return lblLST_DATE.Text; } set { lblLST_DATE.Text = value; } }
        #endregion
        #region "Event Handling"
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["CheckRefresh"] = Server.UrlEncode(System.DateTime.Now.ToString());
                Session["FORMID"] = "";
                Session["TTYPE_ID"] = "";
            }
            String str = "";
            if (Request.QueryString["String"] != null)
            {
                str = Utils.Decryption(Request.QueryString["String"].ToString());
            }
            else if (Request.QueryString["MODULE"] != null)
            {
                str = Utils.Decryption(Request.QueryString["MODULE"].ToString());
            }
            if (str != "")
            {
                string[] ary = Utils.GetStringValue(str);
                Session["USER_ID"] = ary[0];
                Session["USER_NAME"] = ary[1];
                Session["COUNTER_ID"] = ary[2];
                Session["USER_ROLE"] = ary[3];
                Session["USER_TYPE"] = ary[4];
                Session["IP"] = ary[5];
                Session["FORMID"] = ary[6];
                Session["MODID"] = ary[7];
                using (var BLL = new CommonDBAccess())
                {
                    Session["USER_ROLE"] = BLL.GetRoleId(Session["USER_ID"].ToString());
                }
            }
            if (Request.QueryString["FORMID"] != null)
            {
                Session["FORMID"] = Convert.ToString(Request.QueryString["FORMID"]);
            }
            if (!IsPostBack)
            {
                var iDict = new Dictionary<string, string>();
                using (var BLL = new MenuDBAccess())
                {
                    int i;
                    string formName;
                    //Get Exact Form Name(.aspx) from MST_FORMS without Additional Query String
                    if (String.IsNullOrEmpty((string)Session["USER_ROLE"]))
                    {
                        Response.Redirect("~/login.aspx");
                    }
                    //IF URL CHANGE BY USER THEN REDIRECT TO LOGIN PAGE
                    if (Session["USER_ID"].ToString() != "ADMIN")
                    {
                        if (Request.UrlReferrer is null)
                        {
                            Session.Abandon();
                            Response.Redirect("~/login.aspx");
                        }
                    }
                    formName = Request.RawUrl.Split('/').Last();

                    i = (formName.ToUpper()).IndexOf("_HIDE");// '_HIDE IS USED FOR NOT CONSIDER FOR FIND FORMNAME IN MASTER
                    //i = Strings.InStr(formName.ToUpper, "_HIDE");  
                    if (i > 0)
                    {
                        formName = formName.Substring(0, i - 2);
                    }
                    iDict = BLL.GetModuleDet(formName, Session["MOD_ID"].ToString());
                    lblFORM_NAME.Text = iDict["FORM_ETITLE"];
                    lblMODULE_NAME.Text = iDict["MOD_ENAME"];
                    ViewState["FORM_DESC"] = "'" + iDict["FORM_DESC"] + "'";
                    Session["MODID"] = iDict["MOD_ID"];
                    Session["FORMID"] = iDict["FORM_ID"];
                    if (iDict["FORM_TYPE"] != "G")
                    {
                        listRights = BLL.GetFormRights(Session["USER_ROLE"].ToString(), Convert.ToString(Session["FORMID"]), Session["MOD_ID"].ToString());
                    }
                }
                if (iDict["FORM_TYPE"] != "G")
                {
                    //Form Rights Property Set
                    R_ADD = listRights[0].R_ADD;
                    R_EDIT = listRights[0].R_EDIT;
                    if (R_EDIT == "Y")
                    {
                        S_EDIT = "Y";
                        R_READ = "Y";
                    }
                    else
                    {
                        R_READ = listRights[0].R_READ;
                        S_EDIT = listRights[0].S_EDIT;
                    }
                    R_DEL = listRights[0].R_DEL;
                    if (R_DEL == "Y")
                        S_DEL = "Y";
                    else
                        S_DEL = listRights[0].S_DEL;
                    ACCESS = listRights[0].ACCESS;
                    if (ACCESS == "N")
                    {
                        Response.Redirect("~/Access_Denied.aspx", false);
                    }
                    chkR_ADD.Checked = (R_ADD == "Y");
                    chkR_EDIT.Checked = (R_EDIT == "Y");
                    chkR_DEL.Checked = (R_DEL == "Y");
                    chkR_READ.Checked = (R_READ == "Y");
                    chkS_EDIT.Checked = (S_EDIT == "Y");
                    chkS_DEL.Checked = (S_DEL == "Y");
                    Rights.Visible = true;
                }
                else { Rights.Visible = false; }
            }
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            ViewState["CheckRefresh"] = Session["CheckRefresh"];
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!(Session["USER_ID"] == null))
                {
                    lblUSERNAME.Text = Session["USER_NAME"].ToString();
                    //If Session("USER_TYPE") <> "I" Then
                    BindMenu(Session["USER_ROLE"].ToString());
                    //End If
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
                if (Session["CheckRefresh"] == ViewState["CheckRefresh"])
                {
                    _IsPageRefresh = false;
                    Session["CheckRefresh"] = Server.UrlEncode(System.DateTime.Now.ToString());
                }
                else
                    _IsPageRefresh = true;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region "!-- User Defined Functions--!"
        #region "!-- BindMenu()--!"
        private void BindMenu(string Roll)
        {
            try
            {
                if (Session["MENU"].ToString() == "")
                {
                    using (var BALMENU = new MenuDBAccess())
                    {
                        //Add Menu in List
                        lstMenu = BALMENU.GetMenuList(Roll, Session["MOD_ID"].ToString());
                        var SB = new StringBuilder();
                        var lnkPath = "";
                        if (lstMenu.Count > 0)
                        {
                            //Fetch Only Menu Name
                            // var HMenu = lstMenu.Where(Function(s) s.F_PARENT = "").ToList();
                            var HMenu = lstMenu.Where(s => s.F_PARENT == "").ToList();
                            foreach (var lst in HMenu)
                            {
                                SB.AppendLine("<li><a href='#'><i class='" + lst.CSS_CLASS + "'></i><span class = 'title'>" + lst.MENUNAME + "</span><i class='icon-arrow'></i></a>");
                                lnkPath = ResolveUrl("~") + lst.FOLDER_NAME + "/";
                                //lnkPath = ResolveUrl("~") & "TRANSACTION" & "/"
                                var MenuId = lst.MENUID;
                                //Fetch Only SubMenu
                                var SMenu = lstMenu.Where(s => s.F_PARENT != "" && s.F_PARENT == MenuId).ToList();
                                //Add Sub-Menu List
                                SB.AppendLine("<ul class='sub-menu'>");
                                foreach (var sublst in SMenu)
                                {
                                    if (sublst.ACCESS == "N")
                                    {
                                        SB.AppendLine("<li><a href='#'  class='disable'><span class = 'title'>" + sublst.MENUNAME.Replace("_", " ") + "</span></a></li>");
                                    }
                                    else
                                    {
                                        var SMenuID = sublst.MENUID;
                                        //Fetch Only SubMenu
                                        var TMenu = lstMenu.Where(s => s.F_PARENT != "" && s.F_PARENT == SMenuID).ToList();
                                        if (TMenu.Count > 0)
                                        {
                                            SB.AppendLine("<li><a href='javascript:;'><span class = 'title'>" + sublst.MENUNAME.Replace("_", " ") + "</span><i class='icon-arrow'></i></a>");
                                            SB.AppendLine("<ul class='sub-menu'>");
                                            foreach (var Tlist in TMenu)
                                            {
                                                if (sublst.ACCESS == "N")
                                                    SB.AppendLine("<li><a href='#'  class='disable'><span class = 'title'>" + Tlist.MENUNAME.Replace("_", " ") + "</span></a></li>");
                                                else
                                                    SB.AppendLine("<li><a href=" + lnkPath + Tlist.LINK + "><span class = 'title'>" + Tlist.MENUNAME.Replace("_", " ") + "</span></a></li>");
                                            }
                                            SB.AppendLine("</ul></li>");
                                        }
                                        else
                                        {
                                            SB.AppendLine("<li><a href=" + lnkPath + sublst.LINK + "><span class = 'title'>" + sublst.MENUNAME.Replace("_", " ") + "</span></a></li>");
                                        }
                                        //Add Sub-Menu List
                                    }
                                }
                                //End of Loop close </ul>
                                SB.AppendLine("</ul>");
                                SB.AppendLine("</li>");
                            }
                            SB.Append("<li><a href='" + ResolveUrl("~/logout.aspx") + "'><i class='clip-switch'></i><span class='title'>Logout</span></a></li>");
                            Session["MENU"] = SB.ToString();
                            //Bind Horizonal Menu in Master Page
                            menu.InnerHtml = SB.ToString();
                        }
                    }
                }
                else
                {
                    menu.InnerHtml = Session["MENU"].ToString();
                }
            }
            catch (Exception ex)
            {
                Session["Message"] = ex.Message.ToString();
                Page.ClientScript.RegisterStartupScript(GetType(), "message", "Message()", true);
            }
        }
        #endregion
        #region "!--Set User In Label"
        public void SetUser(DataRowCollection Datarow)
        {
            if (Datarow.Count > 0)
            {
                LST_USER = Datarow[0]["LST_USER"].ToString();
                LST_DATE = Datarow[0]["LST_DATE"].ToString();
                LST_IP = Datarow[0]["LST_IP"].ToString();
            }
        }
        #endregion
        #region "!--Rights Checking In Trasaction Form !"
        public Boolean AddRights()
        {
            return chkR_ADD.Checked;
        }
        public Boolean ReadRights()
        {
            return chkR_READ.Checked;
        }
        public Boolean EditRights()
        {
            var EditRights = true;
            if (chkR_EDIT.Checked != true)
            {
                if (chkS_EDIT.Checked == true)
                {
                    if (Session["USER_ID"].ToString() != LST_USER)
                    {
                        EditRights = false;
                    }
                    else
                        EditRights = false;
                }
            }
            return EditRights;
        }
        public Boolean DeleteRights()
        {
            var DeleteRights = true;
            if (chkR_DEL.Checked != true)
            {
                if (chkS_DEL.Checked == true)
                {
                    if (Session["USER_ID"].ToString() != lblLST_USER.Text)
                    {
                        DeleteRights = false;
                    }
                    else
                        DeleteRights = false;
                }

            }
            return DeleteRights;
        }
        #endregion

        #endregion
    }
}