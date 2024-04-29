<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editcompany.aspx.cs" Inherits="Admin_Company_createcompany"
    Title="Create Company" %>

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
<html lang="en">
<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

     <style type="text/css">
        .star
        {
            color: red;
        }
    </style>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Company Details</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>

                                            <tr>
                                                <td style="width: 22%">Company Name <span class="star">*</span></td>
                                                <td style="width: 25%">
                                                    <input id="txtcmpname" type="text" runat="server" class="span12" maxlength="50" pattern="^[a-zA-Z0-9\s\.\-\']*$" title="Company name" required />
                                                </td>
                                                <td style="width: 22%">Establishment Date <span class="star">*</span>
                                                </td>
                                                <td style="width: 30%">
                                                    <input id="txt_est_date" runat="server" class="span12" onkeydown="return enterdate(event);" />

                                                </td>
                                            </tr>

                                            <tr>
                                                <td style="width: 22%">Company Type
                                                </td>
                                                <td style="width: 25%">
                                                    <asp:DropDownList ID="drp_type" runat="server" CssClass="span12" Width="">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="Pvt">Pvt</asp:ListItem>
                                                        <asp:ListItem Value="Pvt. Ltd.">Pvt. Ltd.</asp:ListItem>
                                                        <asp:ListItem Value="Ltd.">Ltd.</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td style="width: 22%">PAN Number
                                                </td>
                                                <td style="width: 30%">
                                                    <input id="txt_pan" runat="server" class="span12" title="PAN Number" type="text" pattern="^([A-Z]{5})(\d{4})([A-Z]{1})$" maxlength="10" />
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_pan"
                                                ValidationGroup="c" runat="server" ValidationExpression="^([A-Z]{5})(\d{4})([A-Z]{1})$" ToolTip="Enter Valid PAN No. (like NADRS4235R) only Uppercase"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">TIN Number
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txttin" runat="server" type="text" class="span12" maxlength="9" title="TIN Number" pattern="^[0-9]{9}$" />
                                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txttin"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{9}$" ToolTip="Enter valid TIN Number (9 digits)"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                                <td class="frm-lft-clr123">Registration Number
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txtregno" runat="server" type="text" class="span12" maxlength="50" title="Registration Number" pattern="^[a-zA-Z0-9\s]+$" />
                                                    <%--<asp:TextBox ID="txtregno" runat="server" CssClass="blue1" Width="" MaxLength="50" onkeypress="return isChar_Number_slash()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtregno"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumberic and slash "
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">TAN Number
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txt_tanno" runat="server" type="text" class="span12" maxlength="50" title="TAN Number" pattern="^[a-zA-Z0-9]{10}$" />
                                                    <%--<asp:TextBox ID="txt_tanno" runat="server" CssClass="blue1" Width="" MaxLength="10" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" ControlToValidate="txt_tanno"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9]{10}$" ToolTip="Enter valid TAN Number (10 Characters)"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                                <td class="frm-lft-clr123">TDS Circle
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txt_tds" runat="server" type="text" class="span12" maxlength="50" title="TDS Circle" pattern="^[a-zA-Z0-9\-\s]+$" />
                                                    <%--<asp:TextBox ID="txt_tds" runat="server" CssClass="blue1" Width="" MaxLength="50" onkeypress="return isChar_Number_space_ifin()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_tds"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\-\s]+$" ToolTip="Enter only alphanumeric and space and - "
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Company PF Trust
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="drp_pftrust" runat="server" CssClass="span12">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                        <asp:ListItem Value="No">No</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_pftrust"
                                                        ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                        ToolTip="Select PF"><img src="../images/../img/error1.gif" alt="" /></asp:CompareValidator>
                                                </td>
                                                <td class="frm-lft-clr123">Nature of Business
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txt_comp_eng" runat="server" type="text" class="span12" maxlength="50" title="Company Engaged" pattern="^[a-zA-Z\s]+$" />
                                                    <%--<asp:TextBox ID="txt_comp_eng" runat="server" CssClass="blue1" Width="" MaxLength="50" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txt_comp_eng"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space "
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Responsible Person
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input id="txt_resppers" runat="server" type="text" class="span12" maxlength="100" title="Responsible Person" pattern="^[a-zA-Z'.\s]+$" onkeypress="return isCharOrSpace()" onblur="capitalizeMe(this)" />
                                                    <%--<asp:TextBox ID="txt_resppers" runat="server" CssClass="blue1" MaxLength="100" Width="" onkeypress="return isCharOrSpace()" onblur="capitalizeMe(this)"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txt_resppers"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z'.\s]+$" ToolTip="Enter only alphabets"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                                <td class="frm-lft-clr123 border-bottom">Company URL <span class="star">*</span>
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <input id="txtcmpurl" runat="server" type="text" class="span12" maxlength="50" title="Company URL" pattern="\w+([-+.']\w+)*\.\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                                    <%--<asp:TextBox ID="txtcmpurl" runat="server" MaxLength="50" CssClass="blue1" Width=""></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ValidationGroup="c" ToolTip="Not a Vaild Url. (example:www.abc.com)"
                                                SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtcmpurl" ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationExpression="\w+([-+.']\w+)*\.\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                            </asp:RegularExpressionValidator>--%>
                                                </td>
                                            </tr>

                                            <tr runat="server" visible="false">
                                                <td class="frm-lft-clr123 border-bottom">Logo Image
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <asp:FileUpload ID="fupload" runat="server" CssClass="input2" ToolTip="Uplooad logo here" /><asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload" CssClass="txt-red"
                                                        Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="File not supported" />'
                                                        ValidationExpression="^.+(.gif|.GIF|.jpg|.JPG|.jpeg|.JPEG|.bmp|.BMP|.png|.PNG)$"
                                                        ValidationGroup="c"><img src="../img/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator>
                                                </td>
                                                <td colspan="3">&nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>PF Details
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td style="width: 22%">EPF Employer Code.
                                            </td>
                                            <td style="width: 25%">
                                                <input id="txt_epfno" runat="server" class="span12" title="EPF Employer Code" type="text" pattern="^[a-zA-Z0-9\/]+$" maxlength="50" onkeypress="return isChar_Number_slash()" />
                                                <%-- <asp:TextBox ID="txt_epfno" runat="server" CssClass="blue1" MaxLength="50" Width="" onkeypress="return isChar_Number_slash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txt_epfno"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\/]+$" ToolTip="Enter only  alphanumeric and slash"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                            </td>

                                            <td style="width: 22%">Sub EPF Employer Code.
                                            </td>
                                            <td style="width: 30%">
                                                <input id="txt_dbffile" runat="server" class="span12" title="Sub EPF Employer Code" type="text" pattern="^[a-zA-Z0-9\/]+$" maxlength="50" onkeypress="return isChar_Number_slash()" />
                                                <%-- <asp:TextBox ID="txt_dbffile" runat="server" CssClass="blue1" MaxLength="50" Width="" onkeypress="return isChar_Number_slash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator21" ControlToValidate="txt_dbffile"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\/]+$" ToolTip="Enter only alphanumeric and slash"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td visible="false" id="e3" runat="server">Extension
                                            </td>
                                            <td visible="false" id="e4" runat="server">
                                                <asp:TextBox ID="txt_fileext" runat="server" CssClass="blue1" MaxLength="50" Width=""></asp:TextBox>
                                            </td>
                                        </tr>

                                    </table>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>ESI Details
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td style="width: 22%">ESI Employer Code.
                                            </td>
                                            <td style="width: 25%">
                                                <input id="txt_esino" runat="server" class="span12" title="ESI Employer Code" type="text" pattern="^[0-9]+$" maxlength="20" onkeypress="return isNumber()" />
                                                <%-- <asp:TextBox ID="txt_esino" runat="server" CssClass="blue1" MaxLength="20" Width="" onkeypress="return isNumber()"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txt_esino"
                                            ValidationGroup="c" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                            </td>

                                            <td style="width: 22%">Sub ESI Employer Code.
                                            </td>
                                            <td style="width: 30%">
                                                <input id="txt_esilocalno" runat="server" class="span12" title="Sub ESI Employer Code." type="text" pattern="^[0-9]+$" maxlength="20" onkeypress="return isNumber()" />
                                                <%--<asp:TextBox ID="txt_esilocalno" runat="server" MaxLength="50" CssClass="blue1" Width="" onkeypress="return isNumber()"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txt_esilocalno"
                                            ValidationGroup="c" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>

                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">

                            <div class="span6">
                                <div class="widget no-margin">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Corporate Address
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td style="width: 22%">Address 1<span class="star">*</span>
                                            </td>
                                            <td style="width: 25%">
                                                <input id="txt_pre_add1" runat="server" class="span11" title="ESI Employer Code" type="text" pattern="^[a-zA-Z0-9&\.\/\-\#\s\:\,\(\)\']+$" maxlength="100" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" required />
                                                <%--  <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="blue1" Width="" MaxLength="100" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pre_add1"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address 1" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txt_pre_add1"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9&\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric space / #  ."
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_pre_add1"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address 1" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Address 2
                                            </td>
                                            <td>
                                                <input id="txt_pre_Add2" runat="server" class="span11" title="ESI Employer Code" type="text" pattern="^[a-zA-Z0-9&\.\/\-\#\s\:\,\(\)\']+$" maxlength="100" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" />
                                                <%--<asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="blue1" Width="" MaxLength="100" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_pre_Add2"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric space / #  ."
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>Country<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_pre_country" runat="server" CssClass="span11" Width=""
                                                    AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_country_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_pre_country"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Country" ValidationGroup="c" InitialValue="0"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>State<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_pre_state" runat="server" CssClass="span11" Width=""
                                                    AutoPostBack="true" Height="20px" OnSelectedIndexChanged="ddl_pre_state_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_pre_state"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="c" InitialValue="0"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>City<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_pre_city" runat="server" CssClass="span11" Width=""
                                                    Height="">                                                    
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_pre_city"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select City" ValidationGroup="c" InitialValue="0" 
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>

                                        </tr>

                                        <tr>
                                            <td>Zip Code<span class="star">*</span>
                                            </td>
                                            <td>
                                                <input id="txt_pre_zip" runat="server" class="span11" title="ESI Employer Code" type="text" pattern="^[0-9]{6}$" maxlength="6" onkeypress=" return isNumberKey(event)" />
                                                <%--<asp:TextBox ID="txt_pre_zip" runat="server" CssClass="blue1" MaxLength="6" Width="" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_pre_zip"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Zip Code" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_pre_zip"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter 6 digits"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_pre_zip"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Zipcode" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Phone No.
                                            </td>
                                            <td>
                                                <input id="txt_pre_phone" runat="server" class="span11" title="ESI Employer Code" type="text" maxlength="11" onkeypress=" return isNumberKey(event)" />
                                                <%--<asp:TextBox ID="txt_pre_phone" runat="server" MaxLength="11" CssClass="blue1" Width=""></asp:TextBox>--%>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>

                            <div class="span6">
                                <div class="widget no-margin">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>
                                            Correspondance Address      
                                             <label class="checkbox inline" style="margin-left:5px">
                                                 <asp:CheckBox ID="check1" runat="server" AutoPostBack="True" OnCheckedChanged="check1_CheckedChanged" Text="Same As Corporate"></asp:CheckBox>

                                             </label>
                                            <%----%>
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td style="width: 22%">Address 1<span class="star">*</span>
                                            </td>
                                            <td style="width: 30%">
                                                <input id="txt_per_add1" runat="server" class="span11" title="ESI Employer Code" type="text" pattern="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" maxlength="50" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" />
                                                <%--<asp:TextBox ID="txt_per_add1" runat="server" CssClass="blue1" Width="" MaxLength="50" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_per_add1"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric space / #  ."
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_per_add1"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Address 2
                                            </td>
                                            <td>
                                                <input id="txt_per_add2" runat="server" class="span11" title="ESI Employer Code" type="text" pattern="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" maxlength="50" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" />
                                                <%--<asp:TextBox ID="txt_per_add2" runat="server" CssClass="blue1" Width="" MaxLength="50" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_per_add2"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric space / #  ."
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Country<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_per_country" runat="server" CssClass="span11" Width=""
                                                    AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_per_country_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_per_country"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Country" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>State<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_per_state" runat="server" CssClass="span11" Width=""
                                                    AutoPostBack="true" Height="20px" OnSelectedIndexChanged="ddl_per_state_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_per_state"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter State" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>City<span class="star">*</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddl_per_city" runat="server" CssClass="span11" Width=""
                                                    Height="">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_per_city"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter city" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Zip Code<span class="star">*</span>
                                            </td>
                                            <td>
                                                <input id="txt_per_zip" runat="server" class="span11" maxlength="6" onkeypress=" return isNumberKey(event)" pattern="^[0-9]{6}$" title="Zip Code" />
                                                <%--<asp:TextBox ID="txt_per_zip" runat="server" CssClass="span12" MaxLength="6" Width="" onkeypress="return isNumber()"></asp:TextBox>--%>
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_per_zip"
                                                    ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter 6 digits"
                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_per_zip"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Zip code" ValidationGroup="c"
                                                    Width="6px"><img src="../img/error1.gif" alt=""/></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Phone No.
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txt_per_phone" runat="server" CssClass="span11" MaxLength="11" Width="" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>

                        </div>
                        <div class="form-actions no-margin" align="right">
                            <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Update" CssClass="btn btn-primary"></asp:Button>

                            <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btn_reset_Click" Visible="false" />
                            <asp:Button ID="btn_cncl" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btn_cncl_Click" />
                        </div>

                        <%--<div class="widget-body">
                            <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Save" CssClass="btn btn-info pull-right"></asp:Button>
                            &nbsp;
                            <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info pull-right" Text="Reset" OnClick="btn_reset_Click" />
                            &nbsp;
                            <asp:Button ID="btn_cncl" runat="server" CssClass="btn btn-info pull-right" Text="Cancel" OnClick="btn_cncl_Click" />
                            &nbsp;
                            <div class="clearfix">
                            </div>
                        </div>--%>

                        <span id="message" runat="server" class="txt02" enableviewstate="false"></span>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>


    </form>
     <script type="text/javascript">
         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode != 46 && charCode > 31
                             && (charCode < 48 || charCode > 57)) {
                 //alert('Please enter only Numbers')
                 return false;
             }
             return true;
         }
                                                                            </script>
</body>
</html>
