<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="trainingprogrammes.aspx.cs" Inherits="training_trainingprogrammes" %>

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
                                <h2>Training Programs</h2>
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
                                            <asp:GridView ID="Grid_trainingprogrammes" runat="server"  AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="Grid_trainingprogrammes_PreRender">
                                                <PagerSettings PageButtonCount="100"></PagerSettings>
                                                <Columns>
                                                       <asp:BoundField DataField="id" HeaderText=" ID" ReadOnly="True" HeaderStyle-Width="5%"
                                                        SortExpression="companyname"></asp:BoundField>
                                                    <asp:BoundField DataField="training_code" HeaderText="Training Code" ReadOnly="True" HeaderStyle-Width="5%"
                                                        SortExpression="companyname"></asp:BoundField>
                                                    <asp:BoundField DataField="module_name" HeaderText="Module Name" ReadOnly="True" HeaderStyle-Width="15%"
                                                        SortExpression="companyname"></asp:BoundField>
                                                    <asp:BoundField DataField="bachcode" HeaderText="Batch Code" SortExpression="branch_name" HeaderStyle-Width="15%"></asp:BoundField>
                                                    <asp:BoundField DataField="training_name" HeaderText="Training Name" SortExpression="region"></asp:BoundField>
                                                    <asp:BoundField DataField="training_type" HeaderText="Training Type" ReadOnly="True" HeaderStyle-Width="15%"
                                                        SortExpression="branch_code"></asp:BoundField>
                                                   <%-- <asp:BoundField DataField="address" HeaderText="Shedule" ReadOnly="True" SortExpression="address"></asp:BoundField>--%>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <a href="edit_trainingprogrammes.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>"
                                                                target="_self" class="link05">Edit</a>
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



                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Training Name:
                                        </div>
                                    </div>
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Training Name:</label>
                                            <div class="controls">

                                                <asp:DropDownList ID="ddl_training_name" runat="server" OnSelectedIndexChanged="ddl_training_name_SelectedIndexChanged"></asp:DropDownList>

                                                <%--<asp:DropDownList ID="drp_comp_name" 
                                                      runat="server" 
                                                      CssClass="span10" 
                                                      DataSourceID="SqlDataSource1" 
                                                      DataTextField="companyname" 
                                                      DataValueField="companyid">
                                                  </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drp_comp_name"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [companyid], [companyname] FROM [tbl_intranet_companydetails]"></asp:SqlDataSource>--%>
                                            </div>

                                        </div>

                                    </fieldset>

                                </div>

                            </div>

                            <%-- ******************************Changed By Irshad***********************************--%>

                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Module Name:
                                        </div>
                                    </div>
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Training Short Name:</label>
                                            <div class="controls">
                                                <input type="text"
                                                    id="Text4"
                                                    runat="server"
                                                    class="span10"
                                                    onkeypress="return isChar_Number_slash()"
                                                    pattern="^[a-zA-Z0-9\s]+$"
                                                    title="Work Location Code" />
                                            </div>
                                        </div>
                                    </fieldset>

                                </div>

                            </div>
                        </div>
                        <%--***************************************************************  Changes for column***********************************************--%>



                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_select" runat="server" Text="Add New Progrmmes" CssClass="btn btn-primary" OnClick="btn_select_Click"
                                ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btn_deselect" runat="server" Text="Next" CssClass="btn btn-primary" OnClick="btn_deselect_Click"
                                                     ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 <asp:Button ID="btn_submit" runat="server" Text="Last" CssClass="btn btn-primary" OnClick="btn_submit_Click"
                                                     ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                   <input type="text"
                                                       id="Text1"
                                                       runat="server" />
                            <asp:Button ID="btn_back" runat="server" Text="Go" CssClass="btn btn-primary" OnClick="btn_back_Click" />
                        </div>



                        <span id="message" runat="server"></span>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                            DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>

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
