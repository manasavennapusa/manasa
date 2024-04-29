<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taxmaster.aspx.cs" Inherits="payroll_admin_taxmaster" %>

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
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
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
                <div id="divapply">
                    <div class="dashboard-wrapper" style="margin-left: 0px;">
                        <div class="main-container">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">

                                        <div class="widget-body">
                                            <fieldset>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                <tr>
                                                                    <td height="5" valign="top"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="29%" class="txt01" style="height: 13px">Tax Details
                                                                                </td>
                                                                                <td width="71%" align="right" class="txt-red" style="height: 13px">
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
                                                                                <td width="21%" class="frm-lft-clr123">Financial Year
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" OnSelectedIndexChanged="dd_year_SelectedIndexChanged"
                                                                                        CssClass="span8">
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td width="1%" rowspan="3"></td>
                                                                                <td width="18%" class="frm-lft-clr123">Education Cess
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_ecess" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_ecess"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter education cess" ValidationGroup="k"></asp:RequiredFieldValidator>


                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Surcharge Percentage
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_scharge" runat="server" CssClass="span8" size="30" MaxLength="3"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_scharge"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter surcharge percentage" ValidationGroup="k"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_scharge"
                                                                                        ErrorMessage="Enter year between 0 and 100" MaximumValue="100" MinimumValue="0"
                                                                                        Type="Double">Enter interest between 0 and 100</asp:RangeValidator>
                                                                                </td>
                                                                                <td class="frm-lft-clr123 border-bottom">Surcharge Limit
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_slimit" runat="server" CssClass="span8" size="30" MaxLength="11"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_slimit"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter surcharge limit" ValidationGroup="k"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_slimit"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Amount must lies between 0 to 100000" MaximumValue="99999999999" MinimumValue="0"
                                                                                        Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">Slab Detail For Men
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123">Minimum Amount
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_min_amt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_min_amt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter minimum amount" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>

                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Maximum Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_max_amt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_max_amt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Amount must lies between 0 to 100000" MaximumValue="9999999999" MinimumValue="0"
                                                                                        Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123 border-bottom">Percentage
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_percentage" runat="server" CssClass="span8" size="30" MaxLength="3"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_percentage"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter deduction percentage" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_percentage"
                                                                                        ErrorMessage="Enter year between 0 and 100" MaximumValue="100" MinimumValue="0"
                                                                                        Type="Double">Enter interest between 0 and 100</asp:RangeValidator>
                                                                                </td>

                                                                                <td colspan="2" align="right" class="frm-rght-clr123 border-bottom" width="49%">
                                                                                    <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="btn_add_Click1"
                                                                                        ValidationGroup="v" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="0" colspan="5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="tax_grid"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="minimumamount"
                                                                                            Width="100%"
                                                                                            EmptyDataText="No record found"
                                                                                            OnRowDeleting="tax_grid_RowDeleting"
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Minimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Percentage Deduction">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                                                <tr>
                                                                    <td height="5px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">Slab Detail For Women
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123">Minimum Amount
                                                                                </td>
                                                                                <td width="29%" class="frm-lft-clr123">
                                                                                    <asp:TextBox ID="txt_wminamnt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_wminamnt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter minimum amount" ValidationGroup="u"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>

                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Maximum Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-lft-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_wmaxamt" runat="server" CssClass="span8" size="30" MaxLength="10"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_wmaxamt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Amount must lies between 0 to 100000" MaximumValue="9999999999" MinimumValue="0"
                                                                                        Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Percentage
                                                                                </td>
                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_wpercentag" runat="server" CssClass="span8" size="30" MaxLength="3"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_wpercentag"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter deduction percentage" ValidationGroup="u"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_wpercentag"
                                                                                        ErrorMessage="Enter year between 0 and 100" MaximumValue="100" MinimumValue="0"
                                                                                        Type="Double">Enter interest between 0 and 100</asp:RangeValidator>
                                                                                </td>
                                                                                <td colspan="2" align="right" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btn_wadd" runat="server" CssClass="button" Text="Add" OnClick="btn_wadd_Click"
                                                                                        ValidationGroup="u" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10" colspan="5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView
                                                                                            ID="tax_wgrid"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="minimumamount"
                                                                                            Width="100%" EmptyDataText="No record found" OnRowDeleting="tax_wgrid_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Minimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="d" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="e" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Percentage Deduction">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="f" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                                                <tr>
                                                                    <td height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">Slab Detail For Senior Citizen
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123">Minimum Amount
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="29%">
                                                                                    <asp:TextBox ID="txt_semin" runat="server" CssClass="span8" size="30"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_semin"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter minimum amount" ValidationGroup="w"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>

                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Maximum Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_semax" runat="server" CssClass="span8" size="30" MaxLength="10"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>&nbsp;
                                                           <asp:RangeValidator ID="RangeValidator7" runat="server" ControlToValidate="txt_semax"
                                                               ErrorMessage="Enter year between 0 and 100" MaximumValue="9999999999" MinimumValue="0"
                                                               Type="Currency">Enter Maximum Amount between 0 and 9999999999</asp:RangeValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Percentage
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_seper" runat="server" CssClass="span8" size="30" MaxLength="3"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_seper"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter deduction percentage" ValidationGroup="w"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator8" runat="server" ControlToValidate="txt_seper"
                                                                                        ErrorMessage="Enter year between 0 and 100" MaximumValue="100" MinimumValue="0"
                                                                                        Type="Double">Enter Percentage between 0 and 100</asp:RangeValidator>

                                                                                </td>
                                                                                <td colspan="2" align="right" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btn_seadd" runat="server" CssClass="button" Text="Add" OnClick="btn_seadd_Click"
                                                                                        ValidationGroup="w" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="0" colspan="5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="tax_sgrid"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="minimumamount"
                                                                                            Width="100%" EmptyDataText="No record found" OnRowDeleting="tax_sgrid_RowDeleting"
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Minimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="g" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="h" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Percentage Deduction">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="i" runat="server" Text='<%# Bind("percentage")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
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
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit Reimbursement Details"
                                                                                        OnClick="btnsubmit_Click" ValidationGroup="k" />&nbsp;
                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details"
                                                        ValidationGroup="none" OnClick="btnreset_Click" Visible="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                        <td>Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                        </td>
                                    </tr>--%>
                                                            </table>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
