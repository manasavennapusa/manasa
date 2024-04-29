<%@ Page Language="C#" AutoEventWireup="true" CodeFile="corevalue.aspx.cs" Inherits="appraisal_corevalue" %>

<%--<%--<Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee Master View" %>--%>

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
                                    <h2>Section-3</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>
                            <%-- start --%>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title" data-icon="&#xe14a;">
                                            &nbsp;<a   title="Core Values">Core Values</a>
                                        </div>
                                    </div>
                                    
                                    <div id="section3" >
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
                                                                    <center>  Values</center>
                                                                </b>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <b>
                                                                    <center>Definition</center>
                                                                </b>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <b>
                                                                    <center> Achievement</center>
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
                                                                <asp:Label ID="Label1" runat="server">1</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblcreativity" runat="server">CREATIVITY</asp:Label>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef1" runat="server">Generate creative ideas to add values to process,organization and colleagues.</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="txtrating1" runat="server" TextMode="MultiLine" Width="220px" Height="32" align="center"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate1" runat="server" OnSelectedIndexChanged="ddlrate1_SelectedIndexChanged" onchange="add2();" AutoPostBack="true" Width="190px">
                                                             <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.3">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="6.6">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="9.9">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.3">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="16.6">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox8" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="Label2" runat="server">2</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblprof" runat="server">PROFESSIONALISM</asp:Label></td>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef22" runat="server">Exhibit the highest levels Of excellence in both behavior and work.</asp:Label></td>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txtrating2" runat="server" Width="220px" Height="32"  TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate2" runat="server" OnSelectedIndexChanged="ddlrate2_SelectedIndexChanged" onchange="add2();" Width="190px" AutoPostBack="true">
                                                          <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.3">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="6.6">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="9.9">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.3">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="16.6">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox1" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="Label3" runat="server">3</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblteamwork" runat="server">TEAMWORK</asp:Label></td>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef44" runat="server">Providing colleague and interdepartmental support</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="txtrating3" runat="server" Width="220px" Height="32"   TextMode="MultiLine"></asp:TextBox> 
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate3" runat="server" OnSelectedIndexChanged="ddlrate3_SelectedIndexChanged" onchange="add2();" Width="190px" AutoPostBack="true">
                                                           <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.3">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="6.6">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="9.9">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.3">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="16.6">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="TextBox2" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                               <asp:Label ID="Label5" runat="server">4</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblintegrty" runat="server">INTEGRITY</asp:Label></td>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef55" runat="server">To Carry Out Functions That would promote integrity to the organization, colleagues and clients</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="txtrating4" runat="server" Width="220px" Height="32"  TextMode="MultiLine" align="center"></asp:TextBox> 
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate4" runat="server" OnSelectedIndexChanged="ddlrate4_SelectedIndexChanged" onchange="add2();" Width="190px" AutoPostBack="true">
                                                            <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.3">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="6.6">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="9.9">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.3">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="16.6">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                               <asp:TextBox ID="TextBox3" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox> 
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="Label6" runat="server">5</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblexcel" runat="server">EXCELLENCE</asp:Label></td>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef66" runat="server">Ability to do things right the first time</asp:Label></td>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txtrating5" runat="server" Width="220px" Height="32"  TextMode="MultiLine" align="center"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate5" runat="server" OnSelectedIndexChanged="ddlrate5_SelectedIndexChanged" onchange="add2();" Width="190px" AutoPostBack="true">
                                                          <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.3">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="6.6">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="9.9">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.3">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="16.6">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox4" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="5%">
                                                                <asp:Label ID="Label7" runat="server">6</asp:Label>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:Label ID="lblpassion" runat="server">PASSION</asp:Label></td>
                                                            </td>
                                                            <td class="frm-lft-clr123" width="35%">
                                                                <asp:Label ID="lbldef77" runat="server">Loving what you do and being charged up about going the ‘Extra Mile’ for the job</asp:Label></td>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txtrating6" runat="server" Width="220px" Height="32"  TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:DropDownList ID="ddlrate6" runat="server" OnSelectedIndexChanged="ddlrate6_SelectedIndexChanged" Width="190px" onchange="add2();" AutoPostBack="true">
                                                      
                                                        <asp:ListItem Value="0">--Select-- </asp:ListItem>
                                                                                            <asp:ListItem Value="3.5">Poor</asp:ListItem>
                                                                                            <asp:ListItem Value="7.0">Below Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="10.5">Meets Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="13.5">Above Expectation</asp:ListItem>
                                                                                            <asp:ListItem Value="17.0">Outstanding</asp:ListItem>
                                                        </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="TextBox5" runat="server" align="center" Height="30px" Width="132px">0</asp:TextBox>
                                                            </td>
                                                        </tr>



                                                    </table>

                                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="65%">
                                                               <center> <asp:Label ID="Label4" runat="server" Height="16px" Width="283px">TOTAL</asp:Label></center>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="20%">
                                                                <asp:TextBox ID="txtperc" runat="server" onblur="add1();" align="center" Height="30px" Width="176px"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr123" width="15%">
                                                                <asp:TextBox ID="txtavg" runat="server" onblur="add2();" align="center" Height="30px" Width="132px"></asp:TextBox>
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
<script type="text/javascript">
    function add1() {

        var a = document.getElementById('ddlrate1').value;
        var b = document.getElementById('ddlrate2').value;
        var c = document.getElementById('ddlrate3').value;
        var d = document.getElementById('ddlrate4').value;
        var e = document.getElementById('ddlrate5').value;
        var f = document.getElementById('ddlrate6').value;
        var result = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e) + parseFloat(f);
        document.getElementById("txtperc").value = result;


    }
    function add2() {

        var a = document.getElementById('TextBox8').value;
        var b = document.getElementById('TextBox1').value;
        var c = document.getElementById('TextBox2').value;
        var d = document.getElementById('TextBox3').value;
        var e = document.getElementById('TextBox4').value;
        var f = document.getElementById('TextBox5').value;
        var result = parseFloat(a) + parseFloat(b) + parseFloat(c) + parseFloat(d) + parseFloat(e) + parseFloat(f);
        document.getElementById("txtavg").value = result;


    }
</script>
