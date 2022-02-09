using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class Common_Mst_Ent : IDisposable
    {
        #region "Property"
        public string MODE { get; set; }
        public string ACTIVE { get; set; }
        public string LST_USER { get; set; }
        public DateTime? LST_DATE { get; set; }
        public string LST_IP { get; set; }
        public string PARAM4 { get; set; }
        public string PARAM5 { get; set; }
        public string PARAM6 { get; set; }
        public string PARAM7 { get; set; }
        public string PARAM8 { get; set; }
        public string PARAM9 { get; set; }
        public string PARAM10 { get; set; }
        public string ROLL_ID { get; set; }
        public string CR_USER { get; set; }
        public DateTime? CR_DATE { get; set; }
        public string CR_IP { get; set; }
        public string UP_USER { get; set; }
        public DateTime? UP_DATE { get; set; }
        public string UP_IP { get; set; }
        public string DEL_USER { get; set; }
        public DateTime? DEL_DATE { get; set; }
        public string FLAG { get; set; }
        public string PARAM { get; set; }
        public string PARAM1 { get; set; }
        public string PARAM2 { get; set; }
        public string PARAM3 { get; set; }
        public DateTime? FROM_DATE { get; set; }
        public DateTime? TO_DATE { get; set; }
        public string ROLE_ID { get; set; }
        #endregion
        #region IDisposable Support
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
