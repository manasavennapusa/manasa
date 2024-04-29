<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module.aspx.cs" Inherits="module" %>

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
<head>
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style>
        .online {
            position: absolute;
            top: 6px;
            right: 5px;
            width: 8px;
            height: 8px;
            -webkit-border-radius: 100%;
            -moz-border-radius: 100%;
            border-radius: 5px;
            background: #cccccc;
            -webkit-box-shadow: 0 0 4px #999999 inset;
            -moz-box-shadow: 0 0 4px #999999 inset;
            box-shadow: 0 0 4px #999999 inset;
        }
    </style>
    <script type="text/javascript">
        function iframeLoaded() {
            var iFrameID = document.getElementById('ifrmSDL');
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
        function reload() {
            document.getElementById('navdiv').contentDocument.location.reload(true);
        }
    </script>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/jquery-1.3.2.min.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="js/tiny-scrollbar.js"></script>
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
                    str += "<div class='user pull-left'><img src='" + data[i].photo + "' alt='user'></div>";
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
                    str += " </li>";
                }
                if (data.length > 5)
                    str += "<li align='center'><a href='#'>View All</a> </li>";
                str += " </ul>";
                // alert(str);
                $("#empreportiess").html(str);
                $("#collapseTwo span").append(data.length - 1);
            }

        });



    </script>

</head>

<body>

    <header>
        <a href="home.aspx">
            <img src="upload/logo/client-logo.png" /></a>

        <div id="mini-nav">
            <ul class="hidden-phone">


                <li>
                    <a href="ResetPassword.aspx" target="ifrmSDL"><span class="fs1" aria-hidden="true" data-icon="&#xe03b;"></span></a>
                </li>
                <li>
                    <a href="#"><span class="fs1" aria-hidden="true" data-icon="&#xe090;"></span></a>
                </li>
                <li>
                    <a href="Default.aspx"><span class="fs1" aria-hidden="true" data-icon="&#xe0b1;"></span></a>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
    </header>

    <div class="container-fluid">
        <div class="left-sidebar hidden-tablet hidden-phone">
            <div class="user-details" style="height: 70px">
                <div class="user-img">

                    <% if (Session["PerPhoto"] != null) Response.Write(Session["PerPhoto"].ToString()); %>
                </div>
                <div class="welcome-text">
                    <span>Welcome</span>
                    <br />
                    <span style="color: white">
                        <% if (Session["rolename"] != null) Response.Write(Session["rolename"].ToString()); %>
                        ( <% if (Session["empcode"] != null) Response.Write(Session["empcode"].ToString()); %> -
                         <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %> ) 

                    </span>
                </div>
            </div>
           
            <div id="navdiv" runat="server">
            <%--  <iframe src="menu.aspx" name="ifrmSDL1" id="Iframe1" style="width: 100%; border: 0px; height: 1890px"></iframe>--%>
            <% if (Session["menu"] != null) { Response.Write(Session["menu"].ToString().ToString()); } %>
                </div>
        </div>

        <div class="dashboard-wrapper">
            <div id="main-nav" class="hidden-phone hidden-tablet">
                <ul id="nav">
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
            <div id="superadmin" runat="server" visible="false">
                <iframe src="EmpDashboard.aspx" name="ifrmSDL" id="ifrmSDL" onload="iframeLoaded();" style="width: 100%; border: 0px;"></iframe>
                <%-- style="width: 100%; height: 1500px; border: 0px; min-height: 1154px;"--%>
            </div>
            <div id="temp" runat="server" visible="false">
                <iframe src="onboarding/edittemplogin.aspx" name="ifrmSDL" id="ifrmtemp" onload="tempframeLoaded();" style="width: 100%; border: 0px;"></iframe>
            </div>

            <%--for Employee dashboard--%>
            <%-- <div id="employee" runat="server" visible="false">
                <iframe src="EmployeeDashboard.aspx" name="ifrmSDL" id="Iframe2" style="width: 100%; height: 1500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
            <%--for HR dashboard--%>
            <%--  <div id="hr" runat="server" visible="false">
                <iframe src="Default5.aspx" name="ifrmSDL" id="ifrmSDL" style="width: 100%; height: 1500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
            <%--for Admin dashboard--%>

            <%--   <div id="admindash" runat="server" visible="false">
                <iframe src="CeoDashboard.aspx" name="ifrmSDL" id="Iframe1" style="width: 100%; height: 1500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
        </div>
        <!-- dashboard-container -->
    </div>
    <!-- container-fluid -->
    <div id="loader" style="display: none;">
        <img src="img/loader.gif" style="width: 25%; height: 25%" />
    </div>

</body>
</html>

