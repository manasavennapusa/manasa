<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewpaystructureemp.aspx.cs"
    Inherits="payroll_admin_paystructureempview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
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
                                            <td valign="bottom" align="center" class="txt01">Please Wait...
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="dashboard-wrapper" style="margin-left: 0px;">
                            <div class="main-container">
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget">

                                            <div class="widget-body">
                                                <fieldset>

                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="top" class="blue-brdr-1">
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <%--      <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>--%>
                                                                        <td class="txt01">Employee Master View
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="middle" class="txt02" height="23">&nbsp;Search Employee
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123 border-bottom" width="11%">Name/Code
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="11%">
                                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span10" ></asp:TextBox>
                                                                        </td>
                                                                        <td class="frm-lft-clr123 border-bottom" width="11%">Designation
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="19%">
                                                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="span10" DataSourceID="SqlDataSource1"
                                                                                DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                                                >
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                                                        </td>
                                                                        <td class="frm-lft-clr123 border-bottom" width="11%">Department
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="19%">
                                                                            <asp:DropDownList ID="dd_branch" runat="server" CssClass="span10" DataSourceID="SqlDataSource2"
                                                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                                >
                                                                            </asp:DropDownList>
                                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="12%">
                                                                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
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
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" id="TABLE1" onclick="return TABLE1_onclick()">
                                                                    <tr>
                                                                        <td valign="middle" class="txt02" style="height: 24px">&nbsp;Employee List
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="empgrid" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                                                                     AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                                                    OnRowEditing="empgrid_RowEditing" OnRowDataBound="empgrid_RowDataBound" OnPageIndexChanging="empgrid_PageIndexChanging"
                                                                                    CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Code">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Name">
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
                                                                                        <asp:HyperLinkField DataNavigateUrlFields="id,empcode" DataNavigateUrlFormatString="changeemployeepaystructure.aspx?paystructureid={0}&empcode={1}"
                                                                                            NavigateUrl="changeemployeepaystructure.aspx" ItemStyle-HorizontalAlign="Center"
                                                                                            Text="Apply_New">
                                                                                            <ControlStyle CssClass="link05" Width="12%" />
                                                                                            <%-- <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>--%>
                                                                                        </asp:HyperLinkField>
                                                                                    </Columns>

                                                                                </asp:GridView>
                                                                            </div>
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
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
