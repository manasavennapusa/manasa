<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updatebankmaster.aspx.cs"
    Inherits="payroll_admin_updatebankmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Bank </h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                        Edit
                                            <span id="Span2" runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Bank Name</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_bankname" size="40" CssClass="span4" runat="server" ToolTip="Leave Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_bankname"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="v"
                                                        Display="Dynamic" ToolTip="Enter Bank Name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_bankname"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Bank Code</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_bankcode" runat="server" CssClass="span4" 
                                                        onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_bankcode"
                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                        ToolTip="Enter Bank Code" ValidationGroup="v"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_bankcode"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s\0-9]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group" runat="server" visible="false">
                                                <label class="control-label">Account Number</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_accno" runat="server" CssClass="span4" size="40" ToolTip="Display name of leave " onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_accno"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="v"
                                                        SetFocusOnError="True" ToolTip="Enter Account No."><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_accno"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Bank Address</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_bankaddr" runat="server" CssClass="span4" size="40" ToolTip="Display name of leave "
                                                        TextMode="MultiLine" ></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txt_bankaddr"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9.\/\-\#\s]+$" ToolTip="Enter only alphanumeric and space / -  #"
                                                        ErrorMessage="enter correct address"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">For TDS(Check if yes)</label>
                                                <div class="controls">
                                                    <asp:CheckBox ID="chktds" runat="server" OnCheckedChanged="chktds_CheckedChanged" AutoPostBack="true" />
                                                </div>
                                            </div>
                                            <div class="control-group" runat="server" visible="false" id="bsrcode">
                                                <label class="control-label">BSR Code</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtbsrcode" runat="server" CssClass="span4" size="40" MaxLength="7" ></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txtbsrcode"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                              <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="btnsbmit_Click"
                                                        ValidationGroup="v" ToolTip="Click to submit the created leave" />&nbsp;
                                                <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                                    Text="Cancel" />
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
