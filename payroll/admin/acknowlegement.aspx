<%@ Page Language="C#" AutoEventWireup="true" CodeFile="acknowlegement.aspx.cs" Inherits="payroll_admin_provident_esi_fund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Leave Rule</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
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
                                    <td valign="bottom">Please Wait...
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
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table>
                                                        <tr>
                                                           <%-- <td width="3%" style="height: 16px">
                                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                            </td>--%>
                                                        <%--    <td class="txt01" style="height: 15px" valign="middle">&nbsp;Acknowledgement
                                                            </td>--%>
                                                            <td align="right">
                                                                <span id="message" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="25" valign="middle" class="txt02">&nbsp;Acknowledgement No.
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 250px">Financial Year
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" CssClass="span4"
                                                        DataSourceID="SqlDataSource1" DataTextField="financial_year" DataValueField="financial_year"
                                                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        SelectCommand="SELECT [financial_year], [id] FROM [tbl_payroll_tax_master] order by id desc"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Quater 1
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_no1" runat="server" CssClass="span4" ValidationGroup="v"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                        ValidationExpression="^[0-9]+$" ControlToValidate="txt_no1" ToolTip="only enter numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
                                                  <img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Quater 2
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_no2" runat="server" CssClass="span4" ValidationGroup="v"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                        ValidationExpression="^[0-9]+$" ControlToValidate="txt_no2" ToolTip="only enter numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
                                                   <img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Quater 3
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_no3" runat="server" CssClass="span4" ValidationGroup="v"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                        ValidationExpression="^[0-9]+$" ControlToValidate="txt_no3" ToolTip="only enter numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
                                                      <img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">Quater 4
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_no4" runat="server" CssClass="span4" ValidationGroup="v"></asp:TextBox>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                        ValidationExpression="^[0-9]+$" ControlToValidate="txt_no4" ToolTip="only enter numbers"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
                                                       <img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom">&nbsp;
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" ValidationGroup="v"/>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" height="10"></td>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
