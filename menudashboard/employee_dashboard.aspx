<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employee_dashboard.aspx.cs" Inherits="menudashboard_employee_dashboard" %>
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

    <style>
        body {
            overflow: hidden;
        }

        .imageround {
            width: 50px;
            height: 50px;
            border-radius: 50%;
        }
    </style>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 279,
                tooltip: { textStyle: { fontSize: 11 } },
                fontSize: 12,
                color: 'black',
                isStacked: true,
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "employee_dashboard.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#departmentchart")[0]);
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
                tooltip: { textStyle: { fontSize: 11 } },
                fontSize: 12,
                color: 'black',
                isStacked: true,
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "employee_dashboard.aspx/GetLocChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#locationchart")[0]);
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
        google.charts.load('current', { packages: ['corechart', 'line'] });

        var dataAttrnJan = parseFloat('<%= Session["TotalAttrnJan"] %>');
        var dataAttrnFeb = parseFloat('<%= Session["TotalAttrnFeb"] %>');
        var dataAttrnMar = parseFloat('<%= Session["TotalAttrnMar"] %>');
        var dataAttrnApr = parseFloat('<%= Session["TotalAttrnApr"] %>');
        var dataAttrnMay = parseFloat('<%= Session["TotalAttrnMay"] %>');
        var dataAttrnJun = parseFloat('<%= Session["TotalAttrnJun"] %>');
        var dataAttrnJul = parseFloat('<%= Session["TotalAttrnJul"] %>');
        var dataAttrnAug = parseFloat('<%= Session["TotalAttrnAug"] %>');
        var dataAttrnSep = parseFloat('<%= Session["TotalAttrnSep"] %>');
        var dataAttrnOct = parseFloat('<%= Session["TotalAttrnOct"] %>');
        var dataAttrnNov = parseFloat('<%= Session["TotalAttrnNov"] %>');
        var dataAttrnDec = parseFloat('<%= Session["TotalAttrnDec"] %>');

        function drawChart() {
            // Define the chart to be drawn.
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'AttritionRate');
            data.addRows([
                 ['Jan', dataAttrnJan],
                 ['Feb', dataAttrnFeb],
                 ['Mar', dataAttrnMar],
                 ['Apr', dataAttrnApr],
                 ['May', dataAttrnMay],
                 ['Jun', dataAttrnJun],
                 ['Jul', dataAttrnJul],
                 ['Aug', dataAttrnAug],
                 ['Sep', dataAttrnSep],
                 ['Oct', dataAttrnOct],
                 ['Nov', dataAttrnNov],
                 ['Dec', dataAttrnDec]
            ]);

            // Set chart options
            var options = {
                //'title': 'Attrition Rate',
                hAxis: {
                    title: 'Month',
                    titleTextStyle: { color: 'green', fontSize: '13' }
                },
                //vAxis: {
                //    title: 'HeadCount'
                //},
                'width': 480,
                'height': 270,
                fontSize: '12',
                pointsVisible: true, animation: { duration: 250 }
            };

            // Instantiate and draw the chart.
            var chart = new google.visualization.LineChart(document.getElementById('container'));
            //chart.draw(data, options);
            var index = 0;
            var chartData = [dataAttrnJan, dataAttrnFeb, dataAttrnMar, dataAttrnApr, dataAttrnMay, dataAttrnJun, dataAttrnJul, dataAttrnAug, dataAttrnSep, dataAttrnOct, dataAttrnNov, dataAttrnDec]
            var drawChart = function () {
                console.log('drawChart index ' + index);
                if (index < chartData.length) {
                    data.setValue(index, 1, chartData[index++]);
                    chart.draw(data, options);
                }
            }

            google.visualization.events.addListener(chart, 'animationfinish', drawChart);
            chart.draw(data, options);
            drawChart();
        }
        google.charts.setOnLoadCallback(drawChart);
    </script>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <section class="services-area-6 bg-gray text-center p-25px employee_dashboard_height">
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
                            <div class="col-lg-5 col-md-5 transition-3 text-center align-middle" style="display: none">
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

            <div class="row" id="row_dept_loc_headcount" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                 <b>Departmentwise Headcount Distribution</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="departmentchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 transition-3">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Locationwise Headcount Distribution</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="locationchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_monthlyjoin_attrition" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp text-left" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-5">
                                    <img src="../images/chart_icon/areachart.png" />
                                </td>
                                <td class="width-95 align-bottom pt-5px">&nbsp;
                                    <b>Monthly Joinees And Resignees</b>
                                </td>
                            </tr>
                        </table>
                        <div>
                            <asp:Literal ID="lt" runat="server"></asp:Literal>
                        </div>
                        <div id="chart_div"></div>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp text-left" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-5">
                                    <img src="../images/chart_icon/linechart_2.png" />
                                </td>
                                <td class="width-95 align-bottom pt-5px">&nbsp;
                                    <b>Attrition Rate</b>
                                </td>
                            </tr>
                        </table>
                        <div id="container"></div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/table_icon.png" style="width: 18px; height: 18px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                 <b>My Reportee</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="dt_example" class="example_alt_pagination">
                            <asp:GridView ID="grdreportees" runat="server" AllowSorting="true" AutoGenerateColumns="False" BorderWidth="0" HeaderStyle-Font-Size="14px" RowStyle-Font-Size="13px"
                                EmptyDataText="No Reportees Present" CssClass="table table-striped table-bordered table-hover table-responsive" OnPreRender="grdreportees_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Image ID="Image" runat="server" ImageUrl='<%# "../upload/photo/" + Eval("photo")  %>' CssClass="imageround" onerror="this.src='../upload/photo/image.png'" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmpCode" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldesg" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/admin/TeamMember_empDetail.aspx?empcode={0}"
                                        NavigateUrl="~/admin/TeamMember_empDetail.aspx" Text="&lt;img src='../images/view.png' /&gt;" HeaderText="View" HeaderStyle-Width="15%"></asp:HyperLinkField>
                                </Columns>
                            </asp:GridView>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/table_icon.png" style="width: 18px; height: 18px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                 <b>My Indirect Reportee</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="dt_example1" class="example_alt_pagination">
                            <asp:GridView ID="grdindirectreportees" runat="server" AutoGenerateColumns="False" BorderWidth="0" HeaderStyle-Font-Size="14px" RowStyle-Font-Size="13px"
                                EmptyDataText="No Indirect Reportees Present" CssClass="table table-striped table-bordered table-hover table-responsive" OnPreRender="grdindirectreportees_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Photo" HeaderStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../upload/photo/" + Eval("photo")  %>' CssClass="imageround" onerror="this.src='../upload/photo/image.png'" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="EmpCode" HeaderStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name" HeaderStyle-Width="25%">
                                        <ItemTemplate>
                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="lbldesg" runat="server" Text='<%#Eval("designation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/admin/TeamMember_empDetail.aspx?empcode={0}"
                                        NavigateUrl="~/admin/TeamMember_empDetail.aspx" Text="&lt;img src='../images/view.png' /&gt;" HeaderText="View" HeaderStyle-Width="15%"></asp:HyperLinkField>
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
                $('#grdreportees').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdindirectreportees').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

    </form>
</body>
</html>
