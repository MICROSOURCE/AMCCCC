using AMCCCC.Helper;
using BusinessLogicLayer;
using BusinessLogicLayer.TRANSACTION;
using Entity;
using Entity.TRANSACTION;
using System;
using System.Data;
using System.IO;
using System.Web.UI;

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
                txtUSAGE_TYPE_RATE.Text = ddlUSAGE_CODE.SelectedItem.Text.Split(new Char[] { '~' }).ToString();
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
                    txtOCCUPANCY_RATE.Text = ddlOCCUPANCY_FACTOR_CODE.SelectedItem.Text.Split(new Char[] { '~' }).ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void ddlPT_FLOOR_DTLS_CODE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlPT_FLOOR_DTLS_CODE.SelectedIndex > 0)
                {
                    txtDISCOUNT_RATE.Text = ddlPT_FLOOR_DTLS_CODE.SelectedItem.Text.Split(new Char[] { '~' }).ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void txtland_value2008_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUSAGE_FACTOR_CODE.SelectedIndex > 0 & Convert.ToInt32(txtland_value2008.Text) > 0)
                {
                    using (var oBJeNT = new Common_Mst_Ent())
                    {
                        oBJeNT.FLAG = "LANDVAL_2008";
                        oBJeNT.PARAM = ddlUSAGE_FACTOR_CODE.SelectedValue;
                        oBJeNT.PARAM1 =txtland_value2008.Text;
                        oBJeNT.CR_USER = Convert.ToString(Session["USER_ID"]);
                        oBJeNT.ROLE_ID = Convert.ToString(Session["USER_ROLE"]);
                        using (var OBJBAL = new CommonDBAccess())
                        {
                            _DT = OBJBAL.GetData("AMCPT.PRO_GET_MST_DATA", oBJeNT);
                        }
                    }

                    if (_DT.Rows.Count > 0)
                    {
                        ddlLOCATION_FACTOR2008.SelectedValue = Convert.ToString(_DT.Rows[0]["LOCATION_TYPE_DESC_CODE"].ToString());
                        txtLOC_FACTOR_RATE2008.Text = Convert.ToString(_DT.Rows[0]["LOCATION_FACTOR_RATE"].ToString());
                    }
                }
                else
                {
                    ddlLOCATION_FACTOR2008.SelectedIndex = 0;
                    txtLOC_FACTOR_RATE2008.Text = "";
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void txtLAND_VALUE2013_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUSAGE_FACTOR_CODE.SelectedIndex > 0 & Convert.ToInt32(txtLAND_VALUE2013.Text) > 0)
                {
                    using (var oBJeNT = new Common_Mst_Ent())
                    {
                        oBJeNT.FLAG = "LANDVAL_2013";
                        oBJeNT.PARAM = ddlUSAGE_FACTOR_CODE.SelectedValue;
                        oBJeNT.PARAM1 = txtLAND_VALUE2013.Text;
                        oBJeNT.CR_USER = Convert.ToString(Session["USER_ID"]);
                        oBJeNT.ROLE_ID = Convert.ToString(Session["USER_ROLE"]);
                        using (var OBJBAL = new CommonDBAccess())
                        {
                            _DT = OBJBAL.GetData("AMCPT.PRO_GET_MST_DATA", oBJeNT);
                        }
                    }

                    if (_DT.Rows.Count > 0)
                    {
                        txtLOC_FACTOR_RATE2013.Text = Convert.ToString(_DT.Rows[0]["LOCATION_FACTOR_RATE"]);
                        ddlLOCATION_FACTOR2013.SelectedValue = Convert.ToString(_DT.Rows[0]["LOCATION_TYPE_DESC_CODE"]);
                    }
                }
                else
                {
                    ddlLOCATION_FACTOR2013.SelectedIndex = 0;
                    txtLOC_FACTOR_RATE2013.Text = Convert.ToString(_DT.Rows[0]["LOCATION_FACTOR_RATE"]);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void txtLAND_VALUE2021_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlUSAGE_FACTOR_CODE.SelectedIndex > 0 & Convert.ToInt32(txtLAND_VALUE2021.Text) > 0)
                {
                    using (var oBJeNT = new Common_Mst_Ent())
                    {
                        oBJeNT.FLAG = "LANDVAL_2013";
                        oBJeNT.PARAM = ddlUSAGE_FACTOR_CODE.SelectedValue;
                        oBJeNT.PARAM1 = txtLAND_VALUE2021.Text;
                        oBJeNT.CR_USER = Convert.ToString(Session["USER_ID"]);
                        oBJeNT.ROLE_ID = Convert.ToString(Session["USER_ROLE"]);
                        using (var OBJBAL = new CommonDBAccess())
                        {
                            _DT = OBJBAL.GetData("AMCPT.PRO_GET_MST_DATA", oBJeNT);
                        }
                    }

                    if (_DT.Rows.Count > 0)
                    {
                        ddlLOCATION_FACTOR2021.SelectedValue = Convert.ToString(_DT.Rows[0]["LOCATION_TYPE_DESC_CODE"]);
                        txtLOC_FACTOR_RATE2021.Text = Convert.ToString(_DT.Rows[0]["LOCATION_FACTOR_RATE"]);
                    }
                }
                else
                {
                    ddlLOCATION_FACTOR2021.SelectedIndex = 0;
                    txtLOC_FACTOR_RATE2021.Text = Convert.ToString(_DT.Rows[0]["LOCATION_FACTOR_RATE"]);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        private DataTable OwnerDetDatatable()
        {
            var _dtown = new DataTable();
            _dtown.Columns.Add("OWNER_NAME");
            _dtown.Columns.Add("MOBILE_NO");
            _dtown.Columns.Add("LANDLINE_NO");
            _dtown.Columns.Add("FAX_NO");
            _dtown.Columns.Add("EMAIL");
            _dtown.Columns.Add("SR_NO");
            return _dtown;
        }

        private void AddOwnerToGrid()
        {
            try
            {
                var DT = new DataTable();
                if (ViewState["Add"].ToString() == "1")
                {
                    DT = (DataTable)ViewState["data"];
                }

                if (ViewState["Add"].ToString() == "0")
                {
                    DT = OwnerDetDatatable();
                }

                if (ViewState["index"].ToString() == "")
                {
                    _DR = DT.NewRow();
                }
                else
                {
                    DT.PrimaryKey = new DataColumn[] { DT.Columns["SR_NO"] };
                    _DR = DT.Rows.Find(Session["SR_NO"]);
                }

                if (ViewState["index"].ToString() == "")
                {
                    _DR["SR_NO"] = ViewState["SR_NO"];
                }
                else
                {
                    _DR["SR_NO"] = Session["SR_NO"].ToString();
                }
          


                // 'Set Value In Datatable
            _DR["OWNER_NAME"] = txtOFULL_NAME.Text.Trim();
                _DR["MOBILE_NO"] = txtOMOBILE_NO.Text.Trim();
                _DR["LANDLINE_NO"] = txtOLANDLINE_NO.Text.Trim();
                _DR["FAX_NO"] = txtOFAX_NO.Text.Trim();
                _DR["EMAIL"] = txtOEMAIL.Text.Trim();
                if (ViewState["index"].ToString() == "")
                {
                   _DT.Rows.Add(_DR);
                }

                grvOWNER.DataSource = _DT;
                grvOWNER.DataBind();
                ViewState["data"] = _DT;
                ViewState["Add"] = "1";
                ViewState["index"] = "";
                Session["SR_NO"] = "";
                ViewState["SR_NO"] = ViewState["SR_NO"].ToString() + 1;
            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }
        }

        protected void btnADD_OWNER_Click(object sender, EventArgs e)
        {
            try
            {
                AddOwnerToGrid();

            }
            catch (Exception ex)
            {
                Utils.ShowMessage("E", ex.Message.ToString());
            }

        }
    }

}