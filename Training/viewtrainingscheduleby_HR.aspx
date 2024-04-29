<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtrainingscheduleby_HR.aspx.cs" Inherits="Training_viewtrainingscheduleby_HR" %>

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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                <tbody>
                                    <tr class="frm-lft-clr123">
                                        <td style="width: 25%">Training Code <%--<span class="star"></span>--%></td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddltrainingcode" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 25%">Batch Code<%--<span class="star"></span>--%>
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_bachcode" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Training Name <%--<span class="star"></span>--%>
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txttrainingname" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 25%">Training Type
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddl_trainingtype" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Branch 
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddl_branch_id" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 25%">Training Short Name
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_training_short_name" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Department Type
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddl_department" runat="server"></asp:Label>
                                        </td>

                                        <td style="width: 25%">Venue of Training
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_time_of_training" runat="server"></asp:Label>
                                        </td>


                                    </tr>

                                    <tr>
                                        <td style="width: 25%">Department
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="lst_deptname" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 25%">Module Name
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_module_name" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <%--   <td style="width: 25%">Module Name
                                        </td>
                                        <td style="width: 25%">                                           
                                        
                                            <asp:Label ID="txt_module_name" runat="server"></asp:Label>
                                        </td>--%>
                                                <td style="width: 25%">Month
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddl_month" runat="server"></asp:Label>
                                        </td>
                                       
                                            <td style="width: 25%">Description
                                            </td>
                                            <td style="width: 25%">

                                                <asp:Label ID="txt_description" runat="server"></asp:Label>
                                            </td>
                                    </tr>

                                    <tr>

                                         <td style="width: 25%">Year
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="ddlyear" runat="server"></asp:Label>
                                            </td>


                                       

                                        <td style="width: 25%">Faculty
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_faculty" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                          <td style="width: 25%">From Date
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="txt_fromdate" runat="server"></asp:Label>

                                        </td>

                                     
                                        <td style="width: 25%">No of Hours: (if required)
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_noofhours" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                           <td style="width: 25%">To Date
                                        </td>
                                        <td style="width: 25%">
                                            <asp:Label ID="txt_todate" runat="server"></asp:Label>

                                        </td>

                                       
                                        <td style="width: 25%">Source
                                        </td>
                                        <td style="width: 25%">
                                            <%--<label class="radio inline">
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
                                            </label>--%>
                                            <asp:Label ID="rd_internal" runat="server"></asp:Label>
                                        </td>


                                    </tr>


                                    <%-- <tr>
                                        <td style="width: 25%">Module Name
                                        </td>
                                        <td style="width: 25%">

                                            <asp:Label ID="txt_module_name" runat="server"></asp:Label>
                                        </td>



                                        <td style="width: 25%"></td>
                                        <td style="width: 25%"></td>

                                    </tr>--%>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">

                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Select Training Effectiveness To Be Conducted:</td>
                            <td width="50%">
                                <asp:Label ID="rd_training_effectiveness_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>


                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Select Training Feedback To Be Conducted:
                            </td>
                            <td width="50%">
                                <asp:Label ID="rd_training_feedback_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>


                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Select participants Action plan:
                            </td>
                            <td width="50%">
                                <%--  <asp:RadioButton ID="rd_participants_action_yes" runat="server" Text="Yes" GroupName="pa" />--%>
                                <asp:Label ID="rd_participants_action_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>

                </div>

                <div class="row-fluid">

                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Programe:
                            </td>
                            <td width="50%">

                                <asp:Label ID="programe_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>

                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Faculty Description:
                            </td>
                            <td width="50%">

                                <asp:Label ID="facultydescription_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>

                    <table class="table table-condensed table-striped  table-bordered pull-left">
                        <tr>
                            <td width="50%">Any Other:
                            </td>
                            <td width="50%">

                                <asp:Label ID="anyother_yes" runat="server"></asp:Label>
                            </td>

                        </tr>
                    </table>

                </div>
                <br />
                <div class="form-actions no-margin" style="text-align: right">
                    <asp:Button ID="btnback" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btnback_Click"></asp:Button>

                </div>
                <br />
                <br />

                <div class="row-fluid">



                    <div align="right">
                        <%--  <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-primary"
                            ValidationGroup="c"></asp:Button>--%>
                    </div>

                    <span id="message" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span>


                </div>
            </div>
        </div>
    </form>

</body>
</html>
