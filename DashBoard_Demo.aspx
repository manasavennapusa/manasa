<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard_Demo.aspx.cs" Inherits="DashBoard_Demo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <link href="css/dashboardcss/animate.css" rel="stylesheet" />
    <link href="css/dashboardcss/bootstrap.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/et-line-icons.css" rel="stylesheet" />
    <link href="css/dashboardcss/font-awesome.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/iconmonstr-iconic-font.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/lity.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/main.css" rel="stylesheet" />
    <link href="css/dashboardcss/owl.carousel.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/owl.theme.default.min.css" rel="stylesheet" />
    <link href="css/dashboardcss/responsive.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <meta name="description" content="Flexible Calendar with jQuery and CSS3" />
    <meta name="keywords" content="responsive, calendar, jquery, plugin, full page, flexible, javascript, css3, media queries" />
    <meta name="author" content="Codrops" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <link rel="shortcut icon" href="../favicon.ico" />

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <!-- Calendar Js -->
    <script src="js/fullcalendar/jquery-ui-1.10.2.custom.min.js"></script>
    <script src="js/fullcalendar/fullcalendar.min.js"></script>
    <link href="css/fullcalendar/fullcalendar.css" rel="stylesheet" />
    <link href="css/fullcalendar/fullcalendar.print.css" rel="stylesheet" media="print" />
    <style type="text/css">
        /* width */
        ::-webkit-scrollbar {
            width: 20px;
        }

        /* Track */
        ::-webkit-scrollbar-track {
            box-shadow: inset 0 0 5px #d5b271;
            border-radius: 10px;
        }

        /* Handle */
        ::-webkit-scrollbar-thumb {
            background: #ff7762;
            border-radius: 10px;
        }

            /* Handle on hover */
            ::-webkit-scrollbar-thumb:hover {
                background: #ff8434;
            }

        .imghov {
            opacity: 0.7;
            filter: alpha(opacity=70); /* For IE8 and earlier */
        }

            .imghov:hover {
                opacity: 1.0;
                filter: alpha(opacity=100); /* For IE8 and earlier */
            }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px dashboard_height">

            <div class="row">
                <div class="leadership-area col-lg-12 col-md-12 transition-3 wow fadeInUp pb-20px  o-hidden" data-wow-delay="0.35s">
                    <div class="wow fadeInUp" data-wow-delay="0.3s">
                        <div class="row">
                            <div class="col-lg-1 col-md-1 transition-3 text-center align-middle">
                                <div class="width-130px height-85 bg-fff p-7px radius-10 mt-10px max-min-height-125px">
                                    <% if (Session["PerPhoto"] != null) Response.Write(Session["PerPhoto"].ToString()); else Response.Redirect("~/notlogged.aspx"); %>
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
                                    <a href="ResetPassword.aspx" title="Reset Password" target="ifrmSDL" class="fs-12 color-navblue">Change Password</a><br />
                                    <a href="viewProfile.aspx" title="View Profile" target="ifrmSDL" class="fs-12 color-navblue">My Profile</a><br />
                                    <a href="notlogged.aspx?logout=1" title="Logout" class="RedLinkButton">Log Out</a>
                                </p>
                            </div>
                            <div class="col-lg-5 col-md-5 transition-3 text-center align-middle" style="display: none">
                                <div class="container about-area-3 mt-20px">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="numberCircle opacity-7">
                                                <asp:Label ID="lbl_EL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="numberCircle1 opacity-7">
                                                <asp:Label ID="lbl_CL_SL" runat="server"></asp:Label>
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
                                        <div class="col-md-4 text-left">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Earned Leave</div>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Casual & SickLeave</div>
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
                <div class="col-lg-6 col-md-6 p-10px transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text radius-10px transition-3 wow fadeInUp">
                        <table class="width-100">
                            <tr>
                                <td class="width-48 text-center bg-fff radius-10px">
                                    <div class="relative">
                                        <img src="img/default_profile.png" class="img-responsive img-square radius-10px imghov" />
                                        <p class="absolute-text">
                                            <asp:Label ID="lbl1" runat="server" CssClass="fs-14">Total Head Count</asp:Label><br />
                                            <asp:Label ID="lbl_headcount" runat="server" CssClass="fs-30 fw-800"></asp:Label>
                                        </p>
                                    </div>
                                </td>
                                <td class="width-4 bg-gray"></td>
                                <td class="width-48 text-center bg-fff radius-10px">
                                    <div class="relative">
                                        <img src="img/plus_image.png" class="img-responsive img-square radius-10px imghov" />
                                        <p class="absolute-text-1">
                                            <asp:Label ID="lbl2" runat="server" CssClass="fs-14">Joinings This Month</asp:Label><br />
                                            <asp:Label ID="lbl_joining" runat="server" CssClass="fs-30 fw-800"></asp:Label>
                                        </p>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="services-text pt-15px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100">
                            <tr>
                                <td class="width-48 text-center bg-fff radius-10px">
                                    <div class="relative">
                                        <img src="img/user_cross.png" class="img-responsive img-square radius-10px imghov" />
                                        <p class="absolute-text">
                                            <asp:Label ID="lbl3" runat="server" CssClass="fs-14">Exits This Month</asp:Label><br />
                                            <asp:Label ID="lbl_exits" runat="server" CssClass="fs-30 fw-800"></asp:Label>
                                        </p>
                                    </div>
                                </td>
                                <td class="width-4 bg-gray"></td>
                                <td class="width-48 text-center bg-fff radius-10px">
                                    <div class="relative">
                                        <img src="img/people_user.png" class="img-responsive img-square radius-10px imghov" />
                                        <div class="absolute-text-2">
                                            <asp:Table ID="tbl" runat="server">
                                                <asp:TableRow>
                                                    <asp:TableCell ColumnSpan="2">
                                                        <%--Appraisal Due --%>
                                                        <asp:Label ID="lbl4" runat="server" CssClass="fs-14">Appraisal Due</asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell CssClass="fs-25 fw-700 border-right-white">
                                                        <asp:Label ID="lbl_this_month" runat="server">0</asp:Label>
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="fs-25 fw-700">
                                                        <asp:Label ID="lbl_next_month" runat="server">0</asp:Label>
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                                <asp:TableRow>
                                                    <asp:TableCell CssClass="fs-12 pr-5px">
                                                               This Month
                                                    </asp:TableCell>
                                                    <asp:TableCell CssClass="fs-12 pl-5px">
                                                                Next Month
                                                    </asp:TableCell>
                                                </asp:TableRow>
                                            </asp:Table>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-60 text-left p-5px">
                                    <img src="images/chart_icon/awards.png" style="width: 21px; height: 21px" />&nbsp;
                                        <b>Awards And Recognization</b>
                                </td>
                                <td id="td_awards_recognization" runat="server" visible="false" class="width-40 text-right p-5px">
                                    <a href="InformationCenter/NewsMasterAdd.aspx" class="buttons">
                                        <img src="img/plus_green.png" alt="Place Holder" class="image" />
                                        Add
                                    </a>

                                    <button type="button" class="buttons-edit" onclick="location.href = 'InformationCenter/NewsMasterEdit.aspx';">
                                        <img src="images/chart_icon/edit.png" style="width: 13px; height: 13px" />
                                        Edit
                                    </button>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="img/award.png" class="transition-3" />
                                </td>
                                <td class="width-80 align-middle">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-5px fw-600 fs-13 color-555">
                                                    <u class="color-underline-red">
                                                        <asp:Label ID="lbl_award_heading" runat="server"></asp:Label>
                                                    </u>
                                                </p>
                                                <p class="ml-5px mr-5px">
                                                    <asp:Label ID="lbl_award_description" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-100 p-10px text-right">
                                    <a href="InformationCenter/NewsMasterView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_3" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-65px">
                            <tr>
                                <td class="width-50 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-7">
                                                <img src="images/chart_icon/user.jpg" style="width: 19px; height: 19px" />
                                            </td>
                                            <td class="width-93 align-bottom pt-5px">&nbsp;
                                                <b>
                                                    <asp:Label ID="Label1" runat="server" CssClass="fs-14">Employee's Status</asp:Label></b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="width-50 text-right p-5px">
                                    <asp:Label ID="lbl" runat="server" CssClass="pt-7px pb-7px pr-15px pl-15px radius-5px bg-label_color color-fff" Text="hello">
                                        <img src="images/chart_icon/cl.png" style="width: 17px; height: 17px" />
                                        <asp:Label ID="lbl_todays_date" runat="server" CssClass="fs-15 fw-700 pl-8px"></asp:Label>
                                    </asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px mt-65px mb-30px">
                            <tr>
                                <td class="width-20 text-center align-middle">
                                    <div id="hexagon">
                                        <asp:Label ID="lbl_Present" runat="server"></asp:Label>
                                    </div>
                                    <br />
                                </td>
                                <td class="width-20 text-center align-middle">
                                    <div id="hexagon_1">
                                        <asp:Label ID="lbl_OnLeave" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td class="width-20 text-center align-middle">
                                    <div id="hexagon_2">
                                        <asp:Label ID="lbl_WFH" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td class="width-20 text-center align-middle">
                                    <div id="hexagon_3">
                                        <asp:Label ID="lbl_CompOff" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td class="width-20 text-center align-middle">
                                    <div id="hexagon_4">
                                        <asp:Label ID="lbl_OD" runat="server"></asp:Label>
                                    </div>
                                </td>
                                <td class="width-20 text-center pr-20px align-middle">
                                    <div id="hexagon_5">
                                        <asp:Label ID="lbl_LateComers" runat="server"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-20 text-center pt-10px pr-20px align-middle">
                                    <asp:Label ID="lbl_Present_Text" runat="server" CssClass="fw-500">Present</asp:Label>
                                </td>
                                <td class="width-20 text-center pt-10px pr-20px align-middle">
                                    <asp:Label ID="lbl_OnLeave_Text" runat="server" CssClass="fw-500">On Leave</asp:Label>
                                </td>
                                <td class="width-20 text-center pt-10px pr-20px align-middle">
                                    <asp:Label ID="lbl_WFH_Text" runat="server" CssClass="fw-500">WFH</asp:Label>
                                </td>
                                <td class="width-20 text-center pt-10px pr-20px align-middle">
                                    <asp:Label ID="lbl_CompOff_Text" runat="server" CssClass="fw-500">CompOff</asp:Label>
                                </td>
                                <td class="width-20 text-center pt-10px pr-20px align-middle">
                                    <asp:Label ID="lbl_OD_Text" runat="server" CssClass="fw-500">OD</asp:Label>
                                </td>
                                <td class="width-20 text-center pt-20px pr-20px align-middle">
                                    <asp:Label ID="lbl_LateComers_Text" runat="server" CssClass="fw-500">Late Comers</asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-255px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-50 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-7">
                                                <img src="images/chart_icon/bull_horn.png" style="width: 22px; height: 22px" />
                                            </td>
                                            <td class="width-93 align-bottom pt-5px">&nbsp;
                                                 <b>News And Updates</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td id="td_news_update" runat="server" visible="false" class="width-50 text-right p-5px">
                                    <a href="InformationCenter/CatalogAdd.aspx" class="news_buttons">
                                        <img src="img/plus_blue.png" alt="Place Holder" class="image" />
                                        Add
                                    </a>

                                    <button type="button" class="buttons-edit" onclick="location.href = 'InformationCenter/CatalogEdit.aspx';">
                                        <img src="images/chart_icon/edit.png" style="width: 13px; height: 13px" />
                                        Edit
                                    </button>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="img/news_2.png" class="radius-50 transition-3" />
                                </td>
                                <td class="width-80 text-justify">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-10px fw-600 fs-14 color-333">
                                                    <asp:Label ID="lbl_news_heading" runat="server"></asp:Label>
                                                </p>
                                                <p class="ml-10px color-underline-red">
                                                    <asp:Label ID="lbl_news_description" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-100 p-10px text-right">
                                    <a href="InformationCenter/CatalogView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_7" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-60 text-left p-5px">
                                    <img src="images/chart_icon/awards.png" style="width: 21px; height: 21px" />&nbsp;
                                        <b>Awards And Recognization</b>
                                </td>
                                <td id="td_awards_recognization_1" runat="server" visible="false" class="width-40 text-right p-5px">
                                    <a href="InformationCenter/NewsMasterAdd.aspx" class="buttons">
                                        <img src="img/plus_green.png" alt="Place Holder" class="image" />
                                        Add
                                    </a>

                                    <button type="button" class="buttons-edit" onclick="location.href = 'InformationCenter/NewsMasterEdit.aspx';">
                                        <img src="images/chart_icon/edit.png" style="width: 13px; height: 13px" />
                                        Edit
                                    </button>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="img/award.png" class="transition-3" />
                                </td>
                                <td class="width-80 align-middle">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-5px fw-600 fs-13 color-555">
                                                    <u class="color-underline-red">
                                                        <asp:Label ID="lbl_award_heading_1" runat="server"></asp:Label>
                                                    </u>
                                                </p>
                                                <p class="ml-5px mr-5px">
                                                    <asp:Label ID="lbl_award_description_1" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-100 p-10px text-right">
                                    <a href="InformationCenter/NewsMasterView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-255px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-50 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-7">
                                                <img src="images/chart_icon/bull_horn.png" style="width: 22px; height: 22px" />
                                            </td>
                                            <td class="width-93 align-bottom pt-5px">&nbsp;
                                                 <b>News And Updates</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td id="td_news_update_1" runat="server" visible="false" class="width-50 text-right p-5px">
                                    <a href="InformationCenter/CatalogAdd.aspx" class="news_buttons">
                                        <img src="img/plus_blue.png" alt="Place Holder" class="image" />
                                        Add
                                    </a>

                                    <button type="button" class="buttons-edit" onclick="location.href = 'InformationCenter/CatalogEdit.aspx';">
                                        <img src="images/chart_icon/edit.png" style="width: 13px; height: 13px" />
                                        Edit
                                    </button>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="img/news_2.png" class="radius-50 transition-3" />
                                </td>
                                <td class="width-80 text-justify">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-10px fw-600 fs-14 color-333">
                                                    <asp:Label ID="lbl_news_heading_1" runat="server"></asp:Label>
                                                </p>
                                                <p class="ml-10px color-underline-red">
                                                    <asp:Label ID="lbl_news_description_1" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-100 p-10px text-right">
                                    <a href="InformationCenter/CatalogView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp text-left" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-410px">

                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="images/chart_icon/bell.png" style="width: 21px; height: 21px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                 <b>Alert</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>

                        <table class="table table-bordered text-center">
                            <tr>
                                <th style="padding: 3px 3px 3px 3px; background-color: whitesmoke; font-size: 15px">Notification
                                </th>
                                <th style="padding: 3px 3px 3px 3px; background-color: whitesmoke; font-size: 15px">Pending
                                </th>
                            </tr>
                            <tr class="error">
                                <td style="font-size: small; background-color: lightsteelblue; padding: 3px 3px 3px 3px">My Leave Application
                                </td>
                                <td style="background-color: skyblue; font-size: small; text-align: center; padding: 3px 3px 3px 3px"><a href="Leave/leavestatus.aspx?leavestatus=0">
                                    <asp:Label ID="lblleave_pending" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a>
                                </td>
                            </tr>
                        </table>

                        <table class="table table-bordered text-center">
                            <tr>
                                <th style="padding: 3px 3px 3px 3px" class="width-15 bg-smoke fs-15">Notification
                                </th>
                                <th style="padding: 3px 3px 3px 3px" class="width-15 bg-smoke fs-15">Pending Query
                                </th>
                                <th style="padding: 3px 3px 3px 3px" class="width-15 bg-smoke fs-15">Approved Query
                                </th>
                            </tr>
                            <tr class="error">
                                <td style="font-size: small; padding: 3px 3px 3px 3px; background-color: lightsteelblue">My Query
                                </td>
                                <td style="padding: 3px 3px 3px 3px; background-color: skyblue"><a href="Query/myquerystatus.aspx">
                                    <asp:Label ID="lbl_allquery_pending_status" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                <td style="padding: 3px 3px 3px 3px; background-color: skyblue"><a href="Query/myquerystatus.aspx">
                                    <asp:Label ID="lbl_allquery_approved_status" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                            </tr>
                        </table>

                        <table class="table table-bordered text-center">
                            <tr>
                                <th style="padding: 3px 3px 3px 3px" class="width-15 bg-smoke fs-15">Notification
                                </th>
                                <th style="padding: 3px 3px 3px 3px" class="width-15 bg-smoke fs-15">Status
                                </th>
                            </tr>
                            <tr class="error">
                                <td style="font-size: small; padding: 3px 3px 3px 3px; background-color: lightsteelblue">My E-Evaluation
                                </td>
                                <td style="padding: 3px 3px 3px 3px; background-color: skyblue"><a href="appraisal/VIEWREAING.aspx">
                                    <asp:Label ID="lbl_Appraisal_status" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                            </tr>
                        </table>
                    </div>

                </div>
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp text-left" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-410px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="images/chart_icon/chain.png" style="width: 21px; height: 21px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Important Links</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-90 mb-100px ml-20px">
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/JobDescriptionView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Job Openings
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/OrganisationChartView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Organisation Chart</a>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/PolicyDockitView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Policy Dockit</a>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/ProductInformationView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Service Information</a>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/AnnouncementMasterView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Announcement</a>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-30 text-left p-10px">
                                    <a href="InformationCenter/AchievementMasterView.aspx" class="color-555">
                                        <img src="images/chart_icon/hand_right_direction.png" style="width: 30px; height: 31px" />&nbsp;
                                        Achievement</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_5" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp bg-label_color">
                        <table class="width-100">
                            <tr>
                                <td class="width-100 text-justify p-5px bg-label_1_color color-fff">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-7">
                                                <img src="images/chart_icon/birthday.png" style="width: 30px; height: 25px" />
                                            </td>
                                            <td class="width-93 align-bottom pt-5px">&nbsp;
                                                 <b>Birthday Wishes</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="width-100 text-justify p-5px bg-label_1_color color-fff">
                                    <asp:Button ID="btnwish" runat="server" Text="Send Wish" CssClass="Greeetings_buttons" ToolTip="Send Wish" OnClick="btnwish_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" class="width-100 text-justify p-5px bg-label_color" style="background: url(img/birthday_1.gif) no-repeat; -webkit-background-size: cover; -moz-background-size: cover; -o-background-size: cover; background-size: cover; padding-bottom: 30px; border-radius: 0 0 15px 15px;">
                                    <div class="list">
                                        <%-- <% Response.Write(Session["Birthday"].ToString()); %>--%>
                                        <% if (Session["Birthday"] != null) Response.Write(Session["Birthday"].ToString());%>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-20px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-298px">
                        <table class="width-100">
                            <tr>
                                <td class="width-50 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="images/chart_icon/user_plus.png" style="width: 34px; height: 18px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>New Joinees</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100 text-justify p-5px">
                                    <div class="list">
                                        <% Response.Write(Session["NewEmployee"].ToString()); %>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_6" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 transition-3 wow fadeInUp text-left" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-3">
                                    <img src="images/chart_icon/calendar.png" style="width: 25px; height: 25px" />
                                </td>
                                <td class="width-97 pt-5px">
                                    <b>Calendar</b>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-100 p-5px">
                                    <div id="calendar"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

        </section>
    </form>
</body>
</html>
