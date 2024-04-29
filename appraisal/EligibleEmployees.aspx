<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EligibleEmployees.aspx.cs" Inherits="appraisal_EligibleEmployees" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />
    <script src="js/popup1.js"></script>
    <%--<script type="text/javascript">
         function ValidateEmpcode() {
             var empcode = document.getElementById('<%=txt_employee.ClientID %>');
            if (empcode.value == "") {
                empcode.focus();
                alert("Please select empcode");
                return false;
            }

        }
        function isKey(keyCode) {
            return false;
        }
    </script>--%>
    <script src="../js/html5-trunk.js"></script>
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

    <style type="text/css">
        .dataTables_scrollBody {
            margin-top: -11px;
        }
    </style>

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>E-Evaluation Eligible Employees    </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Employee List"></asp:Label>
                            
                                        <asp:Label ID="Label1" style="margin-left:610px;"  runat="server" Text="Evaluation Cylce :"></asp:Label>
                                      
                                       
                                                    <asp:DropDownList ID="Dropappcycle_id" runat="server"
                                                        CssClass="span12" DataSourceID="SqlDataSource12" DataTextField="cycleid" AutoPostBack="true" DataValueField="appcycle_id" OnDataBound="Dropappcycle_id_DataBound" OnSelectedIndexChanged="Dropappcycle_id_SelectedIndexChanged" Width="200px">
                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="select  from_month +' '+ from_year +  ' - '  + to_month +' '+ to_year as cycleid ,appcycle_id as appcycle_id from tbl_appraisal_cycle"></asp:SqlDataSource>
                                            
                                     

                                </div>
                            </div>
                            <div class="widget-body">

                                <table width="100%">
                                    <tr>
                                        <td valign="top">
                                            <table width="100%">

                                                <tr>
                                                    <td valign="top">
                                                        <%--<div id="divempsearch" runat="server" class="gvclass">--%>
                                                        <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                            <tr>
                                                                <td class="frm-lft-clr123  " style="text-align: center;" width="10%">Empcode</td>
                                                                <td class="frm-rght-clr123  " width="14%">
                                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()" ReadOnly="true"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                </td>
                                                                <%-- <td class="frm-lft-clr123" width="14%">
                                                                     <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i></a>
                                                                 </td>--%>
                                                                <td class="frm-lft-clr123  " style="display: none" width="12%">Designation</td>
                                                                <td class="frm-rght-clr123 " style="display: none" width="15%">
                                                                    <asp:DropDownList ID="dd_designation" runat="server"
                                                                        CssClass="span11" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound" Width="160px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                                                </td>
                                                                <td class="frm-lft-clr123  " style="text-align: center;" width="10%">Department</td>
                                                                <td class="frm-rght-clr123  " width="14%">&nbsp;<asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dpt_DataBound">
                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                                                </td>
                                                                <%-- SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name--%>
                                                                <%-- <td class="frm-lft-clr123  " style="text-align: center;" width="8%">Grade</td>
                                                                <td class="frm-rght-clr123  " width="12%">
                                                                    <asp:DropDownList ID="dd_grade" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                                        DataTextField="gradename" DataValueField="id" OnDataBound="dd_grade_DataBound">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                                                </td>--%>
                                                                <td class="frm-rght-clr123  " width="10%" colspan="3" style="" align="center">

                                                                    <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <%-- </div>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="15" valign="top"></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%">
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 48%">
                                                        <div class="widget-body">
                                                            <div id="dt_example1" class="example_alt_pagination"  style="max-height:400px;overflow-y:scroll;">
                                                                <asp:GridView ID="empgrid" runat="server"
                                                                    DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                    CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="empgrid_PreRender">
                                                                    <%--OnPreRender="empgrid_PreRender"--%>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <%--<asp:TemplateField HeaderText="Reporting Manager">
                                                        
                                                                       <ItemTemplate>
                                                                       <asp:Label ID="l1" runat="server" Text='<%# Bind ("manager") %>'></asp:Label>
                                                                       </ItemTemplate>
                                                                       </asp:TemplateField>--%>
                                                                        <asp:TemplateField HeaderText="Department" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date of Joining" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <HeaderTemplate>
                                                                                Select All 
                                                                    <asp:CheckBox ID="empgrid_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="empgrid_chkSelectAll_CheckedChanged" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>

                                                                    </Columns>

                                                                </asp:GridView>
                                                            </div>

                                                        </div>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                                                        <SelectParameters>
                                                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="All" Name="status" Type="String" />
                                                                        </SelectParameters>
                                                                    </asp:SqlDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 4%" align="center">
                                                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                                                                    <ProgressTemplate>
                                                                        <div class="divajax">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../images/loading.gif" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>

                                                                <table>
                                                                    <tr>
                                                                        <td>--%>
                                                        <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td style="padding: 2px 2px 5px 2px">
                                                                    <asp:Button ID="btnselect" runat="server" Text=">" ToolTip="Add" CssClass="btn btn-success" Visible="false" OnClick="btnselect_Click" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="padding: 2px 2px 5px 2px">
                                                                    <asp:Button ID="btnreset" runat="server" Text="<" ToolTip="Remove" CssClass="btn btn-danger" Visible="false" OnClick="btnreset_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>

                                                        <%-- <asp:Button ID="btnselect" runat="server" Text=">" ToolTip="Add" CssClass="btn btn-success" Visible="false" OnClick="btnselect_Click" />
                                                        <asp:Button ID="btnreset" runat="server" Text="<" ToolTip="Remove" CssClass="btn btn-danger" Visible="false" OnClick="btnreset_Click" />--%>
                                                        <%--  </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                                    </td>
                                                    <td style="width: 48%">
                                                        <div class="widget-body">
                                                            <div id="dt_example" class="example_alt_pagination" style="max-height:400px;overflow-y:scroll;">
                                                                <asp:GridView ID="empgrid2" runat="server" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                                     CssClass="table table-condensed table-striped  table-bordered pull-left"  OnPreRender="empgrid2_PreRender" >
                                                                    <%--OnPreRender="empgrid2_PreRender"--%>
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblemp" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblname" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Department" HeaderStyle-Width="20%" ItemStyle-Width="20%">

                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldept" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Date of Joining" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldoj" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>

                                                                        <asp:TemplateField HeaderText="Select" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                                                            <HeaderTemplate>
                                                                                Select All 
                                                                    <asp:CheckBox ID="empgrid2_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="empgrid2_chkSelectAll_CheckedChanged" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top"></td>
                                    </tr>
                                    <tr>
                                        <td></td>

                                    </tr>

                                    <tr id="trbuttons" runat="server" visible="false">
                                        <td style="float: right">
                                            <%-- <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel2" DisplayAfter="1" runat="server">
                                                        <ProgressTemplate>
                                                            <div class="divajax">
                                                                <table width="100%">
                                                                    <tr>
                                                                        <td align="center" valign="top">
                                                                            <img src="../images/loading.gif" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </ProgressTemplate>
                                                    </asp:UpdateProgress>--%>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" Visible="false" />
                                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" Visible="false" />&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </td>
                                    </tr>

                                </table>



                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


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
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script src="../js/tiny-scrollbar.js"></script>

        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#empgrid2').dataTable({
                    //bFilter: false,
                    //bInfo: false,
                    bPaginate: false,
                    sScrollY: "300px",
                    sScrollCollapse: true
                });
            });

            //Data Tables
            $(document).ready(function () {
                $('#empgrid').dataTable({
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
                $('#empgrid2').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
            $(document).ready(function () {
                $('#empgrid').dataTable({
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
