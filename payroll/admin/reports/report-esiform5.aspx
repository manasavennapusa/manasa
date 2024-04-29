<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-esiform5.aspx.cs"
    Inherits="payroll_admin_reports_report_esiform5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
        @import "../../../css/blue1.css";
    </style>
 <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Emp_PayStructure" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
             <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1" style="width: 100%">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <%--<td width="3%" style="height: 16px">
                                                <img src="../../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>--%>
                                           <%-- <td class="txt01" style="height: 16px">
                                                &nbsp;ESI Form 6
                                            </td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top" style="width: 100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="txt02" style="height: 13px">
                                                View ESI Form 5
                                            </td>
                                            <td class="txt02" align="right">
                                                <span id="message" runat="server"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 123px; width: 100%;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Financial Year
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:DropDownList ID="dd_year" runat="server" Width="" ToolTip="Financial Year"
                                                    CssClass="span4" DataTextField="year" DataValueField="year">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Month
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:DropDownList ID="dd_month" runat="server" Width="" ToolTip="Month" CssClass="span4"
                                                    DataTextField="month " DataValueField="month ">
                                                    <asp:ListItem Value="1">1st Apr - 30th Sep</asp:ListItem>
                                                    <asp:ListItem Value="2">1st Oct - 31 st Mar</asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ToolTip="Click to view Employee Payslip" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click"
                                                    Text="Reset" />
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="left" colspan="4">
                                                Mandatory Fields (<img src="../../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
