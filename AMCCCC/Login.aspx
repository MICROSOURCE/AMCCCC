<%@ Page Title="" EnableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AMCCCC.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="shortcut icon" type="image/ico" href="images/favicon.ico" />
    <!-- start: MAIN CSS -->
    <link rel="stylesheet" href="~/assets/plugins/bootstrap/css/bootstrap.min.css" />
    <link rel="stylesheet" href="~/assets/plugins/font-awesome/css/font-awesome.min.css" />
    <link rel="stylesheet" href="~/assets/fonts/style.css" />
    <link rel="stylesheet" href="~/assets/css/main.css" />
    <link rel="stylesheet" href="~/assets/css/main-responsive.css" />

    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="JQuery/main.js" type="text/javascript"></script>
    <!-- end: MAIN JAVASCRIPTS -->
</head>
<body class="login example2">
    <form id="form1" runat="server">
        <div class="main-login col-md-4 col-md-offset-4 col-sm-6 col-sm-offset-3">
            <div class="logo">
                <%--<%=Utils.getConStr("CORPNAME")%>--%>
                <div style="font-size: 20px;">
                    Property Tax System
                </div>
            </div>
            <!-- start: LOGIN BOX -->
            <div class="box-login">
                <h3 class="center">Sign in to your account</h3>
                <br />
                <form class="form-login" action="index.html">
                    <div class="errorHandler alert alert-danger no-display">
                        <i class="fa fa-remove-sign"></i>You have some form errors. Please check below.
                    </div>
                    <fieldset>
                        <div class="form-group">
                            <span class="input-icon">
                                <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="UserID"
                                    MaxLength="8"></asp:TextBox>
                                <i class="fa fa-user"></i></span>
                        </div>
                        <div class="form-group form-actions">
                            <span class="input-icon">
                                <asp:TextBox ID="txtPassword" runat="server" class="form-control" placeholder="Password"
                                    TextMode="Password"></asp:TextBox>
                                <i class="fa fa-lock"></i></span>
                        </div>
                        <div class="form-actions">

                            <asp:LinkButton ID="btnSubmit" runat="server" class="btn btn-bricky pull-right" OnClick="btnSubmit_Click">Login <i class="fa fa-arrow-circle-right"></i> </asp:LinkButton>
                        </div>
                        <div>
                            <asp:Label ID="lblMSG" runat="server" ForeColor="Red"></asp:Label>
                        </div>
                        <div>
                            <br />
                        </div>
                        <div>
                            <asp:Label ID="lblIP" runat="server" ForeColor="Black"></asp:Label>
                        </div>
                        <div>
                            <asp:Label ID="lblVersion" runat="server" ForeColor="black"></asp:Label>
                        </div>
                    </fieldset>
                </form>
            </div>
            <div class="copyright">
                2014 &copy; Microtech System Pvt Ltd.
            </div>
            <!-- end: COPYRIGHT -->
        </div>
    </form>
</body>
</html>

