<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproveTravelExpanse.aspx.cs" Inherits="Travel_ApproveTravelExpanse" %>

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
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script src="../js/JavaScriptValidations.js"></script>
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
    <style>
        .center
        {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager" runat="server">
        </asp:ScriptManager>
        <script language="javascript" type="text/javascript">
            function confirmCancel() {
                var comm = document.getElementById('<%=txtmgrcomments.ClientID %>');
                   if (comm.value == "") {
                       alert("Please enter comments");
                       comm.focus();
                       return false;
                   }
                   if (confirm("Are you sure you want to Reject!"))
                       return true;
                   return false;
               }

        </script>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                     <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="images/loader.gif" alt="" />
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Travel Expense</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="travelform" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Travel Expense                                                          
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
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
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
                                                    <%--<asp:TemplateField HeaderText="Domestic" HeaderStyle-Width="8%" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("DemosticTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="International" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("IntrnationalTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="View" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton
                                                                ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="View"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:HyperLinkField HeaderText="View" HeaderStyle-Width="10%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/ApproveTravelExpanse.aspx?travelID={0}"
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

                        <div class="row-fluid" id="Div5" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Rejected Travel Expense               
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example2" class="example_alt_pagination">
                                            <asp:GridView ID="grd_rejectedExpense" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid" OnPreRender="grd_rejectedExpense_PreRender">
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
                                                    <%--<asp:TemplateField HeaderText="Domestic" HeaderStyle-Width="8%" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("DemosticTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="International" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("IntrnationalTrip").ToString()=="0"?"":"&#xe0fe;"%>'></span>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="View" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton
                                                                ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="View"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:HyperLinkField HeaderText="View" HeaderStyle-Width="10%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/ApproveTravelExpanse.aspx?travelID={0}"
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
                                                            <tr style="display:none;">
                                                                <td class="frm-lft-clr123 border-bottom">Grade
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblgrade" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Employee status
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
                                                                <td class="frm-lft-clr123 border-bottom">Mobile NO
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
                                                        EmptyDataText="No Data Exists" DataKeyNames="tripid">
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
                                                            <asp:TemplateField HeaderText="Travel View">
                                                                <ItemTemplate>
                                                                    <%--<asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="View"></asp:LinkButton>--%>
                                                                    <a href="javascript:void(window.open('ViewFullTripDetails.aspx?tripid=<%# Eval("tripid") %>','title','height=650,width=1100,left=100,top=30'));" class="link05">View </a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Expense View / Edit" HeaderStyle-Width="5%">
                                                                <ItemTemplate>
                                                                    <%-- <asp:LinkButton
                                                                    ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="View"></asp:LinkButton>--%>
                                                                    <a href="javascript:void(window.open('viewExpenseDetailsbyAdmin.aspx?tripid=<%# Eval("tripid") %>','title','height=700,width=1300,left=100,top=30'));" class="link05">View / Edit</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="clearfix"></div>
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
                            <div class="row-fluid" id="miscellaneousdetails" runat="server">
                                <div class="row-fluid" id="Div2" runat="server">

                                    <div class="span6">
                                        <div class="widget">
                                            <div class="widget-header">
                                                <div class="title">
                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Pre Travel Advance Summary 
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <table style="width: 100%">

                                                    <tr>
                                                        <td class="txt02" colspan="2" style="height: 25px">Pre Booking Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <div id="Div7" class="example_alt_pagination">
                                                                <asp:GridView ID="grd_prebooked" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                    EmptyDataText="No Data  Found" ShowFooter="false">
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
                                                                                <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
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
                                                                        <asp:TemplateField HeaderText="INRSTD" Visible="false">
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
                                                        <td class="txt02" colspan="2" style="height: 25px">Total Pre Booked Amount</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="grd_pretraveltotals" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data  Found" ShowFooter="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="50%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            <%--  <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="50%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblamount" runat="server" ForeColor="Orange" Text='<%#Eval("total")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 10px"></td>
                                                    </tr>
                                                    <tr id="trkitallowance1" runat="server">
                                                        <td style="height: 25px" colspan="2" class="txt02">Kit Allowance </td>
                                                    </tr>
                                                    <tr id="trkitallowance2" runat="server">
                                                        <td colspan="2">

                                                            <asp:GridView ID="grd_kitallowancedetials" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data  Found" ShowFooter="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="40%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="60%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDetails" runat="server" ForeColor="Orange" Text='<%#Eval("kitallowance")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txt02" colspan="2" style="height: 25px">Advance Estimation Details</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="gridAdvanceSummary" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data  Found" ShowFooter="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Trip">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            <asp:Label ID="lbltripid" runat="server" Text='<%#Eval("tripid")%>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Details">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("allowancetype")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Currency">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcurrency" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltotalINR" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Per Day">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblperdaycost" runat="server" Text='<%#Eval("perdaycost")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lbltotalUSD" runat="server"></asp:Label>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No of Days">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldays" runat="server" Text='<%#Eval("totaldays")%>'></asp:Label>
                                                                        </ItemTemplate>

                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Total">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("totalcost")%>'></asp:Label>
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
                                                        <td colspan="2" style="height: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="txt02" colspan="2" style="height: 25px">Total Advance Estimation Amount</td>

                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:GridView ID="grd_estimationtotals" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data  Found" ShowFooter="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="30%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>

                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Estimation Amount" HeaderStyle-Width="30%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Given Amount" HeaderStyle-Width="35%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="txtgiven" runat="server" ForeColor="Blue" CssClass="span12" Style="text-align: right" Text='<%#Eval("giventotal")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="height: 10px"></td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td class="txt02" colspan="2" style="height: 25px">Miscellaneous Allowance Details</td>
                                                    </tr>
                                                    <tr style="display: none">
                                                        <td colspan="2">
                                                            <asp:GridView ID="grid_allowancetotal" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                EmptyDataText="No Data Exists" ShowFooter="false">
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
                                                                    <asp:TemplateField HeaderText="INRSTD" Visible="false">
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
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span6">
                                        <div class="widget">
                                            <div class="widget-header">
                                                <div class="title">
                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Post Travel Expense Summary
                 
                                                </div>
                                            </div>
                                            <div class="widget-body">
                                                <div id="Div8" class="example_alt_pagination">
                                                    <%--         <asp:UpdatePanel ID="upExpenseSummary" runat="server">
                                                    <ContentTemplate>--%>
                                                    <table style="width: 100%">

                                                        <tr>
                                                            <td class="txt02" style="height: 25px">Expense Claims</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdExpenseSummary" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                    EmptyDataText="No Data  Found" ShowFooter="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Details" HeaderStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("Details")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lbltotal" Font-Bold="true" runat="server" Text="Total"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="25%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblINR" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lbltotalINR" runat="server"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Claimed Amount" HeaderStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUSD" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="25%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="txtSantionedAmount" ForeColor="Red" runat="server" Text='<%#Eval("sanctionedamount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 10px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" style="height: 25px">Total Expense Claims </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grdTotalExpanse" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                    EmptyDataText="No Data  Found" ShowFooter="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="30%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                <%--  <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>--%>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Claimed Amount" HeaderStyle-Width="35%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Sanctioned Amount" HeaderStyle-Width="35%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblamount" runat="server" ForeColor="Green" Text='<%#Eval("sanctionedamount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>

                                                    </table>
                                                    <%--      </ContentTemplate>
                                                </asp:UpdatePanel>--%>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="row-fluid" id="divExpenseTally" runat="server">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Expense Tally
                 
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div class="example_alt_pagination">

                                                <asp:GridView ID="GridTally" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left" Width="100%"
                                                    EmptyDataText="No Data  Found" ShowFooter="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Pre Travel Advance Given Amount" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="txtgiven" runat="server" ForeColor="Blue" CssClass="span12" Style="text-align: right" Text='<%#Eval("giventotal")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Expense Sanctioned Amount" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamount" runat="server" ForeColor="Green" Text='<%#Eval("sanctionedamount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Organization Pay Back" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("orgpayback").ToString()==""?"0":Eval("orgpayback").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Pay Back" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("emppayback").ToString()==""?"0":Eval("emppayback").ToString()%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                            <FooterStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>


                                            </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row-fluid" id="approvers" runat="server">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approvers                 
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example3" class="example_alt_pagination">

                                                <asp:GridView ID="Grid_Approvers6" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data  Found" OnPreRender="Grid_Approvers6_PreRender">
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




                            <div class="row-fluid" id="approverdetails" runat="server">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Travel Comments
                 
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="Div3" class="example_alt_pagination">
                                                <asp:GridView ID="GridTravelComments" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left" Width="100%"
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
                                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
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

                            <div class="row-fluid" id="divpreviouscomment" runat="server">
                                <div class="span12">
                                    <div class="widget no-margin">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Expense Comments
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="Div4" class="example_alt_pagination">
                                                <asp:GridView ID="Gridcomments" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left" Width="100%"
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
                                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("createddate")%>'></asp:Label>
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

                            <div class="form-actions no-margin" style="padding-left: 20px" id="divbuttons" runat="server">
                                <div class="row-fluid">
                                    <div class="span8" style="text-align: left">
                                        Comments &nbsp;
                                        <asp:TextBox ID="txtmgrcomments" TextMode="MultiLine" runat="server" CssClass="blue1" Width="80%" Height="80px" MaxLength="8000" onkeypress="return isChar_Number_space()"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtmgrcomments"
                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Please Enter the comments" ValidationGroup="cmts"
                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtmgrcomments"
                                            ValidationGroup="travel" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only Alphabets"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                    </div>
                                    <div class="span4" style="text-align: right">
                                        <asp:Button ID="btnException" runat="server" CssClass="btn btn-primary" Text="Send For Approve Exception " ValidationGroup="travel" OnClick="btnException_Click" Visible="false" />
                                        <asp:Button ID="btnSumitForm" runat="server" CssClass="btn btn-primary" Text="Approve" ValidationGroup="travel" OnClick="btnSumitForm_Click" OnClientClick="return confirm('Are you sure.You want to Approve?')" />
                                        <asp:Button ID="btnRejecct" runat="server" CssClass="btn btn-primary" Text="Reject" ValidationGroup="cmts" OnClick="btnRejecct_Click" OnClientClick="return confirmCancel();" />
                                        <asp:Button ID="btnsend" runat="server" CssClass="btn btn-primary" Text="Send For Approve" ValidationGroup="travel" OnClick="btnsend_Click" Visible="false" />
                                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                    </div>
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
                $('#grd_rejectedExpense').dataTable({
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
