<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RejectedExpenseForms.aspx.cs" Inherits="Travel_RejectedExpenseForms" %>

<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../img/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>View Rejected Expense Details</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid" id="travelforms" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Travel Forms               
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grid_Travel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccCode" runat="server" Text='<%#Eval("accountcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Departure" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("DateofDeparture","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Arrival" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("DateoofArrival","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Submitted Date" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcreateddate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No. of Trips" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrips" runat="server" Text='<%#Eval("nooftrips")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Domestic" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("DemosticTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="International" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                              <span class="fs1" aria-hidden="true" data-icon='<%#Eval("IntrnationalTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:HyperLinkField HeaderText="View" HeaderStyle-Width="10%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/EditRejectedExpense.aspx?travelid={0}"
                                                        Text='View'>
                                                        <ControlStyle CssClass="link05" />
                                                    </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>