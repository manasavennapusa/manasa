<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Uploader.ascx.cs" Inherits="CustomControl" %>
<link href ="css/blue1.css" rel="stylesheet" type="text/css" />

<html>
<head>
<title>

</title>

 
<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
<asp:FileUpload ID="FilUpl" runat="server" CssClass="blue111" Width="210px" Height="20" />
<asp:CustomValidator CssClass ="blue5" ID="ErrorMsg" runat="server" ErrorMessage="CustomValidator" OnServerValidate="ErrorMsg_ServerValidate" ForeColor="#0000C0" Display="Dynamic"></asp:CustomValidator>
</body>
</html>