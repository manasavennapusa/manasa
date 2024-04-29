<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAppraisal.aspx.cs" Inherits="appraisal_EditAppraisal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
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
    <script src="js/validation.js"></script>
    <script type="text/javascript">
        function disableBtn(btnID, newText) {

            var btn = document.getElementById(btnID);
            setTimeout("setImage('" + btnID + "')", 60000);
            btn.disabled = true;
            btn.value = newText;
        }

        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(12501270608.gif)';
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
                        <h2>Edit / Add Employee Goals</h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="Edit / Add Employee Goals"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                    <tr>
                                        <td class="frm-lft-clr123  " width="14%">Emp Name / Empcode</td>
                                        <td class="frm-rght-clr123  " width="14%">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                        </td>
                                        <td class="frm-lft-clr123  " style="display: none" width="12%">Designation</td>
                                        <td class="frm-rght-clr123 " style="display: none" width="15%">
                                            <asp:DropDownList ID="dd_designation" runat="server"
                                                CssClass="span11" DataSourceID="SqlDataSource1" DataTextField="designationname" DataValueField="id" Width="160px">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                        </td>
                                        <td class="frm-lft-clr123  " style="text-align: center;" width="10%">Department</td>
                                        <td class="frm-rght-clr123  " width="14%">&nbsp;<asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                            DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dpt_DataBound">
                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                        </td>

                                        <td class="frm-lft-clr123  " style="text-align: center;" width="8%">Grade</td>
                                        <td class="frm-rght-clr123  " width="12%">
                                            <asp:DropDownList ID="dd_grade" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                DataTextField="gradename" DataValueField="id" OnDataBound="dd_grade_DataBound">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                        </td>
                                        <td class="frm-rght-clr123  " width="10%" colspan="3" style="" align="center">

                                            <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                        </td>
                                    </tr>
                                </table>

                                <div>
                                    <div>
                                        <div class="row-fluid">
                                            <h5><strong>Employee List</strong>   </h5>
                                        </div>
                                        <div class="row-fluid">
                                            <div class="span12">
                                                <div class="widget-body">
                                                    <div id="dt_example" class="example_alt_pagination">
                                                        <asp:GridView ID="gveligible" runat="server" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                            CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="gveligible_PreRender"
                                                            OnRowDeleting="gveligible_RowDeleting">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Employee Code">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Name">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Department">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("dept") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Date of Joining">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton runat="server" ID="view" Text="View Goals" CssClass="link05" CommandArgument='<%# Bind ("empcode") %>' OnCommand="view_Command"></asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div id="empgoals" style="text-align: left" visible="false" runat="server">
                                        <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">
                                            <tr>
                                                <td align="left" class="txt02" colspan="2" style="height: 20px">Employee Details</td>
                                            </tr>
                                            <tr>
                                                <td style="width: 50%; vertical-align: top">
                                                    <table width="100%">
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
                                                            <td class="frm-lft-clr123  border-bottom">Role</td>
                                                            <td class="frm-rght-clr123  border-bottom">
                                                                <asp:Label ID="lblrole" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td style="width: 50%; vertical-align: top">
                                                    <table width="100%">
                                                        <tr style="height: 36px">
                                                            <td class="frm-lft-clr123 " style="border-left: none; width: 40%">Review Period</td>
                                                            <td class="frm-rght-clr123" width="60%">
                                                                <asp:Label ID="lblReview" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 36px">
                                                            <td class="frm-lft-clr123 " style="border-left: none;">Manager</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lblmanager" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 36px">
                                                            <td class="frm-lft-clr123" style="border-left: none;">Cost Center</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 36px">
                                                            <td class="frm-lft-clr123" style="border-left: none;">Location</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr style="height: 36px">
                                                            <td class="frm-lft-clr123  border-bottom" style="border-left: none;"></td>
                                                            <td class="frm-rght-clr123  border-bottom"></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%; border: 0" cellspacing="0" cellspacing="0">
                                            <tr>
                                                <td align="left" class="txt02" style="height: 20px">Smart Goals</td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:GridView ID="gvGoals" runat="server" Width="100%" AutoGenerateColumns="False"
                                                        DataKeyNames="asd_id" BorderWidth="0px" CellPadding="4"
                                                        OnPageIndexChanging="gvGoals_PageIndexChanging"
                                                        OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowEditing="gvGoals_RowEditing"
                                                        OnRowUpdating="gvGoals_RowUpdating" AllowPaging="True"
                                                        CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                        OnRowDataBound="gvGoals_RowDataBound" ShowFooter="true">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Sl.No" HeaderStyle-Width="5%">

                                                                <ItemTemplate>
                                                                    <%# Container.DataItemIndex +1 %>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Title" HeaderStyle-Width="25%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltitle" runat="server" Text='<%#Eval("title")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "title")%>'
                                                                        MaxLength="100" Width="90%" CssClass="blue1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Text='<%# DataBinder.Eval(Container.DataItem, "description")%>'
                                                                        MaxLength="8000" Width="90%" CssClass="blue1"></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <b>Total Weightage(%) :</b>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Weightage(%)" HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblweightage" runat="server" Text='<%#Eval("weightage")%>'></asp:Label>
                                                                </ItemTemplate>
                                                                <EditItemTemplate>
                                                                    <asp:TextBox ID="txtweightage" runat="server" onkeypress="return IsNumericDot(event)" Text='<%# DataBinder.Eval(Container.DataItem, "weightage")%>'
                                                                        MaxLength="5" CssClass="blue1"></asp:TextBox>
                                                                    <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtweightage"
                                                                        ValidationGroup="p" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                </EditItemTemplate>
                                                                <FooterTemplate>
                                                                    <asp:Label ID="lblTotalWeightage" runat="Server" Font-Bold="true"></asp:Label>
                                                                </FooterTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                <EditItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" ValidationGroup="p"
                                                                        CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                                    |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                                        CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr id="trbtns" runat="server">
                                                <td colspan="2" style="text-align: right; height: 50px; vertical-align: top">
                                                    <asp:Button ID="AddGoals" runat="server" Text="Add Goals" OnClick="AddGoals_Click" CssClass="btn btn-primary" />

                                                </td>
                                            </tr>
                                            <tr id="traddGoals" runat="server" visible="false">
                                                <td colspan="2">
                                                    <table style="width: 100%; border: 0">
                                                        <tr>
                                                            <td class=" frm-lft-clr123 border-bottom" width="25%">Title<span class="star"></span>
                                                            </td>
                                                            <td class=" frm-lft-clr123 border-bottom" width="35%">Description<span class="star"></span>
                                                            </td>
                                                            <td class=" frm-lft-clr123 border-bottom" width="20%">Weightage(%)<span class="star"></span>
                                                            </td>
                                                            <td class=" frm-lft-clr123 border-bottom" width="20%"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="txtTitle" runat="server" Width="85%" CssClass="blue1"></asp:TextBox>
                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTitle"
                                            ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Title"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="txtDesc" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000"></asp:TextBox>
                                                                <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtDesc"
                                            ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9_&quot;\/\.\-\,\(\)\'\&\?\!\:\s]+$" ToolTip="Enter only alphanumeric and(!.,/doulbe_quot()': space ? -) "
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Description"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="frm-rght-clr12345">
                                                                <asp:TextBox ID="txtWeightage" runat="server" CssClass="blue1" Width="120px" onkeypress="return IsNumericDot(event)" MaxLength="5"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                    ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                            </td>
                                                            <td class="frm-rght-clr12345" style="border-right: 1px solid #d9d9d9;">
                                                                <asp:Button ID="Button1" runat="server" Text="Save" OnClick="btnSaveGoals_Click"  OnClientClick="disableBtn(this.id, 'Submitting...')" UseSubmitBehavior="false"
                                                                    CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>
                                                                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                    CssClass="btn btn-primary" ToolTip="Click here to Cancel"></asp:Button>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
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
</body>
</html>

