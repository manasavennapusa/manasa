<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewGoalsByManager_1.aspx.cs" Inherits="appraisal_ReviewGoalsByManager_1" %>

<!DOCTYPE html>

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
    <script type="text/javascript" language="javascript">
        function RefeshWindow() {
            window.opener.location.reload();
        }
    </script>
     <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
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
                        <h2>Review Goals</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid" id="cycle2" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Review Goals"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div runat="server" id="empsearch">
                                    <table width="100%" class="table table-condensed table-striped  table-bordered">

                                        <tr>
                                            <td class="frm-lft-clr123" style="text-align: center;">EmpCode</td>
                                            <td class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span10" onkeypress="return isAlphaNumeric()"></asp:TextBox>

                                                <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Empcode" ValidationGroup="d"
                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>

                                            <%-- <td class="frm-lft-clr123  " style="width: 8%">Grade</td>
                                            <td class="frm-rght-clr123  " width="12%">
                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound">
                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                            </td>--%>
                                            <td class="frm-lft-clr123">Department</td>
                                            <td class="frm-rght-clr123">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_dept"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department" ValidationGroup="d" InitialValue="0"
                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                            <%--SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"--%>
                                            <td class="frm-lft-clr123">

                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" ValidationGroup="d" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>


                                <div runat="server" id="empdetails" visible="false">

                                    <table width="100%" cellpadding="0" cellspacing="0" class="table table-condensed table-striped  table-bordered">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Employee Details</strong> </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered ">

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
                                                <table width="100%" class="table table-condensed table-striped  table-bordered ">

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
                                                        <td class="frm-lft-clr123  border-bottom">Business Unit Head</td>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="lblbuh" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 36px;display:none">
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
                                    <table style="width: 100%" visible="true">
                                        <%--<tr id="tr_1" runat="server">
                                            <td class="txt02" style="height: 24px">&nbsp;<strong>Goals</strong>  </td>
                                        </tr>--%>
                                        <tr id="tr_goals" runat="server">
                                            <td>
                                                <div class="row-fluid">
                                                    <div class="span12">
                                                        <div class="widget no-margin">
                                                            <div class="widget-header">
                                                                <div class="title">
                                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Goals
                                                                </div>
                                                            </div>
                                                            <div class="widget-body">
                                                                <div id="dt_example_1" class="example_alt_pagination">

                                                                    <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        CellPadding="4" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                                        DataKeyNames="asd_id" Width="100%" OnRowEditing="gvGoals_RowEditing"
                                                                        OnRowDataBound="gvGoals_RowDataBound" ShowFooter="false" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating"
                                                                        EmptyDataText="No Data Found">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Sl.No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex +1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                             <asp:TemplateField HeaderText="Empcode" visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblempcode" runat="Server" Text='<%# Eval("empcode") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Asd ID" visible="false">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblasd_id" runat="Server" Text='<%# Eval("asd_id") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Name of the Goal">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblrole" runat="Server" Text='<%# Eval("role") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="text1" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("role") %>' MaxLength="2000"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Desired outcome/Impact">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_kca_kra" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                 <EditItemTemplate>
                                                                                    <asp:TextBox ID="text2" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("kca") %>' MaxLength="2000"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>

                                                                             <asp:TemplateField HeaderText="Milestone to check improvement">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lbl_kpi" runat="Server" Text='<%# Eval("kpi") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                  <EditItemTemplate>
                                                                                    <asp:TextBox ID="text3" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("kpi") %>' MaxLength="2000"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Timeline and support required">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:TextBox ID="text4" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("weightage") %>' MaxLength="2000"></asp:TextBox>
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>

                                                                            <asp:TemplateField HeaderText="Edit" Visible="true">
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CommandName="Edit"
                                                                                       Text="&lt;img src='../images/edit.png'/&gt;" />
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="true"
                                                                                        CommandName="Update" CssClass="btn btn-primary" Text="Update" ValidationGroup="p" />
                                                                                    <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                                                        CssClass="btn btn-primary" Text="Cancel" />
                                                                                </EditItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                                 <div class="clearfix"></div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="trbtns" runat="server" visible="false">
                                            <td colspan="2" style="text-align: right; height: 50px; vertical-align: top">
                                                <asp:Button ID="AddGoals" runat="server" Text="Add Goals" OnClick="AddGoals_Click" CssClass="btn btn-primary" />

                                            </td>
                                        </tr>
                                        <tr id="traddGoals" runat="server" visible="false">
                                            <td colspan="2">
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class=" frm-lft-clr123 border-bottom" width="25%">Title<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="35%">Description<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="20%">Weightage(%)<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="20%">Comments<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="20%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtTitle" runat="server" Width="65%" CssClass="blue1" TextMode="MultiLine" placeholder="Max 200 chars." MaxLength="200"></asp:TextBox>
                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTitle"
                                                        ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Title"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtDesc" runat="server" Width="65%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtDesc"
                                                                ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9;\/\.\-\,\(\)\%\&\?\!\:\s]+$" ToolTip="Enter only alphanumeric and(!.,/(): space ? -) "
                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Description"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtWeightage" runat="server" CssClass="blue1" onkeypress="return IsNumericDot(event)" Width="120px" MaxLength="5" placeholder="Max 5 chars."></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>

                                                        </td>
                                                        <td style="width: 100px" class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtgoalcomm" runat="server" CssClass="blue1" Width="150px" MaxLength="8000" TextMode="MultiLine" placeholder="Max 8000 chars."></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgoalcomm"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:Button ID="btnSaveGoals" runat="server" Text="Save" OnClick="btnSaveGoals_Click" OnClientClick="disableBtn(this.id, 'Submitting...')" UseSubmitBehavior="false"
                                                                CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                CssClass="btn btn-primary" ToolTip="Click here to Cancel"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                        <tr id="trgoal1" runat="server" visible="false">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered" id="tbl_gc1" runat="server">
                                                    <tr id="tr_gc1_heading" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-right: 1px solid #e0e0e0">
                                                            <b>Cycle 1 : Goal Setting</b>
                                                        </td>
                                                    </tr>

                                                    <tr id="tr_gc1_employeecomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label3" runat="server" Text="Overall Employee Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal1empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_gc1_managercomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <%--<asp:Label ID="Label5" runat="server" Text="Overall Manager Comments"></asp:Label>--%>
                                                            Line Manager Comment<span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tr_cycle2" runat="server" visible="false">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="tbl_gc2" runat="server">
                                                    <tr id="tr_gc2_heading" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-right: 1px solid #e0e0e0"><b>Cycle 2 : Mid Year Assessment</b>
                                                        </td>
                                                    </tr>

                                                    <tr id="tr_gc2_employeecomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label4" runat="server" Text="Overall Employee Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal2empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_gc2_managercomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label7" runat="server" Text="Overall Manager Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal2mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>


                                                </table>
                                            </td>
                                        </tr>
                                        <tr><td><br /></td></tr>
                                        <tr>
                                            <td>
                                                <table width="100%" class="table table-condensed table-striped  table-bordered" id="tbl_overallcomments" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom">
                                                            <asp:Label ID="lblcmtsText" runat="server" Text="Overall Manager's Comment"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 80%;">
                                                            <asp:TextBox ID="txtmgrComments" runat="server" MaxLength="8000" CssClass="span11" palceholder="Max. 8000 chars." TextMode="MultiLine"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txtmgrComments" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Comments" ValidationGroup="v" SetFocusOnError="true" />
                                                           <%-- <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txtmgrComments" ErrorMessage='<img src="../images/error1.gif" alt="" /> <b style="color:red;">Please Enter the Comments</b>' ValidationGroup="v" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtmgrComments"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                            </asp:RegularExpressionValidator>--%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="form-actions no-margin" id="btns" runat="server" visible="false" style="text-align: right">
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-info" CausesValidation="false" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_submit_LM_review" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btn_submit_LM_review_Click" ValidationGroup="v" />
                                &nbsp;&nbsp;
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
        <script type="text/javascript" src="../js/timepicker.js"></script>

        <script src="../js/jquery.min.js"></script>

        <script src="../js/jquery.dataTables.js"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gveligible').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gvGoals').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

