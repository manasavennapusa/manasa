<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createbroadgroup.aspx.cs"
    Inherits="admin_createbroadgroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" content="" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
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


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Business Unit </h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">

                            <div class="widget">

                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create                   
                                    </div>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </div>

                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Business Unit Name<span class="star" style="color:red">*</span></label>
                                            <div class="controls">
                                                <input id="txt_Broadgroup" type="text" runat="server" class="span4" maxlength="50"/>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Broadgroup"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Business Unit Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info" Text="Submit" ValidationGroup="c" OnClick="btnsv_Click1" />
                                            <asp:Button ID="btnReset" runat="server" CssClass="btn btn-info" Text="Reset" ValidationGroup="" OnClick="btnReset_Click1" />
                                           
                                        </div>
                                    </fieldset>

                                </div>
                            </div>
                        </div>

                        
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

</body>
</html>
