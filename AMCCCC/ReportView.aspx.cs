//using AMCCCC.Models;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.IO;

namespace AMCCCC
{
    //public partial class ReportView : System.Web.UI.Page
    //{
    //    #region Variable
    //    private ReportDocument vRep;
    //    #endregion

    //    #region Methods

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        try
    //        {
    //            if (Session["USER_ID"] == "")
    //            {
    //                Response.Redirect("~/Login.aspx");
    //                return;
    //            }

    //            string RPT_NAME = Session["REPORT"].ToString();
    //            string v_formula = "";

    //            var vDS = new DataSet();
    //            vDS = (DataSet)Session["DS"];

    //            if (Session["REPORT"] == "rcptPTAX.rpt")
    //            {
    //                vDS.Tables[0].TableName = "VW_TRN_RECEIPT";
    //                vDS.Tables[1].TableName = "VW_TRN_RECEIPT_DET";
    //                vDS.Tables[2].TableName = "VW_TRN_WATERRECEIPT_DET";
    //            }

    //            string cpath = System.Web.HttpRuntime.AppDomainAppPath + @"REPORTS\";
    //            cpath = cpath + RPT_NAME;
    //            // vRep.Load(cpath);
    //           // ShowMe(vRep, vDS, default, v_formula);
    //        }
    //        catch (Exception ex)
    //        {            
    //            //Utils.ShowMessage("E", ex.Message);
    //        }
    //    }

    //    public void ShowMe(ReportDocument pReport, DataSet pDS, string pParams = null, string pFormula = null, string pFormulaSub = null)
    //    {
    //        string strParamenters;
    //        int formula_count;
    //        string strforfield;
    //        string[] strforfieldPair;
    //        int intCounter;
    //        int index;
    //        string[] strParValPair;
    //        string[] strVal;
    //        var paraValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
    //        CrystalDecisions.Shared.ParameterValues currValue;
    //        var TblInfo = new TableLogOnInfo();
    //        {
    //            var withBlock = TblInfo.ConnectionInfo;
    //            withBlock.ServerName = Utils.getConStr("Datasource");
    //            withBlock.DatabaseName = Utils.getConStr("DataBase");
    //            withBlock.UserID = Utils.getConStr("user");
    //            withBlock.Password = Utils.getConStr("pwd");
    //        }

    //        pReport.Database.Tables(0).SetDataSource(pDS.Tables[0]);
    //        pReport.Database.Tables(0).ApplyLogOnInfo(TblInfo);
    //        pReport.RecordSelectionFormula = "";
    //        for (int i = 0, loopTo = pReport.Subreports.Count - 1; i <= loopTo; i++)
    //        {
    //            if (pReport.Subreports(i).Database.Tables.Count > 0)
    //            {
    //                pReport.Subreports(i).Database.Tables(0).ApplyLogOnInfo(TblInfo);
    //                pReport.Subreports(i).Database.Tables(0).SetDataSource(pDS.Tables[pReport.Subreports(i).Database.Tables(0).Name]);
    //                // .Subreports(i).RecordSelectionFormula = ""
    //            }
    //        }

    //        formula_count = pReport.DataDefinition.FormulaFields.Count;
    //        if (pParams is object)
    //        {
    //            intCounter = pReport.DataDefinition.ParameterFields.Count;
    //            if (intCounter == 1)
    //            {
    //                if (Strings.InStr(pReport.DataDefinition.ParameterFields(0).ParameterFieldName, ".", CompareMethod.Text) > 0)
    //                {
    //                    intCounter = 0;
    //                }
    //            }
    //            // For Parameter fields
    //            if (intCounter > 0 & !string.IsNullOrEmpty(Strings.Trim(pParams)))
    //            {
    //                strParamenters = pParams;
    //                strParValPair = strParamenters.Split("&");
    //                var loopTo1 = Information.UBound(strParValPair);
    //                for (index = 0; index <= loopTo1; index++)
    //                {
    //                    if (Strings.InStr(strParValPair[index], "=") > 0)
    //                    {
    //                        strVal = strParValPair[index].Split("=");
    //                        paraValue.Value = strVal[1];
    //                        currValue = pReport.DataDefinition.ParameterFields(strVal[0]).CurrentValues;
    //                        currValue.Add(paraValue);
    //                        pReport.DataDefinition.ParameterFields(strVal[0]).ApplyCurrentValues(currValue);
    //                    }
    //                }
    //            }
    //        }

