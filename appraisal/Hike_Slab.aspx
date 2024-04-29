<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Hike_Slab.aspx.cs" Inherits="Appraisal_Hike_Slab" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px; background-color: white">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                            Hike Table
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="divHike" class="example_alt_pagination">
                                            <%--<h4>
                                                <asp:Label ID="lblOtstanding" runat="server" Text="Outstanding" Style="padding-left: 5px; font: medium; color: black"></asp:Label>
                                                <asp:Label ID="lblExcdExptn" runat="server" Text="Exceed Expectation" Style="padding-left: 10px; color: black"></asp:Label>
                                                <asp:Label ID="lblMetExptn" runat="server" Text="Met Expectation" Style="padding-left: 10px; color: black"></asp:Label>
                                                <asp:Label ID="lblBexptn" runat="server" Text="Below Expectation" Style="padding-left: 10px; color: black"></asp:Label>
                                                <asp:Label ID="lblNMexptn" runat="server" Text="Not Met Expectation" Style="padding-left: 10px; color: black"></asp:Label>
                                            </h4>--%>
                                            <table id="tbl_Hike" runat="server" border="1">
                                                <%--<thead title="Outstanding"></thead>--%>
                                                <tr>
                                                    <th style="text-align: center;width:90px">Outstanding</th>
                                                    <th style="text-align: center;width:90px">Exceed Expectation</th>
                                                    <th style="text-align: center;width:90px">Met Expectation</th>
                                                    <th style="text-align: center;width:90px">Below Expectation</th>
                                                    <th style="text-align: center;width:100px">Not Met Expectation</th>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;font:bold">100</td>
                                                    <td style="text-align: center;height:35px">90 - 99.9</td>
                                                    <td style="text-align: center">80 - 89.9</td>
                                                    <td style="text-align: center">60 - 79.9</td>
                                                    <td style="text-align: center">Less than 60</td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: center;height:35px">20%</td>
                                                    <td style="text-align: center">15% - 19.9%</td>
                                                    <td style="text-align: center">10% - 14.9%</td>
                                                    <td style="text-align: center">5% - 9.99%</td>
                                                    <td style="text-align: center">Less than 4.99%</td>
                                                </tr>
                                            </table>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
