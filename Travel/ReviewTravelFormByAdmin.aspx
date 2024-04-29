<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewTravelFormByAdmin.aspx.cs" Inherits="Travel_ReviewTravelFormByAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <script src="../js/JavaScriptValidations.js"></script>
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script src="../js/JavaScriptValidations.js"></script>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <script type="text/javascript">
            function disableBtn(btnID, newText) {

                var btn = document.getElementById(btnID);
                setTimeout("setImage('" + btnID + "')", 60000);
                btn.disabled = true;
                btn.value = newText;
            }

            function setImage(btnID) {
                var btn = document.getElementById(btnID);
                btn.style.background = 'url(12501270608.gif)';
            }
        </script>
        <script language="javascript" type="text/javascript">
            function confirmCancel() {
                var comm = document.getElementById('<%=txtmgrcomments.ClientID %>');
             if (comm.value == "") {
                 alert("Please enter comments");
                 comm.focus();
                 return false;
             }
             if (confirm("Are you sure you want to cancel!"))
                 return true;
             return false;
         }

        </script>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="updatepanel1" runat="server">
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
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Travel Form</h2>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
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
                                                                    <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
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
                        <div class="row-fluid">
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
                                                        <asp:TextBox ID="txt_travelpurpose" Enabled="false" TextMode="MultiLine" runat="server" CssClass="blue1" Width="60%" onkeypress="return isCharOrSpace()"></asp:TextBox>
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
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="span8" style="display: none;">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approvers
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
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
                                                    <asp:TemplateField HeaderText="Role">
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
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                            <div class="span8" style="display: none;">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label2" runat="server" Text="Miscellaneous Allowance"></asp:Label>
                                        </div>
                                        <asp:Button ID="btnAddAdvance" runat="server" CssClass="btn btn-info pull-right" ValidationGroup="allo"
                                            Text="Add" OnClick="btnAddAdvance_Click" />
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
                                                        <asp:TextBox ID="txtAdvanceAmount" runat="server" CssClass="blue1" Width="80%" onkeypress="return isNumber_dot()"></asp:TextBox>
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
                                                        <asp:Button ID="btnAllowaceSave" runat="server" Text="Save" OnClick="btnAllowaceSave_Click" />
                                                        <asp:Button ID="btnAllowaceCancel" runat="server" CssClass="btn" Text="Cancel" OnClick="btnAllowaceCancel_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="6" height="5px"></td>
                                                </tr>
                                            </table>
                                            <div style="height: 40px; float: right"></div>
                                            <div id="Div2" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Advance" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" OnRowDeleting="grid_Advance_RowDeleting" DataKeyNames="id" OnRowEditing="grid_Advance_RowEditing">
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
                                                        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="5%">
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
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label3" runat="server" Text="Travel Trips"></asp:Label>

                                        </div>
                                        <asp:Button ID="btnAddTrip" runat="server" CssClass="btn btn-info pull-right" OnClick="btnAddTrip_Click"
                                            Text="Add" />

                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <div class=" no-margin" style="float: right">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div style="height: 40px; float: right"></div>
                                                        <div id="Div1" class="example_alt_pagination">
                                                            <asp:GridView ID="grid_Trip" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                                EmptyDataText="No Data Exists" OnRowDeleting="grid_Trip_RowDeleting" DataKeyNames="tripid" OnRowEditing="grid_Trip_RowEditing">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Trip">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>   <%--  <%# Eval("tripid") %>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Of Departure">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("departuredate","{0:dd-MMM-yyyy}").ToString()+" "+Eval("departuretime").ToString()%>'></asp:Label>
                                                                            <asp:Label ID="lbldeptTime" runat="server" Text='<%#Eval("departuretime")%>' Visible="false"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Date Of Arrival">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("arrivaldate","{0:dd-MMM-yyyy}").ToString()+" "+Eval("arrivaltime").ToString()%>'></asp:Label>
                                                                            <asp:Label ID="lblArrTime" runat="server" Text='<%#Eval("arrivaltime")%>' Visible="false"></asp:Label>
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
                                                                    <asp:TemplateField HeaderText="Exception">
                                                                        <ItemTemplate>
                                                                            <span class="fs1" aria-hidden="true" data-icon='<%#Eval("exemption_raised").ToString()=="True"?"&#xe0fe;":""%>'></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Exception Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("approverstatus")%>' Visible='<%#Eval("exemption_raised").ToString()=="True"?true:false%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Edit">
                                                                        <ItemTemplate>
                                                                            <%--<asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"></asp:LinkButton>--%>
                                                                            <a href="javascript:void(window.open('AddEditTripDetails.aspx?tripid=<%# Eval("tripid") %>','title','height=550,width=1100,left=100,top=30'));" class="link05">View / Edit</a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="5%" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton
                                                                                ID="lbtnDelete" runat="server" CommandName="Delete" CssClass="link05" Text="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="divTrip" runat="server" visible="false">
                            <div class="span4">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Trip Details
                                       
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td class="frm-lft-clr123">Travel Type</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddl_traveltype" runat="server" CssClass="blue1" Width="90%" OnSelectedIndexChanged="ddl_traveltype_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Value="0">-----Select-----</asp:ListItem>
                                                            <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                            <asp:ListItem Value="I">International</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddl_traveltype"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Travel Type" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trFromcity" runat="server">
                                                    <td class="frm-lft-clr123">From</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddl_source" runat="server" CssClass="blue1" Width="90%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_source"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select From" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trFromcountry" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">From</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddl_Fromcountry" runat="server" CssClass="blue1" Width="90%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_Fromcountry"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select From" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trToCity" runat="server">
                                                    <td class="frm-lft-clr123">To
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddl_destination" runat="server" CssClass="blue1" Width="90%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_destination"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select To" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="trToCountry" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">To
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="ddl_destinationCountry" runat="server" CssClass="blue1" Width="90%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddl_destinationCountry"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select To" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 44%">Date Of Departure</td>
                                                    <td class="frm-rght-clr123" style="width: 54%">
                                                        <asp:TextBox ID="txtdepartdate" runat="server" CssClass="blue1" Width="80%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                                            TargetControlID="txtdepartdate" Enabled="True" Format="dd MMM yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtdepartdate"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Date Of Departure" ValidationGroup="trip"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                        <%--  <asp:CompareValidator ID="CompareValidator2" runat="server" CultureInvariantValues="false"
                                                                        ControlToValidate="txtdepartdate" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                        Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date" ToolTip="Please do not select earlier date than today."
                                                                        ValidationGroup="v"></asp:CompareValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>

                                                    <td class="frm-lft-clr123">Time Of Departure </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtdeparttime" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="44%">Date Of Arrival</td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:TextBox ID="txtarvlDate" runat="server" CssClass="blue1" Width="80%"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            TargetControlID="txtarvlDate" Enabled="True" Format="dd MMM yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtarvlDate"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Date Of Arrival" ValidationGroup="trip"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                        <%-- <asp:CompareValidator ID="CompareValidator1" runat="server"
                                                                        ControlToValidate="txtdepartdate" ValueToCompare="txtarvlDate" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                        Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date" ToolTip="Please do not select earlier date than today."
                                                                        ValidationGroup="v"></asp:CompareValidator>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Time Of Arrival</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtArvlTime" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Privillege Travel Details</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtPTD" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">Stay Accommodation</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:DropDownList ID="ddl_stayType" runat="server" CssClass="blue1" Width="90%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddl_stayType"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Stay Accommodation" ValidationGroup="trip" InitialValue="0"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                        <asp:HiddenField ID="hftripid" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 ">Employee Comments</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtEmpCommets" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">GL Code</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:TextBox ID="txtGLCode" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="span8">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Expense Details
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="vertical-align: top; width: 50%">

                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td colspan="2" height="30px" class="txt02">Travel</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 44%">Ticket Booked</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl" runat="server" Width="100px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_SelectedIndexChanged">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                                <%--<asp:RadioButton ID="rbtn_ticketYes" Text="Yes" GroupName="ticket" runat="server" CssClass="radio inline"></asp:RadioButton>
                                                                <asp:RadioButton ID="rbtn_ticketNo" Text="No" GroupName="ticket" runat="server" CssClass="radio inline"></asp:RadioButton>--%>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123" style="width: 44%">Advance Given</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_ticketAdv" Width="100px" runat="server" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>

                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trticketadv" runat="server">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtticketAdv" runat="server" CssClass="blue1" Width="50%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddlticketAdv" runat="server" CssClass="blue1" Width="35%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trticket1" runat="server" visible="false">

                                                            <td class="frm-lft-clr123">Tier </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddl_tier" runat="server" CssClass="blue1" Width="90%">
                                                                </asp:DropDownList>

                                                            </td>
                                                        </tr>
                                                        <tr id="trticket2" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Mode</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddl_mode" runat="server" CssClass="blue1" OnSelectedIndexChanged="ddl_mode_SelectedIndexChanged" AutoPostBack="true" Width="90%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trticket3" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Class</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddl_modeClass" runat="server" CssClass="blue1" Width="90%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trticket4" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Fare</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:DropDownList ID="ddl_fareCurrecny" runat="server" CssClass="blue1" Width="34%">
                                                                </asp:DropDownList>
                                                                <asp:TextBox ID="txtticketfair" runat="server" CssClass="blue1" Width="45%" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr id="trticket5" runat="server" visible="false">
                                                            <td class="frm-lft-clr123" style="width: 44%">Ticket Upload</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <asp:FileUpload ID="fupTicket" runat="server" CssClass="blue1" Width="90%"></asp:FileUpload>
                                                            </td>
                                                        </tr>
                                                        <tr id="trticket6" runat="server">
                                                            <td class="frm-lft-clr123" style="width: 44%">Boarding Pass Collected</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <asp:CheckBox ID="chkpass" runat="server" Width="90%"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 44%">Exception</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <asp:CheckBox ID="chkException" runat="server" Width="90%"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">Admin Comments</td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:TextBox ID="txtAdminComments" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="vertical-align: top; width: 50%;">
                                                    <table style="width: 99%;" align=" right">
                                                        <tr>
                                                            <td height="30px" class="txt02">Stay Details</td>
                                                            <td class="txt02" style="text-align: right">Currecny&nbsp;
                                                                <asp:DropDownList ID="ddl_stayCurrency" runat="server" CssClass="blue1" Width="40%">
                                                                </asp:DropDownList></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 44%">Lodging & Conveyance</td>
                                                            <td class="frm-rght-clr123" style="width: 54%;" valign="middle">
                                                                <table style="width: 100%; color: blue">
                                                                    <tr>
                                                                        <td style="width: 30%">Days:<br />
                                                                            <asp:Label ID="lbllodgedays" runat="server"></asp:Label></td>
                                                                        <td style="width: 35%">Per Day:<br />
                                                                            <asp:Label ID="lbllodge" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label></td>
                                                                        <td style="width: 35%">Total:<br />
                                                                            <asp:Label ID="lbllodgetotal" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">Lodge Booked</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_lodge" runat="server" Width="100px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_lodge_SelectedIndexChanged">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trlodge" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Fare</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtlodgefare" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr id="trlodge2" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Address</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtLodgeAddress" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123">Advance Given</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_lodgeAdv" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trlodgeAdv" runat="server">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_lodgeAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td colspan="2" style="height: 5px; border-top: 1px solid #ddd"></td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123" style="width: 44%">Conveyance</td>
                                                            <td class="frm-rght-clr123" style="width: 54%;" valign="middle">
                                                                <table style="width: 100%; color: blue">
                                                                    <tr>
                                                                        <td style="width: 30%">Days:<br />
                                                                            <asp:Label ID="lbl_ConvDays" runat="server" Width="10%"></asp:Label></td>
                                                                        <td style="width: 35%">Per Day:<br />
                                                                            <asp:Label ID="lblconv" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label></td>
                                                                        <td style="width: 35%">Total:<br />
                                                                            <asp:Label ID="lblConvtotal" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123">Advance Given</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_conv" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trconv" runat="server" style="display: none">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtconvAdvance" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 5px; border-top: 1px solid #ddd"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 44%">Food</td>
                                                            <td class="frm-rght-clr123" style="width: 54%;" valign="middle">
                                                                <table style="width: 100%; color: blue">
                                                                    <tr>
                                                                        <td style="width: 30%">Days:<br />
                                                                            <asp:Label ID="lblfoodDays" runat="server" Width="10%"></asp:Label></td>
                                                                        <td style="width: 35%">Per Day:<br />
                                                                            <asp:Label ID="lblfood" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label></td>
                                                                        <td style="width: 35%">Total:<br />
                                                                            <asp:Label ID="lblfoodtotal" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123">Advance Given</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_food" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="trfood" runat="server">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtFoodAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 5px; border-top: 1px solid #ddd"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" style="width: 44%">OOP Expense</td>
                                                            <td class="frm-rght-clr123" style="width: 54%;" valign="middle">
                                                                <table style="width: 100%; color: blue">
                                                                    <tr>
                                                                        <td style="width: 30%;">Days:<br />
                                                                            <asp:Label ID="lbloppDays" runat="server" Width="10%"></asp:Label></td>
                                                                        <td style="width: 35%">Per Day:<br />
                                                                            <asp:Label ID="lbloop" runat="server" Font-Size="Smaller" ForeColor="Blue"></asp:Label></td>
                                                                        <td style="width: 35%">Total:<br />
                                                                            <asp:Label ID="lblopptotal" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123">Advance Given</td>
                                                            <td class="frm-rght-clr123">
                                                                <table class="radio inline">
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButtonList ID="rbtnl_oop" runat="server" Width="100px" RepeatDirection="Horizontal">
                                                                                <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                                <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                            </asp:RadioButtonList>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr id="troop" runat="server">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtoopAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">Management Comments</td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:TextBox ID="txt_mgmtComments" Enabled="false" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <div style="text-align: right; margin-bottom: 10px">
                                <asp:Button ID="btnCalculateSummary" runat="server" CssClass="btn btn-primary"
                                    Text="Calculate Summary" OnClick="btnCalculateSummary_Click" Visible="false" />
                                <asp:Button ID="btnSaveTripDetails" runat="server" ValidationGroup="trip"
                                    Text="Save" OnClick="btnSaveTripDetails_Click" />
                                <asp:Button ID="btnCancelTripDetails" runat="server" CssClass="btn"
                                    Text="Cancel" OnClick="btnCancelTripDetails_Click" />
                            </div>
                        </div>
                        <div class="row-fluid" id="divKit" runat="server" visible="false">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <asp:Label ID="Label6" runat="server" Text="Privilege Allowances"></asp:Label>
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
                                                                <asp:RadioButtonList ID="rbtnl_kitallowance" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" OnSelectedIndexChanged="rbtnl_kitallowance_SelectedIndexChanged" AutoPostBack="true" Height="25px">
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
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Pre Travel Advance Summary 
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 50%; vertical-align: top">
                                                    <table style="width: 99%" align="left">
                                                        <tr>
                                                            <td class="txt02" style="height: 25px">Pre Booking Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div id="Div3" class="example_alt_pagination">
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
                                                            <td style="height: 10px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" style="height: 25px">Total Pre Travel Amount</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grd_pretraveltotals" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                    EmptyDataText="No Data  Found" ShowFooter="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="50%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="50%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblamount" ForeColor="Red" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px"></td>
                                                        </tr>
                                                        <tr id="trkitallowance1" runat="server">
                                                            <td style="height: 15px" class="txt02">Kit Allowance</td>
                                                        </tr>
                                                        <tr id="trkitallowance2" runat="server">
                                                            <td>
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
                                                                                <asp:Label ID="lblDetails" runat="server" ForeColor="Red" Text='<%#Eval("kitallowance")%>'></asp:Label>
                                                                            </ItemTemplate>
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
                                                            <td class="txt02" style="height: 25px">Advance Estimation Details</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
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
                                                                                <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>
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
                                                            <td style="height: 5px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02">Total Advance Estimation Amount</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:GridView ID="grd_estimationtotals" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                    EmptyDataText="No Data  Found" ShowFooter="false">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="25%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="35%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblamount" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Given Amount" HeaderStyle-Width="40%" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="txtgiven" runat="server" Text="" ForeColor="Red" CssClass="span10" Style="text-align: right" MaxLength="18" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtgiven"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                    ValidationGroup="T" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtgiven"
                                                                                    ValidationGroup="T" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <FooterStyle HorizontalAlign="Right" />
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px"></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <table style="width: 100%" class="gvclass">
                                                                    <tr>
                                                                        <td>Currency</td>
                                                                        <td>Advance Amount</td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddl_advancecurrency" runat="server"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="ddl_advancecurrency" InitialValue="0"
                                                                                Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Currency"
                                                                                ValidationGroup="advanceamt" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtAdvancegiving" runat="server" Text="" ForeColor="Red" CssClass="span10" Style="text-align: right" MaxLength="18" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtAdvancegiving"
                                                                                Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                                ValidationGroup="advanceamt" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtAdvancegiving"
                                                                                ValidationGroup="advanceamt" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnAddAdvanceAmount" runat="server" CssClass="btn btn-primary"
                                                                                Text="ADD" ValidationGroup="advanceamt" OnClick="btnAddAdvanceAmount_Click" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3" style="height: 10px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="3">
                                                                            <asp:GridView ID="GridAdvancegiving" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
                                                                                EmptyDataText="No Data  Found" ShowFooter="false" OnRowDeleting="GridAdvancegiving_RowDeleting" DataKeyNames="currencyid">
                                                                                <Columns>
                                                                                    <asp:TemplateField HeaderText="Currency Code" HeaderStyle-Width="30%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                                            <asp:Label ID="lblcurrencyid" runat="server" Text='<%#Eval("currencyid")%>' Visible="false"></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="45%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="25%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lbtndelter" runat="server" Text="Delete" CommandName="Delete"></asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                        <ItemStyle HorizontalAlign="Right" />
                                                                                        <FooterStyle HorizontalAlign="Right" />
                                                                                    </asp:TemplateField>

                                                                                </Columns>
                                                                            </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td class="txt02" style="height: 25px">Miscellaneous Allowance Details</td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td>
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
                                                </td>
                                            </tr>
                                        </table>
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

                                            <asp:GridView ID="Grid_Approvers3" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found" OnPreRender="Grid_Approvers3_PreRender">
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
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Previous Comments
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="Div4" class="example_alt_pagination">
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
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("approverrole")%>'></asp:Label>
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
                        <div class="form-actions no-margin" style="padding-left: 20px">
                            <div class="row-fluid">
                                <div class="span8" style="text-align: left">
                                    Comments &nbsp;
                            <asp:TextBox ID="txtmgrcomments" TextMode="MultiLine" runat="server" CssClass="blue1" Width="80%" Height="80px" MaxLength="8000" onkeypress="return isChar_Number_space()"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtmgrcomments"
                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Please Enter the comments" ValidationGroup="cmts"
                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtmgrcomments"
                                        ValidationGroup="T" runat="server" ValidationExpression="^[A-Za-z0-9- ]+$" ToolTip="Enter only Alpha Numeric Value"
                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                </div>
                                <div class="span4" style="text-align: right">
                                    <asp:Button ID="btnException" runat="server" CssClass="btn btn-primary"
                                        Text="Send For Approve Exception " ValidationGroup="travel" OnClick="btnException_Click" Visible="false" />
                                    <asp:Button ID="btnSumitForm" runat="server" CssClass="btn btn-primary"
                                        Text="Approve" ValidationGroup="T" OnClick="btnSumitForm_Click" OnClientClick="return confirm('Are you sure. you want to Approve?')" />
                                    <%--<asp:Button ID="btnRejecct" runat="server" CssClass="btn btn-primary" OnClientClick="disableBtn(this.id, 'Submitting...')" UseSubmitBehavior="false"
                    Text="Reject" ValidationGroup="travel" OnClick="btnRejecct_Click" />--%>
                                    <asp:Button ID="btn_travelCancel" runat="server" CssClass="btn btn-primary"
                                        Text="Cancel Travel" ValidationGroup="cmts" OnClick="btn_travelCancel_Click" OnClientClick="return confirmCancel();" />

                                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary"
                                        Text="Back" CausesValidation="false" OnClick="btnBack_Click" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
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
                $('#Grid_Emp').dataTable({
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
