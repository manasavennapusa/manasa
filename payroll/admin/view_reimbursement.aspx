<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_reimbursement.aspx.cs"
    Inherits="payroll_admin_view_reimbursement" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <script type="text/javascript" language="javascript">

        function returnempcode(val, val2) {
            window.opener.document.getElementById("txt_approver").value = val;
            window.opener.document.getElementById("hidd_name").value = val2;
            window.opener.focus();
            window.close();

        }
    </script>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
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
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Search Reimbursement Detail
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="0" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="19%">Employee Name/Code
                                                        </td>
                                                        <td class="frm-rght-clr123" width="31%">
                                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span8"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txt_employee" ToolTip=" enter only alphabets or numbers"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td width="1%" rowspan="6">&nbsp;
                                                        </td>
                                                        <td class="frm-lft-clr123" width="18%">Branch
                                                        </td>
                                                        <td class="frm-rght-clr123" width="31%">
                                                            <asp:DropDownList ID="dd_branch" runat="server" CssClass="span8" DataSourceID="SqlDataSource1"
                                                                DataTextField="branch_name" DataValueField="branch_id" OnDataBound="dd_branch_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">Department
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:DropDownList ID="dd_dept" runat="server" CssClass="span8" DataSourceID="SqlDataSource2"
                                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dept_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                        </td>
                                                        <td class="frm-lft-clr123">Ref. Number
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txt_ref" runat="server" CssClass="span8"></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_ref" ToolTip=" enter only alphabets or numbers"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">From Date <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="span8" Enabled="True" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox><asp:Image
                                                                ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" /><asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_sdate" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator><cc1:CalendarExtender
                                                                        ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                                                    </cc1:CalendarExtender>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom">To Date <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom">
                                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="span8" Enabled="True" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                            <asp:Image ID="img_e" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_edate"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                            <cc1:CalendarExtender ID="cextender1" runat="server" PopupButtonID="img_e" TargetControlID="txt_edate">
                                                            </cc1:CalendarExtender>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom">Reimbursement
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="31%">
                                                            <asp:DropDownList ID="dd_reimb" runat="server" CssClass="span8" Width="" DataSourceID="SqlDataSource4"
                                                                DataTextField="PAYHEAD_NAME" DataValueField="ID" OnDataBound="dd_reimb_DataBound">
                                                            </asp:DropDownList>
                                                            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [PAYHEAD_NAME] FROM [tbl_payroll_reimbursement]"></asp:SqlDataSource>
                                                        </td>

                                                        <td colspan="4" align="right" class="frm-rght-clr123 border-bottom">
                                                            <asp:Button ID="btn_search" runat="server" CssClass="button" OnClick="btn_search_Click"
                                                                Text="Search" />
                                                            <%--  <input class="button" value="Back" type="button" runat="server" onclick="javascript: history.go(-1)" />--%>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10px"></td>
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
                                                                                            <td height="18" valign="top" class="txt02">Employee List
                                                                                            </td>
                                                                                            <td align="right">
                                                                                                <span id="message" runat="server" class="txt02"></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="head-2" valign="top"></td>
                                                                            </tr>
                                                                        </table>
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
                                                                <tr>
                                                                   <td class="frm-rght-clr123 border-bottom" colspan="2">  
                                                                        <div class="widget-content">
                                                                            <%--  <div style="overflow-x: scroll; overflow-y: hidden; width: 100%;">--%>
                                                                            <asp:GridView ID="empgrid"
                                                                                runat="server"
                                                                                DataKeyNames="reimbursement_ref_no"
                                                                                AutoGenerateColumns="False"
                                                                                AllowPaging="True"
                                                                                PageSize="50"
                                                                                EmptyDataText="No such employee exists !"
                                                                                CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Ref No.">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("reimbursement_ref_no") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Reimbursment">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("PAYHEAD_NAME") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="EmpCode">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lbl_empcode" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Branch">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Dept">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Amount">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Date">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("sanction_date") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <a class="link05" onclick="javascript:history.go(-1);" href="view_reimbursement_detail.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">View</a> <%--| <a class="link05" target="content" href="edit_reimbursement_detail.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">Edit</a>--%>
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
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <%--</div>--%>
        <%--   </ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
