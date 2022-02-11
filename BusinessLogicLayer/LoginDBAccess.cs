using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.DAL;
using Entity;
//using Entity.ENT;

namespace BusinessLogicLayer
{
    public class LoginDBAccess
    {
        #region "Variable"
        public string Message = "";
        string Str = "";
        private Dictionary<string, object> _DictParam;
        #endregion
        #region "!-- Login User--!"
        //Check UserName & Password
        public string LoginUser(Login_Ent EntLogin)
        {
            using (var DBHelp = new Dal())
            {
                try
                {
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("P_USER_ID", EntLogin.USER_ID);
                        withBlock.Add("P_USER_PWD", EntLogin.USER_PWD);
                        withBlock.Add("P_LST_IP", EntLogin.LST_IP);
                        withBlock.Add("P_CR_IP", EntLogin.LST_IP);
                    }

                    Message = DBHelp.ExecuteProcedureDynamic("AMCDB.PRO_LOGIN", _DictParam);

                    if (Message.Substring(0, 3) != "100")
                        return Message;
                    else
                        DBHelp.Commit();
                }
                catch (Exception ex)
                {
                    Message = ex.Message.ToString();
                }
            }
            return Message;
        }
        #endregion
        #region "!-- Create user --!"
        public string Createuser(Login_Ent EntLogin)
        {
            using (var DBHelp = new Dal())
            {
                try
                {
                    //Bind parameter
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("P_MODE", EntLogin.MODE);
                        withBlock.Add("P_USER_ID", EntLogin.USER_ID);
                        withBlock.Add("P_USER_NAME", EntLogin.USER_NAME);
                        withBlock.Add("P_USER_SRT_NAME", EntLogin.USER_SRT_NAME);
                        withBlock.Add("P_USER_PWD", EntLogin.USER_PWD);
                        withBlock.Add("P_ROLE_ID", EntLogin.ROLE_ID);
                        withBlock.Add("P_EMP_ID", EntLogin.EMP_ID);
                        withBlock.Add("P_ACTIVE", EntLogin.ACTIVE);
                        withBlock.Add("P_LST_USER", EntLogin.LST_USER);
                        withBlock.Add("P_LST_IP", EntLogin.LST_IP);
                    }
                    Str = DBHelp.ExecuteProcedureDynamic("PRO_MST_USER", _DictParam);

                    //Transaction Commite/Rollback as PEr Confirmation Message
                    if (Str.Substring(0, 3) != "100")
                        throw new Exception(Str);
                    else
                        DBHelp.Commit();

                    Message = Str;
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
        #region "!-- Change Password --!"
        public string ChangePassword(Login_Ent EntLogin)
        {
            using (var DBHelp = new Dal())
            {
                try
                {
                    //Bind parameter
                    {
                        var withBlock = _DictParam;
                        withBlock.Clear();
                        withBlock.Add("P_MODE", EntLogin.MODE);
                        withBlock.Add("P_USER_ID", EntLogin.USER_ID);
                        withBlock.Add("P_USER_NAME", "");
                        withBlock.Add("P_USER_SRT_NAME", "");
                        withBlock.Add("P_USER_PWD", EntLogin.USER_PWD);
                        withBlock.Add("P_ROLE_ID", "");
                        withBlock.Add("P_EMP_ID", "");
                        withBlock.Add("P_ACTIVE", EntLogin.ACTIVE);
                        withBlock.Add("P_LST_USER", EntLogin.LST_USER);
                        withBlock.Add("P_LST_IP", EntLogin.LST_IP);
                    }
                    Str = DBHelp.ExecuteProcedureDynamic("AMCDB.PRO_MST_USER", _DictParam);

                    //Transaction Commite/Rollback as PEr Confirmation Message
                    if (Str.Substring(0, 3) != "100")
                        throw new Exception(Str);
                    else
                        DBHelp.Commit();

                    Message = Str;
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
    }
}
