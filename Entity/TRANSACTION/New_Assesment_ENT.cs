using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.TRANSACTION
{
    public class New_Assesment_ENT : Common_Mst_Ent
    {
        public string PT_TENAMENT_NUMBER { get; set; }
        public string PERMISSION_NUMBER { get; set; }
        public DateTime? PERMISSION_DATE { get; set; }
        public string COMPLAINT_NUMBER { get; set; }
        public string PR_HOUSE_NAME { get; set; }
        public string PR_STREET_NAME { get; set; }
        public string PR_LANDMARK_NAME { get; set; }
        public string PR_AREA_NAME { get; set; }
        public string PR_PINCODE { get; set; }
        public string PR_COUNTRY_CODE { get; set; }
        public string PR_STATE_CODE { get; set; }
        public string PR_DISTRICT_CODE { get; set; }
        public string PR_TALUKA_CODE { get; set; }
        public string PR_VILLAGE_CODE { get; set; }
        public string PR_CITY_CODE { get; set; }
        public string PT_HOUSE_NAME { get; set; }
        public string PT_STREET_NAME { get; set; }
        public string PT_LANDMARK_NAME { get; set; }
        public string PT_AREA_NAME { get; set; }
        public string PT_PINCODE { get; set; }
        public string PT_COUNTRY_CODE { get; set; }
        public string PT_STATE_CODE { get; set; }
        public string PT_DISTRICT_CODE { get; set; }
        public string PT_TALUKA_CODE { get; set; }
        public string PT_VILLAGE_CODE { get; set; }
        public string PT_CITY_CODE { get; set; }
        public string OWNER_DETAILS { get; set; }
    }
}
