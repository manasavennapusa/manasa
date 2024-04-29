<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddEditTripDetails.aspx.cs" Inherits="Travel_AddEditTripDetails" %>

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
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script type="text/javascript" src="js/timepicker.js"></script>
    <script src="../js/JavaScriptValidations.js"></script>
    <script type="text/javascript">
        function RefreshParent() {
            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
                window.close();
            }
        }
        //window.onbeforeunload = RefreshParent;
        function ClosePopup()
        { window.close(); }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>
                                    <asp:Label ID="lblheader" runat="server" Text="View/Edit Trip Details"></asp:Label></h2>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid" id="divTrip" runat="server">
                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Trip Details
                                       
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                             <script type="text/javascript">
                                                 function validatedate() {

                                                     var fromdate = document.getElementById('<%=txtdepartdate.ClientID %>').value;
                                                    var todate = document.getElementById('<%=txtarvlDate.ClientID %>').value;

                                                    if ((fromdate != "") && (todate != "")) {
                                                        var startdate = new Date(fromdate);
                                                        var enddate = new Date(todate);
                                                        if (startdate > enddate) {
                                                            alert('Date Of Departure should be less than Date Of Arrival.')
                                                            document.getElementById('<%=txtarvlDate.ClientID %>').value = "";
                                                            return false;
                                                        }
                                                        else
                                                            return true;
                                                    }
                                                }

                                            </script>
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
                                                        <asp:TextBox ID="txtdepartdate" runat="server" CssClass="blue1" Width="80%" onkeypress="return isCharOrSpace()"  onchange="return validatedate();" ></asp:TextBox>
                                                        <asp:Image ID="imgDeprtDate" runat="server" ImageUrl="~/img/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="imgDeprtDate"
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
                                                        <asp:TextBox ID="txtdeparttime" runat="server" CssClass="blue1" Width="80%" onkeypress="return false;" onkeydown="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="imgdepttime" runat="server" ImageUrl="~/images/time_picker.jpg" Height="20" Width="20" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="44%">Date Of Arrival</td>
                                                    <td class="frm-rght-clr123" width="55%">
                                                        <asp:TextBox ID="txtarvlDate" runat="server" CssClass="blue1" Width="80%"  onchange="return validatedate();" onkeypress="return false;" onkeydown="return false;" onpaste="return false;" ></asp:TextBox>
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
                                                        <asp:TextBox ID="txtArvlTime" runat="server" CssClass="blue1" Width="80%" onkeypress="return false;" onkeydown="return false;" onpaste="return false;"></asp:TextBox>
                                                        <asp:Image ID="imgarrivaltime" runat="server" ImageUrl="~/images/time_picker.jpg" Height="20" Width="20" />
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td class="frm-lft-clr123">Privillege Travel Details</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtPTD" runat="server" CssClass="blue1" Width="90%" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">Stay Accommodation</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:DropDownList ID="ddl_stayType" runat="server" CssClass="blue1" Width="90%" >
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
                                                        <asp:TextBox ID="txtEmpCommets" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr style="display:none">
                                                    <td class="frm-lft-clr123 border-bottom">GL Code</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:TextBox ID="txtGLCode" runat="server" CssClass="blue1" Width="90%" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123">Airlines Member Ship?</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:RadioButtonList ID="rbtnl_airlinems" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" OnSelectedIndexChanged="rbtnl_airlinems_SelectedIndexChanged" AutoPostBack="true" Height="25px">
                                                            <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                            <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>

                                                        <asp:TextBox ID="txtairlinedetails" runat="server" CssClass="span11" Style="margin-top: 10px" MaxLength="8000" Visible="false" TextMode="MultiLine" Height="80px" onkeypress="return isalphanumericsplchar();"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123  border-bottom">Hotel Member Ship?</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:RadioButtonList ID="rbtnl_hotelms" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" OnSelectedIndexChanged="rbtnl_hotelms_SelectedIndexChanged" AutoPostBack="true" Height="25px" >
                                                            <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                            <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        <asp:TextBox ID="txthoteldetails" runat="server" CssClass="span11" Visible="false" Style="margin-top: 10px" MaxLength="8000" TextMode="MultiLine" Height="80px" onkeypress="return isalphanumericsplchar();"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Expense Details
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="vertical-align: top; width: 100%">
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
                                                                <asp:TextBox ID="txtticketAdv" runat="server" CssClass="blue1" Width="50%" onkeypress="return isNumber_dot()"></asp:TextBox>
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
                                                                <asp:TextBox ID="txtticketfair" runat="server" CssClass="blue1" Width="45%" onkeypress="return isNumber_dot();"></asp:TextBox>

                                                            </td>
                                                        </tr>
                                                        <tr id="trticket5" runat="server" visible="false">
                                                            <td class="frm-lft-clr123" style="width: 44%">Ticket Upload</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <table style="width:100%">
                                                                    <tr>
                                                                        <td style="width:60%">
                                                                            <asp:FileUpload ID="fupTicket" runat="server" CssClass="blue1" Width="160px" ></asp:FileUpload>
                                                                            <asp:HiddenField ID="hfticket" runat="server" />
                                                                            
                                                                        </td>
                                                                        <td style="width:40%"><asp:Button ID="btn_ticketupload" runat="server" Text="Upload" CssClass="btn btn-success" style="float:left" OnClick="btn_ticketupload_Click"/></td>
                                                                    </tr>
                                                                    <tr >
                                                                        <td colspan="2">
                                                                            <a id="ticketlink" href="" runat="server" class="link05" visible="false" target="_blank" >View</a>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                
                                                                 
                                                            </td>
                                                        </tr>
                                                        <tr id="trticket6" runat="server">
                                                            <td class="frm-lft-clr123" style="width: 44%">Boarding Pass Collected</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <asp:CheckBox ID="chkpass" runat="server" Width="90%"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="display:none">
                                                            <td class="frm-lft-clr123" style="width: 44%">Exception</td>
                                                            <td class="frm-rght-clr123" style="width: 54%">
                                                                <asp:CheckBox ID="chkException" runat="server" Width="90%"></asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">Admin Comments</td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:TextBox ID="txtAdminComments" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <table style="width: 100%;" align=" right">
                                                        <tr>
                                                            <td height="30px" colspan="2" class="txt02">Stay Details</td>
                                                    
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" style="height: 5px"></td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td class="frm-lft-clr123 " style="width: 44%">Accomodation</td>
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
                                                            <td class="frm-lft-clr123" style="width: 44%">Accomodation Booked</td>
                                                            <td class="frm-rght-clr123" style="width: 54%;">
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
                                                                <asp:TextBox ID="txtlodgefare" runat="server" CssClass="blue1" Width="50%" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                <asp:DropDownList ID="ddl_stayCurrency" runat="server" CssClass="blue1" Width="40%">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="trlodge2" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Address</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtLodgeAddress" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine"></asp:TextBox>
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
                                                        <tr>
                                                            <td colspan="2" class=" border-bottom"></td>
                                                        </tr>
                                                        <tr id="trlodgeAdv" runat="server" visible="false" style="display:none" >
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_lodgeAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isNumber_dot()"></asp:TextBox>
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
                                                        <tr id="trconv" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtconvAdvance" runat="server" CssClass="blue1" Width="90%" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td colspan="2" style="height: 5px; border-top: 1px solid #ddd"></td>
                                                        </tr>
                                                        <tr style="display: none">
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
                                                        <tr id="trfood" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtFoodAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none">
                                                            <td colspan="2" style="height: 5px; border-top: 1px solid #ddd"></td>
                                                        </tr>
                                                        <tr style="display: none">
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
                                                        <tr id="troop" runat="server" visible="false">
                                                            <td class="frm-lft-clr123">Advance Amount</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txtoopAdv" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr style="display: none;">
                                                            <td class="frm-lft-clr123 border-bottom">Management Comments</td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:TextBox ID="txt_mgmtComments" Enabled="false" runat="server" CssClass="blue1" Width="90%" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>

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

                                <asp:Button ID="btnSaveTripDetails" runat="server" ValidationGroup="trip"
                                    Text="Save" OnClick="btnSaveTripDetails_Click" />
                                <asp:Button ID="btnCancelTripDetails" runat="server" CssClass="btn"
                                    Text="Cancel" OnClientClick="ClosePopup();" />
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_ticketupload" />
                </Triggers>
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
