<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Form24Q.aspx.cs" Inherits="payroll_admin_reports_report_esiform5" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../../css/blue1.css" rel="stylesheet" />
    <link href="../../../css/main.css" rel="stylesheet" />
    <script src="../../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <cc1:ToolkitScriptManager ID="Emp_PayStructure" runat="server">
        </cc1:ToolkitScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
     <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../../images/loading.gif" /></td>
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
                                                        <td valign="top" class="blue-brdr-1" style="width: 719px">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="3%" style="height: 16px">
                                                                        <img src="../../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                                    <td class="txt01" style="height: 16px">&nbsp;ETDS</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" colspan="4"></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" valign="top" style="width: 719px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="txt02" style="height: 13px">ETDS</td>
                                                                    <td class="txt02" align="right">
                                                                        <span id="message" runat="server"></span>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" style="height: 123px; width: 719px;">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr runat="server" visible="false">
                                                                    <td class="frm-lft-clr123" style="width: 11%">Cost Center</td>
                                                                    <td class="frm-rght-clr123" style="width: 27%">
                                                                        <asp:DropDownList ID="dd_branch" runat="server" CssClass="select" DataSourceID="SqlDataSource3"
                                                                            DataTextField="cost_center_name" DataValueField="cost_center" OnDataBound="dd_branch_DataBound"
                                                                            Width="130px">
                                                                        </asp:DropDownList>
                                                                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct cost_center, cost_center_name FROM tbl_payroll_costcenter ORDER BY cost_center_name"></asp:SqlDataSource>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%">Financial Year</td>
                                                                    <td class="frm-rght-clr123" style="width: 100%">
                                                                        <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                                            CssClass="select" DataTextField="financialyear" DataValueField="financialyear"
                                                                            DataSourceID="SqlDataSource12">
                                                                        </asp:DropDownList>
                                                                        <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                                                                            SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"></asp:SqlDataSource>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%">Quarter</td>
                                                                    <td class="frm-rght-clr123" style="width: 100%">
                                                                        <asp:DropDownList ID="dd_month" runat="server" Width="129px" ToolTip="Quater" CssClass="select"
                                                                            DataTextField="month " DataValueField="month ">
                                                                            <asp:ListItem Value="1">Q1</asp:ListItem>
                                                                            <asp:ListItem Value="2">Q2</asp:ListItem>
                                                                            <asp:ListItem Value="3">Q3</asp:ListItem>
                                                                            <asp:ListItem Value="4">Q4</asp:ListItem>
                                                                        </asp:DropDownList>&nbsp;</td>
                                                                </tr>
                                                               
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%">&nbsp;</td>
                                                                    <td class="frm-rght-clr123" style="width: 100%">
                                                                        <asp:Button ID="btnsbmit" runat="server" Text="Generate FVU" CssClass="button" OnClick="btnsbmit_Click"
                                                                            ToolTip="Click to Generate FVU" />
                                                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click"
                                                                            Text="Form 27A" />
                                                                        <asp:Button ID="btn_form24q" runat="server" CssClass="button" OnClick="btn_form24q_Click"
                                                                            Text="Form 24Q" />
                                                                        <%--<asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"Text=" Form 16" />--%>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="txt02" colspan="2" style="height: 13px">Form 16</td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%" colspan="4">
                                                                        <asp:RadioButton ID="rbtnAll" runat="server" AutoPostBack="True" Checked="True" GroupName="form16"
                                                                            Text="All" OnCheckedChanged="rbtnAll_CheckedChanged" />
                                                                        |
                                            <asp:RadioButton ID="rbtnEmployee" runat="server" AutoPostBack="True" GroupName="form16"
                                                Text="Employee" OnCheckedChanged="rbtnEmployee_CheckedChanged" /></td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" style="width: 19%">Financial Year</td>
                                                                    <td height="5" class="frm-rght-clr123" colspan="3">
                                                                        <asp:DropDownList ID="ddlFinancialYearF16" runat="server" Width="129px" ToolTip="Financial Year"
                                                                            CssClass="select" DataTextField="financialyear" DataValueField="financialyear"
                                                                            DataSourceID="SqlDataSource1">
                                                                        </asp:DropDownList>
                                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                                                                            SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"></asp:SqlDataSource>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr id="form16Employee" runat="server" visible="false">
                                                                    <td style="width: 11%" class="frm-lft-clr123">Employee Code</td>
                                                                    <td style="width: 27%" class="frm-rght-clr123" colspan="3" validationgroup="form">
                                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="input" ToolTip="Employee Code"
                                                                            Width="121px" size="40"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ToolTip="Enter Employee Code"
                                                                            ErrorMessage='<img src="../../../images/error1.gif" alt="" />' ControlToValidate="txt_employee"><img src="../../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <a href="JavaScript:newPopup1('../../../leave/pickemployee.aspx');" class="link05">Pick Employee</a></td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%">&nbsp;Select Date</td>
                                                                    <td height="5" class="frm-rght-clr123" colspan="3">
                                                                        <asp:TextBox ID="txtdate" runat="server" CssClass="input"></asp:TextBox>&nbsp;<asp:Image
                                                                            ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                        <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txtdate"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            ToolTip="Select  Date" ValidationGroup="v"><img src="../../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                            TargetControlID="txtdate" Format="MM/dd/yyyy">
                                                                        </cc1:CalendarExtender>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 19%">&nbsp;</td>
                                                                    <td height="5" class="frm-rght-clr123" colspan="3">
                                                                        <asp:Button ID="Button2" runat="server" CssClass="button" OnClick="Button1_Click"
                                                                            Text=" Form 16" ValidationGroup="form" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" colspan="4">Mandatory Fields (<img src="../../../images/error1.gif" alt="" />)</td>
                                                                </tr>
                                                            </table>
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
        <%--</ContentTemplate> 
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
