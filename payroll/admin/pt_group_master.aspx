<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pt_group_master.aspx.cs"
    Inherits="payroll_admin_pt_group_master" %>

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
                                                PT Group Master
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
                                                Create PT Group
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
                                                Group Rate
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Alias Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ControlToValidate="txt_alias" Display="Dynamic" MaximumValue="99999999" MinimumValue="0"
                                                    ToolTip="Value should be numeric ang greater than 0." Type="Currency" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom" style="height: 30px">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom" style="height: 30px">
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
                        <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial"
                            CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" BorderWidth="0px"
                            AllowPaging="True" PageSize="50" EmptyDataText="No such loan entry exists !"
                            DataSourceID="SqlDataSource1" CssClass="gvclass" Border="1px solid #ddd">
                            <Columns>
                                <asp:TemplateField HeaderText="Group Name">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l0" runat="server" Width="90%" Text='<%# Bind ("ptgrp_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt1" CssClass="blue1" runat="server" Width="80%" Text='<%# Bind ("ptgrp_name") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt1"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </EditItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Group Rate">
                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                    <ItemStyle Width="60%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                    <ItemTemplate>
                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("ptgrp_rate") %>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txt2" runat="server" CssClass="blue1" Width="90%" Text='<%# Bind ("ptgrp_rate") %>'></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt2"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt2"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                            MaximumValue="9999999" MinimumValue="0" ToolTip="Enter numeric data greater than 0."
                                            Type="Currency"></asp:RangeValidator>
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
                            ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" DeleteCommand="DELETE FROM [tbl_payroll_ptgroup_details] WHERE [id] = @original_id AND [ptgrp_name] = @original_ptgrp_name AND [ptgrp_rate] = @original_ptgrp_rate"
                            InsertCommand="INSERT INTO [tbl_payroll_ptgroup_details] ([ptgrp_name], [ptgrp_rate]) VALUES (@ptgrp_name, @ptgrp_rate)"
                            OldValuesParameterFormatString="original_{0}" ProviderName="System.Data.SqlClient"
                            SelectCommand="SELECT [id], [ptgrp_name], [ptgrp_rate] FROM [tbl_payroll_ptgroup_details]"
                            UpdateCommand="UPDATE [tbl_payroll_ptgroup_details] SET [ptgrp_name] = @ptgrp_name, [ptgrp_rate] = @ptgrp_rate WHERE [id] = @original_id AND [ptgrp_name] = @original_ptgrp_name AND [ptgrp_rate] = @original_ptgrp_rate">
                            <DeleteParameters>
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_ptgrp_name" Type="String" />
                                <asp:Parameter Name="original_ptgrp_rate" Type="Decimal" />
                            </DeleteParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="ptgrp_name" Type="String" />
                                <asp:Parameter Name="ptgrp_rate" Type="Decimal" />
                                <asp:Parameter Name="original_id" Type="Int32" />
                                <asp:Parameter Name="original_ptgrp_name" Type="String" />
                                <asp:Parameter Name="original_ptgrp_rate" Type="Decimal" />
                            </UpdateParameters>
                            <InsertParameters>
                                <asp:Parameter Name="ptgrp_name" Type="String" />
                                <asp:Parameter Name="ptgrp_rate" Type="Decimal" />
                            </InsertParameters>
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td valign="top">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
