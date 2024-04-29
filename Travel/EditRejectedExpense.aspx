<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditRejectedExpense.aspx.cs" Inherits="Travel_EditRejectedExpense" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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
<!--<html lang="en">-->
<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <link href="../css/ajax__tab_xp2.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <link href="css/wysiwyg/bootstrap-wysihtml5.css" rel="stylesheet" />
    <link href="css/wysiwyg/wysiwyg-color.css" rel="stylesheet" />
    <link href="css/timepicker.css" rel="stylesheet" />
    <link href="css/bootstrap-editable.css" rel="stylesheet" />
    <link href="css/select2.css" rel="stylesheet" />

    <script src="../js/JavaScriptValidations.js"></script>
    <script type="text/javascript">
        function scrollWintop() {
            window.scrollTo(0, 0);
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Expense Details</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <asp:Label ID="Label3" runat="server" Text="Travel Trips"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div id="Div2" class="example_alt_pagination">
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
                                                        <asp:Label ID="lbldeptDate" runat="server" Text='<%#Eval("departuredate","{0:dd-MMM-yyyy}").ToString()+" "+Eval("departuretime").ToString()%>'></asp:Label>
                                                        <asp:Label ID="lbldeptTime" runat="server" Text='<%#Eval("departuretime")%>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date Of Arrival" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblArrDate" runat="server" Text='<%#Eval("arrivaldate","{0:dd-MMM-yyyy}").ToString()+" "+Eval("arrivaltime").ToString()%>'></asp:Label>
                                                        <asp:Label ID="lblArrTime" runat="server" Text='<%#Eval("arrivaltime")%>' Visible="false"></asp:Label>
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
                                                <asp:TemplateField HeaderText="Travel Type" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltraveltype" runat="server" Text='<% #Eval("triptype").ToString() == "I" ? "International" : "Domestic"%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Accommodation" HeaderStyle-Width="12%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAccommodation" runat="server" Text='<%#Eval("staytype")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="View" HeaderStyle-Width="6%">
                                                    <ItemTemplate>
                                                        <a href="javascript:void(window.open('ViewFullTripDetails.aspx?tripid=<%# Eval("tripid") %>','title','height=550,width=1100,left=100,top=30'));" class="link05">View </a>
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
                        <%--   <div class="widget">
                                  <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Expence Details
                                </div>
                            </div>  <div class="widget-body">--%>
                        <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="1" Width="100%"
                            CssClass="ajax__tab_xp2" Style="border-bottom: 1px; border-bottom-style: solid; border-color: #ddd;">

                            <cc1:TabPanel ID="Tab_Job" runat="server">
                                <HeaderTemplate>
                                    Travel
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="Span10" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="Label1" runat="server" Text="Travel"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddlTrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddlTrip" InitialValue="0" ValidationGroup="T"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtReceiptNumber" runat="server" CssClass="span6" onkeypress="return isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtReceiptNumber"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="T" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />' ControlToValidate="txtReceiptNumber"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="Image3" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image3" TargetControlID="txtDate" Enabled="True"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="T" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Travel By</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtTravelby" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtTravelby"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">From</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtFrom"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">To</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtTo" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txtTo"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtAmount" runat="server" CssClass="span6" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAmount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="T" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="txtAmount"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlTravelCurrecny" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlTravelCurrecny"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="T" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_travelbill" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_travelbill_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="rbtnl_travelbill"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                                        ValidationGroup="T" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divtravllbiillupload" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft1" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" />
                                                                        <asp:RegularExpressionValidator ID="re_travalfileupload" runat="server"
                                                                            ControlToValidate="File_UploadDft1" ValidationGroup="T" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_travalfileupload" runat="server" ControlToValidate="File_UploadDft1"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                            ValidationGroup="T" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divtravllbiillcoments" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txttravelcomment" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_travelcommment" ControlToValidate="txtTo"
                                                                            ValidationGroup="T" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_travelcomment" runat="server" ControlToValidate="txttravelcomment"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill Details"
                                                                            ValidationGroup="T" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:HiddenField ID="hf_travelexpenseid" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnTravelAdd" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="T" OnClick="btnTravelAdd_Click" />
                                                                     <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnCancel_Click" />
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row-fluid" id="Theadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Travel Expenses
                 
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="dt_example" class="example_alt_pagination">
                                                                <asp:GridView ID="grdtravel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                    DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists" OnRowDeleting="grdtravel_RowDeleting" OnRowEditing="grdtravel_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--  <asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <b>Total Amount :</b>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Travel By">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltravelby" runat="server" Text='<%#Eval("travelby")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="From">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblfrom" runat="server" Text='<%#Eval("travelfrom")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="To">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblTo" runat="server" Text='<%#Eval("travelto")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmount" runat="server" Text='<%# Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                          <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtndelte" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnTravelAdd" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                            <cc1:TabPanel ID="TabPanel1" runat="server">
                                <HeaderTemplate>
                                    L & C (Stay)
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel2" runat="server">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="lblhead" runat="server" Text="Lodging"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddllodingtrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddllodingtrip" InitialValue="0" ValidationGroup="L"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtLodgingReceiptno" runat="server" CssClass="span6" onkeypress="isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txtLodgingReceiptno"
                                                                            ValidationGroup="L" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="L" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />' ControlToValidate="txtLodgingReceiptno"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Start Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtStartdate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtStartdate" Enabled="True"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStartdate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="L" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">End Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtEnddate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Image2" TargetControlID="txtEnddate" Enabled="True"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtEnddate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="L" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>


                                                                <div class="control-group">
                                                                    <label class="control-label">No. Of Days</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtNoofdays" runat="server" CssClass="span6" onkeypress="return isNumber()" MaxLength="3"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txtNoofdays"
                                                                            ValidationGroup="L" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Description</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server" CssClass="span6" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txtDescription"
                                                                            ValidationGroup="L" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtLodgingamount" runat="server" CssClass="span6" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtLodgingamount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="L" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txtLodgingamount"
                                                                            ValidationGroup="L" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlLodgeCurrency" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlLodgeCurrency"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="L" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_lodge" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_lodge_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator42" runat="server" ControlToValidate="rbtnl_lodge"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                                        ValidationGroup="L" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divlodgebillupload" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft2" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" />
                                                                        <asp:RegularExpressionValidator ID="re_lodgebillupload" runat="server"
                                                                            ControlToValidate="File_UploadDft2" ValidationGroup="L" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_lodgebillupload" runat="server" ControlToValidate="File_UploadDft2"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                            ValidationGroup="L" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divlodgecomment" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtlodgingbilldetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_lodgebilldetails" ControlToValidate="txtlodgingbilldetails"
                                                                            ValidationGroup="L" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_lodgebilldetails" runat="server" ControlToValidate="txtlodgingbilldetails"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill details"
                                                                            ValidationGroup="L" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnLodging" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="L" OnClick="btnLodging_Click" />
                                                                     <asp:Button ID="btnLodgeCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnLodgeCancel_Click" />
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row-fluid" id="Lheadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>L & C (Stay) Expenses
                                                                   
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div1" class="example_alt_pagination">
                                                                <asp:GridView ID="grdlodging" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnRowDeleting="grdlodging_RowDeleting"
                                                                    OnRowEditing="grdlodging_RowEditing"  DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStartDate" runat="server" Text='<%#Eval("lodgingStartdate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="End Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblEndDate" runat="server" Text='<%#Eval("lodgingEnddate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="No. Of Days" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblSDate" runat="server" Text='<%#Eval("noofdays")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnLodging" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                            <cc1:TabPanel ID="TabPanel2" runat="server">
                                <HeaderTemplate>
                                    OOP
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel4" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="Span6" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="Label9" runat="server" Text="OOP"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddlooptrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddlooptrip" InitialValue="0" ValidationGroup="O"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtOOPReceiptNo" runat="server" CssClass="span6" onkeypress="return isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txtOOPReceiptNo"
                                                                            ValidationGroup="O" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="O" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />'
                                                                            ControlToValidate="txtOOPReceiptNo"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtOOPDate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="image5" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="calendarextender5" runat="server" PopupButtonID="image5" TargetControlID="txtOOPDate" Enabled="true"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtOOPDate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="O" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Description</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtOOPDetails" runat="server" CssClass="span6" onkeypress="return isalphanumericsplchar();"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator22" ControlToValidate="txtOOPDetails"
                                                                            ValidationGroup="O" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtOOPAmount" runat="server" CssClass="span6" onkeypress="return isNumber_dot();" MaxLength="14"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtOOPAmount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="O" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator23" ControlToValidate="txtOOPAmount"
                                                                            ValidationGroup="O" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlOOPCurrecny" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlOOPCurrecny"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="O" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_oopbill" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_oopbill_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator43" runat="server" ControlToValidate="rbtnl_oopbill"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                                        ValidationGroup="O" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divoopbill" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft4" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" />
                                                                        <asp:RegularExpressionValidator ID="re_oopbillupload" runat="server"
                                                                            ControlToValidate="File_UploadDft4" ValidationGroup="O" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_oopbillupload" runat="server" ControlToValidate="File_UploadDft4"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Upload Bill"
                                                                            ValidationGroup="O" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divoopbilldetails" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtoopbilldetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_oopbilldetails" ControlToValidate="txtoopbilldetails"
                                                                            ValidationGroup="O" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_oopbilldetails" runat="server" ControlToValidate="txtoopbilldetails"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill Details"
                                                                            ValidationGroup="O" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnOOP" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="O" OnClick="btnOOP_Click" />
                                                                     <asp:Button ID="btnOOPCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnOOPCancel_Click" />
                                                                </div>

                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row-fluid" id="Oheadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>OOP Expenses
                 
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div3" class="example_alt_pagination">
                                                                <asp:GridView ID="grdoop" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnRowDeleting="grdoop_RowDeleting"
                                                                    OnRowEditing="grdoop_RowEditing" DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--    <asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnOOP" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                            <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Miscellaneous">
                                <HeaderTemplate>
                                    Miscellaneous
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel5" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="Span7" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="Label10" runat="server" Text="Miscellaneous"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddlmisceTrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddlmisceTrip" InitialValue="0" ValidationGroup="M"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" style="display: none">
                                                                    <label class="control-label">Headding </label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtHeadding" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ControlToValidate="txtHeadding"
                                                                            ValidationGroup="M" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtMiscReceipt" runat="server" CssClass="span6" onkeypress="return isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" ControlToValidate="txtMiscReceipt"
                                                                            ValidationGroup="M" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ValidationGroup="M" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />' ControlToValidate="txtMiscReceipt"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtMiscDate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="image6" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="calendarextender6" runat="server" TargetControlID="txtMiscDate" PopupButtonID="image6" Enabled="true"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtMiscDate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="M" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Description</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtMiscDetails" runat="server" CssClass="span6" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txtMiscDetails"
                                                                            ValidationGroup="M" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtMiscAmount" runat="server" CssClass="span6" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtMiscAmount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="M" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" ControlToValidate="txtMiscAmount"
                                                                            ValidationGroup="M" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlMiscCurrency" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="ddlMiscCurrency"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="M" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_miscbill" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_miscbill_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator44" runat="server" ControlToValidate="rbtnl_miscbill"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                                        ValidationGroup="M" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divmiscbillupload" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft5" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" />
                                                                        <asp:RegularExpressionValidator ID="re_miscbillupload" runat="server"
                                                                            ControlToValidate="File_UploadDft5" ValidationGroup="M" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_miscbillupload" runat="server" ControlToValidate="File_UploadDft5"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Upload Bill"
                                                                            ValidationGroup="M" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divmiscbilldetails" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtMiscbilldetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_miscbilldetails" ControlToValidate="txtMiscbilldetails"
                                                                            ValidationGroup="M" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_miscbilldetails" runat="server" ControlToValidate="txtMiscbilldetails"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill Details"
                                                                            ValidationGroup="M" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnMiscellaneous" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="M" OnClick="btnMiscellaneous_Click" />
                                                                     <asp:Button ID="btnMiscellaneousCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnMiscellaneousCancel_Click" />
                                                                </div>

                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row-fluid" id="Mheadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Miscellaneous Expenses
                 
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div4" class="example_alt_pagination">
                                                                <asp:GridView ID="grdmiscillenaous" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnRowDeleting="grdmiscillenaous_RowDeleting"
                                                                    OnRowEditing="grdmiscillenaous_RowEditing" DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblOOPAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnMiscellaneous" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                            <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText=" Personal Car">
                                <HeaderTemplate>
                                    Personal Car
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel6" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="Span8" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="Label11" runat="server" Text="Personal Car"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddlperCartrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddlperCartrip" InitialValue="0" ValidationGroup="P"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalReceipt" runat="server" CssClass="span6" onkeypress="return isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtPersonalReceipt"
                                                                            ValidationGroup="P" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ValidationGroup="P" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />' ControlToValidate="txtPersonalReceipt"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalCarDate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="image8" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="calendarextendar8" runat="server" PopupButtonID="image8" TargetControlID="txtPersonalCarDate" Enabled="true"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtPersonalCarDate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="P" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">From</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalFrom" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" ControlToValidate="txtPersonalFrom"
                                                                            ValidationGroup="P" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">To</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalTo" runat="server" CssClass="span6" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator30" ControlToValidate="txtPersonalTo"
                                                                            ValidationGroup="P" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Approx.Distance(in KM)</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalDistance" runat="server" CssClass="span6" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtPersonalDistance"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Distance"
                                                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator31" ControlToValidate="txtPersonalDistance"
                                                                            ValidationGroup="p" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPersonalAmount" runat="server" CssClass="span6" MaxLength="14" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtPersonalAmount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="P" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txtPersonalAmount"
                                                                            ValidationGroup="P" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlPersonalcarCurrency" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="ddlPersonalcarCurrency"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="P" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_personalcar" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_personalcar_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator45" runat="server" ControlToValidate="rbtnl_personalcar"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Choose One Option"
                                                                                        ValidationGroup="P" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divPersonalcarbillupload" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft6" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" />
                                                                        <asp:RegularExpressionValidator ID="re_personalcarbillupload" runat="server"
                                                                            ControlToValidate="File_UploadDft6" ValidationGroup="P" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_personalcarbillupload" runat="server" ControlToValidate="File_UploadDft6"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Upload Bill"
                                                                            ValidationGroup="P" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divPersonalcarbilldetails" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txt_personalcarbilldetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_personalcarbilldetails" ControlToValidate="txt_personalcarbilldetails"
                                                                            ValidationGroup="P" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_personalcarbilldetails" runat="server" ControlToValidate="txt_personalcarbilldetails"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill Details"
                                                                            ValidationGroup="P" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnpersonalcar" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="P" OnClick="btnpersonalcar_Click" />
                                                                     <asp:Button ID="btnPersonalCarCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnPersonalCarCancel_Click" />
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>

                                            <div class="row-fluid" id="Pheadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Personal Car Expenses
                 
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div5" class="example_alt_pagination">
                                                                <asp:GridView ID="grdpersonalcar" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnRowDeleting="grdpersonalcar_RowDeleting"
                                                                    OnRowEditing="grdpersonalcar_RowEditing" DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Travel From">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCFrom" runat="server" Text='<%#Eval("travelfrom")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Travel To ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCtravelto" runat="server" Text='<%#Eval("travelto")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Travel Distance" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCDistance" runat="server" Text='<%#Eval("approxdispance")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnpersonalcar" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                            <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Telephone/Fax">
                                <HeaderTemplate>
                                    Telephone/Fax
                                </HeaderTemplate>
                                <ContentTemplate>
                                    <asp:UpdatePanel ID="upanel7" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                <span id="Span9" runat="server" class="txt-red" enableviewstate="false"></span>
                                                                <asp:Label ID="Label12" runat="server" Text="Telephone/Fax"></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <fieldset>
                                                                <div class="control-group">
                                                                    <label class="control-label">
                                                                        Trip                     
                                                                    </label>
                                                                    <div class="controls controls-row">
                                                                        <asp:DropDownList ID="ddlphonetrip" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        &nbsp; &nbsp;
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                    ControlToValidate="ddlphonetrip" InitialValue="0" ValidationGroup="F"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Receipt Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPhoneReceipt" runat="server" CssClass="span6" onkeypress="return isChar_Number_space_slash()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtPhoneReceipt"
                                                                            ValidationGroup="F" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s]+$" ToolTip="Enter only alphanumeric and slash space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="F" runat="server" ErrorMessage='<img src="../img/error1.gif" alt=""  />' ControlToValidate="txtPhoneReceipt"></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Date</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPhoneDate" runat="server" CssClass="span6" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                        <asp:Image ID="image7" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                        <cc1:CalendarExtender ID="calendarextender7" runat="server" TargetControlID="txtPhoneDate" PopupButtonID="image7" Enabled="true"></cc1:CalendarExtender>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txtPhoneDate" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date" ValidationGroup="F" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Number</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="span6" onkeypress="return isNumber()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txtPhoneNumber"
                                                                            ValidationGroup="F" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtPhoneNumber"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Phone Number"
                                                                            ValidationGroup="F" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>

                                                                <div class="control-group">
                                                                    <label class="control-label">Number Type</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtn_telephone" runat="server" Width="200px" RepeatDirection="Horizontal">
                                                                                        <asp:ListItem>Office</asp:ListItem>
                                                                                        <asp:ListItem>Personal</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="rbtn_telephone"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Number Type"
                                                                                        ValidationGroup="F" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Description</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtphoneDetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator37" ControlToValidate="txtphoneDetails"
                                                                            ValidationGroup="F" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets and space" ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Amount</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtPhoneamount" runat="server" CssClass="span6" onkeypress="return isNumber_dot()" MaxLength="14"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtPhoneamount"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Amount"
                                                                            ValidationGroup="F" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator35" ControlToValidate="txtPhoneamount"
                                                                            ValidationGroup="F" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only numbers and decimals upto 2 places"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Currency</label>
                                                                    <div class="controls">
                                                                        <asp:DropDownList ID="ddlPhoneCurrency" runat="server" CssClass="span6">
                                                                        </asp:DropDownList>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="ddlPhoneCurrency"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="F" InitialValue="0"
                                                                            Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="control-group">
                                                                    <label class="control-label">Do you have Bill?</label>
                                                                    <div class="controls">
                                                                        <table class="radio inline">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:RadioButtonList ID="rbtnl_phonebill" runat="server" Width="200px" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="rbtnl_phonebill_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                                                    </asp:RadioButtonList>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator46" runat="server" ControlToValidate="rbtnl_phonebill"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                                        ValidationGroup="F" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                </td>
                                                                            </tr>
                                                                        </table>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divfaxbillupload" runat="server" visible="false">
                                                                    <label class="control-label">Upload Bill</label>
                                                                    <div class="controls">
                                                                        <asp:FileUpload ID="File_UploadDft7" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300" />
                                                                        <asp:RegularExpressionValidator ID="re_faxbillupload" runat="server"
                                                                            ControlToValidate="File_UploadDft7" ValidationGroup="F" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                            ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_faxbillupload" runat="server" ControlToValidate="File_UploadDft7"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Select Bill"
                                                                            ValidationGroup="F" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                    </div>
                                                                </div>
                                                                <div class="control-group" id="divfaxbilldetails" runat="server" visible="false">
                                                                    <label class="control-label">Bill Details</label>
                                                                    <div class="controls">
                                                                        <asp:TextBox ID="txtphonebilldetails" runat="server" CssClass="span6" TextMode="MultiLine" onkeypress="return isalphanumericsplchar()"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="re_faxbilldetails" ControlToValidate="txtphonebilldetails"
                                                                            ValidationGroup="F" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        <asp:RequiredFieldValidator ID="rq_faxbilldetails" runat="server" ControlToValidate="txtphonebilldetails"
                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Bill Details"
                                                                            ValidationGroup="F" float="right" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnTelephone" runat="server" CssClass="btn btn-primary"
                                                                        Text="Add" ValidationGroup="F" OnClick="btnTelephone_Click" />
                                                                     <asp:Button ID="btnTelephoneCancel" runat="server" CssClass="btn btn-primary"
                                                                        Text="Cancel" CausesValidation="false" OnClick="btnTelephoneCancel_Click" />
                                                                </div>
                                                            </fieldset>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row-fluid" id="Fheadder" runat="server">
                                                <div class="span12">
                                                    <div class="widget no-margin">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Phone / Fax Expenses
                 
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div6" class="example_alt_pagination">
                                                                <asp:GridView ID="grdtelephone" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnRowDeleting="grdtelephone_RowDeleting"
                                                                    OnRowEditing="grdtelephone_RowEditing" DataKeyNames="expenseid" ShowFooter="false" EmptyDataText="No Data Exists">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Trip No." HeaderStyle-Width="3%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbltripno" runat="server" Text='<%#Eval("tripno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%-- <asp:TemplateField HeaderText="Expense Type ">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFaxExpense" runat="server" Text='<%#Eval("expensetype")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Receipt No." HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFaxReceipt" runat="server" Text='<%#Eval("receiptno")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="10%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("details")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblPCDate" runat="server" Text='<%#Eval("traveldate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Number" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFaxnumber" runat="server" Text='<%#Eval("phonenumber")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Amount">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFaxAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:Label ID="lblTotalAmount" runat="server" Font-Bold="true"></asp:Label>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill Details">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldetails" runat="server" Text='<%# Eval("billdetails")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Bill" HeaderStyle-Width="5%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblbill" runat="server" Text="No Bill" CssClass="link05" Visible='<%#Eval("billpath").ToString()==""?true:false%>'></asp:Label>
                                                                                <a href="Upload/<%#Eval("billpath")%>" target="content" class="link05" style="display: <%#Eval("billpath").ToString()==""?"none":"block"%>">View </a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                         <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Edit">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="lbtnEdit" runat="server" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Delete">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton
                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
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
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="btnTelephone" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </ContentTemplate>
                            </cc1:TabPanel>

                        </cc1:TabContainer>
                        <%--   </div>
                                </div>--%>
                        <div class="clearfix"></div>
                        <br />
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

                <div class="row-fluid">
                    <asp:UpdatePanel ID="UpdatePanelSummary" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
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
                                                <td class="txt02" colspan="2" style="height: 40px">Total Pre Travel Amount</td>
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
                                                                    <asp:Label ID="lblamount" runat="server" Text='<%#Eval("total")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <FooterStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px" colspan="2"></td>
                                            </tr>
                                            <tr id="trkitallowance1" runat="server">
                                                <td style="height: 25px" colspan="2" class="txt02">Kit Allowance</td>
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
                                                                    <asp:Label ID="lblDetails" runat="server" Text='<%#Eval("kitallowance")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <FooterStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>

                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="height: 10px" colspan="2"></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 25px" class="txt02" colspan="2">Total Advance Given Amount</td>

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

                                                            <asp:TemplateField HeaderText="Given Amount" HeaderStyle-Width="35%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtgiven" runat="server" CssClass="span12" Style="text-align: right" Text='<%#Eval("giventotal")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <FooterStyle HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td colspan="2" style="height: 10px"></td>
                                            </tr>
                                            <tr style="display: none;">
                                                <td class="txt02" colspan="2" style="height: 25px">Miscellaneous Allowance Details</td>
                                            </tr>
                                            <tr style="display: none;">
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
                                            <asp:GridView ID="grdExpenseSummary" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
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
                                                        <ItemStyle HorizontalAlign="Right" />
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>
                                            <br />
                                            <b>Total Expense</b>
                                            <br />

                                            <asp:GridView ID="grdTotalExpanse" runat="server" AutoGenerateColumns="False" CssClass="gvclass" Width="100%"
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
                                                            <asp:Label ID="lblamount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
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
                        </ContentTemplate>
                    </asp:UpdatePanel>
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
                                        <div id="Div9" class="example_alt_pagination">
                                            <asp:GridView ID="GridTravelComments" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" Width="100%"
                                                EmptyDataText="No Data  Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrole" runat="server" Text='<%#Eval("approverrole")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="60%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("comments")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
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
                                        <div id="Div10" class="example_alt_pagination">
                                            <asp:GridView ID="Gridcomments" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" Width="100%"
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
                <div class="form-actions no-margin">
                    <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                    <asp:Button ID="btngeneralsubmit" runat="server" align="right" CssClass="btn btn-primary" OnClientClick="return confirm('Are you sure. you want to submit Expense Details?')"
                        Text="Submit" ValidationGroup="v" OnClick="btngeneralsubmit_Click" />
                    <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" CssClass="btn btn-primary" />
                </div>

            </div>
        </div>


        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <script src="js/wysiwyg/wysihtml5-0.3.0.js"></script>

        <script src="js/wysiwyg/bootstrap-wysihtml5.js"></script>
        <script type="text/javascript" src="js/date-picker/date.js"></script>
        <script type="text/javascript" src="js/date-picker/daterangepicker.js"></script>
        <script type="text/javascript" src="js/bootstrap-timepicker.js"></script>

        <!-- Editable Inputs -->
        <script src="js/bootstrap-editable.min.js"></script>
        <script src="js/select2.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/wizard/bwizard.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>
        <script src="js/custom-forms.js"></script>


    </form>
</body>
</html>
