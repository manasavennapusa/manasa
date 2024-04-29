<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewholdsalary.aspx.cs" Inherits="payroll_admin_viewholdsalary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .star:before
        {
            content: " *";
        }
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="bank" runat="server">
</asp:ScriptManager>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
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
                                            <td valign="top" height="463px">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="blue-brdr-1">
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <%--<td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>--%>
                                                                    <td class="txt01" style="height: 16px">Hold Loan Payout
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" valign="top">&nbsp;
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td align="right" valign="top" style="height: 5px"></td>
                                                    </tr>

                                                    <tr>
                                                        <td height="5" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="head-2" valign="top">
                                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                                                                                    runat="server">
                                                                                    <ProgressTemplate>
                                                                                        <div class="divajax" style="top: 160px;">
                                                                                            <table width="100%">
                                                                                                <tr>
                                                                                                    <td align="center" valign="top">
                                                                                                        <img alt="" src="../../images/loading.gif" />
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
                                                                                <%--    <div class="widget-content">--%>
                                                                                <div class="row-fluid">
                                                                                    <div class="span12">
                                                                                        <div class="widget no-margin">

                                                                                            <div class="widget-body">
                                                                                                <div id="dt_example" class="example_alt_pagination">
                                                                                                    <asp:GridView ID="empgrid" runat="server" CellSpacing="0" OnPreRender="empgrid_PreRender"
                                                                                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                                                        BorderWidth="0px" AllowPaging="True" PageSize="200" EmptyDataText="No such employee exists !"
                                                                                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                                        <Columns>
                                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:CheckBox ID="checkg" runat="server" Checked="false"></asp:CheckBox>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="lblempcodeg" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Employee Name">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText=" From Month">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("months") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText="Year">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("year") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>
                                                                                                            <asp:TemplateField HeaderText=" Reason">
                                                                                                                <ItemTemplate>
                                                                                                                    <asp:Label ID="l11" runat="server" Text='<%# Bind ("remarks") %>'></asp:Label>
                                                                                                                </ItemTemplate>
                                                                                                            </asp:TemplateField>

                                                                                                        </Columns>

                                                                                                    </asp:GridView>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <div class="title" id="div_R" runat="server" visible="false"><p style="font-size:12px;font: bold 12px Arial, Helvetica, sans-serif;color: #08486d;">Release Salary</p>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                     <tr>
                                                                            <td class="frm-lft-clr123" width="20%">Financial Year
                                                                            </td>
                                                                            <td class="frm-rght-clr123" colspan="2" style="width: 572px">&nbsp;<asp:Label ID="lbl_fyear" runat="server" CssClass="span4"></asp:Label>
                                                                                <asp:Label ID="lbl" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                     <tr>
                                                                        <td class="frm-lft-clr123" width="45%">Release Month
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="75%">&nbsp;
                                                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="span4" AutoPostBack="true">
                                                                           
                                                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                                                            <asp:ListItem Value="5">May</asp:ListItem>
                                                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                                                             <asp:ListItem Value="1">Jan</asp:ListItem>
                                                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                                                            <asp:ListItem Value="3">Mar</asp:ListItem>

                                                                        </asp:DropDownList>

                                                                        </td>
                                                                    </tr>
                                                                   

                                                                    <tr>
                                                                        <td colspan="2" height="5"></td>
                                                                    </tr>
                                                                </table>
                                                            </div>

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
        <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    </form>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#empgrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
