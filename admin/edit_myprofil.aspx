<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_myprofil.aspx.cs" Inherits="admin_edit_myprofil"
    Title="SmartDrive Labs Technologies India Pvt. Ltd." %>

<%--<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
                        <h2>Employee View</h2>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information	
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
                                                                            <td width="43%" class="frm-lft-clr123"><%--First Name--%>Employee Name
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Gender
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
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

                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="48%" class="frm-lft-clr123 ">Employee Code
                                                                            </td>
                                                                            <td width="51%" class="frm-rght-clr123">
                                                                                <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Employee No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_card_no" runat="server"></asp:Label>
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
                                        <li>Personal Detail</li>
                                      <%--  <li>Health</li>--%>
                                        <li>Employee Upload Detail</li>
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

                                                                        <tr id="Tr3" style="height: 36px;"  runat="server" visible="false">
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
                                                                            <td class="frm-lft-clr123">Department
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>
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
                                                                        <tr id="Tr5" style="height: 36px;"  runat="server" visible="false">
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

                                                                        <tr id="trnoticepriod2" runat="server"  style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom">Notice Period on Confimation (in days)
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
                                                <tr>
                                                    <td colspan="2" class="txt02">Payroll Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
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
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs2">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <div>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td style="height: 34px" colspan="2" width="100%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="txt02">Present Address
                                                                                        </td>
                                                                                        <td class="txt02">Permanent Address
                                                                                   <td>
                                                                                       <table>
                                                                                           <tr>
                                                                                               <td>
                                                                                                   <asp:CheckBox ID="CheckBox1" runat="server" Text="" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                                                       AutoPostBack="True"></asp:CheckBox></td>
                                                                                               <td>Same as Present</td>

                                                                                           </tr>
                                                                                       </table>
                                                                                   </td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
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
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="span11" Width="" Height="60px" MaxLength="1000" placeholder="Max 1000 Chars.." Style="border: 1px solid #ddd" TextMode="MultiLine" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>


                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr10" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr11" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr12" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr13" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr14" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="span11" Width="" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr15" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="span11" Width="" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

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
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="54%">
                                                                                                        <asp:TextBox ID="txt_per_add1" runat="server" CssClass="span11" Width="" placeholder="Max 1000 Chars.." Height="60px" Style="border: 1px solid #ddd" TextMode="MultiLine" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr16" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr17" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddl_per_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr18" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_per_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr19" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr20" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_zip" runat="server" CssClass="span11" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr21" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_phone" runat="server" CssClass="span11" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>


                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="txt02">Emergency Contact Details:
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_name" placeholder="Max 50 Chars.." runat="server" CssClass="span11" Width="" onblur="capitalizeMe(this);"
                                                                                                            MaxLength="50"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Relation
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">

                                                                                                        <asp:DropDownList ID="drp_emg_relation" runat="server" CssClass="span11">
                                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                            <asp:ListItem Value="Spouse"> Spouse</asp:ListItem>
                                                                                                            <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                                                                                                            <asp:ListItem Value="Son">Son</asp:ListItem>
                                                                                                            <asp:ListItem Value="Father">Father</asp:ListItem>
                                                                                                            <asp:ListItem Value="Mother">Mother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother">Brother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother In law">Brother In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister In law">Sister In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister">Sister</asp:ListItem>
                                                                                                            <asp:ListItem Value="Uncle">Uncle</asp:ListItem>
                                                                                                            <asp:ListItem Value="Aunt">Aunt</asp:ListItem>
                                                                                                            <asp:ListItem Value="Neighbour">Neighbour</asp:ListItem>
                                                                                                            <asp:ListItem Value="Others">Others</asp:ListItem>

                                                                                                        </asp:DropDownList>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Contact No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_emg_ccode" runat="server" Width="38px" placeholder="Max 4 Chars.." MaxLength="4">+91</asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emergency_contactno" runat="server" CssClass="span11" Width="190px" placeholder="Max 10 Chars.."
                                                                                                            MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_emg_landcode" runat="server" Width="30px" placeholder="Max 4 Chars.." MaxLength="4">+91</asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlinestdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5"></asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlineno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                                            MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>

                                                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2">
                                                                                                        <asp:Button ID="btnemgcontact" runat="server" Text="Add" OnClick="btnemgcontact_Click" CssClass="btn btn-primary pull-right" OnClientClick="return ValidateEmg();" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="Tr23" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 1
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr24" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address2" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr25" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_country" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" OnSelectedIndexChanged="ddl_emergency_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr26" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_state" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" OnSelectedIndexChanged="ddl_emergency_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr27" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr28" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123 border-bottom">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                                        <asp:TextBox ID="txt_emergency_zipcode" runat="server" MaxLength="6" CssClass="blue1"
                                                                                                            Width="" onkeypress="return isNumber()"></asp:TextBox>

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
                                                                                        <td width="50%" valign="top"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="5">
                                                                                <div class="widget-content">
                                                                                    <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                        OnRowDeleting="gvemgcontact_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
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
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton
                                                                                                        ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                    </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Mode of Transport
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                            <label class="radio inline">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td style="width: 70px">
                                                                                                            <asp:RadioButton ID="optown" runat="server" Text="Own" GroupName="mode" AutoPostBack="True"
                                                                                                                OnCheckedChanged="optown_CheckedChanged" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:RadioButton ID="optcompany" runat="server" Text="Company Vehicle"
                                                                                                                GroupName="mode" AutoPostBack="True" OnCheckedChanged="optcompany_CheckedChanged" /></td>
                                                                                                </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top" style="display: none">
                                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">




                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">&#160;<asp:Label ID="lblpickuppoint" runat="server" Visible="false" Text="Pick Up point"></asp:Label>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%">&#160;<asp:TextBox ID="txtmodeoftransport" CssClass="span11" runat="server" MaxLength="50" placeholder="Max 50 Chars.."></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btncontact" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btncontact_Click" OnClientClick="return ValidateContact();" />
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">&#160;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>


                                    <div>
                                        <p>

                                            <!-- Professional Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs3">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress8" runat="server" AssociatedUpdatePanelID="updatepannel2d"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%">
                                                                    <tr class="frm-lft-clr-main">
                                                                        <td align="left">&nbsp;Educational Qualification :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_quali_add" OnClick="btn_quali_add_Click" runat="server" Text="Add" OnClientClick="return ValidateEducation();"
                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Educational Qualification"></asp:Button></td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">

                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">School / Institute / University Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-rght-clr12345" style="width: 150px">
                                                                            <asp:DropDownList ID="drp_edu_qualification" runat="server" AutoPostBack="true" CssClass="span11" OnSelectedIndexChanged="drp_edu_qualification_SelectedIndexChanged" Width="180px">
                                                                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                <asp:ListItem Value="1">Matric(10th)</asp:ListItem>
                                                                                <asp:ListItem Value="2">Intermediate(12th)</asp:ListItem>
                                                                                <asp:ListItem Value="3">Diploma</asp:ListItem>
                                                                                <asp:ListItem Value="4">Graduation</asp:ListItem>
                                                                                <asp:ListItem Value="others">Others</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedu_specilazation" runat="server" CssClass="span11" MaxLength="100" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;" placeholder="Max. 100 Char.." Width="110px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedush" runat="server" CssClass="span11" MaxLength="150" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;" placeholder="Max. 150 Char.." Width="240px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduper" runat="server" CssClass="span11" MaxLength="5" placeholder="Max. 5 Char.." Width="60px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedufrom" runat="server" CssClass="span11" MaxLength="4" ondrop="return false;" onkeypress="return IsNumeric(event);" onpaste="return false;" placeholder="Max. 4 Char.." Width="60px"></asp:TextBox>
                                                                            to
                                                                            <asp:TextBox ID="txteduto" runat="server" CssClass="span11" MaxLength="4" ondrop="return false;" onkeypress="return IsNumeric(event);" onpaste="return false;" placeholder="Max. 4 Char.." Width="60px"></asp:TextBox>
                                                                        </td>
                                                                    </tr>





                                                                    <tr id="div_Edu_Qual_others" runat="server">
                                                                        <td class="frm-rght-clr12345">
                                                                            <asp:TextBox ID="txt_Edu_Qual_others" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;" placeholder="Max. 50 Char.." Width="180px"></asp:TextBox>
                                                                        </td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>





                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    OnRowDeleting="grid_edu_education_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
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
                                                                                        <asp:TemplateField HeaderText="School / Institute / University Name ">
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
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#160;&nbsp;
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel3"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">Professional / Technical Qualification :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_pro_qual_add" OnClick="btn_pro_qual_add_Click" runat="server" OnClientClick="return ValidateProfessional();"
                                                                                Text="Add" CssClass="btn btn-primary" ToolTip="Click here to add Professional Qualification"
                                                                                ValidationGroup="pro_edu"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">Institute / University Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduc1" runat="server" placeholder="Max. 150 Char.." CssClass="span11" Width="165px" MaxLength="150" onblur="capitalizeMe(this);">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtpro_specilazation" placeholder="Max. 100 Char.." runat="server" CssClass="span11" Width="120px" MaxLength="100" onblur="capitalizeMe(this);"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtsch1" runat="server" placeholder="Max. 100 Char.." CssClass="span11" Width="240px" MaxLength="100" onblur="capitalizeMe(this);">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtper1" runat="server" placeholder="Max. 5 Char.." CssClass="span11" Width="60px" MaxLength="5"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtfrm1" runat="server" placeholder="Max. 4 Char.." CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>


                                                                            to
                                                                    <asp:TextBox ID="txtto1" runat="server" placeholder="Max. 4 Char.." CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" OnRowDeleting="grid_Pro_education_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress10" runat="server" AssociatedUpdatePanelID="UpdatePanel4"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">Experience Details :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_exp_add" OnClick="btn_exp_add_Click" runat="server" Text="Add" ValidationGroup="c"
                                                                                CssClass="btn btn-primary" OnClientClick="return ValidateCompany()"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="18%">Company Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="28%">Address / Location
                                                                        </td>
                                                                        <td class="td-head" width="20%">Designation<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="15%">Total Exp.(in years)
                                                                        </td>
                                                                        <td class="td-head" width="18%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtcomp1" runat="server" CssClass="span11" Width="140px" MaxLength="100" placeholder="Max. 100 Char.." onblur="capitalizeMe(this);"></asp:TextBox>


                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_com_local" runat="server" CssClass="span11" Width="230px" MaxLength="250" placeholder="Max. 250 Char.." onblur="capitalizeMe(this);"></asp:TextBox>


                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_EXp_designation" runat="server" CssClass="span11" Width="150px" MaxLength="50" placeholder="Max. 50 Char.." onblur="capitalizeMe(this);"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_total_exp" runat="server" CssClass="span11" Width="100px" MaxLength="5" placeholder="Max. 5 Char.." ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_total_exp"
                                                                                ValidationGroup="c" runat="server" ValidationExpression="\d{1,3}(\.\d{0,2})?$" ToolTip="Enter Correct Values"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_exp_from" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max. 4 Char.." onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                            to
                                                                    <asp:TextBox ID="txt_exp_to" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max. 4 Char.." onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>


                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" OnRowDeleting="grid_exp_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:HiddenField ID="hdf" runat="server" Value='<%# Eval("autoID") %>' />
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
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                                    <td>&#160;&nbsp;
                                                    </td>
                                                </tr>



                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="UpdatePanel7"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">Training Details :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_Training" OnClick="btn_Training_Click" runat="server" Text="Add" OnClientClick="return ValidateTraining();"
                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Training Details" ValidationGroup="Training"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="22%">Training Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="22%">Conducted By<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="15%">From
                                                                        </td>
                                                                        <td class="td-head" width="17%">To
                                                                        </td>
                                                                        <td class="td-head" width="24%">Remarks
                                                                        
                                                                        
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_TrProgram" runat="server" CssClass="span11" MaxLength="90" Width="180px" placeholder="Max. 100 Char.."></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_TrConductedBy" runat="server" CssClass="span11" Width="180px" MaxLength="90" placeholder="Max. 100 Char.."></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFromdate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image8" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender8" runat="server" PopupButtonID="Image8" TargetControlID="txtFromdate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" onblur="return TrainingCompareDates();"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image9" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender9" runat="server" PopupButtonID="Image9" TargetControlID="txtToDate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTrRemarks" runat="server" CssClass="span11" Width="180px" placeholder="Max. 500 Char.." MaxLength="500">

                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridTraning" runat="Server" Width="100%" OnRowDeleting="GridTraning_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                                    <td height="5">&#160;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upedu" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="upedu"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                                <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnprop" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnprop_Click" OnClientClick="return ValidateProp();" />
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
                                            <!-- Personal Details -->
                                            <asp:UpdatePanel ID="updatepanel8" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress13" runat="server" AssociatedUpdatePanelID="updatepanel8"
                                                        DisplayAfter="1">
                                                        <ProgressTemplate>
                                                            <div class="modal-backdrop fade in">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img src="../img/loading.gif" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0" id="li_tabs4" runat="server">
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
                                                            <td valign="top" colspan="2">
                                                                <table valign="top" cellspacing="0" cellpadding="0" width="1036px" border="0">
                                                                    <tr>
                                                                        <td valign="top" width="50%">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Date of Birth <span class=""></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                        <asp:TextBox ID="txt_DOB" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>

                                                                                        <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob" Format="dd-MMM-yyyy"
                                                                                            PopupButtonID="Image1">
                                                                                        </cc1:CalendarExtender>
                                                                                        <img src="../img/error1.gif" alt="" visible="false" id="imgerror" runat="server" />
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" style="height: 30px">Payment Mode <span class=""></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtnbank" runat="server" AutoPostBack="true"
                                                                                                Text="Bank" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /></label>
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtncheque" runat="server" AutoPostBack="true" Text="Cheque"
                                                                                                GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /></label>
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtncash" runat="server" AutoPostBack="true" Text="Cash"
                                                                                                GroupName="paymentmode" OnCheckedChanged="rbtncash_CheckedChanged" /></label>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Religion
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="54%">
                                                                                        <asp:TextBox ID="txtrelg" runat="server" placeholder="Max. 50 Char.." CssClass="span11" onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px;">
                                                                                    <td class="frm-lft-clr123 ">Blood Group <span class=""></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddlbloodgrp" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                                            <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                                            <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                                            <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                                            <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                                            <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                                            <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                                            <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                                            <asp:ListItem Value="A Rh-">A Rh-</asp:ListItem>
                                                                                            <asp:ListItem Value="A Rh+">A Rh+</asp:ListItem>
                                                                                            <asp:ListItem Value="B Rh-">B Rh-</asp:ListItem>
                                                                                            <asp:ListItem Value="B Rh+">B Rh+</asp:ListItem>
                                                                                            <asp:ListItem Value="AB Rh-">AB Rh-</asp:ListItem>
                                                                                            <asp:ListItem Value="AB Rh+">AB Rh+</asp:ListItem>
                                                                                            <asp:ListItem Value="O Rh-">O Rh-</asp:ListItem>
                                                                                            <asp:ListItem Value="O Rh+">O Rh+</asp:ListItem>
                                                                                            <asp:ListItem Value="HH(Bombay)">HH(Bombay)</asp:ListItem>
                                                                                            <asp:ListItem Value="A1+">A1+</asp:ListItem>
                                                                                        </asp:DropDownList>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="display: none">
                                                                                    <td class="frm-lft-clr123">D.L. No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_dl_no" placeholder="Max. 20 Char.." runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
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
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td align="left" style="height: 30px" class="frm-lft-clr123" width="45%">Bank Name for Salary<span class=""></span>
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123" width="55%">
                                                                                            <asp:DropDownList ID="ddl_bank_name" runat="server" CssClass="span11"
                                                                                                Height="" DataSourceID="SqlDataSource1" DataTextField="bankname" DataValueField="branchcode"
                                                                                                OnDataBound="ddl_bank_name_DataBound1">
                                                                                            </asp:DropDownList>
                                                                                            <asp:SqlDataSource
                                                                                                ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123">Bank Branch Name
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_bankbrachname" runat="server" placeholder="Max. 100 Char.." CssClass="span11" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123" width="45%">Account No. for Salary<span class=""></span>
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123" width="54%">
                                                                                            <asp:TextBox ID="txt_bank_ac" runat="server" CssClass="span11" placeholder="Max. 20 Char.." MaxLength="20" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123">IFSC code
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_ifsc" runat="server" CssClass="span11" MaxLength="11" placeholder="Max. 11 Char.."></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="a" runat="server" visible="false">
                                                                            <td align="left" class="frm-lft-clr123">Bank Name for Reimbursement
                                                                            </td>
                                                                            <td align="left" class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddl_bank_name_reimbursement" runat="server" CssClass="blue1"
                                                                                    DataSourceID="SqlDataSource2" DataTextField="bankname" DataValueField="branchcode"
                                                                                    OnDataBound="ddl_bank_name_reimbursement_DataBound">
                                                                                </asp:DropDownList>
                                                                                <asp:SqlDataSource
                                                                                    ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                            </td>
                                                                            <td>&#160;&nbsp;
                                                                            </td>
                                                                            <td align="left" class="frm-lft-clr123">Account No. for Reimbursement
                                                                            </td>
                                                                            <td align="left" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_bank_ac_reimbursement" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

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
                                                                                        <asp:TextBox ID="txtccode" runat="server" CssClass="span1" Width="50px" MaxLength="4">+91</asp:TextBox>
                                                                                        <asp:TextBox ID="txtmobileno" runat="server" placeholder="Max. 10 Char.." CssClass="span11" Width="190px" MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                        <asp:TextBox ID="txtperccode" runat="server" Width="30px" placeholder="Max 4 Chars.." MaxLength="4">+91</asp:TextBox>
                                                                                        <asp:TextBox ID="txtperstdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                        <asp:TextBox ID="txtperlandno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                            MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Passport No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_passportno" runat="server" CssClass="span11" placeholder="Max. 15 Char.." Width="" MaxLength="15"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Passport Issued Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_passportissueddate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image10" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_passportissueddate"
                                                                                                PopupButtonID="Image10" Format="dd-MMM-yyyy">
                                                                                            </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 ">Passport Expiry Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:TextBox ID="txt_passportexpdate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image7" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_passportexpdate"
                                                                                                PopupButtonID="Image7">
                                                                                            </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">T-Shirt Size
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddl_Tshirt" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">--Select Size--</asp:ListItem>
                                                                                            <asp:ListItem Value="38">38</asp:ListItem>
                                                                                            <asp:ListItem Value="39">39</asp:ListItem>
                                                                                            <asp:ListItem Value="40">40</asp:ListItem>
                                                                                            <asp:ListItem Value="42">42</asp:ListItem>
                                                                                            <asp:ListItem Value="44">44</asp:ListItem>
                                                                                        </asp:DropDownList>
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
                                                                                    <td class="frm-lft-clr123" width="45%">Personal Email Id
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="54%">
                                                                                        <asp:TextBox ID="txt_email" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="return validateEmail(this);"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Driving Licence No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_drli_no" runat="server" CssClass="span11" placeholder="Max. 20 Char.." Width="" MaxLength="20"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Driving Licence Issued Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_dr_iss_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();">

                                                                                        </asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image15" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txt_dr_iss_date"
                                                                                                PopupButtonID="Image15" Format="dd-MMM-yyyy">
                                                                                            </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 ">Driving Licence Expiry Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:TextBox ID="txt_dr_exp_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image16" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender16" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_dr_exp_date"
                                                                                                PopupButtonID="Image16">
                                                                                            </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>


                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">Shirt Size
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddl_ShirtSize" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">--Select Size--</asp:ListItem>
                                                                                            <asp:ListItem Value="S">S</asp:ListItem>
                                                                                            <asp:ListItem Value="M">M</asp:ListItem>
                                                                                            <asp:ListItem Value="L">L</asp:ListItem>
                                                                                            <asp:ListItem Value="XL">XL</asp:ListItem>
                                                                                            <asp:ListItem Value="XXL">XXL</asp:ListItem>
                                                                                        </asp:DropDownList>
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
                                                                                    <td class="txt02" colspan="2">Father&apos;s Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Father / Husband Name 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                        <asp:TextBox ID="txt_f_f_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr22" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_f_mname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr29" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_f_l_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                    </td>
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
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Marital Status
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddlpersonalstatus" runat="server" CssClass="span11"
                                                                                            Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="Unmarried" Value="UNMARRIED"></asp:ListItem>
                                                                                            <asp:ListItem Text="Married" Value="MARRIED"></asp:ListItem>
                                                                                            <asp:ListItem Text="Divorcee" Value="DIVORCEE"></asp:ListItem>
                                                                                            <asp:ListItem Text="Widow" Value="WIDOW"></asp:ListItem>
                                                                                            <asp:ListItem Text="Widower" Value="WIDOWER"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                <tr>
                                                                                    <td style="height: 13px" class="txt02" colspan="2">Mother&apos;s Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Mother Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_m_fname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr30" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_m_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr31" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_m_l_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                    </td>
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
                                                                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                                visible="false">
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
                                                                                                            <td class="frm-lft-clr123" width="45%">Spouse Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                                <asp:TextBox ID="txt_sp_fname" placeholder="Max. 50 Char.." runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr32" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Middle Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_sp_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr33" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123 border-bottom">Last Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:TextBox ID="txt_sp_lname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ControlToValidate="txt_sp_lname"
                                                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Date of Anniversary
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                                                <asp:TextBox ID="txt_doa" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onblur="return SpouseCompareDates();" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;<asp:Image
                                                                                                                    ID="Image2" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_doa" Format="dd-MMM-yyyy"
                                                                                                                    PopupButtonID="Image2">
                                                                                                                </cc1:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>



                                                                                                    </table>
                                                                                                </td>
                                                                                                <td valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                        <tr>
                                                                                                            <td class="txt02" colspan="2" height="5">&#160;&nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">Date of Birth
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                                                <asp:TextBox ID="txt_s_DOB" runat="server" placeholder="Select Date" CssClass="span11" Width="" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox><asp:Image
                                                                                                                    ID="Image14" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_s_DOB" Format="dd-MMM-yyyy"
                                                                                                                    PopupButtonID="Image14">
                                                                                                                </cc1:CalendarExtender>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Gender
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:DropDownList ID="ddl_s_gender" runat="server" CssClass="blue1"
                                                                                                                    Width="">
                                                                                                                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                    <asp:ListItem>Male</asp:ListItem>
                                                                                                                    <asp:ListItem>Female</asp:ListItem>
                                                                                                                </asp:DropDownList>
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
                                                                                                <td valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td style="height: 18px" class="txt02" colspan="3">Children Detail
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="33%">Name<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td class="frm-lft-clr123" width="32%">Gender<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td width="35%" class="frm-lft-clr123">Date of Birth<span class="star"></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-rght-clr123 border-bottom" style="border-right: none" width="33%">
                                                                                                                <asp:TextBox ID="txt_child_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                                                                <asp:DropDownList ID="ddl_child_gender" runat="server" CssClass="span11" Height=""
                                                                                                                    Width="100px">
                                                                                                                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                    <asp:ListItem>Male</asp:ListItem>
                                                                                                                    <asp:ListItem>Female</asp:ListItem>
                                                                                                                </asp:DropDownList>

                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="35%">
                                                                                                                <table width="100%">
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            <asp:TextBox ID="txt_child_Dob" placeholder="Select Date" runat="server" CssClass="span11" Width="150px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Image ID="Image3" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_child_Dob" Format="dd-MMM-yyyy"
                                                                                                                                PopupButtonID="Image3">
                                                                                                                            </cc1:CalendarExtender>

                                                                                                                        </td>
                                                                                                                        <td align="right">
                                                                                                                            <asp:UpdatePanel ID="upvv" runat="server">
                                                                                                                                <ContentTemplate>
                                                                                                                                    <asp:Button ID="btn_child_Add" OnClick="btn_child_Add_Click" runat="server" Text="Add" OnClientClick="return ValidateChildren();"
                                                                                                                                        CssClass="btn btn-primary" ToolTip="Click hare to add children detail"></asp:Button>
                                                                                                                                </ContentTemplate>
                                                                                                                            </asp:UpdatePanel>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="10px" colspan="3"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" colspan="3">
                                                                                                    <div class="widget-content">
                                                                                                        <asp:GridView ID="grid_child" runat="Server" Width="99%" OnRowDeleting="grid_child_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                                            HorizontalAlign="Left" CellPadding="4">
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
                                                                                                                <asp:TemplateField HeaderStyle-Width="9%">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link04"
                                                                                                                            Text="Delete"></asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top"></td>
                                                                                                <td valign="top"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30px; height: 9px"></td>
                                                            <td style="height: 9px" align="right"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnpersonal" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnpersonal_Click" OnClientClick="return ValidatePersonalDetails();" />
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

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
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                <tr>
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
