<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RejectedTravelForm.aspx.cs" Inherits="Travel_RejectedTravelForm" %>

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
                    <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
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
                    </asp:UpdateProgress>--%>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Rejected And Cancelled Travel Forms</h2>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="rejectedlist" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Rejected Travel Forms               
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grid_Travel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid" OnPreRender="grid_Travel_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccCode" runat="server" Text='<%#Eval("accountcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Departure">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("DateofDeparture","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Arrival">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("DateoofArrival","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Submitted Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcreateddate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No. of Trips">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrips" runat="server" Text='<%#Eval("nooftrips")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Domestic" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("DemosticTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="International" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("IntrnationalTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/TravelFormEdit.aspx?travelID={0}"
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
                        <div style="width: 100%; height: 30px"></div>
                        <div class="row-fluid" id="CancelledList" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Cancelled Travel Forms               
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example1" class="example_alt_pagination">
                                            <asp:GridView ID="grid_cancelTravel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid" OnPreRender="grid_Travel_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="S.No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex +1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Account Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAccCode" runat="server" Text='<%#Eval("accountcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Departure">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("DateofDeparture","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date Of Arrival">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("DateoofArrival","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Submitted Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcreateddate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No. of Trips">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrips" runat="server" Text='<%#Eval("nooftrips")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Domestic" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("DemosticTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="International" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("IntrnationalTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/RejectedTravelForm.aspx?travelID={0}"
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
                                                            <tr style="display:none">
                                                                <td class="frm-lft-clr123 border-bottom">Grade
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblgrade" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Employee Status
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblempstatus" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Work Location
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
                                                                <td class="frm-lft-clr123 border-bottom">Designation
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lbldesingantion" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr style="display: none">
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
                                                                    <asp:Label ID="lblCostcenter" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Mobile No.
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblmobileno" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                             
                                                            <tr style="display: none">
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
                                                    <td class="frm-lft-clr123" style="width: 20%">Travel Code
                                                    </td>
                                                    <td class="frm-rght-clr123" style="width: 30%">
                                                        <asp:Label ID="lblAcCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123" style="width: 20%">Travel Form Submitted Date
                                                    </td>
                                                    <td class="frm-rght-clr123" style="width: 30%">
                                                        <asp:Label ID="lblsubmitteddate" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 20%">Travel Purpose
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 80%" colspan="3">
                                                        <asp:Label ID="lblTravelPurpose" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="miscellaneousdetails" runat="server" visible="false" style="display: none">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label2" runat="server" Text="Miscellaneous Allowance"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%" id="tblAllowance" runat="server" visible="false">
                                                <tr style="height: 40px">
                                                    <td class="frm-lft-clr123  border-bottom" style="width: 12%">Description
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 30%">
                                                        <asp:TextBox ID="txtAdvanceDesc" TextMode="MultiLine" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdvanceDesc"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Description" ValidationGroup="allo"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>

                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Currency
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 14%">
                                                        <asp:DropDownList ID="ddlCurrecny" runat="server" CssClass="blue1" Width="80%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCurrecny"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="allo" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">Amount
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 20%">
                                                        <asp:TextBox ID="txtAdvanceAmount" runat="server" CssClass="blue1" Width="80%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdvanceAmount"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Amount" ValidationGroup="allo"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtAdvanceAmount"
                                                            ValidationGroup="allo" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only decimals upto 2 places"
                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                        <asp:HiddenField ID="hfAllownaceID" runat="server" />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="6" height="5px"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" align="right">
                                                        <%-- <asp:Button ID="btnAllowaceSave" runat="server"
                                                            Text="Save" OnClick="btnAllowaceSave_Click" />
                                                        <asp:Button ID="btnAllowaceCancel" runat="server" CssClass="btn"
                                                            Text="Cancel" OnClick="btnAllowaceCancel_Click" />--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" height="5px"></td>
                                                </tr>
                                            </table>
                                            <div class=" no-margin" style="float: right">
                                                <%--<asp:Button ID="btnAddAdvance" runat="server" CssClass="btn btn-primary" ValidationGroup="allo"
                                                    Text="Add" OnClick="btnAddAdvance_Click" />--%>
                                            </div>
                                            <div style="height: 40px; float: right"></div>
                                            <div id="dt_example2" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Advance" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" DataKeyNames="id" OnPreRender="grid_Advance_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("advance_desc")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCurrency" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                                <div class="clearfix"></div>
                                            </div>
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

                                            <div id="dt_example3" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Trip" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" DataKeyNames="tripid" OnPreRender="grid_Trip_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="S.No.">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Of Departure">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("departuredate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date Of Arrival">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("arrivaldate","{0:dd-MMM-yyyy}")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="From">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSource" runat="server" Text='<%#Eval("fromplace")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="To">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDestination" runat="server" Text='<%#Eval("toplace")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Travel Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltraveltype" runat="server" Text='<% #Eval("triptype").ToString() == "I" ? "International" : "Domestic"%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Accommodation">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAccommodation" runat="server" Text='<%#Eval("staytype")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>
                                                <div class="clearfix"></div>
                                            </div>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid" id="divKit" runat="server" visible="false">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <asp:Label ID="Label5" runat="server" Text="Privilege Allowances"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 50%; vertical-align: top">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Kit Allowance?
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:RadioButtonList ID="rbtnl_kitallowance" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Enabled="false" Height="25px">
                                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trkitamount" runat="server" visible="false">
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Kit Allowance Amount
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:Label ID="lblKitallowanceamount" runat="server"></asp:Label>
                                                                <asp:HiddenField ID="hfkitallowanceid" runat="server" />
                                                            </td>
                                                        </tr>
                                                        <tr id="trprvkit" runat="server" visible="false">
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Previous Kit Allowance
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:Label ID="lblprvkitallownace" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>

                                                <td style="width: 50%; vertical-align: top" align="right">
                                                    <table style="width: 99%">
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Do you need Insurance?
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:RadioButtonList ID="rbtnl_insurance" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Height="25px" Enabled="false">
                                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Do you need VISA to be arranged?
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:RadioButtonList ID="rbtnl_visa" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Height="25px" Enabled="false">
                                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid" id="approverdetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approvers
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example4" class="example_alt_pagination">
                                            <asp:GridView ID="Grid_Approvers" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found" OnPreRender="Grid_Approvers_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("approverlevel")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrole" runat="server" Text='<%#Eval("approverrole")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("approverstatus")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>

                                        </div>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row-fluid" id="divpreviouscomment" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Previous Comments
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example5" class="example_alt_pagination">
                                            <asp:GridView ID="Gridcomments" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrole" runat="server" Text='<%#Eval("approverrole")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("comments")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions no-margin" style="text-align: right; vertical-align: central" id="divbuttons" runat="server">
                            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-primary" Style="margin-top: 20px"
                                Text="Back" OnClick="btnClose_Click" />
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
            $(document).ready(function () {
                $('#grid_cancelTravel').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('#grid_Advance').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#grid_Trip').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">
            $(document).ready(function () {
                $('#Grid_Approvers').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

         <script type="text/javascript">
             $(document).ready(function () {
                 $('#Gridcomments').dataTable({
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
