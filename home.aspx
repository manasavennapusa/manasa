<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="home" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet" />

    <!-- NVD graphs css -->
    <link href="css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="css/main.css" rel="stylesheet" />

    <style type="text/css">
        html {
            background-color: whitesmoke;
        }

        body {
            background-color: whitesmoke;
            user-select: none;
        }

        #main-nav ul li {
            padding: 10px 20px 50px 20px;
            margin-left: 20px;
            margin-top: 40px;
            width: 5%;
            margin-right: 1px;
            -webkit-border-radius: 2px 2px 0 0;
            -moz-border-radius: 2px 2px 0 0;
            border-radius: 50%;
            background: whitesmoke;
            -webkit-transition: All 0.2s ease;
            -moz-transition: All 0.2s ease;
            -ms-transition: All 0.2s ease;
            -o-transition: All 0.2s ease;
            transition: All 0.2s ease;
        }

            #main-nav ul li:hover {
                -webkit-transform: scale(1.1);
                transform: scale(1.1);
                width: 5%;
                background-color: #ffb501;
                /*padding: 5px 5px 35px 5px;*/
            }

        .RedLinkButton {
            background-color: #ff4b2b;
            padding: 1px 5px;
            border: 1px solid transparent;
            color: #fff;
            font-weight: 600;
            font-size: 14px;
            border-radius: 5px 5px;
            margin-top: 10px;
        }

            .RedLinkButton:hover {
                background-color: orangered;
                color: aliceblue;
                padding: 1px 5px;
                border: 1px solid transparent;
                text-decoration: none;
            }

        .topbar {
            /*overflow: hidden;
            position: fixed;
            top: 0;
            width: 100%;*/
            position: absolute;
            top: 0;
            width: 100%;
            display: block;
            transition: top 0.3s;
        }

        .bottombar {
            overflow: hidden;
            background-color: cornflowerblue;
            position: fixed;
            bottom: 0;
            width: 100%;
            height: 45px;
            font-family: Arial;
            text-align: center;
        }

            .bottombar p {
                color: #fff;
                font-size: 12px;
                font-weight: 800;
                margin-top: 15px;
            }

        .HomePhoto {
            width: 110px;
            max-height: 110px;
            background-color: #fff;
            padding: 7px 7px 7px 7px;
            border-radius: 20px;
            margin-left: 20px;
            border-radius: 50%;
            -webkit-transition: 0.5s ease;
            transition: 0.5s ease;
            margin-bottom: 10px;
        }

            .HomePhoto:hover {
                -webkit-transform: scale(1.1);
                transform: scale(1.1);
                background-color: #ffb501;
            }

        #mySidenav a {
            position: fixed;
            left: 60px;
            -webkit-transition: 0.5s ease;
            transition: 0.5s ease;
            width: 50px;
            height: 35px;
            text-decoration: none;
            font-size: 18px;
            color: white;
            border-radius: 50%;
            padding: 25px 10px 10px 10px;
            text-align: center;
        }

            #mySidenav a:hover {
                -webkit-transform: scale(1.1);
                transform: scale(1.1);
            }

        #GoHome {
            bottom: 50px;
            background-color: #4CAF50;
        }

        #divContainer {
            border: 1px solid transparent;
            width: 70px;
            height: 70px;
            cursor: move;
            float: left;
            border-radius: 50%;
            background-color: #4CAF50;
            text-align: center;
            position: fixed;
            bottom: 60px;
            left: 55px;
            user-select: none;
        }

        #divContainer_1 {
            border: 1px solid transparent;
            width: 70px;
            height: 70px;
            cursor: move;
            float: left;
            border-radius: 50%;
            background-color: #4CAF50;
            text-align: center;
            position: fixed;
            bottom: 60px;
            left: 55px;
            user-select: none;
        }
    </style>

    <script type="text/javascript">
        var prevScrollpos = window.pageYOffset;
        window.onscroll = function () {
            var currentScrollPos = window.pageYOffset;
            if (prevScrollpos > currentScrollPos) {
                document.getElementById("navbar").style.top = "0";
            } else {
                document.getElementById("navbar").style.top = "-50px";
            }
            prevScrollpos = currentScrollPos;
        }
    </script>

    <script type="text/javascript">
        function iframeLoaded() {
            var iFrameID = document.getElementById('ifrmSDL');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded1() {
            var iFrameID = document.getElementById('Iframe1');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded2() {
            var iFrameID = document.getElementById('Iframe2');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded3() {
            var iFrameID = document.getElementById('Iframe3');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded4() {
            var iFrameID = document.getElementById('Iframe4');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded5() {
            var iFrameID = document.getElementById('Iframe5');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded6() {
            var iFrameID = document.getElementById('Iframe6');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded7() {
            var iFrameID = document.getElementById('Iframe7');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded8() {
            var iFrameID = document.getElementById('Iframe8');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded9() {
            var iFrameID = document.getElementById('Iframe9');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded10() {
            var iFrameID = document.getElementById('Iframe10');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded11() {
            var iFrameID = document.getElementById('Iframe11');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded12() {
            var iFrameID = document.getElementById('Iframe12');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded13() {
            var iFrameID = document.getElementById('Iframe13');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded14() {
            var iFrameID = document.getElementById('Iframe14');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded15() {
            var iFrameID = document.getElementById('Iframe15');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoaded16() {
            var iFrameID = document.getElementById('Iframe16');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function tempframeLoaded() {
            var iFrameID = document.getElementById('ifrmtemp');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

        function iframeLoadedStartPage() {
            var iFrameID = document.getElementById('IframeStartPage');
            if (iFrameID) {
                iFrameID.height = "";
                iFrameID.height = iFrameID.contentWindow.document.body.scrollHeight + "px";
            }
        }

    </script>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/jquery-1.3.2.min.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="js/tiny-scrollbar.js"></script>
    <script type="text/javascript">
        $('#DIVtobehidden', window.parent.document).hide();
    </script>
    <script type="text/javascript">


        $(document).ready(function () {
            //Tiny Scrollbar
            $('#collapseTwo').tinyscrollbar();
            // BIND Employees
            var parameters = {
                empcode: '<%=Session["empcode"].ToString()%>'
            };
            $.ajax({
                type: "POST",
                url: "home.aspx/GetApproverList",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(parameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        BindEmployees(data.d);
                    }
                },
                failure: function (response) {
                    alert(response.d);

                },
                error: function (response) {
                    alert(response.d);

                }

            });
            function BindEmployees(data) {

                var str = "";
                str += "<ul class='signups'>";
                var length = 0;
                if (data.length > 5)
                    length = 5;
                else
                    length = data.length;
                for (var i = 0; i < length; i++) {
                    str += "<li>";
                    str += "<a target='ifrmSDL' href='" + data[i].empcode + "'>";
                    str += "<div class='user pull-left'><img src='" + data[i].photo + "' style='border-radius:50%;margin-top:5px;'></div>";
                    str += "<div class='info'>";
                    str += " <div style='width: 100%'><div style='width: 90%'>" + data[i].empname + "</div>";
                    str += "<div style='width: 10%; float: right;'>";
                    //  alert(data[i].mode);
                    if (data[i].mode == '')
                        str += "<div style='width: 8px; height: 8px; -webkit-border-radius: 100%; -moz-border-radius: 100%; border-radius: 100%; background: #cccccc; -webkit-box-shadow: 0 0 4px #999999 inset; -moz-box-shadow: 0 0 4px #999999 inset; box-shadow: 0 0 4px #999999 inset; background-color:#cccccc'>";
                    else if (data[i].mode == 'P')
                        str += "<div style='width: 8px; height: 8px; -webkit-border-radius: 100%; -moz-border-radius: 100%; border-radius: 100%; background: #cccccc; -webkit-box-shadow: 0 0 4px #999999 inset; -moz-box-shadow: 0 0 4px #999999 inset; box-shadow: 0 0 4px #999999 inset; background-color: #6ac280'>";
                    else if (data[i].mode == 'A')
                        str += "<div style='width: 8px; height: 8px; -webkit-border-radius: 100%; -moz-border-radius: 100%; border-radius: 100%; background: #cccccc; -webkit-box-shadow: 0 0 4px #999999 inset; -moz-box-shadow: 0 0 4px #999999 inset; box-shadow: 0 0 4px #999999 inset; background-color: #e84f4c'>";
                    else
                        str += "<div style='width: 8px; height: 8px; -webkit-border-radius: 100%; -moz-border-radius: 100%; border-radius: 100%; background: #cccccc; -webkit-box-shadow: 0 0 4px #999999 inset; -moz-box-shadow: 0 0 4px #999999 inset; box-shadow: 0 0 4px #999999 inset; background-color: #f3cf59'>";

                    str += "</div>";
                    str += "</div>";
                    str += "<p class='designation'>" + data[i].designation + "</p>";
                    str += "</div>";
                    //// alert(data[i].mode);
                    //if (data[i].mode == '')
                    //    str += "<div class='online'></div>";
                    //else if (data[i].mode == 'P')
                    //    str += "<div class='online' style='background: #6ac280;'></div>";
                    //else if (data[i].mode == 'A')
                    //    str += "<div class='online' style='background: #e84f4c;'></div>";
                    //else
                    //    str += "<div class='online' style='background: #f3cf59;'></div>";
                    str += "</a>";
                    str += " </li>";
                }
                if (data.length > 5)
                    str += "<li align='center'><a href='admin/SubEmployeeList.aspx' target='ifrmSDL'>View All</a> </li>";
                str += " </ul>";
                // alert(str);
                $("#empreportiess").html(str);
                $("#collapseTwo span").append(data.length - 1);
            }

        });



    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            //Tiny Scrollbar
            $('#collapseThree').tinyscrollbar();
            var str = "";
            str += "<ul class='signups'>";
            str += "<li align='center'><a href='viewprofile.aspx' target='ifrmSDL'>My Profile</a> </li>";
            str += " </ul>";
            // alert(str);
            $("#empreportiess1").html(str);
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div style="background-color: whitesmoke">
            <div class="topbar" id="top" runat="server">
                <table style="width: 100%;" cellspacing="0">
                    <tr>
                        <td style="width: 33.33%; text-align: justify;">
                            <% if (Session["Uploaded_logo"] != null) Response.Write(Session["Uploaded_logo"].ToString()); %>
                        </td>
                        <td style="width: 33.33%; text-align: justify;">
                            <p style="font-size: 22px; font-weight: 800; color: #ee7276; padding-top: 5px; margin-left: 80px; margin-top: 10px">Welcome To HRMS Portal</p>
                        </td>
                        <td style="width: 33.33%; text-align: right;">
                            <img src="images/SmartH2R.png" alt="User" style="width: 220px; padding-right: 60px;" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>

        <div class="container-fluid" style="border-top: 5px solid #ffb501; margin-top: 75px">
            <div class="left-sidebar hidden-tablet hidden-phone">
                <div class="content" runat="server" id="reportiees" visible="false" style="margin-top: 100px;">

                    <div id="Div2" runat="server" style="background-color: whitesmoke; padding-bottom: 10px;">
                        <div style="width: 300px; padding-top: 10px;">
                            <table style="width: 55%; text-align: center">
                                <tr>
                                    <td>
                                        <div class="HomePhoto">
                                            <% if (Session["PhotoForHome"] != null) Response.Write(Session["PhotoForHome"].ToString()); else Response.Redirect("~/notlogged.aspx"); %>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-size: 14px; font-weight: 700; color: #353535; font-family: 'Poppins', sans-serif;">
                                            <% if (Session["empcode"] != null) Response.Write(Session["empcode"].ToString()); %> 
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <span style="font-size: 14px; font-weight: 700; color: #353535; font-family: 'Poppins', sans-serif;">
                                            <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %>
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="ResetPassword.aspx" title="Reset Password" target="_blank" style="color: dodgerblue; font-size: 13px;">Change Password</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="viewProfile.aspx" title="View Profile" target="_blank" style="color: dodgerblue; font-size: 13px;">My Profile</a>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Button ID="btn" runat="server" Text="Log Out" ToolTip="LogOut" OnClick="btn_Click" CssClass="RedLinkButton" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div id="accordion1" class="accordion no-margin" runat="server" style="margin-top: 70px">
                        <div class="accordion-group">
                            <div class="accordion-heading">
                                <a href="#collapseTwo" data-parent="#accordion1" data-toggle="collapse" class="accordion-toggle" data-original-title="" style="font-weight: 700;">Team Members <span class="label info-label label-success">
                                    <asp:Label ID="lblempcount" runat="server"></asp:Label></span>
                                </a>
                            </div>
                            <div class="accordion-body in collapse" id="collapseTwo">
                                <div class="accordion-inner">
                                    <div class="viewport">
                                        <div class="overview" style="top: 0px;" id="empreportiess">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="useraccordion1" runat="server" class="accordion no-margin">
                        <div class="accordion-group">
                            <div class="accordion-heading">
                                <a href="#collapseThree" data-parent="#accordion2" data-toggle="collapse" class="accordion-toggle" data-original-title="" style="font-weight: 700;">My Profile<span class="label info-label label-success">
                                    <img src="img/profile-icon.png" alt="" /></span>
                                </a>
                            </div>
                            <div class="accordion-body in collapse" id="collapseThree">
                                <div class="accordion-inner">
                                    <div class="viewport">
                                        <div class='overview' style='top: 0px;' id="empreportiess1">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <% if (Session["menu"] != null) { Response.Write(Session["menu"].ToString().ToString()); } %>
            </div>

            <div class="dashboard-wrapper" style="background-color: whitesmoke;">
                <div id="modulelogo" runat="server" visible="false">
                    <div id="main-nav" class="hidden-phone hidden-tablet">
                        <ul id="nav">
                            <li>
                                <a href="home.aspx?m=MyDash" data-toggle="tooltip" title="My dashboard">
                                    <img src="icon/My_Dashboard.png" alt="My Dashboard" /></a><br />
                            </li>
                            <% Response.Write(Session["AdminSection"].ToString()); %>
                        </ul>

                        <script type="text/javascript">
                            var current = document.getElementById('default');

                            function highlite(el) {
                                if (current != null) {
                                    current.className = "";
                                }
                                el.className = "selected";
                                current = el;
                            }
                        </script>
                        <div class="clearfix"></div>
                    </div>
                </div>

                <div id="superadmin" runat="server" visible="false" style="padding-bottom: 25px; background-color: whitesmoke;">
                    <%--<iframe src="EmpDashboard.aspx" name="ifrmSDL" id="ifrmSDL" onload="iframeLoaded();" style="width: 100%; border: 0px;"></iframe>--%>
                    <% if (Session["modulecode"].ToString() == "0")
                       { %><iframe src="DashBoard_Demo.aspx" name="ifrmSDL" id="ifrmSDL" onload="iframeLoaded();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "1")
                       { %><iframe src="menudashboard/menuconfig_dashboard.aspx" name="ifrmSDL" id="Iframe16" onload="iframeLoaded16();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "2")
                       { %><iframe src="menudashboard/company_dashboard.aspx" name="ifrmSDL" id="Iframe1" onload="iframeLoaded1();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "18")
                       { %><iframe src="menudashboard/informationcenter_dashboard.aspx" name="ifrmSDL" id="Iframe2" onload="iframeLoaded2();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "10")
                       { %><iframe src="menudashboard/recruitment_dashboard.aspx" name="ifrmSDL" id="Iframe3" onload="iframeLoaded3();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "13")
                       { %><iframe src="menudashboard/onboarding_dashboard.aspx" name="ifrmSDL" id="Iframe4" onload="iframeLoaded4();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "3")
                       { %><iframe src="menudashboard/employee_dashboard.aspx" name="ifrmSDL" id="Iframe5" onload="iframeLoaded5();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "11")
                       { %><iframe src="menudashboard/leave_dashboard.aspx" name="ifrmSDL" id="Iframe6" onload="iframeLoaded6();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "23")
                       { %><iframe src="menudashboard/attendance_dashboard.aspx" name="ifrmSDL" id="Iframe7" onload="iframeLoaded7();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "15")
                       { %><iframe src="menudashboard/payroll_dashboard.aspx" name="ifrmSDL" id="Iframe8" onload="iframeLoaded8();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "12")
                       { %><iframe src="menudashboard/Eevaluation_appraisal_dashboard.aspx" name="ifrmSDL" id="Iframe9" onload="iframeLoaded9();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "4")
                       { %><iframe src="menudashboard/travel_dashboard.aspx" name="ifrmSDL" id="Iframe10" onload="iframeLoaded10();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "9")
                       { %><iframe src="menudashboard/reimbursement_dashboard.aspx" name="ifrmSDL" id="Iframe11" onload="iframeLoaded11();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "17")
                       { %><iframe src="menudashboard/training_dashboard.aspx" name="ifrmSDL" id="Iframe12" onload="iframeLoaded12();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "21")
                       { %><iframe src="menudashboard/helpdesk_dashboard.aspx" name="ifrmSDL" id="Iframe13" onload="iframeLoaded13();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "22")
                       { %><iframe src="menudashboard/hrletters_dashboard.aspx" name="ifrmSDL" id="Iframe14" onload="iframeLoaded14();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "8")
                       { %><iframe src="menudashboard/Eresignation_dashboard.aspx" name="ifrmSDL" id="Iframe15" onload="iframeLoaded15();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>

                    <% if (Session["modulecode"].ToString() == "50")
                       { %><iframe src="StartUIPage.aspx" name="ifrmSDL" id="IframeStartPage" onload="iframeLoadedStartPage();" style="width: 100%; border: 0px;"></iframe>
                    <% } %>
                </div>
                <div id="temp" runat="server" visible="false" style="padding-bottom: 25px;">
                    <iframe src="onboarding/edittemplogin.aspx" name="ifrmSDL" id="ifrmtemp" onload="tempframeLoaded();" style="width: 100%; border: 0px;"></iframe>
                </div>
            </div>
        </div>
        <div class="bottombar">
            <p>Powered By SDL Globe&nbsp;<b style="font-size: 14px;">&#169;</b>&nbsp;All Rights Reserved</p>
        </div>

        <%-- <div id="mySidenav" class="sidenav">
            <a href="home.aspx" title="Back To Home Page" id="GoHome">Home
            </a>
        </div>--%>
        <div id="div_home_1" runat="server">
            <link href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/themes/smoothness/jquery-ui.css" rel="stylesheet" type="text/css" />
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
            <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.10.3/jquery-ui.min.js"></script>
            <a href="home.aspx" title="Back To Home Page" style="color: white; font-weight: 500; font-size: 18px;">
                <div id="divContainer" style="user-select: none">
                    <div class="sidenav" style="margin-top: 25px">Home </div>
                </div>
            </a>
            <script type="text/javascript">
                $(document).ready(function () {
                    $(function () { $('#divContainer').draggable(); });
                });
            </script>
        </div>
        <div id="div_home_2" runat="server" visible="false">
            <a href="home.aspx" title="Back To Home Page" style="color: white; font-weight: 500; font-size: 18px;">
                <div id="divContainer_1" style="user-select: none">
                    <div class="sidenav" style="margin-top: 25px">Home </div>
                </div>
            </a>
        </div>

    </form>
</body>
</html>
