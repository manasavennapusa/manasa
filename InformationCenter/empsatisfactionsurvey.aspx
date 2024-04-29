<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="empsatisfactionsurvey.aspx.cs" Inherits="informationcenter_empsatisfactionsurvey" %>

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
                                                <asp:TextBox ID="txt_hremployee" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                            <td>a)	Within 1 workday</td>
                                        </tr>
                                        <tr>
                                            <td>b)	Within 2 or 3 workdays</td>
                                        </tr>
                                        <tr>
                                            <td>c)	Within a week</td>
                                        </tr>
                                        <tr>
                                            <td>d)	After more than a week</td>
                                        </tr>
                                        <tr>
                                            <td>e)	Never</td>

                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt_hrdepartment" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:TextBox ID="txt_hrinformation" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:TextBox ID="txt_hrdifficult" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:TextBox ID="txt_infservice" runat="server" TextMode="MultiLine"></asp:TextBox>
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
                                            <td>a)	Yes</td>
                                        </tr>
                                        <tr>
                                            <td>b)	No</td>
                                        </tr>
                                        <tr>
                                            <td>c)	I have not attempted to contact the HR department</td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txt_problem" runat="server" TextMode="MultiLine"></asp:TextBox>
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

                                    The next group of questions (11 - 34) ask you to rate the quality of HR services that your HR department delivers to you:
                                    •	TIMELINESS: information or assistance is provided promptly
                                    •	CLARITY: information or assistance is provided in a clear manner and is easy to understand
                                    •	ACCURACY: information or assistance provided is current and accurate
                                    •	MANNER: information or assistance is provided in a courteous manner with a good attitude

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
                                        <asp:RadioButtonList ID="rdo_but1" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>



                                        <%--<asp:RadioButton ID="rdo_but1" runat="server" GroupName="A" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but2" runat="server" GroupName="A" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but3" runat="server" GroupName="A" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but4" runat="server" GroupName="A"  AutoPostBack="True"/>&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but5" runat="server" GroupName="A" AutoPostBack="True"/>&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   RepeatLayout="Table"
                                        <asp:RadioButton ID="rdo_but6" runat="server" GroupName="A" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">7. Clarity
                                    </td>

                                    <td>
                                        <asp:RadioButtonList ID="rdo_but2" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%-- <asp:RadioButton ID="rdo_but7" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but8" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but9" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but10" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but11" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but12" runat="server" GroupName="B" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">8. Accuracy
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but3" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>
                                       
                                        <%--<asp:RadioButton ID="rdo_but13" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but14" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but15" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but16" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but17" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but18" runat="server" GroupName="C" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">9. Manner
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but4" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                        <%--<asp:RadioButton ID="rdo_but19" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but20" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but21" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but22" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but23" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but24" runat="server" GroupName="D" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
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
                                        <asp:RadioButtonList ID="rdo_but5" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but25" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but26" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but27" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but28" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but29" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but30" runat="server" GroupName="A1" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">11. Clarity
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but6" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but31" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but32" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but33" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but34" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but35" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but36" runat="server" GroupName="B1" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">12. Accuracy
                                    </td>

                                    <td>

                                        <asp:RadioButtonList ID="rdo_but7" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>
                                       <%-- <asp:RadioButton ID="rdo_but37" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but38" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but39" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but40" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but41" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but42" runat="server" GroupName="C1" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">13. Manner
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but8" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but43" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but44" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but45" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but46" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but47" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but48" runat="server" GroupName="D1" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
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
                                         <asp:RadioButtonList ID="rdo_but9" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--<asp:RadioButton ID="rdo_but49" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but50" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but51" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but52" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but53" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but54" runat="server" GroupName="A2" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">15. Clarity
                                    </td>

                                    <td>
                                        <asp:RadioButtonList ID="rdo_but10" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but55" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but56" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but57" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but58" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but59" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but60" runat="server" GroupName="B2" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">16. Accuracy
                                    </td>

                                    <td>
                                          <asp:RadioButtonList ID="rdo_but11" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                       <%-- <asp:RadioButton ID="rdo_but61" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but62" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but63" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but64" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but65" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but66" runat="server" GroupName="C2" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">17. Manner
                                    </td>

                                    <td>

                                         <asp:RadioButtonList ID="rdo_but12" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but67" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but68" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but69" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but70" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but71" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but72" runat="server" GroupName="D2" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
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

                                         <asp:RadioButtonList ID="rdo_but13" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                       <%-- <asp:RadioButton ID="rdo_but73" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but74" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but75" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but76" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but77" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but78" runat="server" GroupName="A3" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">19. Clarity
                                    </td>

                                    <td>
                                        <asp:RadioButtonList ID="rdo_but14" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                       <%-- <asp:RadioButton ID="rdo_but79" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but80" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but81" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but82" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but83" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but84" runat="server" GroupName="B3" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">20. Accuracy
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but15" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                        <%--<asp:RadioButton ID="rdo_but85" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but86" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but87" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but88" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but89" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but90" runat="server" GroupName="C3" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">21. Manner
                                    </td>

                                    <td>

                                          <asp:RadioButtonList ID="rdo_but16" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                       <%-- <asp:RadioButton ID="rdo_but91" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but92" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but93" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but94" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but95" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but96" runat="server" GroupName="D3" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
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

                                          <asp:RadioButtonList ID="rdo_but17" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                      <%--  <asp:RadioButton ID="rdo_but97" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but98" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but99" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but100" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but101" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but102" runat="server" GroupName="A4" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">23. Clarity
                                    </td>

                                    <td>
                                        
                                        <asp:RadioButtonList ID="rdo_but18" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                       <%-- <asp:RadioButton ID="rdo_but103" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but104" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but105" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but106" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but107" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but108" runat="server" GroupName="B4" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">24. Accuracy
                                    </td>

                                    <td>
                                         <asp:RadioButtonList ID="rdo_but19" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but109" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but110" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but111" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but112" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but113" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but114" runat="server" GroupName="C4" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
                                    </td>
                                </tr>


                                <tr>
                                    <td width="25%">25. Manner
                                    </td>

                                    <td>

                                          <asp:RadioButtonList ID="rdo_but20" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                      <%--  <asp:RadioButton ID="rdo_but115" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but116" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but117" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but118" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but119" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but120" runat="server" GroupName="D4" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>
                                       
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
                                <tr width="25%">
                                    <b>a)	The HR staff is available when I need them.</b>
                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but21" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>                                           
                                        </asp:RadioButtonList>


                                    <%--<asp:RadioButton ID="rdo_but121" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but122" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but123" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but124" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but125" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but126" runat="server" GroupName="E" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>

                                
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>b)	I feel comfortable discussing problems or concerns with the HR staff.</b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but22" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                          <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>      
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but127" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but128" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but129" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but130" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but131" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but132" runat="server" GroupName="F" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>

                                
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>c)	HR staff consistently administers employer personnel policies and procedures.</b>
                                </tr>
                                <td>

                                       <asp:RadioButtonList ID="rdo_but23" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                          <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but133" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but134" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but135" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but136" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but137" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but138" runat="server" GroupName="G" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   --%>

                                
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>d)	The HR staff is not responsive to the needs of other departments. </b>
                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but24" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                          <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>      
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but139" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but140" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but141" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but142" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but143" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but144" runat="server" GroupName="H" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                   
                                --%>
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>e)	The HR staff is too rigid in its interpretation of policies and procedures. </b>
                                </tr>
                                <td>


                                      <asp:RadioButtonList ID="rdo_but25" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but145" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but146" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but147" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but148" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but149" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but150" runat="server" GroupName="I" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;                                   
                                --%>
                                </td>

                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>f)	HR staff responds to my requests in a timely manner.</b>
                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but26" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                         <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>


                                   <%-- <asp:RadioButton ID="rdo_but151" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but152" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but153" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but154" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but155" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but156" runat="server" GroupName="J" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>  

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>g) I don’t receive answers when I ask for information from HR. </b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but27" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                         <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>      
                                        </asp:RadioButtonList>


                                   <%-- <asp:RadioButton ID="rdo_but157" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but158" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but159" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but160" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but161" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but162" runat="server" GroupName="K" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               --%> 


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>h) The HR staff looks for other ways to assist me when what I am requesting cannot be done exactly as requested.</b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but28" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                          <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but163" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but164" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but165" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but166" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but167" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but168" runat="server" GroupName="L" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            --%>  


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>i) The HR staff is courteous and helpful when I call.   </b>
                                </tr>
                                <td>
                                      <asp:RadioButtonList ID="rdo_but29" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                        <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but169" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but170" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but171" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but172" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but173" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but174" runat="server" GroupName="M" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%> 


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>j) The HR staff does not adequately represent the interests of non-supervisory employees   </b>
                                </tr>
                                <td>
                                      <asp:RadioButtonList ID="rdo_but30" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                         <asp:ListItem Text="Strongly Agree" Value="5"></asp:ListItem>
                                            <asp:ListItem Text="Agree" Value="4"></asp:ListItem>
                                            <asp:ListItem Text="Neutral" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="Disagree" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Strongly Disagree" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Don’t Know" Value="0"></asp:ListItem>     
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but175" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but176" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but177" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but178" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but179" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but180" runat="server" GroupName="N" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               --%> 

                                </td>
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
                                <tr width="25%">
                                    <b>26. I am promptly informed about important changes in HR rules or benefits.  </b>
                                </tr>
                                <td>
                                    <asp:RadioButtonList ID="rdo_but31" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem  Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but181" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but182" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but183" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but184" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but185" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but186" runat="server" GroupName="O" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>  

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>27. Policies and procedures affecting my work are communicated adequately.</b>

                                </tr>
                                <td>

                                    <asp:RadioButtonList ID="rdo_but32" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but187" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but188" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but189" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but190" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but191" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but192" runat="server" GroupName="P" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               --%> 


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>28. Awards and recognition are given to the most deserving employees. </b>
                                </tr>
                                <td>
                                      <asp:RadioButtonList ID="rdo_but33" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but193" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but194" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but195" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but196" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but197" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but198" runat="server" GroupName="Q" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               --%>

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>29. I get the training I need to do my job effectively.  </b>
                                </tr>
                                <td>
                                    <asp:RadioButtonList ID="rdo_but34" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but199" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but200" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but201" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but202" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but203" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but204" runat="server" GroupName="R" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                --%>


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>30. I understand the mission and functions of my immediate work area.   </b>
                                </tr>
                                <td>
                                     <asp:RadioButtonList ID="rdo_but35" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but205" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but206" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but207" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but208" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but209" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but210" runat="server" GroupName="S" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>  

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>31. The organizational structure of my area makes it easy to focus on quality. </b>
                                </tr>
                                <td>
                                     <asp:RadioButtonList ID="rdo_but36" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but211" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but212" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but213" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but214" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but215" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but216" runat="server" GroupName="T" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             --%>  


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>32. I have all the skills needed to do my job well.   </b>
                                </tr>
                                <td>
                                    <asp:RadioButtonList ID="rdo_but37" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but217" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but218" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but219" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but220" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but221" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but222" runat="server" GroupName="U" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               --%>


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>33. I would recommend that others pursue a job opportunity at this company.</b>

                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but38" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but223" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but224" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but225" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but226" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but227" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but228" runat="server" GroupName="V" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                             --%>   


                                </td>


                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>34. Organizational structure in my area facilitates communication with employees.</b>
                                </tr>
                                <td>

                                    <asp:RadioButtonList ID="rdo_but39" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>


                                   <%-- <asp:RadioButton ID="rdo_but229" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but230" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but231" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but232" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but233" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but234" runat="server" GroupName="W" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>


                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>35. My performance standards are clear. </b>
                                </tr>
                                <td>

                                    <asp:RadioButtonList ID="rdo_but40" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but235" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but236" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but237" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but238" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but239" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but240" runat="server" GroupName="X" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              
                    --%>        

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>36. My performance standards are realistic.</b>
                                </tr>


                                <td>

                                      <asp:RadioButtonList ID="rdo_but41" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but250" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but251" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but252" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but253" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but254" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but255" runat="server" GroupName="Y" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                                </td>


                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>37. My department is able to attract high-quality employees.</b>
                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but42" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but256" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but257" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but258" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but259" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but260" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but261" runat="server" GroupName="Z" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                                </td>


                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>38. I am encouraged to participate in cultural awareness observances.</b>

                                </tr>
                                <td>
                                        <asp:RadioButtonList ID="rdo_but43" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                  <%--  <asp:RadioButton ID="rdo_but262" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but263" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but264" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but265" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but266" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but267" runat="server" GroupName="1" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              
                    --%>

                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>39. The morale in my work area is good.  </b>

                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but44" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                    <%--<asp:RadioButton ID="rdo_but268" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but269" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but270" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but271" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but272" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but273" runat="server" GroupName="2" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
                                </td>

                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>40. The overall morale in the company is good. </b>

                                </tr>
                                <td>

                                     <asp:RadioButtonList ID="rdo_but45" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but274" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but275" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but276" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but277" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but278" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but279" runat="server" GroupName="3" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>41. Promotions   </b>
                                </tr>
                                <tr>
                                    <td>

                                          <asp:RadioButtonList ID="rdo_but46" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but280" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but281" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but282" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but283" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but284" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but285" runat="server" GroupName="4" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
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
                                <tr width="25%">
                                    <b>42. Training </b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but47" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but286" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but287" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but288" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but289" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but290" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but291" runat="server" GroupName="5" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
                                </td>

                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>43. Awards </b>
                                </tr>
                                <tr>
                                    <td>

                                          <asp:RadioButtonList ID="rdo_but48" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                       <%-- <asp:RadioButton ID="rdo_but292" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but293" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but294" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but295" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but296" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but297" runat="server" GroupName="6" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
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
                                <tr width="25%">
                                    <b>44.Discipline</b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but49" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but298" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but299" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but300" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but301" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but302" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but303" runat="server" GroupName="7" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
                                </td>
                            </table>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr width="25%">
                                    <b>45. Performance appraisal </b>
                                </tr>
                                <td>

                                      <asp:RadioButtonList ID="rdo_but50" runat="server"
                                            RepeatDirection="Horizontal" Width="564px">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                            <asp:ListItem Value="5">5</asp:ListItem>
                                            <asp:ListItem Value="0">0</asp:ListItem>
                                        </asp:RadioButtonList>

                                   <%-- <asp:RadioButton ID="rdo_but304" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;1&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but305" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;2&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but306" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;3&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but307" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;4&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    
                                        <asp:RadioButton ID="rdo_but308" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;5&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                   
                                        <asp:RadioButton ID="rdo_but309" runat="server" GroupName="8" AutoPostBack="True" />&nbsp;&nbsp;Do not know&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                              --%>
                    
                                </td>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="form-actions no-margin">
                    <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btn_submit_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                 
                                                  
                </div>

            </div>
        </div>
    </form>

</body>
</html>
