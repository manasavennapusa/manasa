<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthlypfreoprt.aspx.cs" Inherits="payroll_admin_monthlypfreoprt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style>
        table
        {
            border-collapse: collapse;
        }

            table tr td
            {
                color: #333;
                font-size: 13px;
                font-family: Book Antiqua;
                padding: 10px;
            }

        .btn-head
        {
            font-weight: bold;
            color: #4d4d4d;
            font-size: 1.7em;
        }

        .botn
        {
            background-color: #62a6d0; /* Green */
            border-radius: 4px;
            border: none;
            color: white;
            padding: 8px 15px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 14px;
            margin: 4px 2px;
            cursor: pointer;
            -webkit-transition-duration: 0.4s; /* Safari */
            transition-duration: 0.4s;
        }

            .botn:hover
            {
                background-color: #337ead;
                color: white;
                box-shadow: 0 12px 16px 0 rgba(0,0,0,0.24),0 17px 50px 0 rgba(0,0,0,0.19);
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <center> 
        <div >
            <asp:Button ID="btnExport"  runat="server" OnClick="btnExport_Click" Text="Export" CssClass="botn" style="vertical-align:middle;float:left"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            


                  
            <br />
            <br />
            <div style="width:100%; text-align:center;">
                 <div style="width: 50%; background-color:aqua; margin:  0px auto; text-align:left; visibility:collapse" ></div><br />
</div>
                 <asp:Label ID="Label1" runat="server"  style="margin:-200px" BackColor="#0066ff" ForeColor="#ffffff"  Font-Size="Large"  Text="PF Monthly Report" ></asp:Label>  
            </div>
            <div>
            <asp:Label ID="lbl_compname" ForeColor="#70a1ff"  Font-Size="Large"  runat="server" style="margin-left:10px "></asp:Label> 
            <asp:Label ID="lbl_epf" ForeColor="#70a1ff"  Font-Size="Large"  runat="server"  Text="Employer PF No.:" style="padding-left:350px" ></asp:Label>&nbsp;<asp:Label ID="lbl_epfdetails" runat="server" CssClass="btn-head" ForeColor="#70a1ff"  Font-Size="Large"></asp:Label>
           <center><asp:Label ID="Label5" ForeColor="#70a1ff" Font-Size="Large" runat="server" Text="PF report for month of">&nbsp;</asp:Label><asp:Label ID="lbldate" runat="server" CssClass="btn-head" ForeColor="#70a1ff"  Font-Size="Large"></asp:Label> </center>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server"  CssClass="table table-striped table-bordered table-hover table-checkable datatable"  BorderStyle="Solid"  HeaderStyle-BackColor="#0652DD" HeaderStyle-ForeColor="White"  OnRowDataBound="GridView1_RowDataBound">
                 <RowStyle HorizontalAlign="Center" />
            </asp:GridView>
        </div>
             </center>
    </form>
</body>
</html>
