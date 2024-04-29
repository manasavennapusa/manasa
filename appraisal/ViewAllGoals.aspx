<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewAllGoals.aspx.cs" Inherits="Appraisal_ViewAllGoals" %>

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

    <script type="text/javascript">
        // window.onload = window.parent.iframeLoaded(this);
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="dashboard-wrapper" style="margin-left: 0px;">

                <div class="main-container">

                    <div class="page-header">
                        <div class="pull-left">
                            <h2>All Appraisal Cycle Status</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>All Appraisal Cycle Status
                 
                                    </div>
                                    <asp:DropDownList 
                                        ID="ddlAppraisalCycle" 
                                        runat="server" 
                                        Style="float: right;" 
                                        AutoPostBack="true" 
                                        OnSelectedIndexChanged="ddlAppraisalCycle_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid"
                                            runat="server"
                                            AutoGenerateColumns="false"
                                            OnPreRender="grid_PreRender"
                                            CssClass="table table-condensed table-striped table-hover table-bordered table-checkable"
                                            DataKeyNames="assessment_id,empcode">
                                            <Columns>
                                                <asp:BoundField HeaderText="Appraisal Status" DataField="APP_year" />
                                                <asp:BoundField HeaderText="Employee Code" DataField="empcode" />
                                                <asp:BoundField HeaderText="Employee Name" DataField="emp_fname" />
                                                <asp:BoundField HeaderText="DOJ" DataField="emp_doj" />
                                                <asp:BoundField HeaderText="Gender" DataField="emp_gender" />
                                                <asp:BoundField HeaderText="Employee Status" DataField="employeestatus" />
                                               <%-- <asp:BoundField HeaderText="Branch" DataField="branch_name" />--%>
                                                <asp:BoundField HeaderText="Designation" DataField="designationname" />
                                                <asp:BoundField HeaderText="Goal Assigned Date" DataField="create_date" />
                                                <%-- <asp:BoundField HeaderText="Appraisal Status" DataField="freeze" />--%>
                                                <asp:HyperLinkField
                                                    DataNavigateUrlFields="assessment_id,empcode"
                                                    DataNavigateUrlFormatString="ViewEmpgoalstatusHistory.aspx?assessment_id={0}&empcode={1}"
                                                    Text="View"
                                                    ItemStyle-HorizontalAlign="Center"
                                                    HeaderStyle-HorizontalAlign="Center"
                                                    NavigateUrl="ViewEmpgoalstatusHistory"
                                                    ControlStyle-CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone" />

                                            </Columns>
                                        </asp:GridView>

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
                //bFilter: false,
                //bInfo: false,
                bPaginate: false,
                sScrollY: "500px",
                sScrollCollapse: true
            });
        });
    </script>
</body>
</html>


