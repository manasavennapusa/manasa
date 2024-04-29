<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewITStatement.aspx.cs" Inherits="payroll_admin_ViewITStatement" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />


    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
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
                                                                            <%-- <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                            <%-- <td class="txt01" style="height: 16px">Employee Pay Slip
                                                </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top" style="width: 100%">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="txt02" style="height: 13px">View Income Tax Statement
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
                                                                            <td class="frm-lft-clr123" style="width: 11%">Financial Year
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:DropDownList ID="dd_year" runat="server" ToolTip="Financial Year"
                                                                                    CssClass="span4" DataTextField="year" DataValueField="year" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dd_year"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Month
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:DropDownList ID="dd_month" runat="server" ToolTip="Month" CssClass="span4"
                                                                                    DataTextField="month " DataValueField="month ">
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Select Month"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Employee Code  <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" AutoPostBack="true"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <a href="JavaScript:newPopup1('../../leave/pickemployee.aspx');" class="link05">Pick Employee</a>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">&nbsp;
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                                    ToolTip="Click to view Employee Payslip" />
                                                                               
                                                                            </td>
                                                                        </tr>
                                                                        <%--   <tr>
                                                <td align="left" colspan="4">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>--%>
                                                                    </table>
                                                                    <%-- <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"></CR:CrystalReportViewer>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
          <%--  <Triggers>
                <asp:PostBackTrigger ControlID="btnprint" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
