<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewpayheadmaster.aspx.cs"
    Inherits="payroll_admin_viewpayheadmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="bank" runat="server">
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
                                                    <td valign="top" height="463px">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="blue-brdr-1">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <%--     <td width="3%" style="height: 16px">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>--%>
                                                                            <%--  <td class="txt01" style="height: 16px">
                                                Pay Head Master
                                            </td>--%>
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
                                                                                        <td width="27%" class="txt01">View Pay Head Details
                                                                                        </td>
                                                                                        <td width="73%" align="right" class="txt-red">
                                                                                            <span id="message" runat="server"></span>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <div class="widget-content">
                                                                                    <asp:GridView ID="payheadgird"
                                                                                        runat="server"
                                                                                        DataKeyNames="id"
                                                                                        AutoGenerateColumns="False"
                                                                                        EmptyDataText="Sorry no record found"
                                                                                        DataSourceID="SqlDataSource1"
                                                                                        AllowPaging="True"
                                                                                      
                                                                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="id" HeaderText="Pay Head Id" SortExpression="payheadid"></asp:BoundField>
                                                                                            <asp:BoundField DataField="payhead_name" HeaderText="Pay Head Name" SortExpression="payheadname"></asp:BoundField>
                                                                                            <asp:BoundField DataField="alias_name" HeaderText="Alias Name" SortExpression="alias_name"></asp:BoundField>
                                                                                            <asp:BoundField DataField="payhead_type" HeaderText="Pay Head Type" SortExpression="payhead_type"></asp:BoundField>
                                                                                            <asp:BoundField DataField="name_inpayslip" HeaderText="Name in Pay Slip" SortExpression="name_inpayslip"></asp:BoundField>
                                                                                            <asp:TemplateField>

                                                                                                <ItemTemplate>
                                                                                                    <a class="link05" href="viewpayhead.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                        target="_self">View</a>| <a class="link05" href="editpayheadmaster.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                            target="_self">Edit</a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>
                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="SELECT payhead_name,id,alias_name,(CASE WHEN payhead_type=0 THEN 'Earnings' WHEN payhead_type=1 THEN 'Deductions' ELSE 'N/A' END)payhead_type,name_inpayslip FROM tbl_payroll_payhead WHERE status=1 and type=1"
                                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="10" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">&nbsp;
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
        </asp:UpdatePanel>
    </form>
</body>
</html>
