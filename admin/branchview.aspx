<%@ Page Language="C#" AutoEventWireup="true" CodeFile="branchview.aspx.cs" Inherits="Admin_company_empview"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Branch View" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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
    <link href="../css@vd-charts.css" rel="stylesheet">

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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Work Location </h2>
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
                                                DataKeyNames="branch_id" 
                                                OnRowDeleting="Grid_Emp_RowDeleting"
                                                AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" 
                                                OnPreRender="Grid_Emp_PreRender" >
                                                <PagerSettings PageButtonCount="100"></PagerSettings>
                                                <Columns>
                                                     <asp:BoundField DataField="Branch_Id" HeaderText="Branch ID" ReadOnly="True" HeaderStyle-Width="5%"
                                                        SortExpression="companyname"></asp:BoundField>
                                                    <asp:BoundField DataField="companyname" HeaderText="Company Name" ReadOnly="True" HeaderStyle-Width="15%"
                                                        SortExpression="companyname"></asp:BoundField>
                                                    <asp:BoundField DataField="branch_name" HeaderText="Work Location" SortExpression="branch_name" HeaderStyle-Width="12%"></asp:BoundField>
                                                    <asp:BoundField DataField="region" HeaderText="Region" SortExpression="region" HeaderStyle-Width="15%"></asp:BoundField>
                                                    <asp:BoundField DataField="branch_code" HeaderText="Work Location Code" ReadOnly="True" HeaderStyle-Width="12%"
                                                        SortExpression="branch_code"></asp:BoundField>
                                                    <asp:BoundField DataField="add1" HeaderText="Address" ReadOnly="True" SortExpression="address" HeaderStyle-Width="30%"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <a href="editbranch.aspx?branch_id=<%#DataBinder.Eval(Container.DataItem, "branch_id") %>"
                                                                target="_self" class="link05"><img src="images/edit.png" width="15" height="15" border="0"></a>
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

                        <span id="message" runat="server"></span>
                       <%-- <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                            DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>--%>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>




        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/moment.js" type="text/javascript"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js" type="text/javascript"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js" type="text/javascript"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js" type="text/javascript"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js" type="text/javascript"></script>
        <script src="../js/custom.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Emp').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>



        <script type="text/javascript">
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>

        <script type="text/javascript">
            function validate() {

                var module = $('#txtModule').val();
                var moduledesc = $('#txtModuleDesc').val();

                var regModuleName = document.getElementById('txtModuleName').pattern;
                var regModuleDesc = document.getElementById('txtModuleDesc').pattern;


                if (module == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (!document.getElementById('txtModuleName').value.match(regModuleName)) {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (moduledesc == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModuleDesc').focus();
                    return false;
                }

            };
        </script>
    </form>

</body>
</html>
