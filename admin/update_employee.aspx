<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update_employee.aspx.cs" EnableEventValidation="false" Inherits="admin_update_employee"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee Update View" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            color: red;
        }

        .auto-style1 {
            border-left: 1px solid #d9d9d9;
            border-top: 1px solid #d9d9d9;
            background: #fafafa;
            padding: 9px;
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #555;
            width: 46%;
            border-right-style: none;
            border-right-color: inherit;
            border-right-width: medium;
            border-bottom-style: none;
            border-bottom-color: inherit;
            border-bottom-width: medium;
        }

        .auto-style3 {
            width: 51%;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script src="../admin/js/popup.js"></script>
    <!-- Custom Js -->
    <%--  <script src="../js/theming.js" type="text/javascript"></script>
    <script src="../js/custom.js" type="text/javascript"></script>--%>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>
    <script src="../js/JavaScriptValidations.js"></script>

    <%-- <script type="text/javascript">
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>--%>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- Validations -->


        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Update Employee Details</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information
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
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">Salutation
                                                                            </td>
                                                                            </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:TextBox ID="txt_salutaion" runat="server" Enabled="false" CssClass="span11"></asp:TextBox>
                                                                                        <asp:DropDownList ID="ddlSalutation" runat="server" Visible="false" CssClass="span11" OnSelectedIndexChanged="ddlSalutation_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="Mr">MR</asp:ListItem>
                                                                                            <asp:ListItem Value="Ms">MS</asp:ListItem>
                                                                                            <asp:ListItem Value="Mrs">MRS</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                        </tr>

                                                                        <asp:HiddenField ID="HiddenTodayDate" runat="server" />
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">First Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:TextBox ID="txtfirstname" runat="server" placeholder="Max. 50 Char.." CssClass="span11" MaxLength="200" ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr1" style="height: 50px" runat="server" visible="true">
                                                                            <td class="frm-lft-clr123" width="48%">Middle Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:TextBox ID="txtmiddlename" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr2" style="height: 50px" runat="server" visible="true">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Last Name<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                <asp:TextBox ID="txtlastname" runat="server" CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr53" style="height: 50px" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Alias
                                                                            </td>
                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                <asp:TextBox ID="TextBox170" runat="server" placeholder="Max. 50 Char.." CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr54" style="height: 50px" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Suffix1
                                                                            </td>
                                                                            <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                <asp:TextBox ID="TextBox171" runat="server" placeholder="Max. 50 Char.." CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                         <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom">Type
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:DropDownList ID="ddlType" runat="server" CssClass="span11" Enabled="true">
                                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                              <%--  <asp:ListItem Value="1">Employee History</asp:ListItem>--%>
                                                                                                <asp:ListItem Value="2">Employee Promotion</asp:ListItem>
                                                                                                <asp:ListItem Value="3">Employee Transfer </asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>

                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
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
                                                                                                <%--<tr>
                                                                                                <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                                                                                </td>
                                                                                            </tr>--%>
                                                                                            </table>
                                                                                        </div>
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                                <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0" style="height: 50px">
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123" width="45%">Employee Code<span class=""></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123" width="54%">
                                                                                            <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <%--<tr style="height: 50px">
                                                                                        <td width="48%" class="frm-lft-clr123 border-bottom">Employee No.<span class="star"></span>
                                                                                        </td>
                                                                                        <td width="52%" class="frm-rght-clr123 border-bottom">
                                                                                            <asp:TextBox ID="txt_card_no" runat="server" CssClass="span11" placeholder="Max. 50 Char.." MaxLength="100"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>--%>
                                                                                    <tr style="height: 50px">
                                                                                        <td class="frm-lft-clr123 border-bottom">Gender
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                                            <asp:TextBox ID="txt_gender" runat="server" CssClass="span11" Enabled="false" ></asp:TextBox>
                                                                                            <asp:DropDownList ID="drpgender" runat="server" Visible="false" CssClass="span11" OnSelectedIndexChanged="drpgender_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                                                                                <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                <asp:ListItem Value="MALE">Male</asp:ListItem>
                                                                                                <asp:ListItem Value="FEMALE">Female</asp:ListItem>
                                                                                                <asp:ListItem Value="THIRD">Third</asp:ListItem>
                                                                                                <asp:ListItem Value="NOT APPLICABLE">Not Applicable</asp:ListItem>
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="48%">Date of Joining<span class="star"></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                            <asp:TextBox ID="doj" runat="server" CssClass="span11" AutoPostBack="true" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"
                                                                                                OnTextChanged="doj_TextChanged"></asp:TextBox>&#160;<asp:Image ID="Image4" runat="server"
                                                                                                    ImageUrl="~/img/clndr.gif" placeholder="Select Date" />

                                                                                            <cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                                ID="CalendarExtender4" runat="server" PopupButtonID="Image4" TargetControlID="doj"
                                                                                                Enabled="True">
                                                                                            </cc1:CalendarExtender>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="48%">Effective From Date<span class=""></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                            <asp:TextBox ID="txt_effectivedate" runat="server" CssClass="span11" AutoPostBack="true" placeholder="Select Date" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&#160;<asp:Image ID="Image1" runat="server"
                                                                                                ImageUrl="~/img/clndr.gif" placeholder="Select Date" />

                                                                                            <cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                                ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_effectivedate"
                                                                                                Enabled="True">
                                                                                            </cc1:CalendarExtender>
                                                                                        </td>
                                                                                    </tr>

                                                                                   

                                                                                    <tr>
                                                                                        <td class="frm-lft-clr123 border-bottom" width="48%">Remarks<span class=""></span>
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                            <asp:TextBox ID="txt_remarks" runat="server" CssClass="span11"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>

                                                                                    <tr id="Tr55" style="height: 50px" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="48%">Suffix2
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                            <asp:TextBox ID="TextBox172" runat="server" placeholder="Max. 50 Char.." CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr id="Tr56" style="height: 50px" runat="server" visible="false">
                                                                                        <td class="frm-lft-clr123 border-bottom" width="48%">Suffix3
                                                                                        </td>
                                                                                        <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                                            <asp:TextBox ID="TextBox173" runat="server" placeholder="Max. 50 Char.." CssClass="span11" MaxLength="50" onblur="capitalizeMe(this)" onkeypress="return isCharOrSpace()" Enabled="false"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr id="Tr3" style="height: 50px" runat="server" visible="false">
                                                                    <td width="45%" class="frm-lft-clr123 border-bottom">Employee Photo.<span class=""></span>
                                                                    </td>
                                                                    <td width="54%" class="frm-rght-clr123 border-bottom">
                                                                        <asp:Image ID="empimg" runat="server" Height="120px" Width="120px" ImageUrl="Upload/photo/image.jpg"></asp:Image>
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Job</li>

                                    </ol>
                                    <div style="height:auto">
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
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr id="Tr4" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%"><%--Broad Group--%> Business Unit
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="240px">
                                                                                        <asp:DropDownList ID="ddl_broadgroup" runat="server" CssClass="span11">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Branch <%--Work Location--%><span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpbranch" runat="server" CssClass="span11" Height="" Width="" Enabled="false" OnDataBound="drpbranch_DataBound"
                                                                                            AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Department Type<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" CssClass="span11" Height=""
                                                                                            Width="230px" OnDataBound="DropDownList6_DataBound">
                                                                                        </asp:DropDownList>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="DropDownList6"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department Type" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Department<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdepartmenttype" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpdepartmenttype_SelectedIndexChanged" CssClass="span11" Height=""
                                                                                            Width="230px" OnDataBound="drpdepartmenttype_DataBound">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123">Designation<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdegination" runat="server" CssClass="span11" OnDataBound="drpdegination_DataBound" OnSelectedIndexChanged="drpdegination_SelectedIndexChanged" AutoPostBack="true">
                                                                                        </asp:DropDownList>
                                                                                        <%-- <asp:SqlDataSource ID="sql_data_degination"
                                                                                            runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>--%>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="Tr5" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Grade
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpgrade" runat="server" CssClass="span11"
                                                                                            OnDataBound="drpgrade_DataBound" OnSelectedIndexChanged="drpgrade_SelectedIndexChanged" AutoPostBack="true">
                                                                                        </asp:DropDownList>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="Tr6" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123">Department<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="drpdepartment" runat="server" AutoPostBack="true" CssClass="span11" Height=""
                                                                                            Width="230px" OnDataBound="drpdepartment_DataBound">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>




                                                                                <tr id="Tr7" style="height: 50px" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" width="52%">
                                                                                        <asp:DropDownList ID="drpdivision" runat="server" CssClass="span11" Height=""
                                                                                            Width="" DataSourceID="SqlDatasource_division" DataTextField="division_name"
                                                                                            DataValueField="ID" OnDataBound="drpdivision_DataBound">
                                                                                            <asp:ListItem Value="0">Select</asp:ListItem>
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
                                                                                <tr id="Tr8" style="height: 50px" runat="server" visible="false">
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
                                                                                            DataSourceID="Sql_data_role" DataTextField="role" DataValueField="id" OnDataBound="drprole_DataBound" Enabled="false">
                                                                                        </asp:DropDownList>

                                                                                        <asp:SqlDataSource
                                                                                            ID="Sql_data_role" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [role] FROM [tbl_intranet_role] where id not in (16)"></asp:SqlDataSource>

                                                                                    </td>
                                                                                </tr>

                                                                             

                                                                            



                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123  border-bottom" width="48%">Employment Status<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:DropDownList ID="drpempstatus" runat="server" CssClass="span11" Height="" Enabled="false"
                                                                                            Width=""
                                                                                            OnDataBound="drpempstatus_DataBound" AutoPostBack="true" OnSelectedIndexChanged="drpempstatus_SelectedIndexChanged1">
                                                                                        </asp:DropDownList>


                                                                                    </td>
                                                                                </tr>


                                                                                <tr id="trprobationperiod" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_probationperiod" runat="server" CssClass="span11" placeholder="Max. 2 Char.."
                                                                                            MaxLength="2" AutoPostBack="true" onkeypress=" return isNumberKey(event)" OnTextChanged="txt_probationperiod_TextChanged"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trduptstart" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                                        <asp:TextBox ID="txt_deput_start_date" runat="server" placeholder="Select Date" CssClass="span11" Width="228px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                        &nbsp;
                                                                                <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" Style="position: absolute; padding-top: 6px" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                                                                            TargetControlID="txt_deput_start_date" Enabled="True" Format="dd-MMM-yyyy">
                                                                                        </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr id="trprobationdate3" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom"><%--Confirmation Date--%><asp:Label ID="lblprob" runat="server"></asp:Label><span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_confirmationdate" Enabled="false" runat="server" placeholder="Select Date" CssClass="span10" Width="228px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image13" runat="server" ImageUrl="~/img/clndr.gif" Style="position: absolute; padding-top: 6px" />
                                                                                        <cc1:CalendarExtender Format="dd-MMM-yyyy"
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
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Last Working Date<span class="star"></span></td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txtdol" runat="server" CssClass="span10" placeholder="Select Date" Width="228px" onblur="return JobCompareDates();" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" Style="position: absolute; padding-top: 6px" />
                                                                                        <cc1:CalendarExtender Format="dd-MMM-yyyy"
                                                                                            ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtdol"
                                                                                            Enabled="True">
                                                                                        </cc1:CalendarExtender>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr id="trReasonL" runat="server" visible="false" style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%" style="border-top: none;">Reason for Leaving
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                                                                        <asp:TextBox ID="txtreason" runat="server" CssClass="span11" MaxLength="200" placeholder="Max 200 Chars.." ondrop="return false;" onpaste="return false;"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                            </table>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                                <td valign="top">

                                                                    <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                        <tr style="height: 0px">
                                                                            <td colspan="2">
                                                                                <asp:UpdatePanel ID="upl" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="upl"
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
                                                                                        <table width="100%" border="0" align="right" cellpadding="0" cellspacing="0" style="height: 0px">
                                                                                        </table>
                                                                                    </ContentTemplate>
                                                                                </asp:UpdatePanel>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr9" style="height: 50px;" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123">Salary Calculation From <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txtsalary" placeholder="Select Date" runat="server" CssClass="span11" Width="180px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                <asp:Image ID="Image6" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="Image6" Format="dd-MMM-yyyy"
                                                                                    TargetControlID="txtsalary" Enabled="True">
                                                                                </cc1:CalendarExtender>
                                                                            </td>
                                                                        </tr>

                                                                        
                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123">Offical Mail ID<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_officialemail" placeholder="Max 50 Chars.." runat="server" CssClass="span11"
                                                                                    MaxLength="50" Enabled="false"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatormailId" runat="server"
                                                                                    ControlToValidate="txt_officialemail" ToolTip="Please Enter Correct Email Id" ValidationGroup="C"
                                                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                                                      <img src="../img/error1.gif" alt="" /></asp:RegularExpressionValidator>

                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123" width="48%">Official Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                <asp:TextBox ID="txtcountrycode" Width="30px" placeholder="+91" runat="server" MaxLength="4" Enabled="false">+91</asp:TextBox>&nbsp;
                                                                                        <asp:TextBox ID="txtoff_mobileno" Width="177px" placeholder="Max 10 Chars.." runat="server" CssClass="span11" MaxLength="10" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                            </td>
                                                                        </tr>


                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123 border-bottom" width="45%">Official Landline No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="55%">
                                                                                <asp:TextBox ID="TextBox16" runat="server" Width="30px" placeholder="+91" MaxLength="4" onkeypress="return IsNumeric(event);" Enabled="false">+91</asp:TextBox>
                                                                                <asp:TextBox ID="TextBox17" onkeypress="return IsNumeric(event);" runat="server" Width="50px" placeholder="Max 5 No..." MaxLength="5" Enabled="false" Visible="false"></asp:TextBox>
                                                                                <asp:TextBox ID="TextBox18" runat="server" CssClass="span11" Width="177px" placeholder="Max 10 Chars.."
                                                                                    MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>

                                                                            </td>
                                                                        </tr>

                                                                        <tr id="Tr10" style="height: 50px" runat="server" visible="false">
                                                                            <td class="frm-lft-clr123" width="48%">Sub Employee Type<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                <asp:DropDownList ID="ddl_semp_type" runat="server" Width="228px"  OnSelectedIndexChanged="ddl_semp_type_SelectedIndexChanged" OnDataBound="ddl_semp_type_DataBound">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>

                                                                        <tr style="height: 50px">
                                                                            <td class="frm-lft-clr123 border-bottom">Extension Number
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:TextBox ID="txtextccode" runat="server" Width="30px" Text="+91" placeholder="Max 4 Chars.." MaxLength="4" Enabled="false" Visible="false"></asp:TextBox>
                                                                                <asp:TextBox ID="txtextstdcode" runat="server" Width="50px" placeholder="Max 5 Chars.." MaxLength="5" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" Enabled="false" Visible="false"></asp:TextBox>
                                                                                <asp:TextBox ID="txtext" runat="server" CssClass="span11" placeholder="Max 10 Chars.."
                                                                                    MaxLength="11" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>

                                                                            </td>
                                                                        </tr>
                                                                           <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123" width="48%">Employee Type<span class=""></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123" colspan="2" width="51%">
                                                                                        <%--<asp:DropDownList ID="ddl_emp_type" runat="server"
                                                                                    CssClass="blue1">
                                                                                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Corporate</asp:ListItem>
                                                                                    <asp:ListItem Value="2">Factory</asp:ListItem>
                                                                                </asp:DropDownList>--%>
                                                                                        <asp:DropDownList ID="ddl_emp_type" runat="server" CssClass="span11" Height="" Width="" Enabled="false"
                                                                                            DataSourceID="sql_emp_type" DataTextField="emp_type_name" DataValueField="emp_type_id"
                                                                                            OnDataBound="ddl_emp_type_DataBound" AutoPostBack="True" OnSelectedIndexChanged="ddl_emp_type_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                        <asp:SqlDataSource
                                                                                            ID="sql_emp_type" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="select emp_type_id,emp_type_name from dbo.tbl_internate_employee_type"></asp:SqlDataSource>

                                                                                    </td>
                                                                                </tr>
                                                                            <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom">Employee Sub Type<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:DropDownList ID="DropDownList5" runat="server" CssClass="span11" Enabled="false"
                                                                                            Height="">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>

                                                                        <tr style="height: 50px" runat="server" visible="false">
                                                                            <td width="48%" class="frm-lft-clr123">PAN Card Available
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123">

                                                                                <asp:RadioButtonList ID="RadioButtonList1" Style="float: left" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true" RepeatLayout="table" Enabled="false">
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                <asp:TextBox Style="float: right" ID="TextBox5" runat="server" CssClass="span9" MaxLength="10" placeholder="Max 10 Chars.." Enabled="false"></asp:TextBox>
                                                                                <%--onblur="fnValidatePAN(this);--%>

                                                                            </td>
                                                                        </tr>
                                                                        <tr runat="server" visible="false">
                                                                            <td width="48%" class="frm-lft-clr123 border-bottom">Adhar Card Available
                                                                            </td>
                                                                            <td width="52%" class="frm-rght-clr123 border-bottom">

                                                                                <asp:RadioButtonList ID="RadioButtonList2" Style="float: left" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="RadioButtonList2_SelectedIndexChanged" AutoPostBack="true" RepeatLayout="table" Enabled="false">
                                                                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                    <asp:ListItem Value="No">No</asp:ListItem>
                                                                                </asp:RadioButtonList>
                                                                                <asp:TextBox Style="float: right" ID="TextBox22" runat="server" CssClass="span9" MaxLength="10" placeholder="Min 12 Chars.." Enabled="false"></asp:TextBox>

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
                                                                                <asp:TextBox ID="txt_probation_date" runat="server" CssClass="span11" placeholder="Max 3 Chars.."
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

                                                                        <tr id="trprobationdate2" runat="server" style="height: 50px" visible="false">
                                                                            <td class="frm-lft-clr123 border-bottom" width="48%">Notice Period
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="51%">
                                                                                <asp:TextBox ID="txt_noticePeriod" runat="server" CssClass="span11" onkeypress="return IsNumeric(event);" placeholder="Max 2 Chars.."
                                                                                    MaxLength="2"></asp:TextBox>

                                                                            </td>
                                                                        </tr>


                                                                        <tr>
                                                                            <td height="15" colspan="2"></td>
                                                                        </tr>
                                                                    </table>

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
                                                <tr runat="server" visible="false">
                                                    <td colspan="2" class="txt02">Payroll Details
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td height="5" colspan="2"></td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td colspan="2">
                                                        <asp:UpdatePanel ID="dd" runat="server" UpdateMode="conditional">
                                                            <ContentTemplate>
                                                                <asp:UpdateProgress ID="UpdateProgress5" runat="server" AssociatedUpdatePanelID="dd"
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
                                                                        <td width="50%" valign="top">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%> Payroll Process Currency
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="span11" Height="" Width="" Enabled="false">
                                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="Rupee">INR</asp:ListItem>
                                                                                            <asp:ListItem Value="Doller">Dollar</asp:ListItem>
                                                                                        </asp:DropDownList>

                                                                                        <%--<%-- <asp:SqlDataSource--%>
                                                                                        <%--ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator35" runat="server" ControlToValidate="DropDownList1"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%> Payment Mode
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:DropDownList ID="DropDownList2" runat="server" CssClass="span11" Height="" Width="" Enabled="false">
                                                                                            <asp:ListItem>--Select--</asp:ListItem>
                                                                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                                                                            <asp:ListItem Value="Credit Card">Credit Card</asp:ListItem>
                                                                                            <asp:ListItem Value="Debit Card">Debit Card</asp:ListItem>
                                                                                        </asp:DropDownList>

                                                                                        <%--<%-- <asp:SqlDataSource--%>
                                                                                        <%--ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator36" runat="server" ControlToValidate="DropDownList2"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>



                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123 border-bottom">UAN Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="txt_uan" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">PF Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="pfno" runat="server" CssClass="span11" MaxLength="31" placeholder="Max 30 Chars.." Enabled="false"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 60px">
                                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                        <asp:TextBox ID="esino" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." Enabled="false"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>


                                                                                <tr runat="server" visible="false">
                                                                                    <td id="Td1" class="frm-lft-clr123 " width="48%" runat="server">CTC Per Annum
                                                                                    </td>
                                                                                    <td id="Td2" class="frm-rght-clr123  " width="52%" runat="server">
                                                                                        <asp:TextBox ID="ward" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." Enabled="true"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>


                                                                                <tr id="Tr11" runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123 border-bottom">PAN Number
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                                        <asp:TextBox ID="panno" runat="server" CssClass="span11" MaxLength="10" placeholder="Max 10 Chars.." onblur="fnValidatePAN(this);" Enabled="false"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td colspan="2" style="height: 5px"></td>
                                                                                </tr>

                                                                                <tr id="trptno" runat="server" visible="False">
                                                                                    <td id="Td3" class="frm-lft-clr123" runat="server">PT No.
                                                                                    </td>
                                                                                    <td id="Td4" class="frm-rght-clr123" runat="server">
                                                                                        <asp:TextBox ID="txt_ptno" runat="server" CssClass="span11" MaxLength="50" placeholder="Max 50 Chars.." Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">

                                                                                <%--<tr>
                                                                                    <td width="48%" class="frm-lft-clr123">Graduity Eligible Year
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">

                                                                                        <asp:RadioButtonList ID="RadioButtonList3" Style="float: left" runat="server" RepeatDirection="Horizontal" RepeatLayout="table">
                                                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                                                            <asp:ListItem Value="Yes">No</asp:ListItem>
                                                                                        </asp:RadioButtonList>
                                                                                        <asp:TextBox Style="float: right" ID="TextBox23" runat="server" CssClass="span9" MaxLength="10" placeholder="Max 10 Chars.."></asp:TextBox>

                                                                                    </td>
                                                                                </tr>--%>
                                                                                <tr runat="server" visible="false">
                                                                                    <td width="48%" class="frm-lft-clr123">ESI Dispensary
                                                                                    </td>
                                                                                    <td width="52%" class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="esidesp" runat="server" CssClass="span11" MaxLength="100" placeholder="Max 100 Chars.." Enabled="false"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>

                                                                                <tr runat="server" visible="false">
                                                                                    <td class="frm-lft-clr123" width="48%">PF Region Office
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 " width="51%">
                                                                                        <asp:TextBox ID="pfno_dept" runat="server" CssClass="span11" MaxLength="50" placeholder="Max 50 Chars.." Enabled="false"></asp:TextBox>

                                                                                    </td>
                                                                                </tr>



                                                                                <tr>
                                                                                    <td id="Td7" class="frm-lft-clr123 " width="48%" runat="server">Bank Name
                                                                                    </td>
                                                                                    <td id="Td8" class="frm-rght-clr123  " width="52%" runat="server">
                                                                                        <asp:TextBox ID="TextBox20" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td id="Td9" class="frm-lft-clr123 " width="48%" runat="server">Bank Branch Name
                                                                                    </td>
                                                                                    <td id="Td10" class="frm-rght-clr123  " width="52%" runat="server">
                                                                                        <asp:TextBox ID="TextBox21" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%>IFSC Code<span class="star"></span>
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="TextBox30" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                                        <asp:DropDownList ID="DropDownList4" runat="server" CssClass="span11" Visible="false" Height="" Width="" DataSourceID="" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                                            AutoPostBack="True">
                                                                                        </asp:DropDownList>

                                                                                        <%--<%-- <asp:SqlDataSource--%>
                                                                                        <%--ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator38" runat="server" ControlToValidate="DropDownList4"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr style="height: 50px">
                                                                                    <td class="frm-lft-clr123"><%--Branch Name--%>Salary Account No.
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:TextBox ID="TextBox29" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                                        <asp:DropDownList ID="DropDownList3" runat="server" Visible="false" CssClass="span11" Height="" Width="" DataSourceID="" DataTextField="branch_name" DataValueField="Branch_Id"
                                                                                             AutoPostBack="True">
                                                                                        </asp:DropDownList>

                                                                                        <%--<%-- <asp:SqlDataSource--%>
                                                                                        <%--ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail] order by branch_name"></asp:SqlDataSource>--%>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator37" runat="server" ControlToValidate="DropDownList3"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="e"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td id="Td5" class="frm-lft-clr123 border-bottom" width="48%" runat="server">Account Type
                                                                                    </td>
                                                                                    <td id="Td6" class="frm-rght-clr123 border-bottom" width="52%" runat="server">
                                                                                        <asp:TextBox ID="TextBox19" runat="server" CssClass="span11" MaxLength="20" placeholder="Max 20 Chars.." ondrop="return false;" onpaste="return false;" Enabled="false"></asp:TextBox>
                                                                                    </td>
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
                                                    <td colspan="2">
                                                        <div class="form-actions no-margin">
                                                            <asp:Button ID="btnjob" runat="server" Text="Update" ValidationGroup="C" CssClass="btn btn-primary pull-right" OnClick="btnjob_Click" OnClientClick="return ValidateData();" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td align="right"></td>
                                                </tr>
                                            </table>

                                        </p>
                                    </div>






                                </div>
                            </div>
                          
    </form>

</body>
</html>
