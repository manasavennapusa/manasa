<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="informationcenter_View" %>

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
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Sastisfaction Survey</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1a:
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>1. I have good access to HR employees for advice and assistance.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_hremployee" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>2. When I contact my HR department, I usually receive help or a response:
                                            </td>

                                        </tr>
                                       
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_hrdepartment" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>3.	Do you find found that getting HR information is more difficult than you believe it should be because of a lack of sufficient skill in the HR staff?
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_hrinformation" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>4.	Have you found that getting HR information is more difficult that you believe it should be because of a lack of infrastructure in the HR department?
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_hrdifficult" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>5.	Have you had any problems finding or obtaining access to the right person in the HR department to get the information or service you need?
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>


                                                <asp:Label ID="lbl_infservice" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <table>
                                        <tr>
                                            <td>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>6. Do you believe the HR department made sincere attempts to solve your problems or answer your questions?
                                            </td>
                                        </tr>
                                       
                                        <tr>
                                            <td>

                                                <asp:Label ID="lbl_problem" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1b: QUALITY OF HR SERVICES:
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <b>Recruitment and placement, management-employee relations, training and development, compensation and benefits--as well as an additional overall service. 
                                        <br />

                                        The next group of questions (11 - 34) ask you to rate the quality of HR services that your HR department delivers to you:<br />
                                        <br />
                                        •	TIMELINESS: information or assistance is provided promptly<br />
                                        •	CLARITY: information or assistance is provided in a clear manner and is easy to understand<br />
                                        •	ACCURACY: information or assistance provided is current and accurate<br />
                                        •	MANNER: information or assistance is provided in a courteous manner with a good attitude<br />
                                        <br />
                                        Rating that encompasses all the preceding program areas. Examples of the types of HR activity in each of the broad categories are provided in each section. Please rate your satisfaction level in each area. Use a scale of 1 to 5, with 1 being “very poor,” 3 being “average” and 5 being “very good.” Please base your answers on actual experiences you have had with the HR department; do not base your answers on hearsay. If you believe you do not have enough information about the services being discussed or you have not had first-hand experience with the issue, select the “DO NOT KNOW” response.
                                    </b>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>
                <%-- ------------------------------------------------------------------------------------------%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1c:RECRUITMENT AND PLACEMENT
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <b>Some examples of the services provided in this area are: information on job openings (vacancies) and promotion opportunities, information about qualifications required for specific jobs, career counselling or other employment advice. </b>
                                </tr>
                                <tr>
                                    <td width="25%">6. Timeliness
                                    </td>

                                    <td>

                                        <asp:Label ID="lbl_rbo_but1" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">7. Clarity
                                    </td>

                                    <td>

                                        <asp:Label ID="lbl_rdo_but2" runat="server"></asp:Label>


                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">8. Accuracy
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but3" runat="server"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">9. Manner
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but4" runat="server"></asp:Label>





                                    </td>
                                </tr>



                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1d:MANAGEMENT-EMPLOYEE RELATIONS
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <b>Some examples of the services provided in this area are: advice on hours of work and leave, incentive awards, performance appraisals, disciplinary actions, grievances, appeals and counselling. </b>
                                </tr>

                                <tr>
                                    <td width="25%">10. Timeliness
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but5" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>


                                    <td width="25%">11. Clarity
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but6" runat="server"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">12. Accuracy
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but7" runat="server"></asp:Label>
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">13. Manner
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but8" runat="server"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1e:TRAINING AND DEVELOPMENT
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>Some examples of the services provided in this area are: career development counselling, training opportunities and information about enrolling in training courses, tuition assistance, correspondence training and special or career program training plans.</b>
                                </tr>

                                <tr>
                                    <td width="25%">14. Timeliness
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but9" runat="server"></asp:Label>

                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">15. Clarity
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but10" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">16. Accuracy
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but11" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">17. Manner
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but12" runat="server"></asp:Label>



                                    </td>
                                </tr>




                            </table>
                        </div>
                    </div>
                </div>



                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 1f:COMPENSATION AND BENEFITS
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>Some examples of the services provided in this area are: pay salary rates, pay adjustments, retirement savings choices/changes, life and health insurance choices/change, injury compensation claims, maintaining and updating employee records, orientation for new employees, service date calculations, and official HR file maintenance. </b>
                                </tr>


                                <tr>
                                    <td width="25%">18. Timeliness
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but13" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">19. Clarity
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but14" runat="server"></asp:Label>


                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">20. Accuracy
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but15" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">21. Manner
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but16" runat="server"></asp:Label>



                                    </td>
                                </tr>



                            </table>
                        </div>
                    </div>
                </div>
                <%-- ------------------------------------------------------------------------------------%>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 2a:THE OVERALL QUALITY OF SERVICE FROM YOUR HR DEPARTMENT
                                </div>
                            </div>
                        </div>
                    </div>
                </div>



                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">

                                <tr>
                                    <td width="25%">22. Timeliness
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but17" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">23. Clarity
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but18" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">24. Accuracy
                                    </td>

                                    <td>


                                        <asp:Label ID="lbl_rdo_but19" runat="server"></asp:Label>



                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">25. Manner
                                    </td>

                                    <td>



                                        <asp:Label ID="lbl_rdo_but20" runat="server"></asp:Label>



                                    </td>
                                </tr>


                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>a)	The HR staff is available when I need them.</b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but21" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>b)	I feel comfortable discussing problems or concerns with the HR staff.</b>
                                    </td>

                                    <td>

                                        <asp:Label ID="lbl_rdo_but22" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>c)	HR staff consistently administers employer personnel policies and procedures.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but23" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>d)	The HR staff is not responsive to the needs of other departments. </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but24" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>e)	The HR staff is too rigid in its interpretation of policies and procedures. </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but25" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>f)	HR staff responds to my requests in a timely manner.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but26" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>g) I don’t receive answers when I ask for information from HR. </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but27" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>h) The HR staff looks for other ways to assist me when what I am requesting cannot be done exactly as requested.</b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but28" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>i) The HR staff is courteous and helpful when I call.   </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but29" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>j) The HR staff does not adequately represent the interests of non-supervisory employees   </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but30" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>SECTION 2b:
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>26. I am promptly informed about important changes in HR rules or benefits.  </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but31" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>27. Policies and procedures affecting my work are communicated adequately.</b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but32" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>28. Awards and recognition are given to the most deserving employees. </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but33" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>29. I get the training I need to do my job effectively.  </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but34" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>30. I understand the mission and functions of my immediate work area.   </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but35" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>31. The organizational structure of my area makes it easy to focus on quality. </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but36" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>32. I have all the skills needed to do my job well.   </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but37" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>33. I would recommend that others pursue a job opportunity at this company.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but38" runat="server"></asp:Label>

                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>34. Organizational structure in my area facilitates communication with employees.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but39" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>35. My performance standards are clear. </b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but40" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>36. My performance standards are realistic.</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but41" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>37. My department is able to attract high-quality employees.</b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but42" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>38. I am encouraged to participate in cultural awareness observances.</b>
                                    </td>

                                    <td>
                                        <asp:Label ID="lbl_rdo_but43" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>39. The morale in my work area is good.  </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but44" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>40. The overall morale in the company is good. </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but45" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>41. Promotions   </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but46" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>42. Training </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but47" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>43. Awards </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but48" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>44.Discipline</b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but49" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="60%">
                                        <b>45. Performance appraisal </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_rdo_but50" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="form-actions no-margin">
                    <%--    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_submit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    --%>
                </div>

            </div>
        </div>
    </form>

</body>
</html>
