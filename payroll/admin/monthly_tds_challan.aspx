<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_tds_challan.aspx.cs"
    Inherits="payroll_admin_view_employee_tds" %>

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
                                                <table border="0" cellspacing="0" cellpadding="0" style="width:100%">
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
                                                                                            <td class="frm-lft-clr123" width="21%">Challan No
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="27%" colspan="4">
                                                                                                <asp:Label ID="lblchallanno" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Financial Year</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="27%">
                                                                                                <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" CssClass="span8"
                                                                                                    DataTextField="year" DataValueField="year" OnSelectedIndexChanged="dd_year_SelectedIndexChanged"
                                                                                                    ToolTip="Financial Year" >
                                                                                                </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                                                                                    ControlToValidate="dd_year" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                    ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="23%">Month</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="29%" colspan="2">&nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="span8" DataTextField="month "
                                                                                                DataValueField="month " ToolTip="Month" Width="">
                                                                                            </asp:DropDownList><asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                ToolTip="Select Month" ValidationGroup="submit"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="23%"></td>
                                                                                            <td class="frm-rght-clr123  border-bottom" width="29%" colspan="3" runat="server" visible="false">&nbsp;
                                                                    <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="span4" Width=""
                                                                        Height="20px" DataSourceID="SqlDataSource2" DataTextField="cost_center_name"
                                                                        DataValueField="cost_center" OnDataBound="drp_comp_name_DataBound" OnSelectedIndexChanged="drp_comp_name_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                                                                                    ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                                                                    ToolTip="Select Cost Center"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT cost_center,cost_center_name FROM tbl_payroll_costcenter ORDER BY cost_center_name"></asp:SqlDataSource>
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123  border-bottom">
                                                                                                <asp:Button ID="btnsearch" runat="server" Text="Fetch Data" CssClass="button" OnClick="btnsearch_Click" /></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="right" height="5" valign="bottom">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <asp:Button ID="Button2" runat="server" Text="Generate Challan" CssClass="button2"
                                                                                        OnClick="Button1_Click" ValidationGroup="submit" />&nbsp;
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
                                                                                                                                DataKeyNames="empcode,financial_year,month" Width="96%"
                                                                                                                                AutoGenerateColumns="False" AllowPaging="True" PageSize="100"
                                                                                                                                EmptyDataText="NO TDS entry found for the month" OnPageIndexChanging="griddetail_PageIndexChanging1"
                                                                                                                                OnRowEditing="griddetail_RowEditing" OnRowCancelingEdit="griddetail_RowCancelingEdit"
                                                                                                                                OnRowUpdating="griddetail_RowUpdating" 
                                                                                                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField>
                                                                                                                                        
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:CheckBox ID="chkempcode" runat="server" Checked="true" />
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
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
                                                                                                                                    <asp:TemplateField>
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
                                                                                                                <tr>
                                                                                                                    <td style="height: 18px">
                                                                                                                        <asp:Button ID="Button1" runat="server" Text="Generate Challan" CssClass="button2"
                                                                                                                            OnClick="Button1_Click" /></td>
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
