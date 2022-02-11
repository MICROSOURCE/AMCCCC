using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Login_Ent : Common_Mst_Ent
    {
        public string USER_ID { get; set; }
        public string USER_NAME { get; set; }
        public string USER_SRT_NAME { get; set; }
        public string USER_PWD { get; set; }
        public string ROLE_ID { get; set; }
        public string EMP_ID { get; set; }

        public string MOD_ID { get; set; }
        public string MOD_ENAME { get; set; }
        public string ROLE_NAME { get; set; }
        public string MOD_PATH { get; set; }
        public string MOD_DESC { get; set; }
        public string MOD_CLASS { get; set; }
    }
}
