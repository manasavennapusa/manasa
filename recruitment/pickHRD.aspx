<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickHRD.aspx.cs" Inherits="Leave_admin_pickemployee"
    Title="Employee Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. : Employee Details</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>
    <script src="js/popup1.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">

        function returnempcode(val, val2) {
           // alert(val);
           // alert(val2);
            window.opener.document.getElementById("txtHRD").value = val2;
            window.opener.document.getElementById("hf_hrdCode").value = val;
            window.opener.focus();
            window.close();

        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <%-- <div>--%>
                <table width="800" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Search Approver</td>
                    </tr>
                    <tr>
                        <td height="5" valign="top"></td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123  border-bottom" width="15%">Approver Name</td>
                                    <td class="frm-rght-clr123  border-bottom" width="15%">
                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="90"></asp:TextBox>
                                    </td>
                                    <td class="frm-lft-clr123  border-bottom" width="15%">Designation</td>
                                    <td class="frm-rght-clr123  border-bottom" width="15%">
                                        <asp:DropDownList ID="dd_designation" runat="server"
                                            CssClass="blue1" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                    </td>
                                    <td class="frm-lft-clr123  border-bottom" width="13%">Department&nbsp;</td>
                                    <td class="frm-rght-clr123  border-bottom" width="15%">&nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound" Width="145px">
                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                    </td>

                                    <td class="frm-rght-clr123  border-bottom" width="12%">
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
                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td valign="middle" class="txt02" style="height: 24px">&nbsp;Employee List</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="" valign="top">
                                                                <div class="widget-content">
                                                                    <asp:GridView ID="empgrid" runat="server" CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%"
                                                                        AutoGenerateColumns="False" BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !" OnRowEditing="empgrid_RowEditing" OnPageIndexChanging="empgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="24%">
                                                                                <ItemTemplate>
                                                                                    <%#linkleave(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "name").ToString())%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="26%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="26%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Department" HeaderStyle-Width="24%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
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
                <%--</div>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
