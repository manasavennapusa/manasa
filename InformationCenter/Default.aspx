<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="InformationCenter_Default" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>PostBackTrigger Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    The upload button is defined as a PostBackTrigger.<br/>
    <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
    <ContentTemplate>
    <fieldset>
    <legend>FileUpload in an UpdatePanel</legend>
       First, enter a file name to upload your file to: 
       <asp:TextBox ID="FileName" runat="server" />
       <asp:Button ID="CheckButton" Text="Check" runat="server" OnClick="CheckButton_Click" />
       <br />
       Then, browse and find the file to upload:
       <asp:FileUpload id="FileUpload1"                 
           runat="server">
       </asp:FileUpload>
       <br />
       <asp:Button id="UploadButton" 
           Text="Upload file"
           OnClick="UploadButton_Click"
           runat="server">
       </asp:Button>    
       <br />
       <asp:Label id="UploadStatusLabel"
           runat="server" style="color:red;">
       </asp:Label>           
    </fieldset>
    </ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="UploadButton" />
    </Triggers>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
