<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createbranch.aspx.cs" Inherits="Admin_Company_createcompany"
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

    <script type="text/javascript">
        function IsNumeric(eventObj) {

            var keycode;

            if (eventObj.keyCode) //For IE
                keycode = eventObj.keyCode;
            else if (eventObj.Which)
                keycode = eventObj.Which;  // For FireFox
            else
                keycode = eventObj.charCode; // Other Browser

            if (keycode != 8) //if the key is the backspace key
            {
                if (keycode < 48 || keycode > 57) //if not a number
                    return false; // disable key press
                else
                    return true; // enable key press
            }
        }

        function isAlpha(keyCode) {

            return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9)

        }

        function isAddress(keyCode) {

            return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9 || keyCode == 13 || keyCode == 51 || keyCode == 50)
        }

        function validateEmail(obj) {
            var x = obj.value;
            if (x != '') {
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");
                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    obj.focus();
                    alert("Not a valid e-mail address");
                    return false;
                }
            }
        }

        function capitalizeMe(obj) {
            val = obj.value;
            newVal = '';
            val = val.split(' ');
            for (var c = 0; c < val.length; c++) {
                newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
            }
            obj.value = newVal.trim();
        }

    </script>

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
                                <h2> Work Location </h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span> Create
                                        </div>
                                    </div>
                                    <fieldset>
                                          <br />
                                        <div class="control-group">
                                            <label class="control-label">
                                            Company Name</label>
                                            <div class="controls">
                                                <%--<input type="text" id="drp_comp_name" runat="server" class="span10" onkeypress="return isCharOrSpace()" />--%>
                                                <asp:TextBox ID="drp_comp_name" runat="server" class="span10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                <%--<asp:DropDownList ID="drp_comp_name" runat="server" CssClass="span10" DataSourceID="SqlDataSource1" DataTextField="companyname" DataValueField="companyid">
                                                </asp:DropDownList>--%>
                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drp_comp_name" ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT [companyid], [companyname] FROM [tbl_intranet_companydetails]"></asp:SqlDataSource>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Region Name<span class="star" style="color:red">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="drp_region" runat="server" CssClass="span10">
                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                    <asp:ListItem>North</asp:ListItem>
                                                    <asp:ListItem>South</asp:ListItem>
                                                    <asp:ListItem>East</asp:ListItem>
                                                    <asp:ListItem>West</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_region" ErrorMessage="CompareValidator" Operator="NotEqual" ToolTip="Select Region Name" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Work Location Name<span class="star" style="color:red">*</span></span></label>
                                            <div class="controls">
                                                <input type="text" id="txt_branch_name" runat="server" class="span10" onkeypress="return isCharOrSpace()" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Work Location  Name" ValidationGroup="c" Width="6px"><img src="../img/../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Work Location Code</label>
                                            <div class="controls">
                                                <input type="text" id="txt_branch_code" runat="server" class="span10" onkeypress="return isChar_Number_slash()" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Establishment Date</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_est_date" runat="server" CssClass="span6" onkeydown="return enterdate(event);" onkeypress="return false;" onpaste="return false;"></asp:TextBox>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" ToolTip="click to open calender" />
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd MMM yyyy" PopupButtonID="Image1" TargetControlID="txt_est_date">
                                                </cc1:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            ESI Code No.</label>
                                            <div class="controls">
                                                <input type="text" id="txt_esi_local_no" runat="server" class="span10" onkeypress="return IsNumeric()" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            ESI Work Location Office</label>
                                            <div class="controls">
                                                <input type="text" id="txt_Pfphoneno" runat="server" class="span10" maxlength="12" onkeypress="return isChar_Number_slash()" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            ESI Contact No.</label>
                                            <div class="controls">
                                                <input id="txt_Panno" type="text" runat="server" class="span10" width="" maxlength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            PT Circle</label>
                                            <div class="controls">
                                                <input id="txt_PtCircle" type="text" runat="server" class="span10" maxlength="20" onkeypress="return isChar_Number_space_ifin()" />
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="txt_PtCircle" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" ToolTip="Enter only numbers minimum 10 digits" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ValidationGroup="c"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <%--  <div class="form-actions no-margin">
                                                <div style="padding-left: 10%">
                                                    <asp:Button ID="Button1"  runat="server" Text="Save" CssClass="btn btn-primary"
                                                        OnClientClick="return Validate();"></asp:Button>
                                                </div>
                                              
                                            </div>--%>
                                    </fieldset>

                                </div>

                            </div>

                            <%-- ******************************Changed By Irshad***********************************--%>

                            <div class="span6">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>
                                        </div>
                                    </div>
                                    <fieldset>
                                           <br />
                                        <div class="control-group">
                                            <label class="control-label">
                                            Address</label>
                                            <div class="controls">
                                                <input type="text" id="txt_pre_add1" runat="server" class="span10" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()" />
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pre_add1"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address" ValidationGroup="c"
                                                        Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Country</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" CssClass="span10" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlcountry"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Country" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            State</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlstate" runat="server" AutoPostBack="true" CssClass="span10" OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddlstate"
                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select State"
                                                        ValidationGroup="c" Width="6px"><img 
                                                                src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            City</label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlCity" runat="server" CssClass="span10">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlCity"
                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select City"
                                                        ValidationGroup="c" Width="6px"><img 
                                                                src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            Zip Code</label>
                                            <div class="controls">
                                                <input type="text" id="txt_pre_zip" runat="server" maxlength="6" class="span10" onkeypress=" return isNumberKey(event)" />
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_pre_zip"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter only numbers, min 6 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            EPF Code No.</label>
                                            <div class="controls">
                                                <input type="text" id="txt_esibranchoffice" runat="server" class="span10" onkeypress="return isChar_Number_slash()" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            EPF Work Location Office</label>
                                            <div class="controls">
                                                <input id="txt_Esiphno" runat="server" class="span10" type="text" maxlength="12" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            EPF Contact No.</label>
                                            <div class="controls">
                                                <input id="txt_Epfoffice" type="text" runat="server" class="span10" maxlength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" />
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_Epfoffice"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only numbers minimum 10 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                            TDS Circle</label>
                                            <div class="controls">
                                                <input id="txt_Epfoffadd" type="text" runat="server" class="span10" maxlength="20" onkeypress="return isChar_Number_space_ifin()" />
                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_Epfoffadd"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ToolTip="Enter only numbers minimum 10 digits"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                            </div>
                                        </div>
                                        <%--  <div class="form-actions no-margin">
                                                <div style="padding-left: 10%">
                                                    <asp:Button ID="Button1"  runat="server" Text="Save" CssClass="btn btn-primary"
                                                        OnClientClick="return Validate();"></asp:Button>
                                                </div>
                                              
                                            </div>--%>
                                       
                                    </fieldset>

                                </div>

                            </div>
                        </div>
                        <%--***************************************************************  Changes for column***********************************************--%>
                    </div>

                    <div class="form-actions no-margin" align="right">
                        <%-- CssClass="btn btn-info"--%>
                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-info"
                            ValidationGroup="c"></asp:Button>
                        <asp:Button ID="btnreset" OnClick="btnreset_Click" runat="server" Text="Reset" CssClass="btn btn-info"
                            ValidationGroup=""></asp:Button>

                    </div>
                    <span id="message" runat="server"></span>
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
