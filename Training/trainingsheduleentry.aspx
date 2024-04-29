<%@ Page Title="Training Schedule Entry" Language="C#"
    AutoEventWireup="true"
    CodeFile="trainingsheduleentry.aspx.cs"
    Inherits="Training_TrainingSheduleEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        width: 88px;
    }
</style>
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
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Training Schedule</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Create
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                <tbody>
                                    <tr class="frm-lft-clr123">
                                        <td style="width: 25%">Training Code: <%--<span class="star"></span>--%></td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddltrainingcode" runat="server" CssClass="span10" AutoPostBack="true" OnSelectedIndexChanged="ddltrainingcode_SelectedIndexChanged" OnDataBound="ddltrainingcode_DataBound"></asp:DropDownList>
                                             <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddltrainingcode"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Training Code"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                        </td>
                                        <td style="width: 25%">Batch Code<%--<span class="star"></span>--%>
                                        </td>
                                        <td style="width: 25%">                                         
                                            <asp:TextBox ID="txt_bachcode" runat="server" CssClass="span10"></asp:TextBox> 
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_bachcode"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Batch Code" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Training Name: <%--<span class="star"></span>--%>
                                        </td>
                                        <td style="width: 25%">
                                            <asp:TextBox ID="txttrainingname" runat="server" CssClass="span10"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%">Training Type
                                        </td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddl_trainingtype" runat="server" OnDataBound="ddl_trainingtype_DataBound">
                                                <asp:ListItem Value="0">----Selected Training type</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Long training"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Short training"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Week End Batch training"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Branch:
                                        </td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddl_branch_id" runat="server" CssClass="span10" AutoPostBack="true" OnSelectedIndexChanged="ddl_branch_id_SelectedIndexChanged" OnDataBound="ddl_branch_id_DataBound">
                                            </asp:DropDownList>
                                             <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddl_branch_id"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Branch Name"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                        </td>
                                        <td style="width: 25%">Training Short Name
                                        </td>
                                        <td style="width: 25%">                                          
                                            <asp:TextBox ID="txt_training_short_name" runat="server" CssClass="span10"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Department Type
                                        </td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddl_department" runat="server" CssClass="span10" AutoPostBack="true" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" OnDataBound="ddl_department_DataBound">
                                            </asp:DropDownList>
                                             <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddl_department"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Department Type"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                        </td>
                                        <td style="width: 25%">year
                                        </td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddlyear" runat="server" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">---Select year---</asp:ListItem>
                                                <asp:ListItem Value="1" Text="2017"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="2018"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="2019"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="2020"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="2021"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="2022"></asp:ListItem>
                                                <asp:ListItem Value="7" Text="2023"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="2024"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="2025"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="2026"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="2027"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="2028"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Department Name
                                        </td>
                                        <td style="width: 25%">
                                            <asp:ListBox ID="lst_deptname" runat="server" CssClass="span10" SelectionMode="Multiple" AutoPostBack="true" 
                                                OnSelectedIndexChanged="lst_deptname_SelectedIndexChanged" OnDataBound="lst_deptname_DataBound"></asp:ListBox>
                                              <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="lst_deptname"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Department Name"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                           <%-- <asp:RequiredFieldValidator ID = "RequiredFieldValidator2" ControlToValidate ="lst_deptname" InitialValue = ""  runat="server" 
                                                ErrorMessage = "Please select some Department Name"></asp:RequiredFieldValidator> --%>
                                        </td>
                                        <td style="width: 25%">To Date
                                        </td>
                                        <td style="width: 25%">
                                            <asp:TextBox ID="txt_todate" runat="server" CssClass="span10" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                            <asp:Image
                                                ID="Image1"
                                                runat="server"
                                                ImageUrl="~/img/clndr.gif"
                                                ToolTip="click to open calender" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                TargetControlID="txt_todate" Enabled="True" Format="dd MMM yyyy">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Module Name
                                        </td>
                                        <td style="width: 25%">                                           
                                            <asp:TextBox ID="txt_module_name" runat="server" CssClass="span10" ></asp:TextBox>
                                        </td>
                                        <td style="width: 25%">Time/Venue of Training
                                        </td>
                                        <td style="width: 25%">                                          
                                            <asp:TextBox ID="txt_time_of_training" runat="server" CssClass="span10"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Description
                                        </td>
                                        <td style="width: 25%">
                                            <asp:TextBox ID="txt_description" CssClass="span10" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td style="width: 25%">Faculty
                                        </td>
                                        <td style="width: 25%">                                           
                                            <asp:TextBox ID="txt_faculty" runat="server"  CssClass="span10"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_faculty"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Faculty Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Month
                                        </td>
                                        <td style="width: 25%">
                                            <asp:DropDownList ID="ddl_month" runat="server" CssClass="span10" AutoPostBack="true">
                                                <asp:ListItem Value="0">---Select month---</asp:ListItem>
                                                <asp:ListItem Value="1" Text="Jan"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Feb"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Mar"></asp:ListItem>
                                                <asp:ListItem Value="4" Text="Apr"></asp:ListItem>
                                                <asp:ListItem Value="5" Text="May"></asp:ListItem>
                                                <asp:ListItem Value="6" Text="Jun"></asp:ListItem>
                                                <asp:ListItem Value="8" Text="Jul"></asp:ListItem>
                                                <asp:ListItem Value="9" Text="Aug"></asp:ListItem>
                                                <asp:ListItem Value="10" Text="Sap"></asp:ListItem>
                                                <asp:ListItem Value="11" Text="Oct"></asp:ListItem>
                                                <asp:ListItem Value="12" Text="Nov"></asp:ListItem>
                                                <asp:ListItem Value="13" Text="Dec"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td style="width: 25%">No of Hours: (if required)
                                        </td>
                                        <td style="width: 25%">                                           
                                            <asp:TextBox ID="txt_noofhours" runat="server" CssClass="span10"></asp:TextBox>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">From Date
                                        </td>
                                        <td style="width: 25%">
                                            <asp:TextBox ID="txt_fromdate" runat="server" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&#160;<asp:Image ID="Image4" runat="server"
                                                ImageUrl="~/img/clndr.gif" placeholder="Select Date" />
                                            <cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                ID="CalendarExtender4" runat="server" PopupButtonID="Image4" TargetControlID="txt_fromdate"
                                                Enabled="True">
                                            </cc1:CalendarExtender>
                                        </td>
                                        <td style="width: 25%">Source
                                        </td>
                                        <td style="width: 25%">
                                            <label class="radio inline">
                                                <table>
                                                    <tr>
                                                        <td>

                                                            <asp:RadioButton
                                                                ID="rd_internal"
                                                                runat="server"
                                                                Text="Internal"
                                                                GroupName="ab"
                                                                OnCheckedChanged="rd_internal_CheckedChanged" />
                                                        </td>
                                                        <td class="auto-style1">
                                                            <asp:RadioButton
                                                                ID="rd_external"
                                                                runat="server"
                                                                Text="External"
                                                                GroupName="ab"
                                                                OnCheckedChanged="rd_external_CheckedChanged" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">

                      <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="25%">Select Training Effectiveness To Be Conducted:nducted:</td>
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
                                    <td width="25%">Faculty Description
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
                                    <td width="25%">Any Other
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



                    <div align="right">
                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-primary"
                            ValidationGroup="c"></asp:Button>
                    </div>

                    <span id="message" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span>


                </div>
            </div>
    </form>

</body>
</html>