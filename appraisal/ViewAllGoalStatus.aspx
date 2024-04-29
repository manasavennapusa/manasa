<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllGoalStatus.aspx.cs" Inherits="Appraisal_ViewAllGoalStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>


    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

    <style type="text/css">
        .dataTables_scrollBody
        {
            margin-top: -11px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="dashboard-wrapper" style="margin-left: 0px;">

                <div class="main-container">

                    <div class="page-header">
                        <div class="pull-left">
                            <h2>View Goal Cycle</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">

                                        <table id="grid" style="margin-top: 0px;" class="table table-condensed table-bordered pull-left">
                                            <tr>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Employee Code</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label></td>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Employee Name</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></td>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>DOJ</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblDOJ" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Branch</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblBranch" runat="server"></asp:Label></td>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Designation</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
                                                <%--<td><b>Grade</b></td>
                                                <td>
                                                    <asp:Label ID="lblGrade" runat="server"></asp:Label></td>--%>
                                                <td style="background-color: #f5f5f5;display:none; width: 16%"><b>Appraisal Status</b></td>
                                                <td style="width: 16%;display:none">
                                                    <asp:Label ID="lblAppraisalStatus" runat="server" CssClass="label label-success"></asp:Label></td>
                                                <td style="background-color: #f5f5f5; width: 16%;border-bottom:1px solid #ddd"><b>Appraisal Cycle</b></td>
                                                <td style="width: 16%;border-bottom:1px solid #ddd">
                                                    <asp:Label ID="lblAppraisalCycle" runat="server"></asp:Label></td>
                                            </tr>

                                            <tr>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Gender</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblGender" runat="server"></asp:Label></td>
                                                <td style="background-color: #f5f5f5; width: 16%"><b>Employee Status</b></td>
                                                <td style="width: 16%;border-right:1px solid #ddd">
                                                    <asp:Label ID="lblEmployeeStatus" runat="server"></asp:Label></td>
                                                <%--<td style="background-color: #f5f5f5; width: 16%"><b>Appraisal Cycle</b></td>
                                                <td style="width: 16%">
                                                    <asp:Label ID="lblAppraisalCycle" runat="server"></asp:Label></td>--%>
                                            </tr>

                                            <%--<tr>
                                                <td><b>Appraisal Status</b></td>
                                                <td>
                                                    <asp:Label ID="lblAppraisalStatus" runat="server" CssClass="label label-success"></asp:Label></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>--%>
                                        </table>
                                        <br />

                                        <div id="result" runat="server">
                                        </div>


                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="form-actions no-margin" style="text-align:right">
                                    <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btnBack_Click" />
                                    <asp:Button ID="btn_Back_1" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_1_Click" />
                                    <asp:Button ID="btn_Back_2" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_2_Click" />
                                    <asp:Button ID="btn_Back_3" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_3_Click" />
                                    <asp:Button ID="btn_Back_4" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_4_Click" />
                                    <asp:Button ID="btn_Back_5" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_5_Click" />
                                    <asp:Button ID="btn_Back_6" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_6_Click" />
                                    <asp:Button ID="btn_Back_7" runat="server" Text="Back" CssClass="btn btn-info" Visible="false" OnClick="btn_Back_7_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grid').dataTable({
                bFilter: false,
                bInfo: false,
                bPaginate: false,
                sScrollY: "500px",
                "aoColumnDefs": [{ "bSortable": false, }, null, null, null, null, null]
            });
        });
    </script>
</body>
</html>


