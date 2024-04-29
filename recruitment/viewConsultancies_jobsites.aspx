<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewConsultancies_jobsites.aspx.cs"
    Inherits="recruitment_viewConsultancies_jobsites" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">

    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <script type="text/javascript">

        function selectSkills(skills, ids) {
            window.opener.document.getElementById("txtjobconsult").value = skills;
            window.opener.document.getElementById("hfid").value = ids;
            window.opener.focus();
            window.close();
        }
    </script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>CONSULTANCIES/JOB SITES </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Consultancies / Job sites                                    
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grdjobsites"
                                            runat="server"
                                            AutoGenerateColumns="False"
                                            EmptyDataText="No Data Found"
                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                            OnPreRender="grdjobsites_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Code">
                                                    <ItemTemplate>
                                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                        <asp:CheckBox ID="chkselect" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblorg" runat="server" Text='<%# Eval("organizationname") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl3" runat="server" Text='<%# Eval("orgtype") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Address">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbla" runat="server" Text='<%# Eval("address") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact Person">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl4" runat="server" Text='<%# Eval("contactperson") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Contact No.">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl5" runat="server" Text='<%# Eval("contactno") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Email">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl6" runat="server" Text='<%# Eval("email") %>'>></asp:Label>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="URL">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbl7" runat="server" Text='<%# Eval("url") %>'>></asp:Label>
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

   <%-- <script type="text/javascript" src="../js/jquery.min.js"></script>

    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdjobsites').dataTable({
                "sPaginationType": "full_numbers",
                "bPaginate": false,
                "sScrollY": "200px"
            });
        });
    </script>

    <script type="text/javascript">
        function clearfilter() {
            var oTable = $('#grdjobsites').dataTable();
            oTable.fnFilter('');

            return true;
        }

        function selectall() {
            $("#grdjobsites").dataTable().$('tr', { "filter": "applied" }).each(function () {
                var chk = $(this).find("td:eq(0)");

                $(chk).find('input').attr('checked', true);
            });
        }

        function deselectall() {
            $("#grdjobsites").dataTable().$('tr', { "filter": "applied" }).each(function () {
                var chk = $(this).find("td:eq(0)");

                $(chk).find('input').attr('checked', false);
            });
        }
    </script>--%>
</body>
</html>
