<%@ Page Language="C#" AutoEventWireup="true" CodeFile="appraisaldetails.aspx.cs" Inherits="appraisal_geetha" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head2" runat="server">


    <meta charset="utf-8">

    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>

    <link href="../icomoon/style.css" rel="stylesheet" />
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
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
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

    <%-- start --%>





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






    <%-- end --%>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Create Appraisal</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Appraisal
                                </div>
                            </div>


                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li id="li_tabs_business"><a>Business Grouth</a></li>
                                        <li id="li_tabs_relationship">Releationship Management</li>
                                        <li id="li_tabs_hrbp">HRBP Supervision</li>
                                        <li id="li_tabs_sla">Compliance And Implements of SLA's</li>
                                        <li id="li_tabs_payroll">Payroll Management</li>

                                    </ol>
                                    <div>
                                        <p>
                                            <!-- Business Grouth -->
                                            <asp:UpdatePanel ID="kk" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="kk"
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
                                                    <div class="row-fluid">
                                                        <div class="widget">
                                                            <div class="widget-header">
                                                                <div class="title" data-icon="&#xe14a;">
                                                                    &nbsp; Business Growth
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <fieldset>
                                                                    <div>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <%-- first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%"><b>
                                                                                    <center>Sl No</center>
                                                                                </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <b>
                                                                                        <center>Performance Outcomes/Targets</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">
                                                                                    <b>
                                                                                        <center>Achivements</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Weight</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Rating</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Score</center>
                                                                                    </b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--end first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Label6" runat="server">1</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance1" runat="server">Retain and Grow existing account by 20% in this business year(2016)</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="txtachive1" TabIndex="1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox65" TabIndex="2" runat="server" onblur="mul();add2();add1();" align="center" Height="30px" Width="132px" placeholder="0"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrateing1" TabIndex="3" runat="server" onchange="mul();add1();" AutoPostBack="False" align="center" Width="150px">
                                                                                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore1" runat="server" TabIndex="5" align="center" Height="30px" Width="132px" Text="0"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Label5" runat="server">2</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance2" runat="server">A minimum of 4 referrals per annum</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="txtachive2" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox66" runat="server" align="center" onblur="mul2();add1();add2();" Height="30px" Width="132px" placeholder="0"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating2" runat="server" onchange="mul2();add1();" AutoPostBack="False" align="center" Width="150px">
                                                                                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore2" runat="server" align="center" Height="30px" Width="132px" Text="0"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Label7" runat="server">3</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance3" runat="server">Attend a minimum of 2 HR conferences in 2016(including completed health and safety certifications)</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="txtachive3" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox67" runat="server" align="center" onblur="mul3();add1();add2();" Height="30px" Width="132px" placeholder="0"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating3" runat="server" onchange="mul3();add1();" AutoPostBack="False" align="center" Width="150px">
                                                                                        <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                        <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                        <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                        <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                        <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                        <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore3" runat="server" align="center" Height="30px" Width="132px" Text="0"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="70%">
                                                                                    <center><b>Total</b></center>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox68" runat="server" align="center" Height="30px" onblur="add2();" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:Label ID="lblRating1" runat="server" Height="30px" Width="150px" Text=""></asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore4" runat="server" align="center" onblur="add1();" Height="30px" Width="132px" Text="0"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>


                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Releationship Management -->

                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="kk"
                                                        DisplayAfter="1">
                                                    </asp:UpdateProgress>

                                                    <div class="row-fluid">
                                                        <div class="widget">
                                                            <div class="widget-header">
                                                                <div class="title" data-icon="&#xe14a;">
                                                                    &nbsp;Releationship Management
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <fieldset>
                                                                    <div>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <%-- first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%"><b>
                                                                                    <center>Sl No</center>
                                                                                </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <b>
                                                                                        <center>Performance Outcomes/Targets</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">
                                                                                    <b>
                                                                                        <center>Achivements</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Weight</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Rating</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center>Score</center>
                                                                                    </b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--end first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label1" runat="server">1</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                     <asp:label id="lblperformance4" runat="server">KNOW YOU CUSTOMER (KYC) Maintain the records of all Key Contacts; this record to include but not limited to DOB, Work Anniversaries, etc.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox4" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox7" runat="server" onblur="mul4();add3();add4();" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating4" runat="server" onchange="mul4();add4();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:textbox id="txtscore5" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                     <asp:label id="Label2" runat="server">2</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance5" runat="server">Conduct quarterly meetings with Key Account contacts</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                  <asp:textbox id="TextBox6" runat="server" textmode="MultiLine" align="center"></asp:textbox>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox11" runat="server" align="center" onblur="mul5();add3();add4();" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating5" runat="server" onchange="mul5();add4();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore6" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label3" runat="server">3</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance6" runat="server">95% Successful Client queries resolution within 48hrs</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox9" runat="server" textmode="MultiLine" align="center"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox18" runat="server" align="center" onblur="mul6();add3();add4();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating6" runat="server" onchange="mul6();add4();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="txtscore7" runat="server" align="center" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label8" runat="server">4</asp:label> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance7" runat="server">Attend to email request within 2hrs</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox14" runat="server" textmode="MultiLine" align="center"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox22" runat="server" align="center" onblur="mul7();add3();add4();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                  <asp:dropdownlist id="ddlrating7" runat="server" onchange="mul7();add4();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore8" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="70%">
                                                                                    <center><b>Total</b></center>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox12" runat="server" align="center" onblur="add3();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:Label ID="Label4" runat="server" Height="30px" Width="150px" Text=""></asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox13" runat="server" align="center" onblur="add4();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                        </table>


                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>

                                                </ContentTemplate>
                                            </asp:UpdatePanel>

                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <!-- HRBP Supervision -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                              

                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="kk"
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
                                                                            <%-- start here--%>
                                                                              <div class="row-fluid">
                                                        <div class="widget">
                                                            <div class="widget-header">
                                                                <div class="title" data-icon="&#xe14a;">
                                                                    &nbsp; HRBP Supervision
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <fieldset>
                                                                    <div>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <%-- first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%"><b>
                                                                                    <center>Sl No</center>
                                                                                </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <b>
                                                                                        <center> Performance Outcomes/Targets</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">
                                                                                    <b>
                                                                                        <center>Achivements</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Weight</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Rating</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Score</center>
                                                                                    </b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--end first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label9" runat="server">1</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                     <asp:label id="lblperformance8" runat="server">Submit salary information to Sector Head as stipulated</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox2" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox26" runat="server" align="center" onblur="mul8();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating8" runat="server" onchange="mul8();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore9" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label10" runat="server">2</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance9" runat="server">Send pay on or before 22nd of every month</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox5" runat="server" textmode="MultiLine" align="center"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox32" runat="server" align="center" onblur="mul9();add5();add6();" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating9" runat="server" onchange="mul9();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore10" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label11" runat="server">3</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance10" runat="server">Ensure all duly filled pensionn scheme forms for new steff are submitted to HR 48hours after resumption</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox10" runat="server" textmode="MultiLine" align="center"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox35" runat="server" align="center" onblur="mul10();add5();add6();" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating10" runat="server" onchange="mul10();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore11" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label12" runat="server">4</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance11" runat="server">Place all new recruits on the HMO scheme 48hours after resumption.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox16" runat="server" textmode="MultiLine" align="center"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox37" runat="server" align="center" onblur="mul11();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating11" runat="server" onchange="mul11();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="txtscore12" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label13" runat="server">5</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                     <asp:label id="lblperformance12" runat="server">Submit invoice to the clients on or before 10th & 21st of the month.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox21" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox38" runat="server" align="center" onblur="mul12();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating12" runat="server" onchange="mul12();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore13" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label14" runat="server">6</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance13" runat="server">Ensure 100% pension registration of all employees and 100% health care registration of all employees within the first week of employment.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox24" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox40" runat="server" align="center" onblur="mul13();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:dropdownlist id="ddlrating13" runat="server" onchange="mul13();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore14" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label15" runat="server">7</asp:label> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                   <asp:label id="lblperformance14" runat="server">Providing timely information to the HR unit for induction and orientation ceremony on new recruits before resumption of duties at least 24 hours before induction</asp:label> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox27" runat="server" textmode="MultiLine"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox41" runat="server" align="center" onblur="mul14();add5();add6();" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating14" runat="server" onchange="mul14();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="txtscore15" runat="server" align="center" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label16" runat="server">8</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance15" runat="server">Provide assistance to the HR team to recruit qualified candidates within 5 working days of receiving an official email from the client.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox30" runat="server" textmode="MultiLine"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:textbox id="TextBox46" runat="server" align="center" onblur="mul15();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating15" runat="server" onchange="mul15();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore16" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label17" runat="server">9</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance16" runat="server">Provide support with interviewing and screening candidates based on the client's specification with a minimum of 20% rejection rate from our clients.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox33" runat="server" textmode="MultiLine"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox47" runat="server" align="center" onblur="mul16();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:dropdownlist id="ddlrating16" runat="server" onchange="mul16();add6();" align="center" autopostback="false" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore17" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label18" runat="server">10</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance17" runat="server">Implement disciplinary actions within 48 hours upon request from the client.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                  <asp:textbox id="TextBox36" runat="server" textmode="MultiLine"></asp:textbox>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox48" runat="server" align="center" onblur="mul17();add5();add6();" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:dropdownlist id="ddlrating17" runat="server" onchange="mul17();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore18" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:label id="Label19" runat="server">11</asp:label> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                   <asp:label id="lblperformance18" runat="server">100% resolution of queries from external employees</asp:label>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:textbox id="TextBox39" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox49" runat="server" align="center" onblur="mul18();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:dropdownlist id="ddlrating18" runat="server" onchange="mul18();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore19" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label20" runat="server">12</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                     <asp:label id="lblperformance19" runat="server">Submit a weekly report on/before 3.00 pm activities at client's location</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox42" runat="server" textmode="MultiLine"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox50" runat="server" align="center" onblur="mul19();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:dropdownlist id="ddlrating19" runat="server" onchange="mul19();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="txtscore20" runat="server" align="center" height="30px" width="132px"></asp:textbox> 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:label id="Label21" runat="server">13</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:label id="lblperformance20" runat="server">Conduct quarterly meeting inviting PFA, HMO and other insurance oranizations.</asp:label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:textbox id="TextBox45" runat="server" textmode="MultiLine"></asp:textbox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="TextBox51" runat="server" align="center" onblur="mul20();add5();add6();" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:dropdownlist id="ddlrating20" runat="server" onchange="mul20();add6();" autopostback="false" align="center" width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:dropdownlist> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:textbox id="txtscore21" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="70%">
                                                                                    <center><b>Total</b></center>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox52" runat="server" align="center" height="30px" width="132px"></asp:textbox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:Label ID="Label22" runat="server" Height="30px" Width="150px" Text=""></asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:textbox id="TextBox20" runat="server" align="center" height="30px" width="132px"></asp:textbox> 
                                                                                </td>

                                                                            </tr>
                                                                        </table>


                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>
                                                                           
                                                                            <%-- end here --%>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div class="form-actions no-margin">
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>

                                                            </tr>
                                                            <%--     <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <div class="form-actions no-margin">
                                                                            <asp:Button ID="buthrbp" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="buthrbp_Click" OnClientClick="return ValidateData();" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <!-- Compliance And Implements of SLA's -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                               

                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="kk"
                                                                                DisplayAfter="1">
                                                                                <ProgressTemplate>
                                                                                    <div class="modal-backdrop fade in">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>

                                                                            <div class="row-fluid">
                                                        <div class="widget">
                                                            <div class="widget-header">
                                                                <div class="title" data-icon="&#xe14a;">
                                                                    &nbsp; Compliance and Implementsation of SLA's 
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <fieldset>
                                                                    <div>
                                                                           
                                                                         <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <%-- first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%"><b>
                                                                                    <center>Sl No</center>
                                                                                </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <b>
                                                                                        <center> Performance Outcomes/Targets</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">
                                                                                    <b>
                                                                                        <center>Achivements</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Weight</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Rating</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Score</center>
                                                                                    </b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--end first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:Label ID="Labelcom1" runat="server">1</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance21" runat="server">Ensure new recruits outstanding documents are completely filed and Handed over to HR within 5 days</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:TextBox ID="TextBox43" runat="server" align="center" onblur="mul21();add7();add8();" Height="30px" Width="132px"></asp:TextBox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating21" runat="server" onchange="mul21();add8();" AutoPostBack="false" align="center" Width="150px">
                                                                                                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore22" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                  <asp:Label ID="Labelcom2" runat="server">2</asp:Label>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance22" runat="server">Liaise with Compliance team on a 100% insurance coverage for all employees and insurance claims filed with 48hrs</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                  <asp:TextBox ID="TextBox8" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>  
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox54" runat="server" align="center" onblur="mul22();add7();add8();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:DropDownList ID="ddlrating22" runat="server" onchange="mul22();add8();" AutoPostBack="false" align="center" Width="150px">
                                                                                                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            </asp:DropDownList> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:TextBox ID="txtscore23" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox> 
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Labelcom3" runat="server">3</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">	
                                                                                    <asp:Label ID="lblperformance23" runat="server">Liaise with Compliance team to conduct disciplinary engagement with 48hrs and submit report with 24hrs.</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox17" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox55" runat="server" align="center" onblur="mul23();add7();add8();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating23" runat="server" onchange="mul23();add8();" AutoPostBack="false" align="center" Width="150px">
                                                                                                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore24" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Labelcom4" runat="server">4</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="lblperformance24" runat="server">Liaise with Compliance team to ensure 75% payment of all pension arrears.</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                   <asp:TextBox ID="TextBox23" runat="server" TextMode="MultiLine" align="center"></asp:TextBox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox56" runat="server" align="center" onblur="mul24();add7();add8();" Height="30px" Width="132px"></asp:TextBox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating24" runat="server" onchange="mul24();add8();" AutoPostBack="false" align="center" Width="150px">
                                                                                                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore25" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Labelcom5" runat="server">5</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">	
                                                                                    <asp:Label ID="lblperformance25" runat="server">100% issuance of ID cards to all employees.</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox31" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox57" runat="server" align="center" onblur="mul25();add7();add8();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating25" runat="server" onchange="mul25();add8();" AutoPostBack="false" align="center" Width="150px">
                                                                                                <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore26" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="70%">
                                                                                    <center><b>Total</b></center>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox28" runat="server" align="center" onblur="add7();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:Label ID="Label23" runat="server" Height="30px" Width="150px" Text=""></asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:TextBox ID="TextBox29" runat="server" align="center" onblur="add8();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>


                                                                                       </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>


                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>

                                                            </tr>
                                                            <%-- <table width="100%" border="1" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <div class="form-actions no-margin">
                                                                            <asp:Button ID="butcomplain" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="butcomplain_Click" OnClientClick="return ValidateData();" />
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>--%>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <!-- Payroll Management -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                
                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="kk"
                                                                                DisplayAfter="1">
                                                                                <ProgressTemplate>
                                                                                    <div class="modal-backdrop fade in">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>




                                                                            <div class="row-fluid">
                                                        <div class="widget">
                                                            <div class="widget-header">
                                                                <div class="title" data-icon="&#xe14a;">
                                                                    &nbsp;Payroll Management
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <fieldset>
                                                                    <div>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <%-- first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%"><b>
                                                                                    <center>Sl No</center>
                                                                                </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <b>
                                                                                        <center> Performance Outcomes/Targets</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-lft-clr123" width="30%">
                                                                                    <b>
                                                                                        <center>Achivements</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Weight</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Rating</center>
                                                                                    </b>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <b>
                                                                                        <center> Score</center>
                                                                                    </b>
                                                                                </td>
                                                                            </tr>
                                                                            <%--end first Row --%>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Labelpay1" runat="server">1</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="Labelpay2" runat="server">Compile and send overtime and leave advice to Payroll manager on or before 20th of the month.</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBoxpay" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox58" runat="server" align="center" onblur="mul26();add9();add10();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:DropDownList ID="ddlrating26" runat="server" onchange="mul26();add10();" AutoPostBack="false" align="center" Width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                     <asp:TextBox ID="txtscore27" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:Label ID="Labelpay3" runat="server">2</asp:Label> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="Labelpay4" runat="server">100% accurate preparation of salary information</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox15" runat="server" TextMode="MultiLine" align="center"></asp:TextBox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox59" runat="server" align="center" onblur="mul27();add9();add10();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating27" runat="server" onchange="mul27();add10();" AutoPostBack="false" align="center" Width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:TextBox ID="txtscore28" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                    <asp:Label ID="Labelpay5" runat="server">3</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="Labelpay6" runat="server">Notify Payroll manager of new hires, terminationm, change in remuneration etc. on or before 20th of the month or within 24 hours upon receipt from the client</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox25" runat="server" align="center" TextMode="MultiLine"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox60" runat="server" align="center" onblur="mul28();add9();add10();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:DropDownList ID="ddlrating28" runat="server" onchange="mul28();add10();" align="center" AutoPostBack="false" Width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore29" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="6%">
                                                                                   <asp:Label ID="Labelpay7" runat="server">4</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="34%">
                                                                                    <asp:Label ID="Labelay8" runat="server">Ensure pay slips are received from payroll manager on/before the 25th of every month</asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="30%">
                                                                                    <asp:TextBox ID="TextBox34" runat="server" TextMode="MultiLine" align="center"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:TextBox ID="TextBox61" runat="server" align="center" onblur="mul29();add9();add10();" Height="30px" Width="132px"></asp:TextBox> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                   <asp:DropDownList ID="ddlrating29" runat="server" onchange="mul29();add10();" AutoPostBack="false" align="center" Width="150px">
                                                                                            <asp:ListItem Text="--select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                                                            <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                                                            <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                                                        </asp:DropDownList> 
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="txtscore30" runat="server" align="center" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                            </tr>

                                                                        </table>

                                                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="70%">
                                                                                    <center><b>Total</b></center>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox62" runat="server" align="center" onblur="add9();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:Label ID="Label24" runat="server" Height="30px" Width="150px" Text=""></asp:Label>
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="10%">
                                                                                    <asp:TextBox ID="TextBox44" runat="server" align="center" onblur="add10();" Height="30px" Width="132px"></asp:TextBox>
                                                                                </td>

                                                                            </tr>
                                                                        </table>


                                                                    </div>
                                                                </fieldset>
                                                            </div>
                                                        </div>
                                                    </div>
                                                                            
                                            



                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>

                                                            </tr>

                                                            <tr>
                                                                <td colspan="2">
                                                                    <div class="widget-body">

                                                                        <div class="form-actions no-margin">
                                                                            <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                                                                            <asp:Button ID="butpayroll" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="butpayroll_Click" OnClientClick="return ValidateData();" />
                                                                        </div>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>

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

            </div>
        </div>




        <script type="text/javascript">

            function mul() {
                var txt1 = document.getElementById('TextBox65').value;
                var txt2 = document.getElementById('ddlrateing1').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore1").value = result.toFixed(0);
            }

            function mul2() {

                var txt1 = document.getElementById('TextBox66').value;
                var txt2 = document.getElementById('ddlrating2').value;
                var txt3 = (txt2) * (0.2);
                var result1 = (txt1) * (txt3);
                document.getElementById("txtscore2").value = result1.toFixed(0);


            }
            function mul3() {

                var txt1 = document.getElementById('TextBox67').value;
                var txt2 = document.getElementById('ddlrating3').value;
                var txt3 = (txt2) * (0.2);
                var result2 = (txt1) * (txt3);
                document.getElementById("txtscore3").value = result2.toFixed(0);


            }
            function add1() {

                var a = document.getElementById('txtscore1').value;
                var b = document.getElementById('txtscore2').value;
                var c = document.getElementById('txtscore3').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c);
                document.getElementById("txtscore4").value = result3;


            }
            function add2() {

                var a = document.getElementById('TextBox65').value;
                var b = document.getElementById('TextBox66').value;
                var c = document.getElementById('TextBox67').value;
                var result4 = parseFloat(a) + parseFloat(b) + parseFloat(c);
                document.getElementById("TextBox68").value = result4;
            }

            function mul4() {
                var txt1 = document.getElementById('TextBox7').value;
                var txt2 = document.getElementById('ddlrating4').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore5").value = result.toFixed(0);
            }
            function mul5() {
                var txt1 = document.getElementById('TextBox11').value;
                var txt2 = document.getElementById('ddlrating5').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore6").value = result.toFixed(0);
            }
            function mul6() {
                var txt1 = document.getElementById('TextBox18').value;
                var txt2 = document.getElementById('ddlrating6').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore7").value = result.toFixed(0);
            }
            function mul7() {
                var txt1 = document.getElementById('TextBox22').value;
                var txt2 = document.getElementById('ddlrating7').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore8").value = result.toFixed(0);
            }
            function add3() {

                var a = document.getElementById('TextBox7').value;
                var b = document.getElementById('TextBox11').value;
                var c = document.getElementById('TextBox18').value;
                var d = document.getElementById('TextBox22').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d);
                document.getElementById("TextBox12").value = result3;
            }
            function add4() {

                var a = document.getElementById('txtscore5').value;
                var b = document.getElementById('txtscore6').value;
                var c = document.getElementById('txtscore7').value;
                var d = document.getElementById('txtscore8').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d);
                document.getElementById("TextBox13").value = result3;
            }



            function mul8() {
                var txt1 = document.getElementById('TextBox26').value;
                var txt2 = document.getElementById('ddlrating8').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore9").value = result.toFixed(0);
            }

            function mul9() {
                var txt1 = document.getElementById('TextBox32').value;
                var txt2 = document.getElementById('ddlrating9').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore10").value = result.toFixed(0);
            }
            function mul10() {
                var txt1 = document.getElementById('TextBox35').value;
                var txt2 = document.getElementById('ddlrating10').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore11").value = result.toFixed(0);
            }
            function mul11() {
                var txt1 = document.getElementById('TextBox37').value;
                var txt2 = document.getElementById('ddlrating11').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore12").value = result.toFixed(0);
            }
            function mul12() {
                var txt1 = document.getElementById('TextBox38').value;
                var txt2 = document.getElementById('ddlrating12').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore13").value = result.toFixed(0);
            }
            function mul13() {
                var txt1 = document.getElementById('TextBox40').value;
                var txt2 = document.getElementById('ddlrating13').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore14").value = result.toFixed(0);
            }
            function mul14() {
                var txt1 = document.getElementById('TextBox41').value;
                var txt2 = document.getElementById('ddlrating14').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore15").value = result.toFixed(0);
            }
            function mul15() {
                var txt1 = document.getElementById('TextBox46').value;
                var txt2 = document.getElementById('ddlrating15').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore16").value = result.toFixed(0);
            }
            function mul16() {
                var txt1 = document.getElementById('TextBox47').value;
                var txt2 = document.getElementById('ddlrating16').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore17").value = result.toFixed(0);
            }
            function mul17() {
                var txt1 = document.getElementById('TextBox48').value;
                var txt2 = document.getElementById('ddlrating17').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore18").value = result.toFixed(0);
            }
            function mul18() {
                var txt1 = document.getElementById('TextBox49').value;
                var txt2 = document.getElementById('ddlrating18').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore19").value = result.toFixed(0);
            }
            function mul19() {
                var txt1 = document.getElementById('TextBox50').value;
                var txt2 = document.getElementById('ddlrating19').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore20").value = result.toFixed(0);
            }
            function mul20() {
                var txt1 = document.getElementById('TextBox51').value;
                var txt2 = document.getElementById('ddlrating20').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore21").value = result.toFixed(0);
            }


            function add5() {

                var a = document.getElementById('TextBox26').value;
                var b = document.getElementById('TextBox32').value;
                var c = document.getElementById('TextBox35').value;
                var d = document.getElementById('TextBox37').value;
                var e = document.getElementById('TextBox38').value;
                var f = document.getElementById('TextBox40').value;
                var g = document.getElementById('TextBox41').value;
                var h = document.getElementById('TextBox46').value;
                var i = document.getElementById('TextBox47').value;
                var j = document.getElementById('TextBox48').value;
                var k = document.getElementById('TextBox49').value;
                var l = document.getElementById('TextBox50').value;
                var m = document.getElementById('TextBox51').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e)
                  + parseFloat(f) + parseFloat(g) + parseFloat(h) + parseFloat(i) + parseFloat(j) + parseFloat(k) + parseFloat(l) + parseFloat(m);
                document.getElementById("TextBox52").value = result3;
            }
            function add6() {

                var a = document.getElementById('txtscore9').value;
                var b = document.getElementById('txtscore10').value;
                var c = document.getElementById('txtscore11').value;
                var d = document.getElementById('txtscore12').value;
                var e = document.getElementById('txtscore13').value;
                var f = document.getElementById('txtscore14').value;
                var g = document.getElementById('txtscore15').value;
                var h = document.getElementById('txtscore16').value;
                var i = document.getElementById('txtscore17').value;
                var j = document.getElementById('txtscore18').value;
                var k = document.getElementById('txtscore19').value;
                var l = document.getElementById('txtscore20').value;
                var m = document.getElementById('txtscore21').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e)
                 + parseFloat(f) + parseFloat(g) + parseFloat(h) + parseFloat(i) + parseFloat(j) + parseFloat(k) + parseFloat(l) + parseFloat(m);
                document.getElementById("TextBox20").value = result3;
            }

            function mul21() {
                var txt1 = document.getElementById('TextBox43').value;
                var txt2 = document.getElementById('ddlrating21').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore22").value = result.toFixed(0);
            }
            function mul22() {
                var txt1 = document.getElementById('TextBox54').value;
                var txt2 = document.getElementById('ddlrating22').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore23").value = result.toFixed(0);
            }
            function mul23() {
                var txt1 = document.getElementById('TextBox55').value;
                var txt2 = document.getElementById('ddlrating23').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore24").value = result.toFixed(0);
            }
            function mul24() {
                var txt1 = document.getElementById('TextBox56').value;
                var txt2 = document.getElementById('ddlrating24').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore25").value = result.toFixed(0);
            }
            function mul25() {
                var txt1 = document.getElementById('TextBox57').value;
                var txt2 = document.getElementById('ddlrating25').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore26").value = result.toFixed(0);
            }

            function add7() {

                var a = document.getElementById('TextBox43').value;
                var b = document.getElementById('TextBox54').value;
                var c = document.getElementById('TextBox55').value;
                var d = document.getElementById('TextBox56').value;
                var e = document.getElementById('TextBox57').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e);
                document.getElementById("TextBox28").value = result3;
            }
            function add8() {

                var a = document.getElementById('txtscore22').value;
                var b = document.getElementById('txtscore23').value;
                var c = document.getElementById('txtscore24').value;
                var d = document.getElementById('txtscore25').value;
                var e = document.getElementById('txtscore26').value;
                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e);
                document.getElementById("TextBox29").value = result3;
            }

            function mul26() {
                var txt1 = document.getElementById('TextBox58').value;
                var txt2 = document.getElementById('ddlrating26').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore27").value = result.toFixed(0);
            }

            function mul27() {
                var txt1 = document.getElementById('TextBox59').value;
                var txt2 = document.getElementById('ddlrating27').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore28").value = result.toFixed(0);
            }

            function mul28() {
                var txt1 = document.getElementById('TextBox60').value;
                var txt2 = document.getElementById('ddlrating28').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore29").value = result.toFixed(0);
            }

            function mul29() {
                var txt1 = document.getElementById('TextBox61').value;
                var txt2 = document.getElementById('ddlrating29').value;
                var txt3 = (txt2) * (0.2);
                var result = (txt1) * (txt3);
                document.getElementById("txtscore30").value = result.toFixed(0);
            }
            function add9() {

                var a = document.getElementById('TextBox58').value;
                var b = document.getElementById('TextBox59').value;
                var c = document.getElementById('TextBox60').value;
                var d = document.getElementById('TextBox61').value;

                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d);
                document.getElementById("TextBox62").value = result3;
            }
            function add10() {

                var a = document.getElementById('txtscore27').value;
                var b = document.getElementById('txtscore28').value;
                var c = document.getElementById('txtscore29').value;
                var d = document.getElementById('txtscore30').value;

                var result3 = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d);
                document.getElementById("TextBox44").value = result3;
            }



        </script>
    </form>
</body>
</html>
