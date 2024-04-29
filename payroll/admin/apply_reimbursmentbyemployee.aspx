<%@ Page Language="C#" AutoEventWireup="true" CodeFile="apply_reimbursmentbyemployee.aspx.cs" Inherits="payroll_admin_apply_reimbursmentbyemployee" %>

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
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <%--   <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>--%>
                                                                                <%-- <td class="txt01">Application for Reimbursement
                                                    </td>--%>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" valign="top"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="29%" class="txt02">Reimbursement Details
                                                                                </td>
                                                                                <td width="71%" align="right" class="txt-red">
                                                                                    <span id="message" runat="server"></span>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" style="height: 123px">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Employee Code <span class="star"></span>
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="30%">
                                                                                                <asp:TextBox ID="txt_employee" size="30" CssClass="span4" runat="server" ToolTip="Employee Code"
                                                                                                    onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" Enabled="false"></asp:TextBox>
                                                                                               
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Reimbursement Type <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_reimburse" runat="server" CssClass="span4"
                                                                                        DataSourceID="SqlDataSource1" DataTextField="PAYHEAD_NAME" DataValueField="id"
                                                                                        OnDataBound="dd_reimburse_DataBound" OnSelectedIndexChanged="dd_reimburse_SelectedIndexChanged" AutoPostBack="true">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_reimburse"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Enter Loan/Advances Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="select [ID],[PAYHEAD_NAME] from tbl_payroll_reimbursement where status = 1"
                                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Reimbursement Ref. No. <span class=""></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_remb_ref" runat="server" CssClass="span4" size="30" ToolTip="Loan Reference ID"></asp:TextBox>
                                                                                  <%--  <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_remb_ref"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Enter Reference ID" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                                        ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_remb_ref" ToolTip="only enter alphabets and numbers"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Reimbursement Amount <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_remb_amount" runat="server" CssClass="span4" size="30" ToolTip="Loan Amount" MaxLength="9"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_remb_amount"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ValidationGroup="v"></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_remb_amount"
                                                                                        Display="Dynamic" ErrorMessage="Enter a valid amount" MaximumValue="999999999"
                                                                                        MinimumValue="0" Type="Currency" ValidationGroup="v"></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr runat="server" visible="false">
                                                                                <td width="25%" class="frm-lft-clr123">Sanction Date <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_sanct" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                    <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sanct"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                        ToolTip="Select Sanction Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                                        TargetControlID="txt_sanct">
                                                                                    </cc1:CalendarExtender>
                                                                                </td>
                                                                            </tr>

                                                                            <tr runat="server" visible="false">
                                                                                <td width="25%" class="frm-lft-clr123">Reimburse On
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="span4" Width="150px">
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="dd_year" runat="server" CssClass="span4" Width="150px">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year " ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Attachment (If any)
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:FileUpload ID="upload_attach" runat="server" CssClass="span4" Width="287px" />
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit Reimbursement Details"
                                                                                        OnClick="btnsubmit_Click" ValidationGroup="v" />&nbsp;
                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details"
                                                        ValidationGroup="none" OnClick="btnreset_Click" />
                                                                                </td>
                                                                            </tr>
                                                                            <%--<tr>
                                                    <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                    </td>
                                                </tr>--%>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">&nbsp;
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
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
