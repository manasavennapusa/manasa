<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RatingReviewByBUH.aspx.cs" Inherits="appraisal_RatingReviewByBUH" %>

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

    <style type="text/css">
        .star:before {
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
                        <h2>Review Rating </h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="Review Rating & Comments"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div runat="server" id="empsearch">

                                    <table width="100%" class="table table-condensed table-striped  table-bordered ">

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
                                            <td class="frm-lft-clr123  " style="text-align: center;">Department</td>
                                            <td class="frm-rght-clr123  ">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dept"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department" ValidationGroup="d" InitialValue="0"
                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                            <td class="frm-lft-clr123">
                                                <%--SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"--%>
                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" ValidationGroup="d" />
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

                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered ">
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Role</td>
                                                        <td class="frm-rght-clr123  ">
                                                            <asp:Label ID="lblrole" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Review Period</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblReview" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Line Manager</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblmanager" runat="server"></asp:Label>
                                                        </td>
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
                                                    <tr style="height: 40px; display: none">
                                                        <td class="frm-lft-clr123  "></td>
                                                        <td class="frm-rght-clr123  "></td>
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

                                    <%--<table style="width: 100%;">
                                        <tr>
                                            <td class="txt01" style="height: 40px"><strong>Smart Goals Rating</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left" OnRowDataBound="gvGoals_RowDataBound1"
                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" ShowFooter="true"
                                                    EmptyDataText="No Data Found" OnRowEditing="gvGoals_RowEditing" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="5%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Title" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("role") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="KRA">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("kca") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="20%" />
                                                        </asp:TemplateField>

                                                              <asp:TemplateField HeaderText="KPI" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelspe2" runat="Server" Text='<%# Eval("kpi") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="20%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Weightage">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Comments" runat="server" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Comments" Visible="false" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmngcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
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

                                                        <asp:TemplateField HeaderText="Employee Comments" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempcomments" runat="Server" Text='<%# Eval("empcomments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Manager Rating" runat="server" Visible="false">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("mgrrating")%>'></asp:Label>
                                                            </ItemTemplate>

                                                            <EditItemTemplate>
                                                                <asp:Label ID="lblrating1" runat="Server" Text='<%#Eval("mgrrating")%>' Visible="false"></asp:Label>
                                                                <asp:DropDownList ID="txteditrating" runat="server" CssClass="span11" Width="75px" MaxLength="1"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator
                                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txteditrating" ErrorMessage="Enter rating" InitialValue="0"
                                                                    Display="Dynamic" ValidationGroup="g"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>

                                                            </EditItemTemplate>

                                                            <FooterTemplate>
                                                                <b>Average Rating :</b><asp:Label ID="lblmgrAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="10%" />

                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Manager Comments">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="Server" Text='<%#Eval("mgrcomments")%>'></asp:Label>
                                                            </ItemTemplate>

                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="txteditcomments" CssClass="span11" TextMode="MultiLine" runat="server" placeholder="Max 8000 chars." Width="150px" Text='<%# Eval("mgrcomments") %>' MaxLength="8000"></asp:TextBox>
                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txteditcomments"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g">
                                                                </asp:RegularExpressionValidator>
                                                            </EditItemTemplate>

                                                            <HeaderStyle Width="15%" />
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderStyle-Width="5%">
                                                            <EditItemTemplate>
                                                                <asp:LinkButton ID="lnkbtupdate" runat="server" ValidationGroup="g" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                                <asp:LinkButton ID="lnkbtncancle" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" Visible='<%#Eval("mgrrating").ToString()==""?false:true%>' OnClientClick="return confirm('Are you sure to Edit this entry?')" CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>--%>

                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td class="txt01"><strong>Smart Goals Rating</strong>
                                                </td>
                                                <td style="border-right: none; border-left: none; width: 15%"></td>
                                                <td style="border-right: none; border-left: none; width: 15%"></td>
                                                <td style="border-right: none; border-left: none; width: 15%"></td>
                                                <td class="frm-rght-clr123" style="width: 10%; padding: 10px; border-left: none">
                                                    <a href="#myModal" role="button" class="btn btn-primary" data-toggle="modal" style="float: right">View</a>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%"><b>Competency</b>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%"><b>Appraisee Rating</b></td>
                                                <td class="frm-rght-clr123" style="width: 15%"><b>Appraisee Comments</b></td>
                                                <td class="frm-rght-clr123" style="width: 15%"><b>Appraiser Rating</b></td>
                                                <td class="frm-rght-clr123" style="width: 15%"><b>Appraiser Comments</b></td>

                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Funtional Skills
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_skils" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_skill_cmnt" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_skils_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_skils_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Quality
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_quality" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_quality_cmnt" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_quality_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_quality_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Communication Skills
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_comm" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_comm" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_comm_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_comm_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Self Development
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_self" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_self" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_self_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_self_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Process Knowladge & Ahereance
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_pro" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_pro" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_pro_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_pro_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Team Participation
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_team" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_team" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_team_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_team_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Commitment
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_commit" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_commit" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_commit_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_commit_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Client/Customer Orientation (Supervisor and above)
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_client" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_client" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_client_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_client_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Team Planing & Management (Supervisors and above)
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_plan" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_plan" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_plan_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_plan_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 15%">Mentoring, Leadership and Team Training (Supervisors and above)
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_mentor" runat="Server" Width="115px" CssClass="blue1" Enabled="false" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_mentor" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px" ReadOnly="true"></asp:TextBox>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:DropDownList ID="drp_mentor_app" runat="Server" Width="115px" CssClass="blue1" AutoPostBack="true">
                                                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                                        <asp:ListItem Value="0">NA</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 15%">
                                                    <asp:TextBox runat="server" ID="txt_mentor_app" placeholder="Max 8000 Chars." TextMode="MultiLine" Width="200px"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>

                                    <table style="width: 100%;" id="tbl_behavior" runat="server" visible="false">
                                        <tr>
                                            <td style="height: 40px"><strong>Rate Behavior</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdcolor" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    DataKeyNames="id"
                                                    CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Performance Objcetives" HeaderStyle-Width="20%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblObjcetives" runat="server" Text='<%# Eval("performance_objectivies") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Unaccetable" HeaderStyle-Width="16%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Unaccetable" runat="server" CssClass="button" CommandArgument='<%#Eval("unaccetable") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("unaccetable").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Sometimes" HeaderStyle-Width="16%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Sometimes" runat="server" CommandArgument='<%#Eval("sometimes") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("sometimes").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Regularly" HeaderStyle-Width="16%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Regularly" runat="server" CommandArgument='<%#Eval("regular") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("regular").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Always" HeaderStyle-Width="16%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_Always" runat="server" CommandArgument='<%#Eval("always") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("always").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Role Model" HeaderStyle-Width="16%">
                                                            <ItemTemplate>
                                                                <asp:Button ID="btn_RoleModel" runat="server" CommandArgument='<%#Eval("role_model") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("role_model").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <table style="width: 100%; display: none">



                                        <tr runat="server" visible="false">
                                            <td class="txt01" style="height: 40px"><strong>Training Requirement</strong>
                                            </td>
                                        </tr>

                                        <tr runat="server" visible="false">
                                            <td>
                                                <asp:TextBox ID="txttraining" runat="Server" TextMode="MultiLine" MaxLength="8000" Width="450px" CssClass="span11" Height="40px" placeholder="Max 8000 chars."></asp:TextBox>
                                                <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txttraining"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                </asp:RegularExpressionValidator>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                    <tr style="display: none;">
                                                        <td class="frm-lft-clr123" style="width: 20%; border-top: none">Average Rating of Smart Goals
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 15%; border-top: none">
                                                            <asp:Label ID="lblAvgRatingGoals" runat="server"></asp:Label>
                                                        </td>

                                                        <td class="frm-lft-clr123" style="width: 20%; border-top: none">Average Rating of Competencies
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%; border-top: none">
                                                            <asp:Label ID="lblAvgRatingComp" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr id="troverall" runat="server">
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
                                                        <td class="frm-rght-clr123" style="width: 10%" runat="server" visible="false">Performance and Behavior
                                                        </td>
                                                    </tr>
                                                    <tr id="troverall2" runat="server" visible="true">
                                                        <td class="frm-lft-clr123 " style="width: 15%;">Manager Overall Rating
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%;">
                                                            <asp:Label ID="lblMgrOverallRating" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Manager Overall Comments
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 40%;">
                                                            <%-- <asp:Label ID="txtMgrOverallComments" runat="server"></asp:Label>--%>
                                                            <asp:TextBox ID="txtMgroverallcomments" runat="server" TextMode="MultiLine" Width="450PX" MaxLength="8000" placeholder="Max 8000 chars." ReadOnly="true"></asp:TextBox>
                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtMgroverallcomments"
                                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                            </asp:RegularExpressionValidator>--%>
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 10%">
                                                            <asp:Label ID="lblBehavior" runat="server" Width="80px" Height="40px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblappr" runat="server"><b>What do you (Appraisee) consider to be your most important achievement of the past year?</b></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtappr" runat="server" TextMode="MultiLine" Width="600px" placeholder="Max 8000 chars." ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>
                                                <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lbltraining" runat="server"><b>Which trainings would benefit you to develop job skills by which you and your work will be benefited? (Technical, behavioural, language skills etc. trainings)</b></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:TextBox ID="txt_training" runat="server" TextMode="MultiLine" Width="600px" placeholder="Max 8000 chars." ReadOnly="true"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                    <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td id="Td1" runat="server">
                                                    <asp:Label ID="lblcommnt" runat="server"><b>Appraisee Comments</b></asp:Label>
                                                </td>

                                            </tr>
                                            <tr runat="server" id="appr_div1" visible="true">
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtcmnt_aap" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars." ReadOnly="true"></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr id="tr_1" runat="server" visible="false">
                                                <td id="Td2" runat="server">
                                                    <asp:Label ID="Label2" runat="server"><b>Line Manager Comments</b></asp:Label>
                                                </td>

                                            </tr>
                                            <tr runat="server" id="Tr1" visible="false">
                                                <td>
                                                    <asp:TextBox runat="server" ID="txt_LM_comment" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars."></asp:TextBox>
                                                </td>

                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server"><b>Line Manager Comments</b></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="appr_div" visible="true">
                                                <td style="background-color: white">
                                                    <asp:TextBox runat="server" ID="txtcmnt_appr_1" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars." ReadOnly="true"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server"><b>Business Head Comments<span class="star"></span></b></asp:Label>
                                                </td>
                                            </tr>
                                            <tr runat="server" id="Tr2" visible="true">
                                                <td style="background-color: white">
                                                    <asp:TextBox runat="server" ID="txt_BH_cmnt" TextMode="MultiLine" Width="600px" Height="50px" placeholder="Max 8000 chars."></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txt_BH_cmnt" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Comments" ValidationGroup="v" SetFocusOnError="true" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="clearfix"></div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="v" />&nbsp;&nbsp;
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Back" OnClick="btnCancel_Click" />&nbsp;&nbsp;
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
                                <asp:LinkButton ID="btn_chkall" runat="server" Text="Check All" OnClick="btn_chkall_Click" Style="color: #194893"></asp:LinkButton>
                                &nbsp;|&nbsp
                            <asp:LinkButton ID="btn_unchkall" runat="server" Text="Uncheck All" OnClick="btn_unchkall_Click" Style="color: #194893"></asp:LinkButton>
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gveligible" runat="server" CellSpacing="0" AutoGenerateColumns="false"
                                        CellPadding="4" DataKeyNames="empcode" OnPreRender="gveligible_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderStyle-Width="4%">
                                                <ItemTemplate>
                                                    <asp:CheckBox runat="server" ID="chk_empdetails" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
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

                                            <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="~/appraisal/RatingReviewByBUH.aspx?empcode={0}"
                                                Text="&lt;img src='../images/view.png' /&gt;" ItemStyle-Width="30%">
                                                <ControlStyle CssClass="link05" Width="6%" />
                                            </asp:HyperLinkField>

                                            

                                        </Columns>
                                    </asp:GridView>

                                    <asp:Button ID="btn_submit_all" runat="server" Text="Submit" CssClass="btn btn-primary" style="float:right" OnClick="btn_submit_all_Click" />
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                        ×</button>
                    <h4 id="myModalLabel">Goal Sheet
                    </h4>
                </div>
                <div>
                    <iframe src="ViewBH_kra_golas.aspx?empcode=<%=lblempcode.Text.ToString()%>" width="100%" frameborder="0" height="500px"></iframe>
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
