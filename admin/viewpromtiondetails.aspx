<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewpromtiondetails.aspx.cs" Inherits="admin_viewpromtiondetails" %>

<!DOCTYPE html>

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
                        <h2>View Employee Details</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>
             
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
                                                    <td width="48%" class="frm-lft-clr123"><%--First Name--%>Employee Name
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123">
                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                        &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr id="Tr1" runat="server" visible="true">
                                                    <td class="frm-lft-clr123">Middle Name
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtmiddlename" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr id="Tr2" runat="server" visible="true">
                                                    <td class="frm-lft-clr123 border-bottom">Last Name
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr id="Tr44" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom">Suffix
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_suffix1" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>

                                                <tr id="Tr43" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom">Alias
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_alias_name" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>


                                            </table>
                                        </td>
                                        <td valign="top" style="padding-top: 0px">
                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 ">Employee Code
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123">
                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td width="48%" class="frm-lft-clr123 border-bottom">Employee No.
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td width="48%" class="frm-lft-clr123 border-bottom">Gender
                                                    </td>
                                                    <td width="52%" class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="height: 36px;">
                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Date Of Joining
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                        <asp:Label ID="doj" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="height: 36px;">
                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Effective From Date
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                        <asp:Label ID="lbl_effective_date" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                 <tr style="height: 36px;" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Systems Payable Number
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr45" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom">Suffix2
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_suffix2" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr46" runat="server" visible="false">
                                                    <td class="frm-lft-clr123 border-bottom">Suffix3
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="lbl_suffix3" runat="server"></asp:Label>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="Tr3" runat="server" visible="false">
                                                    <td id="Td1" width="48%" class="frm-lft-clr123 border-bottom" runat="server">Employee Photo
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
                            </fieldset>
                        </div>
                    </div>
                </div>



                <div class="row-fluid" runat="server" visible="true">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Job</li>
                                       
                                    </ol>
                                    <div style="height:auto">
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
                                                    <td colspan="1" class="txt02">Updated Work Information
                                                    </td>
                                                     <td colspan="1"  style="padding-left:120px;font-weight:bold;">Old Work Information
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

                                                                        <tr id="Tr4" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123"><%--Broad Group--%>Business Unit
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_broadgroup" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 36px;">
                                                                            <td width="43%" class="frm-lft-clr123">Branch<%--Work Location--%>
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
                                                                                <asp:Label ID="lbl_dept_type" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr5" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">department
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
                                                                        <tr id="Tr19" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Grade
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>


                                                                        <tr id="Tr6" style="height: 36px;" runat="server" visible="false">
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
                                                                        <tr id="Tr7" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Grade Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_gradetype" runat="server"></asp:Label>
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
                                                                            <td class="frm-lft-clr123 border-bottom">Employee Sub Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txtstafftype" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                      


                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Employee Role
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="tr8" runat="server" visible="False">
                                                                            <td colspan="2" style="height: 5px"></td>
                                                                        </tr>
                                                                        <tr id="trprobationperiod" runat="server" visible="False" style="height: 36px;">
                                                                            <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                            </td>
                                                                            <td id="Td2" class="frm-rght-clr123" runat="server" style="border-top: none;">
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
                                                                        <tr id="tr9" runat="server" visible="False">
                                                                            <td colspan="2" style="height: 5px"></td>
                                                                        </tr>
                                                                        <tr id="trconforimdate" runat="server" visible="false" style="height: 36px;">
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
                                                                            <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Last Working Day
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


                                                                        <tr id="Tr10" style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Salary Calculation From
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtsalary" runat="server" Width="100px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                          <tr style="height: 36px;">
                                                                            <td width="48%" class="frm-lft-clr123">Branch
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_old_branch" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                          <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Department
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_old_Department" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123">Designation
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_old_designation" runat="server" Width="142px" MaxLength="10"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 36px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 border-bottom">Grade
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_old_Grade" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                      
                                                                      

                                                                        <tr id="Tr11" style="height: 36px;" runat="server">
                                                                            <td class="frm-lft-clr123">Employee Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_old_Employee" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 36px;">
                                                                            <td class="frm-lft-clr123 border-bottom">Employee Sub Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_old_StaffType" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                       
                                                                         <tr>
                                                                            <td width="48%" class="frm-lft-clr123 border-bottom">Employee Role
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_old_Employeestatus" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" visible="false">
                                                                            <td width="48%" class="frm-lft-clr123 border-bottom">Adhar Card Available
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="Label13" runat="server"></asp:Label>
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

                                                                        <tr id="trnoticepriod2" runat="server" style="height: 36px;" visible="false">
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
                                                <tr runat="server" visible="false">
                                                    <td colspan="2" class="txt02">Payroll Details
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td height="10" colspan="2"></td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">Payroll Process Currency
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label5" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">Payment Mode
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label6" runat="server"></asp:Label>
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
                                                                            <td width="43%" class="frm-lft-clr123">PF Number
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="pfno" runat="server"></asp:Label>
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

                                                                       

                                                                        <tr id="Tr12" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 " width="48%">CTC Per Annum
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label8" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        

                                                                        <tr id="Tr13" runat="server" visible="false">
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

                                                                       
                                                                        <%--<tr>
                                                                            <td width="48%" class="frm-lft-clr123">Graduity Eligible Year
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:Label ID="Label14" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr id="Tr14" runat="server" visible="false">
                                                                            <td width="48%" class="frm-lft-clr123">ESI Dispensary
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr15" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 " width="48%">PF Region Office
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                       <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">Bank Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label10" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">Bank Branch Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label11" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">IFSC Code
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="ward" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                         <tr>
                                                                            <td class="frm-lft-clr123 " width="48%">Salary Account No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123  " width="52%">
                                                                                <asp:Label ID="Label7" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Account Type
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:Label ID="Label9" runat="server"></asp:Label>
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
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" runat="server" visible="false">
                                            <tr id="Tr16" runat="server" visible="false">
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
                                                                    EmptyDataText="No employee history exists !"
                                                                    class="table table-condensed table-striped table-hover table-bordered pull-left">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Updated Date">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l9" runat="server" Text='<%# Bind ("updated_date") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l0" runat="server" Text='<%# Bind ("EmpCode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="23%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Designation">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Department">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Branch">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l8" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Grade">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l7" runat="server" Text='<%# Bind ("gradename") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Accomodated Date">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l6" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employment Status">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l4" runat="server" Text='<%# Bind ("employeestatus") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="CTC Per Annum">
                                                                            <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                                            <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l5" runat="server" Text='<%# Bind ("ward") %>'></asp:Label>
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
