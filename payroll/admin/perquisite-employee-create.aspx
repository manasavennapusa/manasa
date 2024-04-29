<%@ Page Language="C#" AutoEventWireup="true" CodeFile="perquisite-employee-create.aspx.cs"
    Inherits="payroll_admin_perquisite_employee_create" %>

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
                                           <%-- <td width="3%">
                                                <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                            </td>--%>
                                          <%--  <td class="txt01">
                                                Employee Perquisite master
                                            </td>--%>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="5">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="20">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="txt02" width="27%">
                                                Entry Employee Perquisite
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
                                            <td class="frm-lft-clr123" width="25%">
                                                Year <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                <asp:DropDownList ID="dd_year" runat="server" Width="" CssClass="span4" OnDataBound="dd_year_DataBound"
                                                    DataValueField="financialyear" DataTextField="financialyear" DataSourceID="SqlDataSource12"
                                                    AutoPostBack="False">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator12" runat="server" ValidationGroup="v1"
                                                    ToolTip="Select Financial Year" ValueToCompare="0" Operator="NotEqual" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Display="Dynamic" ControlToValidate="dd_year"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource12" runat="server" ProviderName="<%$ ConnectionStrings:intranetConnectionString.ProviderName %>"
                                                    SelectCommand="select [financial_year] as financialyear from tbl_payroll_tax_master order by id desc"
                                                    ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="25%">
                                                Employee Code <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123" width="75%">
                                                <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code"  onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"
                                                    Width="" ValidationGroup="v"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                    ValidationGroup="v1"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <a href="JavaScript:newPopup1('../../leave/pickemployee.aspx');" class="link05">Pick Employee</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Perquisite Detail <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:DropDownList ID="ddlperquisitedetail" runat="server" CssClass="span4" Width=""
                                                    DataSourceID="SqlDataSource1" DataTextField="name" DataValueField="id" AutoPostBack="True"
                                                    OnSelectedIndexChanged="ddlperquisitedetail_SelectedIndexChanged" OnDataBound="ddlperquisitedetail_DataBound">
                                                </asp:DropDownList>
                                                &nbsp;
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ToolTip="Select Financial Year" ValidationGroup="v1" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="<%$ ConnectionStrings:intranetConnectionString.ProviderName %>" SelectCommand="SELECT id,name FROM tbl_payroll_perquiste_detail">
                                                </asp:SqlDataSource>
                                                <%--SelectCommand="SELECT id,name FROM tbl_payroll_perquiste_detail where id not in (1,2)">--%>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Perquisite Amount <span class="star"></span>
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txtperquisiteamt" runat="server" CssClass="span4" size="40" ToolTip="Perquisite Amount"
                                                    Width=""></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtperquisiteamt"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Perquisite Amount" ValidationGroup="v1"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtperquisiteamt"
                                                    Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="9999999"
                                                    MinimumValue="0" Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr id="month" runat="server" visible="false">
                                            <td class="frm-lft-clr123">
                                                Month
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="span4" Width="">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                    <asp:ListItem>3</asp:ListItem>
                                                    <asp:ListItem>4</asp:ListItem>
                                                    <asp:ListItem>5</asp:ListItem>
                                                    <asp:ListItem>6</asp:ListItem>
                                                    <asp:ListItem>7</asp:ListItem>
                                                    <asp:ListItem>8</asp:ListItem>
                                                    <asp:ListItem>9</asp:ListItem>
                                                    <asp:ListItem>10</asp:ListItem>
                                                    <asp:ListItem>11</asp:ListItem>
                                                    <asp:ListItem>12</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Perquisite Amount Received
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txtperquisiteamtreceived" runat="server" CssClass="span4" size="40"
                                                    ToolTip="Perquisite amount Received" Width="">0.0</asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtperquisiteamtreceived"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Perquisite Amount Received" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtperquisiteamtreceived"
                                                    Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="999999" MinimumValue="0"
                                                    Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="25%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="75%">
                                                <asp:Button ID="btnadd" runat="server" CssClass="button" ValidationGroup="v1" ToolTip="Click to add"
                                                    Text="Add" OnClick="btnadd_Click"></asp:Button>
                                                &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" height="20">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td class="txt02" width="27%">
                                                Employee Perquisite View
                                            </td>
                                            <td class="txt-red" align="right" width="73%">
                                                <span id="SPAN1" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 123px" valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="25%"><div class="widget-content">
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="grid" runat="server"  EmptyDataText="Sorry No Records Found"
                                                            PageSize="50" AllowPaging="true" 
                                                           DataKeyNames="perquisitedetail-id" AutoGenerateColumns="false"
                                                            OnPageIndexChanging="grid_PageIndexChanging" OnRowCancelingEdit="grid_RowCancelingEdit"
                                                            OnRowDeleting="grid_RowDeleting" OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating"
                                                            CssClass ="table table-hover table-striped table-bordered table-highlight-head">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Perquisite Detail">
                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("perquisitedetail")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Perquisite Amt">
                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amt Received">
                                                                   
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind("amountreceived")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtperquisiteamtreceivedg" runat="server" Text='<%# Bind("amountreceived")%>'></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtperquisiteamtreceivedg"
                                                                            Display="Dynamic" ErrorMessage="Enter Correct Amount" MaximumValue="9999999"
                                                                            MinimumValue="0" Type="Double" ValidationGroup="grid"></asp:RangeValidator>
                                                                    </EditItemTemplate>
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
                                                                    <ItemStyle Width="10%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                            CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                        |
                                                                        <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm(' Do you want to Delete this record?');"
                                                                            CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                           
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                         </div>   </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" OnClick="btnsubmit_Click" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
