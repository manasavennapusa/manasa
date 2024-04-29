<%@ Page Language="C#" AutoEventWireup="true" CodeFile="application.aspx.cs" Inherits="admin_applications" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/tabcontent.css";
    </style>
<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <form id="form1" runat="server">
    <table width="960" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="3" style="height: 5px">
            </td>
        </tr>
        <tr>
            <td width="12%" valign="top" class="blue-brdr">
                <!--................................LEFT NAVIGAION........................-->
                <table width="210" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="nav-head-new">
                            Navigation
                        </td>
                    </tr>
                    <tr>
                        <td class="other">
                            <a href="../leave/admin/leaveadmin.aspx" class="other-text">Leave Management</a>
                        </td>
                    </tr>
                    <tr>
                        <td class="other">
                            <a href="../payroll/admin/Payrolladmin.aspx" class="other-text">Payroll System</a>
                        </td>
                    </tr>
                    <%--<tr>
    <td class="other"><a href="#" class="other-text" target="content4">Travel Management</a></td>
</tr>--%>
                </table>
                <!--................................END LEFT NAVIGAION........................-->
            </td>
            <td valign="top" style="width: 1%">
                <img src="../images/5x5.gif" width="10" height="5" />
            </td>
            <td width="87%" valign="top" align="left" class="blue-brdr-1">
                <iframe name="content5" frameborder="0" width="735px" height="495px" src="#" scrolling="yes">
                </iframe>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
