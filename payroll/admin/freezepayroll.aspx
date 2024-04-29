<%@ Page Language="C#" AutoEventWireup="true" CodeFile="freezepayroll.aspx.cs" Inherits="payroll_admin_freezepayroll" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Apply Leave</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup.js"></script>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
     <link href="../../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../js/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="empdetail" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="left: 400px;">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <div>
                    <div style="overflow-x: hidden; overflow-y: scroll; height: 512px; width: 100%;">
                        <table width="98%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            

                                                <td class="txt01">Freeze Payroll</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="7"></td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="19%" class="frm-lft-clr123 border-bottom">Year </td>
                                            <td class="frm-rght-clr123 border-bottom">
                                                 <asp:DropDownList ID="dd_year" runat="server" Width="129px" ToolTip="Financial Year"
                                                    CssClass="blue1" DataTextField="year" DataValueField="year" AutoPostBack="True"
                                                    OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                            </td>

                                        </tr>

                                        <tr>
                                            <td height="7"></td>
                                        </tr>
                                        
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top" class="txt02">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="txt02" height="23" valign="top"><font color="red">* Please Note that the system will not allow to make any changes to payroll data once it freezed !</font></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top">&nbsp;<div class="widget-content"><asp:GridView ID="gd_encash" runat="server" AutoGenerateColumns="False" CssClass ="table table-hover table-striped table-bordered table-highlight-head" BorderWidth="0px"
                                                CellPadding="4" CellSpacing="0" 
                                                Width="100%" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Sl. No">
                                                       <ItemTemplate>
                                                            <%# Container.DataItemIndex  + 1  %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Year">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblYear" runat="server" Text='<%# Bind ("YEAR") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Month">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMonth" runat="server" Text='<%# Bind ("month") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                             <asp:LinkButton ID ="lnkEdit" runat ="server" CommandName ="Edit" Text ="Freeze"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                </Columns>
                                               
                                            </asp:GridView></div>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr>
                                <td height="7"></td>
                            </tr>

                        </table>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
