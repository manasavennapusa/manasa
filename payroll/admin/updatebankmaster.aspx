<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatebankmaster.aspx.cs"
    Inherits="payroll_admin_updatebankmaster" %>

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
                                                <td width="27%" class="txt01" style="height: 13px">Update Bank Record
                                                </td>
                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
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
                                                <td width="25%" class="frm-lft-clr123">Bank Name <span class="star">
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_bankname" size="40" CssClass="span4" runat="server" ToolTip="Bank Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_bankname"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                        Display="Dynamic" ToolTip="Enter Leave Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txt_bankname"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RegularExpressionValidator>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">Bank Code
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_bankcode" runat="server" CssClass="span4"  Enabled="False" onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_bankcode"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Leave Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">Account Number <span class="star">
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_accno" runat="server" CssClass="span4" size="40" ToolTip="Display name of leave " onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_accno"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                        SetFocusOnError="True" ToolTip="Enter Display Name" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_accno"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">Bank Address
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_bankaddr" runat="server" CssClass="span4" size="40" ToolTip="Display name of leave "
                                                        TextMode="MultiLine" ></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_bankaddr"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9.\/\-\#\s]+$" ToolTip="Enter only alphanumeric and space / -  #"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">For TDS(Check if yes)
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">&nbsp;<asp:CheckBox ID="chktds" runat="server" OnCheckedChanged="chktds_CheckedChanged" AutoPostBack="true" />
                                                </td>
                                            </tr>

                                            <tr runat="server" visible="false" id="bsrcode">
                                                <td width="25%" class="frm-lft-clr123">BSR Code
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtbsrcode" runat="server" CssClass="span4" size="40" ></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtbsrcode"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                </td>
                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                        ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;
                                                <asp:Button ID="Button1" runat="server" CssClass="button" OnClick="Button1_Click"
                                                    Text="Cancel" />
                                                </td>
                                            </tr>
                                           <%-- <tr>
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
                                      </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
