<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tds_amendment.aspx.cs" Inherits="payroll_admin_perquisite_employee_accommodation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress id="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
            <ProgressTemplate>
                <div class="divajax" style="left: 250px; top: 150px">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
                <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="blue-brdr-1" valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td width="3%">
                                                                                <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                                            </td>
                                                                            <td class="txt01">TDS Amendment
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" height="20">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="txt02" width="27%">Employee TDS Amendment
                                                                            </td>
                                                                            <td class="txt-red" align="right" width="73%">
                                                                                <span id="message" runat="server"></span>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 123px" valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="25%">Employee Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="75%">
                                                                                <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code"
                                                                                    Width=""></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                                                    ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <a href="JavaScript:newPopup1('../../leave/pickemployee.aspx');" class="link05">Pick Employee</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Apply TDS Amendment
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">&nbsp;Amount
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txtamount" runat="server" CssClass="span4" size="40" ToolTip="Perquisite amount Received"
                                                                                    Width="">0.00</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamount"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter Perquisite Amount Received" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtamount"
                                                                                    Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="999999" MinimumValue="0"
                                                                                    Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="25%">&nbsp;
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="75%">&nbsp;<asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click"
                                                                                ValidationGroup="v" />
                                                                                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                                                                    Text="Reset" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="left" colspan="2">Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" height="20">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="txt02" width="27%" style="height: 13px">Employee TDS Amendment
                                                                            </td>
                                                                            <td class="txt-red" align="right" width="73%" style="height: 13px">
                                                                                <span id="SPAN1" runat="server"></span>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom" width="15%">Emp Name/Code
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                    <asp:TextBox ID="txtempcode" runat="server" CssClass="span12" Width=""></asp:TextBox>
                                                                </td>
                                                                <td class="frm-lft-clr123 border-bottom" width="15%">Designation
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="span12" DataSourceID="SqlDataSource1"
                                                                        DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                                                        Width="">
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
                                                    <td valign="top" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;<asp:Button ID="btnupdate" runat="server" CssClass="button" Text="Update" OnClick="btnupdate_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="grid" runat="server" EmptyDataText="Sorry No Records Found"
                                                            PageSize="100" DataKeyNames="empcode" AllowPaging="true"
                                                            AutoGenerateColumns="false"
                                                            OnPageIndexChanging="grid_PageIndexChanging" OnRowUpdating="grid_RowUpdating"
                                                            OnRowDeleting="grid_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Emp Code">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempcodeg" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp Name">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempnameg" runat="server" Text='<%# Bind("empname")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Applicable">

                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkstatusg" runat="server" Checked='<%# Convert.ToBoolean(Eval("status"))%>' />
                                                                        <%--<asp:Label ID="l7" runat="server" Text='<%# Bind("status")%>' ></asp:Label>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">

                                                                    <ItemTemplate>
                                                                        <asp:TextBox ID="txtamountg" CssClass="span8" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "amount")%>'></asp:TextBox>
                                                                        <%--<asp:Label ID="l6" runat="server" Text='<%# Bind("amount")%>' ></asp:Label>--%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>

                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;<asp:Button ID="btnupdate1" runat="server" CssClass="button" Text="Update"
                                                        OnClick="btnupdate1_Click" />
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
    </form>
</body>
</html>
