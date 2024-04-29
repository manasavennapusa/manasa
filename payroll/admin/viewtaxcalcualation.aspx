<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtaxcalcualation.aspx.cs" Inherits="payroll_admin_viewtaxcalcualation" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>
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
                <div>
                    <div class="dashboard-wrapper" style="margin-left: 0px;">
                        <div class="main-container">
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">

                                        <div class="widget-body">
                                            <fieldset>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" height="463px" style="width: 100%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <%--  <td width="3%" style="height: 16px">
                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>--%>
                                                                                <%--<td class="txt01" style="height: 16px">View Employee Declaration
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
                                                                                            <td width="27%" class="txt02">Tax Calculation Details
                                                                                            </td>
                                                                                            <td width="73%" align="right" class="txt-red">
                                                                                                <span id="message" runat="server"></span>&nbsp;
                                                                                            </td>
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
                                                                                            <td valign="top">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td valign="top" style="width: 100%">
                                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                                <tr>
                                                                                                                    <td valign="top" class="txt02" style="height: 20px">
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                                <tr>
                                                                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                                        <%-- <div style="overflow-x: scroll; overflow-y: hidden; width: 100%; position: absolute;">--%>
                                                                                                                        <div class="widget-content">
                                                                                                                            <asp:GridView ID="griddetail" runat="server"
                                                                                                                                DataKeyNames="empcode" AutoGenerateColumns="False"
                                                                                                                                AllowPaging="True" PageSize="80" EmptyDataText="No such declaration found !"
                                                                                                                                CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                                                                <Columns>
                                                                                                                                    <asp:TemplateField HeaderText="Emp Code">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Employee Name">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Branch">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Department">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Financial Year">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("financialyr") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField HeaderText="Status">
                                                                                                                                        <ItemTemplate>
                                                                                                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind ("dstatus") %>'></asp:Label>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                    <asp:TemplateField>

                                                                                                                                        <ItemTemplate>
                                                                                                                                            <%#linkviewdedit(DataBinder.Eval(Container.DataItem, "empcode").ToString(), DataBinder.Eval(Container.DataItem, "visibility").ToString())%>
                                                                                                                                            <%--<a class="link05"   href="viewdeclarationdetail.aspx?ref_no=<%#DataBinder.Eval(Container.DataItem, "ref_no")%>" target="_self">View</a> |  
                                                                                                               <a class="link05"  href="editdeclarationdetail.aspx?ref_no=<%#DataBinder.Eval(Container.DataItem, "ref_no")%>" target="_self">Edit</a>  
                                                                                                                                            --%>
                                                                                                                                        </ItemTemplate>
                                                                                                                                    </asp:TemplateField>
                                                                                                                                </Columns>

                                                                                                                            </asp:GridView>
                                                                                                                        </div>

                                                                                                                        <%-- </div>--%>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                          
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
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
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
