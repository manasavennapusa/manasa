<%@ Page Language="C#" AutoEventWireup="true" CodeFile="departmenttypeview.aspx.cs" Inherits="admin_departmenttypeview" Title="SmartDrive Labs Technologies India Pvt. Ltd. : Departmenttype View" %>

<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2> Department Type </h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="Grid_Emp" 
                                        runat="server"                                       
                                        DataKeyNames="dept_type_id" 
                                         OnRowDeleting="Grid_Emp_RowDeleting"
                                        AutoGenerateColumns="False" 
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                        OnPreRender="Grid_Emp_PreRender">

                                        <Columns>
                                            <%--<asp:BoundField DataField="" HeaderText="WorkLocation" ></asp:BoundField>--%>
                                            <asp:BoundField DataField="dept_type_id" HeaderText="Department Type Id" ></asp:BoundField>
                                            <asp:BoundField DataField="branch_name" HeaderText="Department  Name" SortExpression="branch_name"></asp:BoundField>
                                            <asp:BoundField DataField="dept_type_name" HeaderText="Department Type Name"  SortExpression="department_name"></asp:BoundField> <%--ReadOnly="True"--%>
                                            <%--<asp:BoundField DataField="department_code" HeaderText="Department Code" SortExpression="department_code"></asp:BoundField>--%>

                                            <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Edit">
                                                <ItemTemplate>
                                                    <a href="editdepartmenttype.aspx?dept_type_id=<%#DataBinder.Eval(Container.DataItem, "dept_type_id") %>" target="_self" class="link05"><img src="images/edit.png" width="15" height="15" border="0"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
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
               <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_internate_department_type.dept_type_id,tbl_internate_department_type.dept_type_name,tbl_intranet_branch_detail.branch_name FROM tbl_intranet_branch_detail INNER JOIN tbl_internate_department_type ON tbl_intranet_branch_detail.Branch_Id = tbl_internate_department_type.branch_id"
                    DeleteCommand="DELETE FROM tbl_internate_department_type WHERE dept_type_id = @dept_type_id" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>--%>

            </div>
            <span id="message" runat="server"></span>
        </div>



        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Emp').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>



        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>



    </form>
</body>
</html>

