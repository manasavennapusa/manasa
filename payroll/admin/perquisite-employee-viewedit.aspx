<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perquisite-employee-viewedit.aspx.cs"
    Inherits="payroll_admin_perquisite_employee_viewedit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>
                        <div>
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
                                                                    <td class="blue-brdr-1">
                                                                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                                                                            <tr>
                                                                                <td class="txt01">Employee Master View for Perquisite
                                                                                </td>
                                                                                <td class="txt-red" align="right">
                                                                                    <span id="message" runat="server">&nbsp;</span>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="7"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td valign="middle" class="txt02 blue-brdr-1" height="23">&nbsp;Search Employee
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="5" valign="top"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="15%">Emp Name/Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span12" Width=""></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                                                    ValidationExpression="^[a-zA-Z0-9///_/-]+$" ControlToValidate="txt_employee" ToolTip=" enter only alphabets or numbers"
                                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="15%">Designation
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                                                <asp:DropDownList ID="dd_designation" runat="server" CssClass="span12" DataSourceID="SqlDataSource1"
                                                                                                    DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="13%">Department
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="span12" DataSourceID="SqlDataSource2"
                                                                                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                                                    Width="">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="12%">
                                                                                                <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
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
                                                                                            <td valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td valign="top">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                                                                <tr>
                                                                                                                    <td valign="middle" class="txt02" style="height: 24px">&nbsp;Employee List
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                   <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                                        <div class="widget-content">
                                                                                                                            <asp:GridView ID="empgrid" runat="server"
                                                                                                                                DataKeyNames="empcode" AutoGenerateColumns="False"
                                                                                                                                AllowPaging="True" PageSize="50" EmptyDataText="No such employee are in the list !"
                                                                                                                                OnPageIndexChanging="empgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField HeaderText="Year">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lr" runat="server" Text='<%# Bind ("fyear") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Designation">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Department">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:HyperLinkField DataNavigateUrlFields="empcode,fyear" DataNavigateUrlFormatString="perquisiteemployeeview.aspx?empcode={0}&fyear={1}"
                                                                                                                                        NavigateUrl="perquisiteemployeeview.aspx" Text="Edit">
                                                                                                                                        <ControlStyle CssClass="link05" Width="8%" />

                                                                                                                                    </asp:HyperLinkField>
                                                                                                                                </Columns>

                                                                                                                            </asp:GridView>
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
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                   </div>
                                                </fieldset>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
