using DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class CommonFunctionHandler : IDisposable
    {
        #region Class Object
     
        #endregion

        #region method
        internal partial class SurroundingClass
        {
            public static string GetIndDate(string dtStr)
            {
                string GetIndDateRet = default;
                var DBAccess = new Dal();
                try
                {
                    var indDateFormat = new CultureInfo("en-GB", true);
                    DateTime dt;
                    try
                    {
                        if (!string.IsNullOrEmpty(dtStr))
                        {
                            dt = DateTime.Parse(dtStr, indDateFormat);
                            GetIndDateRet = string.Format( "dd-MMM-yyyy");
                        }
                        else
                        {
                            GetIndDateRet = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("GetIndDate", ex);
                    }
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }

                return GetIndDateRet;
            }

            public bool IsFutureDate(DateTime pDate)
            {
                return pDate > DateTime.Today;
            }
        }
        #endregion

        public void Dispose()
        {
            // throw new NotImplementedException();
        }
    }
}
