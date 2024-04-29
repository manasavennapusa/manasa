<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportmachinecode.aspx.cs" Inherits="attendance_reportmachinecode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                padding: 6px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" AutoGenerateColumns="true" runat="server" OnRowDataBound="GridView1_RowDataBound" CssClass="table table-striped table-bordered table-hover table-checkable datatable">
                <HeaderStyle BackColor="#009EFF" ForeColor="White" Font-Size="Medium" Height="20px" />
                <RowStyle Width="20px" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField HeaderText="SI No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
