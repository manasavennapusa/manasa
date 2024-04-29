<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdditionalPerformanceFactors.aspx.cs" Inherits="appraisal_AdditionalPerformanceFactors" %>



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
             <Scripts>
        <asp:ScriptReference Path="~/InformationCenter/cal.js" />
    </Scripts>
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                </div>
                <%-- starts here --%>
                <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title" data-icon="&#xe14a;">
                                        &nbsp;<a   title="Additional performance factors">Additional performance factors</a>
                                    </div>
                                </div>
                                <div >
                                <div class="widget-body">
                                    <fieldset>
                                        <div>

                                            <table class="table table-condensed table-striped  table-bordered pull-left">

                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%"><b>
                                                        <center>Type</center>
                                                    </b>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <b>
                                                            <center>  Additional Factors</center>
                                                        </b>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="15%">
                                                        <b>
                                                            <center>Count</center>
                                                        </b>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <b>
                                                            <center>%</center>
                                                        </b>
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                       <asp:Label ID="Label5" runat="server"><center> Eroders</center> </asp:Label>
                                                                                  <center>  -0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:Label ID="lblperformance1" runat="server">Consistent errors in salary information</asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox1" TabIndex="1"   runat="server" onblur="mul();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox7" ReadOnly="false"   runat="server" >0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                        <center>Eroders </center>
                                                           <center> -0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:Label ID="Label1" runat="server">Loss of business (and/or clients) due to unprofessional client engagement and management</asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                       <asp:TextBox ID="TextBox2" TabIndex="2" runat="server" onblur="mul1();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox8" ReadOnly="false"   runat="server">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                       <center>Eroders </center>
                                                           <center> -0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:Label ID="Label2" runat="server">Documented customer/client complaint resulting in potential loss of business</asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox3" TabIndex="3" runat="server" onblur="mul2();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                       <asp:TextBox ID="TextBox9" ReadOnly="false" Text="0"  runat="server"></asp:TextBox> 
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                        <asp:Label ID="Label6" runat="server"> <center>Boosters</center></asp:Label>
                                                                                  <center>  +0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:Label ID="lblperformance2" runat="server">Surpassing of annual  targets</asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox4" TabIndex="4" runat="server" onblur="mul3();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                         <asp:TextBox ID="TextBox10" ReadOnly="false" OnKeyPress="true" Text="0" CssClass="clsTxtToCalculate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                        <center>Boosters </center>
                                                           <center> +0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                         <asp:Label ID="Label3" runat="server">Flagging of material misstatements, errors and fraud resulting in significant financial savings </asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox5" TabIndex="5" runat="server" onblur="mul4();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                         <asp:TextBox ID="TextBox11" ReadOnly="false" Text="0" CssClass="clsTxtToCalculate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="15%">
                                                         <center>Boosters </center>
                                                           <center> +0.5%</center>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                         <asp:Label ID="Label4" runat="server">Official Commendations received</asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox6" TabIndex="6" runat="server" onblur="mul5();add();"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:TextBox ID="TextBox12" ReadOnly="false" Text="0" CssClass="clsTxtToCalculate" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>

                                            </table>

                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="85%">
                                                        <center><b>Total</b></center>
                                                    
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <b>
                                                            <asp:TextBox ID="lblTotal" ReadOnly="false" runat="server">0</asp:TextBox>
                                                        </b>
                                                    </td>

                                                </tr>
                                            </table>

                                        </div>
                                    </fieldset>
                                </div>
                                    </div>
                                <div class="form-actions no-margin">
                                            <asp:Button ID="btnjob" TabIndex="7" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnSave_Click" OnClientClick="return ValidateData();" />
                                        </div>
                            </div>
                    
                        </div>

                 
            </div>
        </div>
<div>
      
    </div>
    </form>
    
</body>
</html>
