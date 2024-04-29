<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewemployeTrainigDeatils.aspx.cs" Inherits="Training_viewemployeTrainigDeatils" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
         <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Training Report</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <%--                                    <div class="row-fluid">
                                        <div class="span12">
                                            <div class="widget no-margin">--%>
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View 
                                        </div>
                                          <div>
                                           <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info pull-right"  OnClick="btn_export_Click" Text="Export" />
                                    </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="gridmark"
                                                runat="server" DataKeyNames="empcode"
                                                AutoGenerateColumns="False"
                                                EmptyDataText="No such employee exists !"
                                                class="table table-condensed table-striped table-hover table-bordered pull-left"
                                                OnPreRender="gridmark_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                       <asp:TemplateField HeaderText="Module Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lmod" runat="server" Text='<%# Bind ("modulename") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Status">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="l4" runat="server" Text='<%# Bind ("attendenceStatus") %>'></asp:Label>--%>
                                                             <asp:Label ID="Label1" runat="server" Text='<%# Bind("attendenceStatus") %>' class="label label-success" Visible='<%#Eval("attendenceStatus").ToString()=="Present"?true:false%>'></asp:Label>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("attendenceStatus") %>' class="label label-important" Visible='<%#Eval("attendenceStatus").ToString()=="Absent"?true:false%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Branch">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l6" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="faculty">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lfac" runat="server" Text='<%# Bind ("Faculty") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%--  <asp:TemplateField HeaderText="TrainingID" Visible="false">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l7" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                     <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromdate" runat="server" Text='<%# Bind ("fromdate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltodate" runat="server" Text='<%# Bind ("todate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Training Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblto" runat="server" Text='<%# Bind ("Newdatepresent") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  <%--  <asp:TemplateField HeaderText="Select">
                                                        <HeaderTemplate>
                                                            Select All 
                                                                    <asp:CheckBox ID="gridmarkatt" AutoPostBack="true" runat="server" OnCheckedChanged="gridmarkatt_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                          
                                            <div class="clearfix"></div>
                                        </div>

                                    </div>
                               <%--      <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btmDisplay_Click" />
                        </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    </div>
                       

               

        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gridmark').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

    </form>

</body>
</html>
