<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="picktrainingcode.aspx.cs" Inherits="training_picktrainingcode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script type="text/javascript" src="../plugins/datatables/responsive/datatables.responsive.js"></script>
    <script type="text/javascript" src="../plugins/datatables/jquery.dataTables.min.js"></script>
    <script src="../js/html5-trunk.js"></script>
    <script type="text/javascript">

        function returnempcode(val) {

            // hardcoded value used to minimize the code. 

            // ControlID can instead be passed as query string to the popup window
            window.opener.document.getElementById("txt_approver").value = val;

            //   window.opener.document.getElementById("hidd_empcode").value = val; 
            window.opener.focus();
            window.close();

        }

    </script>
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
                        <h2>Pick Trining Code	</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Work Location View
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgrid" runat="server" DataKeyNames="training_type_id"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" EmptyDataText="No such employee exists !" OnPageIndexChanging="empgrid_PageIndexChanging" OnPreRender="empgrid_PreRender">
                                        <Columns>

                                            <asp:TemplateField HeaderText="Training Code" HeaderStyle-Width="24%">
                                                <ItemTemplate>
                                                    <a href="javascript:returnempcode('<%# DataBinder.Eval(Container.DataItem, "training_type_id") %>')" class="link05"><%# DataBinder.Eval(Container.DataItem, "training_type_id") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="26%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField HeaderText="Department" HeaderStyle-Width="24%">

                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                        </Columns>

                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <span id="message" runat="server"></span>
                <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                        ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                        DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>--%>
            </div>

        </div>

    </form>

</body>

</html>



