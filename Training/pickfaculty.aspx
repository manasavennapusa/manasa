<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pickfaculty.aspx.cs" Inherits="Training_pickfaculty" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. : Candidate Details</title>
    <script type="text/javascript" language="javascript">

        function returncandidate(val)
        {
            // hardcoded value used to minimize the code.
            // ControlID can instead be passed as query string to the popup window
            var role = GetParameterValues('role');
            if (role == "10")
            {
                window.opener.document.getElementById("txt_faculty").value = val;
            }
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
           
                <div class="row-fluid" style="border:1px solid rgba(0, 0, 0, 0.10);">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="candidategrid" runat="server"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-responsive datatable" EmptyDataText="No such candidate exists !" OnPageIndexChanging="candidategrid_PageIndexChanging" OnPreRender="candidategrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Empcode">
                                                <ItemTemplate>
                                                    <a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "empcode") %>'+' - '+'<%# DataBinder.Eval(Container.DataItem, "empname") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "empcode") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("empname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="l5" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
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
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#candidategrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        
    </form>
</body>
</html>
