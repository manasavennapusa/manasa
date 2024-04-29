<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproverPromotion.aspx.cs" Inherits="Appraisal_ApproverPromotion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>

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
                            <h2>Recommendation on Promotion</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Recommendation on Promotion
                 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid" runat="server" AutoGenerateColumns="false" OnPreRender="grid_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" DataKeyNames="assessment_id" OnRowEditing="grid_RowEditing" OnRowDataBound="grid_RowDataBound">
                                            <Columns>
                                                  <asp:TemplateField HeaderText="Appraisal Year">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lebelyear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"APP_year") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"empcode") %>'></asp:Label>
                                                        <%--<%# DataBinder.Eval(Container.DataItem,"empcode") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"emp_fname") %>'></asp:Label>
                                                        <%--<%# DataBinder.Eval(Container.DataItem,"emp_fname") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="quater" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="labelquert" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quater") %>'></asp:Label>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                              

                                                <asp:TemplateField HeaderText="Tenure - Min 2 Years on the Same Role">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblSameRole" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"ismin2yearsonsamerole") %>'></asp:Label>

                                                        <asp:DropDownList ID="ddlSameRole" runat="server" Width="80px">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="PMP - Avg2 Years > 85">
                                                    <ItemTemplate>

                                                        <asp:Label ID="lblAvg2Years" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"avr2yearweightagegreaterthan85") %>'>
                                                        </asp:Label>

                                                        <asp:DropDownList ID="ddlAvg2Years" runat="server" Width="80px" AutoPostBack="true">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Communications/Leadership Skills - (management observation/Psychometric Testing/Leadership Interviews)">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtReason" runat="server" CssClass="span12" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem,"reason") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comments">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <a href="#" class="btn btn-mini btn-info" onclick="window.open('ViewPromotionComments.aspx?id=<%#DataBinder.Eval(Container.DataItem,"assessment_id") %>','_blank','height=400px,width=600px,top=120,left=450')">Comments</a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:HyperLinkField DataNavigateUrlFields="assessment_id" DataNavigateUrlFormatString="ViewAllGoalStatus.aspx?id_5={0}" Text="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-mini btn-info" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkSubmit" runat="server" CommandName="Edit" CssClass="btn btn-mini btn-info" Text="Submit"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                        </asp:GridView>


                                    </div>
                                    <div class="clearfix"></div>
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




