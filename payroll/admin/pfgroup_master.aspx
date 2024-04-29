<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pfgroup_master.aspx.cs" Inherits="payroll_admin_pfgroup_master" %>

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
    <asp:ScriptManager ID="payroll" runat="server">
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
                                    <img src="../../images/loading.gif" />
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
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                PF Group Master
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
                                <td height="20" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="27%" class="txt02">
                                                Create PF Group
                                            </td>
                                            <td width="73%" align="right" class="txt-red">
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
                                            <td width="25%" class="frm-lft-clr123">
                                                Group Name
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_name" size="40" CssClass="blue1" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                    Display="Dynamic" ToolTip="Enter Allowance Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Group Description
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Alias Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" ValidationGroup="v"
                                                    ToolTip="Click to submit the created pfgroup" OnClick="btnsbmit_Click" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5" colspan="2">
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial"
                            CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                            AllowPaging="True" PageSize="50" EmptyDataText="No such loan entry exists !"
                            DataSourceID="SqlDataSource1" CssClass="gvclass" Border="1px solid #ddd">
                            <Columns>
                                <asp:TemplateField HeaderText="Group Name">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l0" runat="server" Width="90%" Text='<%# Bind ("group_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt1" CssClass="blue1" runat="server" Width="30%" Text='<%# Bind ("group_name") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt1"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                            ToolTip="Enter group name"></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Group Description">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="60%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("groupdescription") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt2" runat="server" CssClass="blue1" Width="90%" Text='<%# Bind ("groupdescription") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt2"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField UpdateText="Update |" EditText="Edit " ShowEditButton="True">
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                    <ControlStyle CssClass="link05" />
                                </asp:CommandField>
                            </Columns>
                            <HeaderStyle CssClass="frm-lft-clr123" />
                            <FooterStyle CssClass="frm-lft-clr123" />
                            <RowStyle Height="5px" />
                            <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                        </asp:GridView>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues"
                            ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" DeleteCommand="DELETE FROM [tbl_payroll_pfgroup_details] WHERE [id] = @original_id AND [group_name] = @original_group_name AND [groupdescription] = @original_groupdescription"
                            InsertCommand="INSERT INTO [tbl_payroll_pfgroup_details] ([group_name], [groupdescription]) VALUES (@group_name, @groupdescription)"
                            OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.SqlClient"
                            SelectCommand="SELECT [id], [group_name], [groupdescription] FROM [tbl_payroll_pfgroup_details]"
                            UpdateCommand="UPDATE [tbl_payroll_pfgroup_details] SET [group_name] = @group_name, [groupdescription] = @groupdescription WHERE [id] = @original_id AND [group_name] = @original_group_name AND [groupdescription] = @original_groupdescription">
                            <DeleteParameters>
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_group_name" Type="String" />
                                <asp:Parameter Name="original_groupdescription" Type="String" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="group_name" Type="String" />
                                <asp:Parameter Name="groupdescription" Type="String" />
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_group_name" Type="String" />
                                <asp:Parameter Name="original_groupdescription" Type="String" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="group_name" Type="String" />
                                <asp:Parameter Name="groupdescription" Type="String" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
