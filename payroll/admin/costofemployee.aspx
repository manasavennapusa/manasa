<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costofemployee.aspx.cs" Inherits="payroll_admin_paystructureempview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
    </style>
     <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    
</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
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
                                    <%--  <td width="3%" style="height: 16px">
                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                </td>--%>
                                    <%-- <td class="txt01" style="height: 16px">
                                    Cost of Employee
                                </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="txt02" height="23">&nbsp;Cost of Employee
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top"></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td colspan="5" width="100%">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                    runat="server">
                                                    <ProgressTemplate>
                                                        <div class="divajax" style="top: 160px;">
                                                            <table width="100%">
                                                                <tr>
                                                                    <td align="center" valign="top" style="height: 34px">
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
                                                <table width="100%">
                                                    <tr>
                                                        <td colspan="4">
                                                            <asp:RadioButton ID="rdo_D" Text="Detail" runat="server" Checked="True" GroupName="r" />
                                                            <asp:RadioButton ID="rdo_S" Text="Summarized" runat="server" GroupName="r" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " width="25%" style="border-right:1px solid #ddd;">Branch
                                                        </td>
                                                        <td class="frm-rght-clr123 " width="25%" style="border-right:1px solid #ddd;">
                                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="span10" DataSourceID="SqlDataSource1"
                                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_designation_DataBound"
                                                                Width="" AutoPostBack="True">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT branch_id, branch_name FROM tbl_intranet_branch_detail"></asp:SqlDataSource>
                                                        </td>
                                                        <td class="frm-lft-clr123 " width="25%" style="border-right:1px solid #ddd;">Department
                                                        </td>
                                                        <td class="frm-rght-clr123 " width="25%">
                                                            <asp:DropDownList ID="dd_branch" runat="server" CssClass="span10" DataSourceID="SqlDataSource2"
                                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                                                Width="">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], department_name  FROM [tbl_internate_departmentdetails] where branchid=@branch or 0=@branch">
                                                                <SelectParameters>
                                                                    <asp:ControlParameter ControlID="dd_designation" DefaultValue="0" Name="branch" PropertyName="SelectedValue" />
                                                                </SelectParameters>
                                                            </asp:SqlDataSource>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123 " width="25%">Year
                                    </td>
                                    <td class="frm-rght-clr123 " width="25%">
                                        <asp:DropDownList ID="ddl_year" runat="server" CssClass="span10" DataSourceID="SqlYear"
                                            DataTextField="year" DataValueField="year">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlYear" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            SelectCommand="select distinct year from tbl_payroll_employee_salary order by year desc"></asp:SqlDataSource>
                                    </td>
                                    <td class="frm-lft-clr123 " width="25%" style="border-left:none">Month
                                    </td>
                                    <td class="frm-rght-clr123 " width="25%">
                                        <asp:DropDownList ID="ddl_month" runat="server" CssClass="span10">
                                            <asp:ListItem Selected="True">None</asp:ListItem>
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
                                    </td>
                                </tr>
                                 <tr>
                                                                <td class="frm-lft-clr123 border-bottom " width="15%">Cost Center Group</td>
                                                                     <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                                <asp:DropDownList ID="ddl_cc_groupid" runat="server" CssClass="span10" Height=""
                                                                                    AutoPostBack="true" OnSelectedIndexChanged="ddl_cc_groupid_SelectedIndexChanged">
                                                                                </asp:DropDownList>
                                                                     </td>
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-left: none;" width="15%">Cost Center Code</td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                        <asp:DropDownList ID="ddl_cc_code" runat="server" CssClass="span10" Height=""
                                                                            AutoPostBack="true"  OnSelectedIndexChanged="ddl_cc_code_SelectedIndexChanged">
                                                                            <asp:ListItem Value="0">------Select--------</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                               
                                                            </tr>
                                <tr>
                                    <td  colspan="4">
                                        <br />
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
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
            </div>
        </form>
    </div>
</body>
</html>
