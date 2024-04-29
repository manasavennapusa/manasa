<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthlyESIReportNew.aspx.cs" Inherits="payroll_admin_reports_MonthlyESIReportNew" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../../css/blue1.css" rel="stylesheet" />
    <link href="../../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server" AsyncPostBackTimeout="50000">
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
                                        <img src="../../../images/loading.gif" /></td>
                                    <td valign="bottom">Please Wait...</td>
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
                                                    <td valign="top" colspan="5">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="3%" style="height: 16px">
                                                                                <img src="../../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                                            <td id="Td1" class="txt01" runat="server" style="width: 347px; height: 16px">Monthly ESI Report</td>
                                                                            <td id="Td2" runat="server" align="right" class="txt02" style="height: 16px">
                                                                                <asp:Label ID="lbl_message" runat="server" Enabled="true" Text=""></asp:Label></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="20%">Financial Year</td>
                                                                            <td class="frm-rght-clr123" colspan="2">&nbsp;<asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Select Month</td>
                                                                            <td class="frm-rght-clr123" colspan="2">&nbsp;<asp:DropDownList ID="dd_month" runat="server" CssClass="select" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
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
                                                                            </asp:DropDownList></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Select Company</td>
                                                                            <td align="left" colspan="2" class="frm-rght-clr123" style="width: 572px">&nbsp;
                                                                                <asp:DropDownList
                                                                                    ID="ddlcompany"
                                                                                    runat="server"
                                                                                    CssClass="select"
                                                                                    DataTextField="companyname"
                                                                                    DataValueField="companyid"
                                                                                    DataSourceID="SqlDataSource1">
                                                                                </asp:DropDownList>&nbsp;
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlcompany"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>

                                                                                <asp:SqlDataSource
                                                                                    ID="SqlDataSource1"
                                                                                    runat="server"
                                                                                    SelectCommand="select companyid, companyname from tbl_intranet_companydetails "
                                                                                    SelectCommandType="Text"
                                                                                    ConnectionString="<%$connectionStrings:ConnectionString %>"></asp:SqlDataSource>

                                                                            </td>
                                                                        </tr>




                                                                       
                                                                </td>
                                                            </tr>
                                                            

                                                            <tr>
                                                                <td colspan="3">
                                                                    <div id="processattendance" runat="server">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" style="width: 198px;">Fetch Report</td>
                                                                                <td align="left" class="frm-rght-clr123 border-bottom" colspan="2">&nbsp;<asp:Button ID="btn_procs_att" runat="server" CssClass="button" Text="Fetch Report"
                                                                                    ValidationGroup="v" OnClick="btn_procs_att_Click" />

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="15" colspan="3"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>

                                                                </td>
                                                            </tr>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15"></td>
                                                </tr>
                                                <tr>
                                                    <td height="7">
                                                        <asp:Button ID="btnexport" runat="server" CssClass="button" OnClick="btnexport_Click"
                                                            Text="Export" ToolTip="Export" /></td>
                                                </tr>
                                                <tr>
                                                    <td valign="top">
                                                        <div>
                                                            <asp:GridView 
                                                                ID="empgrid" 
                                                                GridLines="Both" 
                                                                runat="server" 
                                                                AllowPaging="True"
                                                                OnPageIndexChanging="empgrid_PageIndexChanging" 
                                                                PageSize="50" 
                                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                               
                                                            </asp:GridView>
                                                        </div>
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
            <Triggers>

                <asp:PostBackTrigger ControlID="btnexport" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
