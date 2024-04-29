<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registeredcandidates.aspx.cs" Inherits="recruitment_registeredcandidates" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../icomoon/style.css" rel="stylesheet" />

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
                        <%--<h2><asp:Label ID="lblheader" runat="server"></asp:Label></h2>--%>
                        <h2>Candidate Archives Form</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>REGISTERED CANDIDATES--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example1" class="example_alt_pagination">
                                    <asp:GridView ID="grdCandidates" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                        EmptyDataText="No data Found." OnPreRender="grdCandidates_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Join Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                   <%-- Days--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>        
                                        <%--<asp:TemplateField HeaderText=" View">
                                                <ItemTemplate>
                                                   <%-- <a href="#myModal" role="button" class="btn btn-small btn-info" data-toggle="modal">
                                                    <a href='registeredcandidatedetails.aspx?id=<%# Eval("id") %>' class="link05">View</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             <asp:HyperLinkField DataNavigateUrlFields="id" HeaderText="View" DataNavigateUrlFormatString="registeredcandidatedetails.aspx?id={0}"
                                                NavigateUrl="registeredcandidatedetails.aspx" Text="&lt;img src='../images/view.png' /&gt;" >  <%--Text="&lt;img src='../images/view.png'/&gt;"--%>
                                                <ControlStyle CssClass="link05" />
                                                <HeaderStyle CssClass="" />
                                                <ItemStyle CssClass=""></ItemStyle>
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="widget-body">

                    <!-- Modal -->
                    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×</button>
                            <h4 id="myModalLabel">Modal header
                            </h4>
                        </div>
                        <div class="modal-body">
                            <p>
                                One fine body…
                            </p>
                        </div>
                        <div class="modal-footer">
                            <button class="btn" data-dismiss="modal" aria-hidden="true">
                                Close
                            </button>
                            <button class="btn btn-primary">
                                Save changes
                            </button>
                        </div>
                    </div>
                </div>

            </div>
        </div>

    </form>

    <script src="../js/analytics.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script src="../js/jquery.dataTables.js"></script>
       
      <script type="text/javascript">
          //Data Tables
          $(document).ready(function () {
              $('#grdCandidates').dataTable({
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
</body>
</html>
