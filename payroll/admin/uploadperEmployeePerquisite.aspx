<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadperEmployeePerquisite.aspx.cs" Inherits="payroll_admin_uploadperEmployeePerquisite" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Attendance</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <style type="text/css" media="all">
        @import "../css/blue1.css";

        .input3
        {
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #000;
        }

        .star:before
        {
            content: " *";
        }
    </style>
    <script type="text/javascript" src="../../js/timepicker.js"></script>
    <script language="JavaScript" type="text/javascript" src="../js/popup.js"></script>

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
   <form id="form1" runat="server">
        <div>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">

                                <div class="widget-body">
                                    <fieldset>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="top">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td colspan="2" valign="top" class="blue-brdr-1">
                                                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                    <tr>

                                                                        <td class="txt01">Upload Employee Perquisite</td>
                                                                        <td><a style="float:right;" href="doc/Perquisite.xls">Download</a></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" valign="top" style="height: 5px" class="txt-red" align="right"><span id="message" runat="server"></span>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="left" class="frm-lft-clr123" style="width: 149px">Upload Employee Perquisite&nbsp;<span class="star"></span></td>
                                                            <td valign="top" class="frm-rght-clr123" style="width: 471px">&nbsp;
                                    <asp:FileUpload ID="fupload" runat="server" Width="390px" />
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload" SetFocusOnError="True"
                                                                    ValidationGroup="v"><img src="../../images/error1.gif" /></asp:RequiredFieldValidator></td>
                                                        </tr>

                                                        <tr>
                                                            <td valign="middle" class="frm-lft-clr123  border-bottom" style="width: 149px">
                                                                <asp:Button ID="btnsubmit" runat="server" CssClass="button" Text="Submit" ValidationGroup="v" OnClick="btnsubmit_Click" /></td>
                                                            <td valign="top" class="frm-rght-clr123  border-bottom" style="width: 471px">&nbsp;
              <asp:TextBox ID="txtcode" runat="server" Visible="False"></asp:TextBox></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2" valign="top"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" align="left" style="height: 18px"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
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
