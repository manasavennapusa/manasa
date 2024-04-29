<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelForm.aspx.cs" Inherits="Travel_TravelForm" %>

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
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
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
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label1" runat="server" Text="Travel Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr style="height: 40px; display: none;">
                                                    <td class="frm-lft-clr123" style="width: 20%">Account Code
                                                    </td>
                                                    <td class="frm-rght-clr123" style="width: 80%">
                                                        <asp:Label ID="TextBox2" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 20%">Travel Purpose
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 80%">
                                                        <asp:TextBox ID="txt_travelpurpose" TextMode="MultiLine" runat="server" CssClass="blue1" Width="60%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_travelpurpose"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Travel Purpose" ValidationGroup="travel"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
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
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label2" runat="server" Text="Miscellaneous Allowance"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <table style="width: 100%">
                                                <tr>

                                                    <td class="frm-lft-clr123 border-bottom" style="width: 12%">
                                                        <asp:Label ID="lbl_Default1" runat="server">Upload Voucher</asp:Label>
                                               
                                                    </td>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 14%">
                                                        <asp:FileUpload ID="File_UploadDft1" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" Vgroup="v" />
                                                    </td>                                                                                       

                                                   <%-- <td class="frm-lft-clr123  border-bottom" style="width: 12%">Description
                                                    </td>--%>
                                                    <%--<td class="frm-rght-clr123 border-bottom" style="width: 30%">
                                                        <asp:TextBox ID="txtAdvanceDesc" TextMode="MultiLine" runat="server" CssClass="blue1" Width="90%" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdvanceDesc"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Description" ValidationGroup="allo"
                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    </td>--%>
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
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td colspan="6" height="5px"></td>
                                                </tr>
                                                <%-- <tr>
                                                    <td colspan="6" align="right">
                                                        <asp:Button ID="btnAllowaceSave" runat="server" CssClass="btn btn-primary"
                                                            Text="Save" OnClick="btnAllowaceSave_Click" />
                                                        <asp:Button ID="btnAllowaceCancel" runat="server" CssClass="btn"
                                                            Text="Cancel" OnClick="btnAllowaceCancel_Click" />
                                                    </td>
                                                </tr>--%>
                                                <tr>
                                                    <td colspan="6" height="5px"></td>
                                                </tr>
                                            </table>
                                            <div class=" no-margin" style="float: right">
                                                <asp:Button ID="btnAddAdvance" runat="server" CssClass="btn btn-primary" ValidationGroup="allo"
                                                    Text="Add" OnClick="btnAddAdvance_Click" />
                                            </div>
                                            <div style="height: 40px; float: right"></div>
                                            <div id="Div2" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Advance" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" OnRowDeleting="grid_Advance_RowDeleting" DataKeyNames="autoID">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="File Name" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("fileName")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCurrency" runat="server" Text='<%#Eval("Currency")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
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
                                            <asp:Label ID="Label3" runat="server" Text="Trip Details"></asp:Label>
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
                                                    }
                                                    else
                                                        return true;
                                                }

                                            </script>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="vertical-align: top; width: 50%">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123">Travel Type</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_traveltype" runat="server" CssClass="span10" OnSelectedIndexChanged="ddl_traveltype_SelectedIndexChanged" AutoPostBack="true">
                                                                        <asp:ListItem Value="0">-----Select-----</asp:ListItem>
                                                                        <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                                        <asp:ListItem Value="I">International</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddl_traveltype"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Travel Type" ValidationGroup="trip" InitialValue="0"
                                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 44%">Date Of Departure</td>
                                                                <td class="frm-rght-clr123" style="width: 54%">
                                                                    <asp:TextBox ID="txtdepartdate" runat="server" CssClass="span10" onkeypress="return false;" onkeydown="return false;" onpaste="return false;" onchange="return validatedate();"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtdeparttime" runat="server" CssClass="span10" onkeypress="return false;" onkeydown="return false;" onpaste="return false;" OnTextChanged="txtdeparttime_TextChanged"></asp:TextBox>
                                                                    <asp:Image ID="imgdepttime" runat="server" ImageUrl="~/images/time_picker.jpg" Height="20" Width="20" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trFromcity" runat="server">
                                                                <td class="frm-lft-clr123">From</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_source" runat="server" CssClass="span10">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_source"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select From" ValidationGroup="trip" InitialValue="0"
                                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trFromcountry" runat="server" visible="false">
                                                                <td class="frm-lft-clr123">From</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_Fromcountry" runat="server" CssClass="span10">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_Fromcountry"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select From" ValidationGroup="trip" InitialValue="0"
                                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Employee Comments</td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:TextBox ID="txtEmpCommets" runat="server" CssClass="span10" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                           
                                                        </table>
                                                    </td>
                                                    <td style="vertical-align: top; width: 50%">
                                                        <table style="width: 99%;" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123">Stay Accommodation</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_stayType" runat="server" CssClass="span10">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddl_stayType"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Stay Accommodation" ValidationGroup="trip" InitialValue="0"
                                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>


                                                            <tr>
                                                                <td class="frm-lft-clr123" width="44%">Date Of Arrival</td>
                                                                <td class="frm-rght-clr123" width="55%">
                                                                    <asp:TextBox ID="txtarvlDate" runat="server" CssClass="span10" onkeypress="return false;" onkeydown="return false;" onpaste="return false;" onchange="return validatedate();"></asp:TextBox>
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
                                                                    <asp:TextBox ID="txtArvlTime" runat="server" CssClass="span10" onkeypress="return false;" onkeydown="return false;" onpaste="return false;" OnTextChanged="txtArvlTime_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                    <asp:Image ID="imgarrivaltime" runat="server" ImageUrl="~/images/time_picker.jpg" Height="20" Width="20" />
                                                                </td>
                                                            </tr>
                                                            <tr id="trToCity" runat="server">
                                                                <td class="frm-lft-clr123">To
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:DropDownList ID="ddl_destination" runat="server" CssClass="span10">
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
                                                                    <asp:DropDownList ID="ddl_destinationCountry" runat="server" CssClass="span10">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddl_destinationCountry"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select To" ValidationGroup="trip" InitialValue="0"
                                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Airlines Member Ship?</td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:RadioButtonList ID="rbtnl_airlinems" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" OnSelectedIndexChanged="rbtnl_airlinems_SelectedIndexChanged" AutoPostBack="true" Height="25px">
                                                                        <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                        <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList>

                                                                    <asp:TextBox ID="txtairlinedetails" runat="server" CssClass="span11" Style="margin-top: 10px" MaxLength="8000" Visible="false" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123  border-bottom">Hotel Member Ship?</td>
                                                                <td class="frm-rght-clr123 border-bottom">

                                                                    <asp:RadioButtonList ID="rbtnl_hotelms" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" OnSelectedIndexChanged="rbtnl_hotelms_SelectedIndexChanged" AutoPostBack="true" Height="25px">
                                                                        <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                        <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                    <asp:TextBox ID="txthoteldetails" runat="server" CssClass="span11" Visible="false" Style="margin-top: 10px" MaxLength="8000" TextMode="MultiLine" Height="80px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <div class=" no-margin" style="float: right">
                                                <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-primary" OnClick="btnAddTrip_Click"
                                                    Text="Add" ValidationGroup="trip" />
                                                <asp:Button ID="btnClear" runat="server" CssClass="btn btn-primary" OnClick="btnClear_Click"
                                                    Text="Clear" CausesValidation="false" />
                                            </div>
                                            <div style="height: 40px; float: right"></div>
                                            <div id="Div1" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Trip" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" OnPreRender="grid_Trip_PreRender" OnRowEditing="grid_Trip_RowEditing" OnRowDeleting="grid_Trip_RowDeleting" DataKeyNames="tripid">
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
                                                                <asp:Label ID="lblAccommodation" runat="server" Text='<%#Eval("staytypename")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton
                                                                    ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link04" Text="Edit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="5%">
                                                            <ItemTemplate>
                                                                <asp:LinkButton
                                                                    ID="lbtnDelte" runat="server" CommandName="Delete" CssClass="link04" Text="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')"></asp:LinkButton>
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
                                            <asp:Label ID="Label4" runat="server" Text="Privilege Allowances"></asp:Label>
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
                                                                <asp:RadioButtonList ID="rbtnl_insurance" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Height="25px">
                                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom" style="width: 40%">Do you need VISA to be arranged?
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom" style="width: 60%">
                                                                <asp:RadioButtonList ID="rbtnl_visa" runat="server" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Height="25px" OnSelectedIndexChanged="rbtnl_visa_SelectedIndexChanged" AutoPostBack="true">
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
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approvers
                               
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="Grid_Approvers" runat="server" AutoGenerateColumns="false" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found" OnPreRender="Grid_Approvers_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblapprovercode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("level")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="Approvers For">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblworkflow" runat="server" Text='<%#Eval("workflow")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   
                                                    <asp:TemplateField HeaderText="Travel Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraveltype" runat="server" Text='<%#Eval("traveltype").ToString()=="I"?"International":"Domestic"%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-actions no-margin" style="text-align: right">
                            <asp:Button ID="btnSumitForm" runat="server" CssClass="btn btn-primary"
                                Text="Submit Form" ValidationGroup="travel" OnClick="btnSumitForm_Click" />
                        </div>

                    </div>
                </ContentTemplate>
                <Triggers>
                        <asp:PostBackTrigger ControlID="btnAddAdvance" />
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
