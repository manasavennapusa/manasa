<%@ Page Language="C#" AutoEventWireup="true" CodeFile="informationcenter_dashboard.aspx.cs" Inherits="menudashboard_informationcenter_dashboard" %>

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

    <style>
        body {
            overflow: hidden;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <section class="services-area-6 bg-gray text-center p-25px height-900px">
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

            <div class="row">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-60 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/mission_icon.png" style="width: 24px; height: 24px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Vision And Mission</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-top">
                                    <img alt="img" src="../img/vision_mission.png" class="transition-3" style="width: 70px; height: 70px" />
                                </td>
                                <td class="width-80 align-middle">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-5px fw-600 fs-13 color-555">
                                                    <u class="color-underline-red">
                                                        <asp:Label ID="lbl_vision_heading" runat="server"></asp:Label>
                                                    </u>
                                                </p>
                                                <p class="ml-5px mr-5px">
                                                    <asp:Label ID="lbl_vision_description" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-5px fw-600 fs-13 color-555">
                                                    <u class="color-underline-red">
                                                        <asp:Label ID="lbl_mission_heading" runat="server"></asp:Label>
                                                    </u>
                                                </p>
                                                <p class="ml-5px mr-5px">
                                                    <asp:Label ID="lbl_mission_description" runat="server"></asp:Label>
                                                </p>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-60 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/service_info.png" style="width: 19px; height: 19px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Service Information</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-top">
                                    <img alt="img" src="../img/service_info.jpg" class="transition-3" style="width: 70px; height: 70px" />
                                </td>
                                <td class="width-80 align-middle">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-100 p-10px text-justify">
                                                <p class="ml-5px fw-600 fs-13 color-555">
                                                    <u class="color-underline-red">
                                                        <asp:Label ID="lbl_service_info_heading" runat="server"></asp:Label>
                                                    </u>
                                                </p>
                                                <p class="ml-5px mr-5px">
                                                    <asp:Label ID="lbl_service_info_description" runat="server"></asp:Label>
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
                                    <a href="../InformationCenter/ProductInformationView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-60 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/awards.png" style="width: 20px; height: 20px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Awards And Recognization</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="../img/award.png" class="transition-3" />
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
                                    <a href="../InformationCenter/NewsMasterView.aspx" class="color-orange">Read More</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-260px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-50 text-left p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/bull_horn.png" style="width: 21px; height: 21px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>News And Updates</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="width-100 ml-10px mr-20px">
                            <tr>
                                <td class="width-20 align-middle">
                                    <img alt="img" src="../img/news_2.png" class="radius-50 transition-3" />
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
                                    <a href="../InformationCenter/CatalogView.aspx" class="color-orange">Read More</a>
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


