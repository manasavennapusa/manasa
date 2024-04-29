<%@ Page Language="C#" AutoEventWireup="true" CodeFile="time.aspx.cs" Inherits="InformationCenter_time" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function date() {
            var someDate = document.getElementById('TextBox1').value;
            var numberOfDaysToAdd = 6;
            someDate.setDate(someDate.getDate() + numberOfDaysToAdd);
        }
        function DateFormat() {
            var dd = someDate.getDate();
            var mm = someDate.getMonth() + 1;
            var y = someDate.getFullYear();
            var someFormattedDate = dd + '/' + mm + '/' + y;
            document.getElementById("TextBox1").value = someFormattedDate;
        }
        function d() {
            var n = 5; //number of days to add. 
            var today = new Date(); //Today's Date
            var requiredDate = new Date(today.getFullYear(), today.getMonth(), today.getDate() + n)
            document.getElementById("TextBox2").value = someFormattedDate;
        }
        function a() {
            

            var d = document.getElementById('TextBox1').value;
            var partsOfStr = str.split('/');

            document.getElementById("TextBox2").value = partsOfStr;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="TextBox1" runat="server" onblur="a()"></asp:TextBox>
         <asp:TextBox ID="TextBox2" runat="server" onblur="a()"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" onblur=""></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" onblur=""></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"  Text="Button" />
    </div>
    </form>
</body>
</html>
