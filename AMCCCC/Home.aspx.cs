using AMCCCC.Helper;
using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC
{
    public partial class Home : System.Web.UI.Page
    {
        private List<Rights_Entities> listRights;
        public DataTable table;
        public Action<object, EventArgs> Load { get; }
        //public object Session { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            // For The Insert Rights
            using (var BLL = new MenuDBAccess())
            {
                listRights = BLL.GetFormRights(Session["USER_ROLE"].ToString(), "109000", Session["MOD_ID"].ToString());
            }
            bool flg = Utils.verifyCheckDigit("05133310170001A");
            if (listRights.First().ACCESS == "N")
            {
                Response.Redirect("Access_Denied.aspx");
                Session.Abandon();
            }

            var DbAccess = new CommonDBAccess();
            var objEnt = new Common_Mst_Ent();
            objEnt.FLAG = "INTRA_GET_MENU_LIST";
            objEnt.PARAM = Session["USER_ROLE"].ToString();
            objEnt.PARAM1 = Session["MOD_ID"].ToString();
            var menu = DbAccess.GetData("AMCDB.PRO_GET_MST_DATA", objEnt);

            //var WARDATA = DbAccess.GetData("AMCDB.PRO_GET_WARD_MAST", objEnt);

            foreach (DataRow row in menu.Rows)
            {
                var Ent = new Menu_Entities();
                Ent.MENUID = row["FORM_ID"].ToString();
                Ent.MENUNAME = row["FORM_ETITLE"].ToString();
                Ent.LINK = row["FORM_NAME"].ToString();
                Ent.FORMTYPE = row["FORM_TYPE"].ToString();
                Ent.F_PARENT = row["PARENT_FORM_ID"].ToString();
                Ent.ACCESS = row["ACCESS"].ToString();
                Ent.FORMNAME = row["FORM_ETITLE"].ToString();
                Ent.FORMDEC = row["FORM_DESC"].ToString();
                Ent.CSS_CLASS = row["CSS_CLASS"].ToString();
                Ent.FOLDER_NAME = row["FOLDER_NAME"].ToString();
                
            }
        }
    }
}