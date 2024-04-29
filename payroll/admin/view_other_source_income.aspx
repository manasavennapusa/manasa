<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_other_source_income.aspx.cs"
    Inherits="payroll_admin_view_other_source_income" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .star:before
        {
            content: " *";
        }
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
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
                                                    <td>
                                                        <div id="divedit" visible="false" runat="server">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <%--    <td width="3%">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>--%>
                                                                                <%-- <td class="txt01">Other Source Income Master
                                                    </td>--%>
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
                                                                                <td width="27%" class="txt02">Other Source Income
                                                                                </td>
                                                                                <td width="73%" align="right" class="txt-red">
                                                                                    <span id="message" runat="server"></span>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" style="height: 123px">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Emp Code <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code"
                                                                                        Width="" Enabled="False"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                                                        ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Financial Year <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="dd_year" runat="server" DataSourceID="SqlDataSource12" DataTextField="financialyear"
                                                                                        DataValueField="financialyear" Enabled="false" OnDataBound="dd_year_DataBound"
                                                                                        CssClass="span4" Width="">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToValidate="dd_year"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="select distinct [financial_year] as financialyear from tbl_payroll_tax_master"
                                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Income Source <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">
                                                                                    <asp:DropDownList ID="ddlincomesource" runat="server" Width="" DataSourceID="SqlDataSource2"
                                                                                        DataTextField="incomesource" DataValueField="id" CssClass="span4">
                                                                                    </asp:DropDownList>
                                                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="select id,incomesource from tbl_payroll_income_source_master"
                                                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123">Amount <span class="star"></span>
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123">&nbsp;<asp:TextBox ID="txtamount" runat="server" Width="" CssClass="span4"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Enter Employee Code"
                                                                                        Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ControlToValidate="txtamount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RangeValidator ID="RangeValidator28" runat="server" ControlToValidate="txtamount"
                                                                                        ErrorMessage="RangeValidator" MaximumValue="9999999" MinimumValue="0" ToolTip="Enter valid amount"
                                                                                        Type="Currency" ValidationGroup="s"><img src="../../images/error1.gif" alt="Enter correct amount" /></asp:RangeValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                                </td>
                                                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                                        ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                            <%-- <tr>
                                                    <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                    </td>
                                                </tr>--%>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">&nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" height="463px">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="blue-brdr-1">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <%-- <td width="3%" style="height: 16px">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                            <%-- <td class="txt01" style="height: 16px">View/Edit Others Source
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
                                                                                        <td width="27%" class="txt02">View Others Source Details
                                                                                        </td>
                                                                                        <td width="73%" align="right" class="txt-red">
                                                                                            <span id="message1" runat="server"></span>&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                <div class="widget-content">
                                                                                    <asp:GridView ID="payheadgird" runat="server"
                                                                                        DataKeyNames="id" AutoGenerateColumns="False"
                                                                                        EmptyDataText="Sorry no record found" DataSourceID="SqlDataSource1" AllowPaging="True"
                                                                                        PageSize="30" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="empcode" HeaderText="Employee Code" SortExpression="empcode"></asp:BoundField>
                                                                                            <asp:BoundField DataField="fyear" HeaderText="Financial Year" SortExpression="fyear"></asp:BoundField>
                                                                                            <asp:BoundField DataField="incomesource" HeaderText="Income Source" SortExpression="incomesource"></asp:BoundField>
                                                                                            <asp:BoundField DataField="amount" HeaderText="Amount" SortExpression="amount"></asp:BoundField>
                                                                                            <asp:TemplateField>

                                                                                                <ItemTemplate>
                                                                                                    <a class="link05" href="view_other_source_income.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                        target="_self">Edit</a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>
                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="SELECT i.id,empcode,fyear,i.incomesourceid as incomesourceid,m.incomesource,amount,createdby,createddate FROM tbl_payroll_other_source_income i inner join tbl_payroll_income_source_master m on i.incomesourceid=m.id"
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
