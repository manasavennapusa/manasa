<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_processed_attendance.aspx.cs" Inherits="payroll_admin_view_processed_attendance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script type="text/javascript" language="javascript">
    </script>
    <script src="../../leave/js/popup.js"></script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>

        <%-- <div>--%>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td valign="middle" class="txt02 blue-brdr-1">&nbsp;<img height="16" src="../../images/employee-icon.jpg" width="16" />
                    Search Employee</td>
            </tr>
            <tr>
                <td height="5" valign="top"></td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frm-lft-clr123" width="19%">Month</td>
                            <td class="frm-rght-clr123">
                                <asp:DropDownList ID="dd_year" runat="server" CssClass="blue1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="5" valign="top"></td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="frm-lft-clr123" width="17%">Employee Name/Code</td>
                            <td class="frm-rght-clr123" width="15%">
                                <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="90"></asp:TextBox>
                            </td>
                            <td class="frm-lft-clr123" width="15%">Branch</td>
                            <td class="frm-rght-clr123" width="15%">
                                <asp:DropDownList ID="dd_designation" runat="server"
                                    CssClass="blue1" DataSourceID="SqlDataSource1" DataTextField="branch_name" DataValueField="branch_id" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                            </td>
                            <td class="frm-lft-clr123" width="13%">Department&nbsp;</td>
                            <td class="frm-rght-clr123" width="15%">&nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                DataTextField="department_name" DataValueField="departmentid" AppendDataBoundItems="True">
                                <asp:ListItem Value="0">All</asp:ListItem>
                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="5" valign="top"></td>
            </tr>

        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                            <input id="button" runat="server" class="button" value="Back" onclick="javascript: history.go(-1)" />

                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="middle" class="txt02">&nbsp;Employee List</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !" OnPageIndexChanging="empgrid_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="lbl_emp" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="System Generated LWP">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("LWP_S") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LWP">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("LWP") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total LWP">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("totallwp") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                </table>
                <%--</div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
