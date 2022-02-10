using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Common_Trn_Ent
    {
        public string MODE { get; set; }
        public string FLAG { get; set; }
        public string ACTIVE { get; set; }
        public string LST_USER { get; set; }
        public DateTime? LST_DATE { get; set; }
        public string LST_IP { get; set; }
        public string PARAM { get; set; }
        // 'Entities For New Application
        public string UTYPE_ID { get; set; }
        public string APP_ID { get; set; }
        public string TTYPE_ID { get; set; }
        public string COUNTER_ID { get; set; }
        public string APP_NAME { get; set; }
        public string APP_CONTACT { get; set; }
        public decimal APP_MOBILE { get; set; }
        public string APP_EMAIL { get; set; }
        public DateTime? TR_DATE { get; set; }
        public string STATUS { get; set; }
    }
}
