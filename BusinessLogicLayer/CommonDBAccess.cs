using DataAccessLayer.DAL;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CommonDBAccess : IDisposable
    {

        #region 
        private string Message;
        private string str;
        private Dictionary<string, object> _DictParam;
        private DataTable _DT;
        private DataSet _DS;
        #endregion

        #region method

        #region getData
        public DataTable GetData(string ProcName, Common_Mst_Ent CommEnt)
        {
            using (var SQLHelp = new Dal())
            {
                try
                {
                    _DictParam.Clear();
                    _DictParam.Add("P_FLAG", CommEnt.FLAG);
                    _DictParam.Add("P_FROM_DATE", CommEnt.FROM_DATE);
                    _DictParam.Add("P_TO_DATE", CommEnt.TO_DATE);
                    _DictParam.Add("P_PARAM", CommEnt.PARAM);
                    _DictParam.Add("P_PARAM1", CommEnt.PARAM1);
                    _DictParam.Add("P_PARAM2", CommEnt.PARAM2);
                    _DictParam.Add("P_CR_USER", CommEnt.CR_USER);
                    _DictParam.Add("P_ROLE_ID", CommEnt.ROLE_ID);
                    _DT = SQLHelp.ExecuteProcedureDatatable(ProcName, _DictParam);
                    Message = str;
                }
                catch (Exception ex)
                {

                }
            }
            return _DT;
        }
        #endregion

        #region DeleteData
        public string DeleteData(Common_Mst_Ent CommEnt)
        {
            using (var DBHelp = new Dal())
            {
                try
                {
                    var withBlock = _DictParam;
                    withBlock.Clear();
                    withBlock.Add("@P_FLAG", CommEnt.FLAG);
                    withBlock.Add("@P_PARAM", CommEnt.PARAM);
                    withBlock.Add("@P_IP", CommEnt.LST_IP);
                    withBlock.Add("@P_USER", CommEnt.LST_USER);

                    str = DBHelp.ExecuteProcedureDynamic("PRO_DEL_MST_DATA", _DictParam);
                    if (str.Substring(0, 3) != "100")
                    {
                        throw new Exception(str);
                    }
                    else
                    {
                        DBHelp.Commit();
                    }
                    Message = str;
                }
                catch (Exception ex)
                {
                    DBHelp.Rollback();
                    Message = ex.Message.ToString();
                }
            }

            return Message;
        }

        #endregion

        #region GetDataDataSet
        public DataSet GetDataDataSet(string ProcName, Common_Mst_Ent CommEnt)
        {
            using (var SqlHelp = new Dal())
            {
                try
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("P_FLAG", CommEnt.FLAG);
                        withBlock.Add("P_FROM_DATE", CommEnt.FROM_DATE);
                        withBlock.Add("P_TO_DATE", CommEnt.TO_DATE);
                        withBlock.Add("P_PARAM", CommEnt.PARAM);
                        withBlock.Add("P_PARAM1", CommEnt.PARAM1);
                        withBlock.Add("P_PARAM2", CommEnt.PARAM2);
                        withBlock.Add("P_CR_USER", CommEnt.CR_USER);
                        withBlock.Add("P_ROLE_ID", CommEnt.ROLE_ID);
                    }

                    _DS = SqlHelp.GetDataSetStoredProcedure(ProcName, _DictParam);
                }
                catch (Exception ex)
                {
                    
                }
            }

            return _DS;
        }

        #endregion

        #region GetDataDataSet
        public DataSet GetDataDataSetfromdict(string ProcName, Dictionary<string, object> _DictParam)
        {
            using (var SqlHelp = new Dal())
            {
                try
                {
                    _DS = SqlHelp.GetDataSetStoredProcedure(ProcName, _DictParam);
                }
                catch (Exception ex)
                {
                   
                }
            }

            return _DS;
        }

        #endregion

        #region GetDataTableForComboStr
        public DataTable GetDataTableForComboStr(string Flag, string Param, string Param1 = "", string P_PARAM2 = "", string P_CR_USER = "", string P_ROLE_ID = "")
        {
            try
            {
                using (var ObjDal = new Dal())
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("P_FLAG", Flag);
                        withBlock.Add("P_PARAM", Param);
                        withBlock.Add("P_PARAM1", Param1);
                        withBlock.Add("P_PARAM2", P_PARAM2);
                        withBlock.Add("P_CR_USER", P_CR_USER);
                        withBlock.Add("P_ROLE_ID", P_ROLE_ID);
                    }

                    _DT = ObjDal.GetDataTableFromStoredProcedure("AMCPT.PRO_FILLCOMBO", _DictParam);
                }
            }
            catch (Exception ex)
            {
               
            }

            return _DT;
        }

        #endregion

        #region GetDataTableHelp
        public DataTable GetDataTableForHelp(string Flag, string Param = "", string Param1 = "")
        {
            try
            {
                using (var ObjDal = new Dal())
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("@P_FLAG", Flag);
                        withBlock.Add("@P_PARAM", Param);
                        withBlock.Add("@P_PARAM1", Param1);
                    }

                    _DT = ObjDal.GetDataTableFromStoredProcedure("PRO_HELP", _DictParam);
                }
            }
            catch (Exception ex)
            {
                
            }

            return _DT;
        }

        #endregion

        #region GetRoleId
        public string GetRoleId(string UserId)
        {
            string Roleid;
            using (var ObjDal = new Dal())
            {
                Roleid = ObjDal.GetScalarValue("SELECT dbo.GET_ROLEID('" + UserId + "')");
            }

            return Roleid;
        }

        #endregion

        #region GetRptData
        public DataSet GetRptData(Common_Mst_Ent ObjEnt)
        {
            try
            {
                using (var ObjDal = new Dal())
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("@P_FLAG", ObjEnt.FLAG);
                        withBlock.Add("@P_PARAM", ObjEnt.PARAM);
                        withBlock.Add("@P_PARAM1", ObjEnt.PARAM1);
                    }

                    _DS = ObjDal.GetDataSetStoredProcedure("PRO_GET_RPT_DATA", _DictParam);
                }
            }
            catch (Exception ex)
            {
                
            }

            return _DS;
        }

        #endregion

        #region GetOnScreenReport
        public DataSet GetOnScreenReport(Common_Mst_Ent ObjEnt)
        {
            try
            {
                using (var ObjDal = new Dal())
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("@P_FLAG", ObjEnt.FLAG);
                        withBlock.Add("@P_PARAM", ObjEnt.PARAM);
                        withBlock.Add("@P_PARAM1", ObjEnt.PARAM1);
                    }

                    _DS = ObjDal.GetDataSetStoredProcedure("PRO_GET_ONSCRNRPT_DATA", _DictParam);
                }
            }
            catch (Exception ex)
            {
                
            }

            return _DS;
        }

        #endregion

        #region GetReportlist
        public List<MST_Forms_Entities> GetReportlist(string Roll, string REPORTTYPE)
        {
            string STR = "SELECT * FROM FUN_REPORTS_RIGHTS('" + Roll + "','" + REPORTTYPE + "')";
            var lstappl = new List<MST_Forms_Entities>();
            using (var DBHelp = new Dal())
            {
                DataTable table = DBHelp.GetDataTableDirect(STR);

                // Add Item To List
                foreach (DataRow row in table.Rows)
                {
                    var Ent = new MST_Forms_Entities();
                    Ent.FORM_ID = row["FORM_ID"].ToString();
                    Ent.MODULE_ID = row["MOD_ID"].ToString();
                    Ent.FORM_TYPE = row["FORM_TYPE"].ToString();
                    Ent.FORM_NAME = row["FORM_NAME"].ToString();
                    Ent.FORM_ETITLE = row["FORM_ETITLE"].ToString();
                    Ent.FORM_GTITLE = row["FORM_GTITLE"].ToString();
                    Ent.FORM_DESC = row["FORM_DESC"].ToString();
                    Ent.PARENT_FORM_ID = row["PARENT_FORM_ID"].ToString();
                    lstappl.Add(Ent);
                }
            }

            return lstappl;
        }

        #endregion

        #region GetReportDataset
        public DataSet GetReportDataset(string str)
        {
            var _Dict = new Dictionary<string, object>();
            DataSet _DS;
            _Dict.Add("@P_QUERY", str);
            using (var Dal = new Dal())
            {
                _DS = Dal.GetDataSetStoredProcedure("PRO_GET_REPORT_DATA", _Dict);
            }

            return _DS;
        }


        #endregion

        #region GetChequeReturn
        public DataTable GETRECPT_DET(string CHQ_NO, string MICR_NO, string CHQ_AMOUNT)
        {
            string STR = "";
            STR = "SELECT * FROM  VW_TRN_RECEIPT_PAYMODE WHERE CHQ_NO='" + CHQ_NO + "' AND CHQ_MICR='" + MICR_NO + "'";
            STR = " AND '" + CHQ_AMOUNT + "' =(SELECT SUM(CHQ_AMOUNT) FROM  VW_TRN_RECEIPT_PAYMODE WHERE CHQ_NO='" + CHQ_NO + "' AND CHQ_MICR='"+MICR_NO + "')";
            using (var dal = new Dal())
            {
                _DT = dal.GetDataTableDirect(STR);
            }

            return _DT;
        }

        #endregion

        #region Insert Application in Trn_Application Module
        public string InsertUpdateApplication(Application_Ent ObjEnt)
        {
            using (var Dbhelp = new Dal())
            {
                try
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("@P_MODE", ObjEnt.MODE);
                        withBlock.Add("@P_APP_ID", ObjEnt.APP_ID);
                        withBlock.Add("@P_TENAMENT_NO", ObjEnt.TENAMENT_NO);
                        withBlock.Add("@P_CONN_NO", ObjEnt.CONN_NO);
                        withBlock.Add("@P_TTYPE_ID", ObjEnt.TTYPE_ID);
                        withBlock.Add("@P_COUNTER_ID", ObjEnt.COUNTER_ID);
                        withBlock.Add("@P_APP_NAME", ObjEnt.APP_NAME);
                        withBlock.Add("@P_APP_CONTACT", ObjEnt.APP_CONTACT);
                        withBlock.Add("@P_APP_MOBILE", ObjEnt.APP_MOBILE);
                        withBlock.Add("@P_APP_EMAIL", ObjEnt.APP_EMAIL);
                        withBlock.Add("@P_TR_DATE", ObjEnt.TR_DATE);
                        withBlock.Add("@P_STATUS", ObjEnt.STATUS);
                        withBlock.Add("@P_NO_PROP", ObjEnt.NO_PROP);
                        withBlock.Add("@P_LST_USER", ObjEnt.LST_USER);
                        withBlock.Add("@P_ACTIVE", ObjEnt.ACTIVE);
                        withBlock.Add("@P_LST_IP", ObjEnt.LST_IP);
                    }
                    // PREOCEDURE FOR MASTER DETAILS
                    str = Dbhelp.ExecuteProcedureDynamic("PRO_TRN_APPLICATION", _DictParam);
                    if (str.Substring(0, 3) == "100")
                    {
                        Dbhelp.Commit();
                    }
                    else
                    {
                        throw new Exception(str);
                    }

                    Message = str;
                }
                catch (Exception ex)
                {
                    Dbhelp.Rollback();
                    Message = ex.Message.ToString();
                }
            }

            return Message;
        }

        #endregion

        #region GetApplication
        public DataSet GetRptapplication(string APP_ID)
        {
            try
            {
                string str = "SELECT * FROM VW_TRN_APPLICATION WHERE APP_ID= '" + APP_ID + "';SELECT * FROM VW_TRN_APPLICATION WHERE APP_ID= '" + APP_ID + "';";
                using (var ObjDal = new Dal())
                {
                    _DS = ObjDal.GetDataSet(str);
                }
            }
            catch (Exception ex)
            {
              
            }

            return _DS;
        }

        #endregion

        #region AdvanceSearch
        public DataSet AdvanceSearch(Dictionary<string, object> _ObjDict)
        {
            using (var ObjDll = new Dal())
            {
                try
                {
                    _DS = ObjDll.GetDataSetStoredProcedure("PRO_ADVANCE_SEARCH", _ObjDict);
                }
                catch (Exception ex)
                {
                    Message = ex.Message.ToString();
                }
            }

            return _DS;
        }

        #endregion

        #region GetScalarValue From String
        public string GetScalarvalue(string Str)
        {
            string Id = "";
            using (var dal = new Dal())
            {
                Id = dal.GetScalarValue(Str);
            }

            return Id;
        }

        #endregion

        #region GetDatatable From String 
        public DataTable GetDatatable(string Str)
        {
            DataTable _dt;
            using (var dal = new Dal())
            {
                _dt = dal.GetDataTableDirect(Str);
            }

            return _dt;
        }

        #endregion

        #region GetDataDataSetEXCL
        public DataSet GetDataDataSetEXCL(Common_Mst_Ent CommEnt)
        {
            using (var SqlHelp = new Dal())
            {
                try
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("@P_FLAG", CommEnt.FLAG);
                        withBlock.Add("@P_PARAM", CommEnt.PARAM);
                        withBlock.Add("@P_PARAM1", CommEnt.PARAM1);
                        withBlock.Add("@P_PARAM2", CommEnt.PARAM2);
                        withBlock.Add("@P_PARAM3", CommEnt.PARAM3);
                        withBlock.Add("@P_PARAM4", CommEnt.PARAM4);
                        withBlock.Add("@P_PARAM5", CommEnt.PARAM5);
                        withBlock.Add("@P_PARAM6", CommEnt.PARAM6);
                        withBlock.Add("@P_PARAM7", CommEnt.PARAM7);
                        withBlock.Add("@P_PARAM8", CommEnt.PARAM8);
                        withBlock.Add("@P_PARAM9", CommEnt.PARAM9);
                        withBlock.Add("@P_PARAM10", CommEnt.PARAM10);
                        withBlock.Add("@P_ROLL_ID", CommEnt.ROLL_ID);
                    }

                    _DS = SqlHelp.GetDataSetStoredProcedure("PRO_GET_MST_DATA_EXCL", _DictParam);
                }
                catch (Exception ex)
                {
                    
                }
            }

            return _DS;
        }

        #endregion

        #endregion

        public void Dispose()
        {
           // throw new NotImplementedException();
        }
    }
}
