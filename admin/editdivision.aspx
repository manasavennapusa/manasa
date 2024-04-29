<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editdivision.aspx.cs" Inherits="Admin_Company_createcompany" Title="Create Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Cost Center </h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">

                            <div class="widget">

                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Cost Center Name <span class="star" style="color:red">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_branch_name" runat="server" CssClass="blue1" Width="300px" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Cost Center Name" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_branch_name"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z&\s\-]+$" ToolTip="Enter only alphabets and space"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label"> Work Location</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_branch_code" runat="server" CssClass="blue1" Width="300px" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_branch_code"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z&\s\-]+$" ToolTip="Enter only alphabets and space"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Update" CssClass="btn btn-primary" ValidationGroup="c"></asp:Button>
                                             <asp:Button ID="btncancel" OnClick="btncancel_Click" runat="server" Text="Cancel" CssClass="btn btn-primary" ValidationGroup=""></asp:Button>
                                           <%-- <button type="button" class="btn">Cancel</button>--%>
                                        </div>
                                    </fieldset>
                                </div>

                                <span id="message" runat="server" class="txt02" enableviewstate="false">&nbsp;</span>
                            </div>

                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

</body>
</html>



