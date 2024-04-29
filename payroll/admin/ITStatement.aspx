<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ITStatement.aspx.cs" Inherits="payroll_admin_ITStatement" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        table
        {
            border-collapse:collapse;
            border:1px solid #ddd;
        }
        table tr td
        {   color:#333;
            font-size: 13px;
            font-family: Calibri;
            padding:6px;
            border:1px solid #ddd;
        }

        p
        {
            color:#333;
            font-size: 13px;
            font-family: Calibri;
        }

        .cellvalue
        {
            text-align:right;
        }

        .head
        {
            font-weight:bold;
            text-align:center;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="Result" runat="server">
        </div>
    </form>
</body>
</html>
