<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_emppayslip.aspx.cs" Inherits="payroll_admin_view_emppayslip" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../js/timepicker.js"></script>

    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Emp_PayStructure" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1" style="width: 100%">
                                   
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
                                                View Employee Pay Slip
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
                                                <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                    CssClass="blue1" DataTextField="year" DataValueField="year" AutoPostBack="True"
                                                    OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Month
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:DropDownList ID="dd_month" runat="server" Width="129px" ToolTip="Month" CssClass="blue1"
                                                    DataTextField="month " DataValueField="month ">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Select Month"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                      
                                       
                                       
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ToolTip="Click to view Employee Payslip" />
                                                
                                                <asp:Button ID="btnprint" runat="server" CssClass="button" OnClick="btnprint_Click"
                                                    Text="Print" Visible="false" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>
                                    </table>
                                  <%--  <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true">
                                    </CR:CrystalReportViewer> --%>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnprint" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>

