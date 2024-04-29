<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employee_overtime.aspx.cs"
    Inherits="payroll_admin_employee_overtime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    
    <script src="../../leave/js/popup.js"></script>
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
                    <div class="divajax" style="top: 160px;">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img alt="" src="../../images/loading.gif" />
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
            <div>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>
                                                <td class="txt01" style="height: 16px">
                                                    Overtime
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="29%" class="txt02">
                                                    Overtime Entry
                                                </td>
                                                <td width="71%" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Emp code
                                                </td>
                                                <td colspan="4" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');"
                                                        class="link05">Pick Employee</a></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123">
                                                    Month / Year
                                                </td>
                                                <td colspan="4" class="frm-rght-clr123">
                                                    <asp:DropDownList ID="dd_month_f" runat="server" CssClass="blue1" Width="90px" OnSelectedIndexChanged="dd_month_f_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month_f"
                                                        Display="Dynamic" ErrorMessage='<img <img src="../../images/error1.gif" alt="" />alt="" />'
                                                        Operator="NotEqual" ToolTip="Select Month of Recovery" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:DropDownList ID="dd_year_f" runat="server" CssClass="blue1" Width="90px" OnSelectedIndexChanged="dd_year_f_SelectedIndexChanged"
                                                        AutoPostBack="True">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year_f"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        Operator="NotEqual" ToolTip="Select Year of Recovery" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="19%" class="frm-lft-clr123 border-bottom">
                                                    Overtime(In Hours)
                                                </td>
                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                    <asp:TextBox ID="txt_ot" runat="server" CssClass="blue1">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_ot"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_ot"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                                </td>
                                                <td width="1%">
                                                    &nbsp;
                                                </td>
                                                <td width="21%" class="frm-lft-clr123 border-bottom">
                                                    Overtime-H(In Hours)
                                                </td>
                                                <td width="28%" class="frm-rght-clr123 border-bottom">
                                                    <asp:TextBox ID="txt_oth" runat="server" CssClass="blue1">0</asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_oth"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_oth"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        MaximumValue="1000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" align="right" valign="top">
                                        <table width="40" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="100" align="center" valign="middle" style="height: 18px">
                                                    <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="btn_add_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="head-2">
                                        <asp:GridView ID="grid_overtimedetail" Width="100%" runat="server" AutoGenerateColumns="false"
                                            DataKeyNames="id" BorderWidth="0px" CellPadding="4" CellSpacing="0" Font-Names="Arial"
                                            Font-Size="11px" EmptyDataText="Sorry No Records Found" AllowPaging="True" OnPageIndexChanging="grid_overtimedetail_PageIndexChanging"
                                            OnRowCancelingEdit="grid_overtimedetail_RowCancelingEdit" OnRowDeleting="grid_overtimedetail_RowDeleting"
                                            OnRowEditing="grid_overtimedetail_RowEditing" OnRowUpdating="grid_overtimedetail_RowUpdating"
                                            PageSize="50" CssClass="gvclass" Border="1px solid #ddd">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Month / Year">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind("mth_year")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Over Time">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("OVERTIME")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_ot1" CssClass="blue1" Text='<%# Bind("OVERTIME")%>' runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" Display="Dynamic" runat="server"
                                                            ControlToValidate="txt_ot1" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="RangeValidator10" runat="server" Display="Dynamic" ControlToValidate="txt_ot1"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' Type="Integer" MinimumValue="0"
                                                            MaximumValue="1000" ValidationGroup="grid"></asp:RangeValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Overtime-H">
                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                        Width="20%" />
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("OVERTIME_H")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txt_oth1" CssClass="blue1" Text='<%# Bind("OVERTIME_H")%>' runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" Display="Dynamic"
                                                            ControlToValidate="txt_oth1" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ValidationGroup="grid"></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="RangeValidator20" runat="server" Display="Dynamic" ControlToValidate="txt_oth1"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' Type="Integer" MinimumValue="0"
                                                            MaximumValue="1000" ValidationGroup="grid"></asp:RangeValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                            CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" ValidationGroup="grid" />
                                                        |
                                                        <asp:LinkButton ID="lnkbtndelete" ValidationGroup="none" runat="server" CommandName="Cancel"
                                                            CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="20%" HorizontalAlign="Center" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" ValidationGroup="none" runat="server" CommandName="Edit"
                                                            CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                        |
                                                        <asp:LinkButton ID="lnkbtndelete" ValidationGroup="none" runat="server" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                            CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
