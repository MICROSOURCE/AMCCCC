<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MainMaster.Master" AutoEventWireup="true" CodeBehind="ReportView.aspx.cs" Inherits="AMCCCC.ReportView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%@ Register Assembly="CrystalDecisions.Web, Version=10.2.3600.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"
        Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
    <!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title></title>
    </head>

    <body>
        <form id="form1" runat="server">
            <CR:CrystalReportViewer ID="crv" runat="server" DisplayGroupTree="False" DisplayToolbar="True" />
        </form>
    </body>
    <script type="text/javascript">
        window.print();
    </script>
    </html>

</asp:Content>
