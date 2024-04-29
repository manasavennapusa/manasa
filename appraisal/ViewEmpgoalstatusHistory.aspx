<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEmpgoalstatusHistory.aspx.cs" Inherits="appraisal_ViewEmpgoalstatusHistory" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>


    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

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

                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <div class="alert alert-block alert-info fade in no-margin" style="border-bottom: 0px;">

                                            <h4 class="alert-heading">Employee Information
                                            </h4>
                                            <p>
                                            </p>
                                        </div>

                                        <table id="grid" class="table" style="margin-top: 0px;">
                                            <tr>
                                                <td><b>Employee Code</b></td>
                                                <td>
                                                    <asp:Label ID="lblEmployeeCode" runat="server"></asp:Label></td>
                                                <td><b>Employee Name</b></td>
                                                <td>
                                                    <asp:Label ID="lblEmployeeName" runat="server"></asp:Label></td>
                                                <td><b>DOJ</b></td>
                                                <td>
                                                    <asp:Label ID="lblDOJ" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Branch</b></td>
                                                <td>
                                                    <asp:Label ID="lblBranch" runat="server"></asp:Label></td>
                                                <td><b>Designation</b></td>
                                                <td>
                                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
                                              <td><b>Gender</b></td>
                                                <td>
                                                    <asp:Label ID="lblGender" runat="server"></asp:Label></td>
                                            </tr>

                                            <tr>
                                           
                                                <td><b>Employee Status</b></td>
                                                <td>
                                                    <asp:Label ID="lblEmployeeStatus" runat="server"></asp:Label></td>
                                                <td><b>Appraisal Cycle</b></td>
                                                <td>
                                                    <asp:Label ID="lblAppraisalCycle" runat="server"></asp:Label></td>
                                                <td></td>
                                                <td></td>
                                            </tr>

                                            <tr>
                                                <td><b>Appraisal Status</b></td>
                                                <td>
                                                    <asp:Label ID="lblAppraisalStatus" runat="server" CssClass="label label-success"></asp:Label></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>



                                        </table>
                                        <br />

                                        <div id="result" runat="server">
                                        </div>


                                        <div class="clearfix"></div>
                                    </div>
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


