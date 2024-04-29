<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewbroadgroup.aspx.cs" Inherits="admin_viewbroadgroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" content="" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

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
                                <h2> Business Unit</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <span id="message1" runat="server" class="txt-red" enableviewstate="false"></span>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>  View
                                    
                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="gd_Broadgroup" DataKeyNames="id" runat="server" AutoGenerateColumns="False" OnPreRender="gd_Broadgroup_PreRender" OnRowDeleting="gd_Broadgroup_RowDeleting" CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Business Unit Id">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblentity" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Business Unit Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl2entity" runat="server" Text='<%# Eval("broadgroup_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                   
                                                 
                                                    
                                                    <asp:HyperLinkField HeaderText="Edit" Text="&lt;img src='images/edit.png'/&gt;" HeaderStyle-Width="20%" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/admin/editbroadgroup.aspx?Id={0}">
                                                        <ControlStyle CssClass="link05" Width="6%" />
                                                    </asp:HyperLinkField>
                                                         <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" OnClientClick="return confirm('Are you sure, you want to delete');"
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
                $('#gd_Broadgroup').dataTable({
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

                var parentmenu = $('#ddlParentMenu').val();
                var childmenu = $('#txtChildMenu').val();
                var filename = $('#txtFileName').val();
                var module = $('#ddlModule').val();

                var regParentMenu = document.getElementById('txtChildMenu').pattern;

                if (parentmenu == '0') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#ddlParentMenu').focus();
                    alert('Please select parent menu.');
                    return false;
                }
                if (childmenu == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtChildMenu').focus();
                    // alert('Please enter child menu name.');
                    return false;
                }

                if (!document.getElementById('txtChildMenu').value.match(regParentMenu)) {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtChildMenu').focus();
                    return false;
                }

                if (filename == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtFileName').focus();
                    //   alert('Please enter file name.');
                    return false;
                }
                if (module == '0') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#ddlModule').focus();
                    alert('Please select the module.');
                    return false;
                }

            }
        </script>
    </form>

</body>
</html>
