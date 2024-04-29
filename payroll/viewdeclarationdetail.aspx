<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewdeclarationdetail.aspx.cs"
    Inherits="payroll_viewdeclarationdetail" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>

    <script type="text/javascript" src="../js/tabber.js"></script>
    <link rel="Stylesheet" href="../css/table.css" />

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <script src="../../leave/js/popup.js"></script>
    >

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
                                        <img src="../images/loading.gif" />
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
                <div id="declare">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01">View & Approve Employee Declaration
                                        </td>
                                        <td width="55%" align="right" class="txt-red">
                                            <span id="message" runat="server"></span>&nbsp;
                                        </td>
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
                                        <td width="20%" class="frm-lft-clr123">Employee Code
                                        </td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:Label ID="lbl_empcode" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Employee Name
                                        </td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:Label ID="lbl_empname" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Financial Year
                                        </td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" colspan="5">House Property Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Self Occupied
                                        </td>
                                        <td class="frm-rght-clr123" colspan="3">
                                            <asp:Label ID="lbl_self" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom">Loan Borrowed
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom">
                                            <asp:Label ID="lbl_loan" runat="server" Text="Label"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123 border-bottom" width="20%">Interest
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="30%">
                                            <asp:Label ID="txt_houseint" runat="server" Text="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="20"></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <%-- :::::::::::::::::::::::::::::::::::::: Declaration Tabs ::::::::::::::::::::::::::::::::::::::::: --%>
                        <tr>
                            <td colspan="2">
                                <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Width="100%"
                                    CssClass="ajax__tab_xp2">
                                    <cc1:TabPanel ID="Tab_rent" runat="server" HeaderText="Rent Paid Details">
                                        <ContentTemplate>
                                            <div>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="5" colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="txt02">Monthly Paid Rent
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="9">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="24%">Metro/Non-metro City
                                                                                </td>
                                                                                <td class="frm-rght-clr123" colspan="8" width="76%">
                                                                                    <asp:Label ID="lbl_metro" runat="server" Text="Label"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="15%">April
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_apr" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="15%" style="border-left: none;" >May
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_may" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" width="15%" style="border-left: none;" >June
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_june" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">July
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_jul" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >August
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_aug" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >September
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_sep" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">October
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_oct" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >November
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_nov" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >December
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_dec" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123  border-bottom">January
                                                                    </td>
                                                                    <td class="frm-rght-clr123  border-bottom" colspan="2">
                                                                        <asp:Label ID="txt_jan" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123  border-bottom" style="border-left: none;" >February
                                                                    </td>
                                                                    <td class="frm-rght-clr123  border-bottom" colspan="2">
                                                                        <asp:Label ID="txt_feb" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123  border-bottom" style="border-left: none;">March
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom"  colspan="2">
                                                                        <asp:Label ID="txt_mar" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="9"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel ID="Tab_children" runat="server" HeaderText="Children(Studying) Details">
                                        <ContentTemplate>
                                            <div>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="5" colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" class="txt02">No. of Children Studying
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" colspan="2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="15%">April
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_apr2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;"  width="15%">May
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_may2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;"  width="15%">June
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2" width="18%">
                                                                        <asp:Label ID="txt_june2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">July
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_jul2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >August
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_aug2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >September
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_sep2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">October
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_oct2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >November
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_nov2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123" style="border-left: none;" >December
                                                                    </td>
                                                                    <td class="frm-rght-clr123" colspan="2">
                                                                        <asp:Label ID="txt_dec2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">January
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                        <asp:Label ID="txt_jan2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-left: none;" >February
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                        <asp:Label ID="txt_feb2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-left: none;" >March
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                        <asp:Label ID="txt_mar2" runat="server" Text="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="9"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel ID="Tab_6Adetail" runat="server" HeaderText="VI-A Deduction">
                                        <ContentTemplate>
                                            <div>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" colspan="2">VI-A Deduction
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td  valign="top" colspan="2" height="10">
                                                                <asp:GridView ID="grid_6A" runat="server" Width="100%" DataKeyNames="section_detail"
                                                                    AutoGenerateColumns="False" EmptyDataText="No record found" CellPadding="4" 
                                                                    Font-Names="Arial" Font-Size="11px" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                    
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Status">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top"
                                                                                Width="5%" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("status")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Section">
                                                                            <ItemStyle Width="25%"  HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                                                            <HeaderStyle  HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="kck" runat="server" Text='<%# Bind("section_name")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Detail">
                                                                            <ItemStyle Width="25%"  HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="pck" runat="server" Text='<%# Bind("section_detail")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount">
                                                                            <ItemStyle Width="30%"  HorizontalAlign="Left" VerticalAlign="Top"></ItemStyle>
                                                                            <HeaderStyle  HorizontalAlign="Left"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="acl" runat="server" Text='<%# Bind("a_amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle Height="5px"></RowStyle>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </div>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                </cc1:TabContainer>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" colspan="2"></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="right">
                                            <input type="button" id="Button1" class="button" value="Back" onclick="javascript: history.go(-1);" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
