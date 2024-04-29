<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createrole.aspx.cs" Inherits="Admin_company_createcompany"
    Title="Create company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
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
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

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
                                <h2> Role </h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>Create
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Role Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_branch_name" runat="server" CssClass="blue1" Width="300px" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Role Name" ValidationGroup="c"
                                                        Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_branch_name"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z/>,.';:<+-/=@#$%&^%!|?*{}()]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_branch_code" runat="server" CssClass="blue1" Width="300px" Height="50px" onkeypress="return isCharOrSpace()"
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_branch_code"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s-]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-primary"
                                                    ValidationGroup="c"></asp:Button>

                                                <asp:Button ID="btnreset" OnClick="btnreset_Click" runat="server" Text="Reset" CssClass="btn btn-primary"
                                                    ValidationGroup=""></asp:Button>
                                              <%--  <button type="button" class="btn">Cancel</button>--%>
                                            </div>
                                        </fieldset>
                                    </div>
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
