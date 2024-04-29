<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewallowances.aspx.cs" Inherits="payroll_admin_viewallowances" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

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
                                                                    <%--    <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                    <%--<td class="txt01" style="height: 16px">Allowances Master
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
                                                                                <td width="27%" class="txt01">View Allowances Details
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
                                                                                CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                DataKeyNames="id"
                                                                                AutoGenerateColumns="False"
                                                                                EmptyDataText="Sorry no record found"
                                                                                DataSourceID="SqlDataSource1" AllowPaging="True"
                                                                                PageSize="15">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="id" HeaderText="Id" SortExpression="pay head id"></asp:BoundField>
                                                                                    <asp:BoundField DataField="payhead_name" HeaderText="Allowances Name" SortExpression="pay head name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="alias_name" HeaderText="Alias Name" SortExpression="alias_name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="payhead_type" HeaderText="Pay Head Type" SortExpression="pay head_type"></asp:BoundField>
                                                                                    <asp:BoundField DataField="name_inpayslip" HeaderText="Name in Pay Slip" SortExpression="name_in pay slip"></asp:BoundField>
                                                                                    <asp:TemplateField>

                                                                                        <ItemTemplate>
                                                                                            <a class="link05" href="viewallowancesmaster.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                target="_self">View</a>| <a class="link05" href="editallowancesmaster.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                    target="_self">Edit</a>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerSettings Mode="NumericFirstLast" />
                                                  
                                                                            </asp:GridView>
                                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                SelectCommand="SELECT payhead_name,id,alias_name,(CASE WHEN payhead_type=0 THEN 'Earnings' WHEN payhead_type=1 THEN 'Deductions' ELSE 'N/A' END)payhead_type,name_inpayslip FROM tbl_payroll_payhead WHERE status=1 and type in(2,3)"
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

    </form>
</body>
</html>
