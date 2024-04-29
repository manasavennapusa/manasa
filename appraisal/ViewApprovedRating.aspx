<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewApprovedRating.aspx.cs" Inherits="appraisal_ViewApprovedRating" %>

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
                        <h2>View Rating & Comments</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="divajax">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <img src="../images/loading.gif" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="View Rating & Comments"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">




                                        <div runat="server" id="empsearch">

                                            <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                <tr>
                                                    <td class="frm-lft-clr123  " width="12%">EmpName/EmpCode</td>
                                                    <td class="frm-rght-clr123  " width="14%">
                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                    </td>

                                                    <td class="frm-lft-clr123  " style="width: 8%">Grade</td>
                                                    <td class="frm-rght-clr123  " width="12%">
                                                        <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                            DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound">
                                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                                    </td>
                                                    <td class="frm-lft-clr123  " width="10%">Department</td>
                                                    <td class="frm-rght-clr123  " width="16%">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                                        DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound">
                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="  SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                    </td>
                                                    <td class="frm-lft-clr123  " style="width: 10%">
                                                        <%--SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name --%>
                                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                                    </td>
                                                </tr>
                                            </table>


                                        </div>
                                        <div runat="server" id="empdetails" visible="false">

                                            <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">
                                                <tr>
                                                    <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Employee Details</strong> </td>
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
                                                            <tr style="height: 40px">
                                                                <td class="frm-lft-clr123  "></td>
                                                                <td class="frm-rght-clr123  "></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                            <table style="width: 100%;">
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

                                            <table width="100%">
                                                <tr>
                                                    <td class="txt01" style="height: 40px"><strong>Smart Goals Rating</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px" ShowFooter="true"
                                                            CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                            DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowEditing="gvGoals_RowEditing" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating"
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

                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="30%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Weightage">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
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
                                                                <asp:TemplateField HeaderText="Emp Comments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempcomments" runat="Server" Text='<%# Eval("empcomments") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Manager Rating">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("mgrrating")%>'></asp:Label>

                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtmanagerating" runat="server" Text='<%#Eval("mgrrating")%>' MaxLength="1" Width="50px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmanagerating" ErrorMessage="Enter rating"
                                                                            Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                                        <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtmanagerating"
                                                                            ValidationGroup="v" runat="server" MinimumValue="1" MaximumValue="5" ToolTip="Enter only 1-5" Type="Integer"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>Average Rating :</b>
                                                                        <asp:Label ID="lblmgrAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Manager Comments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcomments" runat="Server" Text='<%#Eval("mgrcomments")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtmanagercments" TextMode="MultiLine" runat="server" Text='<%#Eval("mgrcomments")%>' MaxLength="8000"></asp:TextBox>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                            ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtmanagercments"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                        </asp:RegularExpressionValidator>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="15%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderStyle-Width="10%">

                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" ValidationGroup="v" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />

                                                                        <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                                    </EditItemTemplate>

                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')" CssClass="link05" Text="Edit" ToolTip="Edit" />

                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td class="txt01" style="height: 40px">Average Rating of Smart Goals :
                       
                            <asp:Label ID="lblgoalrating" runat="Server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>


                                            <table style="width: 100%; border: 0">
                                                <tr>
                                                    <td class="txt01" style="height: 40px"><strong>Training Requirement</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="txttraining" runat="Server"></asp:Label>


                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td style="height: 10px"></td>
                                                </tr>
                                                <tr id="troverall" runat="server">
                                                    <td>
                                                        <br />
                                                        <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Smart Goals
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 15%; display: none;">
                                                                    <asp:Label ID="lblAvgRatingGoals" runat="server"></asp:Label>
                                                                </td>

                                                                <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Competencies
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 15%; display: none;">
                                                                    <asp:Label ID="lblAvgRatingComp" runat="server"></asp:Label>
                                                                </td>

                                                            </tr>
                                                            <tr id="troverall1" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 15%; border-top: none">Employee Overall Rating
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 15%; border-top: none">
                                                                    <asp:Label ID="lblOverallRating" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123 " style="width: 20%; border-top: none">Employee Overall Comments
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 40%; border-top: none">
                                                                    <asp:Label ID="txtOverallComments" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 10%; border-top: none" id="tdcolor1" runat="server">Performance and Behavior
                                                                </td>
                                                            </tr>
                                                            <tr id="troverall2" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 15%;">Manager Overall Rating
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 15%;">
                                                                    <asp:Label ID="lblMgrOverallRating" runat="server"></asp:Label>
                                                                </td>
                                                                <td class="frm-lft-clr123 " style="width: 20%;">Manager Overall Comments
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 40%;">
                                                                    <asp:Label ID="txtMgrOverallComments" runat="server"></asp:Label>

                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 10%" id="tdcolor2" runat="server">
                                                                    <asp:Label ID="lblBehavior" runat="server" Width="80px" Height="40px"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="text-align: right">
                                                        <div class="form-actions no-margin">
                                                            <asp:Button ID="btn_AllowMgremmts" runat="server" CssClass="btn btn-primary" Text="Notify Rating" OnClick="btn_AllowMgremmts_Click" Visible="false" />
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" ValidationGroup="v" Text="Save" OnClick="btnSubmit_Click" Visible="false" />
                                                            <asp:Button ID="btnClose" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Back" OnClick="btnClose_Click" />&nbsp;&nbsp;
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>

                                        </div>

                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                        BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !" OnPageIndexChanging="gveligible_PageIndexChanging"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.NO">

                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("name") %>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/ViewApprovedRating.aspx?empcode={0}"
                                                Text="View">
                                                <ControlStyle CssClass="link05" Width="6%" />
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
                $('#Grid_Emp').dataTable({
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
