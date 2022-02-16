using DAL;
using Entity.TRANSACTION;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.TRANSACTION
{
    public class New_Assessment_DBAccess : IDisposable
    {
        #region method
        public string InsertNewAssessment(New_Assesment_ENT ObjEnt)
        {
            string _message;
            using (var DBHelp = new Dal())
            {
                try
                {
                    _message = DBHelp.ExecuteProcedureDynamic("AMCPT.PRO_NEW_ASSESSMENT", ObjEnt);
                    if (_message.Substring(0, 3) != "100")
                    {
                        DBHelp.Rollback();
                        return _message;
                    }
                    else
                    {
                        DBHelp.Commit();
                    }
                }
                catch (Exception ex)
                {
                    _message = ex.Message.ToString();
                    DBHelp.Rollback();
                }
            }

            return _message;
        }

        #endregion
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
