<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewjobdetail.aspx.cs" Inherits="InformationCenter_viewjobdetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
!--[if lt IE 7]>
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

    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta charset="utf-8">
        <title>SmartDrive Labs</title>

        <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet">
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet">

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet">

        <!-- fullcalendar css -->
        <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
        <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    </head>
    <body>
        <form id="myForm" runat="server" class="form-horizontal no-margin">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="main-container">
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2></h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Job Details                
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div class="form-horizontal row-border myform">
                                    <div class="control-group">
                                         <label class="control-label">Job Summary:<span class="required"></span></label>
                                        <div class="controls">
                                            <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                          <label class="control-label">Requirements:<span class="required"></span></label>                                        
                                        <div class="controls">
                                            <asp:Label ID="lbl_alias" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Responsbility:</label>
                                        <div class="controls">
                                            <asp:Label ID="lbl_payheadtype" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                    </div>
                                </div>
                            </div>
                              <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </body>
    </html>