    //        // For formula fields
    //        if (pFormula is object | !string.IsNullOrEmpty(pFormula))
    //        {
    //            pReport.RecordSelectionFormula = "";
    //            if (formula_count > 0 & !string.IsNullOrEmpty(Strings.Trim(pFormula)))
    //            {
    //                strforfield = pFormula;
    //                strforfieldPair = pFormula.Split("&");
    //                var loopTo2 = Information.UBound(strforfieldPair);
    //                for (index = 0; index <= loopTo2; index++)
    //                {
    //                    if (Strings.InStr(strforfieldPair[index], "=") > 0)
    //                    {
    //                        strVal = strforfieldPair[index].Split("=");
    //                        pReport.DataDefinition.FormulaFields(strVal[0].ToString()).Text = strVal[1].ToString().Trim().ToUpper();
    //                        // pReport.DataDefinition.FormulaFields(strVal(0)).Text = 
    //                    }
    //                }
    //            }
    //        }

    //        // For SubReport Formulas
    //        if (pFormulaSub is object)
    //        {
    //            if (pReport.Subreports.Count > 0)
    //            {
    //                formula_count = pReport.Subreports(0).DataDefinition.FormulaFields.Count;
    //                if (formula_count > 0 & !string.IsNullOrEmpty(Strings.Trim(pFormulaSub)))
    //                {
    //                    strforfield = pFormulaSub;
    //                    strforfieldPair = pFormulaSub.Split("&");
    //                    var loopTo3 = Information.UBound(strforfieldPair);
    //                    for (index = 0; index <= loopTo3; index++)
    //                    {
    //                        if (Strings.InStr(strforfieldPair[index], "=") > 0)
    //                        {
    //                            strVal = strforfieldPair[index].Split("=");
    //                            pReport.Subreports(0).DataDefinition.FormulaFields.Item(strVal[0]).Text = strVal[1];
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        {
    //            var withBlock1 = crv;
    //            withBlock1.ReportSource = pReport;
    //            withBlock1.RefreshReport();
    //        }

    //        ExportRpt(pReport);
    //    }

    //    private void CloseReports(ReportDocument reportDocument)
    //        {
    //            Sections sections = reportDocument.ReportDefinition.Sections;
    //            foreach (Section section in sections)
    //            {
    //                ReportObjects reportObjects = section.ReportObjects;
    //                foreach (ReportObject reportObject in reportObjects)
    //                {
    //                    if (reportObject.Kind == ReportObjectKind.SubreportObject)
    //                    {
    //                        SubreportObject subreportObject = (SubreportObject)reportObject;
    //                        ReportDocument subReportDocument = subreportObject.OpenSubreport(subreportObject.SubreportName);
    //                        subReportDocument.Close();
    //                        subReportDocument.Dispose();
    //                    }
    //                }
    //            }

    //            reportDocument.Close();
    //            reportDocument.Dispose();
    //        }

    //    public void ExportRpt(ReportDocument reportDocument)
    //        {
    //            try
    //            {
    //                var stream = new BinaryReader(reportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
    //                Response.ClearContent();
    //                Response.ClearHeaders();
    //                Response.ContentType = "application/pdf";
    //                Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
    //                Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
    //                Response.Flush();
    //                Response.Close();
    //            }
    //            catch
    //            {
    //            }
    //            finally
    //            {
    //                reportDocument.Dispose();
    //            }
    //        }

    //    private void ExportPdf(ReportDocument orpt)
    //    {
    //        try
    //        {
    //            if (!Page.IsPostBack)
    //            {
    //                // Open ReportDocument to browser
    //                // orpt.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, False, "data")
    //                // Export Pdf by Memomry Stream
    //                var objMem = new MemoryStream();
    //                objMem = orpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
    //                System.Web.HttpContext.Current.Response.Clear();
    //                System.Web.HttpContext.Current.Response.Buffer = false;
    //                System.Web.HttpContext.Current.Response.ClearContent();
    //                System.Web.HttpContext.Current.Response.ClearHeaders();
    //                System.Web.HttpContext.Current.Response.ContentType = "application/pdf";
    //                System.Web.HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename=" + Session("REPORT").ToString.Split(".")(0) + ".pdf"));
    //                System.Web.HttpContext.Current.Response.BinaryWrite(objMem.ToArray());
    //                objMem.Close();
    //                objMem.Dispose();
    //                GC.Collect();
    //                System.Web.HttpContext.Current.ApplicationInstance.CompleteRequest();
    //                orpt.Dispose();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Response.Write("PDF Generation Failed.");
    //        }
    //    }

    //     protected void Page_Unload(object sender, EventArgs e)
    //        {
    //            if (Session["USER_ID"] == "")
    //            {
    //                return;
    //            }
    //            // CloseReports(vRep)
    //            crv.Dispose();
    //            crv.ReportSource = null;
    //            if (vRep is object)
    //            {
    //                vRep.Dispose();
    //            }

    //            GC.Collect();
    //            GC.SuppressFinalize(true);
    //        }
        
    //    #endregion
    //}
}