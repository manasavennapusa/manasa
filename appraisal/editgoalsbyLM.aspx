<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editgoalsbyLM.aspx.cs" Inherits="appraisal_editgoalsbyLM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 32%;
    }

    .auto-style2 {
        width: 38%;
    }
</style>
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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>

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
    <script src="js/validation.js"></script>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Goals </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Edit Employee Goals"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <table width="100%">
                                            <tr>
                                                <td>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>
                                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                                        <tr>
                                                            <td class=" frm-lft-clr123 border-bottom"><b>Name of the Goal</b><span class="star"></span>
                                                            </td>
                                                             <td class=" frm-lft-clr123 border-bottom"><b>Desired outcome/Impact</b><span class="star"></span>
                                                            </td>
                                                             <td class=" frm-lft-clr123 border-bottom"><b>Milestone to check improvement</b><span class="star"></span>
                                                            </td>
                                                            <td class=" frm-lft-clr123 border-bottom"><b>Timeline and support required.</b><span class="star"></span></td>
                                                            <td class=" frm-lft-clr123 border-bottom" style="border-right: 1px solid #d9d9d9;"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="textrole" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="textkca_outcome" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="textkpi_milestone" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            </td>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="txtWeightage_timeline" runat="server" CssClass="blue1" Width="85%" MaxLength="8000" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <div class="form-actions no-margin" style="text-align:right">
                                             <asp:Button ID="btnback" runat="server" CssClass="btn btn-info" Text="Back" OnClick="btnback_Click" /> &nbsp;
                                            <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-info" Text="Update" OnClick="btnupdate_Click" />&nbsp;
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
