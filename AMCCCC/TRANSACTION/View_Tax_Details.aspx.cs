using BusinessLogicLayer;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCCCC.TRANSACTION
{
    public partial class View_Tax_Details : System.Web.UI.Page
    {
        private string _message;
        private DataSet _DS;
        private DataRow DR;
        private DataTable DT;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Getdata(string TENAMENT_NO)
        {
            _DS = new DataSet();
            var _DictParam = new Dictionary<string, object>();
            using (var oBJeNT = new Common_Mst_Ent())
            {
                _DictParam.Clear();
                _DictParam.Add("P_TENAMENT_NO", txt_TENAMENT_NO.Text);
                using (var OBJBAL = new CommonDBAccess())
                {
                    _DS = OBJBAL.GetDataDataSetfromdict("AMCPT.PRO_GET_TAX_TENAMENT_NO", _DictParam);
                }
            }

            if (_DS.Tables[1].Rows.Count > 0)
            {
                rptfactor.DataSource = _DS.Tables[1];
                rptfactor.DataBind();
                rptfloor.DataSource = _DS.Tables[0];
                rptfloor.DataBind();
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblTOTTAX") as Label).Text = _DS.Tables[0].Select().Sum(p => Convert.ToInt32(p["NETTAX"]));
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblNETTAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p("GEN_TAX")));
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblWATERTAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p"WATER_TAX")));
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblCONSTAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p("CONSERVANCY_TAX")));
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblUSAGETAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p("USAGE_CHARGE")));
                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblEDUTAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p("EDU_TAX")));


                //(rptfloor.Controls[rptfloor.Controls.Count - 1].Controls[0].FindControl("lblTOTPROPTAX") as Label).Text = _DS.Tables[1].Select().Sum(p => Convert.ToInt32(p["TOT_PROP_TAX"]));


                factor.Visible = true;
                floor.Visible = true;
            }
        }

        protected void btnSearchReg_Click(object sender, EventArgs e)
        {
            Getdata(txt_TENAMENT_NO.Text);
        }

    }
}