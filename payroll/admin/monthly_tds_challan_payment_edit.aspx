<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_tds_challan_payment_edit.aspx.cs"
    Inherits="payroll_admin_monthly_tds_challan_payment_edit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

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
                        <div class="divajax" style="left: 250px; top: 150px">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...</td>
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
                                            <div>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="3%" style="height: 16px">
                                                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                                                <td class="txt01" style="height: 16px">Monthly TDS Challan</td>
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
                                                                                <td valign="top" class="txt02" style="height: 20px">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="27%" class="txt02" style="height: 13px">Monthly TDS Challan</td>
                                                                                            <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Challan No
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="27%" colspan="0">
                                                                                                <asp:Label ID="lblchallanno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123" width="23%">Cost Center</td>
                                                                                            <td class="frm-rght-clr123" width="29%" colspan="2">
                                                                                                <asp:Label ID="lblCostCenter" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="5" align="right" height="5" valign="bottom">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Financial Year</td>
                                                                                            <td class="frm-rght-clr123" width="27%">
                                                                                                <asp:Label ID="lblFinancialYear" runat="server"></asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="23%">Month</td>
                                                                                            <td class="frm-rght-clr123" width="29%" colspan="2">
                                                                                                <asp:Label ID="lblMonth" runat="server"></asp:Label></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="5" align="right" height="5" valign="bottom">&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" align="center" height="5" valign="bottom">
                                                                                    <strong>Search EmpCode or EmpName</strong> :
                                                                                    <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                                                                    &nbsp;
                                                        <asp:Button ID="search" runat="server" Text="Search" CssClass="button" OnClick="search_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txt01" style="height: 15px" valign="top"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" class="txt01" style="height: 15px">Tax Detail for the month
                                                                                </td>
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
                                                                                                                    <td valign="top">
                                                                                                                        <div>
                                                                                                                            <asp:GridView ID="griddetail" runat="server"
                                                                                                                                DataKeyNames="empcode,financial_year,month"
                                                                                                                                AutoGenerateColumns="False" AllowPaging="True" PageSize="100"
                                                                                                                                EmptyDataText="NO TDS entry found for the month" OnPageIndexChanging="griddetail_PageIndexChanging1"
                                                                                                                                OnRowEditing="griddetail_RowEditing" OnRowCancelingEdit="griddetail_RowCancelingEdit"
                                                                                                                                OnRowUpdating="griddetail_RowUpdating"
                                                                                                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField HeaderText="Emp Code">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lblempcodeg" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                                                            <asp:Label ID="lblmonthg" runat="server" Visible="false" Text='<%# Bind ("month") %>'></asp:Label>
                                                                                                                                            <asp:Label ID="lblfinancialyrg" runat="server" Visible="false" Text='<%# Bind ("financial_year") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Employee Name">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lblempnameg" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="TDS Amount">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lbltdsg" runat="server" Text='<%# Bind ("tds_rupees") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                        <EditItemTemplate>
                                                                                                                                            <asp:TextBox ID="txttdsg" runat="server" Text='<%# Bind("tds_rupees") %>' CssClass="input"
                                                                                                                                                Width="71px"></asp:TextBox>
                                                                                                                                        </EditItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Surcharge">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lblsurchargeg" runat="server" Text='<%# Bind ("surcharge") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Edu Cess">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lbleducessg" runat="server" Text='<%# Bind ("education_cess") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Total Tax">

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="lbltottaxg" runat="server" Text='<%# Bind ("total_tax") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Action">
                                                                                                                                        <EditItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkbtnupdate" runat="server" CausesValidation="false" ValidationGroup="grid"
                                                                                                                                                OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update"
                                                                                                                                                CssClass="link05" Text="Update" ToolTip="Update" />
                                                                                                                                            |
                                                                                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                                                                                    CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                                                                                                        </EditItemTemplate>

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                                                                                                CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                                                                                        </ItemTemplate>

                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>

                                                                                                                            </asp:GridView>
                                                                                                                        </div>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td align="right" height="5" valign="bottom">&nbsp;
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
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
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
    </form>
</body>
</html>
