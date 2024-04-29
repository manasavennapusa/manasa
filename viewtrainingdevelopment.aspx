<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtrainingdevelopment.aspx.cs" Inherits="viewtrainingdevelopment" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Training" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                                                                            <%--<td class="txt01" style="height: 16px">
                                                Bank Master
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
                                                                                        <td width="27%" class="txt02">view Training & Development Details
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
                                                                                    <asp:GridView ID="traininggrid" runat="server"
                                                                                        DataKeyNames="id" AutoGenerateColumns="False"
                                                                                        EmptyDataText="Sorry no record found" DataSourceID="SqlDataSource1" AllowPaging="True"
                                                                                         CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                        <Columns>
                                                                                            <asp:BoundField DataField="title" HeaderText="Title" SortExpression="title"></asp:BoundField>
                                                                                            <asp:BoundField DataField="description" HeaderText="Description" SortExpression="description"></asp:BoundField>
                                                                                            <asp:BoundField DataField="trainer" HeaderText="Trainer" SortExpression="trainer"></asp:BoundField>
                                                                                            
                                                                                            <asp:TemplateField>

                                                                                                <ItemTemplate>
                                                                                                    <a class="link05" href="updatetrainingdevelopment.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>"
                                                                                                        target="_self">Edit</a>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>

                                                                                    </asp:GridView>
                                                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        SelectCommand="SELECT [id], [title], [description], [trainer] FROM [TblTrainingDevelopment]"
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
