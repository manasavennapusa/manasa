<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PerformanceQualities.aspx.cs" Inherits="appraisal_PerformanceQualities" %>

<%--Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee Master View" %>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
 <meta charset="utf-8" />
    <title>Mactay</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <%-- taken from appraisaldetails.aspx --%>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>

    <script src="../js/JavaScriptValidations.js"></script>

    <style type="text/css">
        .star
        {
            color: red;
        }

        .auto-style9
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 34px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style16
        {
            color: #555;
            width: 259px;
            border-left: 1px solid #d9d9d9;
            border-right: 1px solid #d9d9d9;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #ffffff;
        }

        .auto-style17
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 66px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style19
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 688px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style24
        {
            width: 930px;
        }

        .auto-style25
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 49px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style26
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 65px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style29
        {
            width: 876px;
        }

        .auto-style31
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 146px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }

        .auto-style32
        {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 69px;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }
    </style>

    <%--end taken from appraisaldetails.aspx --%>


    <%-- this will make the asterisk red in color --%>
    <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>
    <%--end this will make the asterisk red in color --%>
    <style>
        .table th, .table td
        {
            padding: 10px;
            line-height: 20px;
            text-align: left;
            vertical-align: inherit;
            /*border-top:inherit;*/
        }
    </style>
    <style>
        .rbshipcons
        {
            margin-left: 15px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            display: inline;
            position: relative;
        }

        .rbppcol
        {
            margin-left: 45px;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 14px;
            display: inline;
            position: relative;
        }

        .txtOrigin
        {
            margin-left: 15px;
            font-family: Arial;
            font-size: 14px;
            text-decoration: none;
            max-width: 73px;
        }
    </style>

</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
            function disableBtn(btnID, newText) {

                var btn = document.getElementById(btnID);
                setTimeout("setImage('" + btnID + "')", 60000);
                btn.disabled = true;
                btn.value = newText;
            }

            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(12501270608.gif)';
            }



        </script>
        <script type="text/javascript">
            function isKey(keyCode) {
                return false;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Section-2</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>


                            <%-- start of the thing --%>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title" data-icon="&#xe14a;">
                                            &nbsp;<a title="Performance Qualities">Performance Qualities</a>
                                        </div>
                                    </div>
                                    <div id="section2">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div>



                                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%"><b>
                                                                <center>Sl No</center>
                                                            </b>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <b>
                                                                    <center> Performance Oualities</center>
                                                                </b>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <b>
                                                                    <center>Definition</center>
                                                                </b>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <b>
                                                                    <center> Rating</center>
                                                                </b>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <b>
                                                                    <center> Score</center>
                                                                </b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <center><asp:Label ID="lb1" runat="server">1</asp:Label></center>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance1" runat="server">Knowledge of Job</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                 <asp:Label ID="Labeldef1" runat="server">Sound understanding of job requirements</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate1" runat="server" AutoPostBack="true" Width="220px" Height="32" OnSelectedIndexChanged="ddlrate1_SelectedIndexChanged" >
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox8" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="lb2" runat="server">2</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance2" runat="server">Product Knowledge</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                 <asp:Label ID="Labeldef2" runat="server">Knowledge of Mactay's bouquet of products/services and efficient management of this knowledge. 95% attendance on product knowledge training scheduled by HR</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate2" runat="server" Width="220px" Height="32" AutoPostBack="true" OnSelectedIndexChanged="ddlrate2_SelectedIndexChanged" >
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="TextBox1" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="lb3" runat="server">3</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance3" runat="server">Develops Self</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <asp:Label ID="Labeldef3" runat="server">Strives for learning and growth both professionally and personally.</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate3" runat="server" Width="220px" Height="32"  AutoPostBack="true" OnSelectedIndexChanged="ddlrate3_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="TextBox2" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="lb4" runat="server">4</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                 <asp:Label ID="lblperformance4" runat="server">Customer/ Service Orientation</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                 <asp:Label ID="Labeldef4" runat="server">Understands Mactay's customers' needs, anticipating those needs and giving high priority to customer satisfaction while at the same time balancing the needs of the organisation. Commitment to providing service to all customers </asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate4" runat="server" Width="220px" Height="32"  AutoPostBack="true" OnSelectedIndexChanged="ddlrate4_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox3" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                               <asp:Label ID="lb5" runat="server">5</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance5" runat="server">Time Management and Punctuality</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <asp:Label ID="Labeldef5" runat="server">Managing time effectively so that the right time is allocated to the right activity: ability to prioritize work according to urgency and making the best use of time.</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate5" runat="server" Width="220px" Height="32"  AutoPostBack="true" OnSelectedIndexChanged="ddlrate5_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox4" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                               <asp:Label ID="lb6" runat="server">6</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                 <asp:Label ID="lblperformance6" runat="server">Attitude to work/Interpersonal Ability</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <asp:Label ID="Labeldef6" runat="server">Demonstrates strong skills in establishing and maintaining healthy & co-operative relationships with team members as well as customer.  Attitude to work, team members, instructions , responsibilities etc</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                 <asp:DropDownList ID="ddlrate6" runat="server" Width="220px" Height="32"  AutoPostBack="true" OnSelectedIndexChanged="ddlrate6_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox5" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="lb7" runat="server">7</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance7" runat="server">Result-Oriented</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <asp:Label ID="Labeldef7" runat="server">Ability to think through the job and focus on results. Also aim to achieve maximum result based on clear and measurable agreement made upfront.</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate7" runat="server" Width="220px" Height="32"  OnSelectedIndexChanged="ddlrate7_SelectedIndexChanged" AutoPostBack="true">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                 <asp:TextBox ID="TextBox6" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                               <asp:Label ID="lb8" runat="server">8</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblperformance8" runat="server">Resource Management</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="50%">
                                                                <asp:Label ID="Labeldef8" runat="server">Manages internal and external resources efficiently (people, information, technologies, time, and capital). Effective usage, maintaining proper filing and cataloguing of emails received by creating folders for storage of different mails at all times.</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                 <asp:DropDownList ID="ddlrate8" runat="server" Width="220px" Height="32"  AutoPostBack="true" OnSelectedIndexChanged="ddlrate8_SelectedIndexChanged">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="2.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="5">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="7.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="12.5">Outstanding</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox7" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>



                                                    </table>

                                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="70%">
                                                               <center> <asp:Label ID="Label4" runat="server" width="50px" >TOTAL</asp:Label></center>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txt_totalrate" runat="server" align="center" Width="205px" Height="30" ></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txt_totalscore" runat="server" onblur="add2();" align="center" Height="30px" Width="132px" ></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>

                                                    
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                                                <asp:Button ID="btn_sbmit" runat="server" Style="margin-right: 5px" CssClass="btn btn-info pull-right " Text="Submit" OnClick="btn_sbmit_Click" OnClientClick="return ValidateOD();" />
                                                            </div>
                                </div>
                            </div>



                        </ContentTemplate>
                    </asp:UpdatePanel>
                  
                </div>
            </div>
        </div>

    </form>
</body>
</html>
<%--<script type="text/javascript">

    function add2() {

        var a = document.getElementById('TextBox8').value;
        var b = document.getElementById('TextBox1').value;
        var c = document.getElementById('TextBox2').value;
        var d = document.getElementById('TextBox3').value;
        var e = document.getElementById('TextBox4').value;
        var f = document.getElementById('TextBox5').value;
        var g = document.getElementById('TextBox6').value;
        var h = document.getElementById('TextBox7').value;
        var result = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e) + parseFloat(f) + parseFloat(g) + parseFloat(h);
        document.getElementById("txt_totalscore").value = result;


    }
</script>--%>
