using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.TRANSACTION
{
    public partial class TRN_New_Assesment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //  Fillcombo()
                    //reset view states
                    ViewState["data"] = "";
                    ViewState["Add"] = "0";
                    ViewState["index"] = "";
                    ViewState["SR_NO"] = 1;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString)
            }
        }
    }
    //Private Sub Fillcombo()
    //    Try
    //        Utils.FillCombo(ddlUSAGE_FACTOR_CODE, "PROP_TYPE")
    //        Utils.FillCombo(ddlLOCATION_FACTOR2008, "LOCATION_FACTOR")
    //        Utils.FillCombo(ddlLOCATION_FACTOR2013, "LOCATION_FACTOR")
    //        Utils.FillCombo(ddlLOCATION_FACTOR2021, "LOCATION_FACTOR")
    //        Utils.FillCombo(ddlOCCUPANCY_FACTOR_CODE, "OCCUPANCY")
    //    Catch ex As Exception
    //        Utils.ShowMessage("E", ex.Message.ToString)
    //    End Try
    //End Sub
}