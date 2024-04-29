<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Pickrecruiter.aspx.cs" Inherits="recruitment_Pickrecruiter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>SmartDrive Labs</title>

    <script type="text/javascript" src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

     <meta name="author" content="SDLGlobe Technologies India Pvt. Ltd." />
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport" />
    <meta name="description" content="SDLGlobe Technologies India Pvt. Ltd." />
    <meta name="keywords" content="SDLGlobe Technologies India Pvt. Ltd." />
    <script type="text/javascript" src="../js/html5-trunk.js"></script>
     <script type="text/javascript" src="js/popup.js"></script>
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

    <script type="text/javascript" language="javascript">

        function returnempcode(val1, val2) {

            // hardcoded value used to minimize the code. 

            // ControlID can instead be passed as query string to the popup window

            window.opener.document.getElementById("txt_employee").value = val2;
            window.opener.document.getElementById("hidd_empcode").value = val1;
            window.opener.focus();
            window.close();

        }

    </script>

</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Pick Employee</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid" id="tbl_list" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="empgrid"
                                        runat="server"
                                        DataKeyNames="empcode"
                                        Width="100%"
                                        AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !"
                                        OnRowEditing="empgrid_RowEditing"
                                         class="table table-condensed table-striped table-hover table-bordered pull-left"
                                        OnPreRender="empgrid_PreRender">

                                        <Columns>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkselect" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">

                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">

                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">

                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>

                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

                <div class="form-actions no-margin" style="text-align:right">
                    <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnaddnew_Click" OnClientClick="return clearfilter();" />&nbsp;&nbsp;&nbsp;
                    <input type="button" value="Select All" class="btn btn-info" onclick="selectall()" />&nbsp;&nbsp;&nbsp;
                    <input type="button" value="De-Select All" class="btn btn-info" onclick="deselectall()" />
                </div>

            </div>
        </div>
    </form>

      <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#empgrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>

<script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#empgrid').dataTable({
                "sPaginationType": "full_numbers",
                "bPaginate": false,
                "sScrollY": "200px"
            });
        });
    </script>

    <script type="text/javascript">

        //function clearfilter()
        //{
        //    var oTable = $('#empgrid').dataTable();
        //    oTable.fnFilter('');

        //    return true;
        //}

        function selectall() {
            $("#empgrid").dataTable().$('tr', { "filter": "applied" }).each(function () {
                var chk = $(this).find("td:eq(0)");

                $(chk).find('input').attr('checked', true);
            });
        }

        function deselectall() {
            $("#empgrid").dataTable().$('tr', { "filter": "applied" }).each(function () {
                var chk = $(this).find("td:eq(0)");

                $(chk).find('input').attr('checked', false);
            });
        }
    </script>

</body>
</html>
