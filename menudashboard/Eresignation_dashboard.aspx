<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Eresignation_dashboard.aspx.cs" Inherits="menudashboard_Eresignation_dashboard" %>
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
                pieHole: 0.4,
                width: 480,
                height: 279,
                pieStartAngle: 0
            };
            $.ajax({
                type: "POST",
                url: "Eresignation_dashboard.aspx/ExitStatusChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.PieChart($("#exitstatus")[0]);
                    google.visualization.events.addListener(chart, 'ready', function () {
                        if (options.pieStartAngle < 60) {
                            options.pieStartAngle++;
                            setTimeout(function () {
                                chart.draw(data, options);
                            }, 1);
                        }
                    });
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
         var $border_color = "#efefef";
         var $grid_color = "#ddd";
         var $default_black = "#666";
         var $default_grey = "#ccc";
         var $primary_color = "#428bca";
         var $go_green = "#93caa3";
         var $jet_blue = "#70aacf";
         var $lemon_yellow = "#ffe38a";
         var $nagpur_orange = "#fc965f";
         var $orangered = "#db4211";
         var $ruby_red = "#fa9c9b";
         var $FireBrick = "#B22222";
         var $DarkOrange = "#FF8C00";
         var $RoyalBlue = "#4169E1";

         var pendemp = parseInt('<%= Session["ExitPending"] %>');
        var apvremp = parseInt('<%= Session["ExitApproved"] %>');
         var rejemp = parseFloat('<%= Session["ExitRejected"] %>');

         function drawChart5() {
             var data = google.visualization.arrayToDataTable([
                 ['Status', 'Total'],
               ['Pending Exit Employee', pendemp],
               ['Approved Exit Employee', apvremp],
               ['Rejected Exit Employee', rejemp]

             ]);

             var options = {
                 width: '500',
                 height: '220',
                 backgroundColor: 'transparent',
                 colors: [$RoyalBlue, $RoyalBlue, $RoyalBlue, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
                 tooltip: {
                     textStyle: {
                         color: '#666666',
                         fontSize: 11
                     },
                     showColorCode: true
                 },
                 legend: {
                     textStyle: {
                         color: 'black',
                         fontSize: 12
                     }
                 },
                 chartArea: {
                     left: 60,
                     top: 10,
                     height: '80%'
                 },
                 animation: {
                     duration: 1000,
                     easing: 'out',
                     startup: true
                 }
             };

             var chart = new google.visualization.ColumnChart(document.getElementById('allexitempchart'));
             chart.draw(data, options);
         }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $RoyalBlue = "#4169E1";

        var ExitApplied = parseInt('<%= Session["ExitAppliedEmp"] %>');
        var ExitPending = parseInt('<%= Session["ExitPendingEmp"] %>');
        var ExitApproved = parseInt('<%= Session["ExitApprovedEmp"] %>');
        var ExitRejected = parseInt('<%= Session["ExitRejectedEmp"] %>');

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Status', 'Total'],
              ['Exit Applied', ExitApplied],
              ['Exit Pending', ExitPending],
              ['Exit Approved', ExitApproved],
              ['Exit Rejected', ExitRejected]
            ]);

            var options = {
                width: '780',
                height: '279',
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
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myreptexitstatus'));
            chart.draw(data, options);
        }
    </script>

    <style>
        body {
            overflow: hidden;
        }

        ul {
            font-family: 'Times New Roman';
        }

        ol {
            font-family: 'Times New Roman';
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px Resignation_Exit_dashboard_height">
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
                                                <img src="../images/chart_icon/piechart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                             <b>Exit Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="exitstatus"></div>
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
                                              <b>Exit Employees</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="allexitempchart" runat="server" style="height: 279px"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-10 col-md-10">
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
                                                <b>My Reportee Exit Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100">
                                    <div id="myreptexitstatus"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row mb-20px" id="row_5" runat="server" visible="false">
                <div class="col-lg-12 col-md-12">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <%-- <b style="font-family: 'Times New Roman'">Employee:</b>
                        <ul>
                            <li class="fs-17">Employee will initiate the resignation approval form.
                            </li>
                            <li class="fs-17">For confirmed employees notice period will be 60 days, and unconfirmed Employees notice period will be 15 days. 
                            </li>
                            <li class="fs-17">"Default last working date" (LWD) will be calculated by adding "notice period" to "form initiation date", and displayed.
                            </li>
                            <li class="fs-17">Comment box will be provided for the employee.
                            </li>
                            <li class="fs-17">Employee will also have the option to specify "preferred last working date". – (This will be only in comments and is not final date).
                            </li>
                            <li class="fs-17">After filling above details, form will be forwarded to Line Manager.
                            </li>
                            <li class="fs-17">And an auto generated email will also go to Business head & HR
                            </li>
                        </ul>
                        <b style="font-family: 'Times New Roman'">Line Manager:</b>
                        <ul>
                            <li class="fs-17">Line Manager will approve or reject the request form.
                            </li>
                            <li class="fs-17">One to one discussion will be done with employee and same will be displayed.
                            </li>
                            <li class="fs-17">Comment box will be provided for the Line Manager.
                            </li>
                            <li class="fs-17">If the form is rejected by line manager it will come back to employee where he can cancel or reinitiate the form. 
                            </li>
                            <li class="fs-17">If it’s reinitiated by employee, the form initiation date won’t change and remain same as that of first initiation. 
                            </li>
                            <li class="fs-17">If the line manager approves the form after filling all details, the form will be forwarded to Business Head.
                            </li>
                        </ul>
                        <b style="font-family: 'Times New Roman'">Business Head:</b>
                        <ul>
                            <li class="fs-17">Business head will receive the form and approves or rejects it.
                            </li>
                            <li class="fs-17">If it’s rejected the form will go to employee where he can cancel or reinitiate.
                            </li>
                            <li class="fs-17">BU will have the option to edit the last working day.
                            </li>
                            <li class="fs-17">Only BU head has a option to tick on the notice period recovery or waived off if there is a short fall in the notice period. This flow will be moved to Exit process and F&F will be done based on this.
                            </li>
                            <li class="fs-17">If the form is approved, it will be forwarded to HR.
                            </li>
                        </ul>
                        <b style="font-family: 'Times New Roman'">HR:</b>
                        <ul>
                            <li class="fs-17">Once Form comes to HR, it will be in the "pending exit process". 
                            </li>
                            <li class="fs-17">HR will get Mail Alert 2 days before LWD to initiate Exit process.
                            </li>
                            <li class="fs-17">HR will initiate it for Exit process, two days before the “confirmed last working date” (LWD).Confirmed LWD which is mentioned by BU head.
                            </li>
                            <li class="fs-17">When it is initialized each exit clearance certificate will go to respective Department. These are the following exit Clearance certificate that should be verified and validated in the tool( BASED ON THE EXIT FORM FORMAT provided)<br />
                                &nbsp;&nbsp;&nbsp;-	Departmental Clearance<br />
                                &nbsp;&nbsp;&nbsp;-	General administration Clearance<br />
                                &nbsp;&nbsp;&nbsp;-	Accounts Department Clearance<br />
                                &nbsp;&nbsp;&nbsp;-	Network Administration Clearance<br />

                            </li>
                            <li class="fs-17">All the roles involved in the Exit flow process are connected to single form all the time, HR will verify the status of the form and give the direction to the employee if there is any clearance in pending.
                            </li>
                            <li class="fs-17">Mean while above clearance Certificates is verified and validated. Employee will fill Exit questionnaire form
                            </li>
                            <li class="fs-17">(In the tool). And the Following attachment will be given for download for employee to fill the forms, where applicable
                            </li>
                            <li class="fs-17">Checklist popup and attachment.<br />
                                &nbsp;&nbsp;&nbsp;-	PF Settlement<br />
                                &nbsp;&nbsp;&nbsp;-	Pension Settlement<br />
                                &nbsp;&nbsp;&nbsp;-	Gratuity<br />
                                &nbsp;&nbsp;&nbsp;-	SAF<br />
                            </li>
                            <li class="fs-17">Finally the HR will get all the validation details. And HR will Update the Full and Final Settlement Status and give the signoff. – Note HR should not be able to give Sign off before all departments have signed off.
                            </li>
                            <li class="fs-17">Once HR gives sign off the reliving letter is generated which can be issued to employee   – if reliving letter is not generated, the status of this letter to show pending.
                            </li>
                            <li class="fs-17">After the sign off from HR, The ESS for that particular Employee will be removed and Employee details will be moved to Resigned-Employees list in the EDB.
                            </li>
                        </ul>
                        <b style="font-family: 'Times New Roman'">Clearance certificates:</b>
                        <ol>
                            <li class="fs-17">Each department will only be able to view and edit their respective tabs.
                            </li>
                            <li class="fs-17">HR will be able to view all the tabs. And edit only
                                <br />
                                &nbsp;&nbsp;&nbsp;- User Account Deletion Request.<br />
                                &nbsp;&nbsp;&nbsp;- Human Resource Department Clearance.<br />

                            </li>
                            <li class="fs-17">Network Administration Department can view – User Account Deletion Request.
                                 View - Blue color tab represents in pending, Green tab represents approved, and Red tab represents not Cleared.
                            </li>
                        </ol>
                        <b style="font-family: 'Times New Roman'">Note:</b>
                        <ol>
                            <li class="fs-17">Adding Notice period for each individual employee should be provided in the Masters, because notice period may vary for each employee.
                            </li>
                            <li class="fs-17">"Settlement form" attachment should come as a pop-up to the Employee to download.
                            </li>
                            <li class="fs-17">Date of Clearance for each clearance form will be auto Generated.
                            </li>
                            <li class="fs-17">Attachment download should come as pop-up for employee.
                            </li>
                            <li class="fs-17">HR Should get mail alert 2 days before LWD of the employee.
                            </li>
                        </ol>--%>
                        <img src="../images/exitworkflow.jpg" style="width: 1000px; height: 700px" />
                    </div>
                </div>
            </div>

            <%-- <div class="row">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        E-RESIGNATION
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        E-RESIGNATION
                    </div>
                </div>
            </div>--%>
        </section>
    </form>
</body>
</html>
