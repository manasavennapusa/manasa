<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EDB_Query_Grid.aspx.cs" Inherits="EDB_Query_Grid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
    </style>
    <script type="text/javascript">
        function IsNumericDot(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
    <style type="text/css">

        /* Style buttons */
.btn {
    background-color:#be4b4b; /* Blue background */
    border: none; /* Remove borders */
    color: white; /* White text */
    padding: 3px 10px 3px 9px;  /*Some padding*/ 
    font-size: 16px; /* Set a font size */
    cursor: pointer; /* Mouse pointer on hover */
}

/* Darker background on mouse-over */
.btn:hover {
    /*background-color: RoyalBlue;*/
     background-color:#c72929;
}
    </style>

    <link href="css/font-awesome.min.css" rel="stylesheet" />
    <!-- Add icon library -->
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />
</head>
<body>
    <form id="myForm" runat="server">
        <table style="width: 100%;" cellspacing="0" cellpadding="0">
            <%-- <tr>
                  <td style="padding:10px 10px 10px 10px">
                       <asp:Button ID="btn_export" runat="server" Text="Export" CssClass="btn btn-info" OnClick="btn_export_Click" />
                  </td>
                 </tr>--%>
            <tr>
                <td style="background-color: #08486d;padding:6px 6px 6px 6px;text-align:center">
                    <asp:Label ID="lbl" runat="server" style="color:#fff;font-size:22px">Employee Details</asp:Label>

                    <button class="btn" style="float:right" onclick="javascript:window.close()"><i class="fa fa-close"></i></button>
                   <%-- <button class="btn"style="float:right"><i class="fa fa-close"></i> Close</button>--%>
                </td>
            </tr>
            <tr>
                <td style="text-align: center;">
                    <div style="width: 100%;" align="center" valign="top">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" Style="background-color: #f8f8f8; table-layout: auto; font-size: small; text-align: center; box-shadow: 1px 1px 1px 1px #b6ff00 inset" CellPadding="2" ForeColor="#333333" Visible="true"
                            EmptyDataText="No Record Found !!" GridLines="Both">
                            <AlternatingRowStyle BackColor="White" />
                            <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
                            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                            <SortedAscendingCellStyle BackColor="#FDF5AC" />
                            <SortedAscendingHeaderStyle BackColor="#4D0000" />
                            <SortedDescendingCellStyle BackColor="#FCF6C0" />
                            <SortedDescendingHeaderStyle BackColor="#820000" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
        </table>

    </form>
</body>
</html>
