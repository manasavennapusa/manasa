<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update_dutyroaster.aspx.cs"
    Inherits="payroll_admin_update_dutyroaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
    </style>

    <script type="text/javascript" src="../../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="cmaster" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">
                                        Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tbody>
                            <tr>
                                <td valign="top" class="blue-brdr-1" colspan="2">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                Update Duty Roaster for Holiday / Week Off
                                            </td>
                                            <td align="right">
                                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            <tr>
                                                <td class="frm-lft-clr123" width="25%">
                                                    Branch Name
                                                </td>
                                                <td class="frm-rght-clr123" width="75%">
                                                    <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" Width="145px"
                                                        Height="20px" DataSourceID="SqlDataSource1" DataTextField="branch_name" DataValueField="Branch_Id"
                                                        OnDataBound="drp_comp_name_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                        ToolTip="Select Branch Name"><img src="../../images/../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 11%">
                                                    Employee Code
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 27%">
                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="blue1" runat="server" ToolTip="Employee Code"
                                                        Width="121px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                        Pick Employee</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="14%">
                                                    From Date
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <asp:TextBox ID="txt_sdate" runat="server" CssClass="blue1"></asp:TextBox>
                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_sdate"
                                                        ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                        ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
                                                    <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="14%%">
                                                    To Date
                                                </td>
                                                <td class="frm-rght-clr123" colspan="3" width="20%">
                                                    <asp:TextBox ID="txt_edate" runat="server" CssClass="blue1"></asp:TextBox>
                                                    <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="txt_edate"
                                                        ErrorMessage="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                        ValidationGroup="c" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
                                                    <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom">
                                                    &nbsp;
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Update Holiday"
                                                        CssClass="button" ValidationGroup="c"></asp:Button>&nbsp;
                                                    <asp:Button ID="btnweekoff" runat="server" CssClass="button" OnClick="btnweekoff_Click"
                                                        Text="Update Week Off" ValidationGroup="c" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
