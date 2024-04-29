<%@ Page Language="C#" AutoEventWireup="true" CodeFile="processattendanceforfullandfinal1.aspx.cs" Inherits="payroll_admin_processattendanceforfullandfinal1" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />


    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
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
                                                                <td valign="top" class="blue-brdr-1" style="width: 100%">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top" style="width: 100%">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="txt02" style="height: 13px">Employee Full and Final Settlement Form
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
                                                                            <td class="frm-lft-clr123" style="width: 11%">Employee Code  <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" AutoPostBack="true"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                               
                                                                            <a href="JavaScript:newPopup1('../../leave/picemployeresigned.aspx');" class="link05">Pick Employee</a>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Select Month<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:DropDownList ID="ddl_month" runat="server" CssClass="span4" OnSelectedIndexChanged="ddl_month_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Mar</asp:ListItem>
                                                                                    <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                                    <asp:ListItem Value="5">May</asp:ListItem>
                                                                                    <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                                    <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                                    <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                                    <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                                    <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                                    <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                                    <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Finance Year<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lblfyear" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">LWP<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:TextBox ID="txtlwp" runat="server" CssClass="span4"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Working Days<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:TextBox ID="txt_wdays" runat="server" CssClass="span4"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%"><span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click" />
                                                                            </td>

                                                                        </tr>

                                                                    </table>

                                                                </td>
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
            <%--  <Triggers>
                <asp:PostBackTrigger ControlID="btnprint" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
