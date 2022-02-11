<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="View_Tax_Details.aspx.cs" Inherits="AMCCCC.TRANSACTION.View_Tax_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-sm-12">
            <div class="page-header center">
                <h3>Tax Details
                </h3>
            </div>

        </div>
    </div>
     <div class="row">
        <div class="col-sm-8 col-centered">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <i class="fa fa-pencil-square"></i>
                    <div class="panel-tools">
                        <a href="#" class="btn btn-xs btn-link panel-collapse collapses"></a>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label">
                                Tenament No
                            </label>
                            <div class="col-sm-5">
                                <asp:TextBox ID="txt_TENAMENT_NO" runat="server" CssClass="form-control " ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <asp:LinkButton ID="btnSearchReg" runat="server" CssClass="btn btn-primary" OnClick="btnSearchReg_Click"><i class="fa fa-search"></i> Search</asp:LinkButton>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="row" id="factor" runat="server" visible="false">
        <div class="col-sm-8 col-centered">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <asp:Repeater ID="rptfactor" runat="server">
                            <HeaderTemplate>
                                <table class="table-responsive table-bordered table">
                                    <thead>
                                        <tr class="badge-default fontbold" style="color: white">
                                            <th style="text-align: center;">Factor
                                            </th>
                                            <th style="text-align: center;">Description
                                            </th>
                                            <th style="text-align: center;">Rate
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <th>Type of Property</th>
                                        <td><%# Eval("PROPERTY_TYPE_DESC")%></td>
                                        <td><%# Eval("USAGE_FACTOR_RATE")%></td>
                                    </tr>
                                    <tr>
                                        <th>Building Type</th>
                                        <td><%# Eval("BUILDING_FACTOR_DESC")%></td>
                                        <td><%# Eval("BUILDING_FACTOR_RATE")%></td>
                                    </tr>
                                    <tr>
                                        <th>Type of Occupancy</th>
                                        <td><%# Eval("OCCUPANCY_FACTOR_DESCRIPTION")%></td>
                                        <td><%# Eval("PT_OCCUPANCY_FACTOR_RATE")%></td>
                                    </tr>
                                    <tr>
                                        <th>Location Factor</th>
                                        <td><%# Eval("LOCATION_FACTOR_DESCRIPTION")%></td>
                                        <td><%# Eval("LOCATION_FACTOR_RATE")%></td>
                                    </tr>
                                    <tr>
                                        <th>Government Building</th>
                                        <%--<td><%# IIf(Eval("GOVERNMENT_BUILDING") = 1, "Yes", "No")%></td>--%>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <th>Water Zone</th>
                                        <%-- <td><%# IIf(Eval("WATER_ZONE") = 1, "Yes", "No")%></td>--%>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <th>Building Age</th>
                                        <td><%# Eval("MAX_AGE")%></td>
                                        <td>-</td>
                                    </tr>
                                    <tr>
                                        <th>Age Factor Rate</th>
                                        <td><%# Eval("AGE_FACTOR")%></td>
                                        <td>-</td>
                                    </tr>
                                </tbody>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
     <div class="row" id="floor" runat="server" visible="false">
        <div class="col-sm-8 col-centered">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="form-horizontal">
                        <asp:Repeater ID="rptfloor" runat="server">
                            <HeaderTemplate>
                                <table class="table-responsive table-bordered table">
                                    <thead>
                                        <tr class="badge-default fontbold" style="color: white">
                                            <th style="text-align: center;">Sr. No.
                                            </th>
                                            <th style="text-align: center;">Floor Description
                                            </th>
                                            <th style="text-align: center;">Construction Year
                                            </th>
                                            <th style="text-align: center;">Age Factor Rate (F2)
                                            </th>
                                            <th style="text-align: center;">Carpet Area
                                            </th>
                                            <th style="text-align: center;">Gross Tax = R*F1*F2*F3*F4
                                            </th>
                                            <th style="text-align: center;">Discount Rate %
                                            </th>
                                            <th style="text-align: center;">Net Tax
                                            </th>
                                        </tr>
                                    </thead>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblRowNumber" Text='<%# Container.ItemIndex + 1 %>' runat="server" /></td>
                                        <td><%# Eval("FLOOR_DESCRIPTION")%></td>
                                        <td style="text-align: right;"><%# Eval("PT_YEAR_OF_CONSTRUCTION")%></td>
                                        <td style="text-align: right;"><%# Eval("AGE_FACTOR")%></td>
                                        <td style="text-align: right;"><%# Eval("PT_AREA")%> sq.mtr</td>
                                        <td style="text-align: right;"><%# Eval("GROSSTAX")%></td>
                                        <td style="text-align: right;"><%# Eval("DISCOUNT")%></td>
                                        <td style="text-align: right;"><%# Eval("NETTAX")%></td>
                                    </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Total Tax</th>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblTOTTAX" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Net Tax</th>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblNETTAX" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Water Tax</th>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblWATERTAX" runat="server" Text=""></asp:Label>


                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Conservancy Tax</th>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblCONSTAX" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Usage Charge</th>
                                    <td style="text-align: right;">
                                        <asp:Label ID="lblUSAGETAX" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Education Cess</th>
                                    <td style="text-align: right;">
                                       <asp:Label ID="lblEDUTAX" runat="server" Text=""></asp:Label> </td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Service Tax</th>
                                    <td style="text-align: right;">0</td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Estate Rent</th>
                                    <td style="text-align: right;">0</td>
                                </tr>
                                <tr>
                                    <th colspan="7" style="text-align: right;">Total Property Tax</th>
                                    <td style="text-align: right;">
                                        
                                        <asp:Label ID="lblTOTPROPTAX" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
