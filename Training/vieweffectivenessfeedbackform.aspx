<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vieweffectivenessfeedbackform.aspx.cs" Inherits="Training_vieweffectivenessfeedbackform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

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
                        <h2>Effectiveness FeedBack Form</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>Create
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                <tbody>
                                    <tr>
                                        <td width="22%">Training Programing Name:</td>
                                        <td width="25%">
                                            <asp:Label ID="txtcmpname" runat="server"></asp:Label>
                                        </td>
                                        <td width="22%">From Date:
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="txt_frm_date" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Employee Code:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_empcode" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td >To Date:
                                        </td>
                                        <td >
                                            <asp:Label ID="Label1" runat="server"></asp:Label>&nbsp;
                                        </td>
                                       
                                    </tr>

                                    <tr>
                                        <td>Venue:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtvenue" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td>Conducted By:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_conducted_by" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Department:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_dept" runat="server"></asp:Label>&nbsp;
                                        </td>
                                       
                                       <%-- <td id="td1" runat="server" visible="true">
                                            <asp:Label ID="txt_tds" runat="server"></asp:Label>&nbsp;
                                        </td>--%>
                                         <td>Participant Name:
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_emp_name" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Rating Before The Programe:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_rt_before_prog" runat="server"></asp:TextBox>&nbsp;
                                        </td>
                                        <td>Rating After The Programe:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_rt_after_prog" runat="server"></asp:TextBox>&nbsp;
                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="Table1">
                                <tbody>

                                    <tr>
                                        <td style="width: 200px"></td>
                                        <td>Ratings before the program</td>
                                        <td style="width: 415px">Rating After the program</td>
                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <table class="table-condensed table-striped  table-bordered pull-left" id="Table2" style="width: 90%">
                                <tbody>
                                    <tr>
                                        <td style="height: 40px; text-align: center">Areas Of Improvement
                                        </td>
                                        <td style="height: 40px; text-align: center">Meets The Current Requirements
                                        </td>
                                        <td style="height: 40px; text-align: center">Needs Improvement
                                        </td>
                                        <td style="height: 40px; text-align: center">Significant Improvement Seen
                                        </td>
                                        <td style="height: 40px; text-align: center">Meets The Current Requirements
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_area_of_improvement_1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_meets_current_recuiremnt_1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_need_improvement_1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_significant_imprvemnt_1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_current_requirement_1" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_area_of_improvement_2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_meets_current_recuiremnt_2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_need_improvement_2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_significant_imprvemnt_2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_current_requirement_2" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_area_of_improvement_3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_meets_current_recuiremnt_3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_need_improvement_3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_significant_imprvemnt_3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_current_requirement_3" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_area_of_improvement_4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_meets_current_recuiremnt_4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_need_improvement_4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_significant_imprvemnt_4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_current_requirement_4" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:TextBox ID="txt_area_of_improvement_5" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_meets_current_recuiremnt_5" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_need_improvement_5" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_significant_imprvemnt_5" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_current_requirement_5" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        </td>

                                    </tr>

                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Action plan that is required to be adopted both by the supervisor and the employee over the improve upon the areas identified.
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Employee Name:
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txt_employee_name" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Supervisor:
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txt_supervisor" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Remarks Made by the Supervisor At the end of Quarter:
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txt_remarks_by_supervisor" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td width="22%">Need To Improve:
                                    </td>
                                    <td width="25%">
                                        <asp:TextBox ID="txt_need_to_improve" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>

                    </div>

                </div>

                <br />
                <br />
                <div class="form-actions no-margin" style="text-align: right">
                    <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btn_submit_Click" />
                    <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btn_reset_Click" />
                </div>
            </div>

        </div>
    </form>

</body>
</html>