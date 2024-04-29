<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelStatus.aspx.cs" Inherits="Travel_TravelStatus" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
</head>
<body>
    <form id="myForm" runat="server">

        <script type="text/javascript">
            function isKey(keyCode) {
                return false;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Travel Detials</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search 
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>

                                    <div class="control-group">
                                        <label class="control-label">Travel Status</label>
                                        <div class="controls">
                                            <asp:DropDownList ID="drp_leavestatus" runat="server" CssClass="span3" Width="">
                                                <asp:ListItem Value="0">---Select---</asp:ListItem>                                              
                                                <asp:ListItem Value="0">Pending</asp:ListItem>
                                                <asp:ListItem Selected="True" Value="1">Approved</asp:ListItem>                                            
                                                <asp:ListItem Value="2">Rejected</asp:ListItem>                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                   

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return ValidateData();" />

                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" OnClick="btn_reset_Click" Text="Reset" ValidationGroup="c" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--  </ContentTemplate>
                    </asp:UpdatePanel>--%>

                    <div class="row-fluid">
                        <div class="span12">
                            <%--<div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                    </div>

                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">

                                      <div class="widget-body">
                                        <div id="dt_example1" class="example_alt_pagination">
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
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="13%">
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
                                                    <asp:HyperLinkField HeaderText="View" HeaderStyle-Width="6%" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/ApprovedTravelForm.aspx?travelID={0}"
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
                        </div>--%>

                      <%--<div class="row-fluid" id="travelform" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                  <%--  <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Travel Forms               
                                           
                                        </div>
                                    </div>--%
                                    <div class="widget-body">
                                        <div id="Div1" class="example_alt_pagination">
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelid" OnPreRender="GridView1_PreRender">
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
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="14%">
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
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("approverlevel") %>' class="label label-info" Visible='<%#Eval("approverlevel").ToString()=="Pending"?true:false%>'></asp:Label>
                                                                <asp:Label ID="Label10" runat="server" Text='<%# Bind("approverlevel") %>' class="label label-info" Visible='<%#Eval("approverlevel").ToString()=="Pending in MD"?true:false%>'></asp:Label>
                                                                <asp:Label ID="Label12" runat="server" Text='<%# Bind("approverlevel") %>' class="label label-info" Visible='<%#Eval("approverlevel").ToString()=="Pending in Admin"?true:false%>'></asp:Label>
                                                                <asp:Label ID="Label11" runat="server" Text='<%# Bind("approverlevel") %>' class="label label-info" Visible='<%#Eval("approverlevel").ToString()=="Pending in Finance"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("approverlevel") %>' class="label label-info" Visible='<%#Eval("approverlevel").ToString()=="Approved"?true:false%>'></asp:Label>
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
                                                    <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="travelid" DataNavigateUrlFormatString="~/Travel/PendingTravelForm.aspx?travelID={0}"
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
                        </div>--%>

                                    <%--<asp:GridView ID="grdpending1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                DataKeyNames="RID" OnPreRender="grdpending1_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RID" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbrid" runat="server" Text='<%#Eval("RID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltype" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:HyperLinkField DataNavigateUrlFields="RID" HeaderText="View" DataNavigateUrlFormatString="PendingClosed.aspx?RID={0}"
                                                NavigateUrl="PendingClosed.aspx" Text="&lt;img src='images/view.png'/&gt;">
                                                           <HeaderStyle CssClass=""  />
                                                <ControlStyle CssClass="link05" Width="50%" />
                                            </asp:HyperLinkField>
                                                </Columns>
                                            </asp:GridView>--%>
                                           


                                        <div class="clearfix"></div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
               
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grid_Travel').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
