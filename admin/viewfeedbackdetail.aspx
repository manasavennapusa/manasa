<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewfeedbackdetail.aspx.cs" Inherits="admin_viewfeedbackdetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <%--<link href="../css/blue1.css" rel="stylesheet" type="text/css" />--%>
     <style type="text/css" media="all">
        @import "../css/blue.css";
        @import "../css/home.css";
        </style>
<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1">
        <ProgressTemplate>
        <div class="divajax">
        <table width="100%">
        <tr>
        <td align="center" valign="top"><img src="../images/loading.gif" /></td>
        </tr>
        <tr>
        <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
        </tr>
        </table>
        </div>
        </ProgressTemplate>
        </asp:UpdateProgress>
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td valign="top" class="blue-brdr-1">&nbsp;</td>
      </tr>

      <tr>
        <td valign="top" class="dot-line">View Feedback</td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
      <tr>
        <td valign="top">&nbsp;&nbsp;<img src="../images/date-icon.gif" width="10" height="10" alt=""/>&nbsp; <asp:Label ID="lbldate" runat="server" Text=""></asp:Label><asp:Label ID="lblname" runat="server" Text=""></asp:Label></td>
      </tr>
      <tr>
        <td height="26" valign="middle" class="txt01">&nbsp;&nbsp;<asp:Label ID="lblheading" runat="server" CssClass="txt3"></asp:Label></td>
      </tr>  
      <tr>
        <td valign="top">
        <p>
        
        <asp:Label ID="lbldetails" runat="server" Text=""></asp:Label>
          
          </p></td>
      </tr>
      <tr>
        <td valign="top">&nbsp;</td>
      </tr>
      <tr>
        <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="2">
<tr>
<td width="11%" class="txt01"> </td>
<td width="20%">
    &nbsp;</td>
<td width="34%"></td>
<td width="35%"><table width="50" border="0" align="right" cellpadding="0" cellspacing="0">
<tr>
<td width="5" align="left" valign="top"><img src="../images/button-right.jpg" width="5" height="18" /></td>
<td width="90" align="center" valign="middle" CssClass="button"><a href="javascript:history.go(-1)" class="back">Back</a></td>
<td width="5" align="right"><img src="../images/button-right1.jpg" width="5" height="18" /></td>
</tr>
</table></td>
</tr>
</table></td>
      </tr>
    </table></div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>