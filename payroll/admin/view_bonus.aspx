<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_bonus.aspx.cs" Inherits="payroll_admin_view_bonus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script type="text/javascript" language="javascript">

        function returnempcode(val, val2) {
            window.opener.document.getElementById("txt_approver").value = val;
            window.opener.document.getElementById("hidd_name").value = val2;
            window.opener.focus();
            window.close();

        }
    </script>
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                 <div class="divajax">
                    <table width="100%">
                    <tr>
                    <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                    </tr>
                    <tr>
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
        </ProgressTemplate>
        </asp:UpdateProgress>--%>
    <%-- <div>--%>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="middle" class="txt02 blue-brdr-1">
                &nbsp;Search Bonus Detail
            </td>
        </tr>
        <tr>
            <td height="5" valign="top">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="frm-lft-clr123" width="19%">
                            Employee Name
                        </td>
                        <td class="frm-rght-clr123" width="31%">
                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1"></asp:TextBox>
                        </td>
                        <td width="1%" rowspan="5">
                            &nbsp;
                        </td>
                        <td class="frm-lft-clr123" width="18%">
                            Branch
                        </td>
                        <td class="frm-rght-clr123" width="31%">
                            <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">
                            Department&nbsp;
                        </td>
                        <td class="frm-rght-clr123">
                            <asp:DropDownList ID="dd_dept" runat="server" CssClass="blue1" Width="145px" DataSourceID="SqlDataSource2"
                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">
                            </asp:SqlDataSource>
                        </td>
                        <td class="frm-lft-clr123">
                            Ref. Number
                        </td>
                        <td class="frm-rght-clr123">
                            <asp:TextBox ID="txt_ref" runat="server" CssClass="blue1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123 border-bottom" width="19%">
                            Bonus
                        </td>
                        <td class="frm-rght-clr123 border-bottom" width="31%">
                            <asp:DropDownList ID="dd_reimb" runat="server" CssClass="blue1" DataSourceID="SqlDataSource4"
                                DataTextField="PAYHEAD_NAME" DataValueField="ID" OnDataBound="dd_reimb_DataBound">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [PAYHEAD_NAME] FROM [tbl_payroll_bonus]">
                            </asp:SqlDataSource>
                        </td>
                        <td align="left">
                            &nbsp;
                        </td>
                        <td align="right" valign="bottom">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="4" align="right" valign="middle">
                            <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click"
                                Text="Search" />
                            <input id="Text1" class="button" value="Back" type="button" runat="server" onclick="javascript:history.go(-1)" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="5">
            </td>
        </tr>
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
                                                <td width="100%">
                                                    <table width="100%">
                                                        <tr>
                                                            <td height="18" valign="top" class="txt02">
                                                                Employee List
                                                            </td>
                                                            <td align="right">
                                                                <span id="message" runat="server" class="txt02"></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <div style="overflow: scroll; width: 100%; position: absolute;">
                                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                        CellPadding="4" DataKeyNames="bonus_id" Width="150%" AutoGenerateColumns="False"
                                                                        BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                                        OnPageIndexChanging="empgrid_PageIndexChanging">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Reference No.">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("bonus_ref_no") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Bonus">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("PAYHEAD_NAME") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employee Code">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_empcode" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employee Name">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Branch Name">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Department Name">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="13%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Sanction Date">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("sanction_date") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Center" VerticalAlign="Top"
                                                                                    Width="7%" />
                                                                                <ItemTemplate>
                                                                                    <a class="link05" target="content" onclick="javascript:history.go(-1);" href="view_bonus_detail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&bonus_id=<%#DataBinder.Eval(Container.DataItem,"bonus_id")%>">
                                                                                        View</a>| <a class="link05" target="content" href="edit_bonus_detail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&bonus_id=<%#DataBinder.Eval(Container.DataItem,"bonus_id")%>">
                                                                                            Edit</a>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </div>
                                                                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                    runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                                                    <SelectParameters>
                                                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                                        <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                                                        <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                                                        <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                                                        <asp:Parameter Name="status" Type="String" />
                                                                    </SelectParameters>
                                                                </asp:SqlDataSource>
                                                            </td>
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
                </table>
            </td>
        </tr>
    </table>
    <%--</div>--%>
    <%--   </ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
