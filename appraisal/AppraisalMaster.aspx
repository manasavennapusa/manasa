<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalMaster.aspx.cs" Inherits="appraisal_AppraisalMaster" %>

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
    <script src="js/validation.js"></script>

    <script type="text/javascript">
        function ValidateForm() {
            var designation = document.getElementById('<%=desig.ClientID %>');

             if (designation.value == "0") {
                 alert("Please Select Designation");
                 designation.focus();
                 return false;
             }
             return true;
         }
    </script>
    <style type="text/css">
    .auto-style1 {
        width: 32%;
    }

    .auto-style2 {
        width: 38%;
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
                        <h2>Assign Employee Goals </h2>
                    </div>
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Search"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <table class="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                    <tr>
                                        <td style="width: 10%; text-align: center; padding: 12px 8px 8px 8px"><b>Empcode</b></td>
                                        <td style="width: 20%; padding: 8px 8px 8px 8px">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span10"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Empcode" ValidationGroup="d"
                                                Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                        </td>

                                        <td style="width: 10%; text-align: center; padding: 12px 8px 8px 8px"><b>Department</b></td>
                                        <td style="width: 20%; padding: 8px 8px 8px 8px">
                                            <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span12" DataSourceID="SqlDataSourc4" AutoPostBack="false"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_dpt_DataBound" OnSelectedIndexChanged="dd_dpt_SelectedIndexChanged">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                        </td>
                                        <td style="width: 10%; text-align: center; padding: 12px 8px 8px 8px"><b>Designation</b></td>
                                        <td style="width: 20%; padding: 8px 8px 8px 8px">
                                            <asp:DropDownList ID="ddldesig" runat="server" OnDataBound="ddldesig_DataBound"
                                                CssClass="span12" DataSourceID="SqlDataSource2" DataTextField="designationname" DataValueField="id">
                                            </asp:DropDownList>
                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                        </td>
                                        <td style="width: 10%; padding: 8px 8px 8px 8px">
                                            <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" Text="Search" OnClick="btn_search_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <%--<div class="row-fluid">
                                    <h5><strong>Employee List</strong>   </h5>
                                </div>--%>
                                <table>
                                    <tr>
                                        <td style="height: 10px"></td>
                                    </tr>
                                </table>
                                <div class="row-fluid">
                                    <div class="span12">
                                        <div class="widget">
                                            <div class="widget-header" style="border-bottom: none;">
                                                <div class="title">
                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                    <asp:Label ID="Label24" runat="server" Text="Employee List"></asp:Label>
                                                </div>
                                            </div>

                                            <div class="widget-body">
                                                <div id="dt_example" class="example_alt_pagination">
                                                    <asp:GridView ID="gveligible" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                                        CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="gveligible_PreRender">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="20%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Department" HeaderStyle-Width="20%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("dept") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="10%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("designation") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Date of Joining" HeaderStyle-Width="20%">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderStyle-Width="10%">
                                                                <HeaderTemplate>
                                                                    Select All 
                                                    <asp:CheckBox ID="chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                        </div>
                                    </div>
                                </div>


                                <br />
                                <asp:UpdatePanel ID="updatepanel1" runat="server">
                                    <ContentTemplate>
                                        <table style="width: 100%">
                                            <tr>
                                                <td>
                                                    <div class="row-fluid" style="margin-top: 2%">
                                                        <div class="span12">
                                                            <div class="widget">
                                                                <div class="widget-header">
                                                                    <div>
                                                                        <table style="width: 100%; color: #4d4d4d; float: left; font-weight: 600; font-size: 14px;" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td style="width: 50%;">
                                                                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                                                                    <asp:Label ID="Label38" runat="server" Text="Create Goals"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 50%;">
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td style="width: 50%; text-align: right; padding: 2px 5px 2px 2px">Designation</td>
                                                                                            <td style="width: 50%; padding: 2px 2px 2px 5px">
                                                                                                <asp:DropDownList ID="desig" runat="server" OnDataBound="desig_DataBound1"
                                                                                                    CssClass="span11" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="desig_SelectedIndexChanged" DataTextField="designationname" AutoPostBack="true" DataValueField="id">
                                                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </div>

                                                                <div class="widget-body">
                                                                    <table style="width: 100%;">
                                                                        <tr>
                                                                            <td>
                                                                                <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">

                                                                                    <%--<tr>
                                                            <td class=" frm-lft-clr123 border-bottom" width="32%"><b>Role & Responsibilities</b><span class="star"></span>
                                                            </td>
                                                             <td class=" frm-lft-clr123 border-bottom" width="32%"><b>KRA</b><span class="star"></span>
                                                            </td>
                                                             <td class=" frm-lft-clr123 border-bottom" width="32%"><b>KPI</b><span class="star"></span>
                                                            </td>
                                                            <td class=" frm-lft-clr123 border-bottom" width="20%"><b>Weightage(%)</b><span class="star"></span></td>
                                                            <td class=" frm-lft-clr123 border-bottom" width="10%" style="border-right: 1px solid #d9d9d9;"></td>
                                                        </tr>--%>
                                                                                    <tr>
                                                                                        <td class=" frm-lft-clr123 border-bottom"><b>Name of the Goal</b><span class="star"></span>
                                                                                        </td>
                                                                                        <td class=" frm-lft-clr123 border-bottom"><b>Desired outcome/Impact</b><span class="star"></span>
                                                                                        </td>
                                                                                        <td class=" frm-lft-clr123 border-bottom"><b>Milestone to check improvement</b><span class="star"></span>
                                                                                        </td>
                                                                                        <td class=" frm-lft-clr123 border-bottom"><b>Timeline and support required.</b><span class="star"></span></td>
                                                                                        <td class=" frm-lft-clr123 border-bottom"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-rght-clr12345">
                                                                                            <asp:TextBox ID="textrole" runat="server" CssClass="span12" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="textrole"
                                                                    ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textrole"
                                                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Please Enter Name of the Goal"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                        </td>


                                                                                        <td class="frm-rght-clr12345">
                                                                                            <asp:TextBox ID="textkca" runat="server" CssClass="span12" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="textkca"
                                                                    ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9;\/\.\-\,\(\)\\&\?\!\:\s\%]+$" ToolTip="Enter only alphanumeric and(!.,/(): space ? - %) "
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="textkca"
                                                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Please Enter Desired outcome/Impact"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                        </td>


                                                                                        <td class="frm-rght-clr12345">
                                                                                            <asp:TextBox ID="textkpi" runat="server" CssClass="span12" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="textkpi"
                                                                    ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9;\/\.\-\,\(\)\\&\?\!\:\s\%]+$" ToolTip="Enter only alphanumeric and(!.,/(): space ? - %) "
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textkpi"
                                                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Please Enter Milestone to check improvement"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                        </td>


                                                                                        <td class="frm-rght-clr12345">
                                                                                            <asp:TextBox ID="txtWeightage" runat="server" CssClass="span12" MaxLength="8000" TextMode="MultiLine" placeholder="Max 8000 chars."></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Please Enter Timeline and support required"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            <%--<asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                    ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>--%>
                                                                                        </td>


                                                                                        <td class="frm-rght-clr12345">
                                                                                            <%--<asp:Button ID="btn_add_goals" runat="server" Text="Add Goal" OnClick="btn_add_goals_Click" OnClientClick="disableBtn(this.id, 'Submitting...')" UseSubmitBehavior="false"
                                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>--%>
                                                                                            <%--   <asp:Button ID="btn_add_goals1" runat="server" Text="Add Goal" OnClick="btn_add_goals1_Click" CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g" />--%>


                                                                                            <asp:Button ID="btn_add_goals" runat="server" Text="Add Goal" OnClick="btn_add_goals_Click" CssClass="btn btn-info" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>
                                                                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-info" ToolTip="Click here to Cancel"></asp:Button>
                                                                                        </td>
                                                                                    </tr>

                                                                                </table>
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Div1" runat="server" visible="false">
                                                                            <td colspan="4">
                                                                                <br />
                                                                                <div class="widget-body">
                                                                                    <div class="example_alt_pagination">
                                                                                        <asp:GridView ID="gvGoals" runat="server" AutoGenerateColumns="False"
                                                                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                                                            OnRowDeleting="gvGoals_RowDeleting" OnRowEditing="gvGoals_RowEditing" OnRowUpdating="gvGoals_RowUpdating"
                                                                                            OnRowDataBound="gvGoals_RowDataBound" OnRowCancelingEdit="gvGoals_RowCancelingEdit" ShowFooter="false">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex +1 %>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle Width="5%" />
                                                                                                </asp:TemplateField>

                                                                                                <%--<asp:TemplateField HeaderText="asd_id" Visible="true">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblro2" runat="Server" Text='<%# Eval("asd_id") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>

                                                                                                <asp:TemplateField HeaderText="Name of the Goal"><%--HeaderText="Role & Responsibilities"--%>
                                                                                                    <ItemTemplate>
                                                                                                        <%--<asp:Label ID="lblro" runat="Server" Text='<%# Eval("role") %>'></asp:Label>--%>
                                                                                                        <asp:Label ID="lblro" runat="Server" Text='<%# Eval("role_name_of_the_goal") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                   <%-- <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text1" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("role") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Desired outcome/Impact"><%--HeaderText="KRA"--%>
                                                                                                    <ItemTemplate>
                                                                                                       <%-- <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca_kra_desired_outcome_impact") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                   <%-- <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text2" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("kca") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Milestone to check improvement"><%--HeaderText="KPI"--%>
                                                                                                    <ItemTemplate>
                                                                                                       <%-- <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi_milestone_to_check_improvement") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <%--<EditItemTemplate>
                                                                                                        <asp:TextBox ID="text3" runat="server" CssClass="span11" TextMode="MultiLine" Text='<%#Eval("kpi") %>' MaxLength="2000"></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Timeline and support required"><%--<asp:TemplateField HeaderText="Weightage(%)">--%>
                                                                                                    <ItemTemplate>
                                                                                                       <%-- <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage_timeline_and_support_required") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                  <%--  <EditItemTemplate>
                                                                                                        <asp:TextBox ID="text4" CssClass="span11" runat="server" TextMode="MultiLine" Text='<%#Eval("weightage") %>'></asp:TextBox>
                                                                                                    </EditItemTemplate>--%>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Delete" ItemStyle-Width="26px">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            ID="LinkButton1" runat="server" CommandName="Delete" Text="&lt;img src='../images/download_delete.png'/&gt;" OnClientClick="return confirm('Are you sure to delete this Goal?')"></asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Edit">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton
                                                                                                            ID="LinkButton2" runat="server" CommandName="Edit" Text="&lt;img src='../images/edit.png'/&gt;"></asp:LinkButton>
                                                                                                    </ItemTemplate>

                                                                                                    <EditItemTemplate>
                                                                                                        <asp:LinkButton ID="lnkbtupdate" runat="server" CommandName="Update" class="btn btn-info" Text="Update" />
                                                                                                        <asp:LinkButton ID="lnkbtncancle" runat="server" CommandName="Cancel" class="btn btn-info" Text="Cancel" />
                                                                                                    </EditItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                    <ItemStyle HorizontalAlign="Center" Width="7%"></ItemStyle>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr1" runat="server" visible="false">
                                                                            <td colspan="4">
                                                                                <br />
                                                                                <div class="widget-body">
                                                                                    <div class="example_alt_pagination">
                                                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                                                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" 
                                                                                            OnRowDeleting="gvGoals_RowDeleting" OnRowEditing="gvGoals_RowEditing" OnRowUpdating="gvGoals_RowUpdating"
                                                                                            OnRowDataBound="gvGoals_RowDataBound" OnRowCancelingEdit="gvGoals_RowCancelingEdit" ShowFooter="false">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                                                    <ItemTemplate>
                                                                                                        <%# Container.DataItemIndex +1 %>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                                <%--<asp:TemplateField HeaderText="asd_id" Visible="false">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="lblro2" runat="Server" Text='<%# Eval("asd_id") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>

                                                                                                <asp:TemplateField HeaderText="Name of the Goal"><%--HeaderText="Role & Responsibilities"--%>
                                                                                                    <ItemTemplate>
                                                                                                         <%--<asp:Label ID="lblro" runat="Server" Text='<%# Eval("role") %>'></asp:Label>--%>
                                                                                                        <asp:Label ID="lblro" runat="Server" Text='<%# Eval("role_name_of_the_goal") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Desired outcome/Impact"><%--HeaderText="KRA"--%>
                                                                                                    <ItemTemplate>
                                                                                                         <%-- <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label2" runat="Server" Text='<%# Eval("kca_kra_desired_outcome_impact") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle Width="20%" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Milestone to check improvement"><%--HeaderText="KPI"--%>
                                                                                                    <ItemTemplate>
                                                                                                        <%-- <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label3" runat="Server" Text='<%# Eval("kpi_milestone_to_check_improvement") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Timeline and support required"><%--<asp:TemplateField HeaderText="Weightage(%)">--%>
                                                                                                    <ItemTemplate>
                                                                                                                            <%-- <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>--%>
                                                                                                         <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("weightage_timeline_and_support_required") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                            </Columns>
                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </div>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>


                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-actions no-margin" style="text-align: right">
                                <asp:Button ID="btnSaveGoals" runat="server" Text="Assign Goals " CssClass="btn btn-info" OnClientClick="return ValidateForm();" OnClick="btnSaveGoals_Click" />
                                <asp:Button ID="btnCancelGoals" runat="server" Text="Clear Goals" CssClass="btn btn-info" OnClick="btnCancelGoals_Click" Visible="False" />
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
                //"sPaginationType": "full_numbers"
                bPaginate: false,
                sScrollY: "300px",
                sScrollCollapse: true
            });
        });
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gvGoals1').dataTable({
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
