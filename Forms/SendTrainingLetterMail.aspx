<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SendTrainingLetterMail.aspx.cs" Inherits="Forms_SendTrainingLetterMail" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <title>Send Mail</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            color: red;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>HR Letters</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget" style="">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Send Mail</span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <div>
                                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" width="100%">
                                                    <table style="width: 100%; height: 180px" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td style="width: 50%" valign="top">
                                                                <asp:UpdatePanel ID="kk" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="kk" DisplayAfter="1">
                                                                            <ProgressTemplate></ProgressTemplate>
                                                                        </asp:UpdateProgress>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr id="tr" runat="server" visible="false">
                                                                                <td class="frm-lft-clr123 border-bottom">
                                                                                    <asp:Label ID="lblname" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr style="height: 50px">
                                                                                <td class="frm-lft-clr123" width="48%">FROM<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                    <asp:TextBox ID="tbfrom" runat="server" placeholder="YourEmail.@gmail.com" CssClass="span11" MaxLength="100">connect@escalon.services</asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbfrom"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Fom Mail"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">TO<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="tbto" runat="server" CssClass="span11" Width="" MaxLength="100" placeholder="Receiver@gmail.com" Style="border: 1px solid #ddd" TextMode="SingleLine"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="tbto"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter To Mail"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>

                                                                            <tr id="Tr1" style="height: 50px" runat="server">
                                                                                <td class="frm-lft-clr123" width="48%">SUBJECT<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                    <asp:TextBox ID="tbsubject" runat="server" CssClass="span11" MaxLength="500" placeholder="Max 100 Chars.." BorderColor="#cccccc"></asp:TextBox>
                                                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbsubject"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Subject"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="Tr2" style="height: 50px" runat="server">
                                                                                <td class="frm-lft-clr123 border-bottom" style="border-bottom: 1px solid #d1cccc" width="48%">MESSAGE<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" style="border-bottom: 1px solid #d1cccc" width="52%">
                                                                                    <asp:TextBox ID="tbmessage" runat="server" CssClass="span11" Width="" MaxLength="500" Height="60px" placeholder="Max 200 Chars.." TextMode="MultiLine" Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="tbmessage"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Message"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="Tr3" style="height: 50px" runat="server">
                                                                                <td class="frm-lft-clr123 border-bottom" style="border-bottom: 1px solid #d1cccc" width="48%">CHOOSE FILE<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="2%" style="border-bottom: 1px solid #d1cccc">
                                                                                    <asp:FileUpload ID="File_UploadDft" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" Vgroup="v" />
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="File_UploadDft"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Choose File"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr><td><br /></td></tr>
                                            <tr>
                                                <td>
                                                    <div class="form-actions no-margin" style="text-align:right">
                                                        <asp:Button ID="btnsend" runat="server" CssClass="btn btn-info" Text="Send" title="Send Mail" OnClick="SendEmail" Style="margin-left: 10px" ValidationGroup="v" />
                                                        <asp:Button ID="btnreset" runat="server" CssClass="btn btn-info" Text="Reset" title="Clear" Style="margin-left: 10px" OnClick="btnreset_Click" />
                                                        <asp:Button ID="btnback" runat="server" CssClass="btn btn-info" Text="Back" title="Back To Previous menu" OnClick="btnback_Click" Style="margin-left: 10px" />
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />    
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


