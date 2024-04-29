<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trainingtypemasterentry.aspx.cs" Inherits="Training_trainingtypemasterentry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
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

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

        <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>

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
     <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <br />
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Training Schedule</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                       <%-- <div class="row-fluid">
                            <div class="span12">--%>
                                <%--<div class="widget">--%>
                                  <%--  <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Training Schedule"></asp:Label>
                                        </div>
                                    </div>--%>
                                 <%--   <div class="widget-body">
                                        <br />--%>

                                        <div class="row-fluid">
                                            <div class="span6">
                                                <div class="widget">
                                                    <div class="widget-header" style="border-bottom: none;">
                                                        <div class="title">
                                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>Create
                                                        </div>
                                                    </div>

                                                    <fieldset>
                                                        <br /><br />
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Training Code<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddltrainingcode" runat="server" AutoPostBack="true" CssClass="span10" OnDataBound="ddltrainingcode_DataBound" OnSelectedIndexChanged="ddltrainingcode_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddltrainingcode" ErrorMessage="CompareValidator" SetFocusOnError="True" Operator="NotEqual" ToolTip="Training Code Required" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator10" SetFocusOnError="True" ToolTip="Select Training Code" 
                                                                    ControlToValidate="ddltrainingcode" ValidationGroup="c" InitialValue="0" 
                                                                    runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Training Name</label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txttrainingname" runat="server" CssClass="span10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Branch<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddl_branch_id" runat="server" AutoPostBack="true" CssClass="span10" OnDataBound="ddl_branch_id_DataBound" OnSelectedIndexChanged="ddl_branch_id_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddl_branch_id" 
                                                                    SetFocusOnError="True" ErrorMessage="CompareValidator" Operator="NotEqual" 
                                                                    ToolTip="Branch Required" ValidationGroup="c" ValueToCompare="0">
                                                                    <img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                             <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator9" SetFocusOnError="True" ToolTip="Select Branch Name " 
                                                                    ControlToValidate="ddl_branch_id" ValidationGroup="c" InitialValue="0" 
                                                                    runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Department Type<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddl_department" runat="server" AutoPostBack="true" CssClass="span10" OnDataBound="ddl_department_DataBound" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                 <asp:CompareValidator ID="CompareValidator3" runat="server" SetFocusOnError="True" ControlToValidate="ddl_department" ErrorMessage="CompareValidator" Operator="NotEqual" ToolTip="Department Type Required" ValidationGroup="c" ValueToCompare="0"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" ToolTip="Department Type Required" ControlToValidate="ddl_department" ValidationGroup="c" InitialValue="" runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                               
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Department<span class="star"></span>
                                                            </label>
                                                            <div class="controls">
                                                                <asp:ListBox ID="lst_deptname" runat="server" CssClass="span10" SelectionMode="Multiple" AutoPostBack="true"
                                                                    OnDataBound="lst_deptname_DataBound"></asp:ListBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ToolTip="Department Required" SetFocusOnError="True" ControlToValidate="lst_deptname" ValidationGroup="c" InitialValue="" runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Month<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddl_month" runat="server" CssClass="span10" AutoPostBack="true" OnSelectedIndexChanged="ddl_month_SelectedIndexChanged">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                                                    <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                                                    <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                                                    <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                                                    <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                                    <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                                                    <asp:ListItem Value="7" Text="Jul"></asp:ListItem>
                                                                    <asp:ListItem Value="8" Text="Aug"></asp:ListItem>
                                                                    <asp:ListItem Value="9" Text="Sep"></asp:ListItem>
                                                                    <asp:ListItem Value="10" Text="Oct"></asp:ListItem>
                                                                    <asp:ListItem Value="11" Text="Nov"></asp:ListItem>
                                                                    <asp:ListItem Value="12" Text="Dec"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" SetFocusOnError="True" ToolTip="Month Required"
                                                                      ControlToValidate="ddl_month" ValidationGroup="c" InitialValue="0" 
                                                                     runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Year<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddlyear" runat="server" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true" CssClass="span10">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="2017" Text="2017"></asp:ListItem>
                                                                    <asp:ListItem Value="2018" Text="2018"></asp:ListItem>
                                                                    <asp:ListItem Value="2019" Text="2019"></asp:ListItem>
                                                                    <asp:ListItem Value="2020" Text="2020"></asp:ListItem>
                                                                    <asp:ListItem Value="2021" Text="2021"></asp:ListItem>
                                                                    <asp:ListItem Value="2022" Text="2022"></asp:ListItem>
                                                                    <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                                                    <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                                                                    <asp:ListItem Value="2025" Text="2025"></asp:ListItem>
                                                                    <asp:ListItem Value="2026" Text="2026"></asp:ListItem>
                                                                    <asp:ListItem Value="2027" Text="2027"></asp:ListItem>
                                                                    <asp:ListItem Value="2028" Text="2028"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" SetFocusOnError="True" ToolTip="Year Required"
                                                                      ControlToValidate="ddlyear" ValidationGroup="c" InitialValue="0" 
                                                                     runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                From Date<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_fromdate" runat="server" CssClass="span10" placeholder="dd-mm-yyyy" onkeydown="return enterdate(event);" onkeypress="return false;" onpaste="return false;" OnTextChanged="txt_fromdate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" ToolTip="click to open calender" />
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" Enabled="True" Format="dd MMM yyyy" PopupButtonID="Image1" TargetControlID="txt_fromdate">
                                                                </cc1:CalendarExtender>
                                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" SetFocusOnError="True" ToolTip="From Date Required"
                                                                      ControlToValidate="txt_fromdate" ValidationGroup="c"  
                                                                     runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                To Date<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_todate" runat="server" CssClass="span10" placeholder="dd-mm-yyyy" onkeydown="return enterdate(event);" onkeypress="return false;" onpaste="return false;" OnTextChanged="txt_todate_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/img/clndr.gif" ToolTip="click to open calender" />
                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" Enabled="True" Format="dd MMM yyyy" PopupButtonID="Image2" TargetControlID="txt_todate">
                                                                </cc1:CalendarExtender>
                                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator8" SetFocusOnError="True" ToolTip="To Date Required"
                                                                      ControlToValidate="txt_todate" ValidationGroup="c"  
                                                                     runat="server"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>

                                            </div>

                                            <%-- ******************************Changed By Irshad***********************************--%>

                                            <div class="span6">
                                                <div class="widget">
                                                    <div class="widget-header" style="border-bottom: none;">
                                                        <div class="title">
                                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                        </div>
                                                    </div>
                                                    <fieldset>
                                                        <br /><br />
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Batch Code<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_bachcode" runat="server" CssClass="span10"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_bachcode"
                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Batch Code Required" ValidationGroup="c"
                                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Training Type</label>
                                                            <div class="controls">
                                                                <asp:DropDownList ID="ddl_trainingtype" runat="server" OnDataBound="ddl_trainingtype_DataBound" CssClass="span10">
                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                    <asp:ListItem Value="Long training" Text="Long training"></asp:ListItem>
                                                                    <asp:ListItem Value="Short training" Text="Short training"></asp:ListItem>
                                                                    <asp:ListItem Value="Week End Batch training" Text="Week End Batch training"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Training Short Name
                                                            </label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_training_short_name" runat="server" CssClass="span10"  placeholder="Max 50 Chars.."></asp:TextBox>
                                                            </div>
                                                        </div>

                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Venue of Training</label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_time_of_training" runat="server" CssClass="span10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Module Name
                                                            </label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_module_name" runat="server" CssClass="span10"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Description</label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_description" CssClass="span10" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                Faculty<span class="star"></span></label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_faculty" runat="server" CssClass="span10" Enabled="false"></asp:TextBox>
                                                                <a href="JavaScript:newPopup1('pickfaculty.aspx?role=10&employee=<%=txt_faculty.Text.ToString() %>');" title="Pick Faculty"><i class="icon-user"></i></a>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_faculty"
                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Faculty Required" ValidationGroup="c"
                                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </div>
                                                            
                                                        </div>
                                                        <div class="control-group">
                                                            <label class="control-label">
                                                                No of Hours: (if required)</label>
                                                            <div class="controls">
                                                                <asp:TextBox ID="txt_noofhours" runat="server" CssClass="span10" placeholder="hh:mm:ss"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <%-- <div class="control-group">
                                            <label class="control-label">
                                            TDS Circle</label>
                                            <div class="controls">
                                                 <asp:TextBox ID="txt_Epfoffadd" type="text" runat="server" class="span10" maxlength="20" onkeypress="return isChar_Number_space_ifin()" />
                                            </div>
                                        </div>--%>
                                                        <div class="control-group" style="padding-bottom: 11px">
                                                            <label class="control-label">
                                                                Source</label>
                                                            <div class="controls">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RadioButton ID="rd_internal" runat="server" Text="Internal" GroupName="ab" OnCheckedChanged="rd_internal_CheckedChanged" />
                                                                        </td>
                                                                        <td class="auto-style1">
                                                                            <asp:RadioButton ID="rd_external" runat="server" Text="External" GroupName="ab" OnCheckedChanged="rd_external_CheckedChanged" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </fieldset>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row-fluid">

                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Select Training Effectiveness To Be Conducted:</td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_training_effectiveness_yes" runat="server" Text="Yes" GroupName="te" />
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_training_effectiveness_no" runat="server" Text="NO" GroupName="te" />
                                                    </td>
                                                </tr>
                                            </table>


                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Select Training Feedback To Be Conducted:
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_training_feedback_yes" runat="server" Text="Yes" GroupName="tf" />
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_training_feedback_no" runat="server" Text="NO" GroupName="tf" />
                                                    </td>
                                                </tr>
                                            </table>


                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Select participants Action plan:
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_participants_action_yes" runat="server" Text="Yes" GroupName="pa" />
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="rd_participants_action_no" runat="server" Text="NO" GroupName="pa" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>

                                        <div class="row-fluid">

                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Programe:
                                                    </td>
                                                    <td width="25%">
                                                        <%--   <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" GroupName="pa" AutoPostBack="True"/>--%>
                                                        <asp:RadioButton ID="programe_yes" runat="server" Text="Yes" GroupName="pr" />
                                                        <td width="25%">
                                                            <asp:RadioButton ID="programe_no" runat="server" Text="NO" GroupName="pr" />
                                                </tr>
                                            </table>

                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Faculty Description:
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="facultydescription_yes" runat="server" Text="Yes" GroupName="fd" />
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="facultydescription_no" runat="server" Text="NO" GroupName="fd" />
                                                    </td>
                                                </tr>
                                            </table>

                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td width="25%">Any Other:
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="anyother_yes" runat="server" Text="Yes" GroupName="ao" />
                                                    </td>
                                                    <td width="25%">
                                                        <asp:RadioButton ID="anyother_no" runat="server" Text="NO" GroupName="ao" />
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>

                                        <div class="row-fluid">
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span>


                                        </div>
                                        <%--***************************************************************  Changes for column***********************************************--%>
                                   <%-- </div>--%>

                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-info"
                                            ValidationGroup="c"></asp:Button>
                                    </div>
                                    <span id="message" runat="server"></span>

                                <%--</div>--%>
                            <%--</div>
                        </div>--%>
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
