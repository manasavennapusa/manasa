<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="trainingtypemaster.aspx.cs" Inherits="training_trainingtypemaster" %>

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
                                <h2>Training Type Master</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Master

                 
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                        <tbody>
                                            <tr>
                                                <td width="22%">Training Type Code:</td>
                                                <td width="25%">
                                                      <input type="text"
                                                    id="txt_trainingid"
                                                    runat="server"
                                                    class="span5" />
                                                    <%-- <asp:TextBox ID="txt_trainingid" runat="server" CssClass="span4" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>--%>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Sub Department Name" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_branch_name"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z&_\s\-]+$" ToolTip="Enter only alphabets and space"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td width="22%">Description:
                                                </td>
                                                <td width="25%">
                                                    <input type="text"
                                                    id="txt_training_name"
                                                    runat="server"
                                                    class="span5" />
                                                </td>
                                            </tr>

                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>




                        <%--***************************************************************  Changes for column***********************************************--%>



                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_save" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btn_save_Click"
                                ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btn_clear_Click"
                                                     ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="btn btn-primary" OnClick="btn_back_Click"
                                                     ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                  
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
