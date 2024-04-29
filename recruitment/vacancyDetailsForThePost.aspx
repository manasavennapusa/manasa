<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vacancyDetailsForThePost.aspx.cs"
    Inherits="recruitment_vacancyDetailsForThePost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" colspan="4">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">VACANCY DETAILS FOR THE POST-
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123 border-bottom" width="25%">Department
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:Label ID="lbldepartment" runat="server"></asp:Label>
                    </td>
                    <td class="frm-lft-clr123 border-bottom" width="25%">Designation
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:Label ID="lbl_Designation" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4" class="border-bottom">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td align="center" colspan="6" class="frm-lft-clr-main">Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123 border-bottom" width="18%">No of Posts
                                </td>
                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                    <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="18%">Posted On
                                </td>
                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                    <asp:Label ID="lbl_postedon" runat="server"></asp:Label>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">Location
                                </td>
                                <td class="frm-rght-clr123 border-bottom" width="18%">
                                    <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="6"></td>
                            </tr>


                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" class="border-bottom">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="50%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">ADDITIONAL QUALIFIERS
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">INDUSTRIES PREFERIED
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           <%-- <tr>
                                <td height="5" colspan="2"></td>
                            </tr>--%>
                            <tr>
                                <td width="50%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">JOB DESCRIPTION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">SKILLS
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="Label9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <%--<tr>
                                <td height="5" colspan="2"></td>
                            </tr>--%>
                            <tr>
                                <td width="50%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">EDUCATIONAL QUALIFICATION
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td>
                                    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                        <tr>
                                            <td align="center" class="frm-lft-clr-main">EXPERIENCE
                                            </td>
                                        </tr>
                                        <tr>
                                           <td class="frm-rght-clr123">
                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5" colspan="4"></td>
                </tr>

            </table>
        </div>
    </form>
</body>
</html>
