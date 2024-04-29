<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproverHike.aspx.cs" Inherits="Appraisal_ApproverHike" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>


    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>

            <div class="dashboard-wrapper" style="margin-left: 0px;">

                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
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
                                            <%--<a data-toggle="modal" href="#myModal1" class="btn btn-primary pull-right">View Slab</a>--%>
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
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"emp_fname") %>'></asp:Label>
                                                                <%--<%# DataBinder.Eval(Container.DataItem,"emp_fname") %>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Yes">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblHike" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"ishike") %>'>
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddlHike" runat="server" Width="85" AutoPostBack="true" OnSelectedIndexChanged="ddlHike_SelectedIndexChanged">
                                                                    <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="OnHold" ItemStyle-Width="20px">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblOnHold" runat="server" Visible="false" Text='<%# DataBinder.Eval(Container.DataItem,"onhold") %>'>
                                                                </asp:Label>

                                                                <asp:DropDownList ID="ddlOnHold" runat="server" Width="70" AutoPostBack="true" OnSelectedIndexChanged="ddlOnHold_SelectedIndexChanged">
                                                                    <asp:ListItem Text="No" Value="2"></asp:ListItem>
                                                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="No (Reason for no to be filled)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtReason" runat="server" TextMode="MultiLine" Width="150px" Text='<%# DataBinder.Eval(Container.DataItem,"reasonforno") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Width="100px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Hike(%)">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtHike" runat="server" Width="30px"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                          <asp:TemplateField HeaderText="quater" Visible="false">
                                                            <ItemTemplate>
                                                                 <asp:Label ID="labelquert" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"quater") %>'></asp:Label>
                                                              
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField Visible="false">
                                                            <ItemTemplate>
                                                                <a href="#" class="btn btn-mini btn-info "
                                                                    onclick="window.open('ViewComments.aspx?id=<%#DataBinder.Eval(Container.DataItem,"assessment_id") %>','_blank','height=400px,width=600px,top=120,left=450')">Comments</a>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:HyperLinkField DataNavigateUrlFields="assessment_id" DataNavigateUrlFormatString="ViewAllGoalStatus.aspx?id_1={0}" Text="View" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" ControlStyle-CssClass="btn btn-mini btn-info " />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkSubmit" runat="server" CommandName="Edit" CssClass="btn btn-mini btn-info" Text="Submit"></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                    </Columns>
                                                </asp:GridView>

                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal fade" id="myModal1">
                                    <div class="modal-dialog">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                <h4 class="modal-title">Hike Table</h4>
                                            </div>
                                            <div class="modal-body">
                                                <iframe src="Hike_Slab.aspx" width="100%" frameborder="0" scrolling="No" height="270px"></iframe>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
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

   <%-- <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

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



