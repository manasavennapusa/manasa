<%@ Page Language="C#" AutoEventWireup="true" CodeFile="startstopPerquisiteamount.aspx.cs" Inherits="payroll_admin_startstopPerquisiteamount" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>



    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
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
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="blue-brdr-1">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                             <td id="Td2" runat="server" align="right" class="txt02" style="height: 16px">
                                                                                <asp:Label ID="lbl_message" runat="server" Enabled="true" ForeColor="Red" Text=""></asp:Label>
                                                                            </td>
                                                                            <td width="3%">
                                                                                <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                                            <td class="txt01"></td>
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
                                                                            <td width="27%" class="txt02"></td>
                                                                            <td width="73%" align="right" class="txt-red">
                                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="txt02">Start/Stop Perquisite 
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                             <tr>
                                                <td class="frm-lft-clr123" width="20%">Financial Year
                                                </td>
                                                <td class="frm-rght-clr123" colspan="2" style="width: 572px">&nbsp;<asp:DropDownList ID="lbl_fyear" runat="server" CssClass="span4"></asp:DropDownList>
                                                    <asp:Label ID="lbl" runat="server"></asp:Label>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">Empcode Code</td>
                                                <td width="75%" class="frm-rght-clr123">&nbsp;<asp:Label ID="txtperquistename" runat="server" CssClass="span4"
                                                    MaxLength="50"></asp:Label>
                                                &nbsp;
                                                   
                                            </tr>

                                            <tr>
                                                <td width="25%" class="frm-lft-clr123 border-bottom">Perquisite Amount</td>
                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Stop" CssClass="button" OnClick="btnsbmit_Click"
                                                        ValidationGroup="s" ToolTip="Click to submit " />&nbsp;&nbsp;&nbsp;
                                                     <asp:Button ID="btn_start" runat="server" Text="Start" CssClass="button" OnClick="btn_start_Click"
                                                         ValidationGroup="s" ToolTip="Click to submit " />&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2"></td>
                                            </tr>
                                        </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" valign="top"></td>
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
