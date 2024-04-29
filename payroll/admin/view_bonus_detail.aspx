<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_bonus_detail.aspx.cs" Inherits="payroll_admin_view_bonus_detail" %>

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
                                        <img src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...</td>
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
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                    <td class="txt01">Sanction Bonus</td>
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
                                                    <td width="29%" class="txt02">View
               Bonus Details</td>
                                                    <td width="71%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td valign="top" colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="21%" class="frm-lft-clr123">Employee Code</td>
                                                    <td class="frm-rght-clr123" width="29%">
                                                        <asp:Label ID="lbl_empcode" runat="server"></asp:Label></td>
                                                    <td width="1%" rowspan="5">&nbsp;</td>
                                                    <td width="18%" class="frm-lft-clr123">Bonus</td>
                                                    <td width="31%" class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_bonus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5px"></td>
                                                    <td colspan="2" height="5px"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Bonus Reference No.</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_ref" runat="server"></asp:Label></td>
                                                    <td class="frm-lft-clr123">Bonus Amount</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_amount" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Sanction Date</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_sanction" runat="server"></asp:Label></td>
                                                    <td class="frm-lft-clr123">Detail</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_detail" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td height="23" valign="bottom" colspan="2" align="center">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td class="txt02" align="left">Dispersement Detail</td>
                                                                <td align="right" class="txt-red" colspan="4"><span id="Span1" runat="server"></span>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="5"></td>
                                                </tr>
                                                <tr>
                                                    <td height="10" valign="top" colspan="5" class="head-2">

                                                        <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CellPadding="4" CellSpacing="0" DataKeyNames="month" Font-Names="Arial" Font-Size="11px"
                                                            Width="100%" EmptyDataText="No record found">
                                                            <Columns>

                                                                <asp:TemplateField HeaderText="Month">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left"
                                                                        VerticalAlign="Top" Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="kck" runat="server" Text='<%# Bind("month")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Year">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left"
                                                                        VerticalAlign="Top" Width="25%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="pck" runat="server" Text='<%# Bind("year")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left"
                                                                        VerticalAlign="Top" Width="18%" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="acl" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                                            <FooterStyle CssClass="frm-lft-clr123" />
                                                            <RowStyle Height="5px" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                                </tr>
                                            </table>
                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">&nbsp;</td>
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
