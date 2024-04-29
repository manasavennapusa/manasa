<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReviewGoalsByBUH.aspx.cs" Inherits="appraisal_ReviewGoalsByBUH" %>


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

                <div class="row-fluid">
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

                                <%--<div runat="server" id="empsearch">
                                    <table width="100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="frm-lft-clr123  border-bottom" width="12%">EmpName/EmpCode</td>
                                            <td class="frm-rght-clr123  border-bottom" width="17%">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="172px" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                            </td>

                                           <%-- <td class="frm-lft-clr123  border-bottom" style="border-left: none; width: 11%">Grade</td>
                                            <td class="frm-rght-clr123  border-bottom" width="16%">
                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound" Width="172px">
                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                            </td>--%
                                            <td class="frm-lft-clr123  border-bottom" style="border-left: none;" width="11%">Department</td>
                                            <td class="frm-rght-clr123  border-bottom" width="12%">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="blue1" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound" Width="172px">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                            </td>
                                            <td class="frm-lft-clr123  border-bottom" style="border-left: none; width: 10%">
                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>--%>

                                 <div runat="server" id="empsearch">
                                    <table width="100%" class="table table-condensed table-striped  table-bordered">

                                        <tr>
                                            <td class="frm-lft-clr123" style="text-align: center;" width="12%">EmpCode</td>
                                            <td class="frm-rght-clr123  " width="14%">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                            </td>

                                           <%-- <td class="frm-lft-clr123  " style="width: 8%">Grade</td>
                                            <td class="frm-rght-clr123  " width="12%">
                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound">
                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                            </td>--%>
                                            <td class="frm-lft-clr123 " style="text-align: center;" width="10%">Department</td>
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
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="">Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="">Location</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">
                                        <tr>
                                            <td valign="middle" class="txt02" style="height: 24px">&nbsp;<strong>Goals</strong>  </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowEditing="gvGoals_RowEditing"
                                                    OnRowDataBound="gvGoals_RowDataBound" ShowFooter="True" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating"
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
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txttitle" runat="Server" Text='<%# Eval("title") %>' TextMode="MultiLine" palceholder="Max. 200 chars."></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtdesc" runat="Server" Text='<%# Eval("Description") %>' TextMode="MultiLine" MaxLength="8000" palceholder="Max. 8000 chars."></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Total Weightage :</b>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="25%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Weightage(%)">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'> </asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtweightage" onkeypress="return IsNumericDot(event)" runat="Server" Text='<%# Eval("weightage") %>' Width="100" palceholder="Max. 5 chars." MaxLength="5" CssClass="blue1"></asp:TextBox>
                                                                <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtweightage"
                                                                    ValidationGroup="p" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                            </EditItemTemplate>
                                                            <FooterTemplate>
                                                                <asp:Label ID="lblTotalWeightage" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="25%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmngcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txtmngcomm" runat="Server" Text='<%# Eval("mng_comments") %>' TextMode="MultiLine" MaxLength="8000" palceholder="Max. 8000 chars."></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <HeaderStyle Width="25%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Edit">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"
                                                                    CssClass="btn btn-primary" Text="Edit" ToolTip="Edit" />
                                                                <%--<asp:Label ID="lbledit" CssClass="link05" runat="Server" Text="Not Editable" Visible='<%# Eval("IsEditable").ToString()=="E"?false:true %>'></asp:Label>--%>
                                                            </ItemTemplate>
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="true"
                                                                    CommandName="Update" CssClass="btn btn-primary" Text="Update" ToolTip="Update" ValidationGroup="p" />
                                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                                    CssClass="btn btn-primary" Text="Cancel" ToolTip="Cancel" />
                                                            </EditItemTemplate>
                                                            <HeaderStyle Width="5%" />
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
                                                <table style="width: 100%;">
                                                    <tr>
                                                        <td class=" frm-lft-clr123 border-bottom" width="25%">Title<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="35%">Description<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 border-bottom" width="20%">Weightage(%)<span class="star"></span>
                                                        </td>
                                                        <%-- <td class=" frm-lft-clr123 border-bottom" width="20%">Comments<span class="star"></span>
                                                        </td>--%>
                                                        <td class=" frm-lft-clr123 border-bottom" width="20%"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtTitle" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" placeholder="Max 200 chars." MaxLength="200"></asp:TextBox>
                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTitle"
                                                        ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Title"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtDesc" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtDesc"
                                                                ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9;\/\.\-\,\(\)\%\&\?\!\:\s]+$" ToolTip="Enter only alphanumeric and(!.,/(): space ? -) "
                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Description"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtWeightage" runat="server" CssClass="blue1" Width="120px" MaxLength="5" placeholder="Max 5 chars."></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>

                                                        </td>
                                                        <td style="width: 100px; display: none" class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtgoalcomm" runat="server" CssClass="blue1" Width="120px" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgoalcomm"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="frm-rght-clr12345">

                                                            <input type="button" id="btnSaveGoals" runat="server" onserverclick="btnSaveGoals_Click" value="Save" class="btn btn-primary" />
                                                            <%--                                                            <asp:Button ID="btnSaveGoals" runat="server" Text="Save" OnClick="btnSaveGoals_Click"
                                                                CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>--%>
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                CssClass="btn btn-primary" ToolTip="Click here to Cancel"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                        <tr>
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
                                                            <asp:Label ID="Label5" runat="server" Text="Overall Manager Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="tbl_gc2" runat="server">
                                                    <tr id="tr_gc2_heading" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-right: 1px solid #e0e0e0"><b>Cycle 2 : Mid Year Assessment</b>
                                                        </td>
                                                    </tr>

                                                    <tr id="tr_gc2_employeecomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label4" runat="server" Text="Employee Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal2empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="tr_gc2_managercomments" runat="server">
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label7" runat="server" Text="Manager Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal2mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>


                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered" id="tbl_overallcomments" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="lblcmtsText" runat="server" Text="Manager Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:TextBox ID="txtmgrComments" runat="server"  MaxLength="8000" placeholder="Max 8000 chars." CssClass="span11" TextMode="MultiLine" Style="width: 100%"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txtmgrComments" ErrorMessage='<img src="../images/error1.gif" alt="" /> <b style="color:red;">Please Fill</b>' ValidationGroup="v" />
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtmgrComments"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                            </asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            <div class="form-actions no-margin" id="btns" runat="server" visible="false">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="btn btn-success" ValidationGroup="v" />
                                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary" CausesValidation="false" />
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
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("name") %>'></asp:Label></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/ReviewGoalsByBUH.aspx?empcode={0}"
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

