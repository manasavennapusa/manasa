<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthlyattendancereport.aspx.cs" Inherits="attendance_monthlyattendancereport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        table {
            border-collapse: collapse;
        }

            table tr td {
                color: #333;
                font-size: 13px;
                font-family: Book Antiqua;
                padding: 6px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" Text="Export" />
            <br />
            <br />

            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped table-bordered table-hover table-checkable datatable" OnRowDataBound="GridView1_RowDataBound">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
