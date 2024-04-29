<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reports.aspx.cs" Inherits="payroll_admin_reports_reports" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Form 5</title>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
    <style type="text/css" media="all">
        body
        {
            margin: 0;
            padding: 0;
        }
        A.link05:link
        {
            font: bold 11px Arial, Helvetica, sans-serif;
            color: #1062b6;
            text-decoration: none;
        }
        A.link05:visited
        {
            font: bold 11px Arial, Helvetica, sans-serif;
            color: #1062b6;
            text-decoration: none;
        }
        A.link05:hover
        {
            font: bold 11px Arial, Helvetica, sans-serif;
            color: #CC0000;
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <table width="711px" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <%--<td align="left" style="width:50%; height: 35px;" valign="middle">
                
                <asp:Button ID="btnback" runat="server" Text="Back" CssClass="button" OnClick="btnback_Click" /></td>--%>
                <td align="center" style="width: 50%; height: 35px;" valign="middle">
                    <a href="#" onclick="javascript:history.go(-1);" class="link05">Back</a>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"
                        Width="965px" HasSearchButton="False"  HasZoomFactorList="False"
                        HasGotoPageButton="False" HasToggleGroupTreeButton="False" BestFitPage="False"
                        Height="500px" HasDrillUpButton="False" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
