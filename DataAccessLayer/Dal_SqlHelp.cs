using System;
using System.Data;
using IBM.Data.DB2;
using IBM.Data.DB2Types;

namespace DAL
{
    public partial class Dal_SqlHelp
    {
        public static string mconstr;
        public DB2Connection oConnection = new DB2Connection();
        public string Version = "1.0.0.1";

        public Dal_SqlHelp()
        {

            // '  mconstr = "Data Source='" & Datasource() & "';Initial Catalog='" & DataBase() & "';User ID= '" & user() & "';Password= '" & pwd & "';Connection Timeout=500;"
            mconstr = "Database=SAMPLE;uid=db2admin;pwd=db2@106Server=100.100.100.106:50000";
        }

        public static DB2Connection getConnection()
        {
            var oConnection = new DB2Connection();
            oConnection.ConnectionString = mconstr;
            oConnection.Open();
            return oConnection;
        }

        public void GetExecuteNonQuery(string strdb2)
        {
            var oConnection = getConnection();
            var oCommand = new DB2Command(strdb2, oConnection);
            oCommand.ExecuteNonQuery();
            oConnection.Close();
        }

        public static bool GetExecuteNonQueryTransaction(string strSql)
        {
            int intNoOfRows;
            var oConnection = getConnection();
            var oCommand = new DB2Command(strSql, oConnection);
            DB2Transaction oTransaction = oConnection.BeginTransaction();
            oCommand.Transaction = oTransaction;
            try
            {
                intNoOfRows = oCommand.ExecuteNonQuery();
                oTransaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                throw e;
                oTransaction.Rollback();
                return false;
            }
            finally
            {
                oConnection.Close();
            }
        }

        public DataSet GetDataSet(string strSql)
        {
            var oConnection = getConnection();
            var oDataSet = new DataSet();
            var oCommand = new DB2Command(strSql, oConnection);
            var oAdapter = new DB2DataAdapter(oCommand);
            oAdapter.Fill(oDataSet);
            oConnection.Close();
            return oDataSet;
        }
    }
}