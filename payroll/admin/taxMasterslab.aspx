<%@ Page Language="C#" AutoEventWireup="true" CodeFile="taxMasterslab.aspx.cs" Inherits="payroll_admin_taxMasterslab" %>

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
                                                                <tr runat="server" visible="false">
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
                                                                    <td height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">NHIF
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123">Slab for NHIF
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_nhif" runat="server" CssClass="span8" size="30"
                                                                                        ></asp:TextBox>
                                                                                  
                                                                                </td>

                                                                                <td width="21%" class="frm-lft-clr123">Minimum Amount
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_min_amt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_min_amt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter minimum amount" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                               

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
                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Fixed Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_fx_amt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                   
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                              
                                                                                  <td width="21%" class="frm-lft-clr123 border-bottom">Start Date of Slab
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txtstartdate" runat="server" CssClass="span10" placeholder="Select Date" onblur="return JobCompareDates();" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtstartdate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                                   
                                                                                </td>
                                                                                <td width="21%" class="frm-lft-clr123 border-bottom">End Date of Slab
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txtenddate" runat="server" CssClass="span10" placeholder="Select Date" onblur="return JobCompareDates();" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtenddate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                                   
                                                                                </td>

                                                                                <td colspan="2" align="right" class="frm-rght-clr123 border-bottom" width="49%">
                                                                                    <asp:Button ID="btn_add" runat="server" CssClass="button" Text="Add" OnClick="btn_add_Click"
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
                                                                                                <asp:TemplateField HeaderText="Slab for NHIF">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("slabnhif")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Manimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Fixed Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("fixedamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Start Date of Slab">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("startdate")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="End Date of Slab">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("enddate")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                               <%-- <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>
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
                                                                    <td class="txt02" align="left" height="22" valign="middle">Tax Slab 
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="21%" class="frm-lft-clr123">Slab No.
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_slab_no" runat="server" CssClass="span8" size="30"
                                                                                        ></asp:TextBox>
                                                                                  
                                                                                </td>

                                                                                <td width="21%" class="frm-lft-clr123">Minimum Amount
                                                                                </td>
                                                                                <td width="29%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_min_amt1" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_min_amt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter minimum amount" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                               

                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Maximum Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_maxamt" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_max_amt"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Amount must lies between 0 to 100000" MaximumValue="9999999999" MinimumValue="0"
                                                                                        Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                                </td>
                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">Tax Percentage
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_taxper" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                   
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                              
                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">fixed Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_fix" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                  
                                                                                </td>
                                                                                <td width="18%" class="frm-lft-clr123 border-bottom">MRP Amount
                                                                                </td>
                                                                                <td width="31%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:TextBox ID="txt_mrp" runat="server" CssClass="span8" size="30"
                                                                                        onkeypress="return isNumber()" MaxLength="10"></asp:TextBox>
                                                                                   
                                                                                </td>
                                                                                   
                                                                                </td>

                                                                                <td colspan="2" align="right" class="frm-rght-clr123 border-bottom" width="49%">
                                                                                   <asp:Button ID="btnslbtax" runat="server" CssClass="button" Text="Add" OnClick="btnslbtax_Click" />
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
                                                                                        <asp:GridView ID="grid_tax"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="minimumamount"
                                                                                            Width="100%"
                                                                                            EmptyDataText="No record found"
                                                                                            OnRowDeleting="grid_tax_RowDeleting"
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Slab No.">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("slabNo")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Manimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("minimumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("maximumamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="Tax Percentage">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("taxper")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="Fixed Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("fixedamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="MRP Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("mrpamount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                             <%--   <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>
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
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
