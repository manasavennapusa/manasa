<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report-tax-variance.aspx.cs"
    Inherits="payroll_admin_report_tax_variance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .star:before
        {
            content: " *";
        }
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
    <link href="../../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../js/main.css" rel="stylesheet" type="text/css" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Report Tax Variance
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="10%">&nbsp;Employee Name/Code
                                                        </td>
                                                        <td class="frm-rght-clr123" width="14%">
                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span12" Width=""></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txt_employee" ToolTip=" enter only alphabets or numbers"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="frm-lft-clr123" width="10%">Designation
                                                        </td>
                                                        <td class="frm-rght-clr123" width="14%">
                                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="span8" DataSourceID="SqlDataSource1"
                                                                DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                                Width="">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" width="8%">Department&nbsp;
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="12%">&nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="span8" DataSourceID="SqlDataSource2"
                                                            DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                            Width="120">
                                                        </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr runat="server" visible="false">
                                                        <td class="frm-lft-clr123 border-bottom" width="15%">Cost Center Group</td>
                                                        <td class="frm-rght-clr123 border-bottom" width="15%">
                                                            <asp:DropDownList ID="ddl_cc_groupid" runat="server" CssClass="span12" Height=""
                                                                AutoPostBack="true" Width="" OnSelectedIndexChanged="ddl_cc_groupid_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="border-left: none;" width="15%">Cost Center Code</td>
                                                        <td class="frm-rght-clr123 border-bottom" width="15%">
                                                            <asp:DropDownList ID="ddl_cc_code" runat="server" CssClass="span8" Height=""
                                                                AutoPostBack="true" Width="" OnSelectedIndexChanged="ddl_cc_code_SelectedIndexChanged">
                                                                <asp:ListItem Value="0">------All--------</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom" width="10%">Financial Year <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="14%">
                                                            <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" CssClass="span14"
                                                                DataSourceID="SqlDataSource12" DataTextField="financialyear" DataValueField="financialyear"
                                                                OnDataBound="dd_year_DataBound" Width="">
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ToolTip="Select Financial Year" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="select  [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"></asp:SqlDataSource>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 11%">Month <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                            <asp:DropDownList ID="dd_month" runat="server" Width="" ToolTip="Month" CssClass="span8">
                                                                <asp:ListItem Value="0">---Select Month---</asp:ListItem>
                                                                <asp:ListItem>Jan</asp:ListItem>
                                                                <asp:ListItem>Feb</asp:ListItem>
                                                                <asp:ListItem>Mar</asp:ListItem>
                                                                <asp:ListItem>Apr</asp:ListItem>
                                                                <asp:ListItem>May</asp:ListItem>
                                                                <asp:ListItem>Jun</asp:ListItem>
                                                                <asp:ListItem>Jul</asp:ListItem>
                                                                <asp:ListItem>Aug</asp:ListItem>
                                                                <asp:ListItem>Sep</asp:ListItem>
                                                                <asp:ListItem>Oct</asp:ListItem>
                                                                <asp:ListItem>Nov</asp:ListItem>
                                                                <asp:ListItem>Dec</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_month"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                Operator="NotEqual" ToolTip="Select Month" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" colspan='2' width="8%" style="border-right: 1px solid #d9d9d9">
                                                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                            <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" colspan="6" valign="top"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table>
                                        <tr>
                                            <td colspan="6" valign="top">
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td valign="middle" class="txt02" style="height: 24px">&nbsp;Employee List
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="empgrid" runat="server"
                                                                                            DataKeyNames="empcode" AutoGenerateColumns="False"
                                                                                            AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                                                            OnPageIndexChanging="empgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Emp Code">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Emp Name">
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
                                                                                                <asp:TemplateField HeaderText="Cost Center Group">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("cost_center_group_name") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Cost Center Name">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("cost_center_name") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Est Total Tax(Y)">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("incometax") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Monthly Tax">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("total_tax") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Est Balance Tax">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("balance") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Gross Amt(M)">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("gross_amount") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="HRA Exemption">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("hra_exemption") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Est Gross Amt(Y)">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("tgross") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Est Taxable Income(Y)">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("ttaxable_amount") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>

                                                                                        </asp:GridView>
                                                                                    </div>
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
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%-- </table></td>
    </tr>--%>
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
        <%--</TD></TR></TABLE>--%>
    </form>
</body>
</html>
