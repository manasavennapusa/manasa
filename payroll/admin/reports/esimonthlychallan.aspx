<%@ Page Language="C#" AutoEventWireup="true" CodeFile="esimonthlychallan.aspx.cs"
    Inherits="payroll_admin_reports_esimonthlychallan" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
        @import "../../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

    <script type="text/javascript" src="../../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../../js/timepicker.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Emp_PayStructure" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <%--  <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1" style="width: 100%">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%" style="height: 16px">
                                                <img src="../../../images/employee-icon.jpg" alt="" width="16" height="16" />
                                            </td>
                                            <td class="txt01" style="height: 16px">
                                                &nbsp;ESI Monthly Challan
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="4">
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top" style="width: 100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="txt02" style="height: 13px">
                                                Fill Monthly ESI Challan Details
                                            </td>
                                            <td class="txt02" align="right">
                                                <span id="message" runat="server"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 123px; width: 100%;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Challan Submission Date
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                    CssClass="blue1" DataTextField="year" DataValueField="year">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Branch
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:DropDownList ID="dd_month" runat="server" Width="129px" ToolTip="Month" CssClass="blue1"
                                                    DataTextField="month " DataValueField="month ">
                                                    <asp:ListItem Value="1">1st Apr - 30th Sep</asp:ListItem>
                                                    <asp:ListItem Value="2">1st Oct - 31 st Mar</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Bank Name
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 11%">
                                                Period Of Contribution
                                            </td>
                                            <td class="frm-rght-clr123" style="width: 27%">
                                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                      
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ToolTip="Click to view Employee Payslip" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="4">
                                                Mandatory Fields (<img src="../../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>
                                    </table>
                                </td>
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
