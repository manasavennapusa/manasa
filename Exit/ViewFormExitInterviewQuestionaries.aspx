<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFormExitInterviewQuestionaries.aspx.cs" Inherits="Exit_ViewFormExitInterviewQuestionaries" %>

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
<head id="Head1"  runat="server" >
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

    <form id="myForm"  runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1"  runat="server" ></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Exit Interview Questionnaire </h2>
                    </div>
                    <br />
                    <br />
                    <br />
                    <div id="Div1" runat="server" style="border: 1px solid #e0e0e0; padding-left:10px; border-radius: 2px; width:1080px; background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#f2f2f2));">
                       
                   <h5><span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>&nbsp;&nbsp;Employee Details:</h5>
                            
                </div>
                   <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:1090px; border-top:none">
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
                                            <asp:Label ID="txt_stsalary" runat="server" Width="160px" style="padding-top:6px"></asp:Label>
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
                                    </div>
                                    <br />--%>
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
                                            <asp:Label ID="txt_endsalary" runat="server"  Width="200px" style="padding-top:6px"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    
                </div>

                    <div class="clearfix"><br /></div>
                <div id="Div2" runat="server" style="border: 1px solid #e0e0e0; padding-left:10px; border-radius: 2px; width:1080px; background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#f2f2f2));">
                       
                   <h5><span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>&nbsp;&nbsp;PART l:  REASONS FOR LEAVING</h5>
                            
                </div>
                <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:1090px; border-bottom:none; border-top:none">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>RESIGNATION :</b>
                    <br />
                    <br />
                    <div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Took another position</label>
                                        <div class="controls">
                                            <input id="Relocation1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Home/family needs</label>
                                        <div class="controls">
                                            <input id="HigherEducation1" type="checkbox" runat="server" readonly="true" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Poor health/physical disability</label>
                                        <div class="controls">
                                            <input id="JobProfile1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Relocation to another city</label>
                                        <div class="controls">
                                            <input id="CompanyPolicy1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Travel difficulties</label>
                                        <div class="controls">
                                            <input id="Compensation1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To attend Education</label>
                                        <div class="controls">
                                            <input id="Benifits1" type="checkbox" runat="server" readonly="true"/>
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
                                            <input id="Supervisor1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -work</label>
                                        <div class="controls">
                                            <input id="LackofCareerProgression1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -supervisor</label>
                                        <div class="controls">
                                            <input id="CompanyManagement1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction -co-workers</label>
                                        <div class="controls">
                                            <input id="HealthMedicalReason1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction– working Conditions</label>
                                        <div class="controls">
                                            <input id="Personal1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Dissatisfaction with benefits</label>
                                        <div class="controls">
                                            <input id="Retirement1" type="checkbox" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    
                </div>
                <div class="control-group" runat="server" visible="false">
                    <label class="control-label">Please elaborate the above point</label>
                    <div class="controls">
                        <asp:TextBox ID="Pleaseelaboratetheabovepoint1"  runat="server" disabled="disabled"  TextMode="MultiLine" CssClass="span8"></asp:TextBox>
                    </div>
                </div>


                <div class="row-fluid" style="border: 1px solid #e0e0e0; border-radius: 2px; width:1090px; border-top:none; border-bottom:none ">
                    <h5>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Other (specify) :</b></h5>&nbsp;<span id="Span3"></span>
                   
                    <div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">LAID OFF</label>
                                        <div class="controls">
                                            <input id="Relocation2" type="checkbox" name="ReasonResponsible2" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of work</label>
                                        <div class="controls">
                                            <input id="HigherEducation2" type="checkbox" name="ReasonResponsible2" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Abolition of position</label>
                                        <div class="controls">
                                            <input id="JobProfile2" type="checkbox" name="ReasonResponsible2" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of funds</label>
                                        <div class="controls">
                                            <input id="CompanyPolicy2" type="checkbox" name="ReasonResponsible2" runat="server" readonly="true"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Termination</label>
                                        <div class="controls">
                                            <input id="Compensation2" type="checkbox" name="ReasonResponsible2" runat="server" readonly="true"/>
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
                    <%--<div class="span3">
                        <div class="widget" style="border: none;">
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Supervisor / Reporting Manager</label>
                                        <div class="controls">
                                            <input id="Supervisor2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Lack of Career Progression</label>
                                        <div class="controls">
                                            <input id="LackofCareerProgression2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Company Management</label>
                                        <div class="controls">
                                            <input id="CompanyManagement2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Health/Medical Reason</label>
                                        <div class="controls">
                                            <input id="HealthMedicalReason2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal</label>
                                        <div class="controls">
                                            <input id="Personal2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Retirement</label>
                                        <div class="controls">
                                            <input id="Retirement2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
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
                                            <input id="VeryLongHoursofWorking2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Commute</label>
                                        <div class="controls">
                                            <input id="Commute2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Another Job Offer</label>
                                        <div class="controls">
                                            <input id="AnotherJobOffer2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Better Designation</label>
                                        <div class="controls">
                                            <input id="BetterDesignation2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Marriage</label>
                                        <div class="controls">
                                            <input id="Marriage2" type="radio" name="ReasonResponsible2"  runat="server" disabled="disabled"  />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Other</label>
                                        <div class="controls">
                                            <input id="Other2" type="text" class="span4"  runat="server" disabled="disabled"  style="width: 200px;" />
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>--%>
                </div>
               <div class="control-group" style="border: 1px solid #e0e0e0; border-radius: 2px; width:1090px; border-top:none">
                    <label class="control-label"><h5><b>Plans after Leaving :</b></h5></label>
                    <div class="controls">
                        <asp:TextBox ID="Pleaseelaboratetheabovepoint2" runat="server" TextMode="MultiLine" readonly="true" CssClass="span8"></asp:TextBox>&nbsp;<span id="Span4"></span>
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
                                            <asp:TextBox ID="txt_like" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px" readonly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b>2. What did you like least about your job?</b></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_least" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px" readonly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"><b>3. How did you feel about the pay and benefits?</b></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_pay" runat="server" TextMode="MultiLine" CssClass="span8" Width="610px" readonly="true"></asp:TextBox>
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
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate1e" type="radio" name="Rate1" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate1g" type="radio" name="Rate1" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate1f" type="radio" name="Rate1" runat="server" readonly="true"/>&nbsp;<span id="Span2"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Your supervisor’s management </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate2e" type="radio" name="Rate2" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate2g" type="radio" name="Rate2" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate2f" type="radio" name="Rate2" runat="server" readonly="true"/>&nbsp;<span id="Span5"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">The opportunity to talk with your Supervisor</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate3e" type="radio" name="Rate3" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate3g" type="radio" name="Rate3" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate3f" type="radio" name="Rate3" runat="server" readonly="true"/>&nbsp;<span id="Span7"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">The information you received on </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate4e" type="radio" name="Rate4" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate4g" type="radio" name="Rate4" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate4f" type="radio" name="Rate4" runat="server" readonly="true"/>&nbsp;<span id="Span8"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Promotion policies and practices</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate5e" type="radio" name="Rate5" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate5g" type="radio" name="Rate5" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate5f" type="radio" name="Rate5" runat="server" readonly="true"/>&nbsp;<span id="Span9"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Discipline policies and practices</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate6e" type="radio" name="Rate6" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate6g" type="radio" name="Rate6" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate6f" type="radio" name="Rate6" runat="server" readonly="true"/>&nbsp;<span id="Span10"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Performance review policies and </label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate7e" type="radio" name="Rate7" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate7g" type="radio" name="Rate7" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate7f" type="radio" name="Rate7" runat="server" readonly="true"/>&nbsp;<span id="Span12"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Physical working conditions</label>
                                        <div class="controls">
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp<input id="Rate8e" type="radio" name="Rate8" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate8g" type="radio" name="Rate8" runat="server" readonly="true"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input id="Rate8f" type="radio" name="Rate8" runat="server" readonly="true"/>&nbsp;<span id="Span6"></span>
                                        </div>
                                    </div>
                            <div class="control-group">
                                <label>
                                    I have submitted all company belongings back i.e. (ID card, Keys, and Laptop etc.). In case of anything pendency at my end call me 
                                    <asp:TextBox ID="txt_phone" runat="server" CssClass="span10" style="border-top:none; border-left:none; border-right:none" Width="120px" ReadOnly="true"></asp:TextBox>
                                    mail me<asp:TextBox ID="txt_mail" runat="server" CssClass="span10" style="border-top:none; border-left:none; border-right:none" Width="200px" ReadOnly="true"></asp:TextBox>
                                    else the charges can be deducted from F&F. Details of F&F are :<br /><br />
                                    <asp:TextBox ID="txt_ff" runat="server" CssClass="span10" TextMode="MultiLine" Rows="4" readonly="true"></asp:TextBox>
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
                                            <asp:TextBox ID="txtOverAll2" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span20"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">b)	Present Address (Along with latest Tel/Cell Numbers): </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll3" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span21"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">c)	City, State/Province: </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll4" runat="server" CssClass="span10" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span22"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">d)	Zip/Postal Code:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll5" runat="server" CssClass="span10" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span23"></span>
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
                                           <asp:TextBox ID="txtOverAll6" runat="server" CssClass="span10" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span24"></span>
                                        </div>
                                    </div>
                                    <div class="control-group" id="divsus" runat="server">
                                        <label class="control-label">f)	Mother:</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll7" runat="server" CssClass="span10" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span25"></span>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">g)	Name of Husband /Wife(If applicable):</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll8" runat="server" CssClass="span10" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span26"></span>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">h)	References( at least 2 references and their correspondence address):</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtOverAll9" runat="server" CssClass="span10" TextMode="MultiLine" Rows="5" ReadOnly="true"></asp:TextBox>&nbsp;<span id="Span27"></span>
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
                                    <div class="control-group">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence"  runat="server" disabled="disabled"  CssClass="span4"></asp:TextBox>                                           
                                        </div>
                                    </div>  
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" runat="server" visible="false">
                    <div class="span12">
                        <div class="widget" style="width:76px; float:right; height:46px ">
                            <div class="widget-header" style="border-bottom: none; height:36px">
                                <div class="pull-right">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                    </div>
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

