using AMCCCC.Helper;
using BusinessLogicLayer.TRANSACTION;
using Entity.TRANSACTION;
using System;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.TRANSACTION
{
    public partial class TRN_New_Assesment : System.Web.UI.Page
    {
        private string _message;
        private DataTable _DT;
        private DataRow _DR;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    BindCombo();
                    // reset view states
                    //ViewState("data") = null;
                    //ViewState("Add") = "0";
                    //ViewState("index") = "";
                    //ViewState("SR_NO") = 1;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        private void BindCombo()
        {
            try
            {
                Utils.FillCombo(ddlUSAGE_FACTOR_CODE, "PROP_TYPE","");
                Utils.FillCombo(ddlLOCATION_FACTOR2008, "LOCATION_FACTOR", "");
                Utils.FillCombo(ddlLOCATION_FACTOR2013, "LOCATION_FACTOR","");
                Utils.FillCombo(ddlLOCATION_FACTOR2021, "LOCATION_FACTOR", "");
                Utils.FillCombo(ddlOCCUPANCY_FACTOR_CODE, "OCCUPANCY", "");
            }
            catch (Exception ex)
            {
            }
        }

        protected void lkbSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Fillentities();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Fillentities()
        {
            try
            {
                using (New_Assesment_ENT ObjEnt = new New_Assesment_ENT())
                {
                    {
                        var withBlock = ObjEnt;
                        _DT = new DataTable();
                        withBlock.PT_TENAMENT_NUMBER = txtPT_TENEMENT_NUMBER.Text;
                        withBlock.PERMISSION_NUMBER = txtPERMISSION_NUMBER.Text;
                        withBlock.PERMISSION_DATE = Convert.ToDateTime(txtPERMISSION_DATE);
                        withBlock.COMPLAINT_NUMBER = txtCOMPLAINT_NUMBER.Text;
                        withBlock.CR_USER = Session["USER_ID"].ToString();
                        withBlock.CR_IP = Session["ip"].ToString();
                        // PROPERTY ADDRESS SAVE
                        withBlock.PR_HOUSE_NAME = txtPRHOUSE_NAME.Text;
                        withBlock.PR_STREET_NAME = txtPRSTREET_NAME.Text;
                        withBlock.PR_LANDMARK_NAME = txtPRLANDMARK_NAME.Text;
                        withBlock.PR_AREA_NAME = txtPRAREA_NAME.Text;
                        withBlock.PR_PINCODE = txtPRPINCODE.Text;
                        withBlock.PR_COUNTRY_CODE = ddlPRCOUNTRY_CODE.SelectedValue;
                        withBlock.PR_STATE_CODE = ddlPRSTATE_CODE.SelectedValue;
                        withBlock.PR_DISTRICT_CODE = ddlPRDISTRICT_CODE.SelectedValue;
                        withBlock.PR_TALUKA_CODE = null;
                        withBlock.PR_VILLAGE_CODE = null;
                        withBlock.PR_CITY_CODE = ddlPRTCITY_CODE.SelectedValue;
                        // PROPERTY POSTAL ADDRESS
                        withBlock.PT_HOUSE_NAME = txtPTHOUSE_NAME.Text;
                        withBlock.PT_STREET_NAME = txtPTSTREET_NAME.Text;
                        withBlock.PT_LANDMARK_NAME = txtPTLANDMARK_NAME.Text;
                        withBlock.PT_AREA_NAME = txtPTAREA_NAME.Text;
                        withBlock.PT_PINCODE = txtPTPINCODE.Text;
                        withBlock.PT_COUNTRY_CODE = ddlPTCOUNTRY_CODE.SelectedValue;
                        withBlock.PT_STATE_CODE = ddlPTSTATE_CODE.SelectedValue;
                        withBlock.PT_DISTRICT_CODE = ddlPTDISTRICT_CODE.SelectedValue;
                        withBlock.PT_TALUKA_CODE = null;
                        withBlock.PT_VILLAGE_CODE = null;
                        withBlock.PT_CITY_CODE = null;
                        // ' generate owner string
                        DataTable _RVTable = (DataTable)ViewState["data"];

                        StringWriter MyWriter = new StringWriter();
                        _RVTable.WriteXml(MyWriter, XmlWriteMode.IgnoreSchema, false);
                        string OwnerDetail = MyWriter.ToString();

                        withBlock.OWNER_DETAILS = OwnerDetail;
                    }
                    using (var objbal = new New_Assessment_DBAccess())
                    {
                        var _message = objbal.InsertNewAssessment(ObjEnt);
                    }
                }
                if (_message.Substring(0, 3) == "100")
                {
                    Utils.ShowMessage("S", _message);
                }
                else
                {
                    Utils.ShowMessage("I", _message);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void ddlUSAGE_FACTOR_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUSAGE_FACTOR_CODE.SelectedIndex > 0)
                {
                    Utils.FillCombo(ddlBUILDING_FACTOR_CODE, "BUILDING_GROUP", ddlUSAGE_FACTOR_CODE.SelectedValue);
                    txtUSGAE_FACTOR_RATE.Text = ddlUSAGE_FACTOR_CODE.SelectedItem.Text.Split(new Char[] { '~' }).ToString();
                    Utils.FillCombo(ddlPT_FLOOR_DTLS_CODE, "FLOOR", ddlUSAGE_FACTOR_CODE.SelectedValue);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void ddlBUILDING_FACTOR_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.FillCombo(ddlBUILDING_TYPE, "BUILDING_TYPE", ddlBUILDING_FACTOR_CODE.SelectedValue);
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }
        protected void ddlBUILDING_TYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Utils.FillCombo(ddlUSAGE_CODE, "BUILDING_USAGE", ddlBUILDING_TYPE.SelectedValue);
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void ddlUSAGE_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtUSAGE_TYPE_RATE.Text = ddlUSAGE_CODE.SelectedItem.Text.Split("~")(1);
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }

        }

        protected void ddlOCCUPANCY_FACTOR_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlOCCUPANCY_FACTOR_CODE.SelectedIndex > 0)
                {
                    txtOCCUPANCY_RATE.Text = ddlOCCUPANCY_FACTOR_CODE.SelectedItem.Text.Split("~")(1);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }
    }
    
}