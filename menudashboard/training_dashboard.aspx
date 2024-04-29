<%@ Page Language="C#" AutoEventWireup="true" CodeFile="training_dashboard.aspx.cs" Inherits="menudashboard_training_dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
                                                                     
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <link href="../css/dashboardcss/animate.css" rel="stylesheet" />
    <link href="../css/dashboardcss/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/et-line-icons.css" rel="stylesheet" />
    <link href="../css/dashboardcss/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/iconmonstr-iconic-font.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/lity.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/main.css" rel="stylesheet" />
    <link href="../css/dashboardcss/owl.carousel.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/owl.theme.default.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/responsive.css" rel="stylesheet" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 279,
                legend: { position: 'top' },
                isStacked: true,
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "training_dashboard.aspx/TrainingTypeChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#trainingtype")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 279,
                legend: { position: 'top' },
                isStacked: true,
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "training_dashboard.aspx/TrainingTypeEmployeeChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#trainingempchart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 880,
                height: 300,
                legend: { position: 'top' },
                isStacked: true,
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "training_dashboard.aspx/MonthwiseTrainingChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#monthwisetrainingemp")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $RoyalBlue = "#4169E1";

        var jan = parseInt('<%= Session["january"] %>');
        var feb = parseInt('<%= Session["february"] %>');
        var mar = parseInt('<%= Session["march"] %>');
        var apr = parseInt('<%= Session["april"] %>');
        var may = parseInt('<%= Session["may"] %>');
        var jun = parseInt('<%= Session["june"] %>');
        var jul = parseInt('<%= Session["july"] %>');
        var aug = parseInt('<%= Session["august"] %>');
        var sept = parseInt('<%= Session["september"] %>');
        var oct = parseInt('<%= Session["october"] %>');
        var nov = parseInt('<%= Session["november"] %>');
        var dec = parseInt('<%= Session["december"] %>');

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Month', 'Total'],
              ['January', jan],
              ['February', feb],
              ['March', mar],
              ['April', apr],
              ['May', may],
              ['June', jun],
              ['July', jul],
              ['August', aug],
              ['September', sept],
              ['October', oct],
              ['November', nov],
              ['December', dec],
            ]);

            var options = {
                width: '520',
                height: '290',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue],
                tooltip: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'top'
                },
                animation: {
                    duration: 1500,
                    easing: 'out',
                    startup: true
                },
                hAxis: {
                    slantedText: true,
                    slantedTextAngle: 60 // here you can even use 180
                },
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('AsFacultytrainingemp'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $RoyalBlue = "#4169E1";

        var MyReporteejan = parseInt('<%= Session["MyReporteejanuary"] %>');
        var MyReporteefeb = parseInt('<%= Session["MyReporteefebruary"] %>');
        var MyReporteemar = parseInt('<%= Session["MyReporteemarch"] %>');
        var MyReporteeapr = parseInt('<%= Session["MyReporteeapril"] %>');
        var MyReporteemay = parseInt('<%= Session["MyReporteemay"] %>');
        var MyReporteejun = parseInt('<%= Session["MyReporteejune"] %>');
        var MyReporteejul = parseInt('<%= Session["MyReporteejuly"] %>');
        var MyReporteeaug = parseInt('<%= Session["MyReporteeaugust"] %>');
        var MyReporteesept = parseInt('<%= Session["MyReporteeseptember"] %>');
        var MyReporteeoct = parseInt('<%= Session["MyReporteeoctober"] %>');
        var MyReporteenov = parseInt('<%= Session["MyReporteenovember"] %>');
        var MyReporteedec = parseInt('<%= Session["MyReporteedecember"] %>');

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Month', 'Total'],
              ['January', MyReporteejan],
              ['February', MyReporteefeb],
              ['March', MyReporteemar],
              ['April', MyReporteeapr],
              ['May', MyReporteemay],
              ['June', MyReporteejun],
              ['July', MyReporteejul],
              ['August', MyReporteeaug],
              ['September', MyReporteesept],
              ['October', MyReporteeoct],
              ['November', MyReporteenov],
              ['December', MyReporteedec],
            ]);

            var options = {
                width: '520',
                height: '290',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue],
                tooltip: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'top'
                },
                animation: {
                    duration: 1500,
                    easing: 'out',
                    startup: true
                },
                hAxis: {
                    slantedText: true,
                    slantedTextAngle: 60 // here you can even use 180
                },
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myreporteetrainings'));
            chart.draw(data, options);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px Training_dashboard_height">
            <div class="row">
                <div class="leadership-area col-lg-12 col-md-12 transition-3 wow fadeInUp pb-20px  o-hidden" data-wow-delay="0.35s">
                    <div class="wow fadeInUp" data-wow-delay="0.3s">
                        <div class="row">
                            <div class="col-lg-1 col-md-1 transition-3 text-center align-middle">
                                <div class="width-130px height-85 bg-fff p-7px radius-10 mt-10px max-min-height-125px">
                                    <% if (Session["PerEmpPhoto"] != null) Response.Write(Session["PerEmpPhoto"].ToString()); else Response.Redirect("~/notlogged.aspx"); %>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 transition-3 text-left">
                                <p class="ml-40px pl-20px pt-10px">
                                    <span class="black-paragraph fw-800 fs-15" style="text-shadow: 2px 2px 2px skyblue;">Welcome&nbsp;<% if (Session["EmployeeRoleName"] != null) Response.Write(Session["EmployeeRoleName"].ToString()); %>
                                    </span>
                                    <br />
                                    <span class="black-paragraph fw-600 fs-14">
                                        <% if (Session["empcode"] != null) Response.Write(Session["empcode"].ToString()); %> 
                                          -
                                        <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %>
                                    </span>
                                    <br />
                                    <a href="../ResetPassword.aspx" title="Reset Password" target="ifrmSDL" class="fs-12">Change Password</a><br />
                                    <a href="../viewProfile.aspx" title="View Profile" target="ifrmSDL" class="fs-12">My Profile</a><br />
                                    <a href="../notlogged.aspx?logout=1" title="Logout" class="RedLinkButton">Log Out</a>
                                </p>
                            </div>
                            <div class="col-lg-5 col-md-5 transition-3 text-center align-middle" style="display:none">
                                <div class="container about-area-3 mt-20px">
                                    <div class="row">
                                        <div class="col-md-4" id="row_EarnedLev_1" runat="server">
                                            <div class="numberCircle opacity-7" id="row_circle_EarnedLev_1" runat="server">
                                                <asp:Label ID="lbl_EL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_ProbLev_1" runat="server" visible="false">
                                            <div class="numberCircle1 opacity-7">
                                                <asp:Label ID="lbl_ProbL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_ML_1" runat="server" visible="false">
                                            <div class="numberCircle2 opacity-7">
                                                <asp:Label ID="lbl_ML" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_PL_1" runat="server" visible="false">
                                            <div class="numberCircle2 opacity-7">
                                                <asp:Label ID="lbl_PL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-left" id="row_EarnedLev_2" runat="server">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">
                                                <asp:Label ID="lbl_earned_leave_name" runat="server">Earned Leave</asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_ProbLev_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Probationary Leave</div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_ML_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Maternity Leave</div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_PL_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Paternity Leave</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_2" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                             <b>Training Type</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="trainingtype"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                              <b>Training Type Employees</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="trainingempchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_3" runat="server" visible="false">
                <div class="col-lg-12 col-md-12">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-50 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" style="width: 30px;" />
                                            </td>
                                            <td class="width-45 align-bottom pt-5px">
                                                <b>Monthwise Training Employees</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100">
                                    <div id="monthwisetrainingemp"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-50 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" style="width: 30px;" />
                                            </td>
                                            <td class="width-45 align-bottom pt-5px">&nbsp;
                                                <b>As Faculty Trainings</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100">
                                    <div id="AsFacultytrainingemp"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-50 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" style="width: 30px;" />
                                            </td>
                                            <td class="width-45 align-bottom pt-5px">&nbsp;
                                                <b>My Reportee Trainings</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100">
                                    <div id="myreporteetrainings"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_5" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-3">
                                                <img src="../images/chart_icon/table_icon.png" style="width: 18px; height: 18px" />
                                            </td>
                                            <td class="width-97 align-bottom pt-5px">&nbsp;
                                                 <b>My Trainings</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="dt_example" class="example_alt_pagination">
                            <asp:GridView ID="grdmytrainings" runat="server" AutoGenerateColumns="False" BorderWidth="0" HeaderStyle-Font-Size="14px" RowStyle-Font-Size="13px"
                                EmptyDataText="No Indirect Reportees Present" CssClass="table table-striped table-bordered table-hover table-responsive datatable" OnPreRender="grdmytrainings_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Training Code" HeaderStyle-Width="5%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltrainingcode" runat="server" Text='<%#Eval("training_code")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltrainingname" runat="server" Text='<%#Eval("training_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="From Date" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfromdate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="To Date" HeaderStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbltodate" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Module Name" HeaderStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblmodulename" runat="server" Text='<%#Eval("module_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department Name" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldeptname" runat="server" Text='<%#Eval("department_name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Faculty" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblfaculty" runat="server" Text='<%#Eval("Faculty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>

        </section>

        <script type="text/javascript" src="../js/jquery.min.js"></script>
        <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdmytrainings').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
