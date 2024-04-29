<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormExitInterviewQuestionaries.aspx.cs" Inherits="Exit_FormExitInterviewQuestionaries" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />


</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Exit Interview Questionnaire </h2>
                    </div>
                   <br />
                    <br />
                    <br />
                    <div id="Div1" runat="server" style="border: 1px solid #e0e0e0; padding-left:10px; border-radius: 2px; width:890px; background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#f2f2f2));">
                       
                   <h5><span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>&nbsp;&nbsp;Employee Details</h5>
                            
                </div>
                    <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:900px; border-top:none">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                    <div class="span3" style="width:400px">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Date:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_date" runat="server" Width="400px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Name:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_name" runat="server" Width="400px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <%--<div class="control-group">
                                        <label class="control-label">Supervisor:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_supervisor" runat="server" Width="400px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>--%>
                                    <div class="control-group">
                                        <label class="control-label">Hire Date:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_hire" runat="server" Width="400px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Starting Position:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_stposition" runat="server" Width="200px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Starting Salary:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_stsalary" runat="server" Width="160px"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="span3">
                        <div class="widget" style="border: none;">

                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label"></label>
                                        <div class="controls">
                                            <asp:Label ID="i" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="control-group">
                                        <label class="control-label">Department:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_dept" runat="server"  Width="200px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <%--<div class="control-group">
                                        <label class="control-label"></label>
                                        <div class="controls">
                                            <asp:Label ID="h" runat="server"></asp:Label>
                                        </div>
                                    </div>--%>
                                    
                                    <div class="control-group">
                                        <label class="control-label">Last Date:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_lastdate" runat="server"  Width="200px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Ending Position:</label>
                                        <div class="controls">
                                            <asp:Label ID="txt_endposition" runat="server"  Width="200px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Ending Salary:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_endsalary" runat="server" Width="160px"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    
                </div>

                    <div class="clearfix"><br /></div>
                    <div runat="server" style="border: 1px solid #e0e0e0; padding-left:10px; border-radius: 2px; width:890px; background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#f2f2f2));">
                       
                   <h5><span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>&nbsp;&nbsp;PART l:  REASONS FOR LEAVING</h5>
                            
                </div>
                <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:900px; border-bottom:none; border-top:none">
                    <h5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>RESIGNATION :</b></h5>&nbsp;<span id="Span1"></span>
                    
                    
                    <div class="span3">
                        <div class="widget" style="border: none;">
                            
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Took another position</label>
                                        <div class="controls">
                                            <input id="Relocation1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Home/family needs</label>
                                        <div class="controls">
                                            <input id="HigherEducation1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Poor health/physical disability</label>
                                        <div class="controls">
                                            <input id="JobProfile1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Relocation to another city</label>
                                        <div class="controls">
                                            <input id="CompanyPolicy1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Travel difficulties</label>
                                        <div class="controls">
                                            <input id="Compensation1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To attend Education</label>
                                        <div class="controls">
                                            <input id="Benifits1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <div class="span3">
                        <div class="widget" style="border: none;">

                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction with salary</label>
                                        <div class="controls">
                                            <input id="Supervisor1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -work</label>
                                        <div class="controls">
                                            <input id="LackofCareerProgression1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -supervisor</label>
                                        <div class="controls">
                                            <input id="CompanyManagement1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -co-workers</label>
                                        <div class="controls">
                                            <input id="HealthMedicalReason1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction– working Conditions</label>
                                        <div class="controls">
                                            <input id="Personal1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction with benefits</label>
                                        <div class="controls">
                                            <input id="Retirement1" type="checkbox" runat="server" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    
