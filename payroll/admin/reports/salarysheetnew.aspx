<%@ Page Language="C#" AutoEventWireup="true" CodeFile="salarysheetnew.aspx.cs" Inherits="payroll_admin_reports_salarysheetnew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divexport" runat="server">
                <table>
                    <tr>
                        <td>
                            <div id="tablehead" runat="server">
                            </div>
                        </td>
                        <td>
                             <asp:Button ID="btnexport" runat="server" CssClass="btn btn-primary" OnClick="btnexport_Click" Text="Export" ValidationGroup="c"  style="position:absolute;left:2161px;top:40px" /> 
                        </td>
                    </tr>
                    <tr>                       
                        <td>

                            <asp:GridView ID="GvCumulative" runat="server" OnRowDataBound="GvCumulative_RowDataBound" Width="1200"></asp:GridView>
                                        

                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </form>
</body>
</html>
