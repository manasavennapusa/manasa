<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_reimbursement_detail.aspx.cs"
    Inherits="payroll_admin_edit_reimbursement_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .pop2 {
            position: absolute;
            background-color: #fff;
            z-index: 1002;
            overflow: auto;
            padding: 0px;
            left: 135px;
            top: 48%;
            width: 500px;
        }
    </style>
    <script src="../../leave/js/popup.js"></script>
    <script src="../../js/JavaScriptValidations.js"></script>
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
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="top" class="blue-brdr-1">
                                         <%--   <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>
                                                    <td class="txt01">Application for Reimbursement
                                                    </td>
                                                </tr>
                                            </table>--%>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top"></td>
                                    </tr>
                                    <tr>
                                        <td height="20" valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="29%" class="txt02">Update Reimbursement
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
                                                    <td width="25%" class="frm-lft-clr123">Employee Code
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <table width="100%" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="30%">
                                                                    <asp:TextBox ID="txt_employee" size="30" CssClass="blue1" runat="server" ToolTip="Employee Code" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="rfvempcode" runat="server" ControlToValidate="txt_employee"
                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                        ToolTip="Select Employee Code" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td width="45%">
                                                                    <a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">Pick Employee</a>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">Reimbursement Type
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_reimburse" runat="server" CssClass="blue1" Width="180px"
                                                            DataSourceID="SqlDataSource1" DataTextField="PAYHEAD_NAME" DataValueField="id"
                                                            OnDataBound="dd_reimburse_DataBound">
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
                                                    <td width="25%" class="frm-lft-clr123">Reimbursement Ref. No.
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_remb_ref" runat="server" CssClass="blue1" size="30" ToolTip="Loan Reference ID"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_remb_ref"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter Reference ID" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                            ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_ref" ToolTip=" enter only alphabets or numbers"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RegularExpressionValidator>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">Reimbursement Amount
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_remb_amount" runat="server" CssClass="blue1" size="30" ToolTip="Loan Amount"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfvloanamnt" runat="server" ControlToValidate="txt_remb_amount"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            ToolTip="Enter Amount" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_remb_amount"
                                                            Display="Dynamic" ErrorMessage="Enter valid amount" MaximumValue="9999999" MinimumValue="0"
                                                            Type="Currency" ValidationGroup="v"></asp:RangeValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">Sanction Date
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_sanct" runat="server" CssClass="blue1" Width="100px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                        <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sanct"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                            ToolTip="Select Sanction Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            TargetControlID="txt_sanct">
                                                        </cc1:CalendarExtender>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">Reimburse On
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="blue1" Width="90px" OnDataBound="dd_month_DataBound">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="dd_year" runat="server" CssClass="blue1" Width="90px" OnDataBound="dd_year_DataBound">
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                        <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year"
                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year " ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">Attachment (If any)
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_file" runat="server"></asp:Label><br />
                                                        <asp:FileUpload ID="upload_attach" runat="server" CssClass="blue1" Width="287px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                    </td>
                                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                                        <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit Reimbursement Details"
                                                            OnClick="btnsubmit_Click1" ValidationGroup="v" />&nbsp;
                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details"
                                                        ValidationGroup="none" OnClick="btnreset_Click" />
                                                    </td>
                                                </tr>
                                            <%--    <tr>
                                                    <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">&nbsp;<asp:HiddenField ID="HiddenField1" runat="server" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsubmit" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
