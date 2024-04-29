<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_bonusmaster_list.aspx.cs" Inherits="payroll_admin_view_bonusmaster_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>

    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                    <td valign="bottom">Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" height="463px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01" style="height: 16px">Bonus Master</td>
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
                                                <td height="20" valign="top" class="txt02">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="27%" class="txt02">View Bonus Details</td>
                                                            <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="head-2">

                                                    <asp:GridView ID="bonusgird" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="Sorry no record found" DataSourceID="SqlDataSource1" AllowPaging="True" PageSize="30">
                                                        <Columns>

                                                            <asp:BoundField DataField="payhead_name" HeaderText="Bonus Name" SortExpression="payhead_name">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="alias_name" HeaderText="Alias Name" SortExpression="alias_name">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="payhead_type" HeaderText="Pay Head Type" SortExpression="payhead_type">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="15%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>

                                                            <asp:BoundField DataField="name_inpayslip" HeaderText="Name in Pay Slip" SortExpression="name_inpayslip">
                                                                <ItemStyle CssClass="frm-rght-clr1234" Width="30%" />
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                            </asp:BoundField>


                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top" Width="10%" />
                                                                <ItemTemplate>
                                                                    <a class="link05" href="view_bonus_master.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" target="_self">View</a>|  
                       <a class="link05" href="edit_bonus_master.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>" target="_self">Edit</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345" />
                                                        <RowStyle Height="5px" />

                                                    </asp:GridView>

                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        SelectCommand="SELECT id,payhead_name,alias_name,(CASE WHEN payhead_type=0 THEN 'Earnings' WHEN payhead_type=1 THEN 'Deductions' ELSE 'N/A' END)payhead_type,name_inpayslip FROM tbl_payroll_bonus where status=1" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10" valign="top"></td>
                                </tr>
                                <tr>
                                    <td valign="top">&nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
