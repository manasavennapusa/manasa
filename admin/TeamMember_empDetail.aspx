<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TeamMember_empDetail.aspx.cs" Inherits="admin_TeamMember_empDetail"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee View" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/blue1.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            border-left: 1px solid #d9d9d9;
            border-top: 1px solid #d9d9d9;
            background: #fafafa;
            padding: 9px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #555;
            width: 46%;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>ctc
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="navbar hidden-desktop">
                    <div class="navbar-inner">
                        <div class="container">
                            <a data-target=".navbar-responsive-collapse" data-toggle="collapse" class="btn btn-navbar">
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                                <span class="icon-bar"></span>
                            </a>
                            <div class="nav-collapse collapse navbar-responsive-collapse">
                                <ul class="nav">
                                    <li>
                                        <a href="index.html">Dashboard</a>
                                    </li>

                                    <li>
                                        <a href="reports.html">Reports</a>
                                    </li>
                                    <li>
                                        <a href="forms.html">Basic Forms</a>
                                    </li>
                                    <li>
                                        <a href="extended-forms.html">Extended Forms</a>
                                    </li>
                                    <li>
                                        <a href="form-wizards.html">Form Wizard</a>
                                    </li>
                                    <li>
                                        <a href="graphs.html">Flot Charts</a>
                                    </li>
                                    <li>
                                        <a href="google-charts.html">Google Charts</a>
                                    </li>
                                    <li>
                                        <a href="animated-charts.html">Animated Charts</a>
                                    </li>
                                    <li>
                                        <a href="ui-elements.html">General Elements</a>
                                    </li>
                                    <li>
                                        <a href="clients-list.html">Clients List</a>
                                    </li>
                                    <li>
                                        <a href="messages.html">Messages</a>
                                    </li>
                                    <li>
                                        <a href="timeline.html">Timeline</a>
                                    </li>
                                    <li>
                                        <a href="pricing.html">Pricing Plans</a>
                                    </li>
                                    <li>
                                        <a href="grid.html">Grid Layout</a>
                                    </li>
                                    <li>
                                        <a href="icons.html">Buttons &amp; Icons</a>
                                    </li>
                                    <li>
                                        <a href="typography.html">Typography</a>
                                    </li>
                                    <li>
                                        <a href="tables.html">Static Tables</a>
                                    </li>
                                    <li>
                                        <a href="dynamic-tables.html">Dynamic Tables</a>
                                    </li>
                                    <li>
                                        <a href="gallery.html">Gallery</a>
                                    </li>
                                    <li>
                                        <a href="invoice.html">Invoice</a>
                                    </li>
                                    <li>
                                        <a href="calendar.html">Calendar</a>
                                    </li>
                                    <li>
                                        <a href="profile.html">Profile</a>
                                    </li>
                                    <li>
                                        <a href="error.html">404 Error</a>
                                    </li>
                                    <li>
                                        <a href="faq.html">Faq</a>
                                    </li>
                                    <li>
                                        <a href="login.html">Login</a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="page-header">
                    <div class="pull-left">
                        <h2>View Employee Information</h2>
                    </div>
                    <%--<div class="pull-right">
                        <ul class="stats">
                            <li class="color-first">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe0b3;"></span>
                                <div class="details">
                                    <span class="big">12</span>
                                    <span>New Tasks</span>
                                </div>
                            </li>
                            <li class="color-second hidden-phone">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>
                                <div class="details" id="date-time">
                                    <span>Date </span>
                                    <span>Day, Time</span>
                                </div>
                            </li>
                        </ul>
                    </div>--%>
                    <div class="clearfix"></div>
                </div>
                <%-- first div employee Information --%>
                <div class="row-fluid">

                    <div class="widget">

                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                            </div>
                        </div>

                        <div class="widget-body">
                            <fieldset>

                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="50%">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="48%">Title
                                                    </td>
                                                    <td class="frm-rght-clr123" width="52%">
                                                        <asp:Label ID="lblSalutation" runat="server" Width="142px"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123"><%--First Name--%>Employee Name
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123">
                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                        &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 border-bottom">Gender
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr1" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Middle Name
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtmiddlename" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr id="Tr2" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom">Last Name
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 border-bottom">Employee No.
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                            </table>
                                        </td>
                                        <td valign="top" style="padding-top: 4px">
                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 ">Employee Code
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123">
                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 border-bottom">Employee Photo
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123">
                                                        <%--  <asp:Label ID="Label3" runat="server"></asp:Label>--%>
                                                        <asp:Image ID="empimg" runat="server" Height="91px" Width="150px" ImageUrl="Upload/photo/image.jpg"></asp:Image>
                                                        &nbsp;
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                </td>
                                                </tr>

                            </fieldset>
                        </div>
                    </div>
                </div>



                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Job Detail</li>
                                        <li id="li_tabs_approver">Approver's Detail</li>
                                        <li>Contact Detail</li>
                                        <li>Professional</li>
                                        <%--<li>Personal Detail</li>--%>
                                        <%--  <li>Health</li>--%>
                                        <%--<li>Upload Documents</li>--%>
                                    </ol>
                                    <div>
                                        <p>
                                            <!-- Job Details -->

                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>

                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">Work Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                        <tr id="Tr3" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123"><%--Broad Group--%>Business Unit
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_broadgroup" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 36px;">
                                                                            <td width="43%" class="frm-lft-clr123"><%--Branch Name--%>Work Location
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_branch_name" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Department Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_dept_type" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Department
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Designation
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_desigination" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr4" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Grade
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr5" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="lbl_division_name" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <%--<tr>
                                                                            <td class="frm-lft-clr123">Sub Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_subgroup" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>




                                                                        <%--<tr>
                                                                            <td class="frm-lft-clr123">Entity
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_entity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>
                                                                        <tr id="Tr6" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Grade Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_gradetype" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>




                                                                        <tr style="height: 36px;">
                                                                            <td width="48%" class="frm-lft-clr123">Employee Role
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>


                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Employee Status
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="tr7" runat="server" visible="False">
                                                                            <td colspan="2" style="height: 5px"></td>
                                                                        </tr>
                                                                        <tr id="trprobationperiod" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                            </td>
                                                                            <td id="Td1" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                                <asp:Label ID="txt_probationperiod" runat="server" MaxLength="2"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trduptstart" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date
                                                                            </td>
                                                                            <td id="Td4" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                                <asp:Label ID="txt_deput_start_date" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="tr8" runat="server" visible="False">
                                                                            <td colspan="2" style="height: 5px"></td>
                                                                        </tr>
                                                                        <tr id="trconforimdate" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                <asp:Label ID="lblprob" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_confirmationdate" runat="server" Width="120px"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>
                                                                        <tr id="trDOL" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Date of Leaving
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                <asp:Label ID="txtdol" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trReasonL" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Reason for Leaving
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                <asp:Label ID="txtreason" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123" width="48%">Date of Joining
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="51%">
                                                                                <asp:Label ID="doj" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr9" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Salary Calculation From
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtsalary" runat="server" Width="100px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Official Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtoff_mobileno" runat="server" Width="142px" MaxLength="10"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Official Email Id
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_officialemail" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Employee Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txremployee_type" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Sub Employee Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtsubemployeetype" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom">Ext. Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txtext" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>


                                                                        <tr style="height: 36px; display: none">
                                                                            <td class="frm-lft-clr123"><%--Immediate Supervisor Name--%>Reporting Manager
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_supervisor" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 36px; display: none">
                                                                            <td class="frm-lft-clr123 "><%--Corporate Reporting Name--%>Functional Manager
                                                                            </td>
                                                                            <td class="frm-rght-clr123 ">
                                                                                <asp:Label ID="lbl_corp_report_name" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 36px; display: none">
                                                                            <td class="frm-lft-clr123 border-bottom"><%--Manager Name --%>Unit Head
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_hod" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>




                                                                        <%--<tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Salary Calculation From
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="txtsalary" runat="server"></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>--%>

                                                                        <tr id="trprobationdate" runat="server" visible="False" style="height: 36px;">
                                                                            <td id="Td5" class="frm-lft-clr123" runat="server" style="border-top: none;">Notice Period During Probation (in days)
                                                                            </td>
                                                                            <td id="Td6" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                                <asp:Label ID="txt_probation_date" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="trduptenddate" runat="server" visible="False" style="height: 36px;">
                                                                            <td id="Td7" class="frm-lft-clr123 border-bottom" runat="server" style="border-top: none;">Deputation End Date
                                                                            </td>
                                                                            <td id="Td8" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                                <asp:Label ID="txt_deput_end_date" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="trnoticepriod2" runat="server" style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom">Notice Period
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_noticePeriod" runat="server" MaxLength="2"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <%-- <tr>
                                                                        <td colspan="2" height="5"></td>
                                                                    </tr>--%>


                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="15"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" visible="false">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td colspan="2" class="txt02">Cost Center
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="lbl_cc_groupid" runat="server">
                                                                                </asp:Label>

                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_cc_code" runat="server">
                                                                                </asp:Label>

                                                                            </td>
                                                                        </tr>

                                                                        <tr id="trcc" runat="server" visible="false">
                                                                            <td colspan="2">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="52%" style="border-top: none;">
                                                                                            <asp:Label ID="lbl_cc_country" runat="server" Height="20px">
                                                                                            </asp:Label>

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">State
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:Label ID="lbl_cc_state" runat="server" Height="20px">
                                                                                            </asp:Label>

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">City
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:Label ID="lbl_cc_city" runat="server" Height="20px">
                                                                                            </asp:Label>

                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom">Location
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:Label ID="lbl_cc_location" runat="server"
                                                                                                Width="147px">
                                                                                            </asp:Label>

                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                </table>

                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                        <tr>
                                                                            <td colspan="2" class="txt02">Additional Cost Center
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="51%">
                                                                                <asp:Label ID="lbl_acc_groupid" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_acc_code" runat="server">
                                                                                </asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="traddcc" runat="server" visible="false">
                                                                            <td colspan="2">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                                                                                            <asp:Label ID="lbl_acc_country" runat="server" Height="20px">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">State
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:Label ID="lbl_acc_state" runat="server" Height="20px">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123">City
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123">
                                                                                            <asp:Label ID="lbl_acc_city" runat="server" Height="20px">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom">Location
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:Label ID="lbl_acc_location" runat="server" Height="20px">
                                                                                            </asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height="5" colspan="2"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr style="visibility: hidden">
                                                    <td colspan="2" class="txt02">Payroll Details
                                                    </td>
                                                </tr>
                                                <tr style="visibility: hidden;height:1px">
                                                    <td height="1" colspan="2"></td>
                                                </tr>
                                                <tr style="visibility: hidden;height:1px">
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0" hidden="hidden">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">CTC Per Annum
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="ward" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="43%" class="frm-lft-clr123">PF Number
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="pfno" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">PAN Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="panno" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">UAN Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_uan" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                                        <tr id="sss" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">PT No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_ptno" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="48%" class="frm-lft-clr123">ESI Dispensary
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">PF Region Office
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="esino" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <tr>
                                                <td colspan="2">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee History
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div1" class="example_alt_pagination">
                                                                <asp:GridView ID="EmpHistGrid"
                                                                    runat="server"
                                                                    DataKeyNames="empcode"
                                                                    AutoGenerateColumns="False"
                                                                    EmptyDataText="No such employee exists !"
                                                                    class="table table-condensed table-striped table-hover table-bordered pull-left">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("EmpCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Designation">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Department">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Role">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("role") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                    </Columns>
                                                                    <HeaderStyle CssClass="" />
                                                                    <FooterStyle CssClass="" />
                                                                    <RowStyle Height="5px" />
                                                                    <PagerStyle CssClass=""></PagerStyle>
                                                                </asp:GridView>

                                                                <div class="clearfix"></div>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </p>
                                    </div>
                                    <div>
                                        <p>

                                            <!-- Approver Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                <tr>
                                                    <td colspan="2" class="txt02" style="height: 25px">Approver's Information
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Line Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txtreportmanager" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Dotted Line Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="txtdottedlinemanager" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Business Head
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txtbusinesshead" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Account Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="txtfncmang" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123 " width="48%">Admin
                                                                            </td>
                                                                            <td class="frm-rght-clr123 " width="52%">
                                                                                <asp:Label ID="txtadmin" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">HR 
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="txthr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">HR-C&B 
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="txthrcb" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">HRD 
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="txthrd" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Management/MD
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="txtmng" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="15" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">Clearance   Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                        <ContentTemplate>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Departmental Clearance
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txtdeptclr" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">General Administration Clearance
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:Label ID="txtadminclr" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Accounts Department Clearance
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:Label ID="txtaccdeptclr" runat="server"></asp:Label>

                                                                                    </td>
                                                                                </tr>


                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">Network Administration Clearance
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="txtnetworkclr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">HR Department Clearance
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="txthrdeptclr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">User Account Deletion Request
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="txtaccdeleclr" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="2"></td>
                                                </tr>

                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Contact Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td height="5"></td>
                                                                                        <td class="txt02"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02" align="center">Present Address
                                                                                        </td>
                                                                                        <td class="txt02" align="center">Permanent Address
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02">&nbsp;
                                                                                        </td>
                                                                                        <td class="txt02">&nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="43%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="57%">
                                                                                                        <asp:Label ID="txt_pre_add1" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr10" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="43%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="57%">
                                                                                                        <asp:Label ID="txt_pre_add2" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr11" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_pre_city" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr12" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_pre_state" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr13" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_pre_country" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr14" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr15" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>


                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                        <asp:Label ID="txt_per_add1" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr16" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_add2" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr17" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr18" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr19" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr20" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr21" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>



                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02">Emergency Contact Details:
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td height="10"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <div class="widget-body">
                                                                                                            <div id="dt_example" class="example_alt_pagination">
                                                                                                                <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                                                    AutoGenerateColumns="False" AllowSorting="True" Style="border-top: 1px solid #e0e0e0"
                                                                                                                    CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">

                                                                                                                    <Columns>
                                                                                                                        <asp:TemplateField HeaderText="Emg. Contact Name">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Emg. Contact Relation">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Emg. Contact No. ">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                        <asp:TemplateField HeaderText="Emg. LandLine No.">
                                                                                                                            <ItemTemplate>
                                                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                                                                                                            </ItemTemplate>
                                                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                                            <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                                                                        </asp:TemplateField>
                                                                                                                    </Columns>
                                                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                                </asp:GridView>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="43%">Mode of Transport
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="57%">
                                                                                                        <asp:Label ID="lblmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top" style="display: none">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">




                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="50%">Pick Up Point
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="50%">
                                                                                                        <asp:Label ID="txtmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>

                                            <!-- Professional Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="frm-lft-clr-main">Educational Qualification :
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True"
                                                                                    CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Education">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Specialization">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="School / Institute / University Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade / %">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label
                                                                                                    ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr-main">Professional / Technical Qualification :
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 1px;">
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                                    HorizontalAlign="Left" CellPadding="4" BorderWidth="0px">

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Education" HeaderStyle-Width="21%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Specialization" HeaderStyle-Width="21%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Institute / University Name" HeaderStyle-Width="30%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade / %" HeaderStyle-Width="13%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="13%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr-main">Experience Details :
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 1px;">
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="30%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr-main">Training Details :
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 1px;">
                                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td>
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridTraning" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="trainingname"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTraning" runat="Server" Text='<%# Eval("trainingname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Conducted By" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblConductedBy" runat="Server" Text='<%# Eval("personname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="From" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("fromdate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="To" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltodate" runat="Server" Text='<%# Eval("todate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Personal Details -->
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0" style="visibility:hidden">
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" colspan="2">Personal Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="45%">Date of Birth
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                <asp:Label ID="txt_DOB" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Payment Mode
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lblpaymentmode" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" border="0" align="right">
                                                                        <tr style="height: 37px">
                                                                            <td class="frm-lft-clr123" width="45%">Religion
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                <asp:Label ID="txtrelg" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 ">Blood Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123 ">
                                                                                <asp:Label ID="txtbloodgrp" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 37px; display: none">
                                                                            <td class="frm-lft-clr123 border-bottom">D.L. No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_dl_no" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <div id="paymentmode" runat="server" visible="true" align="center">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="50%">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" align="right" border="0">
                                                                            <tr>
                                                                                <td align="left" class="frm-lft-clr123" width="45%">Bank Name for Salary
                                                                                </td>
                                                                                <td align="left" class="frm-rght-clr123" width="55%">
                                                                                    <asp:Label ID="txt_bank_name" runat="server"></asp:Label>&nbsp;
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td align="left" class="frm-lft-clr123">Bank Branch Name
                                                                                </td>
                                                                                <td align="left" class="frm-rght-clr123">
                                                                                    <asp:Label ID="txt_bankbrachname" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </td>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                            <tr>
                                                                                <td align="left" class="frm-lft-clr123" width="45%">Account No. for Salary
                                                                                </td>
                                                                                <td align="left" class="frm-rght-clr123" width="55%">
                                                                                    <asp:Label ID="txt_bank_ac" runat="server" Width="142px"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td align="left" class="frm-lft-clr123">IFSC code
                                                                                </td>
                                                                                <td align="left" class="frm-rght-clr123">
                                                                                    <asp:Label ID="txt_ifsc" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                    <td align="left" class="frm-lft-clr123">
                                                                        Bank Name for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_bank_name_reimbursement" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" class="frm-lft-clr123">
                                                                        Account No for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_bank_ac_reimbursement" runat="server" Width="142px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="5" height="5">
                                                                    </td>
                                                                </tr>--%>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="45%">Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                <asp:Label ID="txtmobileno" runat="server" Width="142px" MaxLength="10"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                <asp:Label ID="land" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Passport No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_passportno" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 ">Passport Expiry Date
                                                                            </td>
                                                                            <td class="frm-rght-clr123 ">
                                                                                <asp:Label ID="txt_passportexpdate" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Passport Issued Date
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_passportissueddate" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">T-Shirt Size
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_Tshirt" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="45%">Personal Email Id
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                <asp:Label ID="txt_email" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Driving Licence No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_drli_no" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Driving Licence Issued Date
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txt_dr_iss_date" runat="server">

                                                                                </asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 ">Driving Licence Expiry Date
                                                                            </td>
                                                                            <td class="frm-rght-clr123 ">
                                                                                <asp:Label ID="txt_dr_exp_date" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>


                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Shirt Size
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_ShirtSize" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" colspan="2" height="5">Relationship Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Father / Husband Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                <asp:Label ID="txt_f_f_name" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txt02" colspan="2" height="5">Employee Marital Status
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="43%">Marital Status
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Mother's Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="555">
                                                                                <asp:Label ID="txt_m_fname" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 12px" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td style="height: 13px" class="txt02" colspan="2">Spouse Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">&nbsp;<asp:Label ID="txt_sp_fname" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2" height="5">&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Date of Anniversary
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:Label ID="txt_doa" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td style="width: 86px" class="frm-lft-clr123">Date of Birth
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:Label ID="txt_sp_dob" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td style="width: 86px" class="frm-lft-clr123 border-bottom">Gender
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                        <asp:Label ID="txt_sp_gender" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">Children Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" align="left" colspan="2">&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" colspan="2">
                                                                                            <div class="widget-content">
                                                                                                <asp:GridView ID="grid_child" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                                    HorizontalAlign="Left" CellPadding="4" EmptyDataText="No Data Found">
                                                                                                    <Columns>
                                                                                                        <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                </asp:GridView>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" width="50%"></td>
                                                                                        <td valign="top"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 14px"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>


                                    <div id="divhealth" runat="server" visible="false">
                                        <p>
                                            <!-- Health Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                <tr>
                                                    <td colspan="2" class="txt02" style="height: 25px">Select Health Insurance Package
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr style="height: 50px">

                                                                            <td class="frm-lft-clr123" width="40%">BENEFITS 
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                <asp:Label ID="lblbenefits" runat="server"></asp:Label>
                                                                        </tr>

                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) INDIVIDUAL PLAN
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                <asp:Label ID="lblindivibual" runat="server"></asp:Label>
                                                                            </td>

                                                                        </tr>

                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF FOUR 
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                <asp:Label ID="lblplanfour" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF SIX 
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                <asp:Label ID="lblplansix" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 30px; height: 9px"></td>
                                                                            <td style="height: 9px" align="right"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>

                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>


                                                <tr>
                                                    <td style="height: 12px" colspan="2"></td>
                                                </tr>

                                            </table>

                                        </p>
                                    </div>


                                    <div>
                                        <p>
                                            <!-- Employee Upload Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" style="visibility:hidden">
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02" style="height: 13px">Upload Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr id="Tr22" runat="server" visible="false">
                                                    <td class="frm-lft-clr123" width="40%">Employee Photo
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <a id="A1" runat="server" class="link05">
                                                            <asp:Label ID="lblphoto" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">
                                                        <asp:Label ID="lbl_Default1" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <a id="dftlink1" runat="server" class="link05">
                                                            <asp:Label ID="lbldft1" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default2" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink2" runat="server" class="link05">
                                                            <asp:Label ID="lbldft2" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default3" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink3" runat="server" class="link05">
                                                            <asp:Label ID="lbldft3" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default4" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink4" runat="server" class="link05">
                                                            <asp:Label ID="lbldft4" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default5" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink5" runat="server" class="link05">
                                                            <asp:Label ID="lbldft5" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default6" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink6" runat="server" class="link05">
                                                            <asp:Label ID="lbldft6" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default7" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink7" runat="server" class="link05">
                                                            <asp:Label ID="lbldft7" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default8" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink8" runat="server" class="link05">
                                                            <asp:Label ID="lbldft8" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default9" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink9" runat="server" class="link05">
                                                            <asp:Label ID="lbldft9" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123 ">
                                                        <asp:Label ID="lbl_Default10" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <a id="dftlink10" runat="server" class="link05">
                                                            <asp:Label ID="lbldft10" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123 ">
                                                        <asp:Label ID="lbl_Default11" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 ">
                                                        <a id="dftlink11" runat="server" class="link05">
                                                            <asp:Label ID="lbldft11" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">
                                                        <asp:Label ID="lbl_Default12" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <a id="dftlink12" runat="server" class="link05">
                                                            <asp:Label ID="lbldft12" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">
                                                        <asp:Label ID="lbl_Default13" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <a id="dftlink13" runat="server" class="link05">
                                                            <asp:Label ID="lbldft13" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">
                                                        <asp:Label ID="lbl_Default14" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <a id="dftlink14" runat="server" class="link05">
                                                            <asp:Label ID="lbldft14" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
            </div>
        </div>

    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script type="text/javascript">
        $("#wizard").bwizard();
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
</body>
</html>
