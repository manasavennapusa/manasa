<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickemployee.aspx.cs" Inherits="Leave_admin_pickemployee"
    Title="Employee Detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. : Employee Details</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
    </style>

    <script type="text/javascript" language="javascript">

        function returnempcode(val1,val2) {

            // hardcoded value used to minimize the code. 

            // ControlID can instead be passed as query string to the popup window
          
            window.opener.document.getElementById("txt_resourcename").value = val2;
            window.opener.document.getElementById("hidd_empcode").value = val1; 
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
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="803" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="middle" class="txt02 blue-brdr-1">&nbsp;Search Employee
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top"></td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="15%">Employee Name
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="15%">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="90"></asp:TextBox>
                                        </td>
                                        <td class="frm-lft-clr123 border-bottom" width="15%">Designation
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="15%">
                                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                                DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                        </td>
                                        <td class="frm-lft-clr123 border-bottom" style="width: 11%">Department
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="15%">&nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                            DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                            Width="145px">
                                        </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                        </td>
                                        <td class="frm-lft-clr123 border-bottom" width="12%">
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
                            <td height="5" valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td valign="top">&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="txt02">&nbsp;Employee Record
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="head-2" valign="top">
                                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                        BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                                        OnRowEditing="empgrid_RowEditing" OnPageIndexChanging="empgrid_PageIndexChanging"
                                                                        CssClass="gvclass" Border="1px solid #ddd">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Select">
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="chkselect" runat="server" />
                                                                                </ItemTemplate>
                                                                                <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                                                                <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employee Code - Name">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") +" - "+ Eval("name") %>' ></asp:Label>                                                                                    
                                                                                      <%-- <%# DataBinder.Eval(Container.DataItem, "empcode")%>
                                                                                         -
                                                                                        <%# DataBinder.Eval(Container.DataItem, "name")%>--%>

                                                                                    <%--<a href="javascript:returnempcode('<%# DataBinder.Eval(Container.DataItem, "empcode") %>')"
                                                                                    class="link05">
                                                                                    <%# DataBinder.Eval(Container.DataItem, "empcode") %></a>--%>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Employee Name">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Designation">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Department">
                                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                                <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                                        <RowStyle Height="5px" />
                                                                    </asp:GridView>
                                                                </td>
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
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="10" valign="top"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" width="100%">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td align="center">
                                            <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="button" OnClick="btnaddnew_Click" />&nbsp;
                                <asp:Button ID="btnselectall" runat="server" Text="Select All" CssClass="button" OnClick="btnselectall_Click" />&nbsp;
                                <asp:Button ID="btndeselectall" runat="server" Text="Deselect All" CssClass="button" OnClick="btnDeselectall_Click" />&nbsp;
                                        </td>
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