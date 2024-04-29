<%@ Page Language="C#" AutoEventWireup="true" CodeFile="languagemaster.aspx.cs" Inherits="admin_languagemaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
  <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">
                                        Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                        <tbody>
                            <tr>
                                <td valign="top" class="blue-brdr-1" colspan="2">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                Add Language
                                            </td>
                                            <td align="right">
                                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tbody>
                                            
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom" width="40%">
                                                    Language
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom" width="60%">
                                                    <asp:TextBox ID="txtLanguage" runat="server" CssClass="blue1" Width="250px" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLanguage"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Language" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            
                                            
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td width="20%" class=" border-left border-bottom">
                                                Mandatory Fields (<img alt="" src="../img/error1.gif" />)
                                            </td>
                                            <td align="right" width="80%" class="border-right border-bottom" height="40px">
                                                <asp:Button ID="btnlanguage" runat="server" CssClass="button"
                                                    Text="Save" ValidationGroup="c" onclick="btnlanguage_Click" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    </td> </tr> </tbody> </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
