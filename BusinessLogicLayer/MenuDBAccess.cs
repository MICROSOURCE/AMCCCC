using DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class MenuDBAccess : IDisposable
    {
        #region Variable

        private string _message;
        private List<Menu_Entities> lstMenu;
        private List<Rights_Entities> lstRights;

        #endregion

        #region Method

        public List<Menu_Entities> GetMenuList(string Roll, string MOD_ID)
        {
            lstMenu = new List<Menu_Entities>();
            DataTable table;
           
            using (var objEnt = new Common_Mst_Ent())
            {
                objEnt.FLAG = "INTRA_GET_MENU_LIST";
                objEnt.PARAM = Roll;
                objEnt.PARAM1 = MOD_ID;
                using (var objbal = new CommonDBAccess())
                {
                    table = objbal.GetData("AMCDB.PRO_GET_MST_DATA", objEnt);
                }
            }
            // Add Item to List
            lstMenu.Clear();
            foreach (DataRow row in table.Rows)
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
                lstMenu.Add(Ent);
            }
            return lstMenu;
        }

        public Dictionary<string, string> GetModuleDet(string pForm_Name, string MODULE_ID)
        {
            pForm_Name = pForm_Name.ToUpper();
            string str = string.Format("SELECT A.MOD_ID, A.FORM_ID, A.FORM_TYPE, A.FORM_NAME, A.FORM_ETITLE, A.FORM_DESC, A.TTYPE_ID, A.ACTIVE, B.MOD_ENAME FROM MST_FORMS A INNER JOIN AMCDB.MST_MODULE B ON A.MOD_ID=B.MOD_ID WHERE UPPER(A.FORM_NAME)='{0}' AND A.MOD_ID='{1}'", pForm_Name.ToUpper(), MODULE_ID);
            var Dt = new DataTable();
            using (var DBHelp = new Dal())
            {
                Dt = DBHelp.GetDataTableDirect(str);
            }
            var iDict = new Dictionary<string, string>();
            if (Dt.Rows.Count != 0)
            {
                for (int i = 0, loopTo = Dt.Columns.Count - 1; i <= loopTo; i++)
                    iDict.Add(Dt.Columns[i].ColumnName, Dt.Rows[0][i].ToString());
            }
            return iDict;
        }

        public List<Rights_Entities> GetFormRights(string ROLL, string FORM_ID, string MOD_ID)
        {
            DataTable table;
            lstMenu = new List<Menu_Entities>();
            lstRights = new List<Rights_Entities>();
            // Fetch MenuItem as per Roll
            string STR = "SELECT * FROM TABLE(AMCDB.FUN_FORM_RIGHTS('" + ROLL + "','" + FORM_ID + "','" + MOD_ID + "'));";
            using (var DBHelp = new Dal())
            {
                table = DBHelp.GetDataTableDirect(STR);
            }
            // Add Item to List
            lstMenu.Clear();
            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var Ent = new Rights_Entities();
                    Ent.ROLE_ID = row["ROLE_ID"].ToString();
                    Ent.FORM_ID = row["FORM_ID"].ToString();
                    Ent.R_ADD = row["R_ADD"].ToString();
                    Ent.R_EDIT = row["R_EDIT"].ToString();
                    Ent.R_DEL = row["R_DEL"].ToString();
                    Ent.R_READ = row["R_READ"].ToString();
                    Ent.S_EDIT = row["S_EDIT"].ToString();
                    Ent.S_DEL = row["S_DEL"].ToString();
                    Ent.ACCESS = row["ACCESS"].ToString();
                    lstRights.Add(Ent);
                }
            }
            else
            {
                var Ent = new Rights_Entities();
                Ent.ROLE_ID = "N";
                Ent.FORM_ID = "N";
                Ent.R_ADD = "N";
                Ent.R_EDIT = "N";
                Ent.R_DEL = "N";
                Ent.R_READ = "N";
                Ent.S_EDIT = "N";
                Ent.S_DEL = "N";
                Ent.ACCESS = "N";
                lstRights.Add(Ent);
            }

            return lstRights;
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
        #endregion

    }
}

