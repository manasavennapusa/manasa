<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelHistory.aspx.cs" Inherits="Travel_TravelHistory" %>

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
    <link href="../css/blue1.css" rel="stylesheet" />
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
                                <h2>Travel History</h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="travelform" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Travel Forms In Process
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grid_Travel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid" OnRowEditing="grid_Travel_RowEditing" OnPreRender="grid_Travel_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
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
                                                   
                                                      <asp:HyperLinkField HeaderText=" View" HeaderStyle-Width="10%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/ExpenseView.aspx?travelID={0}"
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

                        <div class="row-fluid" id="closedtravelforms" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Closed Travel Forms
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grd_ClosedTravels" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid"  OnPreRender="grd_ClosedTravels_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
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
                                                   
                                                      <asp:HyperLinkField HeaderText="View" HeaderStyle-Width="10%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/ExpenseView.aspx?travelID={0}"
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

                        <div class="row-fluid" id="empdetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span4" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label4" runat="server" Text="Employee Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Employee Code

                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="lblempcode" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Employee Name
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblempname" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Grade
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblgrade" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Designation
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lbldesingantion" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Location
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Department
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lbldept" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Reporting Manager
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblmgr" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Cost Center
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Bank Account No.
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblbank" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">ACCPAC Code
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblaccpac" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="traveldetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label1" runat="server" Text="Travel Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr style="height: 40px;">
                                                    <td class="frm-lft-clr123" style="width: 20%">Account Code
                                                    </td>
                                                    <td class="frm-rght-clr123" style="width: 80%">
                                                        <asp:Label ID="lblAcCode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 20%">Travel Purpose
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 80%">
                                                        <asp:Label ID="lblTravelPurpose" runat="server"></asp:Label>
                                                        <%--<asp:TextBox ID="txt_travelpurpose" Enabled="false" TextMode="MultiLine" runat="server" CssClass="blue1" Width="60%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_travelpurpose"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Travel Purpose" ValidationGroup="travel"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                        <div class=" no-margin" style="float: right">
                                                            <asp:Button ID="btnEditTravel" runat="server" CssClass="btn btn-primary"
                                                                Text="Edit" OnClick="btnEditTravel_Click" />
                                                            <asp:Button ID="btnupdateTravel" runat="server" CssClass="btn btn-warning" ValidationGroup="travel" Visible="false"
                                                                Text="Update" OnClick="btnupdateTravel_Click" />
                                                            <asp:Button ID="btnTravelCancel" runat="server" CssClass="btn" Visible="false"
                                                                Text="Cancel" OnClick="btnTravelCancel_Click" />
                                                        </div>--%>
                                                    </td>
                                                </tr>
                                            </table>


                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="tripdetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label3" runat="server" Text="Trip Details"></asp:Label>

                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div id="Div1" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Trip" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" DataKeyNames="tripid" OnRowEditing="grid_Trip_RowEditing">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No." HeaderStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Of Departure" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("departuredate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Of Arrival" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("arrivaldate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="From" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSource" runat="server" Text='<%#Eval("fromplace")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="To" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("toplace")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Travel Type" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltraveltype" runat="server" Text='<% #Eval("triptype").ToString() == "I" ? "International" : "Domestic"%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Accommodation" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccommodation" runat="server" Text='<%#Eval("staytype")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="View" HeaderStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton
                                                                    ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="View"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <table style="width: 100%" id="tbl_tripDetails" runat="server" visible="false">

                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 10%">Expense Type</td>
                                                    <td class="frm-lft-clr123" style="width: 10%">Pre Travel Advance</td>
                                                    <td class="frm-lft-clr123" style="width: 10%">Post Travel Expense Claim</td>
                                                    <td class="frm-lft-clr123" style="width: 10%">Default Amount</td>
                                                    <td class="frm-lft-clr123" style="width: 10%" id="exemanag" runat="server" visible="true">Exception</td>
                                                     <td class="frm-lft-clr123" style="width: 15%" id="tdmgr" runat="server" visible="false">Manager Status</td>
                                                     <td class="frm-lft-clr123" style="width: 15%" id="tdmgmt" runat="server" visible="false">Management Status</td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Travel</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpretravel" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblposttravel" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtdefamtt" runat="server" Width="70%" Visible="false"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag1" runat="server" visible="true">
                                                        <asp:CheckBox ID="chktrvel" runat="server" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                     <td class="frm-rght-clr123" id="tdmgrtravel" runat="server" visible="false">
                                                        <asp:Label ID="lbltravelmgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmttravel" runat="server" visible="false">
                                                        <asp:Label ID="lbltravelmgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Lodging</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblprelodge" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpostlodge" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtlod" runat="server" Visible="false" Width="70%"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag2" runat="server" visible="true">
                                                        <asp:CheckBox ID="chklodge" runat="server" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                     <td class="frm-rght-clr123" id="tdmgrlodge" runat="server" visible="false">
                                                        <asp:Label ID="lbllodgemgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmtlodge" runat="server" visible="false">
                                                        <asp:Label ID="lbllodgemgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Conveyance</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpreconv" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpostconv" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="conv">
                                                        <asp:Label ID="txtcony" runat="server" Visible="false" Width="70%"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag3" runat="server" visible="true">
                                                        <asp:CheckBox ID="chkconv" runat="server" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                     <td class="frm-rght-clr123" id="tdmgrconv" runat="server" visible="false">
                                                        <asp:Label ID="lblconvemgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmtconv" runat="server" visible="false">
                                                        <asp:Label ID="lblconvmgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Meals</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpremeals" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpostmeals" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="meals">
                                                        <asp:Label ID="txtmeals" runat="server" Visible="false" Width="70%"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag4" runat="server" visible="true">
                                                        <asp:CheckBox ID="chkmeals" runat="server"  Enabled="false"></asp:CheckBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="tdmgrmeals" runat="server" visible="false">
                                                        <asp:Label ID="lblmealsemgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmtmeals" runat="server" visible="false">
                                                        <asp:Label ID="lblmealsmgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">OOP</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpreoop" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpostoop" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtoop" runat="server" Visible="false" Width="70%"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag5" runat="server" visible="true">
                                                        <asp:CheckBox ID="chkoop" runat="server" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="tdmgroop" runat="server" visible="false">
                                                        <asp:Label ID="lbloopmgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmtoop" runat="server" visible="false">
                                                        <asp:Label ID="lbloopmgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Others</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpreothers" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpostothers" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtothers" runat="server" Visible="false" Width="70%"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="exemanag6" runat="server" visible="true">
                                                        <asp:CheckBox ID="chkothers" runat="server" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="tdmgrother" runat="server" visible="false">
                                                        <asp:Label ID="lblothersemgrstatus" runat="server"></asp:Label></td>
                                                     <td class="frm-rght-clr123" id="tdmgmtothers" runat="server" visible="false">
                                                        <asp:Label ID="lblothersmgmtstatus" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">Total</td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblpretotal" Font-Bold="true" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" style="text-align: right">
                                                        <asp:Label ID="lblposttotal" Font-Bold="true" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="Label8" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" id="exemanag7" runat="server" visible="true">
                                                        <asp:Label ID="Label12" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-rght-clr123" id="tdmgr2" runat="server" visible="false">
                                                        </td>
                                                     <td class="frm-rght-clr123" id="tdmgmt2" runat="server" visible="false">
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="8" style="text-align: right; height: 50px">
                                                        <asp:Button ID="btnclose" runat="server" Text="Close" CssClass="btn" OnClick="btnBack_Click" />
                                                        <asp:Button ID="btnsubmit" runat="server" Text="Save" ValidationGroup="allo" Visible="false" CssClass="btn" OnClick="btnsubmit_Click" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="clearfix"></div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="row-fluid" id="miscellaneousdetails" runat="server">
                            <div class="row-fluid">
                                <div class="span8">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Travel Expense Summary 
                 
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 50%; vertical-align: top">
                                                        <table style="width: 99%" align="left">
                                                            <tr>
                                                                <td class="txt02" colspan="2" style="height: 25px">Pre Booking Summary</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div id="Div4" class="example_alt_pagination">
                                                                        <asp:GridView ID="grd_prebooked" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                            EmptyDataText="No Data  Found" ShowFooter="true" OnRowDataBound="grd_prebooked_RowDataBound">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Trip">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblcode" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Details">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Details")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total Booking"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Currency">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblINR" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lbltotalINR" runat="server"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Amount">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblUSD" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label ID="lbltotalUSD" runat="server"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="INRSTD">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblINRSTD" runat="server" Text='<%#Eval("AmountINR")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <FooterTemplate>
                                                                                        <asp:Label Font-Bold="true" ID="lbltotalINRSTD" runat="server"></asp:Label>
                                                                                    </FooterTemplate>
                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                    <FooterStyle HorizontalAlign="Right" />
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </div>
                                                                    <div class="clearfix"></div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" style="height: 10px"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txt02" colspan="2" style="height: 25px">Miscellaneous Allowance</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:GridView ID="grid_allowancetotal" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                        EmptyDataText="No Data Exists" ShowFooter="true" OnRowDataBound="grid_allowancetotal_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("advance_desc")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="15%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblINR" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                    <asp:Label ID="Label7" runat="server" Text='<%#Eval("currencytype")%>' Visible="false"></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="INRSTD">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblINRSTD" runat="server"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lbltotalINRSTD" Font-Bold="true" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 50%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="txt02" colspan="2" style="height: 25px">Advance Amount Summary</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:GridView ID="gridAdvanceSummary" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                        EmptyDataText="No Data  Found" ShowFooter="true" OnRowDataBound="gridAdvanceSummary_RowDataBound">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Trip">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblcode" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Details">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Details")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total Booking"></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Currency">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblINR" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lbltotalINR" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Amount">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblUSD" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lbltotalUSD" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="INRSTD">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblINRSTD" runat="server" Text='<%#Eval("AmountINR")%>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label Font-Bold="true" ID="lbltotalINRSTD" runat="server"></asp:Label>
                                                                                </FooterTemplate>
                                                                                <ItemStyle HorizontalAlign="Right" />
                                                                                <FooterStyle HorizontalAlign="Right" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 5px" colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txt02" style="width: 50%">Total Estimation Amount</td>
                                                                <td style="width: 50%">
                                                                    <asp:Label ID="Label2" runat="server" Text="INR" Width="30%"></asp:Label>
                                                                    <asp:Label ID="txtEstimation" runat="server"></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="txt02">Final Advance Given</td>
                                                                <td>
                                                                    <asp:Label ID="lbINR" runat="server" Text="INR" Width="30%"></asp:Label>
                                                                    <asp:Label ID="txtFinalAmountGiven1" runat="server"></asp:Label>

                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 5px" colspan="2"></td>
                                                            </tr>
                                                            <tr style="display: none">
                                                                <td class="txt02">Final Advance Given</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddl_finalCurrency" runat="server" CssClass="blue1" Width="30%">
                                                                        <asp:ListItem Value="2">USD</asp:ListItem>
                                                                        <asp:ListItem Value="3">EUR</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:TextBox ID="txtFinalAmountGiven2" runat="server" Width="40%" Height="15px" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                                <div class="span4">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Post Travel Expense Summary
                                                 
                                            </div>
                                        </div>
                                        <div class="widget-body">

                                            <div id="Div6" class="example_alt_pagination">
                                                <table style="width: 100%" align="right">
                                                    <tr>
                                                        <td class="txt02" style="height: 25px">Post Travel Expense  </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="grdposttravel" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data  Found" ShowFooter="true" OnRowDataBound="grdposttravel_RowDataBound">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Trip">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("tripid")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Receipt No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Expense Type">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblINR" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblUSD" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label Font-Bold="true" ID="lbltotalINRSTD" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </div>
                                            <div class="clearfix"></div>

                                        </div>
                                    </div>
                                </div>
                              </div>
                              <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Difference Amount
                                                 
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="6" height="40px" class="txt02">Difference Amount </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Employee Return</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblEmpReturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Organization Payback</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblOrgPayback" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="span12" style=" display:none">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label6" runat="server" Text="Expense Details"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 50%" id="tblAllowance" runat="server">
                                                <tr>
                                                    <td colspan="6" height="40px" class="txt02">Final Pre Tavel Total </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Pre Booking Total</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblprebooking" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Advance Amount Total</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblAdvancetotal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Total</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblpretraveltotal" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" height="40px" class="txt02">Final Post Tavel Total </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="6">
                                                        <asp:GridView ID="grid_Expanse" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                            EmptyDataText="No Data Exists" DataKeyNames="tripid" ShowFooter="true" OnRowDataBound="grid_Expanse_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Trip" HeaderStyle-Width="46%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("tripid")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>Total</b>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="15%" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblCurrency" runat="server"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="54%">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalAmount" Font-Bold="true" runat="server"></asp:Label>
                                                                    </FooterTemplate>
                                                                </asp:TemplateField>
                                                                <%--<asp:TemplateField HeaderText="Edit" HeaderStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton
                                                                    ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton
                                                                    ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <%--<tr>
                                                    <td colspan="6" height="40px" class="txt02">Difference Amount </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Employee Return</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblEmpReturn" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Organization Payback</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:Label ID="lblOrgPayback" runat="server"></asp:Label>
                                                    </td>
                                                </tr>--%>
                                            </table>
                                            <div class=" no-margin" style="float: right">
                                                <%--<asp:Button ID="btnAddAdvance" runat="server" CssClass="btn btn-primary" ValidationGroup="allo"
                                                    Text="Add" OnClick="btnAddAdvance_Click" />--%>
                                            </div>
                                            <div style="height: 40px; float: right"></div>
                                            <div id="Div2" class="example_alt_pagination">
                                            </div>
                                            <div class="clearfix"></div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="approverdetails" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approvers
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="Div3" class="example_alt_pagination">
                                            <asp:GridView ID="Grid_Approvers" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("approverlevel")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("approverstatus")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>

                                    </div>
                                </div>
                            </div>
                            <div class="form-actions no-margin" style="text-align: right">
                               
                                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary"
                                    Text="Close" OnClick="btnBack_Click" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
          <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grid_Travel').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grd_ClosedTravels').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grid_Trip').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Approvers').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>
    </form>
</body>
</html>
