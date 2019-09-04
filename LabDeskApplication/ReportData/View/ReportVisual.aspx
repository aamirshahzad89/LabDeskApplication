<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportVisual.aspx.cs" Inherits="LabDeskApplication.Report.View.ReportVisual" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css">
</head>
<body class="container body-content">
    <div class="navbar navbar-inverse navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="#">J. Lab Services</a>
            </div>
            <div class="navbar-collapse collapse">
                <ul class="nav navbar-nav">
                    <li><a href="\Fetch/FetchData">Home</a></li>
<%--                    <li><a href="\Fetch/FetchData">Home</a></li>
                    <li><a href="\Log01InitialVendor/Index">SRF Log</a></li>
                    <li><a href="\TestValues/Index">Results Log</a></li>
                    <li><a href="\TestApproaches/Index">New Test</a></li>--%>
                </ul>
            </div>
        </div>
    </div>
    <br /><br /><br />
        <form id="form1" runat="server">
            <div>
                <div class="form-group form-inline">
                    <asp:Label ID="Label1" runat="server" Text="Style-ID#"></asp:Label>
                    <asp:TextBox ID="txtStyleID" runat="server" Width="450px" class = "form-control"></asp:TextBox>
                    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" class="btn btn-primary"/>
                </div>
                <br />
                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="700px" Width="100%" BackColor="WhiteSmoke">
                </rsweb:ReportViewer>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
        </form>
        <div class="container body-content">
        <hr />
        <footer>
            <p>Powered by <b>IT Department</b> - U&amp;I Garments (Private) limited.</p>
        </footer>
    </div>







</body>
</html>
