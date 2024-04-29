<%@ Page Language="C#" AutoEventWireup="true" CodeFile="empmaster.aspx.cs" Inherits="Admin_company_empmaster"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee Master View" %>

<%--<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star:before {
            color: red !important;
            content: "*";
            font: bold;
        }

        .auto-style2 {
            font-style: normal;
            font-variant: normal;
            font-weight: bold;
            font-size: 11px;
            line-height: normal;
            font-family: verdana, Helvetica, sans-serif;
            color: #555;
            width: 35%;
            border-left: 1px solid #d9d9d9;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-top: 1px solid #d9d9d9;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
            padding: 9px;
            background: #fafafa;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Details</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>Create
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" width="100%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <asp:UpdatePanel ID="kk" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:UpdateProgress ID="UpdateProgress3" runat="server" AssociatedUpdatePanelID="kk"
                                                                        DisplayAfter="1">
                                                                        <ProgressTemplate>
                                                                            <div class="modal-backdrop fade in">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td align="center" valign="top">
                                                                                            <img src="../img/loading.gif" />
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                </table>
                                                                            </div>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td colspan="2" class="txt02"><b>Employee Information</b>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5px"></td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">Title<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:DropDownList ID="ddlSalutation" runat="server" CssClass="span11" OnSelectedIndexChanged="ddlSalutation_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="Mr">MR</asp:ListItem>
                                                                                    <asp:ListItem Value="Ms">MS</asp:ListItem>
                                                                                    <asp:ListItem Value="Mrs">MRS</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlSalutation"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Title" ValidationGroup="e" InitialValue="0"
                                                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <asp:HiddenField ID="HiddenTodayDate" runat="server" />
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">Employee Name<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:TextBox ID="txtfirstname" runat="server" placeholder="Max 50 Char" CssClass="span11" MaxLength="50" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfirstname"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Name Required" ValidationGroup="e"
                                                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="height: 66px">
                                                                            <td class="frm-lft-clr123 border-bottom">Gender<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:DropDownList ID="drpgender" runat="server" CssClass="span11" OnSelectedIndexChanged="drpgender_SelectedIndexChanged" AutoPostBack="true">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="MALE">MALE</asp:ListItem>
                                                                                    <asp:ListItem Value="FEMALE">FEMALE</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drpgender"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Gender" ValidationGroup="e"
                                                                                    InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr1" style="height: 50px" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123" width="48%">Middle Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:TextBox ID="txtmiddlename" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr2" style="height: 50px" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Last Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                <asp:TextBox ID="txtlastname" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td height="18px"></td>
                                                                </tr>
                                                                <tr style="height: 50px">
                                                                    <td colspan="2">
                                                                        <asp:UpdatePanel ID="upempcode" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="upempcode"
                                                                                    DisplayAfter="1">
                                                                                    <ProgressTemplate>
                                                                                        <div class="modal-backdrop fade in">
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
                                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0" align="right">
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123" width="47%">Employee Code<span class="star"></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="53%">
                                                                                            <asp:TextBox ID="txtempcode" runat="server" CssClass="span11" placeholder="Max 50 Char" MaxLength="50" OnTextChanged="txtempcode_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtempcode"
                                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code Required" ValidationGroup="e"
                                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                            <asp:HiddenField ID="hdnpassword" runat="server" />
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>


                                                                <tr style="height: 50px">
                                                                    <td width="47%" class="frm-lft-clr123 border-bottom">Employee No.<span class="star"></span>
                                                                    </td>
                                                                    <td width="53%" class="frm-rght-clr123 border-bottom">
                                                                        <asp:TextBox ID="txt_card_no" runat="server" CssClass="span11" placeholder="Max 50 Char" MaxLength="50"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_card_no"
                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Employee No. Required" ValidationGroup="e"
                                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 50px">
                                                                    <td width="47%" class="frm-lft-clr123 border-bottom">Employee Photo
                                                                    </td>
                                                                    <td width="53%" class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lblphoto" runat="server"></asp:Label>
                                                                        <asp:FileUpload ID="empphoto" runat="server" ToolTip="Upload File here" CssClass="span11" />&nbsp;
                                                <%--<asp:RegularExpressionValidator ID="regphoto" runat="server" ControlToValidate="empphoto"
                                                    ValidationGroup="v" CssClass="txt-red" Display="Dynamic" ErrorMessage="file not supported..." ValidationExpression="^.+(.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>--%>
                                                                        <asp:RegularExpressionValidator ID="regphoto" runat="server" ControlToValidate="empphoto"
                                                                            ValidationGroup="v" CssClass="txt-red" Display="Dynamic" ErrorMessage="file not supported..." ValidationExpression="^.+(.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF|.jpeg|.JPEG)$"></asp:RegularExpressionValidator>
                                                                        <asp:HiddenField ID="hdnphoto" runat="server" Value="" />
                                                                        <p style="color: red">(Supported Files are png,bmp,jpg,gif,jpeg)</p>
                                                                    </td>

                                                                </tr>

                                                                <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>Create
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li id="li_tabs_job"><a>Job Details</a></li>
                                        <li id="li_tabs_approver">Approver Details</li>
                                        <li id="li_tabs_contact">Contact Details</li>
                                        <li id="li_tabs_pro">Qualification & Experience Details</li>
                                        <li id="li_tabs_per">Personal Detail</li>
                                        <%-- <li id="li1">Health</li>--%>
                                        <li id="li_tabs_upload">Upload Documents</li>
                                    </ol>
                                    <div>
                                        <p>
                                            <!-- Job Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">




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
                                                                                    <div class="modal-backdrop fade in">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
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
                                                                            <table width="100%" cellspacing="0" cellpadding="0">
                                                                                <tr id="Tr3" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123"><%--Broad Group--%> Business Unit<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_broadgroup" runat="server" CssClass="span11">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%> Work Location<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpbranch" runat="server" CssClass="span11" Height="" Width=""
                                                                                            DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                                            OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                        <asp:SqlDataSource
                                                                                            ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="drpbranch"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Department Type<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdepartmenttype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdepartmenttype_SelectedIndexChanged" CssClass="span11" Height=""
                                                                                            Width="230px" OnDataBound="drpdepartmenttype_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="drpdepartmenttype"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department Type" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Department<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdepartment_SelectedIndexChanged1" CssClass="span11" Height=""
                                                                                            Width="230px" OnDataBound="drpdepartment_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drpdepartment"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                    </td>
                                                                                </tr>




                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Designation<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdegination" runat="server" CssClass="span11" OnDataBound="drpdegination_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <%-- <asp:SqlDataSource ID="sql_data_degination"
                                                                                            runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="drpdegination"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Designation" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr4" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Grade
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpgrade" runat="server" CssClass="span11" DataSourceID="sql_data_grade"
                                                                                            DataTextField="gradename" DataValueField="id" OnDataBound="drpgrade_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <asp:SqlDataSource ID="sql_data_grade" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [gradename] FROM [tbl_intranet_grade]"></asp:SqlDataSource>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpgrade"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Grade" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr5" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:DropDownList ID="drpdivision" runat="server" CssClass="span11" Height=""
                                                                                            Width="" DataSourceID="SqlDatasource_division" DataTextField="division_name"
                                                                                            DataValueField="ID" OnDataBound="drpdivision_DataBound">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        </asp:DropDownList>
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
                                                                                <tr id="Tr6" style="height: 50px" runat="server" visible="false">
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
                                                                                    <td width="48%" class="frm-lft-clr123">Employee Role<span class="star"></span>
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drprole" runat="server" Height="" CssClass="span11" Width=""
                                                                                            DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound">
                                                                                        </asp:DropDownList>

                                                                                        <asp:SqlDataSource
                                                                                            ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] where id not in (16)"></asp:SqlDataSource>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="drprole"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Role" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123  border-bottom" width="48%">Employee Status<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:UpdatePanel ID="upd" runat="server" UpdateMode="Conditional">
                                                                                            <ContentTemplate>
                                                                                                <asp:UpdateProgress ID="UpdateProgress16" runat="server" AssociatedUpdatePanelID="upd">
                                                                                                    <ProgressTemplate>
                                                                                                        <div class="modal-backdrop fade in">
                                                                                                            <table width="100%">
                                                                                                                <tr>
                                                                                                                    <td align="center" valign="top">
                                                                                                                        <img src="../img/loading.gif" />
                                                                                                                    </td>
                                                                                                                </tr>

                                                                                                            </table>
                                                                                                        </div>
                                                                                                    </ProgressTemplate>
                                                                                                </asp:UpdateProgress>

                                                                                                <asp:DropDownList ID="drpempstatus" runat="server" CssClass="span11" Height=""
                                                                                                    Width="" DataSourceID="sql_data_status" DataTextField="employeestatus" DataValueField="id"
                                                                                                    OnDataBound="drpempstatus_DataBound" AutoPostBack="true" OnSelectedIndexChanged="drpempstatus_SelectedIndexChanged1">
                                                                                                </asp:DropDownList>
                                                                                                <asp:SqlDataSource
                                                                                                    ID="sql_data_status" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id],[employeestatus] FROM tbl_intranet_employee_status"></asp:SqlDataSource>
                                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="drpempstatus"
                                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Status" ValidationGroup="e"
                                                                                                    InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="drpempstatus" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr id="trprobationperiod" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_probationperiod" runat="server" CssClass="span11" placeholder="Max 2 Char"
                                                                                            MaxLength="2" AutoPostBack="true" onkeypress=" return isNumberKey(event)" OnTextChanged="txt_probationperiod_TextChanged"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptstart" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_deput_start_date" runat="server" placeholder="dd-MMM-yyyyy" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        &nbsp;
                                                                                <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                                                                            TargetControlID="txt_deput_start_date" Enabled="True" Format="dd-MMM-yyyy" PopupPosition="BottomRight">
                                                                                        </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trprobationdate3" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom"><%--Confirmation Date--%>
                                                                                        <asp:Label ID="lblprob" runat="server"></asp:Label><span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_confirmationdate" runat="server" placeholder="dd-MMM-yyyyy" CssClass="span10" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image13" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy" PopupPosition="BottomRight"
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
                                                                                        <asp:TextBox ID="txtdol" runat="server" CssClass="span10" placeholder="dd-MMM-yyyyy" onblur="return JobCompareDates();" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                    ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtdol"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trReasonL" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Reason for Leaving
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txtreason" runat="server" CssClass="span11" MaxLength="200" placeholder="Max 200 Chars" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="drpempstatus" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress15" runat="server" AssociatedUpdatePanelID="UpdatePanel9"
                                                                                DisplayAfter="1">
                                                                                <ProgressTemplate>
                                                                                    <div class="modal-backdrop fade in">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                <tr style="height: 50px">
                                                                                    <td colspan="2">
                                                                                        <asp:UpdatePanel ID="upl" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:UpdateProgress ID="UpdateProgress13" runat="server" AssociatedUpdatePanelID="upl"
                                                                                                    DisplayAfter="1">
                                                                                                    <ProgressTemplate>
                                                                                                        <div class="modal-backdrop fade in">
                                                                                                            <table width="100%">
                                                                                                                <tr>
                                                                                                                    <td align="center" valign="top">
                                                                                                                        <img src="../img/loading.gif" />
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </div>
                                                                                                    </ProgressTemplate>
                                                                                                </asp:UpdateProgress>
                                                                                                <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0" style="height: 50px">
                                                                                                    <tr>
                                                                                                        <td class="frm-lft-clr123" width="48%">Date of Joining<span class="star"></span>
                                                                                                        </td>
                                                                                                        <td class="frm-rght-clr123" width="51%">
                                                                                                            <asp:TextBox ID="doj" runat="server" CssClass="span11" placeholder="dd-MMM-yyyyy" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&#160;<asp:Image ID="Image4" runat="server"
                                                                                                                ImageUrl="~/img/clndr.gif" placeholder="Select Date" />

                                                                                                            <cc1:CalendarExtender Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                                                ID="CalendarExtender4" runat="server" PopupButtonID="Image4" TargetControlID="doj"
                                                                                                                Enabled="True">
                                                                                                            </cc1:CalendarExtender>
                                                                                                            <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="doj"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Date of Joining Required"
                                                ValidationGroup="e" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>

                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr7" style="height: 50px;" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Salary Calculation From <span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txtsalary" placeholder="Select Date" runat="server" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        <asp:Image ID="Image6" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="Image6" Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                            TargetControlID="txtsalary" Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Official Mobile No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                        <asp:TextBox ID="txtcountrycode" Width="30px" placeholder="Max 4 Chars" runat="server" MaxLength="4" onkeypress="return ValidatePhoneNo()">+91</asp:TextBox>&nbsp;
                                                                                        <asp:TextBox ID="txtoff_mobileno" Width="177px" placeholder="Max 10 No" runat="server" CssClass="span11" MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Official Email Id <span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="txt_officialemail" placeholder="Max 50 Chars" runat="server" CssClass="span11"
                                                                                            MaxLength="50"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator34" runat="server" ControlToValidate="txt_officialemail"
                                                                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Email Id Required"
                                                                                            ValidationGroup="e" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                                            ValidationGroup="e" ToolTip="Invalid Format" SetFocusOnError="True" Display="Dynamic"
                                                                                            ControlToValidate="txt_officialemail" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                        <%---<asp:RegularExpressionValidator ID="RegularExpressionValidatormailId" runat="server"
                                                                                    ControlToValidate="txt_officialemail" ToolTip="Please Enter Correct Email Id"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><img src="../img/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtcity"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter City" ValidationGroup="c"
                                                                                    Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Employee Type<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                        <%--<asp:DropDownList ID="ddl_emp_type" runat="server"
                                                                                    CssClass="blue1">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Corporate</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Factory</asp:ListItem>
                                                                                </asp:DropDownList>--%>

                                                                                        <asp:DropDownList ID="ddl_emp_type" runat="server" CssClass="span11" Height="" Width=""
                                                                                            DataSourceID="sql_emp_type" DataTextField="emp_type_name" DataValueField="emp_type_id"
                                                                                            OnDataBound="ddl_emp_type_DataBound1" AutoPostBack="True" OnSelectedIndexChanged="ddl_emp_type_SelectedIndexChanged1">
                                                                                        </asp:DropDownList>
                                                                                        <asp:SqlDataSource
                                                                                            ID="sql_emp_type" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="select emp_type_id,emp_type_name from dbo.tbl_internate_employee_type"></asp:SqlDataSource>
                                                                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddl_emp_type"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Type" ValidationGroup="e"
                                                                                    InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Employee Sub Type<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                        <asp:DropDownList ID="ddl_semp_type" runat="server" CssClass="span11" Height="" Width=""
                                                                                            OnDataBound="ddl_semp_type_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddl_semp_type_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddl_semp_type"
                                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Employee Sub Type" ValidationGroup="e"
                                                                                    InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom">Ext. No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txtextccode" runat="server" Width="30px" placeholder="Max 4 No" MaxLength="4" onkeypress="return ValidatePhoneNo()">+91</asp:TextBox>
                                                                                        <asp:TextBox ID="txtextstdcode" runat="server" Width="50px" placeholder="Max 5 No" MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                        <asp:TextBox ID="txtext" runat="server" CssClass="span11" Width="114px" placeholder="Max 10 No"
                                                                                            MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px; display: none">
                                                                                    <td class="frm-lft-clr123"><%--Immediate Supervisor Name--%>Reporting Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="ddl_supervisor" runat="server" CssClass="span11"
                                                                                            Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px; display: none">
                                                                                    <td class="frm-lft-clr123 "><%--Corporate Reporting Name--%> Functional Manager
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddl_corp_report_name" runat="server" CssClass="span11"
                                                                                            Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px; display: none">
                                                                                    <td class="frm-lft-clr123 "><%--Manager Name--%>Unit Head
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 ">
                                                                                        <asp:DropDownList ID="ddl_hod" runat="server" CssClass="span11" Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px; display: none">
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
                                                                                        <asp:TextBox ID="txt_probation_date" runat="server" CssClass="span11" placeholder="Max 3 Chars"
                                                                                            MaxLength="3"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptenddate" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Deputation End Date<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_deput_end_date" runat="server" CssClass="span11" placeholder="Select Date.." Width="180" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12" Format="dd-MMM-yyyy"
                                                                                            TargetControlID="txt_deput_end_date" Enabled="True">
                                                                                        </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trprobationdate2" runat="server" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Notice Period
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                        <asp:TextBox ID="txt_noticePeriod" runat="server" CssClass="span11" onkeypress="return IsNumeric(event);" placeholder="Max 2 No"
                                                                                            MaxLength="2"></asp:TextBox>

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
                                                    <td colspan="2" class="txt02">Payroll Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="dd" runat="server" UpdateMode="Conditional">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="dd"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td id="Td1" class="frm-lft-clr123 " width="48%" runat="server">CTC Per Annum
                                                                                    </td>
                                                                                    <td id="Td2" class="frm-rght-clr123  " width="52%" runat="server">
                                                                                        <asp:TextBox ID="ward" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 No" onkeypress="return IsNumeric(event);"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">PF No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="pfno" runat="server" CssClass="span11" MaxLength="30" placeholder="Max 30 No"></asp:TextBox>


                                                                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server"
                                                                                    ControlToValidate="pfno" ToolTip="Please Enter Correct pf num"
                                                                                    ValidationExpression="^[a-zA-Z0-9/]"><img src="../img/error1.gif" alt="" /></asp:RegularExpressionValidator>--%>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">PAN No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="panno" runat="server" CssClass="span11" MaxLength="10" placeholder="Max 10 Chars"></asp:TextBox>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="panno"
                                                                                            CssClass="txt-red" Display="Dynamic" ToolTip="Invalid PAN Number" ErrorMessage='<img src="../images/error1.gif" alt="not vaild pan" />'
                                                                                            ValidationExpression="[A-Z]{5}\d{4}[A-Z]{1}$"
                                                                                            ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Format not supported" /></asp:RegularExpressionValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">UAN No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_uan" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td colspan="2" style="height: 5px"></td>
                                                                                </tr>
                                                                                <tr id="trptno" runat="server" visible="False">
                                                                                    <td id="Td3" class="frm-lft-clr123" runat="server">PT No.
                                                                                    </td>
                                                                                    <td id="Td4" class="frm-rght-clr123" runat="server">
                                                                                        <asp:TextBox ID="txt_ptno" runat="server" CssClass="span11" MaxLength="50" placeholder="Max 50 Chars"></asp:TextBox>
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
                                                                                        <asp:TextBox ID="esidesp" runat="server" CssClass="span11" MaxLength="100" placeholder="Max 100 Chars"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123" width="48%">PF Region Office
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 " width="51%">
                                                                                        <asp:TextBox ID="pfno_dept" runat="server" CssClass="span11" MaxLength="50" placeholder="Max 50 Chars"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">ESI No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:TextBox ID="esino" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <div class="form-actions no-margin">
                                                                                <%--Here History Of Employee Will Be Saved Onclick--%>
                                                                                <asp:Button ID="btnjob" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnjob_Click1" ValidationGroup="e" />
                                                                                <%--OnClientClick="return ValidateData();"--%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
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
                                            <!-- Approver Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table3">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upapprobver" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="upapprobver"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>

                                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                                    <tr>
                                                                        <td colspan="2" class="txt02" style="height: 25px">Approver Information
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td colspan="2" width="100%">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td width="50%" valign="top">

                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">Line Manager <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txtreportmanager" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtreportmanager"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Dotted Line Manager <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtdottedlinemanager" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtdottedlinemanager"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Dotted Line Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=50&empcode=<%=txtempcode.Text.ToString() %>');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">Business Head <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txtbusinesshead" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtbusinesshead"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Business Head" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=14&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">Finance Manager <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 " width="52%">
                                                                                                    <asp:TextBox ID="txtfncmang" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txtfncmang"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Finance Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=11&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123  border-bottom" width="47%"><%--Network Administration Clearance--%>IT Manager<span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtnetworkclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ControlToValidate="txtnetworkclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select IT Manager" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=NAC');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom " width="45%">Virtual Head <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtdeptclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtdeptclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Virtual Head" ValidationGroup=""
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=DC');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>

                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 " width="45%">Admin <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 " width="52%">
                                                                                                    <asp:TextBox ID="txtadmin" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtadmin"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Admin" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=12&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">HR-TA <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txthr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txthr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select HR-TA" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=9&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">HR-C&B <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txthrcb" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txthrcb"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select HR-C&B" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=51&empcode=<%=txtempcode.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">HR-BP <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txthrd" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txthrd"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select HR-BP" ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=15&empcode=<%=txtempcode.Text.ToString() %>');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Management/MD <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtmng" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txtmng"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Management/MD " ValidationGroup="d"
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx?role=10&empcode=<%=txtempcode.Text.ToString() %>');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>

                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="15" colspan="2"></td>
                                                                    </tr>
                                                                    <tr runat="server" visible="false">
                                                                        <td colspan="2" class="txt02">Clearance   Information
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height="5" colspan="2"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" width="100%">
                                                                            <table width="100%" border="0" cellspacing="0" runat="server" cellpadding="0" visible="false">
                                                                                <tr>
                                                                                    <td width="50%" valign="top">
                                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">


                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">General Administration Clearance <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txtadminclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ControlToValidate="txtadminclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select General Administration Clearance " ValidationGroup=""
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=GAC');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Accounts Department Clearance <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtaccdeptclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ControlToValidate="txtaccdeptclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Accounts Department Clearance" ValidationGroup=""
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=ADC');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>


                                                                                        </table>

                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">

                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123" width="45%">HR Department Clearance <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="52%">
                                                                                                    <asp:TextBox ID="txthrdeptclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ControlToValidate="txthrdeptclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select HR Department Clearance " ValidationGroup=""
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=HRC');"><i class="icon-user"></i></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">User Account Deletion Request <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                                    <asp:TextBox ID="txtaccdeleclr" runat="server" Enabled="false"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ControlToValidate="txtaccdeleclr"
                                                                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select User Account Deletion Request" ValidationGroup=""
                                                                                                        Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <a href="JavaScript:newPopup1('pickhr.aspx?role=ACDC');"><i class="icon-user"></i></a>
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
                                                                        <td colspan="2">
                                                                            <div class="form-actions no-margin">
                                                                                <asp:Button ID="btnapprover" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnapprover_Click" ValidationGroup="d" Height="28px" />
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <!-- Contact Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs2">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress6" runat="server" AssociatedUpdatePanelID="UpdatePanel2"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <div>
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="" border="0">
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
                                                                                                        <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="span12" MaxLength="1000" placeholder="Max 1000 Chars" Style="border: 1px solid #ddd; height: 60px; font-size: 14px" TextMode="MultiLine" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr8" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr9" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr10" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_pre_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr11" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_pre_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr12" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="span11" Width="" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr13" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="span11" Width="" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

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
                                                                                                        <asp:TextBox ID="txt_per_add1" runat="server" CssClass="span11" Width="" placeholder="Max 1000 Chars" Style="border: 1px solid #ddd; font-size: 14px; height: 60px" TextMode="MultiLine" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr14" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_add2" runat="server" CssClass="span11" Width="" MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr15" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Country
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_country" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" OnSelectedIndexChanged="ddl_per_country_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr16" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">State
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_state" runat="server" CssClass="span11" Width=""
                                                                                                            AutoPostBack="true" Height="" OnSelectedIndexChanged="ddl_per_state_SelectedIndexChanged">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr17" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">City
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:DropDownList ID="ddl_per_city" runat="server" CssClass="span11" Width=""
                                                                                                            Height="">
                                                                                                        </asp:DropDownList>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr18" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Zip Code
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_zip" runat="server" CssClass="span11" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr19" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123">Phone No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_per_phone" runat="server" CssClass="span11" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="width: 100%">
                                                                                <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 10px"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02">Emergency Contact Information:
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td width="100%" valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="50%">Contact Name<span class="star"></span>
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="50%"><%--onblur="capitalizeMe(this);"--%>
                                                                                                        <asp:TextBox ID="txt_emergency_name" placeholder="Max 50 Chars" runat="server" CssClass="span7" Width="" onkeydown="return isAlpha(event.keyCode);"
                                                                                                            MaxLength="50"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator30" runat="server" ControlToValidate="txt_emergency_name"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Contact Name Required" ValidationGroup="f"
                                                                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="50%">Relationship<span class="star"></span>
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="50%">

                                                                                                        <asp:DropDownList ID="drp_emg_relation" runat="server" CssClass="span7">
                                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                            <asp:ListItem Value="Spouse"> Spouse</asp:ListItem>
                                                                                                            <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                                                                                                            <asp:ListItem Value="Son">Son</asp:ListItem>
                                                                                                            <asp:ListItem Value="Father">Father</asp:ListItem>
                                                                                                            <asp:ListItem Value="Mother">Mother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother">Brother</asp:ListItem>
                                                                                                            <asp:ListItem Value="Friend">Friend</asp:ListItem>
                                                                                                            <asp:ListItem Value="Brother In law">Brother In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister In law">Sister In law</asp:ListItem>
                                                                                                            <asp:ListItem Value="Sister">Sister</asp:ListItem>
                                                                                                            <asp:ListItem Value="Uncle">Uncle</asp:ListItem>
                                                                                                            <asp:ListItem Value="Aunt">Aunt</asp:ListItem>
                                                                                                            <asp:ListItem Value="Neighbour">Neighbour</asp:ListItem>
                                                                                                            <asp:ListItem Value="Others">Others</asp:ListItem>
                                                                                                        </asp:DropDownList>

                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator31" runat="server" ControlToValidate="drp_emg_relation"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Relationship" ValidationGroup="f"
                                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="50%">Contact No.<span class="star"></span>
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="50%">
                                                                                                        <asp:TextBox ID="txt_emg_ccode" runat="server" CssClass="span2" onkeypress="return IsNumeric(event);" placeholder="Max 4 No" MaxLength="4">+91</asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emergency_contactno" runat="server" Style="width: 42%" placeholder="Max 10 No"
                                                                                                            MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txt_emergency_contactno"
                                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Contact No. Required" ValidationGroup="f"
                                                                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>




                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123 border-bottom" width="50%">LandLine No.
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123 border-bottom" width="50%">
                                                                                                        <asp:TextBox ID="txt_emg_landcode" runat="server" CssClass="span2" placeholder="Max 4 No" MaxLength="4" onkeypress="return IsNumeric(event);">+91</asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlinestdcode" Style="width: 13%" onkeypress="return IsNumeric(event);" runat="server" placeholder="Max 5 No" MaxLength="5"></asp:TextBox>
                                                                                                        <asp:TextBox ID="txt_emg_landlineno" runat="server" Style="width: 25.5%" placeholder="Max 10 No"
                                                                                                            MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>

                                                                                                    <td class="frm-rght-clr123 border-bottom" colspan="2" align="right">
                                                                                                        <%-- <asp:Button ID="btnemgcontact" runat="server" Text="Add" OnClick="btnemgcontact_Click" CssClass="btn btn-primary pull-right" ValidationGroup="d"/><%--OnClientClick="return ValidateEmg();"--%>
                                                                                                        <asp:Button ID="btnemgcontact" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnemgcontact_Click1" ValidationGroup="f" />

                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr id="Tr23" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="50%">Address 1
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="50%">
                                                                                                        <asp:TextBox ID="txt_emergency_address" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr id="Tr24" runat="server" visible="false">
                                                                                                    <td class="frm-lft-clr123" width="45%">Address 2
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="55%">
                                                                                                        <asp:TextBox ID="txt_emergency_address2" runat="server" CssClass="span11" Width=""
                                                                                                            MaxLength="1000" onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>

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
                                                                            <td colspan="5">
                                                                                <div class="widget-content">
                                                                                    <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                        OnRowDeleting="gvemgcontact_RowDeleting" AutoGenerateColumns="False" AllowSorting="True"
                                                                                        CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact Relation">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact No. ">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. LandLine No.">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton
                                                                                                        ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="&lt;img src='../images/download_delete.png'/&gt;" Width="38px"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                    </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td valign="top" width="50%">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="txt02">Transport Information:
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="10"></td>
                                                                                    </tr>
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="50%">Mode of Transport
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="50%">
                                                                                            <label class="radio inline">
                                                                                                <table>
                                                                                                    <tr>
                                                                                                        <td style="width: 70px">
                                                                                                            <asp:RadioButton ID="optown" runat="server" Text="Own" GroupName="mode" Checked="true" AutoPostBack="True"
                                                                                                                OnCheckedChanged="optown_CheckedChanged" />
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:RadioButton ID="optcompany" runat="server" Text="Company Vehicle"
                                                                                                                GroupName="mode" AutoPostBack="True" OnCheckedChanged="optcompany_CheckedChanged" /></td>
                                                                                                </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr style="height: 50px" id="pick" runat="server">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="45%">
                                                                                            <asp:Label ID="lblpickuppoint" runat="server" Visible="true" Text="Pickup Point"></asp:Label>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="55%" id="modeoftransp" runat="server">
                                                                                            <asp:TextBox ID="txtmodeoftransport" CssClass="span9" runat="server" MaxLength="50" placeholder="Max 50 Chars"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td colspan="2" height="5"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                            <td valign="top">
                                                                                <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </div>
                                                                <br />
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btncontact" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btncontact_Click" OnClientClick="return ValidateContact();" />
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
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="li_tabs3">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress7" runat="server" AssociatedUpdatePanelID="updatepannel2d"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%">
                                                                    <tr class="frm-lft-clr-main">
                                                                        <td align="left">&nbsp;Educational Information :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_quali_add" OnClick="btn_quali_add_Click" runat="server" Text="Add" OnClientClick="return ValidateEducation();"
                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Educational Qualification"></asp:Button></td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">

                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">School / Institute / University Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-rght-clr12345">
                                                                            <asp:DropDownList ID="drp_edu_qualification" runat="server" CssClass="span11" OnSelectedIndexChanged="drp_edu_qualification_SelectedIndexChanged" AutoPostBack="true">
                                                                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                <asp:ListItem>Matric(10th)</asp:ListItem>
                                                                                <asp:ListItem>Intermediate(12th)</asp:ListItem>
                                                                                <asp:ListItem>Diploma</asp:ListItem>
                                                                                <asp:ListItem>Graduation</asp:ListItem>
                                                                                <asp:ListItem Value="others">Others</asp:ListItem>
                                                                            </asp:DropDownList>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedu_specilazation" placeholder="Max 100 Char" runat="server" CssClass="span11" MaxLength="100" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedush" runat="server" placeholder="Max 150 Char" CssClass="span11" MaxLength="150" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduper" runat="server" placeholder="Max 5 Char" CssClass="span11" MaxLength="5"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtedufrom" runat="server" placeholder="Max 4 Char" CssClass="span5" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                            to
                                                                    <asp:TextBox ID="txteduto" runat="server" CssClass="span5" placeholder="Max 4 Char" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr id="div_Edu_Qual_others" runat="server">
                                                                        <td class="frm-rght-clr12345">
                                                                            <asp:TextBox ID="txt_Edu_Qual_others" placeholder="Max. 50 Char" runat="server" CssClass="span11" Width="180px" MaxLength="50" onblur="capitalizeMe(this);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                        </td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                                                                    ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="&lt;img src='../images/download_delete.png'/&gt;" Width="35px"></asp:LinkButton>
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
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress8" runat="server" AssociatedUpdatePanelID="UpdatePanel3"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">&nbsp;Professional/Technical Information :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_pro_qual_add" OnClick="btn_pro_qual_add_Click" runat="server" OnClientClick="return ValidateProfessional();"
                                                                                Text="Add" CssClass="btn btn-primary" ToolTip="Click here to add Professional Qualification"
                                                                                ValidationGroup="pro_edu"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="21%">Education<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="17%">Specialization
                                                                        </td>
                                                                        <td class="td-head" width="30%">Institute / University Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="10%">Grade / %
                                                                        </td>
                                                                        <td class="td-head" width="22%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txteduc1" runat="server" placeholder="Max 150 Char" CssClass="span11" Width="165px" MaxLength="150" onblur="capitalizeMe(this);">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtpro_specilazation" placeholder="Max 100 Char" runat="server" CssClass="span11" Width="120px" MaxLength="100" onblur="capitalizeMe(this);"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtsch1" runat="server" placeholder="Max 100 Char" CssClass="span11" Width="240px" MaxLength="100" onblur="capitalizeMe(this);">
                                                                            </asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtper1" runat="server" placeholder="Max 5 Char" CssClass="span11" Width="60px" MaxLength="5"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtfrm1" runat="server" placeholder="Max 4 Char" CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>


                                                                            to
                                                                    <asp:TextBox ID="txtto1" runat="server" placeholder="Max 4 Char" CssClass="span11" Width="60px" MaxLength="4" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" OnRowDeleting="grid_Pro_education_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress9" runat="server" AssociatedUpdatePanelID="UpdatePanel4"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">&nbsp;Experience Information :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_exp_add" OnClick="btn_exp_add_Click" runat="server" Text="Add"
                                                                                CssClass="btn btn-primary" ValidationGroup="c" OnClientClick="return ValidateCompany()"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="18%">Company Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="28%">Address / Location
                                                                        </td>
                                                                        <td class="td-head" width="20%">Designation<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="15%">Total Exp.(in years)
                                                                        </td>
                                                                        <td class="td-head" width="18%">Year 
                                                                    
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="txtcomp1" runat="server" CssClass="span11" Width="140px" MaxLength="100" placeholder="Max 100 Char" onblur="capitalizeMe(this);"></asp:TextBox>


                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_com_local" runat="server" CssClass="span11" Width="230px" MaxLength="250" placeholder="Max 250 Char" onblur="capitalizeMe(this);"></asp:TextBox>


                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_EXp_designation" runat="server" CssClass="span11" Width="150px" MaxLength="50" placeholder="Max 50 Char" onblur="capitalizeMe(this);"></asp:TextBox>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_total_exp" runat="server" CssClass="span11" Width="100px" MaxLength="5" placeholder="Max 5 Char" onkeypress="return (!(event.keyCode>=65 && event.keyCode<=122));" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_total_exp"
                                                                                ValidationGroup="c" runat="server" ValidationExpression="\d{1,3}(\.\d{0,2})?$" ToolTip="Enter Correct Values"
                                                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_exp_from" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max 4 Char" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                            to
                                                                    <asp:TextBox ID="txt_exp_to" runat="server" CssClass="span11" Width="60px" MaxLength="4" placeholder="Max 4 Char" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>


                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="grid_exp" runat="Server" Width="100%" OnRowDeleting="grid_exp_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                    <td>
                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress10" runat="server" AssociatedUpdatePanelID="UpdatePanel7"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table width="100%" class="frm-lft-clr-main">
                                                                    <tr>
                                                                        <td align="left">&nbsp;Training Information :</td>
                                                                        <td align="right">
                                                                            <asp:Button ID="btn_Training" OnClick="btn_Training_add_Click" runat="server" Text="Add" OnClientClick="return ValidateTraining();"
                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Training Details"></asp:Button>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                                    width="100%" border="1">
                                                                    <tr>
                                                                        <td class="td-head" width="22%">Training Name<span class=""></span>
                                                                        </td>
                                                                        <td class="td-head" width="22%">Conducted By<span class=""></span>
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
                                                                            <asp:TextBox ID="txt_TrProgram" runat="server" CssClass="span11" MaxLength="90" Width="180px" placeholder="Max 100 Char"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txt_TrConductedBy" runat="server" CssClass="span11" Width="180px" MaxLength="90" placeholder="Max 100 Char"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFromdate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image8" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                    ID="CalendarExtender8" runat="server" PopupButtonID="Image8" TargetControlID="txtFromdate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtToDate" runat="server" Width="100px" CssClass="span11" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);" onblur="return TrainingCompareDates();"></asp:TextBox>&#160;<asp:Image
                                                                                ID="Image9" runat="server" ImageUrl="~/img/clndr.gif" /><cc1:CalendarExtender Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                    ID="CalendarExtender9" runat="server" PopupButtonID="Image9" TargetControlID="txtToDate"
                                                                                    Enabled="True">
                                                                                </cc1:CalendarExtender>

                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtTrRemarks" runat="server" CssClass="span11" Width="180px" placeholder="Max 500 Char" MaxLength="500">

                                                                            </asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridTraning" runat="Server" Width="100%" OnRowDeleting="GridTraning_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                    <td>
                                                        <asp:UpdatePanel ID="upedu" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress11" runat="server" AssociatedUpdatePanelID="updatepanel8"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <div class="form-actions no-margin">
                                                                    <asp:Button ID="btnprop" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnprop_Click" OnClientClick="return ValidateProp();" />
                                                                </div>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>

                                            </table>

                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <!-- Personal Details -->
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0" id="Table4">
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="updatepanel8" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="updatepanel8"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" id="li_tabs4" runat="server">
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
                                                                            <table valign="top" cellspacing="0" cellpadding="0" width="1036px" border="0">
                                                                                <tr>
                                                                                    <td valign="top" width="50%">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="45%">Date of Birth <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="55%">
                                                                                                    <asp:TextBox ID="txt_DOB" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>

                                                                                                    <asp:Image ID="Image1" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txt_dob" Format="dd-MMM-yyyy" PopupPosition="BottomRight"
                                                                                                        PopupButtonID="Image1">
                                                                                                    </cc1:CalendarExtender>
                                                                                                    <img src="../img/error1.gif" alt="" visible="false" id="imgerror" runat="server" />
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" style="height: 30px">Payment Mode <span class="star"></span>
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
                                                                                                    <asp:TextBox ID="txtrelg" runat="server" placeholder="Max. 50 Char.." CssClass="span11" onblur="capitalizeMe(this);"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="height: 50px;">
                                                                                                <td class="frm-lft-clr123 ">Blood Group <span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 ">
                                                                                                    <asp:DropDownList ID="ddlbloodgrp" runat="server" CssClass="span11">
                                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                        <asp:ListItem Value="A+">A+</asp:ListItem>
                                                                                                        <asp:ListItem Value="A-">A-</asp:ListItem>
                                                                                                        <asp:ListItem Value="B+">B+</asp:ListItem>
                                                                                                        <asp:ListItem Value="B-">B-</asp:ListItem>
                                                                                                        <asp:ListItem Value="AB+">AB+</asp:ListItem>
                                                                                                        <asp:ListItem Value="AB-">AB-</asp:ListItem>
                                                                                                        <asp:ListItem Value="O+">O+</asp:ListItem>
                                                                                                        <asp:ListItem Value="O-">O-</asp:ListItem>
                                                                                                        <asp:ListItem Value="A Rh-">A Rh-</asp:ListItem>
                                                                                                        <asp:ListItem Value="A Rh+">A Rh+</asp:ListItem>
                                                                                                        <asp:ListItem Value="B Rh-">B Rh-</asp:ListItem>
                                                                                                        <asp:ListItem Value="B Rh+">B Rh+</asp:ListItem>
                                                                                                        <asp:ListItem Value="AB Rh-">AB Rh-</asp:ListItem>
                                                                                                        <asp:ListItem Value="AB Rh+">AB Rh+</asp:ListItem>
                                                                                                        <asp:ListItem Value="O Rh-">O Rh-</asp:ListItem>
                                                                                                        <asp:ListItem Value="O Rh+">O Rh+</asp:ListItem>
                                                                                                        <asp:ListItem Value="HH(Bombay)">HH(Bombay)</asp:ListItem>
                                                                                                        <asp:ListItem Value="A1+">A1+</asp:ListItem>
                                                                                                    </asp:DropDownList>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr style="display: none">
                                                                                                <td class="frm-lft-clr123">D.L. No.
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_dl_no" placeholder="Max. 20 Char.." runat="server" CssClass="span11" MaxLength="20"></asp:TextBox>
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
                                                                                                        <asp:SqlDataSource
                                                                                                            ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td align="left" class="frm-lft-clr123">Bank Branch Name <span class="star"></span>
                                                                                                    </td>
                                                                                                    <td align="left" class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_bankbrachname" runat="server" placeholder="Max. 100 Char.." CssClass="span11" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td>
                                                                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right">
                                                                                                <tr>
                                                                                                    <td align="left" class="frm-lft-clr123" width="45%">Account No. for Salary<span class=""><span class="star"></span>
                                                                                                    </td>
                                                                                                    <td align="left" class="frm-rght-clr123" width="54%">
                                                                                                        <asp:TextBox ID="txt_bank_ac" runat="server" CssClass="span11" placeholder="Max. 20 Char.." MaxLength="20" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>

                                                                                                <tr>
                                                                                                    <td align="left" class="frm-lft-clr123">IFSC code<span class="star"></span>
                                                                                                    </td>
                                                                                                    <td align="left" class="frm-rght-clr123">
                                                                                                        <asp:TextBox ID="txt_ifsc" runat="server" CssClass="span11" MaxLength="11" placeholder="Max. 11 Char.."></asp:TextBox>
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
                                                                                            <asp:SqlDataSource
                                                                                                ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [branchcode],[branchcode]+'--'+[bankname] as bankname FROM tbl_payroll_bank"></asp:SqlDataSource>
                                                                                        </td>
                                                                                        <td>&#160;&nbsp;
                                                                                        </td>
                                                                                        <td align="left" class="frm-lft-clr123">Account No. for Reimbursement
                                                                                        </td>
                                                                                        <td align="left" class="frm-rght-clr123">
                                                                                            <asp:TextBox ID="txt_bank_ac_reimbursement" runat="server" CssClass="span11" MaxLength="50"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td valign="top" colspan="2">
                                                                            <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>

                                                                                    <td valign="top" width="50%">
                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" width="45%">Mobile No.<span class="star"></span>
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" width="55%">
                                                                                                    <%--<asp:TextBox ID="txtccode" runat="server" CssClass="span1" Width="10px" MaxLength="4">+91</asp:TextBox>--%>
                                                                                                    <asp:TextBox ID="txtccode" Width="30px" placeholder="Max 4 Chars.." runat="server" MaxLength="4" onkeypress="return ValidatePhoneNo()">+91</asp:TextBox>&nbsp;
                                                                                        <asp:TextBox ID="txtmobileno" runat="server" placeholder="Max. 10 Char.." CssClass="span11" Width="190px" MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">LandLine No.
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                    <asp:TextBox ID="txtperccode" runat="server" Width="30px" placeholder="Max 4 Chars.." onkeypress="return IsNumeric(event);" MaxLength="4">+91</asp:TextBox>
                                                                                                    <asp:TextBox ID="txtperstdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                    <asp:TextBox ID="txtperlandno" runat="server" CssClass="span11" Width="130px" placeholder="Max 10 Chars.."
                                                                                                        MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">Passport No.
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_passportno" runat="server" CssClass="span11" placeholder="Max. 15 Char.." Width="" MaxLength="15"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Passport Expiry Date
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 ">
                                                                                                    <asp:TextBox ID="txt_passportexpdate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image7" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender7" runat="server" Format="dd-MMM-yyyy" PopupPosition="BottomRight" TargetControlID="txt_passportexpdate"
                                                                                                            PopupButtonID="Image7">
                                                                                                        </cc1:CalendarExtender>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="tshirt" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123 border-bottom">T-Shirt Size
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:DropDownList ID="ddl_Tshirt" runat="server" CssClass="span11">
                                                                                                        <asp:ListItem Value="0">--Select Size--</asp:ListItem>
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
                                                                                                <%--<td class="frm-rght-clr123" width="54%">
                                                                                        <asp:TextBox ID="txt_email" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50"></asp:TextBox>
                                                                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                                    ControlToValidate="txt_email" ToolTip="Please Enter Correct Email Id" ValidationGroup="c"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"><img src="../img/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                                    </td>--%>
                                                                                                <td class="frm-rght-clr123" width="54%">
                                                                                                    <asp:TextBox ID="txt_email" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator33" runat="server" ControlToValidate="txt_email"
                                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email Id"
                                                                                                        ValidationGroup="V" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                                                                                        ValidationGroup="V" ToolTip="Invalid Email ID" SetFocusOnError="True" Display="Dynamic"
                                                                                                        ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123">Driving Licence No.
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_drli_no" runat="server" CssClass="span11" placeholder="Max. 20 Char.." Width="" MaxLength="20"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom">Passport Issued Date
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_passportissueddate" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();"></asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image10" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender10" runat="server" TargetControlID="txt_passportissueddate"
                                                                                                            PopupButtonID="Image10" Format="dd-MMM-yyyy" PopupPosition="BottomRight">
                                                                                                        </cc1:CalendarExtender>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr visible="false" runat="server">
                                                                                                <td class="frm-lft-clr123">Driving Licence Issued Date
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_dr_iss_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();">

                                                                                                    </asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image15" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender15" runat="server" TargetControlID="txt_dr_iss_date"
                                                                                                            PopupButtonID="Image15" Format="dd-MMM-yyyy" PopupPosition="BottomRight">
                                                                                                        </cc1:CalendarExtender>

                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr visible="false" runat="server">
                                                                                                <td class="frm-lft-clr123  border-bottom">Driving Licence Expiry Date
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_dr_exp_date" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return isNumber_slash();" onblur="return CompareDates();"></asp:TextBox>&nbsp;<asp:Image
                                                                                                        ID="Image16" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image><cc1:CalendarExtender ID="CalendarExtender16" runat="server" Format="dd-MMM-yyyy" PopupPosition="BottomRight" TargetControlID="txt_dr_exp_date"
                                                                                                            PopupButtonID="Image16">
                                                                                                        </cc1:CalendarExtender>

                                                                                                </td>
                                                                                            </tr>


                                                                                            <tr id="short" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123 border-bottom">Shirt Size
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:DropDownList ID="ddl_ShirtSize" runat="server" CssClass="span11">
                                                                                                        <asp:ListItem Value="0">--Select Size--</asp:ListItem>
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
                                                                                                <td class="txt02" colspan="2"><%--Father&apos;s Detail--%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2" height="5"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Father / Husband Name 
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                                    <asp:TextBox ID="txt_f_f_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="Tr20" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_f_mname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="Tr21" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_f_l_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

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
                                                                                                        <asp:ListItem Text="Unmarried" Value="UNMARRIED"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Married" Value="MARRIED"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Divorcee" Value="DIVORCEE"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Widow" Value="WIDOW"></asp:ListItem>
                                                                                                        <asp:ListItem Text="Widower" Value="WIDOWER"></asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </td>
                                                                                    <td valign="top">
                                                                                        <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                            <tr>
                                                                                                <td style="height: 13px" class="txt02" colspan="2"><%--Mother&apos;s Detail--%>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <%--<tr>
                                                                                    <td colspan="2" height="5"></td>
                                                                                </tr>--%>
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Mother Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_m_fname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="Tr22" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123" width="45%">Middle Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123">
                                                                                                    <asp:TextBox ID="txt_m_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                                </td>
                                                                                            </tr>

                                                                                            <tr id="Tr29" runat="server" visible="false">
                                                                                                <td class="frm-lft-clr123 border-bottom" width="45%">Last Name
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                    <asp:TextBox ID="txt_m_l_name" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

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
                                                                                                                            <asp:TextBox ID="txt_sp_fname" placeholder="Max. 50 Char.." runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                                        </td>
                                                                                                                    </tr>

                                                                                                                    <tr id="Tr30" runat="server" visible="false">
                                                                                                                        <td class="frm-lft-clr123">Middle Name
                                                                                                                        </td>
                                                                                                                        <td class="frm-rght-clr123">
                                                                                                                            <asp:TextBox ID="txt_sp_mname" runat="server" CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()"></asp:TextBox>

                                                                                                                        </td>
                                                                                                                    </tr>

                                                                                                                    <tr id="Tr31" runat="server" visible="false">
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
                                                                                                                            <asp:TextBox ID="txt_doa" runat="server" placeholder="Select Date" CssClass="span11" onkeypress="return enterdate(event);" onblur="return SpouseCompareDates();" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;<asp:Image
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
                                                                                                                        <td class="frm-rght-clr123" width="55%">
                                                                                                                            <asp:TextBox ID="txt_s_DOB" runat="server" placeholder="Select Date" CssClass="span11" Width="" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                                                            <asp:Image ID="Image14" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
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
                                                                                                                                Width="92%">
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
                                                                                                                            <asp:TextBox ID="txt_child_name" runat="server" placeholder="Max. 50 Char.." CssClass="span11" Width="" MaxLength="50" onblur="capitalizeMe(this);" onkeydown="return isAlpha(event.keyCode);" ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                                                        </td>
                                                                                                                        <td class="frm-rght-clr123 border-bottom" style="border-right: none">
                                                                                                                            <asp:DropDownList ID="ddl_child_gender" runat="server" CssClass="span11" Height=""
                                                                                                                                Width="100px">
                                                                                                                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                                                                                                <asp:ListItem>Male</asp:ListItem>
                                                                                                                                <asp:ListItem>Female</asp:ListItem>
                                                                                                                            </asp:DropDownList>

                                                                                                                        </td>
                                                                                                                        <td class="frm-rght-clr123 border-bottom" width="35%">
                                                                                                                            <table width="100%">
                                                                                                                                <tr>
                                                                                                                                    <td align="left">
                                                                                                                                        <asp:TextBox ID="txt_child_Dob" placeholder="Select Date" runat="server" CssClass="span11" Width="150px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                                                    <asp:Image ID="Image3" runat="server" ToolTip="click to open calender" ImageUrl="~/img/clndr.gif"></asp:Image>
                                                                                                                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txt_child_Dob" Format="dd-MMM-yyyy"
                                                                                                                                            PopupButtonID="Image3">
                                                                                                                                        </cc1:CalendarExtender>

                                                                                                                                    </td>
                                                                                                                                    <td align="right">
                                                                                                                                        <asp:UpdatePanel ID="upvv" runat="server">
                                                                                                                                            <ContentTemplate>
                                                                                                                                                <asp:Button ID="btn_child_Add" OnClick="btn_child_Add_Click" runat="server" Text="Add" OnClientClick="return ValidateChildren();"
                                                                                                                                                    CssClass="btn btn-primary" ToolTip="Click hare to add children detail"></asp:Button>
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
                                                                                                            <td height="10px" colspan="3"></td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td valign="top" colspan="3">
                                                                                                                <div class="widget-content">
                                                                                                                    <asp:GridView ID="grid_child" runat="Server" Width="99%" OnRowDeleting="grid_child_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
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
                                                                        <td colspan="2">
                                                                            <div class="form-actions no-margin">
                                                                                <asp:Button ID="btnpersonal" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnpersonal_Click" ValidationGroup="V" OnClientClick="return ValidatePersonalDetails();" />
                                                                                <%--OnClientClick="return ValidatePersonalDetails();--%>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </p>
                                    </div>

                                    <div id="divhealth" runat="server" visible="false">
                                        <p>
                                            <!-- Job Details -->
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                                <tr>
                                                    <td colspan="2" class="txt02" style="height: 25px">Select Health Insurance Package
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2" width="100%">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%" valign="top">
                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:UpdateProgress ID="UpdateProgress14" runat="server" AssociatedUpdatePanelID="kk"
                                                                                DisplayAfter="1">
                                                                                <ProgressTemplate>
                                                                                    <div class="modal-backdrop fade in">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td align="center" valign="top">
                                                                                                    <img src="../img/loading.gif" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                        </table>
                                                                                    </div>
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <caption>
                                                                                    </fieldset>
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123" width="32%">BENEFITS </td>
                                                                                        <td class="frm-rght-clr123" width="3%">
                                                                                            <asp:CheckBox ID="txtbasic" runat="server" AutoPostBack="True" OnCheckedChanged="txtbasic_CheckedChanged" Text="" ValidationGroup="a" />
                                                                                        </td>
                                                                                        <td class="frm-lft-clr123" width="10%">MTN CR BASIC</td>
                                                                                        <td class="frm-rght-clr123" width="3%">
                                                                                            <asp:CheckBox ID="txtclassic" runat="server" AutoPostBack="True" OnCheckedChanged="txtclassic_CheckedChanged" Text="" ValidationGroup="a" />
                                                                                        </td>
                                                                                        <td class="frm-lft-clr123" width="10%">MTN CR CLASSIC</td>
                                                                                        <td class="frm-rght-clr123" width="3%">
                                                                                            <asp:CheckBox ID="txtunique" runat="server" AutoPostBack="True" OnCheckedChanged="txtunique_CheckedChanged" Text="" ValidationGroup="a" />
                                                                                        </td>
                                                                                        <td class="frm-lft-clr123" width="10%">MTN CR UNIQUE</td>
                                                                                    </tr>

                                                                                </caption>
                                                                            </table>

                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) INDIVIDUAL PLAN
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:DropDownList ID="ddl_individual" runat="server" CssClass="span11"
                                                                                            Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="1500" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="2800" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="3500" Value="3"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>

                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF FOUR 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:DropDownList ID="ddl_familyfour" runat="server" CssClass="span11"
                                                                                            Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="3600" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="6200" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="8000" Value="3"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="40%">MONTHLY SUBSCRIPTION (NAIRA) FAMILY PLAN OF SIX 
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="48%">
                                                                                        <asp:DropDownList ID="ddl_familysix" runat="server" CssClass="span11"
                                                                                            Height="" AutoPostBack="True" OnSelectedIndexChanged="ddlpersonalstatus_SelectedIndexChanged">
                                                                                            <asp:ListItem Text="0" Value="0"></asp:ListItem>
                                                                                            <asp:ListItem Text="5000" Value="1"></asp:ListItem>
                                                                                            <asp:ListItem Text="7000" Value="2"></asp:ListItem>
                                                                                            <asp:ListItem Text="10000" Value="3"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="width: 30px; height: 9px"></td>
                                                                                    <td style="height: 9px" align="right"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="2">
                                                                                        <div class="form-actions no-margin">

                                                                                            <asp:Button ID="btn_submit" runat="server" Text="Submit" CssClass="btn btn-primary pull-right" OnClick="btn_submit_Click" />
                                                                                            <asp:Button ID="btn_view" runat="server" Text="View Plan" CssClass="btn btn-primary pull-right" OnClick="btn_view_Click" />
                                                                                        </div>
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

                                        </p>
                                    </div>




                                    <div>
                                        <p>
                                            <!-- Employee Upload Details -->


                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td colspan="2" class="txt02"><b>Photo Id Proof</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <hr size="4px" style="background-color: gray" />
                                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress17" runat="server" AssociatedUpdatePanelID="UpdatePanel13"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table id="Table5" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">

                                                                    <tr>

                                                                        <td class="frm-rght-clr123 " width="20%">ID Type</td>
                                                                        <td class="frm-rght-clr123 " width="25%">
                                                                            <asp:DropDownList ID="DropDownList13" runat="server" CssClass="span7"
                                                                                Height="" AutoPostBack="True" OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged">
                                                                               <%-- <asp:ListItem Text="0" Value="0">--Select--</asp:ListItem>--%>
                                                                                <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                                                            </asp:DropDownList></td>


                                                                        <td class="frm-rght-clr123 ">
                                                                            <%-- <label class="radio inline">
                                                                                <asp:RadioButton ID="RadioButton10" runat="server" AutoPostBack="true" Checked="false"
                                                                                    Text="Current Residential Address" GroupName="paymentmode" OnCheckedChanged="rbtnbank_CheckedChanged" /></label>
                                                                            <label class="radio inline">
                                                                                <asp:RadioButton ID="RadioButton11" runat="server" AutoPostBack="true" Checked="false" Text="Permanent Residential Address"
                                                                                    GroupName="paymentmode" OnCheckedChanged="rbtncheque_CheckedChanged" /></label>--%>
                                                                            <asp:FileUpload ID="FileUpload2" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr runat="server" id="ot1" visible="false">
                                                                        <td class="frm-rght-clr123 border-bottom" width="20%">Others</td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="25%">

                                                                            <asp:TextBox ID="TextBox77" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 20 Chars..." Width="" MaxLength="20"></asp:TextBox>
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridView1" runat="Server" Width="100%" OnRowDeleting="GridPhotoUpload_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="ID Type" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:HiddenField ID="hdfs" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                                <asp:Label ID="lblTrjjjsg" runat="Server" Text='<%# Eval("ID_Type")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCondfdductedBy" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <%--<asp:TemplateField HeaderText="Address Type" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("Address_Type")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                        <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltodfddate" runat="Server" Text='<%# Eval("File")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>

                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="frm-lft-clr-main border-bottom">
                                                                        <td></td>
                                                                        <td></td>

                                                                        <td align="right">
                                                                            <asp:Button ID="Button2" OnClick="Button2_Click" runat="server" Text="Add" OnClientClick="return validation();"
                                                                                CssClass="btn btn-primary" ToolTip="Click here to add Educational Qualification"></asp:Button></td>
                                                                    </tr>

                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="Button2" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top"></td>

                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02"><b>Address Proof</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <hr size="4px" style="background-color: gray" />
                                                        <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress19" runat="server" AssociatedUpdatePanelID="UpdatePanel14"
                                                                    DisplayAfter="1">
                                                                    <ProgressTemplate>
                                                                        <div class="modal-backdrop fade in">
                                                                            <table width="100%">
                                                                                <tr>
                                                                                    <td align="center" valign="top">
                                                                                        <img src="../img/loading.gif" />
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </ProgressTemplate>
                                                                </asp:UpdateProgress>
                                                                <table id="Table6" width="100%" border="0" cellpadding="0" cellspacing="0" runat="server">

                                                                    <tr>

                                                                        <td class="frm-rght-clr123 " width="20%">ID Type</td>
                                                                        <td class="frm-rght-clr123 " width="25%">
                                                                            <asp:DropDownList ID="DropDownList15" runat="server" CssClass="span7"
                                                                                Height="" OnSelectedIndexChanged="DropDownList15_SelectedIndexChanged" AutoPostBack="true">
                                                                              <%--  <asp:ListItem Value="0">--Select--</asp:ListItem>--%>
                                                                                <asp:ListItem Text="A" Value="1"></asp:ListItem>
                                                                                <asp:ListItem Text="B" Value="2"></asp:ListItem>
                                                                                <asp:ListItem Text="C" Value="3"></asp:ListItem>
                                                                            </asp:DropDownList></td>


                                                                        <td class="frm-rght-clr123 ">
                                                                            <%--<label class="radio inline">
                                                                                <asp:RadioButton ID="RadioButton12" runat="server" Checked="false"
                                                                                    Text="Current Residential Address" GroupName="paymentmode2" /></label>
                                                                            <label class="radio inline">
                                                                                <asp:RadioButton ID="RadioButton13" runat="server" Checked="false" Text="Permanent Residential Address"
                                                                                    GroupName="paymentmode2" /></label>--%>
                                                                            <asp:FileUpload ID="FileUpload3" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                                        </td>



                                                                    </tr>
                                                                    <tr runat="server" id="ot2" visible="false">

                                                                        <td class="frm-rght-clr123 border-bottom" width="20%">Others</td>
                                                                        <td class="frm-rght-clr123 border-bottom" width="25%">
                                                                            <asp:TextBox ID="TextBox74" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 20 Chars..." Width="" MaxLength="20"></asp:TextBox>
                                                                        </td>


                                                                        <td class="frm-rght-clr123 border-bottom"></td>



                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="5">
                                                                            <div class="widget-content">
                                                                                <asp:GridView ID="GridView2" runat="Server" Width="100%" OnRowDeleting="GridAddressUpload_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="ID Type" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:HiddenField ID="hdfww" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                                <asp:Label ID="lblTraningwqqw" runat="Server" Text='<%# Eval("ID_Type")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%" Visible="false">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblConductedByqgfgfg" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <%-- <asp:TemplateField HeaderText="Address Type" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("Address_Type")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                        <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltodatfvcvcve" runat="Server" Text='<%# Eval("File")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                    <tr class="frm-lft-clr-main border-bottom">
                                                                        <td></td>
                                                                        <td></td>

                                                                        <td align="right">
                                                                            <asp:Button ID="Button3" OnClick="Button3_Click" runat="server" Text="Add" OnClientClick="return validation();"
                                                                                CssClass="btn btn-primary"></asp:Button></td>
                                                                    </tr>

                                                                </table>
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="Button3" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                        <br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" class="txt02"><b>Other Documents</b></td>
                                                </tr>
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <tr>

                                                                <td class="frm-rght-clr123 border-bottom" width="20%">Document Name</td>
                                                                <td class="frm-rght-clr123 border-bottom" width="25%">
                                                                    <asp:TextBox ID="TextBox73" runat="server" CssClass="span7" TextMode="SingleLine" placeholder="Max 50 Chars.." Width="150px" MaxLength="50"></asp:TextBox>


                                                                </td>


                                                                <td class="frm-rght-clr123 border-bottom">

                                                                    <asp:FileUpload ID="FileUpload4" runat="server" Width="287px" ToolTip="Upload File here" />&nbsp;
                                                                </td>



                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="GridView3" runat="Server" Width="100%" OnRowDeleting="GridOtherDoc_RowDeleting" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="autoID"
                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Others" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:HiddenField ID="hdfkb" runat="server" Value='<%# Eval("autoID") %>' />
                                                                                        <asp:Label ID="lblConductedBvbvy" runat="Server" Text='<%# Eval("Others")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>


                                                                                <asp:TemplateField HeaderText="File" HeaderStyle-Width="16%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbltovbbbndate" runat="Server" Text='<%# Eval("File")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                                     <asp:TemplateField HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:LinkButton
                                                                                                    CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete" CausesValidation="false"></asp:LinkButton>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr class="frm-lft-clr-main border-bottom">
                                                                <td></td>
                                                                <td></td>

                                                                <td align="right">
                                                                    <asp:Button ID="Button4" OnClick="Button4_Click" runat="server" Text="Add" OnClientClick="return validation();"
                                                                        CssClass="btn btn-primary"></asp:Button></td>
                                                            </tr>
                                                            <tr style="display: none">
                                                                <td colspan="4">
                                                                    <div class="widget-body">

                                                                        <div class="form-actions no-margin">
                                                                            <asp:Label ID="Label42" runat="server" EnableViewState="False"></asp:Label>
                                                                            <asp:Button ID="Button12" runat="server" align="right" CssClass="btn btn-primary" OnClick="btngeneralsubmit_Click"
                                                                                Text="Submit" />
                                                                        </div>

                                                                    </div>

                                                                </td>
                                                            </tr>

                                                            <table width="100%" border="0" cellpadding="0" cellspacing="0" id="li_tabs5" visible="false" runat="server">
                                                                <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" style="height: 13px">Upload Support Documents<p style="color: red">(Supported Files are PDF,PNG,BMP,JPG,GIF)</p>
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
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server"
                                                                                ControlToValidate="File_UploadDft1" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft2" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft3" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft4" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft5" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft6" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft7" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft8" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft9" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
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
                                                                                ControlToValidate="File_UploadDft10" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Default11" runat="server"></asp:Label><asp:TextBox ID="TextBox11"
                                                                            runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:FileUpload ID="File_UploadDft11" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                                ControlToValidate="File_UploadDft11" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Default12" runat="server"></asp:Label><asp:TextBox ID="TextBox12"
                                                                            runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:FileUpload ID="File_UploadDft12" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                                ControlToValidate="File_UploadDft12" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>

                                                                <!--  added by darshan -->
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Default13" runat="server"></asp:Label><asp:TextBox ID="TextBox13"
                                                                            runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:FileUpload ID="File_UploadDft13" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server"
                                                                                ControlToValidate="File_UploadDft13" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Default14" runat="server"></asp:Label><asp:TextBox ID="TextBox14"
                                                                            runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:FileUpload ID="File_UploadDft14" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidaor13" runat="server"
                                                                                ControlToValidate="File_UploadDft14" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>

                                                                <tr>

                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Default15" runat="server"></asp:Label><asp:TextBox ID="TextBox15"
                                                                            runat="server"></asp:TextBox>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:FileUpload ID="File_UploadDft15" runat="server" FileTypeRange="bmp,jpg" MaxWidth="300"
                                                                            Vgroup="v" /><asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                                                                ControlToValidate="File_UploadDft15" ValidationGroup="v" CssClass="txt-red" ToolTip="File Not Supported" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                                                ValidationExpression="^.+(.pdf|.PDF|.png|.PNG|.bmp|.BMP|.jpg|.JPG|.gif|.GIF)$"></asp:RegularExpressionValidator>
                                                                    </td>

                                                                </tr>
                                                                <!--  End file add -->

                                                                <tr>
                                                                    <td colspan="2">
                                                                        <asp:UpdatePanel ID="upload" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="form-actions no-margin" style="display: none">
                                                                                    <asp:Button ID="btnupload" runat="server" Text="Save" CssClass="btn btn-primary pull-right" OnClick="btnupload_Click" OnClientClick="return validateUpload();" />
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 50px" id="password" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123  border-bottom">Login Password<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:TextBox ID="txtpwd" runat="server" CssClass="span11" TextMode="Password"
                                                                            MaxLength="50" placeholder="Max. 50 Char.."></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </table>

                                                        </td>

                                                    </tr>
                                                </table>
                                                <tr>
                                                    <td colspan="2">
                                                        <div class="widget-body">
                                                            <%--  <asp:UpdatePanel ID="uppwd" runat="server">
                                                                <ContentTemplate>--%>
                                                            <div class="form-actions no-margin">
                                                                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                                                                <asp:Button ID="btngeneralsubmit" runat="server" align="right" CssClass="btn btn-primary pull-right" OnClick="btngeneralsubmit_Click"
                                                                    Text="Submit" OnClientClick="return ValidateSubmitData();" />
                                                            </div>
                                                            <%--</ContentTemplate>
                                                            </asp:UpdatePanel>--%>
                                                        </div>

                                                    </td>
                                                </tr>

                                                </td>
                                                   
                                             

                                            </table>

                                        </p>
                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>

        <script type="text/javascript">
            function ValidateSubmitData() {
                var Salutation = document.getElementById('<%=ddlSalutation.ClientID %>');
                var FName = document.getElementById('<%=txtfirstname.ClientID %>');
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                var Machinecode = document.getElementById('<%=txt_card_no.ClientID %>');
                var businessunit = document.getElementById('<%=ddl_broadgroup.ClientID %>');
                var Password = document.getElementById('<%=txtpwd.ClientID %>');
                var Gender = document.getElementById('<%=drpgender.ClientID %>');
                var Branch = document.getElementById('<%=drpbranch.ClientID %>');
                var DepartmentType = document.getElementById('<%=drpdepartmenttype.ClientID %>');
                var Department = document.getElementById('<%=drpdepartment.ClientID %>');
                var EmpDesignation = document.getElementById('<%=drpdegination.ClientID %>');
                var EmpRole = document.getElementById('<%=drprole.ClientID %>');
                var EmpStatus = document.getElementById('<%=drpempstatus.ClientID %>');
                var EmpDateofJoin = document.getElementById('<%=doj.ClientID %>');
                var offemailid = document.getElementById('<%=txt_officialemail.ClientID %>');





                var costcenter = document.getElementById('<%=drpdivision.ClientID %>');
                var grade = document.getElementById('<%=drpgrade.ClientID %>');





                var bank = document.getElementById('<%=ddl_bank_name.ClientID%>');
                var dol, conformationdate, lblcondate;

                var accno = document.getElementById('<%=txt_bank_ac.ClientID %>');


            var dob = document.getElementById('<%=txt_DOB.ClientID %>');
                var passfrmdate = document.getElementById('<%=txt_passportissueddate.ClientID %>');
                var passtodate = document.getElementById('<%=txt_passportexpdate.ClientID %>');

                var dlfrmdate = document.getElementById('<%=txt_dr_iss_date.ClientID %>');
                var dltodate = document.getElementById('<%=txt_dr_exp_date.ClientID %>');
                var martialstatus = document.getElementById('<%=ddlpersonalstatus.ClientID %>');

                var spousedob, spousedoa;
                if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {
                    spousedob = document.getElementById('<%=txt_s_DOB.ClientID %>');
                spousedoa = document.getElementById('<%=txt_doa.ClientID %>');
            }
            if (Salutation.value == 0) {
                Salutation.focus();
                alert("Please select title from Job Details Tab.");
                return false;
            }
            if ((IsEmpty(FName))) {
                FName.focus();
                alert("Please enter employee name from Job Details Tab.");
                return false;
            }
            if (Gender.value == 0) {
                Gender.focus();
                alert("Please select gender from Job Details Tab.");
                return false;
            }
            if ((IsEmpty(Empcode))) {
                Empcode.focus();
                alert("Please enter employee code from Job Details Tab.");
                return false;
            }
            if ((IsEmpty(Machinecode))) {
                Machinecode.focus();
                alert("Please enter Employee No from Job Details Tab.");
                return false;
            }
            if (Branch.value == 0) {
                Branch.focus();
                alert("Please select worklocation from Job Details Tab.");
                return false;
            }
            if (DepartmentType.value == 0) {
                DepartmentType.focus();
                alert("Please select Department Type from Job Details Tab.");
                return false;
            }

            if (Department.value == 0) {
                Department.focus();
                alert("Please select department from Job Details Tab.");
                Department.focus();
                return false;
            }

            if (EmpDesignation.value == 0) {
                EmpDesignation.focus();
                alert("Please select employee designation from Job Details Tab.");
                return false;
            }


            if (EmpRole.value == 0) {
                EmpRole.focus();
                alert("Please select employee role from Job Details Tab.");
                return false;
            }

            if (EmpStatus.value == 0) {
                EmpStatus.focus();
                alert("Please select employee status from Job Details Tab.");
                return false;
            }
            if (IsEmpty(EmpDateofJoin)) {
                EmpDateofJoin.focus();
                alert("Please enter date of joining from Job Detaails Tab.");
                return false;
            }
            if (IsEmpty(offemailid)) {
                offemailid.focus();
                alert("Please enter official email id from Job Detaails Tab.");
                return false;
            }
                //if (businessunit.value == 0) {
                //    businessunit.focus();
                //    alert("Please select business unit from Job Details Tab.");
                //    return false;
                //}
            if (bank.value == 0) {
                bank.focus();
                alert("Please select Bank Name from Personal Details Tab.");
                return false;
            }













            else if (EmpStatus.value == 4) {
                dol = document.getElementById('<%=txtdol.ClientID %>');
                }
                else if (EmpStatus.value != 3) {
                    lblcondate = document.getElementById('<%=lblprob.ClientID%>').innerText;
                    conformationdate = document.getElementById('<%=txt_confirmationdate.ClientID %>');
                }







        if (lblcondate == "Probation End date") {
            if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'Pro')))
                return false;
        }
        if (lblcondate == "Confirmation Date") {
            if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'C')))
                return false;
        }
        if (EmpStatus.value == 4) {
            if (!(validateEmphistorydate(EmpDateofJoin, dol, 'R')))
                return false;
        }



        if (!(validateEmphistorydate(dob, EmpDateofJoin, 'DOB')))
            return false;

        if (!(validateEmphistorydate(passfrmdate, passtodate, 'P')))
            return false;

        if (!(validateEmphistorydate(dlfrmdate, dltodate, 'D')))
            return false;
        if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {
            if (!(validateEmphistorydate(spousedob, spousedoa, 'S')))
                return false;
        }

        var txtreportmanager = document.getElementById('<%=txtreportmanager.ClientID %>'); //Line Manager

        var dottedlinemanager = document.getElementById('<%=txtdottedlinemanager.ClientID %>');
                //Dotted Line Manager
                var txtbusinesshead = document.getElementById('<%=txtbusinesshead.ClientID %>'); //Business Head
                var txtfncmang = document.getElementById('<%=txtfncmang.ClientID %>'); //Account Manager

                var txtadmin = document.getElementById('<%=txtadmin.ClientID %>');  //Admin
                var txthr = document.getElementById('<%=txthr.ClientID %>');        //HR TA
                var hrcb = document.getElementById('<%=txthrcb.ClientID %>');                                                                    // HR-C&B
                var txthrd = document.getElementById('<%=txthrd.ClientID %>');      //HR-BP

                var txtmng = document.getElementById('<%=txtmng.ClientID %>');               //Management/MD

                var txtdeptclr = document.getElementById('<%=txtdeptclr.ClientID %>');       //Departmental Clearance
                var txtadminclr = document.getElementById('<%=txtadminclr.ClientID %>');     //General Administration Clearance
                var txtaccdeptclr = document.getElementById('<%=txtaccdeptclr.ClientID %>'); //Accounts Department Clearance
                var txtnetworkclr = document.getElementById('<%=txtnetworkclr.ClientID %>'); //Network Administration Clearance
                var txthrdeptclr = document.getElementById('<%=txthrdeptclr.ClientID %>');   //HR Department Clearance
                var txtaccdeleclr = document.getElementById('<%=txtaccdeleclr.ClientID %>'); // User Account Deletion Request

                if ((IsEmpty(txtreportmanager))) {
                    txtreportmanager.focus();
                    alert("Please enter Reporting Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtbusinesshead))) {
                    txtbusinesshead.focus();
                    alert("Please enter Business Head from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtadmin))) {
                    txtadmin.focus();
                    alert("Please enter Admin from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthr))) {
                    txthr.focus();
                    alert("Please enter  HR Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthrd))) {
                    txthrd.focus();
                    alert("Please enter HRD Manager from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtmng))) {
                    txtmng.focus();
                    alert("Please enter Management/MD from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtdeptclr))) {
                    txtdeptclr.focus();
                    alert("Please enter Departmental Clearance from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtadminclr))) {
                    txtadminclr.focus();
                    alert("Please enter General Administartion Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtfncmang))) {
                    txtfncmang.focus();
                    alert("Please enter Finance Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtaccdeptclr))) {
                    txtaccdeptclr.focus();
                    alert("Please enter Accounts Department Clearance from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtnetworkclr))) {
                    txtnetworkclr.focus();
                    alert("Please enter Network Administartion Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txthrdeptclr))) {
                    txthrdeptclr.focus();
                    alert("Please enter HR Department Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtaccdeleclr))) {
                    txtaccdeleclr.focus();
                    alert("Please enter User Account Deletion Request from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtdottedlinemanager))) {
                    txtdottedlinemanager.focus();
                    alert("Please enter Dotted Line Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthrcb))) {
                    txthrcb.focus();
                    alert("Please enter HR C&B from Approver's Details Tab.");
                    return false;
                }

                return true;
            }

            function IsEmpty(aTextField) {
                if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                    return true;
                }
                else {
                    return false;
                }
            }
        </script>

        <script type="text/javascript">
            function ValidateApprover() {
                var txtreportmanager = document.getElementById('<%=txtreportmanager.ClientID %>'); //Line Manager

                var dottedlinemanager = document.getElementById('<%=txtdottedlinemanager.ClientID %>');
                //Dotted Line Manager
                var txtbusinesshead = document.getElementById('<%=txtbusinesshead.ClientID %>'); //Business Head
                var txtfncmang = document.getElementById('<%=txtfncmang.ClientID %>'); //Account Manager

                var txtadmin = document.getElementById('<%=txtadmin.ClientID %>');  //Admin
                var txthr = document.getElementById('<%=txthr.ClientID %>');        //HR TA
                var hrcb = document.getElementById('<%=txthrcb.ClientID %>');                                                                    // HR-C&B
                var txthrd = document.getElementById('<%=txthrd.ClientID %>');      //HR-BP

                var txtmng = document.getElementById('<%=txtmng.ClientID %>');               //Management/MD

                var txtdeptclr = document.getElementById('<%=txtdeptclr.ClientID %>');       //Departmental Clearance
                var txtadminclr = document.getElementById('<%=txtadminclr.ClientID %>');     //General Administration Clearance
                var txtaccdeptclr = document.getElementById('<%=txtaccdeptclr.ClientID %>'); //Accounts Department Clearance
                var txtnetworkclr = document.getElementById('<%=txtnetworkclr.ClientID %>'); //Network Administration Clearance
                var txthrdeptclr = document.getElementById('<%=txthrdeptclr.ClientID %>');   //HR Department Clearance
                var txtaccdeleclr = document.getElementById('<%=txtaccdeleclr.ClientID %>'); // User Account Deletion Request

                if ((IsEmpty(txtreportmanager))) {
                    txtreportmanager.focus();
                    alert("Please enter Reporting Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtbusinesshead))) {
                    txtbusinesshead.focus();
                    alert("Please enter Business Head from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtadmin))) {
                    txtadmin.focus();
                    alert("Please enter Admin from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthr))) {
                    txthr.focus();
                    alert("Please enter  HR Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthrd))) {
                    txthrd.focus();
                    alert("Please enter HRD Manager from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtmng))) {
                    txtmng.focus();
                    alert("Please enter Management/MD from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtdeptclr))) {
                    txtdeptclr.focus();
                    alert("Please enter Departmental Clearance from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtadminclr))) {
                    txtadminclr.focus();
                    alert("Please enter General Administartion Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtfncmang))) {
                    txtfncmang.focus();
                    alert("Please enter Finance Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtaccdeptclr))) {
                    txtaccdeptclr.focus();
                    alert("Please enter Accounts Department Clearance from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtnetworkclr))) {
                    txtnetworkclr.focus();
                    alert("Please enter Network Administartion Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txthrdeptclr))) {
                    txthrdeptclr.focus();
                    alert("Please enter HR Department Clearance from Approver's Details Tab.");
                    return false;
                }
                if ((IsEmpty(txtaccdeleclr))) {
                    txtaccdeleclr.focus();
                    alert("Please enter User Account Deletion Request from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txtdottedlinemanager))) {
                    txtdottedlinemanager.focus();
                    alert("Please enter Dotted Line Manager from Approver's Details Tab.");
                    return false;
                }

                if ((IsEmpty(txthrcb))) {
                    txthrcb.focus();
                    alert("Please enter HR C&B from Approver's Details Tab.");
                    return false;
                }

                return true;
            }
        </script>

        <script type="text/javascript">
            function ValidateData() {
                var Salutation = document.getElementById('<%=ddlSalutation.ClientID %>');
                var FName = document.getElementById('<%=txtfirstname.ClientID %>');
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                var Machinecode = document.getElementById('<%=txt_card_no.ClientID %>');
                var businessunit = document.getElementById('<%=ddl_broadgroup.ClientID %>');
                var Password = document.getElementById('<%=txtpwd.ClientID %>');
                var Gender = document.getElementById('<%=drpgender.ClientID %>');
                var Branch = document.getElementById('<%=drpbranch.ClientID %>');
                var DepartmentType = document.getElementById('<%=drpdepartmenttype.ClientID %>');
                var Department = document.getElementById('<%=drpdepartment.ClientID %>');
                var EmpDesignation = document.getElementById('<%=drpdegination.ClientID %>');
                var EmpRole = document.getElementById('<%=drprole.ClientID %>');
                var EmpStatus = document.getElementById('<%=drpempstatus.ClientID %>');
                var EmpDateofJoin = document.getElementById('<%=doj.ClientID %>');
                var offemailid = document.getElementById('<%=txt_officialemail.ClientID %>');

                var dol, conformationdate, lblcondate;
                if (Salutation.value == 0) {
                    Salutation.focus();
                    alert("Please select title from Job Details Tab.");
                    return false;
                }
                if ((IsEmpty(FName))) {
                    FName.focus();
                    alert("Please enter employee name from Job Details Tab.");
                    return false;
                }
                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }
                if ((IsEmpty(Machinecode))) {
                    Machinecode.focus();
                    alert("Please enter Employee No from Job Details Tab.");
                    return false;
                }
                if (Gender.value == 0) {
                    Gender.focus();
                    alert("Please select gender from Job Details Tab.");
                    return false;
                }
                if (Branch.value == 0) {
                    Branch.focus();
                    alert("Please select worklocation from Job Details Tab.");
                    return false;
                }

                if (drpdepartmenttype.value == 0) {
                    drpdepartmenttype.focus();
                    alert("Please select worklocation from Job Details Tab.");
                    return false;
                }
                if (Department.value == 0) {
                    Department.focus();
                    alert("Please select department from Job Details Tab.");
                    Department.focus();
                    return false;
                }
                if (EmpDesignation.value == 0) {
                    EmpDesignation.focus();
                    alert("Please select employee designation from Job Details Tab.");
                    return false;
                }
                if (EmpRole.value == 0) {
                    EmpRole.focus();
                    alert("Please select employee role from Job Details Tab.");
                    return false;
                }
                if (EmpStatus.value == 0) {
                    EmpStatus.focus();
                    alert("Please select employee status from Job Details Tab.");
                    return false;
                }
                else if (EmpStatus.value == 4) {
                    dol = document.getElementById('<%=txtdol.ClientID %>');
                }
                else if (EmpStatus.value != 3) {
                    lblcondate = document.getElementById('<%=lblprob.ClientID%>').innerText;
                    conformationdate = document.getElementById('<%=txt_confirmationdate.ClientID %>');
                }
        if (IsEmpty(EmpDateofJoin)) {
            EmpDateofJoin.focus();
            alert("Please enter date of joining from Job Details Tab.");
            return false;
        }
        if (IsEmpty(offemailid)) {
            offemailid.focus();
            alert("Please enter official email id from Job Details Tab.");
            return false;
        }
                //if (businessunit.value == 0) {
                //    businessunit.focus();
                //    alert("Please select business unit from Job Details Tab.");
                //    return false;
                //}
















                //if (lblcondate == "Probation End date") {
                //    if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'Pro')))
                //        return false;
                //}
                //if (lblcondate == "Confirmation Date") {
                //    if (!(validateEmphistorydate(EmpDateofJoin, conformationdate, 'C')))
                //        return false;
                //}

                //if (EmpStatus.value == 4) {
                //    if (!(validateEmphistorydate(EmpDateofJoin, dol, 'R')))
                //        return false;
                //}

                //if (!(validateEmphistorydate(doa, EmpDateofJoin, 'DOB')))
                //    return false;

        return true;
    }

    function IsEmpty(aTextField) {
        if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
            return true;
        }
        else {
            return false;
        }
    }
        </script>

        <script type="text/javascript">

            function ValidatePersonalDetails() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');

                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }

                var passfrmdate = document.getElementById('<%=txt_passportissueddate.ClientID %>');
                var passtodate = document.getElementById('<%=txt_passportexpdate.ClientID %>');
                var dlfrmdate = document.getElementById('<%=txt_dr_iss_date.ClientID %>');
                var dltodate = document.getElementById('<%=txt_dr_exp_date.ClientID %>');
                if (!(validateEmphistorydate(passfrmdate, passtodate, 'P')))
                    return false;

                if (!(validateEmphistorydate(dlfrmdate, dltodate, 'D')))
                    return false;

                var martialstatus = document.getElementById('<%=ddlpersonalstatus.ClientID %>');

                var spousedob, spousedoa;

                if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {

                    spousedob = document.getElementById('<%=txt_s_DOB.ClientID %>');
                    spousedoa = document.getElementById('<%=txt_doa.ClientID %>');
                }
                if ((martialstatus.value != 0) && (martialstatus.value != "Unmarried")) {
                    if (!(validateEmphistorydate(spousedob, spousedoa, 'S')))
                        return false;
                }


                return true;
            }
        </script>

        <script type="text/javascript">
            function IsNumeric(eventObj) {

                var keycode;

                if (eventObj.keyCode) //For IE
                    keycode = eventObj.keyCode;
                else if (eventObj.Which)
                    keycode = eventObj.Which;  // For FireFox
                else
                    keycode = eventObj.charCode; // Other Browser

                if (keycode != 8) //if the key is the backspace key
                {
                    if (keycode < 48 || keycode > 57) //if not a number
                        return false; // disable key press
                    else
                        return true; // enable key press
                }
            }

            function isAlpha(keyCode) {

                return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9)

            }

            function isAddress(keyCode) {

                return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9 || keyCode == 13 || keyCode == 51 || keyCode == 50)
            }

            function validateEmail(obj) {
                var x = obj.value;
                if (x != '') {
                    var atpos = x.indexOf("@");
                    var dotpos = x.lastIndexOf(".");
                    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                        obj.focus();
                        alert("Not a valid e-mail address");
                        return false;
                    }
                }
            }

            function capitalizeMe(obj) {
                val = obj.value;
                newVal = '';
                val = val.split(' ');
                for (var c = 0; c < val.length; c++) {
                    newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
                }
                obj.value = newVal.trim();
            }

        </script>

        <script type="text/javascript" language="javascript">
            function fnValidatePAN(Obj) {

                if (Obj == null) Obj = window.event.srcElement;
                if (Obj.value != "") {
                    ObjVal = Obj.value;
                    var panPat = /^([a-zA-Z]{5})(\d{4})([a-zA-Z]{1})$/;
                    var code = /([C,P,H,F,A,T,B,L,J,G])/;
                    var code_chk = ObjVal.substring(3, 4);
                    if (ObjVal.search(panPat) == -1) {
                        alert("Invalid Pan No");
                        Obj.value = "";
                        Obj.focus();
                        return false;
                    }
                    if (code.test(code_chk) == false) {
                        alert("Invaild PAN Card No.");
                        Obj.value = "";
                        return false;
                    }
                }
            }
        </script>

        <script type="text/javascript">
            function ValidateContact() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }
                return true;
                //$("#li_tabs2").find("input,button,textarea,select").prop("disabled", false);
                //$("#li_tabs3").find("input,button,textarea,select").prop("disabled", false);
                //$("#li_tabs4").find("input,button,textarea,select").attr("disabled", "disabled");
                //$("#li_tabs5").find("input,button,textarea,select").attr("disabled", "disabled");
            }
        </script>

        <script type="text/javascript">
            function ValidateProp() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }
                return true;
            }
        </script>

        <script type="text/javascript">


            function ValidateEducation() {
                var education = document.getElementById('<%=drp_edu_qualification.ClientID %>');
                var specilization = document.getElementById('<%=txtedu_specilazation.ClientID %>');
                var inistitute = document.getElementById('<%=txtedush.ClientID %>');
                var fromyear = document.getElementById('<%=txtedufrom.ClientID %>');
                var toyear = document.getElementById('<%=txteduto.ClientID %>');
                var grade = document.getElementById('<%=txteduper.ClientID %>');

                if (education.value == 0) {
                    education.focus();
                    alert("Please select education from Educational Qualification.");
                    return false;
                }

                if ((IsEmpty(specilization))) {
                    specilization.focus();
                    alert("Please enter specialization from Educational Qualification.");
                    return false;
                }

                if ((IsEmpty(inistitute))) {
                    inistitute.focus();
                    alert("Please enter Institute / University Name from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(grade))) {
                    grade.focus();
                    alert("Please enter Grade/% from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Educational Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Educational Qualification.");
                    return false;
                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }

                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in Educational Qualification");
                        return false;
                    }

                return true;
            }
        </script>

        <script type="text/javascript">
            function ValidateProfessional() {
                var education = document.getElementById('<%=txteduc1.ClientID %>');
                var specilization = document.getElementById('<%=txtpro_specilazation.ClientID %>');
                var inistitute = document.getElementById('<%=txtsch1.ClientID %>');
                var fromyear = document.getElementById('<%=txtfrm1.ClientID %>');
                var toyear = document.getElementById('<%=txtto1.ClientID %>');
                var grade = document.getElementById('<%=txtper1.ClientID %>');

                if (education.value == 0) {
                    education.focus();
                    alert("Please select education from Professional Qualification");
                    return false;
                }

                if ((IsEmpty(specilization))) {
                    specilization.focus();
                    alert("Please enter specialization from Professional Qualification.");
                    return false;
                }

                if ((IsEmpty(inistitute))) {
                    inistitute.focus();
                    alert("Please enter Institute / University Name from  Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(grade))) {
                    grade.focus();
                    alert("Please enter Grade/% from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Professional Qualification.");
                    return false;

                }
                if (fromyear.value < '1900' || fromyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (toyear.value < '1900' || toyear.value > '2100') {
                    alert("Enter The Valid Year");
                }
                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in  Professional Qualification");
                        return false;
                    }

                return true;
            }
        </script>

        <script type="text/javascript">

            function ValidateCompany() {
                var companyname = document.getElementById('<%=txtcomp1.ClientID %>');
                var location = document.getElementById('<%=txt_com_local.ClientID %>');
                var desingation = document.getElementById('<%=txt_EXp_designation.ClientID %>');
                var fromyear = document.getElementById('<%=txt_exp_from.ClientID %>');
                var toyear = document.getElementById('<%=txt_exp_to.ClientID %>');
                var experince = document.getElementById('<%=txt_total_exp.ClientID %>');

                if ((IsEmpty(companyname))) {
                    companyname.focus();
                    alert("Please enter Company Name from Experience Details.");
                    return false;
                }

                if ((IsEmpty(location))) {
                    location.focus();
                    alert("Please enter Address/Location from Experience Details.");
                    return false;
                }

                if ((IsEmpty(desingation))) {
                    desingation.focus();
                    alert("Please enter desingation from Experience Details.");
                    return false;
                }
                if ((IsEmpty(experince))) {
                    experince.focus();
                    alert("Please enter Total Exp.(in years) from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(fromyear))) {
                    fromyear.focus();
                    alert("Please enter From Year from Professional Qualification.");
                    return false;
                }
                if ((IsEmpty(toyear))) {
                    toyear.focus();
                    alert("Please enter To Year from Professional Qualification.");
                    return false;
                }
                //if (fromyear.value < '1900' || fromyear.value > '2100') {
                //    alert("Enter The Valid Year");
                //}
                //if (toyear.value < '1900' || toyear.value > '2100') {
                //    alert("Enter The Valid Year");
                //  }
                if (fromyear.value != '' && toyear.value != '')
                    if (fromyear.value > toyear.value) {
                        fromyear.focus();
                        alert("To-Year should be greaterthan or equal to From-Year in Experience Details.");
                        return false;
                    }
                return true;
            }
        </script>

        <script type="text/javascript" lang="javascript">
            function ValidateTraining() {

                var program = document.getElementById('<%=txt_TrProgram.ClientID %>');
                var conductedby = document.getElementById('<%=txt_TrConductedBy.ClientID %>');
                var fromdate = document.getElementById('<%=txtFromdate.ClientID %>');
                var todate = document.getElementById('<%=txtToDate.ClientID %>');
                var remarks = document.getElementById('<%=txtTrRemarks.ClientID %>');

                if ((IsEmpty(program))) {
                    program.focus();
                    alert("Please enter Training Name from Training Details.");
                    return false;
                }

                if ((IsEmpty(conductedby))) {
                    conductedby.focus();
                    alert("Please enter Conducted By from Training Details.");
                    return false;
                }
                if ((IsEmpty(fromdate))) {
                    fromdate.focus();
                    alert("Please enter From Date from Training Details.");
                    return false;
                }

                if ((IsEmpty(todate))) {
                    todate.focus();
                    alert("Please enter To Date from Training Details.");
                    return false;
                }
                if ((IsEmpty(remarks))) {
                    remarks.focus();
                    alert("Please enter Remarks from Training Details.");
                    return false;
                }
                //if (validateEmphistorydate(fromdate, todate, 'T') == true)
                //    return true;
                //else
                //    return false;
                return true;
            }

        </script>

        <%--  <script type="text/javascript">
            function validateEmphistorydate(fromdate, todate, type) {
                if ((fromdate.value.trim() != "") && (todate.value.trim() != "")) {
                    var startdate = new Date(fromdate.value.trim());
                    var enddate = new Date(todate.value.trim());
                    if (startdate > enddate) {
                        if (type == 'T') {
                            alert('From Date should be less than To Date.')
                            return false;
                        }
                        else if (type == 'P') {
                            alert('Passport Issued Date should be less than Passport Expiry  Date.')
                            return false;
                        }
                        else if (type == 'D') {
                            alert('DL Issued Date should be less than DL Expiry  Date.')
                            return false;
                        }
                        else if (type == 'S') {
                            alert('Spouse Date of Birth should be less than Spouse Date of anniversary Date.')
                            return false;
                        }
                        else if (type == 'Pro') {
                            alert('Date of Joining should be less than Probation End Date.')
                            return false;
                        }
                        else if (type == 'C') {
                            alert('Date of Joining should be less than Confirmation Date.')
                            return false;
                        }
                        else if (type == 'R') {
                            alert('Date of Joining should be less than Date of Leaving.')
                            return false;
                        }
                        else if (type == 'DOB') {
                            alert('Date of Birth should be less than Date of Joining.')
                            return false;
                        }
                    }
                    else
                        return true;
                }
                return true;
            }

        </script>--%>

        <script type="text/javascript">
            function validateEmphistorydate(fromdate, todate, type) {
                if ((fromdate.value.trim() != "") && (todate.value.trim() != "")) {
                    var startdate = new Date(fromdate.value.trim());
                    var enddate = new Date(todate.value.trim());
                    if (startdate >= enddate) {
                        if (type == 'T') {
                            alert('From Date should be less than To Date.')
                            return false;
                        }
                        else if (type == 'P') {
                            alert('Passport Issued Date should be less than Passport Expiry  Date.')
                            return false;
                        }
                        if (fromyear.value < '1900' || fromyear.value > '2100') {
                            alert("Enter The Valid Year");
                        }
                        if (toyear.value < '1900' || toyear.value > '2100') {
                            alert("Enter The Valid Year");
                        }
                        else if (type == 'D') {
                            alert('DL Issued Date should be less than DL Expiry  Date.')
                            return false;
                        }
                        if (fromyear.value < '1900' || fromyear.value > '2100') {
                            alert("Enter The Valid Year");
                        }
                        if (toyear.value < '1900' || toyear.value > '2100') {
                            alert("Enter The Valid Year");
                        }
                        else if (type == 'S') {
                            alert('Spouse Date of Birth should be less than Spouse Date of anniversary Date.')
                            return false;
                        }
                        else if (type == 'Pro') {
                            alert('Date of Joining should be less than Probation End Date.')
                            return false;
                        }
                        else if (type == 'C') {
                            alert('Date of Joining should be less than Confirmation Date.')
                            return false;
                        }
                        else if (type == 'R') {
                            alert('Date of Joining should be less than Date of Leaving.')
                            return false;
                        }
                        else if (type == 'DOB') {
                            alert('Date of Birth should be less than Date of Joining.')
                            return false;
                        }
                        else if (type == 'K') {
                            alert('Employee Date of Birth should be less than Date of Anniversary.')
                            return false;
                        }
                        else if (type == 'E') {
                            alert('Period TO date should be less than Period From date ')
                            return false;
                        }
                    }
                    else
                        return true;
                }
                return true;
            }

        </script>

        <script type="text/javascript" lang="javascript">
            function ValidateChildren() {

                var childname = document.getElementById('<%=txt_child_name.ClientID %>');
                var cgend = document.getElementById('<%=ddl_child_gender.ClientID %>');
                var cdob = document.getElementById('<%=txt_child_Dob.ClientID %>');

                if ((IsEmpty(childname))) {
                    childname.focus();
                    alert("Please enter child name from Personal Details Tab.");
                    return false;
                }

                if (cgend.value == 0) {
                    cgend.focus();
                    alert("Please select child gender from Personal Details Tab.");
                    return false;
                }

                if (validateEmphistorydate(fromdate, todate, 'T') == true)
                    return true;
                else
                    return false;
                return true;
            }
        </script>

        <script type="text/javascript" lang="javascript">
            function ValidateEmg() {

                var emgname = document.getElementById('<%=txt_emergency_name.ClientID %>');
                var emgrelation = document.getElementById('<%=drp_emg_relation.ClientID %>');
                var emgphno = document.getElementById('<%=txt_emergency_contactno.ClientID %>');
                var emgccphno = document.getElementById('<%=txt_emg_ccode.ClientID %>');
                var emglandno = document.getElementById('<%=txt_emg_landlineno.ClientID %>');
                var emglandstdno = document.getElementById('<%=txt_emg_landlinestdcode.ClientID %>');
                var emglandccno = document.getElementById('<%=txt_emg_landcode.ClientID %>');

                if ((IsEmpty(emgname))) {
                    emgname.focus();
                    alert("Please enter Emergency Contact name from Contact Details Tab.");
                    return false;
                }

                if (emgrelation.value == 0) {
                    emgrelation.focus();
                    alert("Please enter Emergency Contact Relation from Contact Details Tab.");
                    return false;
                }

                if ((IsEmpty(emgccphno))) {
                    emgccphno.focus();
                    alert("Please enter Emergency Contact Contry Code from Contact Details Tab.");
                    return false;
                }

                if ((IsEmpty(emgphno))) {
                    emgphno.focus();
                    alert("Please enter Emergency Contact No. from Contact Details Tab.");
                    return false;
                }
                if ((IsEmpty(emglandccno))) {
                    emglandccno.focus();
                    alert("Please enter Emergency Conatct No. from Contact Details Tab.");
                    return false;
                }
                if ((IsEmpty(emglandstdno))) {
                    emglandstdno.focus();
                    alert("Please enter Emergency LandLine Std. Code from Contact Details Tab.");
                    return false;
                }
                if ((IsEmpty(emglandno))) {
                    emglandno.focus();
                    alert("Please enter Emergency LandLine No. from Contact Details Tab.");
                    return false;
                }
                return true;
            }
        </script>

        <script type="text/javascript">
            function validateUpload() {
                var Empcode = document.getElementById('<%=txtempcode.ClientID %>');
                if ((IsEmpty(Empcode))) {
                    Empcode.focus();
                    alert("Please enter employee code from Job Details Tab.");
                    return false;
                }
                return true;
            }
        </script>

        <script type="text/javascript">
            function ValidatePhoneNo() {
                if ((event.keyCode > 47 && event.keyCode < 58) || event.keyCode == 43 || event.keyCode == 32)
                    return event.returnValue;
                return event.returnValue = '';
            }
        </script>

        <script type="text/javascript">
            function IsNumeric(eventObj) {

                var keycode;

                if (eventObj.keyCode) //For IE
                    keycode = eventObj.keyCode;
                else if (eventObj.Which)
                    keycode = eventObj.Which;  // For FireFox
                else
                    keycode = eventObj.charCode; // Other Browser

                if (keycode != 8) //if the key is the backspace key
                {
                    if (keycode < 48 || keycode > 57) //if not a number
                        return false; // disable key press
                    else
                        return true; // enable key press
                }
            }
        </script>

    </form>

</body>
</html>

