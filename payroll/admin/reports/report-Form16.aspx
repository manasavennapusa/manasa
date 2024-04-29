<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-form16.aspx.cs" Inherits="payroll_admin_view_payslip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
        @import "../../../css/blue1.css";
    </style>

    <link href="../../../css/blue1.css" rel="stylesheet" />
    <link href="../../../css/main.css" rel="stylesheet" />
    <script src="../../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
                <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 100%" class="blue-brdr-1" valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <%-- <td style="height: 16px" width="3%">
                                                                <img height="16" src="../../../images/employee-icon.jpg" width="16" />
                                                            </td>--%>
                                                                                        <%-- <td style="height: 16px" class="txt01">Employee TDS Form
                                                            </td>--%>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4" height="5"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%" valign="top" height="20">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="height: 13px" class="txt02">Generate Employee TDS Form
                                                                                        </td>
                                                                                        <td class="txt02" align="right" style="height: 13px">
                                                                                            <span id="message" runat="server"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%; height: 123px" valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 11%" class="frm-lft-clr123">Financial Year
                                                                                        </td>
                                                                                        <td style="width: 27%" class="frm-rght-clr123">
                                                                                            <asp:DropDownList ID="dd_year" runat="server" DataValueField="financialyear" DataTextField="financialyear"
                                                                                                CssClass="span4" ToolTip="Financial Year" Width="" DataSourceID="SqlDataSource12">
                                                                                            </asp:DropDownList>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ToolTip="Select Financial Year"
                                                                                                ErrorMessage='<img src="../../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                                ControlToValidate="dd_year"><img src="../../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="<%$ ConnectionStrings:intranetConnectionString.ProviderName %>"
                                                                                                SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"></asp:SqlDataSource>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td style="width: 11%" class="frm-lft-clr123">Employee Code
                                                                                        </td>
                                                                                        <td style="width: 27%" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span4" ToolTip="Employee Code"
                                                                                                onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"
                                                                                                Width="" size="40"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ToolTip="Enter Employee Code"
                                                                                                ErrorMessage='<img src="../../../images/error1.gif" alt="" />' ControlToValidate="txt_employee"><img src="../../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            <a class="link05" href="JavaScript:newPopup1('../../../leave/pickemployee.aspx');">Pick Employee</a>
                                                                                        </td>
                                                                                    </tr>


                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="40%">Form 16A
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="60%">
                                                                                            <a id="A1" runat="server" class="link05">
                                                                                                <asp:Label ID="lblphoto" runat="server"></asp:Label></a>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td style="width: 11%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                                        </td>
                                                                                        <td style="width: 27%" class="frm-rght-clr123 border-bottom">
                                                                                            <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="button"
                                                                                                ToolTip="Click to view Employee Payslip" Text="Form 16"></asp:Button>
                                                                                            <asp:Button ID="btn_formD" runat="server" CssClass="button" OnClick="btn_formD_Click"
                                                                                                Text="Form 16 Detail" />
                                                                                            <asp:Button ID="btn_16AA" runat="server" CssClass="button" OnClick="btn_16AA_Click"
                                                                                                Text="Form 16AA" />
                                                                                            <asp:Button ID="btn_ack" runat="server" CssClass="button" Text="ITR Ack" OnClick="btn_ack_Click"></asp:Button>
                                                                                            <asp:Button ID="btn_itr" runat="server" CssClass="button" Text="ITR 1" OnClick="btn_itr_Click"></asp:Button>
                                                                                            <asp:Button ID="btnform12ba" runat="server" CssClass="button" OnClick="btnform12ba_Click"
                                                                                                Text="Form12BA" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%-- <tr>
                                                            <td align="left" colspan="4">Mandatory Fields (<img alt="" src="../../../images/error1.gif" />)
                                                            </td>
                                                        </tr>--%>
                                                                                </tbody>
                                                                            </table>
                                                                            <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                                                Text="Reset" Visible="False"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <a class="link05" href="../printtdsreports.aspx">Click here for Multiple Printing</a>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
