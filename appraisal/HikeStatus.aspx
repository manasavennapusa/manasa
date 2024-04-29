<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HikeStatus.aspx.cs" Inherits="Appraisal_HikeStatus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>


    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

    <style type="text/css">
        .dataTables_scrollBody {
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
                            <h2>Recommendation on Hike</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Recommendation on Hike
                                    </div>
                                    <asp:DropDownList ID="ddlAppraisalCycle" runat="server" Style="float: right;" AutoPostBack="true" OnSelectedIndexChanged="ddlAppraisalCycle_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnPreRender="grid_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" DataKeyNames="assessment_id">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Appraisal Year ">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lebelyear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"APP_year") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code ">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem,"empcode") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:TemplateField HeaderText="Employee Name ">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem,"emp_fname") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Yes">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem,"ishike") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OnHold">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem,"onhold") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No (Reason for no to be filled)">
                                                    <ItemTemplate>
                                                        <%# DataBinder.Eval(Container.DataItem,"reasonforno") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Approval Status">
                                                    <ItemTemplate>
                                                        <label class="label label-success">
                                                            <%# DataBinder.Eval(Container.DataItem,"approvalstatus") %>
                                                        </label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Hike Status">
                                                    <ItemTemplate>
                                                        <label class="label label-success">
                                                            <%# DataBinder.Eval(Container.DataItem,"hikestatus") %>
                                                        </label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" class="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone"
                                                            onclick="window.open('ViewComments.aspx?id=<%#DataBinder.Eval(Container.DataItem,"assessment_id") %>','_blank','height=400px,width=600px,top=120,left=450')">Comments</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField>
                                                    <ItemTemplate>
                                                        <a href="#" class="btn btn-small btn-mini btn-primary hidden-tablet hidden-phone"
                                                            onclick="window.open('ViewAllGoalStatus.aspx?id=<%#DataBinder.Eval(Container.DataItem,"assessment_id") %>','_blank','height=600,width=1000,top=10,left=200')">View</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:HyperLinkField DataNavigateUrlFields="assessment_id" DataNavigateUrlFormatString="ViewAllGoalStatus.aspx?id_3={0}" Text="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-mini btn-info " />
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





