<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEmployeelistByManager.aspx.cs" Inherits="appraisal_ViewEmployeelistByManager" %>

<!DOCTYPE html>

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

    <script src="../js/html5-trunk.js"></script>
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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>View Employee Assessment Form</h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="View"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div runat="server" id="empsearch">
                                    <table width="100%" class="table table-condensed table-striped  table-bordered">

                                        <tr>
                                            <td class="frm-lft-clr123 " style="text-align: center;" width="12%">EmpCode</td>
                                            <td class="frm-rght-clr123  " width="14%">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <a href="JavaScript:newPopup1('PickEmployee.aspx?empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                            </td>

                                            <%-- <td class="frm-lft-clr123  " style="width: 8%">Grade</td>
                                            <td class="frm-rght-clr123  " width="12%">
                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound">
                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                            </td>--%>
                                            <td class="frm-lft-clr123  " style="text-align: center;" width="10%">Department</td>
                                            <td class="frm-rght-clr123  " width="16%">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                            </td>
                                            <%--SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"--%>
                                            <td class="frm-lft-clr123  " style="width: 8%">

                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>


                                <div runat="server" id="empdetails" visible="false">
                                    <table width="100%" class="table table-condensed table-striped  table-bordered ">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Employee Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">EmpCode</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblempcode" runat="server"></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Employee Name</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblempname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Designation</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lbldesignation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Department</td>
                                                        <td class="frm-rght-clr123 ">
                                                            <asp:Label ID="lbldept" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Role</td>
                                                        <td class="frm-rght-clr123  ">
                                                            <asp:Label ID="lblrole" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Review Period</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblReview" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Manager</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblmanager" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  border-bottom">Business Head</td>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="lblbuh" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 36px" runat="server" visible="false">
                                                        <td class="frm-lft-clr123">Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Location</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                       <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Rating System</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 25%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">1</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="Label7" runat="server" Text="Unsatisfactory (E-)"></asp:Label>
                                                        </td>


                                                    </tr>
                                                                                                    
                                                </table>
                                            </td>
                                             <td style="width: 25%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">2</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="Label8" runat="server" Text="Learning (E)"></asp:Label>
                                                        </td>


                                                    </tr>
                                                                                                    
                                                </table>
                                            </td>
                                             <td style="width: 25%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">3</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="Label9" runat="server" Text="Successful (E+)"></asp:Label>
                                                        </td>


                                                    </tr>
                                                                                                    
                                                </table>
                                            </td>

                                            <td style="width: 25%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">4</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="Label12" runat="server" Text="Exeptional (X)"></asp:Label>
                                                        </td>
                                                    </tr>
                                                   
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                    <table style="width: 100%;" runat="server" visible="false">
                                        <tr>
                                            <td class="txt01" style="height: 40px"><strong>Rating System</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridratings" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    DataKeyNames="rating_id" BorderWidth="0px" CellPadding="4" AllowPaging="True"
                                                    CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Rating">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "rating")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>


                                    <table style="width: 100%;" runat="server" visible="false">
                                        <tr>
                                            <td class="txt01" style="height: 40px"><strong>Smart Goals</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <%-- <div style="width: 75%; overflow-x: scroll">--%>
                                                <asp:GridView ID="gvGoals" runat="server" Width="99%" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" EnableModelValidation="True" ShowFooter="true"
                                                    EmptyDataText="No Data Found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Title">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("title") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Weightage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Goal Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelempgoalcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Goal Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelmnggoalcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Ratings">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemprating" runat="Server" Text='<%# Eval("emprating") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Average Rating :</b>
                                                                <asp:Label ID="lblGoalsAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Emp Rating Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempcomments" runat="Server" Text='<%# Eval("empcomments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Rating">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("mgrrating")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Average Rating :</b><asp:Label ID="lblmgrAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Rating Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="Server" Text='<%#Eval("mgrcomments")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="15%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <%--  </div>--%>
                                            </td>
                                        </tr>
                                    </table>

                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="Table2" runat="server">
                                        <tr>
                                            <td>

                                                <div style="width: 350px;">
                                                    <table>
                                                        <tr>
                                                            <td style="width: 350px;">
                                                                <b>Evaluation Cylce:</b>
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="Dropappcycle_id" runat="server"
                                                                    CssClass="span11" DataSourceID="SqlDataSource12" DataTextField="cycleid" AutoPostBack="true" DataValueField="appcycle_id" OnDataBound="Dropappcycle_id_DataBound" OnSelectedIndexChanged="Dropappcycle_id_SelectedIndexChanged" Width="200px">
                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select  from_month +' '+ from_year +  ' - '  + to_month +' '+ to_year as cycleid ,appcycle_id as appcycle_id from tbl_appraisal_cycle"></asp:SqlDataSource>

                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>

                                            </td>
                                        </tr>

                                        <tr id="trgoal1" visible="false" runat="server">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="Table1" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-bottom: 1px solid #ddd"><b>Cycle 1 : </b>
                                                        </td>
                                                        <td style="border-bottom: 1px solid #ddd"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #ddd">Goal  cycle 1 Initiated Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="lblcyl1intdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="Label3" runat="server" Text="Employee OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="lblgoal1empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="Label5" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="Label6" runat="server" Text="Business Head OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #ddd">
                                                            <asp:Label ID="lblbhcmntcycle1" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal Freezed Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdate" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                        <tr visible="false" runat="server">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="tblComments" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-right: 1px solid #e0e0e0; width: 20%;"><b>Cycle 2 : </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal  Cycle 2 Initiated Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgol2intdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label2" runat="server" Text="Employee OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lbempcmtscyle2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="lblcmts" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="txtmgrCommentscycle2" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label4" runat="server" Text="Business Head OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblbhcmntcycle2" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <%-- <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal Freezed Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdate" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal Freezed Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdatecycle2" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                         </table>
                                  
                                                   <div class="row-fluid" id="Div1" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Rating Comments
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="Div2" class="example_alt_pagination">
                                    <asp:GridView ID="GridView1" runat="server" CellSpacing="0"
                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" OnPreRender="gveligible_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.NO">

                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval ("appcycle_id") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname1" runat="server" Text='<%# Eval ("additional_cmnt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Line Manager Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname2" runat="server" Text='<%# Eval ("LM_appraiser_cmnt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Business Head Comments">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname3" runat="server" Text='<%# Eval ("BH_appraiser_cmnt") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode,appcycle_id" DataNavigateUrlFormatString="~/appraisal/LineMangerRatingView.aspx?empcode={0}&back=0&appcycle_id={1}"
                                                Text="&lt;img src='../images/view.png' /&gt;">
                                              
                                            </asp:HyperLinkField>

                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

 

                                    <table id="trTraining1" runat="server" style="width: 100%; display: none" visible="false" class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td class="txt01" style="height: 40px">Training Requirement
                                            </td>
                                        </tr>
                                        <tr id="trTraining2" runat="server">
                                            <td>
                                                <asp:Label ID="txttraining" runat="Server" Width="550px" Height="60px" CssClass="frm-rght-clr123 border-bottom"></asp:Label>

                                            </td>
                                        </tr>

                                        <tr id="troverall" runat="server">
                                            <td>
                                                <br />
                                                <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%; border-bottom: 1px #ddd solid;">Rating Initiated Date
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%; border-right: 1px #ddd solid; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="lblratintdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Smart Goals
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 15%; display: none;">
                                                            <asp:Label ID="GoalAvgRating" runat="server"></asp:Label>
                                                        </td>

                                                        <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Competencies
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%; display: none;">
                                                            <asp:Label ID="CompAvgRating" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr id="troverall1" runat="server">
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 15%; border-top: none;">Employee Overall Rating
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 15%; border-top: none">
                                                            <asp:Label ID="lblOverallRating" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 20%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;">Employee Overall Comments
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 40%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="txtOverallComments" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 10%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;" id="tdcolor1" runat="server">Performance and Behavior
                                                        </td>
                                                    </tr>
                                                    <tr id="troverall2" runat="server">
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 15%;">Manager  Overall Rating
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 15%;">
                                                            <asp:Label ID="lblMgrOverallRating" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 20%; border-bottom: 1px #ddd solid;">Manager  Overall Comments
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 40%; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="txtMgrOverallComments" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 10%; border-bottom: 1px #ddd solid;" id="tdcolor2" runat="server">
                                                            <asp:Label ID="lblBehavior" runat="server" Width="80px" Height="40px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%;">Cycle Closed Date
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 15%; border: 1px solid #e0e0e0;">
                                                            <asp:Label ID="cycleclosedate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="tabpreinc" runat="server" visible="false">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Previous Increment Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">DOJ</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lbldoj" runat="server"></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Designation(Current)</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lbldes" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Grade(Current)</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblpregrade" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Previous CTC/PA </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblprectc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Previous Year Hike(%) </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblprehike" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Previous Bonus</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblprebonus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="tabcurinc" runat="server" visible="false">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Current Increment Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">Revised Location</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblrevloc" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Department</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdept" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Designation</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdes" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Grade</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevgrade" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevcostcenter" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Hike(%) </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblcurhike" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Increased Amount</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblincramount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current CTC/PA</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurctc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current Bonus</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurbonus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised W.E.F</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:HiddenField ID="hdinccycle" runat="server" Value="0" />
                                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Back" OnClick="btnBack_Click" />
                                    </div>
                                </div>
                                <div class="clearfix"></div>

                            </div>

                        </div>
                    </div>
                </div>
                <div class="row-fluid" id="emplist" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee List
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gveligible" runat="server" CellSpacing="0"
                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" OnPreRender="gveligible_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.NO">

                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/ViewEmployeelistByManager.aspx?empcode={0}"
                                                Text="&lt;img src='../images/view.png' /&gt;">
                                                
                                            </asp:HyperLinkField>

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

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gveligible').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
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
