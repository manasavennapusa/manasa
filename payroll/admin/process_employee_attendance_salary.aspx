<%@ Page Language="C#" AutoEventWireup="true" CodeFile="process_employee_attendance_salary.aspx.cs" Inherits="payroll_admin_process_attendance_salary" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                    <td valign="bottom">Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <table width="100%" border="0" cellspacing="0" cellpadding="0">

                    <tr>
                        <td valign="top" colspan="5">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01" runat="server">Attendance / Salary </td>

                                                <td runat="server" align="right" class="txt02">
                                                    <asp:Label ID="lbl_message" runat="server" Enabled="true" Text=""></asp:Label></td>

                                            </tr>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td height="5"></td>
                                </tr>

                                <tr>

                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123">Financial Year</td>
                                                <td class="frm-rght-clr123" colspan="2">&nbsp;<asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="3"></td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Select
                Month</td>
                                                <td class="frm-rght-clr123" colspan="2">
                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="blue1" AutoPostBack="True" OnSelectedIndexChanged="dd_month_SelectedIndexChanged" Width="140px">
                                                    </asp:DropDownList></td>
                                            </tr>

                                            <tr>
                                                <td height="5" colspan="3"></td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Emp Code</td>
                                                <td align="left" class="frm-rght-clr123" colspan="2">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="140px"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">Pick Employee</a></span></td>
                                                &nbsp;
                <tr>
                    <td height="5" colspan="3"></td>
                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Process Salary</td>
                                                    <td align="left" class="frm-rght-clr123">&nbsp;<asp:Button ID="btn_procs_att" runat="server" CssClass="button2" Text="Process Attendance" OnClick="btn_procs_att_Click" ValidationGroup="v" /></td>
                                                    <td align="left" class="frm-rght-clr123">
                                                        <asp:Button ID="btn_procs_salary" runat="server" CssClass="button2" Text="Process Salary" OnClick="btn_procs_salary_Click" ValidationGroup="v" /></td>
                                                </tr>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="7"></td>
                                </tr>
                                <tr>
                                    <td valign="top"></td>
                                </tr>
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
