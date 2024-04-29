<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createtemplogin.aspx.cs" Inherits="admin_createtemplogin" %>
<%--<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Create Employee</h2>
                    </div>
                    <%--<div class="pull-right">
                        <ul class="stats">
                            <li class="color-first">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe0b3;"></span>
                                <div class="details">
                                    <span class="big">12</span>
                                    <span>New Tasks</span>
                                </div>
                            </li>
                            <li class="color-second hidden-phone">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>
                                <div class="details" id="date-time">
                                    <span>Date </span>
                                    <span>Day, Time</span>
                                </div>
                            </li>
                        </ul>
                    </div>--%>
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Job Detail</li>
                                        <li>Contact Detail</li>
                                        <li>Professional</li>
                                        <li>Personal Detail</li>
                                        <li>Employee Upload Detail</li>
                                    </ol>
                                    <div>
                                        <p>
                                            <script type="text/javascript">
                                                function JobCompareDates() {
                                                    var DOJ = document.getElementById('<%=doj.ClientID %>');
                                                    var DOB = document.getElementById('<%=txtdol.ClientID %>');
                                                    if (!(DOB.value < DOJ.value)) {
                                                        alert("Date of joining  Should be lessthan Date of Leaving");
                                                        DOJ.focus();
                                                        return false;
                                                    }
                                                }
                                            </script>
                                            <!-- Job Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                <tr>
                                                    <td colspan="2" class="txt02" style="height: 25px">Employee Information
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2" width="100%">

                                                        <asp:UpdatePanel ID="kk" runat="server">
                                                            <ContentTemplate>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Title
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="span11" OnSelectedIndexChanged="ddlSalutation_SelectedIndexChanged" AutoPostBack="true">
                                                                                            <asp:ListItem Value="Mr">Mr</asp:ListItem>
                                                                                            <asp:ListItem Value="Ms">Ms</asp:ListItem>
                                                                                            <asp:ListItem Value="Mrs">Mrs</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <asp:HiddenField ID="HiddenTodayDate" runat="server" />
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Employee Name<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:TextBox ID="txtfirstname" runat="server" CssClass="span11" MaxLength="200" onblur="capitalizeMe(this)" onkeypress="return isChar_Space_dot_dash_ifin()"></asp:TextBox>
                                                                                       <%-- <asp:RequiredFieldValidator
                                                                                            ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfirstname"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Employee First Name"
                                                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtfirstname"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets and space"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom">Gender<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="drpgender" runat="server" CssClass="span11" OnSelectedIndexChanged="drpgender_SelectedIndexChanged" AutoPostBack="true">
                                                                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                            <asp:ListItem Value="Male">MALE</asp:ListItem>
                                                                                            <asp:ListItem Value="Female">FEMALE</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                       <%-- <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="drpgender"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Title" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>--%>
                                                                                    </td>
                                                                                </tr>



                                                                                <tr id="Tr1" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%">Middle Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:TextBox ID="txtmiddlename" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txtmiddlename"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr2" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Last Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                        <asp:TextBox ID="txtlastname" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator15" ControlToValidate="txtlastname"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Employee Code<span class="star"></span>
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txtempcode" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtempcode" Display="Dynamic"
                                                                                            SetFocusOnError="True" ToolTip="Employee Code" ValidationGroup="v" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator46" ControlToValidate="txtempcode"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9_\-\/]+$" ToolTip="Enter only alphanumeric"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td width="48%" class="frm-lft-clr123">Employee No.
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_card_no" runat="server" CssClass="span11" MaxLength="100"></asp:TextBox>
                                                                                       <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator47" ControlToValidate="txt_card_no"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123  border-bottom">Login Password<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txtpwd" runat="server" CssClass="span11" TextMode="Password"
                                                                                            MaxLength="50"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpwd"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Employee Password"
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td height="5" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">Work Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel5"
                                                                                DisplayAfter="1">
                                                                                <ProgressTemplate>
                                                                                    <div class="divajax">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
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
                                                                            <script type="text/javascript">
                                                                                function isNumberKey(evt) {
                                                                                    var charCode = (evt.which) ? evt.which : event.keyCode
                                                                                    if (charCode != 46 && charCode > 31
                                                                                                    && (charCode < 48 || charCode > 57)) {
                                                                                        //alert('Please enter only Numbers')
                                                                                        return false;
                                                                                    }
                                                                                    return true;
                                                                                }
                                                                            </script>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%> Work Location<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpbranch" runat="server" CssClass="span11" Height="" Width=""
                                                                                            DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                                            OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                      <%--  <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="drpbranch"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>--%><asp:SqlDataSource
                                                                                                ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Department<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdepartment" runat="server" CssClass="span11" Height=""
                                                                                            Width="" OnDataBound="drpdepartment_DataBound">
                                                                                        </asp:DropDownList>
                                                                                       <%-- <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="drpdepartment"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Emplyee Department" ValidationGroup="v"
                                                                                            ValueToCompare="0"></asp:CompareValidator>--%>
                                                                                        <%--<asp:SqlDataSource ID="sql_data_department" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                ProviderName="System.Data.SqlClient" SelectCommand="SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid=@branchid">
                <SelectParameters>
                    <asp:ControlParameter ControlID="drpbranch" Name="branchid" PropertyName="SelectedValue" DefaultValue="0" />
                </SelectParameters>
            </asp:SqlDataSource>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center <span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:DropDownList ID="drpdivision" runat="server" CssClass="span11" Height=""
                                                                                            Width="" DataSourceID="SqlDatasource_division" DataTextField="division_name"
                                                                                            DataValueField="ID" OnDataBound="drpdivision_DataBound">
                                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                      <%--  <asp:CompareValidator ID="CompareValidator7" runat="server" ControlToValidate="drpdivision"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Sub Department" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>--%>
                                                                                        <asp:SqlDataSource ID="SqlDatasource_division" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [ID], [division_name] FROM [tbl_intranet_division]"></asp:SqlDataSource>
                                                                                    </td>
                                                                                </tr>


                                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Sub Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddl_subgroup" runat="server"  CssClass="span11"  Height="20px"
                                                                                    Width="147px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>--%>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Broad Group--%> Business Unit
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_broadgroup" runat="server" CssClass="span11">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Designation<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdegination" runat="server" CssClass="span11" DataSourceID="sql_data_degination" DataTextField="designationname"
                                                                                            DataValueField="id" OnDataBound="drpdegination_DataBound">
                                                                                        </asp:DropDownList>
                                                                                       <%-- <asp:CompareValidator ID="CompareValidator6" runat="server" ControlToValidate="drpdegination"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Emplyee Degination" ValidationGroup="v"
                                                                                            ValueToCompare="0"></asp:CompareValidator>--%><asp:SqlDataSource ID="sql_data_degination"
                                                                                                runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>

                                                                                    </td>
                                                                                </tr>

                                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Entity
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddl_entity" runat="server"  CssClass="span11"  Height="20px" Width="147px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>--%>
                                                                                <tr id="Tr3" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Grade Type
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_gradetype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_gradetype_SelectedIndexChanged"
                                                                                            CssClass="blue1">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="A">Administration</asp:ListItem>
                                                                                            <asp:ListItem Value="T">Technical</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Grade
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpgrade" runat="server" CssClass="span11" DataSourceID="sql_data_grade"
                                                                                            DataTextField="gradename" DataValueField="id" OnDataBound="drpgrade_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <%--<asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="drpgrade"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                            SetFocusOnError="True" ToolTip="Select Employee Grade" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>--%>
                                                                                        <asp:SqlDataSource ID="sql_data_grade" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [gradename] FROM [tbl_intranet_grade]"></asp:SqlDataSource>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr style="height: 50px">
                                                                                    <td width="48%" class="frm-lft-clr123">Employee Role<span class="star"></span>
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drprole" runat="server" Height="" CssClass="span11" Width=""
                                                                                            DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">
                                                                                            <asp:ListItem Text="-Select Employee Role-" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Value="1">Employee</asp:ListItem>
                                                                                            <asp:ListItem Value="2">Middle Level</asp:ListItem>
                                                                                            <asp:ListItem Value="3">Top Level</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            Operator="NotEqual" ValidationGroup="v" ControlToValidate="drprole" ValueToCompare="0"
                                                                                            SetFocusOnError="True" ToolTip="Select Employee Roll"></asp:CompareValidator>
                                                                                        <asp:SqlDataSource
                                                                                            ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role]"></asp:SqlDataSource>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123  border-bottom" width="48%">Employee Status<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:DropDownList ID="drpempstatus" runat="server" CssClass="blue1" Height=""
                                                                                            Width="" DataSourceID="sql_data_status" DataTextField="employeestatus" DataValueField="id"
                                                                                            OnDataBound="drpempstatus_DataBound" AutoPostBack="true" OnSelectedIndexChanged="drpempstatus_SelectedIndexChanged1">
                                                                                        </asp:DropDownList>
                                                                                       <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpempstatus"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                            ToolTip="Select Employee Status" ValidationGroup="v" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>--%><asp:SqlDataSource
                                                                                                ID="sql_data_status" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id],[employeestatus] FROM tbl_intranet_employee_status"></asp:SqlDataSource>

                                                                                    </td>
                                                                                </tr>


                                                                                <tr id="trprobationperiod" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_probationperiod" runat="server" CssClass="span11"
                                                                                            MaxLength="2" AutoPostBack="true" onkeypress=" return isNumberKey(event)" OnTextChanged="txt_probationperiod_TextChanged"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RFV_probationperiod" runat="server" ControlToValidate="txt_probationperiod"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Probation Period"
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptstart" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_deput_start_date" runat="server" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        &nbsp;
                                                                                <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                                                                            TargetControlID="txt_deput_start_date" Enabled="True" Format="dd-MMM-yyyy">
                                                                                        </cc1:CalendarExtender>
                                                                                        <asp:RequiredFieldValidator ID="RFV_deput_start_date" runat="server" ControlToValidate="txt_deput_start_date"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Deputation Start Date"
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trprobationdate3" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom">Confirmation Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_confirmationdate" runat="server" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image13" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender13" runat="server" PopupButtonID="Image13" TargetControlID="txt_confirmationdate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                                    </td>
                                                                                </tr>

                                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Entity
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddl_entity" runat="server"  CssClass="span11"  Height="" Width="">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2">
                                                                            </td>
                                                                        </tr>--%>
                                                                                <tr id="trDOL" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Date of Leaving<span class="star"></span></td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txtdol" runat="server" CssClass="span11" Width="100px" onblur="return JobCompareDates();" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtdol"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                                        <asp:RequiredFieldValidator ID="RFV_DOL" runat="server" ControlToValidate="txtdol"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Date of Leaving"
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <%--<asp:CompareValidator ID="CompareValidator20" runat="server" ControlToCompare="doj"
                                                                                        ControlToValidate="txtdol" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                        Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                                                        ValidationGroup="v"></asp:CompareValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:UpdatePanel ID="upl" runat="server">
                                                                        <ContentTemplate>
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Date of Joining<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="51%">
                                                                                        <asp:TextBox ID="doj" runat="server" CssClass="span11" AutoPostBack="true" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"
                                                                                            OnTextChanged="doj_TextChanged"></asp:TextBox>&#160;<asp:Image ID="Image4" runat="server"
                                                                                                ImageUrl="~/img/clndr.gif" />
                                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator12"
                                                                                            runat="server" ControlToValidate="doj" Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            SetFocusOnError="True" ToolTip="Enter Joining Date" ValidationGroup="v" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                        <cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                            ID="CalendarExtender4" runat="server" PopupButtonID="Image4" TargetControlID="doj"
                                                                                            Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr id="Tr4" style="height: 50px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Salary Calculation From<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txtsalary" runat="server" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="Image6" Format="dd-MMM-yyyy"
                                                                                            TargetControlID="txtsalary" Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                       <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtsalary"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                            ToolTip="Enter Salary Calculation From Date" ValidationGroup="v" Width="6px">
                                                                                    <img src="../img/error1.gif" alt="" />
                                                                                        </asp:RequiredFieldValidator>--%>
                                                                                        <asp:CompareValidator ID="CompareValidator13" runat="server" ControlToCompare="doj"
                                                                                            ControlToValidate="txtsalary" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                                                            ValidationGroup="v"></asp:CompareValidator>

                                                                                    </td>
                                                                                </tr>


                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Official Mobile No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txtoff_mobileno" runat="server" CssClass="span11" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator17" ControlToValidate="txtoff_mobileno"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[7-9][0-9]{9}$" ToolTip="Enter 10 digits and starts with 7 or 8 or 9"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Official Email Id
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_officialemail" runat="server" CssClass="span11"
                                                                                            MaxLength="50"></asp:TextBox>
                                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                                        ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                                                        ControlToValidate="txt_officialemail" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                        ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Ext. Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txtext" runat="server" MaxLength="15" CssClass="span11"></asp:TextBox>
                                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtext"
                                                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Immediate Supervisor Name--%>Reporting Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_supervisor" runat="server" CssClass="span11"
                                                                                            Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 "><%--Corporate Reporting Name--%> Functional Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddl_corp_report_name" runat="server" CssClass="span11"
                                                                                            Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 "><%--Manager Name--%>Unit Head
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddl_hod" runat="server" CssClass="span11" Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Employee Photo
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                        <File_Uploader:File_Uploader ID="f_upload_rep1" runat="server" FileTypeRange="bmp,jpg"
                                                                                            Vgroup="v" />
                                                                                    </td>
                                                                                </tr>




                                                                                <tr id="trprobationdate" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%" style="border-top: none;">Notice Period During Probation (in days)<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_probation_date" runat="server" CssClass="span11"
                                                                                            MaxLength="3"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RFV_probation_date" runat="server" ControlToValidate="txt_probation_date"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Notice Period during Probation "
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="REg_probation_date" ControlToValidate="txt_probation_date"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptenddate" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Deputation End Date<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_deput_end_date" runat="server" CssClass="span11" Width="180" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12" Format="dd-MMM-yyyy"
                                                                                            TargetControlID="txt_deput_end_date" Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                        <asp:RequiredFieldValidator ID="RFV_deput_end_date" runat="server" ControlToValidate="txt_deput_end_date"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Enter Deputation End Date"
                                                                                            ValidationGroup="v" Width="5px" SetFocusOnError="True"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:CompareValidator ID="CompareValidator18" runat="server" ControlToCompare="txt_deput_start_date"
                                                                                            ControlToValidate="txt_deput_end_date" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            Operator="GreaterThanEqual" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                                                            ValidationGroup="Driving"></asp:CompareValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trprobationdate2" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Notice Period on Confimation (in days)<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                        <asp:TextBox ID="txt_noticePeriod" runat="server" CssClass="span11"
                                                                                            MaxLength="2"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="REg_probationdate2" ControlToValidate="txt_noticePeriod"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trReasonL" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Reason for Leaving
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txtreason" runat="server" CssClass="span11" MaxLength="200"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator48" ControlToValidate="txtreason"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td height="15" colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">

                                                                    <table id="Table1" width="100%" border="0" cellspacing="0" cellpadding="0" runat="server" visible="false">
                                                                        <tr>
                                                                            <td width="50%" valign="top">
                                                                                <asp:UpdatePanel ID="up" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr>
                                                                                                <td colspan="2" class="txt02">Cost Center
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5" colspan="2"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:DropDownList ID="ddl_cc_groupid" runat="server" CssClass="span11" Height=""
                                                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_cc_groupid_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:DropDownList ID="ddl_cc_code" runat="server" CssClass="span11" Height=""
                                                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_cc_code_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="trcc" runat="server" visible="false">
                                                                                                <td colspan="2">
                                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" style="border-top: none;" width="48%">Country
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="52%" style="border-top: none;">
                                                                                                                <asp:Label ID="lbl_cc_country" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_ccountry" runat="server" />

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">State
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:Label ID="lbl_cc_state" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_cstate" runat="server" />

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:Label ID="lbl_cc_city" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_ccity" runat="server" />

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Location
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:Label ID="lbl_cc_location" runat="server" Height="">
                                                                                                                </asp:Label>

                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="2" height="5"></td>
                                                                                                        </tr>
                                                                                                    </table>

                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                            <tr>
                                                                                                <td colspan="2" class="txt02">Additional Cost Center
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="5" colspan="2"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="51%">
                                                                                                    <asp:DropDownList ID="ddl_acc_groupid" runat="server" CssClass="span11" Height=""
                                                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_acc_groupid_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:DropDownList ID="ddl_acc_code" runat="server" CssClass="span11" Height=""
                                                                                                        AutoPostBack="true" OnSelectedIndexChanged="ddl_acc_code_SelectedIndexChanged">
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="traddcc" runat="server" visible="false">
                                                                                                <td colspan="2">
                                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                                                                                                                <asp:Label ID="lbl_acc_country" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_accountry" runat="server" />
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">State
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:Label ID="lbl_acc_state" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_acstate" runat="server" />
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">City
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:Label ID="lbl_acc_city" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                                <asp:HiddenField ID="hf_accity" runat="server" />
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Location
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:Label ID="lbl_acc_location" runat="server" Height="">
                                                                                                                </asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td height="5" colspan="2"></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="10" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02">Payroll Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td id="Td1" class="frm-lft-clr123 " width="48%" runat="server">CTC Per Annum
                                                                            </td>
                                                                            <td id="Td2" class="frm-rght-clr123  " width="52%" runat="server">
                                                                                <asp:TextBox ID="ward" runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123">PF Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="pfno" runat="server" CssClass="span11" MaxLength="16"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator51" ControlToValidate="pfno"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\/\-]+$" ToolTip="Enter only alphanumeric and /"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">PAN Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:TextBox ID="panno" runat="server" CssClass="span11" MaxLength="10"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator52" ControlToValidate="panno"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^([A-Z]{5})(\d{4})([A-Z]{1})$" ToolTip="Enter Valid PAN No. (like NADRS4235R) only capital letters and numbers"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 5px"></td>
                                                                        </tr>
                                                                        <tr id="trptno" runat="server" visible="False">
                                                                            <td id="Td3" class="frm-lft-clr123" runat="server">PT No.
                                                                            </td>
                                                                            <td id="Td4" class="frm-rght-clr123" runat="server">
                                                                                <asp:TextBox ID="txt_ptno" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="48%" class="frm-lft-clr123">ESI Dispensary
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="esidesp" runat="server" CssClass="span11" MaxLength="100"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator53" ControlToValidate="esidesp"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="48%">PF Region Office
                                                                            </td>
                                                                            <td class="frm-rght-clr123 " width="51%">
                                                                                <asp:TextBox ID="pfno_dept" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator54" ControlToValidate="pfno_dept"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ToolTip="Enter only alphabets,numbers,dash and space"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                <asp:TextBox ID="esino" runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator49" ControlToValidate="esino"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numeric "
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td align="right"></td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Contact Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <div>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <td style="height: 34px" colspan="2" width="100%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 50%" class="txt02">Present Address
                                                                                        </td>
                                                                                        <td class="txt02">Permanent Address
                                                                                   <td>
                                                                                       <table>
                                                                                           <tr>
                                                                                               <td>
                                                                                                   <asp:CheckBox ID="CheckBox1" runat="server" Text="" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                                                       AutoPostBack="True"></asp:CheckBox></td>
                                                                                               <td>Same as Present</td>

                                                                                           </tr>
                                                                                       </table>
                                                                                   </td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="span11" Width="" Height="60px" MaxLength="1000" Style="border: 1px solid #ddd" TextMode="MultiLine" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator67" ControlToValidate="txt_pre_add1"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr5" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator68" ControlToValidate="txt_pre_Add2"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr6" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr7" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr8" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr9" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="span11" Width="" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator35" ControlToValidate="txt_pre_zip"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter valid Zip Code(6 digits)"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr10" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="span11" Width="" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator36" ControlToValidate="txt_pre_phone"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter min 10 digits"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>


                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Address 
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="54%">
                                                                                                        <asp:TextBox ID="txt_per_add1" runat="server" CssClass="span11" Width="" Height="60px" Style="border: 1px solid #ddd" TextMode="MultiLine" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator69" ControlToValidate="txt_per_add1"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr11" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator70" ControlToValidate="txt_per_add2"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr12" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddl_per_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr13" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_per_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr14" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr15" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_zip" runat="server" CssClass="span11" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator38" ControlToValidate="txt_per_zip"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter valid Zip Code(6 digits)"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr16" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_phone" runat="server" CssClass="span11" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator37" ControlToValidate="txt_per_phone"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter min 10 digits"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>


                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td class="txt02">Emergency Contact Details:
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_name" runat="server" CssClass="span11" Width="" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"
                                                                                                            MaxLength="50"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator39" ControlToValidate="txt_emergency_name"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="45%">Relation
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_relation" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="50"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator45" ControlToValidate="txt_emergency_relation"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'.\-\s]+$" ToolTip="Enter only alphabets"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Contact No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_contactno" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator40" ControlToValidate="txt_emergency_contactno"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter min 10 digits"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr23" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 1
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator71" ControlToValidate="txt_emergency_address"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr24" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address2" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator72" ControlToValidate="txt_emergency_address2"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\.\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only alphanumeric  . - # and space"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr25" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_country" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" OnSelectedIndexChanged="ddl_emergency_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr26" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_state" runat="server" CssClass="span11" Width=""
                                                                                                            Height="" AutoPostBack="true" OnSelectedIndexChanged="ddl_emergency_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr27" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_emergency_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr28" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123 border-bottom">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                                        <asp:TextBox ID="txt_emergency_zipcode" runat="server" MaxLength="6" CssClass="blue1"
                                                                                                            Width="" onkeypress="return isNumber()"></asp:TextBox>
                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator41" ControlToValidate="txt_emergency_zipcode"
                                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{6}$" ToolTip="Enter valid Zip Code (6 digits)"
                                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td width="50%" valign="top"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">Mode of Transport
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                            <label class="radio inline">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td style="width: 70px">
                                                                                                            <asp:RadioButton ID="optown" runat="server" Text="Own" GroupName="mode" AutoPostBack="True"
                                                                                                                OnCheckedChanged="optown_CheckedChanged" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:RadioButton ID="optcompany" runat="server" Text="Company Vehicle" Checked="True"
                                                                                                                GroupName="mode" AutoPostBack="True" OnCheckedChanged="optcompany_CheckedChanged" /></td>
                                                                                                </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">




                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">&#160;<asp:Label ID="lblpickuppoint" runat="server" Text="Pick Up point"></asp:Label>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%">&#160;<asp:TextBox ID="txtmodeoftransport" CssClass="span11" runat="server" MaxLength="50"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator66" ControlToValidate="txtmodeoftransport"
                                                                                                ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphabets and number and space"
                                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" colspan="2">&#160;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>

                                            <!-- Professional Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td class="frm-lft-clr-main">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">Educational Qualification :</td>
                                                                <td align="right">
                                                                    <asp:Button ID="btn_quali_add" OnClick="btn_quali_add_Click" runat="server" Text="Add"
                                                                        CssClass="btn btn-info pull-right" ToolTip="Click here to add Educational Qualification" ValidationGroup="acc_edu"></asp:Button></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">School / Institute / University Name<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 150px" class="frm-rght-clr12345">
                                                                            <asp:DropDownList ID="drp_edu_qualification" runat="server" CssClass="span11" Width="180px">
                                                                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                <asp:ListItem>Matric(10th)</asp:ListItem>
                                                                                <asp:ListItem>Intermediate(12th)</asp:ListItem>
                                                                                <asp:ListItem>Diploma</asp:ListItem>
                                                                                <asp:ListItem>Graduation</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                            <asp:CompareValidator ID="CompareValidator9" runat="server" ValidationGroup="acc_edu"
                                                                                ValueToCompare="0" Operator="NotEqual" ControlToValidate="drp_edu_qualification"><img src="../img/error1.gif" alt="" title ="select qualification"  /></asp:CompareValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedu_specilazation" runat="server" CssClass="span11" Width="110px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator55" ControlToValidate="txtedu_specilazation"
                                                                                ValidationGroup="acc_edu" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedush" runat="server" CssClass="span11" Width="240px" MaxLength="150"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="rfvschl" runat="server" ControlToValidate="txtedush" Display="Dynamic" SetFocusOnError="True"
                                                                                ToolTip="Enter School / Institute / University Name" ValidationGroup="acc_edu"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>&nbsp;
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator56" ControlToValidate="txtedush"
                                                                            ValidationGroup="acc_edu" runat="server" ValidationExpression="^[a-zA-Z0-9\s\'\-\.]+$" ToolTip="Enter only alphabets and space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduper" runat="server" CssClass="span11" Width="60px" MaxLength="5"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txteduper"
                                                                                ValidationGroup="acc_edu" runat="server" ValidationExpression="^[a-zA-Z0-9\.\s]+$" ToolTip="Enter like 98.99, A,B"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedufrom" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator18" ControlToValidate="txtedufrom"
                                                                            ValidationGroup="acc_edu" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                            <asp:RangeValidator ID="rayear" runat="server" ControlToValidate="txtedufrom" MaximumValue="2200" ValidationGroup="acc_edu" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'>

                                                                            </asp:RangeValidator>
                                                                            to
                                                                    <asp:TextBox ID="txteduto" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator19" ControlToValidate="txteduto"
                                                                            ValidationGroup="acc_edu" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                            <asp:CompareValidator ID="CompareValidator14" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />' ControlToValidate="txteduto" ToolTip="To year should greaterthan From year"
                                                                                ControlToCompare="txtedufrom" ValueToCompare="drptoyear" Display="Dynamic" Operator="GreaterThan" ValidationGroup="acc_edu"></asp:CompareValidator>
                                                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txteduto" MaximumValue="2200" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />' ValidationGroup="acc_edu"></asp:RangeValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                    OnRowDeleting="grid_edu_education_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
                                                                                    CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Education">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Specialization">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="School / Institute / University Name ">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade / %">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label
                                                                                                    ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField>
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#160;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr-main">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">Professional Qualification :</td>
                                                                <td align="right">
                                                                    <asp:Button ID="btn_pro_qual_add" OnClick="btn_pro_qual_add_Click" runat="server"
                                                                        Text="Add" CssClass="btn btn-info pull-right" ToolTip="Click here to add Professional Qualification"
                                                                        ValidationGroup="pro_edu"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">Institute / University Name<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduc1" runat="server" CssClass="span11" Width="165px" MaxLength="150">
                                                                            </asp:TextBox><asp:RequiredFieldValidator ID="Requfdsfsd" runat="server" Width="6px"
                                                                                ToolTip="Enter Education" ValidationGroup="pro_edu" ControlToValidate="txteduc1"
                                                                                SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator19" ControlToValidate="txteduc1"
                                                                                ValidationGroup="pro_edu" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtpro_specilazation" runat="server" CssClass="span11" Width="120px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txtpro_specilazation"
                                                                                ValidationGroup="pro_edu" runat="server" ValidationExpression="^[a-zA-Z\s\&]+$" ToolTip="Enter only alphabets and space &"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtsch1" runat="server" CssClass="span11" Width="240px" MaxLength="100">
                                                                            </asp:TextBox>&nbsp;<asp:RequiredFieldValidator ID="RequiredfdfFieldValidator7" runat="server"
                                                                                Width="6px" ToolTip="Enter School / Institute / University Name" ValidationGroup="pro_edu"
                                                                                ControlToValidate="txtsch1" SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator21" ControlToValidate="txtsch1"
                                                                                ValidationGroup="pro_edu" runat="server" ValidationExpression="^[a-zA-Z0-9\s\'\-\.]+$" ToolTip="Enter only alphabets and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtper1" runat="server" CssClass="span11" Width="60px" MaxLength="5"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator22" ControlToValidate="txtper1"
                                                                                ValidationGroup="pro_edu" runat="server" ValidationExpression="^[a-zA-Z0-9\.\s]+$" ToolTip="Enter like 98.99, A,B"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtfrm1" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator20" ControlToValidate="txtfrm1"
                                                                            ValidationGroup="pro_edu" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtfrm1" MaximumValue="2200" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt="" ValidationGroup="pro_edu" />'></asp:RangeValidator>
                                                                            to
                                                                    <asp:TextBox ID="txtto1" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator21" ControlToValidate="txtto1"
                                                                            ValidationGroup="pro_edu" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                            <asp:CompareValidator ID="CompareValidator15" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />' ControlToValidate="txtto1" ToolTip="To year should greaterthan From year"
                                                                                ControlToCompare="txtfrm1" ValueToCompare="drptoyear" Display="Dynamic" Operator="GreaterThan" ValidationGroup="pro_edu"></asp:CompareValidator>
                                                                            <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txtto1" MaximumValue="2200" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />' ValidationGroup="pro_edu"></asp:RangeValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" OnRowDeleting="grid_Pro_education_RowDeleting" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                                    HorizontalAlign="Left" CellPadding="4" BorderWidth="0px">

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Education" HeaderStyle-Width="21%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Specialization" HeaderStyle-Width="21%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Institute / University Name" HeaderStyle-Width="30%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade / %" HeaderStyle-Width="13%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="13%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr-main">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">Experience Details :</td>
                                                                <td align="right">
                                                                    <asp:Button ID="btn_exp_add" OnClick="btn_exp_add_Click" runat="server" Text="Add"
                                                                        CssClass="btn btn-info pull-right" ValidationGroup="Exp"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="18%">Company Name<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="28%">Address / Location
                                                                        </td>
                                                                        <td class="td-head" width="20%">Designation<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="15%">Total Exp.(in years)
                                                                        </td>
                                                                        <td class="td-head" width="18%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtcomp1" runat="server" CssClass="span11" Width="140px" MaxLength="100"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" Width="6px"
                                                                                ToolTip="Enter Education" ValidationGroup="Exp" ControlToValidate="txtcomp1"
                                                                                SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator23" ControlToValidate="txtcomp1"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumaric and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_com_local" runat="server" CssClass="span11" Width="230px" MaxLength="250"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator57" ControlToValidate="txt_com_local"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^[a-zA-Z0-9\/\s\'\-\.\#\,]+$" ToolTip="Enter only alphanumaric and space (' - , . #)"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_EXp_designation" runat="server" CssClass="span11" Width="150px" MaxLength="50"></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" Width="6px"
                                                                                ToolTip="Enter Education" ValidationGroup="Exp" ControlToValidate="txt_EXp_designation"
                                                                                SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator58" ControlToValidate="txt_EXp_designation"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only Alphabets and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_total_exp" runat="server" CssClass="span11" Width="100px" MaxLength="5" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator65" ControlToValidate="txt_total_exp"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter Experience like 2, 1.11, 0.5"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_total_exp" Type="Double" ValidationGroup="Exp" MaximumValue="60" MinimumValue="0" ToolTip="Enter year between 0-60"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_exp_from" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressioalidator22" ControlToValidate="txt_exp_from"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            <asp:RangeValidator ID="RangeValidator5" runat="server" ControlToValidate="txt_exp_from" ValidationGroup="Exp" Type="Integer" MaximumValue="2200" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                            to
                                                                    <asp:TextBox ID="txt_exp_to" runat="server" CssClass="span11" Width="40px" MaxLength="4" onkeypress=" return isNumberKey(event)"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidat23" ControlToValidate="txt_exp_to"
                                                                                ValidationGroup="Exp" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            <asp:CompareValidator ID="CompareValidator17" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />' ControlToValidate="txt_exp_to"
                                                                                ControlToCompare="txt_exp_from" ValueToCompare="drptoyear" Display="Dynamic" Operator="GreaterThanEqual" ValidationGroup="Exp"></asp:CompareValidator>
                                                                            <asp:RangeValidator ID="RangeValidator4" runat="server" ControlToValidate="txt_exp_to" ValidationGroup="Exp" MaximumValue="2200" Type="Integer" MinimumValue="1920" ToolTip="Enter year between 1920-2200"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RangeValidator>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" OnRowDeleting="grid_exp_RowDeleting" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:HiddenField ID="hdf" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                                <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="30%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButwton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>&#160;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <script type="text/javascript">
                                                        function TrainingCompareDates() {
                                                            var DOJ = document.getElementById('<%=txtFromdate.ClientID %>');
                                                            var DOB = document.getElementById('<%=txtToDate.ClientID %>');
                                                            if (!(DOB.value < DOJ.value)) {
                                                                alert("Training From Date Should be lessthan Training To Date");
                                                                DOJ.focus();
                                                                return false;
                                                            }
                                                        }
                                                    </script>
                                                    <td class="frm-lft-clr-main">
                                                        <table width="100%">
                                                            <tr>
                                                                <td align="left">Training Details :</td>
                                                                <td align="right">
                                                                    <asp:Button ID="btn_Training" OnClick="btn_Training_add_Click" runat="server" Text="Add"
                                                                        CssClass="btn btn-info pull-right" ToolTip="Click here to add Training Details" ValidationGroup="Training"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="22%">Training Name<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="22%">Conducted By<span class="star"></span>
                                                                        </td>
                                                                        <td class="td-head" width="15%">From
                                                                        </td>
                                                                        <td class="td-head" width="17%">To
                                                                        </td>
                                                                        <td class="td-head" width="24%">Remarks
                                                                        
                                                                        
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_TrProgram" runat="server" CssClass="span11" MaxLength="90" Width="180px"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator15" runat="server" Width="6px" ToolTip="Enter  Traning program"
                                                                                ValidationGroup="Training" ControlToValidate="txt_TrProgram" SetFocusOnError="True"
                                                                                Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator59" ControlToValidate="txt_TrProgram"
                                                                                ValidationGroup="Training" runat="server" ValidationExpression="^[a-zA-Z0-9#+&_\s\(\)\-\.\\\/]+$" ToolTip="Enter only alphanumaric and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_TrConductedBy" runat="server" CssClass="span11" Width="180px" MaxLength="90"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator16" runat="server" Width="6px" ToolTip="Enter Conducted By"
                                                                                ValidationGroup="Training" ControlToValidate="txt_TrConductedBy" SetFocusOnError="True"
                                                                                Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator60" ControlToValidate="txt_TrConductedBy"
                                                                                ValidationGroup="Training" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumaric and space"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFromdate" runat="server" Width="70px" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image8" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender8" runat="server" PopupButtonID="Image8" TargetControlID="txtFromdate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtToDate" runat="server" Width="70px" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" onblur="return TrainingCompareDates();"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image9" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                    ID="CalendarExtender9" runat="server" PopupButtonID="Image9" TargetControlID="txtToDate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                            <%--  <asp:CompareValidator ID="CompareValidator12" runat="server" ControlToCompare="txtFromdate"
                                                                            Type="Date" ControlToValidate="txtToDate" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                            Operator="GreaterThanEqual" SetFocusOnError="True" ToolTip="Select valid date " ValidationGroup="Training"></asp:CompareValidator>--%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTrRemarks" runat="server" CssClass="span11" Width="180px" MaxLength="500">

                                                                            </asp:TextBox>
                                                                            <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator61" ControlToValidate="txtTrRemarks"
                                                                            ValidationGroup="Training" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumaric and space"
                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridTraning" runat="Server" Width="100%" OnRowDeleting="GridTraning_RowDeleting" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="trainingname"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTraning" runat="Server" Text='<%# Eval("trainingname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Conducted By" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblConductedBy" runat="Server" Text='<%# Eval("personname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="From" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("fromdate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="To" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltodate" runat="Server" Text='<%# Eval("todate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5">&#160;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" align="right">&nbsp;
                                                    </td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Personal Details -->
                                            <asp:UpdatePanel ID="updatepanel8" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" colspan="2">Personal Information
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="2">
                                                                <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td valign="top" width="50%">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Date of Birth
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                        <asp:TextBox ID="txt_DOB" runat="server" CssClass="span11" AutoPostBack="true" OnTextChanged="txt_dob_changed" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>

                                                                                        <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob" Format="dd-MMM-yyyy"
                                                                                            PopupButtonID="Image1">
                                                                                        </cc1:CalendarExtender>
                                                                                        <img src="../img/error1.gif" alt="" visible="false" id="imgerror" runat="server" />
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" style="height: 30px">Payment Mode
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtnbank" runat="server" AutoPostBack="true" Checked="true"
                                                                                                Text="Bank" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /></label>
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtncheque" runat="server" AutoPostBack="true" Checked="false" Text="Cheque"
                                                                                                GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /></label>
                                                                                        <label class="radio inline">
                                                                                            <asp:RadioButton ID="rbtncash" runat="server" AutoPostBack="true" Checked="false" Text="Cash"
                                                                                                GroupName="paymentmode" OnCheckedChanged="rbtncash_CheckedChanged" /></label>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Religion
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="54%">
                                                                                        <asp:TextBox ID="txtrelg" runat="server" CssClass="span11"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator44" ControlToValidate="txtrelg"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">D.L. No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_dl_no" runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator62" ControlToValidate="txt_dl_no"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="2">
                                                                <div id="paymentmode" runat="server" visible="true" align="center">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="50%">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td align="left" style="height: 30px" class="frm-lft-clr123" width="45%">Bank Name for Salary<span class="star"></span>
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123" width="55%">
                                                                                            <asp:DropDownList ID="ddl_bank_name" runat="server" CssClass="span11"
                                                                                                Height="" DataSourceID="SqlDataSource1" DataTextField="bankname" DataValueField="branchcode"
                                                                                                OnDataBound="ddl_bank_name_DataBound">
                                                                                            </asp:DropDownList>
                                                                                           <%-- <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="ddl_bank_name"
                                                                                                ErrorMessage='<img src="../img/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                                ToolTip="Select Employee Bank Name" ValidationGroup="v" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>--%><asp:SqlDataSource
                                                                                                    ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123">Bank Branch Name
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_bankbrachname" runat="server" CssClass="span11"></asp:TextBox>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator50" ControlToValidate="txt_bankbrachname"
                                                                                                ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td>
                                                                                <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123" width="45%">Account No. for Salary<span class="star"></span>
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123" width="54%">
                                                                                            <asp:TextBox ID="txt_bank_ac" runat="server" CssClass="span11" MaxLength="15"></asp:TextBox><%--<asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_bank_ac" Display="Dynamic"
                                                                                                SetFocusOnError="True" ToolTip="Employee Account Number for Salary" ValidationGroup="v"
                                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator42" ControlToValidate="txt_bank_ac"
                                                                                                ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td align="left" class="frm-lft-clr123">IFSC code
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_ifsc" runat="server" CssClass="span11" MaxLength="11"></asp:TextBox><asp:RequiredFieldValidator
                                                                                                ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_bank_ac_reimbursement"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Account Number for Reimbursement"
                                                                                                ValidationGroup="v" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator63" ControlToValidate="txt_ifsc"
                                                                                                ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"
                                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="a" runat="server" visible="false">
                                                                            <td align="left" class="frm-lft-clr123">Bank Name for Reimbursement
                                                                            </td>
                                                                            <td align="left" class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="ddl_bank_name_reimbursement" runat="server" CssClass="blue1"
                                                                                    DataSourceID="SqlDataSource2" DataTextField="bankname" DataValueField="branchcode"
                                                                                    OnDataBound="ddl_bank_name_reimbursement_DataBound">
                                                                                </asp:DropDownList>
                                                                                <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="ddl_bank_name_reimbursement"
                                                                                    ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;"
                                                                                    Operator="NotEqual" SetFocusOnError="True" ToolTip="Select Employee Bank Name"
                                                                                    ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator><asp:SqlDataSource
                                                                                        ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                            </td>
                                                                            <td>&#160;&nbsp;
                                                                            </td>
                                                                            <td align="left" class="frm-lft-clr123">Account No. for Reimbursement
                                                                            </td>
                                                                            <td align="left" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_bank_ac_reimbursement" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                                                    ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_bank_ac_reimbursement"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Account Number for Reimbursement"
                                                                                    ValidationGroup="v" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator43" ControlToValidate="txt_bank_ac_reimbursement"
                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="2">
                                                                <script type="text/javascript">
                                                                    function CompareDates() {
                                                                        var DOJ = document.getElementById('<%=txt_passportissueddate.ClientID %>');
                                                                        var DOB = document.getElementById('<%=txt_passportexpdate.ClientID %>');
                                                                        if (!(DOB.value < DOJ.value)) {
                                                                            alert("Passport Issued Date Should be lessthan Passport Expiry Date");
                                                                            DOJ.focus();
                                                                            return false;
                                                                        }
                                                                    }
                                                                </script>
                                                                <script type="text/javascript">
                                                                    function SpouseCompareDates() {
                                                                        var DOJ = document.getElementById('<%=txt_s_DOB.ClientID %>');
                                                                        var DOB = document.getElementById('<%=txt_doa.ClientID %>');
                                                                        if (!(DOB.value < DOJ.value)) {
                                                                            alert("Spouse Date of Birth   Should be lessthan Spouse Anniversary  Date");
                                                                            DOJ.focus();
                                                                            return false;
                                                                        }
                                                                    }
                                                                </script>
                                                                <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>

                                                                        <td valign="top" width="50%">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Personal Mobile No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                        <asp:TextBox ID="txtmobileno" runat="server" CssClass="span11" Width="" MaxLength="50"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Passport No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_passportno" runat="server" CssClass="span11" Width="" MaxLength="10"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator64" ControlToValidate="txt_passportno"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 ">Passport Expiry Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:TextBox ID="txt_passportexpdate" runat="server" CssClass="span11" onkeypress="return isNumber_slash();" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image7" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MMM-yyyy" TargetControlID="txt_passportexpdate"
                                                                                                PopupButtonID="Image7">
                                                                                            </cc1:CalendarExtender>
                                                                                        <%--   <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToCompare="txt_passportissueddate"
                                                                                            ControlToValidate="txt_passportexpdate" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                                                            ValidationGroup="v"></asp:CompareValidator>--%>
                                                                                        <%--                                                                                    <asp:CustomValidator ID="CompareValidator16" runat="server" ControlToCompare="txt_passportissueddate"
                                                                                        ControlToValidate="txt_passportexpdate" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                        Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date "
                                                                                        ValidationGroup="v"></asp:CustomValidator>--%>
                                                                                        <%--<asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txt_passportexpdate"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                                                            ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">T-Shirt Size
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddl_Tshirt" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">Select Size</asp:ListItem>
                                                                                            <asp:ListItem Value="38">38</asp:ListItem>
                                                                                            <asp:ListItem Value="39">39</asp:ListItem>
                                                                                            <asp:ListItem Value="40">40</asp:ListItem>
                                                                                            <asp:ListItem Value="42">42</asp:ListItem>
                                                                                            <asp:ListItem Value="44">44</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="45%">Personal Email Id
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="54%">
                                                                                        <asp:TextBox ID="txt_email" runat="server" CssClass="span11" Width="" MaxLength="50"></asp:TextBox><asp:RegularExpressionValidator
                                                                                            ID="RegularExpressionValidator1" runat="server" ValidationGroup="v" ToolTip="Not a Vaild Email ID"
                                                                                            SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_email" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                            ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Passport Issued Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_passportissueddate" runat="server" CssClass="span11" onkeypress="return isNumber_slash();"></asp:TextBox>&nbsp;<asp:Image
                                                                                            ID="Image10" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_passportissueddate"
                                                                                                PopupButtonID="Image10" Format="dd-MMM-yyyy">
                                                                                            </cc1:CalendarExtender>
                                                                                        <%-- <asp:CustomValidator ID="CompareValidator19" runat="server" ControlToCompare="txt_DOB"
                                                                                        ControlToValidate="txt_passportissueddate" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                                                        Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Passport Issued Date should not earler than Date of Birth"
                                                                                        ValidationGroup="v"></asp:CustomValidator>--%>
                                                                                        <%-- <asp:CompareValidator ID="CompareValidator22" runat="server" ControlToValidate="txt_passportissueddate"
                                                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                                                        ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px;">
                                                                                    <td class="frm-lft-clr123 ">Blood Group
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddlbloodgrp" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="A+">A+
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="A+VE">A+VE
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="A+ve">A+ve
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="B + ve">B + ve
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="B+VE">B+VE
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="Ab + ve">Ab + ve
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="AB +ve">AB +ve
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="AB+ve">AB+ve</asp:ListItem>
                                                                                            <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                                            <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                                            <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                                            <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                                            <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                                            <asp:ListItem Value="O+ve">O +ve</asp:ListItem>
                                                                                            <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                                            <asp:ListItem Value="A Rh Negative">A Rh Negative</asp:ListItem>
                                                                                            <asp:ListItem Value="A Rh Positive">A Rh Positive</asp:ListItem>
                                                                                            <asp:ListItem Value="A1+VE">A1+VE
                                                                                            </asp:ListItem>
                                                                                            <asp:ListItem Value="Ab Rh Positive">Ab Rh Positive</asp:ListItem>
                                                                                            <asp:ListItem Value="B Ah Positive">B Ah Positive</asp:ListItem>
                                                                                            <asp:ListItem Value="B Rh Negative">B Rh Negative</asp:ListItem>
                                                                                            <asp:ListItem Value="B Rh Positive">B Rh Positive</asp:ListItem>
                                                                                            <asp:ListItem Value="O Ah Positive">O Ah Positive</asp:ListItem>
                                                                                            <asp:ListItem Value="O Rh Positive">O Rh Positive</asp:ListItem>



                                                                                        </asp:DropDownList>
                                                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidatorsss0" ControlToValidate="txtbloodgrp"
                                                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z'+\-\s]+$" ToolTip="Enter only alphabets"
                                                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">Shirt Size
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddl_ShirtSize" runat="server" CssClass="span11">
                                                                                            <asp:ListItem Value="0">Select Size</asp:ListItem>
                                                                                            <asp:ListItem Value="S">S</asp:ListItem>
                                                                                            <asp:ListItem Value="M">M</asp:ListItem>
                                                                                            <asp:ListItem Value="L">L</asp:ListItem>
                                                                                            <asp:ListItem Value="XL">XL</asp:ListItem>
                                                                                            <asp:ListItem Value="XXL">XXL</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="txt02" colspan="2" height="5">Relationship Details
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td valign="top" width="50%">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td class="txt02" colspan="2">Father&apos;s Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Father Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                        <asp:TextBox ID="txt_f_f_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isChar_Space_dot_dash_ifin()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator25" ControlToValidate="txt_f_f_name"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr17" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_f_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator26" ControlToValidate="txt_f_mname"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr18" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_f_l_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator27" ControlToValidate="txt_f_l_name"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="txt02" colspan="2" height="5">Employee Marital Status
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Marital Status
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="ddlpersonalstatus" runat="server" CssClass="span11"
                                                                                            Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="Unmarried" Value="Unmarried"></asp:ListItem>
                                                                                            <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                                                                                            <asp:ListItem Text="Divorcee" Value="Divorcee"></asp:ListItem>
                                                                                            <asp:ListItem>Widow</asp:ListItem>
                                                                                            <asp:ListItem>Widower</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                <tr>
                                                                                    <td style="height: 13px" class="txt02" colspan="2">Mother&apos;s Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Mother Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_m_fname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isChar_Space_dot_dash_ifin()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator28" ControlToValidate="txt_m_fname"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr19" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_m_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator29" ControlToValidate="txt_m_mname"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr20" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_m_l_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator30" ControlToValidate="txt_m_l_name"
                                                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 12px" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tr>
                                                                        <td>
                                                                            <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                                visible="false">
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td valign="top" width="50%">
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td style="height: 13px" class="txt02" colspan="2">Spouse Detail
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="45%">Spouse Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="55%">
                                                                                                                <asp:TextBox ID="txt_sp_fname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isChar_Space_dot_dash_ifin()"></asp:TextBox>
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator31" ControlToValidate="txt_sp_fname"
                                                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr21" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123">Middle Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123">
                                                                                                                <asp:TextBox ID="txt_sp_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator32" ControlToValidate="txt_sp_mname"
                                                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr id="Tr22" runat="server" visible="false">
                                                                                                            <td class="frm-lft-clr123 border-bottom">Last Name
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:TextBox ID="txt_sp_lname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator33" ControlToValidate="txt_sp_lname"
                                                                                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Date of Anniversary
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                                                <asp:TextBox ID="txt_doa" runat="server" CssClass="span11" onkeypress="return enterdate(event);" onblur="return SpouseCompareDates();" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;<asp:Image
                                                                                                                    ID="Image2" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txt_doa" Format="dd-MMM-yyyy"
                                                                                                                    PopupButtonID="Image2">
                                                                                                                </cc1:CalendarExtender>
                                                                                                            </td>
                                                                                                        </tr>



                                                                                                    </table>
                                                                                                </td>
                                                                                                <td valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                        <tr>
                                                                                                            <td class="txt02" colspan="2" height="5">&#160;&nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123">Date of Birth
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                                                <asp:TextBox ID="txt_s_DOB" runat="server" CssClass="span11" Width="" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox><asp:Image
                                                                                                                    ID="Image14" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                <cc1:CalendarExtender ID="CalendarExtender14" runat="server" TargetControlID="txt_s_DOB" Format="dd-MMM-yyyy"
                                                                                                                    PopupButtonID="Image14">
                                                                                                                </cc1:CalendarExtender>

                                                                                                            </td>
                                                                                                        </tr>

                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123 border-bottom">Gender
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                                <asp:DropDownList ID="ddl_s_gender" runat="server" CssClass="blue1"
                                                                                                                    Width="">
                                                                                                                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                    <asp:ListItem>Male</asp:ListItem>
                                                                                                                    <asp:ListItem>Female</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td colspan="2" height="5"></td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td valign="top">
                                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                        <tr>
                                                                                                            <td style="height: 18px" class="txt02" colspan="3">Children Detail
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-lft-clr123" width="33%">Name<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td class="frm-lft-clr123" width="32%">Gender<span class="star"></span>
                                                                                                            </td>
                                                                                                            <td width="35%" class="frm-lft-clr123">Date of Birth<span class="star"></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td class="frm-rght-clr123 border-bottom" style="border-right: none" width="33%">
                                                                                                                <asp:TextBox ID="txt_child_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isChar_Space_dot_dash_ifin()"></asp:TextBox>
                                                                                                                <asp:RequiredFieldValidator
                                                                                                                    ID="Requfdgggsfsd" runat="server" Width="6px" ValidationGroup="child" ToolTip="Enter Education"
                                                                                                                    SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_child_name"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator34" ControlToValidate="txt_child_name"
                                                                                                                    ValidationGroup="child" runat="server" ValidationExpression="^[a-zA-Z\.\s]+$" ToolTip="Enter only alphabets"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                                                                <asp:DropDownList ID="ddl_child_gender" runat="server" CssClass="span11" Height=""
                                                                                                                    Width="100px">
                                                                                                                    <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                    <asp:ListItem>Male</asp:ListItem>
                                                                                                                    <asp:ListItem>Female</asp:ListItem>
                                                                                                                </asp:DropDownList>
                                                                                                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddl_child_gender"
                                                                                                                    ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                                                                                    SetFocusOnError="True" ToolTip="Select gender" ValidationGroup="child" ValueToCompare="0"></asp:CompareValidator>
                                                                                                            </td>
                                                                                                            <td class="frm-rght-clr123 border-bottom" width="35%">
                                                                                                                <table width="100%">
                                                                                                                    <tr>
                                                                                                                        <td align="left">
                                                                                                                            <asp:TextBox ID="txt_child_Dob" runat="server" CssClass="span11" Width="80px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Image ID="Image3" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_child_Dob" Format="dd-MMM-yyyy"
                                                                                                                                PopupButtonID="Image3">
                                                                                                                            </cc1:CalendarExtender>
                                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" Width="6px"
                                                                                                                                ValidationGroup="child" ToolTip="Enter Date of birth" SetFocusOnError="True"
                                                                                                                                Display="Dynamic" ControlToValidate="txt_child_Dob"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                                            <asp:CompareValidator ID="CompareValidator24" runat="server" ControlToCompare="txt_s_DOB" ControlToValidate="txt_child_Dob"
                                                                                                                                ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="GreaterThan"
                                                                                                                                SetFocusOnError="True" Type="Date" ToolTip="please enter correct date " ValidationGroup="child"></asp:CompareValidator>
                                                                                                                        </td>
                                                                                                                        <td align="right">
                                                                                                                            <asp:Button ID="btn_child_Add" OnClick="btn_child_Add_Click" runat="server" Text="Add"
                                                                                                                                CssClass="btn btn-info pull-right" ValidationGroup="child" ToolTip="Click hare to add children detail"></asp:Button>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </table>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td height="10px" colspan="3"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" colspan="3">
                                                                                                    <div class="widget-content">
                                                                                                        <asp:GridView ID="grid_child" runat="Server" Width="99%" OnRowDeleting="grid_child_RowDeleting" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderStyle-Width="9%">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandName="Delete" CssClass="link04"
                                                                                                                            Text="Delete"></asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top"></td>
                                                                                                <td valign="top"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2"></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 30px; height: 9px"></td>
                                                            <td style="height: 9px" align="right"></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" colspan="2"></td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </p>
                                    </div>
                                    <div>
                                        <p>
                                            <!-- Employee Upload Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" style="height: 13px">Upload Details
                                                    </td>
                                                    <td class="txt02" align="right">
                                                        <%-- <asp:CheckBox ID="ck_editlables" runat="server" Text="Edit Lables" AutoPostBack="True"
                                                                OnCheckedChanged="ck_editlables_CheckedChanged"></asp:CheckBox>
                                                            &nbsp;&nbsp;<asp:Button ID="btnSavedeflable" runat="server" Text="Save" OnClick="btnSavedeflable_Click" />&nbsp;--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">

                                                        <asp:Label ID="lbl_Default1" runat="server"></asp:Label><asp:TextBox ID="TextBox1"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <asp:FileUpload ID="File_UploadDft1" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                ControlToValidate="File_UploadDft1" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default2" runat="server"></asp:Label><asp:TextBox ID="TextBox2"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft2" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server"
                                                                ControlToValidate="File_UploadDft2" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default3" runat="server"></asp:Label><asp:TextBox ID="TextBox3"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft3" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server"
                                                                ControlToValidate="File_UploadDft3" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default4" runat="server"></asp:Label><asp:TextBox ID="TextBox4"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft4" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server"
                                                                ControlToValidate="File_UploadDft4" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default5" runat="server"></asp:Label><asp:TextBox ID="TextBox5"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft5" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server"
                                                                ControlToValidate="File_UploadDft5" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default6" runat="server"></asp:Label><asp:TextBox ID="TextBox6"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft6" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server"
                                                                ControlToValidate="File_UploadDft6" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default7" runat="server"></asp:Label><asp:TextBox ID="TextBox7"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft7" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server"
                                                                ControlToValidate="File_UploadDft7" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">

                                                        <asp:Label ID="lbl_Default8" runat="server"></asp:Label><asp:TextBox ID="TextBox8"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft8" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                                                ControlToValidate="File_UploadDft8" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        <asp:Label ID="lbl_Default9" runat="server"></asp:Label><asp:TextBox ID="TextBox9"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:FileUpload ID="File_UploadDft9" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                                                ControlToValidate="File_UploadDft9" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">
                                                        <asp:Label ID="lbl_Default10" runat="server"></asp:Label><asp:TextBox ID="TextBox10"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:FileUpload ID="File_UploadDft10" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                                ControlToValidate="File_UploadDft10" ValidationGroup="v" CssClass="txt-red" ErrorMessage="file not supported..."
                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>
                                    <div>
                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                <asp:Button ID="btngeneralsubmit" runat="server" align="right" CssClass="btn btn-info pull-right" OnClick="btngeneralsubmit_Click"
                    Text="Submit" ValidationGroup="v" />


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

    <script type="text/javascript">
        $("#wizard").bwizard();
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
