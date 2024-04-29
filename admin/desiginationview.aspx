<%@ Page Language="C#" AutoEventWireup="true" CodeFile="desiginationview.aspx.cs"
    Inherits="Admin_company_empview" Title="SmartDrive Labs Technologies India Pvt. Ltd. : Designation View" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />



</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2> Designation </h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <%--<asp:GridView ID="Grid_Emp" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="Grid_Emp_PreRender">
                                        <PagerSettings PageButtonCount="100"></PagerSettings>
                                        <Columns>
                                            <asp:TemplateField HeaderText="SI No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsno" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="10%" />
                                            </asp:TemplateField>

                                            <asp:BoundField DataField="designationname" HeaderText="Designation Name" SortExpression="designationname"></asp:BoundField>
                                            <asp:TemplateField HeaderText="Department Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldeptname" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="25%" />
                                            </asp:TemplateField>
                                          <%--  <asp:TemplateField HeaderText="WorkLoaction">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldeptname" runat="server" Text='<%# Eval("branch_name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle Width="25%" />
                                            </asp:TemplateField>--%
                                            <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True"
                                                SortExpression="description"></asp:BoundField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="editdesigination.aspx?desigination_id=<%#DataBinder.Eval(Container.DataItem, "id") %>"
                                                        target="_self" class="link05">Edit</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>--%>

                                      <asp:GridView ID="Grid_Emp" runat="server" OnRowDeleting="Grid_Emp_RowDeleting"
                                        DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                        OnPreRender="Grid_Emp_PreRender">

                                        <Columns>
                                            <%--<asp:BoundField DataField="departmentid" HeaderText="Dept. ID" ></asp:BoundField>--%>
                                            <asp:BoundField DataField="id" HeaderText="ID" ></asp:BoundField>
                                            <asp:BoundField DataField="designationname" HeaderText="Designation Name" ></asp:BoundField>
                                            <asp:BoundField DataField="department_name" HeaderText="Department Name"></asp:BoundField>

                                            <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Edit">
                                                <ItemTemplate>
                                                    
                                                    <a href="editdesigination.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>" target="_self" class="link05"><img src="images/edit.png" width="15" height="15" border="0"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
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

              <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="select tbl_intranet_designation.id,tbl_intranet_designation.departmentid,department_name,branch_name,tbl_internate_departmentdetails.branchid id,designationname,description FROM tbl_intranet_designation
 inner join dbo.tbl_internate_departmentdetails on dbo.tbl_internate_departmentdetails.departmentid=tbl_intranet_designation.departmentid 
inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid"
                    DeleteCommand="DELETE FROM [tbl_intranet_designation] WHERE [id] = @id" ProviderName="System.Data.SqlClient"
                    ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>--%>
            </div>
            <span id="message" runat="server"></span>
                      </ContentTemplate>
            </asp:UpdatePanel>
        </div>


      <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Emp').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>



       <%-- <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>--%>
    </form>

</body>
</html>
