﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickemployee.aspx.cs" Inherits="leave_pickemployee" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">

        function returnempcode(val) {

            // hardcoded value used to minimize the code. 

            // ControlID can instead be passed as query string to the popup window
            var role = GetParameterValues('role');
            //  alert(role);
            if (role == "13")
                window.opener.document.getElementById("txtreportmanager").value = val;
            else if (role == "14")
                window.opener.document.getElementById("txtbusinesshead").value = val;
            else if (role == "11")
                window.opener.document.getElementById("txtfncmang").value = val;
            else if (role == "12")
                window.opener.document.getElementById("txtadmin").value = val;
            else if (role == "9")
                window.opener.document.getElementById("txthr").value = val;
            else if (role == "15")
                window.opener.document.getElementById("txthrd").value = val;
            else if (role == "10")
                window.opener.document.getElementById("txtmng").value = val;
            else if (role == "50")
                window.opener.document.getElementById("txtdottedlinemanager").value = val;
            else if (role == "51")
                window.opener.document.getElementById("txthrcb").value = val;
            //   window.opener.document.getElementById("hidd_empcode").value = val; 
            window.opener.focus();
            window.close();
        }
        function GetParameterValues(param) {
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver List
                                </div>
                            </div>
                            <div style="padding: 15px 10px 10px 10px">
                                <table style="width: 30%;" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td style="width: 50%;"><b>Work Location</b>
                                        </td>
                                        <td style="width: 50%;">
                                            <asp:DropDownList ID="ddl_branch" runat="server" CssClass="span12" OnDataBound="ddl_branch_DataBound"
                                                DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource
                                                ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgrid" runat="server" DataKeyNames="empcode"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" EmptyDataText="No such employee exists !" OnRowEditing="empgrid_RowEditing" OnPageIndexChanging="empgrid_PageIndexChanging" OnPreRender="empgrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="24%">
                                                <ItemTemplate>
                                                    <a style="text-decoration: underline;color:#4ca3bb" href="javascript:returnempcode('<%# DataBinder.Eval(Container.DataItem, "empcode") %>'+'>'+'<%# DataBinder.Eval(Container.DataItem, "name") %>' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "empcode") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" HeaderStyle-Width="24%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Role">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("role") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
