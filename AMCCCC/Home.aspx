<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="AMCCCC.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- start: PAGE CONTENT -->
  <div class="row">
        <div class="col-sm-12">
            <!-- start: TEXT FIELDS PANEL -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    Details
                </div>
                <div class="panel-body">
                <div role="form" class="form-horizontal">
            
                    <div class="form-group">
                        <label class="col-sm-1 control-label" for="form-field-1">
                            User Id
                        </label>
                        <div class="col-sm-3">
                            <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Text Field"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <label class="col-sm-1 control-label" for="form-field-select-1">
                            Default
                        </label>
                        <div class="col-sm-4">
                            <select id="Select1" class="form-control">
                                <option value="">&nbsp;</option>
                                <option value="AL">Alabama</option>
                                <option value="AK">Alaska</option>
                                <option value="AZ">Arizona</option>
                                <option value="AR">Arkansas</option>
                                <option value="CA">California</option>
                            </select>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="text-center">
                            <asp:Button ID="btnSubmit" class="btn btn-blue" runat="server" Text="Submit" />
                            <asp:Button ID="btnDelete" class="btn btn-blue" runat="server" Text="Delete" />
                            <asp:Button ID="btnReset" class="btn btn-blue" runat="server" Text="Reset" />
                        </div>
                    </div>
                    </div>
                
                </div>
            </div>
            <!-- end: TEXT FIELDS PANEL -->
        </div>
    </div>
    <!-- end: PAGE CONTENT-->
</asp:Content>
