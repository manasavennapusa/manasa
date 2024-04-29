<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InterviewAnalysis2.aspx.cs" Inherits="recruitment_InterviewAnalysis2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery-1.3.2.min.js"></script>
    <script src="../js/jquery.min.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <script type="text/javascript">
        function validaterating() {
            return validateGroup(document.getElementsByName("Personality")) && validateGroup(document.getElementsByName("Academic")) && validateGroup(document.getElementsByName("Goal")) && validateGroup(document.getElementsByName("Communication")) && validateGroup(document.getElementsByName("Knowledge")) && validateGroup(document.getElementsByName("Learning")) && validateGroup(document.getElementsByName("Behavior")) && validateGroup(document.getElementsByName("Stability")) && validateGroup(document.getElementsByName("Experience")) && validateGroup(document.getElementsByName("Interest")) && validateGroup(document.getElementsByName("Skills")) && validateGroup(document.getElementsByName("Need")) && validateGroup(document.getElementsByName("Development")) && validateGroup(document.getElementsByName("Management")) && validateGroup(document.getElementsByName("Budget")) && validateGroup(document.getElementsByName("Overall")) && validateGroup(document.getElementsByName("Recomendation"))
        }

        function validateGroup(elements) {
            for (var i = 0; i < elements.length; i++) {
                if (elements[i].checked)
                    return true;
            }
            alert("Something went wrong.Please select Rating");
            return false;
        }
        function avg() {

            var personality = $("input[name=Personality]:checked").val();
            var academic = $("input[name=Academic]:checked").val();
            var goal = $("input[name=Goal]:checked").val();
            var comm = $("input[name=Communication]:checked").val();
            var know = $("input[name=Knowledge ]:checked").val();
            var learn = $("input[name=Learning]:checked").val();
            var behave = $("input[name=Behavior]:checked").val();
            var stability = $("input[name=Stability]:checked").val();
            var experience = $("input[name=Experience]:checked").val();
            var interest = $("input[name=Interest]:checked").val();
            var skill = $("input[name=Skills]:checked").val();
            var need = $("input[name=Need]:checked").val();
            var develop = $("input[name=Development]:checked").val();
            var manage = $("input[name=Management]:checked").val();
            var budget = $("input[name=Budget]:checked").val();

            //var cust = $("input[name=Customer]:checked").val();
            //var culter = $("input[name=Culter]:checked").val();
            var totalval = parseInt(typeof personality === "undefined" ? 0 : personality) + parseInt(typeof academic === "undefined" ? 0 : academic) + parseInt(typeof goal === "undefined" ? 0 : goal) + parseInt(typeof comm === "undefined" ? 0 : comm) + parseInt(typeof know === "undefined" ? 0 : know) + parseInt(typeof learn === "undefined" ? 0 : learn) + parseInt(typeof behave === "undefined" ? 0 : behave) + parseInt(typeof stability === "undefined" ? 0 : stability) + parseInt(typeof experience === "undefined" ? 0 : experience) + parseInt(typeof interest === "undefined" ? 0 : interest) + parseInt(typeof skill === "undefined" ? 0 : skill) + parseInt(typeof need === "undefined" ? 0 : need) + parseInt(typeof develop === "undefined" ? 0 : develop) + parseInt(typeof manage === "undefined" ? 0 : manage) + parseInt(typeof budget === "undefined" ? 0 : budget)


            var avgval = Math.round(totalval / 15, 0);

            if (avgval < 1)
                avgval = 1

            if (avgval == 1) {
                $("#Outstanding").attr('checked', true);
            }
            else
                if (avgval == 2) {
                    $("#VeryGood").attr('checked', true);
                }
                else
                    if (avgval == 3) {
                        $("#Good").attr('checked', true);
                    }
                    //else
                    //    if (avgval == 4) {
                    //        $("#Fair").attr('checked', true);
                    //    }
                        else
                            if (avgval == 4) {
                                $("#satisfact").attr('checked', true);
                            }
                            else {
                                $("#unsatis").attr('checked', true);
                            }
        }
    </script>
    <script type="text/javascript">
        function clearAllRadios() {
            var radList = document.getElementsByName('Personality');
            var radList1 = document.getElementsByName('Academic');
            var radList2 = document.getElementsByName('Goal');
            var radList3 = document.getElementsByName('Communication');
            var radList4 = document.getElementsByName('Knowledge');
            var radList5 = document.getElementsByName('Learning');
            var radList6 = document.getElementsByName('Customer');
            var radList7 = document.getElementsByName('Culter');
            var radList8 = document.getElementsByName('Overall');
            var radList9 = document.getElementsByName('Recomendation');
            var radList10 = document.getElementById('txtRemarks');
            var radList11 = document.getElementsByName('Behavior');
            var radList12 = document.getElementsByName('Stability');
            var radList13 = document.getElementsByName('Experience');
            var radList14 = document.getElementsByName('Interest');
            var radList15 = document.getElementsByName('Skills');
            var radList16 = document.getElementsByName('Need');
            var radList17 = document.getElementsByName('Development');
            var radList18 = document.getElementsByName('Management');
            var radList19 = document.getElementsByName('Budget');

            radList.value = false;
            radList1.value = false;
            radList2.value = false;
            radList3.value = false;
            radList4.value = false;
            radList5.value = false;
            radList6.value = false;
            radList7.value = false;
            radList8.value = false;
            radList9.value = false;
            radList10.value = "";
            radList11.value = false;
            radList12.value = false;
            radList13.value = false;
            radList14.value = false;
            radList15.value = false;
            radList16.value = false;
            radList17.value = false;
            radList18.value = false;
            radList19.value = false;
        }
   </script>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Interview Rating </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>CANDIDATES SELECTED IN ROUND 2
                                </div>
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-striped  table-bordered pull-left">
                                    <tbody>
                                        <tr>
                                            <td>RRF Code
                                            </td>
                                            <td>
                                                <asp:Label ID="lblrrfcode" runat="server"></asp:Label>
                                            </td>
                                            <td>Candidate Name
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCandidatename" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Qualification</td>
                                            <td>
                                                <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                            </td>
                                            <td>Skills
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSkills" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Experience
                                            </td>
                                            <td>
                                                <asp:Label ID="lblExperience" runat="server"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>

                                        <asp:HiddenField ID="hdcandidatecode" runat="server" />
                                    </tbody>
                                </table>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon=""></span>Interview Rating
                                </div>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-bordered no-margin">

                                    <thead>
                                        <tr>
                                            <th style="width: 3%">Functional</th>
                                            <th style="width: 5%">UnSatisfactory</th>
                                            <th style="width: 5%">Satisfactory</th>
                                            <th style="width: 3%">Good</th>
                                            <th style="width: 5%">Excellent</th>
                                            <th style="width: 5%">Exceptional</th>
                                            <th style="width: 5%">Not Applicable</th>
                                            <th>Particulars</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr onsubmit="check">
                                            <td>General/ Basic Knowledge</td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="optionsRadios2" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="Radio1" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="Radio2" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="Radio3" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="Radio4" value="2" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Personality" id="Radio40" value="1" onclick="avg();" /></td>
                                            <td>

                                                <p>
                                                    Basic knowledge of work related to the field as applicable (Accounting/ Payroll/Benefit/ US HR/ HR/PHP/Finance/ Taxation)
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Concepts and Standards</td>
                                            <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio5" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio6" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio7" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio8" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio9" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Academic" id="Radio41" value="1" onclick="avg();" /></td>
                                            <td>
                                                <p>
                                                    Understanding of concepts and standards as applicable 
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Advance Knowledge</td>
                                            <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio10" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio11" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio12" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio13" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio14" value="2" onclick="avg();" /></td>
                                              <td>
                                                <input type="radio" runat="server" name="Goal" id="Radio42" value="1" onclick="avg();" /></td>
                                            <td>
                                              
                                                <p>
                                                    Advance level of knowledge in respective field
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Software knowledge</td>
                                            <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio15" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio16" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio17" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio18" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio19" value="2" onclick="avg();" /></td>
                                              <td>
                                                <input type="radio" runat="server" name="Communication" id="Radio43" value="1" onclick="avg();" /></td>
                                            <td>
                                              
                                                <p>
                                                   Software knowledge in respective field
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Decision Making/ Trouble Shooting</td>
                                            <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio20" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio21" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio22" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio23" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio24" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Knowledge" id="Radio47" value="1" onclick="avg();" /></td>
                                            <td>
                                                
                                                <p>
                                                    Demonstrate decision making and trouble shooting skills in respective field
                                                </p>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Review/Analytical skills</td>
                                            <td id="Td1" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio25" value="6" onclick="avg();" /></td>
                                            <td id="Td2" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio26" value="5" onclick="avg();" /></td>
                                            <td id="Td3" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio27" value="4" onclick="avg();" /></td>
                                            <td id="Td4" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio28" value="3" onclick="avg();" /></td>
                                            <td id="Td5" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio29" value="2" onclick="avg();" /></td>
                                              <td id="Td6" style="border-bottom:1px solid #e0e0e0" runat="server">
                                                <input type="radio" runat="server" name="Learning" id="Radio48" value="1" onclick="avg();" /></td>
                                            <td id="Td7" style="border-bottom:1px solid #e0e0e0" runat="server">
                                             
                                                <p>
                                                   Demonstrate review and analytical skills in respective field
                                                </p>
                                            </td>
                                        </tr>
                                        <tr id="Tr1" runat="server" visible="false">
                                            <td>Customer Orientation</td>
                                            <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio30" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio31" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio32" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio33" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio34" value="2" /></td>
                                              <td>
                                                <input type="radio" runat="server" name="Customer" id="Radio49" value="1" /></td>
                                            <td>
                                                <h6>Customer Orientation:
                                                </h6>
                                                <p>
                                                    Alert to customer needs, develop & maintain relationships.
                                                </p>
                                            </td>
                                        </tr>
                                        <tr id="Tr2"  runat="server" visible="false">
                                            <td>Culture Fit</td>
                                            <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio35" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio36" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio37" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio38" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio39" value="2" onclick="avg();" /></td>
                                             <td>
                                                <input type="radio" runat="server" name="Culter" id="Radio50" value="1" onclick="avg();" /></td>
                                            <td>
                                                <h6>Culture Fit:
                                                </h6>
                                                <p>
                                                    Ability to fit himself/herself to the Escalon Business Services Pvt Ltd
                                                </p>
                                            </td>
                                        </tr>
                                        <tr id="Tr3" style="background-color:#f2f2f2" runat="server">
                                            <td id="Td8" style="background-color:#f2f2f2" runat="server"><b>HR</b></td>
                                            <td id="Td9" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td10" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td11" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td12" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td13" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td14" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td15" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                        </tr>
                                        <tr>
                                            <td>Behavior</td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio51" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio52" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio53" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio54" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio55" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Behavior" id="Radio56" value="1" onclick="avg();" /></td>
                                            <td id="Td16" runat="server" style="border-bottom:none">
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Stability</td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio57" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio58" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio59" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio60" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio61" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Stability" id="Radio62" value="1" onclick="avg();" /></td>
                                            <td id="Td17" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Relevant Experience</td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio63" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio64" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio65" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio66" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio67" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Experience" id="Radio68" value="1" onclick="avg();" /></td>
                                            <td id="Td18" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Interest in Profile</td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio69" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio70" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio71" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio72" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio73" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Interest" id="Radio74" value="1" onclick="avg();" /></td>
                                            <td id="Td19" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Communication Skills</td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio75" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio76" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio77" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio78" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio79" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Skills" id="Radio80" value="1" onclick="avg();" /></td>
                                            <td id="Td20" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Need</td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" id="Radio81" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" id="Radio82" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" id="Radio83" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" id="Radio84" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" id="Radio85" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Need" id="Radio86" value="1" onclick="avg();" /></td>
                                            <td id="Td21" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Self Development</td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" id="Radio87" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" id="Radio88" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" id="Radio89" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" id="Radio90" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" id="Radio91" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Development" id="Radio92" value="1" onclick="avg();" /></td>
                                            <td id="Td22" runat="server" style="border-bottom:none; border-top:none">
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Team Co-ordination/ Management</td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" id="Radio93" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" id="Radio94" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" id="Radio95" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" id="Radio96" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" id="Radio97" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Management" id="Radio98" value="1" onclick="avg();" /></td>
                                            <td id="Td23" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Package Budget</td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio99" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio100" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio101" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio102" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio103" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Budget" id="Radio104" value="1" onclick="avg();" /></td>
                                            <td id="Td24" runat="server" style="border-top:none">
                                                
                                            </td>
                                        </tr>
                                    </tbody>
                                    
                                </table>
                                <br />
                                <table class="table table-condensed table-bordered no-margin">
                                    <tr id="Tr4" runat="server">
                                        <td>Overall Assessment</td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="Outstanding" value="6" onclick="return false;"/>Exceptional
                                            </label>
                                        </td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="VeryGood" value="5" onclick="return false;"/>Excellent 
                                            </label>
                                        </td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="Good" value="4" onclick="return false;"/>Good</label></td>
                                        <%--<td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="Fair" value="3" onclick="return false;"/>Average </label></td>--%>
                                          <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="satisfact" value="2" onclick="return false;"/>Satisfactory </label></td>
                                          <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Overall" id="unsatis" value="1" onclick="return false;"/>Unsatisfactory </label></td>
                                       
                                    </tr>
                                    <tr id="Tr5" runat="server">
                                        <td>Panel's Recomendation</td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Recomendation" id="Radio44" value="3" />
                                                Selected</label></td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Recomendation" id="Radio45" value="2" />Not Selected</label></td>
                                        <td>
                                            <label class="radio inline">
                                                <input type="radio" runat="server" name="Recomendation" id="Radio46" value="1" />Put On Hold</label></td>
                                        <td></td>
                                         <td></td>
                                         
                                    </tr>

                                    <tr>
                                        <td>Remarks:</td>
                                        <td colspan="6">
                                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="400px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                                <table><tr><td><br /></td></tr></table>

                                <div class="form-actions no-margin">
                                    <asp:Button ID="btnInsert" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnInsert_Click" OnClientClick="return validaterating();" style="margin-left:600px" />&nbsp;&nbsp;
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="btn btn-info" OnClick="btnUpdate_Click" />&nbsp;&nbsp;
                                    <asp:Button ID="btnreset" runat="server" Text="Reset" CssClass="btn btn-info"  value="reset" OnClientClick="clearAllRadios()" />&nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info " OnClick="btnBack_Click" />
                                    
                                </div>
                            </div>

                        </div>
                    </div>

                </div>

            </div>
        </div>
    </form>

</body>
</html>
