<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OverallRatings.aspx.cs" Inherits="appraisal_OverallRatings" %>



<%--<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <!-- Job Details -->
                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title" data-icon="&#xe14a;">
                                &nbsp;<a  title=" OVERALL RATING AND COMMENTS">OVERALL RATING AND COMMENTS</a>
                            </div>
                        </div>
                        <div >
                            <div class="widget-body">
                                <fieldset>
                                    <div>
                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                            <tr>
                                                <td class="frm-lft-clr123" width="50%"><b>
                                                    <center>TARGET/OUTCOMES SCORE STANDARD</center>
                                                </b>
                                                </td>
                                                <td class="frm-rght-clr123" width="50%">
                                                    <b>
                                                        <center>PERFORMANCE QUALITIES SCORE STANDARD</center>
                                                    </b>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                            <tr>
                                                <td class="frm-lft-clr123" width="15%">
                                                    <center><b>1</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Consistently Fails To Reach The Expectations In This Area(Does Not Meet)
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <center><b>1</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Poor
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="15%">
                                                    <center><b>2</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Inconsistent Demonstration Of Results (Typically Meets)
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <center><b>2</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Below Expectation
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="15%">
                                                    <center><b>3</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Meets The Desired Requirements (Meets)
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <center><b>3</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Meets Expectation
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="15%">
                                                    <center><b>4</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Meets and exceeds the desired Requirement (Exceeds)
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <center><b>4</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Above Expectation
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="15%">
                                                    <center><b>5</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Consistently Meets and exceeds the desired Requirement (OUTSTANDING)
                                                </td>
                                                <td class="frm-rght-clr123" width="15%">
                                                    <center><b>5</b></center>
                                                </td>
                                                <td class="frm-rght-clr123" width="35%">Outstanding
                                                </td>
                                            </tr>


                                        </table>

                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                            <tr>
                                                <td class="frm-lft-clr123" width="100%"><b>Employee's Comments:</b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123" width="100%">
                                                     <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="64px" Width="1000px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table table-condensed table-striped  table-bordered pull-left">
                                            <tr>
                                                <td class="frm-lft-clr123" width="100%"><b>Appraiser's Comments: </b>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-rght-clr123" width="100%">
                                                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine" Height="61px" Width="1000px" ></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>
                                </fieldset>
                            </div>
                            <div class="form-actions no-margin">
                    <asp:Button ID="btnsumbmit" runat="server" Text="submit" CssClass="btn btn-primary pull-right" OnClick="btnsumbmit_Click"></asp:Button>
                </div>
                        </div>
                    </div>
                </div>
                
            </div>

        </div>
    </form>
</body>
</html>































