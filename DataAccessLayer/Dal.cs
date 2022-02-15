using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DataAccessLayer.DAL;
using IBM.Data.DB2;

namespace DAL
{
    public partial class Dal : IDisposable
    {

        public static string mconstr;
        DB2Connection oConnection = new DB2Connection();
        public string Version = "1.0.0.1";
        public DB2Transaction Tran;
        public string p_SCHEMA = "db2admin";

        public Dal()
        {
            mconstr = "Database=SAMPLE;uid=db2admin;pwd=db2@106;Server=103.251.219.92:50000;CurrentSchema=AMCDB";
            oConnection = Dal.getConnection();
            Tran = oConnection.BeginTransaction();
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

        public static bool GetExecuteNonQueryTransaction(string strdb2)
        {
            int intNoOfRows;
            var oConnection = getConnection();
            var oCommand = new DB2Command(strdb2, oConnection);
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

        public DataSet GetDataSet(string strdb2)
        {
            var oConnection = getConnection();
            var oDataSet = new DataSet();
            var oCommand = new DB2Command(strdb2, oConnection);
            oCommand.CommandType = CommandType.Text;
            var oAdapter = new DB2DataAdapter(oCommand);
            oAdapter.Fill(oDataSet);
            oConnection.Close();
            return oDataSet;
        }

        public static void GetExecuteNonQueryFromStoredProc(DB2Command oCommand)
        {
            var oConnection = getConnection();
            oCommand.Connection = oConnection;
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.ExecuteNonQuery();
            oConnection.Close();
        }

        public static bool GetExecuteNonQueryFromStoredProcTransaction(DB2Command oCommand)
        {
            var oConnection = getConnection();
            oCommand.Connection = oConnection;
            oCommand.CommandType = CommandType.StoredProcedure;
            DB2Transaction oTransaction = oConnection.BeginTransaction();
            oCommand.Transaction = oTransaction;
            try
            {
                oCommand.ExecuteNonQuery();
                // Commit the transaction
                oTransaction.Commit();
                return true;
            }
            catch (Exception e)
            {
                string str = e.Message;
                // Rollback the transaction
                oTransaction.Rollback();
                return false;
            }
            finally
            {
                oConnection.Close();
            }
        }

        public string GetScalarValue(string strdb2)
        {
            var oConnection = getConnection();
            var oCommand = new DB2Command(strdb2, oConnection);
            object obj = oCommand.ExecuteScalar();
            oConnection.Close();
            if (obj is null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public string GetScalarValueFromCommand(DB2Command oCmd)
        {
            var oConnection = getConnection();
            oCmd.Connection = oConnection;
            oCmd.CommandType = CommandType.StoredProcedure;
            object obj = oCmd.ExecuteScalar();
            if (obj is null)
            {
                return "";
            }
            else
            {
                return obj.ToString();
            }
        }

        public DataTable ExecuteProcedureRetTable(Dictionary<string, object> pList, string p_procname, string p_SCHEMA = "DB2ADMIN", string P_OWNER = "")
        {
            var eDt = new DataTable();
            var dt = new DataTable();
            string Arg;

            DataRow dr;
            DB2Command cmd;
            string vStr;
            vStr = "SELECT PROC.ROUTINESCHEMA AS SCHEMA_NAME,PROC.ROUTINENAME AS PROCEDURE_NAME,PARAM.PARMNAME AS PARAMETER_NAME,ROWTYPE ,TYPENAME AS DATA_TYPE,LENGTH";
            vStr += " from syscat.routines proc left join syscat.routineparms param    on proc.routineschema = param.routineschema   and proc.specificname = param.specificname";
            vStr += " where proc.routinetype = 'P'  and proc.routineschema ='" + p_SCHEMA + "' and proc.routinename= '" + p_procname + "' order by schema_name,   procedure_name,ROWTYPE;";
            eDt = GetDataTableDirect(vStr);
            cmd = new DB2Command(p_procname.ToUpper().ToString().Trim());

            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0, loopTo = eDt.Rows.Count - 1; i <= loopTo; i++)
            {
                dr = eDt.Rows[i];
                if (dr["ROWTYPE"] == "P")
                {
                    Arg = dr["PARAMETER_NAME"].ToString();
                 
                    if (string.IsNullOrEmpty(pList[Arg].ToString()))
                    {
                        cmd.Parameters.Add(dr["PARAMETER_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                            getTypeSize(dr["DATA_TYPE"].ToString())).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add(dr["PARAMETER_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                            getTypeSize(dr["DATA_TYPE"].ToString())).Value = pList[Arg].ToString().ToUpper();
                    }
                }
                else
                {
                    cmd.Parameters.Add(dr["PARAMETER_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                        getTypeSize(dr["DATA_TYPE"].ToString())).Direction = ParameterDirection.Output;
                }
            }

            eDt.Clear();
            eDt.Dispose();
            dt = GetDataTableFromStoredProcedure(cmd);
            return dt;
        }

        public static DataTable GetDataTableFromStoredProcedure(DB2Command oCommand)
        {
            var oConnection = getConnection();
            var oDataSet = new DataSet();
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.Connection = oConnection;
            var oAdapter = new DB2DataAdapter(oCommand);
            oAdapter.Fill(oDataSet);
            oConnection.Close();
            return oDataSet.Tables[0];
        }

        public DataTable GetDataTableDirect(string strdb2)
        {
            var oConnection = getConnection();
            var oDataSet = new DataSet();
            var oAdapter = new DB2DataAdapter(strdb2, oConnection);
            oAdapter.Fill(oDataSet);
            return oDataSet.Tables[0];
        }

        public DB2Type getdb2Type(string pStr)
        {
            switch (pStr.ToUpper() ?? "")
            {
                case "VARCHAR2":
                    {
                        return IBM.Data.DB2.DB2Type.VarChar;
                    }

                case "CHAR":
                    {
                        return IBM.Data.DB2.DB2Type.Char;
                    }

                case "NVARCHAR2":
                    {
                        return IBM.Data.DB2.DB2Type.NVarChar;
                    }

                case "NCHAR":
                    {
                        return IBM.Data.DB2.DB2Type.NChar;
                    }

                case "NUMBER":
                    {
                        return IBM.Data.DB2.DB2Type.Numeric;
                    }

                case "FLOAT":
                    {
                        return IBM.Data.DB2.DB2Type.Float;
                    }

                case "DATE":
                    {
                        return IBM.Data.DB2.DB2Type.DateTime;
                    }

                case "LONG":
                    {
                        return IBM.Data.DB2.DB2Type.DecimalFloat;
                    }

                case "REF CURSOR":
                    {
                        return IBM.Data.DB2.DB2Type.Cursor;
                    }

                case "VARCHAR":
                    {
                        return IBM.Data.DB2.DB2Type.VarChar;
                    }
                    // DB2Type.SQLUDTVar()

            }

            return default;
        }

        public int getTypeSize(string pStr)
        {
            switch (pStr.ToUpper() ?? "")
            {
                case "VARCHAR2":
                    {
                        return 4000;
                    }

                case "CHAR":
                    {
                        return 4000;
                    }

                case "NVARCHAR2":
                    {
                        return 4000;
                    }

                case "NCHAR":
                    {
                        return 4000;
                    }

                case "NUMBER":
                    {
                        return 38;
                    }

                case "FLOAT":
                    {
                        return 126;
                    }

                case "DATE":
                    {
                        return 30;
                    }

                case "LONG":
                    {
                        return 32760;
                    }
            }

            return default;
        }

        public string ExecuteProcedureDynamic(string p_procname, Dictionary<string, object> pList, string p_owner = "")
        {
            string str;
            string Arg;
            DB2Command cmd;
            cmd = new DB2Command(p_procname.ToUpper());
            cmd.CommandTimeout = 100000;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = oConnection;
            cmd.Transaction = Tran;
            DB2CommandBuilder.DeriveParameters(cmd);
            for (int i = 0, loopTo = cmd.Parameters.Count - 1; i <= loopTo; i++)
            {
                switch (cmd.Parameters[i].Direction)
                {
                    case var @case when @case == ParameterDirection.Input:
                    case var case1 when case1 == ParameterDirection.InputOutput:
                        {
                            Arg = cmd.Parameters[i].ParameterName;
                            if (pList[Arg] is null)
                            {
                                cmd.Parameters[i].Value = DBNull.Value;
                            }
                            else if (string.IsNullOrEmpty(pList[Arg].ToString()))
                            {
                                cmd.Parameters[i].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters[i].Value = pList[Arg];
                            }

                            break;
                        }
                }
            }

            cmd.ExecuteNonQuery();
            str = cmd.Parameters["P_RET_VAL"].Value.ToString() + "-" + cmd.Parameters["P_RET_MSG"].Value.ToString();
            return str;
        }

        public string ExecuteProcedureDynamic<T>(string p_procname, T list) where T : class
        {
            var _DictParam = new Dictionary<string, object>();
            _DictParam = (Dictionary<string, object>)DataUtil.ConvertToDict(list);
            return ExecuteProcedureDynamic(p_procname, _DictParam);
        }

        public void Rollback()
        {
            Tran.Rollback();
            Dispose();
        }

        public void Commit()
        {
            Tran.Commit();
            Dispose();
        }

        public DataSet ExecuteProcedureRetDataset(Dictionary<string, object> pList, string p_procname, string p_pckname = "X", string P_OWNER = "")
        {
            var eDt = new DataTable();
            var ds = new DataSet();
            string Arg;
            DataRow dr;
            DB2Command cmd;
            string vStr;
            vStr = "SELECT PROC.ROUTINESCHEMA AS SCHEMA_NAME,PROC.ROUTINENAME AS PROCEDURE_NAME,PARAM.PARMNAME AS PARAMETER_NAME,ROWTYPE ,TYPENAME AS DATA_TYPE,LENGTH";
            vStr += " from syscat.routines proc left join syscat.routineparms param    on proc.routineschema = param.routineschema   and proc.specificname = param.specificname";
            vStr += " where proc.routinetype = 'P'  and proc.routineschema ='" + p_SCHEMA + "' and proc.routinename= '" + p_procname + "' order by schema_name,   procedure_name,ROWTYPE;";
            eDt = GetDataTableDirect(vStr);
            if (p_pckname == "X")
            {
                cmd = new DB2Command(p_procname.ToUpper().ToString().Trim());
            }
            else
            {
                cmd = new DB2Command(p_pckname.ToUpper().ToString().Trim() + "." + p_procname.ToUpper().ToString().Trim());
            }

            cmd.CommandType = CommandType.StoredProcedure;
            // eDt = Dal.GetDataTable(vStr)
            for (int i = 0, loopTo = eDt.Rows.Count - 1; i <= loopTo; i++)
            {
                dr = eDt.Rows[i];
                if (dr["IN_OUT"] == "IN")
                {
                    Arg = dr["ARGUMENT_NAME"].ToString();
                    if (string.IsNullOrEmpty(pList[Arg].ToString()))
                    {
                        cmd.Parameters.Add(dr["ARGUMENT_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                            getTypeSize(dr["DATA_TYPE"].ToString())).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add(dr["ARGUMENT_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                            getTypeSize(dr["DATA_TYPE"].ToString())).Value = pList[Arg].ToString().ToUpper();
                    }
                }
                else
                {
                    cmd.Parameters.Add(dr["ARGUMENT_NAME"].ToString(), getdb2Type(dr["DATA_TYPE"].ToString()), 
                        getTypeSize(dr["DATA_TYPE"].ToString())).Direction = ParameterDirection.Output;
                }
            }

            eDt.Clear();
            eDt.Dispose();
            ds = GetDataSetFromStoredProcedure(cmd);
            return ds;
        }

        public static DataSet GetDataSetFromStoredProcedure(DB2Command oCommand)
        {
            var oConnection = getConnection();
            var oDataSet = new DataSet();
            oCommand.CommandType = CommandType.StoredProcedure;
            oCommand.Connection = oConnection;
            var oAdapter = new DB2DataAdapter(oCommand);
            oAdapter.Fill(oDataSet);
            oConnection.Close();
            return oDataSet;
        }

        public DataTable ExecuteProcedureDatatable(string p_procname, Dictionary<string, object> pList)
        {
            return GetDataSetStoredProcedure(p_procname, pList).Tables[0];
        }

        public DataSet GetDataSetStoredProcedure(string p_procname, Dictionary<string, object> pList)
        {
            string Arg;
            DB2Command cmd;
            DB2DataAdapter Da;
            var RetDt = new DataSet(); // = Nothing
            cmd = new DB2Command(p_procname.ToUpper());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = getConnection();
            DB2CommandBuilder.DeriveParameters(cmd);
            for (int i = 0, loopTo = cmd.Parameters.Count - 1; i <= loopTo; i++)
            {
                switch (cmd.Parameters[i].Direction)
                {
                    case var @case when @case == ParameterDirection.Input:
                        {
                            Arg = cmd.Parameters[i].ParameterName;
                            if (pList.ContainsKey(Arg) == false)
                            {
                                throw new Exception(Arg + " not found in Dictionary");
                            }

                            if (pList[Arg] is null)
                            {
                                cmd.Parameters[i].Value = DBNull.Value;
                            }
                            else if (string.IsNullOrEmpty(pList[Arg].ToString()))
                            {
                                cmd.Parameters[i].Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters[i].Value = pList[Arg];
                            }

                            break;
                        }

                    case var case1 when case1 == ParameterDirection.InputOutput:
                        {
                            cmd.Parameters[i].Value = DBNull.Value;
                            break;
                        }
                }
            }

            Da = new DB2DataAdapter(cmd);
            Da.Fill(RetDt);
            cmd.Connection.Close();
            cmd.Dispose();
            return RetDt;
        }

        public DataTable GetDataTableFromStoredProcedure(string ProcedureName, Dictionary<string, object> pList)
        {
            string Arg;
            var Dt = new DataTable();
            using (var Cn = getConnection())
            {
                using (var cmd = new DB2Command(ProcedureName, Cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DB2CommandBuilder.DeriveParameters(cmd);
                    for (int i = 0, loopTo = cmd.Parameters.Count - 1; i <= loopTo; i++)
                    {
                        switch (cmd.Parameters[i].Direction)
                        {
                            case var @case when @case == ParameterDirection.Input:
                                {
                                    Arg = cmd.Parameters[i].ParameterName;
                                    if (pList.ContainsKey(Arg) == false)
                                    {
                                        throw new Exception(Arg + " not found in Dictionary");
                                    }

                                    if (pList[Arg] is null)
                                    {
                                        cmd.Parameters[i].Value = DBNull.Value;
                                    }
                                    else if (string.IsNullOrEmpty(pList[Arg].ToString()))
                                    {
                                        cmd.Parameters[i].Value = DBNull.Value;
                                    }
                                    else
                                    {
                                        cmd.Parameters[i].Value = pList[Arg];
                                    }

                                    break;
                                }

                            case var case1 when case1 == ParameterDirection.InputOutput:
                                {
                                    cmd.Parameters[i].Value = DBNull.Value;
                                    break;
                                }
                        }
                    }

                    using (var Da = new DB2DataAdapter(cmd))
                    {
                        Da.Fill(Dt);
                    }

                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }

            return Dt;
        }
        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls
        private object DB2Type;

        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
                // TODO: set large fields to null.
            }

            disposedValue = true;
        }

        // TODO: override Finalize() only if Dispose(ByVal disposing As Boolean) above has code to free unmanaged resources.
        // Protected Overrides Sub Finalize()
        // ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
        // Dispose(False)
        // MyBase.Finalize()
        // End Sub

        // This code added by Visual Basic to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}