<%--                    <div class="span3">
                        <div class="widget" style="border: none;">

                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Very Long Hours of Working</label>
                                        <div class="controls">
                                            <input id="VeryLongHoursofWorking1" type="radio" name="ReasonResponsible1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Commute</label>
                                        <div class="controls">
                                            <input id="Commute1" type="radio" name="ReasonResponsible1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Another Job Offer</label>
                                        <div class="controls">
                                            <input id="AnotherJobOffer1" type="radio" name="ReasonResponsible1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Better Designation</label>
                                        <div class="controls">
                                            <input id="BetterDesignation1" type="radio" name="ReasonResponsible1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Marriage</label>
                                        <div class="controls">
                                            <input id="Marriage1" type="radio" name="ReasonResponsible1" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Other</label>
                                        <div class="controls">
                                            <input id="Other1" type="text" runat="server" class="span4" style="width: 200px;" onfocus="Clear1();" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>--%>
                </div>

                <script type="text/javascript">
                    function Clear1() {
                        document.getElementById('Relocation1').checked = false;
                        document.getElementById('HigherEducation1').checked = false;
                        document.getElementById('JobProfile1').checked = false;
                        document.getElementById('CompanyPolicy1').checked = false;
                        document.getElementById('Compensation1').checked = false;
                        document.getElementById('Benifits1').checked = false;
                        document.getElementById('Supervisor1').checked = false;
                        document.getElementById('LackofCareerProgression1').checked = false;
                        document.getElementById('CompanyManagement1').checked = false;
                        document.getElementById('HealthMedicalReason1').checked = false;
                        document.getElementById('Personal1').checked = false;
                        document.getElementById('Retirement1').checked = false;
                        document.getElementById('VeryLongHoursofWorking1').checked = false;
                        document.getElementById('Commute1').checked = false;
                        document.getElementById('AnotherJobOffer1').checked = false;
                        document.getElementById('BetterDesignation1').checked = false;
                        document.getElementById('Marriage1').checked = false;
                    }

                    function Clear2() {
                        document.getElementById('Relocation2').checked = false;
                        document.getElementById('HigherEducation2').checked = false;
                        document.getElementById('JobProfile2').checked = false;
                        document.getElementById('CompanyPolicy2').checked = false;
                        document.getElementById('Compensation2').checked = false;
                        document.getElementById('Benifits2').checked = false;
                        document.getElementById('Supervisor2').checked = false;
                        document.getElementById('LackofCareerProgression2').checked = false;
                        document.getElementById('CompanyManagement2').checked = false;
                        document.getElementById('HealthMedicalReason2').checked = false;
                        document.getElementById('Personal2').checked = false;
                        document.getElementById('Retirement2').checked = false;
                        document.getElementById('VeryLongHoursofWorking2').checked = false;
                        document.getElementById('Commute2').checked = false;
                        document.getElementById('AnotherJobOffer2').checked = false;
                        document.getElementById('BetterDesignation2').checked = false;
                        document.getElementById('Marriage2').checked = false;
                    }

                    function ValidateFirstSection() {
                        var flag = false;

                        if (document.getElementById('Relocation1').checked == true) flag = true;
                        else if (document.getElementById('HigherEducation1').checked == true) flag = true;
                        else if (document.getElementById('JobProfile1').checked == true) flag = true;
                        else if (document.getElementById('CompanyPolicy1').checked == true) flag = true;
                        else if (document.getElementById('Compensation1').checked == true) flag = true;
                        else if (document.getElementById('Benifits1').checked == true) flag = true;
                        else if (document.getElementById('Supervisor1').checked == true) flag = true;
                        else if (document.getElementById('LackofCareerProgression1').checked == true) flag = true;
                        else if (document.getElementById('CompanyManagement1').checked == true) flag = true;
                        else if (document.getElementById('HealthMedicalReason1').checked == true) flag = true;
                        else if (document.getElementById('Personal1').checked == true) flag = true;
                        else if (document.getElementById('Retirement1').checked == true) flag = true;
                        else if (document.getElementById('VeryLongHoursofWorking1').checked == true) flag = true;
                        else if (document.getElementById('Commute1').checked == true) flag = true;
                        else if (document.getElementById('AnotherJobOffer1').checked == true) flag = true;
                        else if (document.getElementById('BetterDesignation1').checked == true) flag = true;
                        else if (document.getElementById('Marriage1').checked == true) flag = true;
                        else if (document.getElementById('Other1').value != "") flag = true;

                        return flag;
                    }

                    function ValidateThirdSection() {
                        var flag = false;

                        if (document.getElementById('Relocation2').checked == true) flag = true;
                        else if (document.getElementById('HigherEducation2').checked == true) flag = true;
                        else if (document.getElementById('JobProfile2').checked == true) flag = true;
                        else if (document.getElementById('CompanyPolicy2').checked == true) flag = true;
                        else if (document.getElementById('Compensation2').checked == true) flag = true;
                        else if (document.getElementById('Benifits2').checked == true) flag = true;
                        else if (document.getElementById('Supervisor2').checked == true) flag = true;
                        else if (document.getElementById('LackofCareerProgression2').checked == true) flag = true;
                        else if (document.getElementById('CompanyManagement2').checked == true) flag = true;
                        else if (document.getElementById('HealthMedicalReason2').checked == true) flag = true;
                        else if (document.getElementById('Personal2').checked == true) flag = true;
                        else if (document.getElementById('Retirement2').checked == true) flag = true;
                        else if (document.getElementById('VeryLongHoursofWorking2').checked == true) flag = true;
                        else if (document.getElementById('Commute2').checked == true) flag = true;
                        else if (document.getElementById('AnotherJobOffer2').checked == true) flag = true;
                        else if (document.getElementById('BetterDesignation2').checked == true) flag = true;
                        else if (document.getElementById('Marriage2').checked == true) flag = true;
                        else if (document.getElementById('Other2').value != "") flag = true;

                        return flag;
                    }

                    function Rate1() {
                        var flag = false;

                        if (document.getElementById('Rate1e').checked == true) flag = true;
                        else if (document.getElementById('Rate1g').checked == true) flag = true;
                        else if (document.getElementById('Rate1f').checked == true) flag = true;
                        else if (document.getElementById('Rate1p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate2() {
                        var flag = false;

                        if (document.getElementById('Rate2e').checked == true) flag = true;
                        else if (document.getElementById('Rate2g').checked == true) flag = true;
                        else if (document.getElementById('Rate2f').checked == true) flag = true;
                        else if (document.getElementById('Rate2p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate3() {
                        var flag = false;

                        if (document.getElementById('Rate3e').checked == true) flag = true;
                        else if (document.getElementById('Rate3g').checked == true) flag = true;
                        else if (document.getElementById('Rate3f').checked == true) flag = true;
                        else if (document.getElementById('Rate3p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate4() {
                        var flag = false;

                        if (document.getElementById('Rate4e').checked == true) flag = true;
                        else if (document.getElementById('Rate4g').checked == true) flag = true;
                        else if (document.getElementById('Rate4f').checked == true) flag = true;
                        else if (document.getElementById('Rate4p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate5() {
                        var flag = false;

                        if (document.getElementById('Rate5e').checked == true) flag = true;
                        else if (document.getElementById('Rate5g').checked == true) flag = true;
                        else if (document.getElementById('Rate5f').checked == true) flag = true;
                        else if (document.getElementById('Rate5p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate6() {
                        var flag = false;

                        if (document.getElementById('Rate6e').checked == true) flag = true;
                        else if (document.getElementById('Rate6g').checked == true) flag = true;
                        else if (document.getElementById('Rate6f').checked == true) flag = true;
                        else if (document.getElementById('Rate6p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate7() {
                        var flag = false;

                        if (document.getElementById('Rate7e').checked == true) flag = true;
                        else if (document.getElementById('Rate7g').checked == true) flag = true;
                        else if (document.getElementById('Rate7f').checked == true) flag = true;
                        else if (document.getElementById('Rate7p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate8() {
                        var flag = false;

                        if (document.getElementById('Rate8e').checked == true) flag = true;
                        else if (document.getElementById('Rate8g').checked == true) flag = true;
                        else if (document.getElementById('Rate8f').checked == true) flag = true;
                        else if (document.getElementById('Rate8p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate9() {
                        var flag = false;

                        if (document.getElementById('Rate9e').checked == true) flag = true;
                        else if (document.getElementById('Rate9g').checked == true) flag = true;
                        else if (document.getElementById('Rate9f').checked == true) flag = true;
                        else if (document.getElementById('Rate9p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate10() {
                        var flag = false;

                        if (document.getElementById('Rate10e').checked == true) flag = true;
                        else if (document.getElementById('Rate10g').checked == true) flag = true;
                        else if (document.getElementById('Rate10f').checked == true) flag = true;
                        else if (document.getElementById('Rate10p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate11() {
                        var flag = false;

                        if (document.getElementById('Rate11e').checked == true) flag = true;
                        else if (document.getElementById('Rate11g').checked == true) flag = true;
                        else if (document.getElementById('Rate11f').checked == true) flag = true;
                        else if (document.getElementById('Rate11p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate12() {
                        var flag = false;

                        if (document.getElementById('Rate12e').checked == true) flag = true;
                        else if (document.getElementById('Rate12g').checked == true) flag = true;
                        else if (document.getElementById('Rate12f').checked == true) flag = true;
                        else if (document.getElementById('Rate12p').checked == true) flag = true;


                        return flag;
                    }

                    function Rate13() {
                        var flag = false;

                        if (document.getElementById('Rate13e').checked == true) flag = true;
                        else if (document.getElementById('Rate13g').checked == true) flag = true;
                        else if (document.getElementById('Rate13f').checked == true) flag = true;
                        else if (document.getElementById('Rate13p').checked == true) flag = true;


                        return flag;
                    }

                    function OverAll() {
                        var flag = false;
                        if (document.getElementById('OverAllYes').checked == false && document.getElementById('OverAllNo').checked == false)
                            flag = false;
                        else if (document.getElementById('OverAllNo').checked == true)
                            flag = true;
                        else if (document.getElementById('OverAllYes').checked == true) {
                            if (document.getElementById('<%= txtOverAll6.ClientID%>').value == "")
                                flag = false
                            else
                                flag = true;
                        }

                return flag;
            }

            function Validate() {
                var flag = 1;

                if (ValidateFirstSection() == false) {
                    flag = 0;
                    document.getElementById('Span1').innerHTML = "<font style='color:red;'><b>Please select any one option.</b></font>";
                }
                
                if (ValidateThirdSection() == false) {
                    flag = 0;
                    document.getElementById('Span3').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (document.getElementById('<%= Pleaseelaboratetheabovepoint2.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span4').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (Rate1() == false) {
                    flag = 0;
                    document.getElementById('Span5').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate2() == false) {
                    flag = 0;
                    document.getElementById('Span6').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate3() == false) {
                    flag = 0;
                    document.getElementById('Span7').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate4() == false) {
                    flag = 0;
                    document.getElementById('Span8').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate5() == false) {
                    flag = 0;
                    document.getElementById('Span9').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate6() == false) {
                    flag = 0;
                    document.getElementById('Span10').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate7() == false) {
                    flag = 0;
                    document.getElementById('Span11').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate8() == false) {
                    flag = 0;
                    document.getElementById('Span12').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate9() == false) {
                    flag = 0;
                    document.getElementById('Span13').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate10() == false) {
                    flag = 0;
                    document.getElementById('Span14').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate11() == false) {
                    flag = 0;
                    document.getElementById('Span15').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate12() == false) {
                    flag = 0;
                    document.getElementById('Span16').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                if (Rate13() == false) {
                    flag = 0;
                    document.getElementById('Span17').innerHTML = "<font style='color:red;'><b>Please select any one option</b></font>";
                }
                
                if (document.getElementById('<%= txtOverAll1.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span19').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll2.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span20').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll3.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span21').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll4.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span22').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll5.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span23').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (OverAll() == false) {
                    flag = 0;
                    document.getElementById('Span24').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll7.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span25').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll8.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span26').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }
                if (document.getElementById('<%= txtOverAll9.ClientID%>').value == "") {
                    flag = 0;
                    document.getElementById('Span27').innerHTML = "<font style='color:red;'><b>Required!</b></font>";
                }

                if (flag == 0)
                    return false;
                else
                    return true;
            }
                </script>

               <%-- <div class="control-group">
                    <label class="control-label">Please elaborate the above point</label>
                    <div class="controls">
                        <asp:TextBox ID="Pleaseelaboratetheabovepoint1" runat="server" TextMode="MultiLine" CssClass="span8"></asp:TextBox>&nbsp;<span id="Span2"></span>
                    </div>
                </div>--%>


                <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:900px; border-top:none; border-bottom:none ">
                    <h5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Other (specify) :</b></h5>&nbsp;<span id="Span3"></span>
                   
                    <div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">LAID OFF</label>
                                        <div class="controls">
                                            <input id="Relocation2" type="checkbox" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of work</label>
                                        <div class="controls">
                                            <input id="HigherEducation2" type="checkbox" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Abolition of position</label>
                                        <div class="controls">
                                            <input id="JobProfile2" type="checkbox" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of funds</label>
                                        <div class="controls">
                                            <input id="CompanyPolicy2" type="checkbox" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Termination</label>
                                        <div class="controls">
                                            <input id="Compensation2" type="checkbox" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <%--<div class="control-group">
                                        <label class="control-label">Benefits</label>
                                        <div class="controls">
                                            <input id="Benifits2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>--%>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                  <%--  <div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Supervisor / Reporting Manager</label>
                                        <div class="controls">
                                            <input id="Supervisor2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of Career Progression</label>
                                        <div class="controls">
                                            <input id="LackofCareerProgression2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Company Management</label>
                                        <div class="controls">
                                            <input id="CompanyManagement2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Health/Medical Reason</label>
                                        <div class="controls">
                                            <input id="HealthMedicalReason2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal</label>
                                        <div class="controls">
                                            <input id="Personal2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Retirement</label>
                                        <div class="controls">
                                            <input id="Retirement2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>--%>
                    <%--<div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Very Long Hours of Working</label>
                                        <div class="controls">
                                            <input id="VeryLongHoursofWorking2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Commute</label>
                                        <div class="controls">
                                            <input id="Commute2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Another Job Offer</label>
                                        <div class="controls">
                                            <input id="AnotherJobOffer2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Better Designation</label>
                                        <div class="controls">
                                            <input id="BetterDesignation2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Marriage</label>
                                        <div class="controls">
                                            <input id="Marriage2" type="radio" name="ReasonResponsible2" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Other</label>
                                        <div class="controls">
                                            <input id="Other2" type="text" class="span4" runat="server" style="width: 200px;" onfocus="Clear2();" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>--%>
                </div>
                <div class="control-group" style="border: 1px solid #e0e0e0; border-radius: 2px; width:900px; border-top:none">
                    <label class="control-label"><h5><b>Plans after Leaving :</b></h5></label>
                    <div class="controls">
                        <asp:TextBox ID="Pleaseelaboratetheabovepoint2" runat="server" TextMode="MultiLine" CssClass="span8"></asp:TextBox>&nbsp;<span id="Span4"></span>
                    </div>
                    <br />
                </div>
                
                <div class="row-fluid">
                    <div class="span10">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    PART ll: COMMENTS/SUGGESTIONS FOR IMPROVEMENT
                                </div>
                            </div>
                            <div class="widget-body">
                                <div class="widget" style="border:none">
                                         <label><b>We are interested in what our employees have to say about their work experience with us. Please complete this form. </b></label>
                                    </div>
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label"><b>1. What did you like most about your job?</b></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_like" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b>2. What did you like least about your job?</b></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_least" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b>3. How did you feel about the pay and benefits?</b></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_pay" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b>4. How did you feel about the following:</b></label>
                                        <div class="controls">
                                            <asp:Label ID="lblExcellent" runat="server" Text="Very-Satisfied"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblGood" runat="server" Text="Satisfied"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:Label ID="lblFair" runat="server" Text="Dissatisfied"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Opportunity to use your abilities</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate1e" type="radio" name="Rate1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate1g" type="radio" name="Rate1" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate1f" type="radio" name="Rate1" runat="server" />&nbsp;<span id="Span2"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Your supervisor’s management </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate2e" type="radio" name="Rate2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate2g" type="radio" name="Rate2" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate2f" type="radio" name="Rate2" runat="server" />&nbsp;<span id="Span5"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">The opportunity to talk with your Supervisor</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate3e" type="radio" name="Rate3" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate3g" type="radio" name="Rate3" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate3f" type="radio" name="Rate3" runat="server" />&nbsp;<span id="Span7"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">The information you received on </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate4e" type="radio" name="Rate4" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate4g" type="radio" name="Rate4" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate4f" type="radio" name="Rate4" runat="server" />&nbsp;<span id="Span8"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Promotion policies and practices</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate5e" type="radio" name="Rate5" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate5g" type="radio" name="Rate5" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate5f" type="radio" name="Rate5" runat="server" />&nbsp;<span id="Span9"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Discipline policies and practices</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate6e" type="radio" name="Rate6" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate6g" type="radio" name="Rate6" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate6f" type="radio" name="Rate6" runat="server" />&nbsp;<span id="Span10"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Performance review policies and </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate7e" type="radio" name="Rate7" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate7g" type="radio" name="Rate7" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate7f" type="radio" name="Rate7" runat="server" />&nbsp;<span id="Span12"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Physical working conditions</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate8e" type="radio" name="Rate8" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate8g" type="radio" name="Rate8" runat="server" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate8f" type="radio" name="Rate8" runat="server" />&nbsp;<span id="Span6"></span>
                                        </div>
                                    </div>
                            <div class="control-group">
                                <label>
                                    I have submitted all company belongings back i.e. (ID card, Keys, and Laptop etc.). In case of anything pendency at my end call me 
                                    <asp:TextBox ID="txt_phone" runat="server" CssClass="span10" style="border-top:none; border-left:none; border-right:none" Width="120px"></asp:TextBox>
                                    mail me<asp:TextBox ID="txt_mail" runat="server" CssClass="span10" style="border-top:none; border-left:none; border-right:none" Width="200px"></asp:TextBox>
                                    else the charges can be deducted from F&F. Details of F&F are :<br /><br />
                                    <asp:TextBox ID="txt_ff" runat="server" CssClass="span10" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                </label>
                            </div>
 
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span10">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    LATEST FAMILY INFORMATION AND CORRESPONDENCE ADDRESS
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label>This has reference to your resignation letter dated 
                                            <asp:TextBox ID="txtOverAll1" runat="server" CssClass="span10" style="border-top:none; border-left:none; border-right:none" Width="120px"></asp:TextBox>&nbsp;<span id="Span19"></span>
                                        In this regard we need to know your full and complete latest information.</label>
                                    </div>
                                    <div class="control-group">
                                        <label><b>Kindly fill in the following information.</b></label>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">a)	Permanent Address (Along with latest Tel/Cell Numbers): </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll2" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5"></asp:TextBox>&nbsp;<span id="Span20"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">b)	Present Address (Along with latest Tel/Cell Numbers): </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll3" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5"></asp:TextBox>&nbsp;<span id="Span21"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">c)	City, State/Province: </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll4" runat="server" CssClass="span10"></asp:TextBox>&nbsp;<span id="Span22"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">d)	Zip/Postal Code:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll5" runat="server" CssClass="span10"></asp:TextBox>&nbsp;<span id="Span23"></span>
                                        </div>
                                    </div>
                                    <%--<script type="text/javascript">

                                        function checkYes(checkbox) {
                                            if (checkbox.checked) {
                                                $('#<%=txtOverAll6.ClientID %>').show();
                                            }
                                            else {
                                                $('#<%=txtOverAll6.ClientID %>').hide();
                                            }
                                        }
                                        function checkNO(checkbox) {
                                            if (checkbox.checked) {
                                                $('#<%=txtOverAll6.ClientID %>').hide();
                                            }
                                            else {
                                                $('#<%=txtOverAll6.ClientID %>').show();
                                            }
                                        }
                                    </script>--%>
                                    <div class="control-group">
                                        <label><b>Family details:</b></label>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">e)	Father :</label>
                                        <div class="controls">
                                           <asp:TextBox ID="txtOverAll6" runat="server" CssClass="span10"></asp:TextBox>&nbsp;<span id="Span24"></span>
                                        </div>
                                    </div>
                                    <div class="control-group" id="divsus" runat="server">
                                        <label class="control-label">f)	Mother:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll7" runat="server" CssClass="span10"></asp:TextBox>&nbsp;<span id="Span25"></span>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">g)	Name of Husband /Wife(If applicable):</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll8" runat="server" CssClass="span10"></asp:TextBox>&nbsp;<span id="Span26"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">h)	References( at least 2 references and their correspondence address):</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll9" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5"></asp:TextBox>&nbsp;<span id="Span27"></span>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span10">
                        <div class="widget">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group" style="display: none;">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="DateOfClearence" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click" />
                                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnApprove_Click" OnClientClick="return Validate();" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />
                                        <asp:Button ID="Btn_Back" runat="server" CssClass="btn btn-primary" Text="BACK" OnClick="Btn_Back_Click" Visible="false" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdstaytype').dataTable({
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
    </form>
</body>
</html>

