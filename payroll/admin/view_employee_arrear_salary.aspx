<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_employee_arrear_salary.aspx.cs" Inherits="payroll_admin_view_employee_arrear_salary" %>

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
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" height="463px">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01" style="height: 16px">View Employee Arrear Salary</td>
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
                                                    <td height="20" valign="top" class="txt02">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="27%" class="txt02">Search Salary Arrears</td>
                                                                <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="21%">Arrear Reference No.</td>
                                                                <td class="frm-rght-clr123" width="27%">
                                                                    <asp:TextBox ID="txt_arrearrefno" runat="server" CssClass="blue1" Width="100px"></asp:TextBox></td>
                                                                <td width="1%" rowspan="3">&nbsp;</td>
                                                                <td class="frm-lft-clr123" width="23%">Employee Name/Code</td>
                                                                <td class="frm-rght-clr123" width="29%" colspan="2">
                                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="120px"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="5"></td>
                                                                <td height="5" colspan="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Branch</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSourceBranch" DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound" Width="110px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123">Department</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="dd_dept" runat="server" CssClass="blue1" DataSourceID="SqlDataSourceDept" DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound" Width="110px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourceDept" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" align="right" height="23" valign="bottom">
                                                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                                                                    <input type="button" id="bck" class="button" value="Back" onclick="javascript: history.go(-1);" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                                    <tr>
                                                                                        <td valign="top" class="txt02" style="height: 22px">Employees' List</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2" valign="top">
                                                                                            <div style="overflow: scroll; width: 100%; position: absolute;">
                                                                                                <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="135%" AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such arrear entry exists !" OnPageIndexChanging="griddetail_PageIndexChanging">
                                                                                                    <Columns>

                                                                                                        <asp:TemplateField HeaderText="Arrear Reference No.">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="17%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("arrear_ref_no") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Branch">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="11" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Department">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="11" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField HeaderText="Arrear Amount">
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                        <asp:TemplateField>
                                                                                                            <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                                            <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="10%" />
                                                                                                            <ItemTemplate>
                                                                                                                <a class="link05" href="view_employee_arrear_salary_detail.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" target="_self">View</a> |  
                       <a class="link05" href="edit_employee_arrear_salary.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" target="_self">Edit</a>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>

                                                                                                    </Columns>
                                                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                    <RowStyle Height="5px" />
                                                                                                    <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" runat="server" SelectCommand="sp_payroll_fetch_arreardetail" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
                                    <tr>
                                        <td valign="top">&nbsp;</td>
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
