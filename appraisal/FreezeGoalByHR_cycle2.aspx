<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreezeGoalByHR_cycle2.aspx.cs" Inherits="appraisal_FreezeGoalByHR_cycle2" %>

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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Approved Goals </h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="Appraisal Goals"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">


                                <div runat="server" id="empsearch">
                                    <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td class="frm-lft-clr123  " style="text-align: center;" width="12%">EmpCode</td>
                                            <td class="frm-rght-clr123  " width="14%">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                            </td>
                                            <td class="frm-lft-clr123  " style="text-align: center;" width="11%">Department</td>
                                            <td class="frm-rght-clr123  " width="12%">&nbsp;<asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dpt_DataBound">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand= "select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                            </td>
                                            <%--SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name--%>
                                           <%-- <td class="frm-lft-clr123  " style="width: 11%">Grade</td>
                                            <td class="frm-rght-clr123  " width="16%">
                                                <asp:DropDownList ID="dd_grade" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_grade_DataBound">
                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                            </td>--%>

                                            <td class="frm-lft-clr123  " style="width: 10%">

                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                            </td>
                                        </tr>
                                    </table>



                                </div>

                                <div runat="server" id="empdetails" visible="false">

                                    <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px">Employee Details</td>
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
                                                   <%-- <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Role</td>
                                                        <td class="frm-rght-clr123  ">
                                                            <asp:Label ID="lblrole" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
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
                                                    <%--<tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>--%>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Role</td>
                                                        <td class="frm-rght-clr123  ">
                                                            <asp:Label ID="lblrole" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Location</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr style="height: 40px">
                                                        <td class="frm-lft-clr123  "></td>
                                                        <td class="frm-rght-clr123  "></td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%">

                                        <tr runat="server" visible="false">
                                            <td valign="middle" class="txt02" style="height: 24px">&nbsp;Employee Goals </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td>
                                                <div class="widget-body">
                                                    <div id="ee" class="example_alt_pagination">
                                                        <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                            DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowEditing="gvGoals_RowEditing"
                                                            OnRowDataBound="gvGoals_RowDataBound" ShowFooter="false" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating"
                                                            EmptyDataText="No Data Found">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex +1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name of the Goal">
                                                                   <%-- <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("title") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txttitle" runat="Server" Text='<%# Eval("title") %>'></asp:TextBox>
                                                                    </EditItemTemplate>--%>
                                                                     <ItemTemplate>
                                                                        <asp:Label ID="lblrole" runat="Server" Text='<%# Eval("role") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtrole" runat="Server" Text='<%# Eval("role") %>'></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="15%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description" Visible="false">
                                                                    <%--<ItemTemplate>
                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtdesc" runat="Server" Width="400px" TextMode="MultiLine" Text='<%# Eval("Description") %>' MaxLength="8000"></asp:TextBox>
                                                                    </EditItemTemplate>--%>
                                                                    <FooterTemplate>
                                                                        <b>Total Weightage :</b>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Timeline and support required">

                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtweightage" runat="Server" Text='<%# Eval("weightage") %>' MaxLength="5" CssClass="span11"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtweightage"
                                                                            ValidationGroup="p" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                    </EditItemTemplate>
                                                                   <%-- <FooterTemplate>
                                                                        <asp:Label ID="lblTotalWeightage" runat="Server" Font-Bold="true"></asp:Label>
                                                                    </FooterTemplate>--%>
                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Employee Comments" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Manager Comments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmngcomm" runat="Server" Text='<%# Eval("line_manager_comment") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit" Visible="false">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"
                                                                            CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="true"
                                                                            CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" ValidationGroup="p" />
                                                                        <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                                            CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="15%" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
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
                                                <table style="width: 100%; border: 0">
                                                    <tr>
                                                        <td class=" frm-lft-clr123 " width="25%">Title<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 " width="35%">Description<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 " width="20%">Weightage(%)<span class="star"></span>
                                                        </td>
                                                        <td class=" frm-lft-clr123 " width="20%" style="border: 1px solid #d9d9d9;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtTitle" runat="server" Width="85%" CssClass="span11"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTitle"
                                            ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Title"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtDesc" runat="server" Width="85%" CssClass="span11" TextMode="MultiLine" MaxLength="8000"></asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtDesc"
                                            ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9_&quot;\/\.\-\,\(\)\'\&\?\!\:\s]+$" ToolTip="Enter only alphanumeric and(!.,/doulbe_quot()': space ? -) "
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Description"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="frm-rght-clr12345">
                                                            <asp:TextBox ID="txtWeightage" runat="server" CssClass="span11" Width="120px" MaxLength="5"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                        </td>
                                                        <td class="frm-rght-clr12345" style="border-right: 1px solid #d9d9d9;">
                                                            <asp:Button ID="btnSaveGoals" runat="server" Text="Save" OnClick="btnSaveGoals_Click"
                                                                CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>
                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                CssClass="btn btn-primary" ToolTip="Click here to Cancel"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                        </tr>
                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="Table2" runat="server">

                                        <tr id="trgoal1">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="Table1" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-bottom:1px solid #e0e0e0;"><b>Cycle 1 : </b>
                                                        </td>
                                                        <td style="border-bottom:1px solid #e0e0e0;"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px #ddd solid">Goal  cycle 1 Initiated Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="lblcyl1intdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="Label3" runat="server" Text="Employee OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="lblgoal1empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="Label5" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="Label1" runat="server" Text="Business Head OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px #ddd solid">
                                                            <asp:Label ID="lblgoalBHcomm" runat="server"></asp:Label>
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

                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="tblComments" runat="server">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-right: 1px solid #e0e0e0; width: 20%;"><b>Cycle 2 :</b>
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
                                                            <asp:Label ID="lbempcmts" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="lblcmtsText" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="txtmgrComments" runat="server"></asp:Label>

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

                                    <table id="trTraining1" runat="server" style="width: 100%;" visible="false" class="table table-condensed table-striped  table-bordered pull-left">

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

                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" visible="false">

                                        <tr id="tr1" runat="server">
                                            <td colspan="2" style="text-align: right; height: 50px; vertical-align: top">

                                                <asp:Button ID="btnFreeze" runat="server" Text="Freeze" OnClick="btnFreeze_Click" CssClass="btn btn-primary" />&nbsp;
                            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" id="empApprovedlist" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approved Employee List
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            <div class="widget-content">
                                                <div class="widget-body">
                                                    <div id="dt_example" class="example_alt_pagination">
                                                        <asp:GridView ID="gveligible" runat="server" DataKeyNames="empcode" AutoGenerateColumns="false" OnPreRender="gveligible_PreRender"
                                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
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

                                                                <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/FreezeGoalByHR_cycle2.aspx?empcode={0}"
                                                                    Text="&lt;img src='../images/view.png' /&gt;">
                                                          
                                                                </asp:HyperLinkField>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        <asp:CheckBox ID="chkall" Text="Select All" runat="server" AutoPostBack="true" OnCheckedChanged="chkall_CheckedChanged" />
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chk" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="tr2" runat="server">
                                        <td colspan="2" style="text-align: right; vertical-align: top">
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnFreezeSelected" runat="server" Text="Freeze" OnClick="btnFreezeSelected_Click" CssClass="btn btn-primary" />&nbsp;
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" id="empNotApprovedlist" runat="server" visible="false">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Not Approved Employee List
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <table width="100%">

                                    <tr>
                                        <td>
                                            <div class="widget-content">
                                                <asp:GridView ID="grd_notApprovedEmp" runat="server"
                                                    CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                    BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                    CssClass="table table-condensed table-striped  table-bordered pull-left" OnPageIndexChanging="grd_notApprovedEmp_PageIndexChanging">
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

                                                        <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/FreezeGoalsByHR.aspx?NA_empcode={0}"
                                                            Text="&lt;img src='../images/view.png' /&gt;">
                                                            
                                                        </asp:HyperLinkField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
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
