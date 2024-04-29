<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InitiateHike.aspx.cs" Inherits="Appraisal_InitiateHike" %>

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
                            <h2>Hike Initiation</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Hike Initiation
                                    </div>
                                    <%--<asp:Button ID="btnInitiate" runat="server" Text="Initiate Hike" CssClass="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone pull-right" OnClick="btnInitiate_Click" />--%>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnPreRender="grid_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" DataKeyNames="assessment_id">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Check All">
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                                       <%-- <asp:Button ID="btncheckall" runat="server" OnClick="btncheckall_Click" Text="Check All" />--%>
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Assessment ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblAssessmentId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"assessment_id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Employee Code" DataField="empcode" />--%>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Employee Name" DataField="emp_fname" />--%>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"emp_fname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="DOJ" DataField="emp_doj" />--%>
                                                <asp:TemplateField HeaderText="Date Of Join" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldoj" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"emp_doj") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Gender" DataField="emp_gender" />--%>
                                                <asp:TemplateField HeaderText="Gender" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblgender" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"emp_gender") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Employee Status" DataField="emp_status" />--%>
                                                <asp:TemplateField HeaderText="Employee Status" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempstatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"quater") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Designation" DataField="designationname" />--%>
                                                <asp:TemplateField HeaderText="Designation">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldesg" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"designationname") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:BoundField HeaderText="Appraisal Status" DataField="freeze" />--%>
                                                <asp:TemplateField HeaderText="Appraisal Year" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblaprstatus" runat="server" Text='<%#DataBinder.Eval(Container.DataItem,"APP_year") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField DataNavigateUrlFields="assessment_id" DataNavigateUrlFormatString="ViewAllGoalStatus.aspx?id={0}" Text="&lt;img src='../images/view.png' /&gt;" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderText="View" />
                                            </Columns>
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                <div class="form-actions no-margin" style="text-align:right">
                                    <%--<asp:Button ID="btnInitiate" runat="server" Text="Initiate Hike" CssClass="btn btn-info" OnClick="btnInitiate_Click" />--%>
                                   <asp:Button ID="btn_initiate_hike" runat="server" Text="Initiate Hike" CssClass="btn btn-info" OnClick="btn_initiate_hike_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script type="text/javascript" src="../js/timepicker.js"></script>

    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>

<%--<script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grid').dataTable({
                //bFilter: false,
                //bInfo: false,
                bPaginate: false,
                sScrollY: "200px",
                sScrollCollapse: true
            });
        });
    </script>--%>
</body>
</html>
