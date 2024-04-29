<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="markattendance.aspx.cs" Inherits="training_markattendance" %>

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

      <style type="text/css">
        .dataTables_scrollBody
        {
            margin-top: -11px;
        }
    </style>

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
                                <h2>Mark Attendance	</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                         <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                         <div class="title">
                                            <span class="fs1" aria-hidden="true" ></span>Search 
                                        </div>
                                        </div>
                          <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">From Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_sdate"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip=" Please Select From Date"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip=" Please Select To Date"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txt_edate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                   
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Search" OnClick="Button1_Click" ValidationGroup="v" />
                                         <%--OnClientClick="return ValidateData();"--%>&nbsp;&nbsp;
                                     
                                    </div>
                                </fieldset>
                            </div>
                        
                        <%-- <table class="table table-condensed table-striped  table-bordered pull-left">--%>
                                      <div class="widget-body">

                                           <div class="control-group">
                                        <label class="control-label"> Date<span class=""></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtdatepicker" 
                                                    runat="server"
                                                     class="span3"></asp:TextBox>
                                           <asp:Image ID="Image3" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                    <cc1:CalendarExtender
                                                ID="CalendarExtender4" runat="server" PopupButtonID="Image3" TargetControlID="txtdatepicker">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                           
                                          
                                    </div>
                                    </div>
                               </div>
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
                                                     <asp:TemplateField HeaderText="Id" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lid" runat="server" Text='<%# Bind ("id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

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

                                                    <%--<asp:TemplateField HeaderText="Training Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind ("status") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

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

                                                    <asp:TemplateField HeaderText="Select">
                                                        <HeaderTemplate>
                                                            Select All 
                                                                    <asp:CheckBox ID="gridmarkatt" AutoPostBack="true" runat="server" OnCheckedChanged="gridmarkatt_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSelect" runat="server" />
                                                        </ItemTemplate>

                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <%-- <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="emp_fname" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                            <asp:Parameter Name="status" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>--%>
                                            <div class="clearfix"></div>
                                        </div>

                                    </div>
                                     <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btmDisplay_Click" />
                        </div>
                                </div>
                            </div>
                        </div>
                   <%-- </div>
                    </div>
                        </div>--%>
                       <%-- <div class="form-actions no-margin">
                            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-info pull-right" OnClick="btmDisplay_Click" />
                        </div>--%>

                    <span id="message" runat="server"></span>
                    <%--  <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code, tbl_intranet_branch_detail.esstt_date, tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1 + ', '  + tbl_intranet_branch_detail.city + ', '+ tbl_intranet_branch_detail.state+ ', ' + tbl_intranet_branch_detail.country + ' ' + tbl_intranet_branch_detail.zipcode as address FROM tbl_intranet_branch_detail INNER JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid"
                            ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                            DeleteCommand="DELETE FROM [tbl_intranet_branch_detail] WHERE [branch_id] = @branch_id"></asp:SqlDataSource>--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
           <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>
       
        <script src="../js/tiny-scrollbar.js"></script>

  
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gridmark').dataTable({
                    //bFilter: false,
                    //bInfo: false,
                    bPaginate: false,
                    sScrollY: "300px",
                    sScrollCollapse: true
                });
            });
            
           </script>
     <%--   <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gridmark').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>--%>
          <script>
              (function (i, s, o, g, r, a, m) {
                  i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                      (i[r].q = i[r].q || []).push(arguments)
                  }, i[r].l = 1 * new Date(); a = s.createElement(o),
                  m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
              })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

              ga('create', 'UA-41161221-1', 'srinu.html');
              ga('send', 'pageview');

        </script>

    </form>

</body>
</html>
