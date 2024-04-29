<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearlyLeaveReport_ReporteesDetails.aspx.cs" Inherits="Leave_YearlyLeaveReport_ReporteesDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        table
        {
            border-collapse: collapse;
        }

            table th
            {
                border: 1px solid #ddd;
                padding: 3px;
                font-family: Calibri;
                font-size: 12px;
            }

            table td
            {
                border: 1px solid #ddd;
                padding: 3px;
                font-family: Calibri;
                font-size: 12px;
            }

        #header
        {
            text-align: center;
            font-family: Calibri;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="header">
             My Reportees leave report for the calander year  <%= CalanderName %> - (<%= LeaveName %>)
        </div>
        <br />
        <div>
            <asp:GridView
                ID="grid"
                runat="server"
                OnRowDataBound="grid_RowDataBound">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
