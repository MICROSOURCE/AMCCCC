<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="TRN_New_Assesment.aspx.cs" Inherits="AMCCCC.TRANSACTION.TRN_New_Assesment" %>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
        <div class="row">
        <div class="col-sm-12">
            <div class="page-header">
                <h5>
                    <span id="lblFORM_DESC"></span>
                    <asp:Button ID="btnMODE" runat="server" CssClass="btn btn-teal btn-xs pull-right" disabled="disabled" />
                </h5>
            </div>
        </div>
    </div>
     <div class="row" id="maindiv">


        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-pencil-square"></i>Property Details
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                    </div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Tenament Number
                                    </label>
                                    <asp:TextBox ID="txtPT_TENEMENT_NUMBER" runat="server" CssClass="form-control " ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Complaint Number <span class="symbol required"></span>
                                    </label>
                                    <asp:TextBox ID="txtCOMPLAINT_NUMBER" runat="server" CssClass="form-control" ClientIDMode="Static"
                                        MaxLength="50"></asp:TextBox>

                                </div>
                            </div>
                            <div class="col-sm-3 ">
                                <div class="form-group">

                                    <label class="control-label">
                                        Effective From Date
                                    </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control date-picker" date-date-format="dd-mm-yyyy"
                                            ClientIDMode="Static"> </asp:TextBox><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>


                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="from-group">
                                    <label class="control-label">
                                        Permission Number
                                    </label>
                                    <asp:TextBox ID="txtPERMISSION_NUMBER" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>




                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="from-group">
                                    <label class="control-label">
                                        Permission Date
                                    </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtPERMISSION_DATE" runat="server" CssClass="form-control date-picker" date-date-format="dd-mm-yyyy"
                                            ClientIDMode="Static"> </asp:TextBox><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="from-group">
                                    <label class="control-label">
                                        Bill Date
                                    </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBILL_DATE" runat="server" CssClass="form-control date-picker" date-date-format="dd-mm-yyyy"
                                            ClientIDMode="Static"> </asp:TextBox><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="from-group">
                                    <label class="control-label">
                                        Bill Due Date
                                    </label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBILL_DUE_DATE" runat="server" CssClass="form-control date-picker" date-date-format="dd-mm-yyyy"
                                            ClientIDMode="Static"> </asp:TextBox><span class="input-group-addon"><i class="fa fa-calendar"></i></span>
                                    </div>
                                </div>
                            </div>

                        </div>


                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-pencil-square"></i>Property Address
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        House No
                              
                                    </label>
                                    <asp:TextBox ID="txtPRHOUSE_NAME" runat="server" CssClass="form-control tooltips"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Street <span class="symbol required"></span>

                                    </label>
                                    <asp:TextBox ID="txtPRSTREET_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"
                                        MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Landmark <span class="symbol required"></span>

                                    </label>

                                    <asp:TextBox ID="txtPRLANDMARK_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"
                                        MaxLength="50"></asp:TextBox>



                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Area
                                    </label>

                                    <asp:TextBox ID="txtPRAREA_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Country
                                    </label>
                                    <asp:DropDownList ID="ddlPRCOUNTRY_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        State
                                    </label>
                                    <asp:DropDownList ID="ddlPRSTATE_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        District
                                    </label>
                                    <asp:DropDownList ID="ddlPRDISTRICT_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        City
                                    </label>
                                    <asp:DropDownList ID="ddlPRTCITY_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        PIN Code
                                    </label>
                                    <asp:TextBox ID="txtPRPINCODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-pencil-square"></i>Postal Address
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        House No
                              
                                    </label>
                                    <asp:TextBox ID="txtPTHOUSE_NAME" runat="server" CssClass="form-control"
                                        ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Street <span class="symbol required"></span>

                                    </label>
                                    <asp:TextBox ID="txtPTSTREET_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"
                                        MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Landmark <span class="symbol required"></span>

                                    </label>

                                    <asp:TextBox ID="txtPTLANDMARK_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"
                                        MaxLength="50"></asp:TextBox>



                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class="control-label">
                                        Area
                                    </label>

                                    <asp:TextBox ID="txtPTAREA_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Country
                                    </label>
                                    <asp:DropDownList ID="ddlPTCOUNTRY_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        State
                                    </label>
                                    <asp:DropDownList ID="ddlPTSTATE_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        District
                                    </label>
                                    <asp:DropDownList ID="ddlPTDISTRICT_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        City
                                    </label>
                                    <asp:DropDownList ID="ddlPTCITY_CODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:DropDownList>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        PIN Code
                                    </label>
                                    <asp:TextBox ID="txtPTPINCODE" runat="server" CssClass="form-control" ClientIDMode="Static">
                                    </asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Torrent Service Number
                                    </label>
                                    <asp:TextBox runat="server" ID="txtTORRENT_BILL_NO" MaxLength="50"></asp:TextBox>
                                </div>
                            </div>
                        </div>


                    </div>

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-pencil-square"></i>Owner Details
                                        <div class="panel-tools">
                                            <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="row">


                            <div class="col-sm-2">
                                <div class="form-group">
                                    <label class="control-label">
                                        Full Name
                                    </label>

                                    <asp:TextBox ID="txtOFULL_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Mobile No
                                    </label>
                                    <asp:TextBox ID="txtOMOBILE_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Land Line No
                                    </label>
                                    <asp:TextBox ID="txtOLANDLINE_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Fax No
                                    </label>
                                    <asp:TextBox ID="txtOFAX_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Email
                                    </label>
                                    <asp:TextBox ID="txtOEMAIL" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="form-group">
                            <div class="text-center">
                                <asp:LinkButton ID="btnADD_OWNER" runat="server" CssClass="btn btn-primary" ValidationGroup="ValADDOWNER" OnClick="btnADD_OWNER_Click"><i class="fa fa-plus"></i> Add Item</asp:LinkButton>
                                <asp:LinkButton ID="btnCLEAR_OWNER" runat="server" CssClass="btn btn-purple"><i class="fa fa-refresh"></i> Reset</asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="table-responsive">
                                <asp:GridView ID="grvOWNER" runat="server" CssClass="table table-striped table-bordered table-hover table-full-width dataTable grid"
                                    HeaderStyle-Font-Bold="true" BorderStyle="Solid" AutoGenerateColumns="False"
                                    Width="100%" PageSize="10" EmptyDataText="No Record Found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID">
                                            <ItemTemplate>
                                                <asp:Label ID="lnkSelect" runat="server" Text='<%# Eval("SR_NO") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="OWNER_NAME" HeaderText="માલિકનું નામ" />
                                        <asp:BoundField DataField="MOBILE_NO" HeaderText="મોબાઈલ નંબર" />
                                        <asp:BoundField DataField="LANDLINE_NO" HeaderText="ઘરનો નંબર" />
                                        <asp:BoundField DataField="FAX_NO" HeaderText="ઘરનો નંબર" />
                                        <asp:BoundField DataField="EMAIL" HeaderText="ઈ-મેઈલ" />

                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Del" CssClass="btn btn-xs btn-bricky tooltips"
                                                    ToolTip="Delete" CommandArgument='<%#Eval("SR_NO")%>' OnClientClick="return confirm('Do you want to delete the record ? ');"><i class="fa fa-times fa fa-white"></i></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                    </div>

                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <i class="fa fa-pencil-square"></i>Occupier Details
                                        <div class="panel-tools">
                                            <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                                        </div>
                    </div>
                    <div class="panel-body">

                        <div class="row">

                            <div class="col-sm-4">
                                <div class="form-group">
                                    <label class="control-label">
                                        Full Name
                                    </label>

                                    <asp:TextBox ID="OCCUPIER_NAME" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>

                        <div class="row">
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Mobile No
                                    </label>
                                    <asp:TextBox ID="txtOCMOBILE_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Land Line No
                                    </label>
                                    <asp:TextBox ID="txtOCLANDLINE_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Fax No
                                    </label>
                                    <asp:TextBox ID="txtOCFAX_NO" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-sm-3">
                                <div class="form-group">
                                    <label class=" control-label">
                                        Email
                                    </label>
                                    <asp:TextBox ID="txtOCEMAIL" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>



    </div>
     <asp:UpdatePanel runat="server" ID="factor">
        <ContentTemplate>

            <div class="row" id="factordetails">
                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Survey Details
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                TP Number<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtTP_NUMBER" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                FP Number<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtFP_NUMBER" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Survey Number<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtSURVEY_CODE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Census Number<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtCENSUS_NUMBER" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Factor Details
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Type Of Property<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlUSAGE_FACTOR_CODE" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlUSAGE_FACTOR_CODE_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>

                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Rate Of Tax<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtUSGAE_FACTOR_RATE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Usage Factor
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Building Group<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlBUILDING_FACTOR_CODE" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBUILDING_FACTOR_CODE_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Building Type<span class="symbol required"></span>

                                            </label>
                                     <asp:DropDownList ID="ddlBUILDING_TYPE" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBUILDING_TYPE_SelectedIndexChanged"></asp:DropDownList>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Usage Code<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlUSAGE_CODE" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlUSAGE_CODE_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Usage Type Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtUSAGE_TYPE_RATE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Location Factor
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                            </label>
                                            <label class="control-label">
                                                As & On 2008-09<span class="symbol required"></span>

                                            </label>

                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Land Value<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtland_value2008" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtland_value2008_TextChanged"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Description<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlLOCATION_FACTOR2008" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Farctor Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtLOC_FACTOR_RATE2008" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                            </label>
                                            <label class="control-label">
                                                As & On 2013-14<span class="symbol required"></span>

                                            </label>

                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Land Value<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtLAND_VALUE2013" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtLAND_VALUE2013_TextChanged"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Description<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlLOCATION_FACTOR2013" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Farctor Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtLOC_FACTOR_RATE2013" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                            </label>
                                            <label class="control-label">
                                                As & On 2021-22<span class="symbol required"></span>

                                            </label>

                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Land Value<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtLAND_VALUE2021" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtLAND_VALUE2021_TextChanged"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Description<span class="symbol required"></span>

                                            </label>
                                            <asp:DropDownList ID="ddlLOCATION_FACTOR2021" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Location Farctor Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtLOC_FACTOR_RATE2021" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Occupancy Factor
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Type Of Occupancy
                                            </label>

                                            <asp:DropDownList runat="server" ID="ddlOCCUPANCY_FACTOR_CODE" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlOCCUPANCY_FACTOR_CODE_SelectedIndexChanged"></asp:DropDownList>



                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Occupancy Factor Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtOCCUPANCY_RATE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Water Zone<span class="symbol required"></span>

                                            </label>
                                            <asp:RadioButtonList runat="server" ID="rdlWATER_ZONE" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Text="No" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="col-sm-3">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Government Building<span class="symbol required"></span>

                                            </label>
                                            <asp:RadioButtonList runat="server" ID="rdlGOVERNMENT_BUILDING" RepeatDirection="Horizontal">
                                                <asp:ListItem Selected="True" Text="No" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-sm-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <i class="fa fa-pencil-square"></i>Floor Details
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Floor Description
                                            </label>

                                            <asp:DropDownList runat="server" ID="ddlPT_FLOOR_DTLS_CODE" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPT_FLOOR_DTLS_CODE_SelectedIndexChanged"></asp:DropDownList>



                                        </div>

                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Discount Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtDISCOUNT_RATE" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>

                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Construction Year<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtPT_YEAR_OF_CONSTRUCTION" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Age Factor Rate<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="TextBox44" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Carpet Area<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="txtPT_AREA" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-sm-2">
                                        <div class="form-group">
                                            <label class="control-label">
                                                Total Area<span class="symbol required"></span>

                                            </label>
                                            <asp:TextBox ID="TextBox46" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="form-group">
                                        <div class="text-center">
                                            <asp:LinkButton ID="btnADD_FLOORDET" runat="server" CssClass="btn btn-primary" ValidationGroup="ValADDOWNER"><i class="fa fa-plus"></i> Add Item</asp:LinkButton>
                                            <asp:LinkButton ID="btnRESET_FLOORDET" runat="server" CssClass="btn btn-purple"><i class="fa fa-refresh"></i> Reset</asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="table-responsive">
                                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover table-full-width dataTable grid"
                                                HeaderStyle-Font-Bold="true" BorderStyle="Solid" AutoGenerateColumns="False"
                                                Width="100%" PageSize="10" EmptyDataText="No Record Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ID">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lnkSelect" runat="server" Text='<%# Eval("OWNER_ID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="OWNER_NAME" HeaderText="માલિકનું નામ" />
                                                    <asp:BoundField DataField="POSTAL_ADDR" HeaderText="સરનામું" />
                                                    <asp:BoundField DataField="PINCODE" HeaderText="પીનકોડ" />
                                                    <asp:BoundField DataField="MOBILE_NO" HeaderText="મોબાઈલ નંબર" />
                                                    <asp:BoundField DataField="CONTACT_NO" HeaderText="ઘરનો નંબર" />
                                                    <asp:BoundField DataField="EMAIL_ID" HeaderText="ઈ-મેઈલ" />
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkSelect1" runat="server" CommandName="Select" CssClass="btn btn-xs btn-teal tooltips"
                                                                ToolTip="Edit" CommandArgument="<%# Container.DataItemIndex %>"><i class="fa fa-times fa fa-edit"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Del" CssClass="btn btn-xs btn-bricky tooltips"
                                                                ToolTip="Delete" CommandArgument='<%#Eval("OWNER_ID")%>' OnClientClick="return confirm('Do you want to delete the record ? ');"><i class="fa fa-times fa fa-white"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <div class="text-center">
        <asp:LinkButton ID="lkbSubmit" runat="server" CssClass="btn btn-success" ValidationGroup="valSubmit" OnClick="lkbSubmit_Click"><i class="fa fa-refresh"></i> Submit</asp:LinkButton>
        <asp:LinkButton ID="lkbClear" runat="server" CssClass="btn btn-purple"><i class="fa fa-refresh"></i> Reset</asp:LinkButton>
    </div>
</asp:Content>
