<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewedit_reimbursment.aspx.cs" Inherits="payroll_admin_viewedit_reimbursment" %>

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
                                            <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Reimbursement Detail
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
                                                                                    <asp:TemplateField HeaderText="Date" Visible="false">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("sanction_date") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField>
                                                                                        <ItemTemplate>
                                                                                            <a class="link05" onclick="javascript:history.go(-1);" href="apply_reimbursement.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">Update</a> <%--| <a class="link05" target="content" href="edit_reimbursement_detail.aspx?reimbursement_ref_no=<%#DataBinder.Eval(Container.DataItem, "reimbursement_ref_no")%>">Edit</a>--%>
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
