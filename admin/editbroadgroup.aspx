<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editbroadgroup.aspx.cs" Inherits="admin_editbroadgroup" %>

<<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
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
                                <h2> Business Unit</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit  
                                        </div>
                                        <span id="message" runat="server"></span>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Business Unit Name<span class="star" style="color:red">*</span></label>
                                                <div class="controls">
                                                    <input id="txt_Broadgroup" runat="server" class="span4"/>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Broadgroup"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Business Unit Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_Broadgroup"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9&\.\/\-\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric space / #  ."
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsv" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="c" OnClick="btnsv_Click"></asp:Button>
                                                  <asp:Button ID="Button1" runat="server" Text="Cancel" CssClass="btn btn-primary" ValidationGroup="" OnClick="Button1_Click"></asp:Button>
                                            </div>
                                        </fieldset>
                                    </div>

                                    <%--<table class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td class="frm-lft-clr123" width="23%">Business Unit Name
                                                </td>
                                                <td style="width: 77%">

                                                    <asp:TextBox ID="txt_Broadgroup" runat="server" CssClass="blue1" Width="182px" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_Broadgroup"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter BroadGroup Name" ValidationGroup="c"
                                                        Width="6px"><img src="../images/../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom">&nbsp;
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom"></td>
                                            </tr>

                                        </tbody>
                                    </table>--%>
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

