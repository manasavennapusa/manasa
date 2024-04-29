<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_applyloanadvances.aspx.cs"
    Inherits="payroll_applyloanadvances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
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
                                    <td valign="bottom">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
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
                                                        <td valign="top" height="463px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <%--  <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>--%>
                                                                                <%-- <td class="txt01" style="height: 16px">View Loan/Advances Applications
                                                    </td>--%>
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
                                                                                            <td width="27%" class="txt02">Search Applications
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
                                                                                            <td class="frm-lft-clr123" width="22%">Loan Reference No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="27%">
                                                                                                <asp:TextBox ID="txt_loanrefno" runat="server" CssClass="span10"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                                                    ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_loanrefno" ToolTip=" enter only alphabets or numbers"
                                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                            <td width="1%" rowspan="5"></td>
                                                                                            <td class="frm-lft-clr123" width="22%">Employee Name/Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="28%">
                                                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span10"></asp:TextBox>
                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                                                    ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txt_employee" ToolTip=" enter only alphabets or numbers"
                                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">Branch
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:DropDownList ID="dd_branch" runat="server" CssClass="span10" DataSourceID="SqlDataSourceBranch"
                                                                                                    DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource ID="SqlDataSourceBranch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"
                                                                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123">Department
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:DropDownList ID="dd_dept" runat="server" CssClass="span10" DataSourceID="SqlDataSourceDept"
                                                                                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound"
                                                                                                    Width="">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource ID="SqlDataSourceDept" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"
                                                                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom">Loan/Advances Name
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                <asp:DropDownList ID="dd_loanname" runat="server" CssClass="span10" DataSourceID="SqlDataSourceLoan"
                                                                                                    DataTextField="loan_name" DataValueField="id" OnDataBound="dd_loanname_DataBound">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource ID="SqlDataSourceLoan" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    SelectCommand="select [id],[loan_name] from tbl_payroll_loan_advances where status=1"
                                                                                                    ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123 border-bottom">Sanction Date
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                <asp:TextBox ID="txt_sdate" runat="server" CssClass="span10"
                                                                                                    onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                                                    TargetControlID="txt_sdate">
                                                                                                </cc1:CalendarExtender>
                                                                                            </td>
                                                                                        </tr>

                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" colspan="5" height="0" valign="bottom">
                                                                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />
                                                                                    <%-- <input type="button" id="Button1" class="button" value="Back" onclick="javascript:history.go(-1);" />--%>
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
                                                                                                                    <td valign="top" class="txt02" style="height: 20px">Employee's List
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                   <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                                        <div class="widget-content">
                                                                                                                            <%-- <div style="overflow-x: scroll; overflow-y: hidden; width: 100%;">--%>
                                                                                                                            <asp:GridView ID="griddetail" runat="server"
                                                                                                                                DataKeyNames="empcode" AutoGenerateColumns="False"
                                                                                                                                AllowPaging="True" EmptyDataText="No such loan entry exists !"
                                                                                                                                OnPageIndexChanging="griddetail_PageIndexChanging"
                                                                                                                                CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField HeaderText="RefNo.">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("loan_ref_id") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Branch">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Dept">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Loan/Adv.">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind ("loan_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Loan Amt">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind ("loan_amount") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Sanc.Date">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l7" runat="server" Text='<%# Bind ("sanction_date") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField>
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <a class="link05" href="view_applyloanadvances_detail.aspx?loan_id=<%#DataBinder.Eval(Container.DataItem, "loan_id")%>"
                                                                                                                                                target="_self">View</a> | <a class="link05" href="edit_applyloanadvances_detail.aspx?loan_id=<%#DataBinder.Eval(Container.DataItem, "loan_id")%>"
                                                                                                                                                    target="_self">Edit</a>| <a class="link05" href="holdandrelesesalary.aspx?loan_id=<%#DataBinder.Eval(Container.DataItem, "loan_id")%>"
                                                                                                                                                    target="_self">Hold Loan</a>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>

                                                                                                                            </asp:GridView>
                                                                                                                        </div>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                            <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                                runat="server" SelectCommand="sp_payroll_fetch_loandetail" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
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
                                                                    <td valign="top">&nbsp;
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
