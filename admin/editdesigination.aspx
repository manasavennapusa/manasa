<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editdesigination.aspx.cs"
    Inherits="Admin_company_createcompany" Title="Create company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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

<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

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

    <script type="text/javascript">
        function Validate() {
            var branch = document.getElementById('<%=drpdepartment.ClientID%>');
             var dept = document.getElementById('<%=drpdepartment.ClientID%>');
             var bu = document.getElementById('<%=txt_branch_name.ClientID%>');

             if (branch.value == "0") {
                 alert("Please select WorkLoaction.");
                 return false;
             }

             if (dept.value == "0") {
                 alert("Please select Department.");
                 return false;
             }
             if (bu.value == "") {
                 alert("Please enter Designation.");
                 return false;
             }
             return true;
         }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Designation </h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit 
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <%--<div class="control-group">
                                                <label class="control-label">Work Location</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="span4" Height="" Width=""
                                                        DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                        OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                      <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpbranch"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Work Location"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource
                                                        ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                                </div>
                                            </div>--%>

                                            <div class="control-group">
                                                <label class="control-label">Department Name <span class="star" style="color:red">*</span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="drpdepartment" runat="server" CssClass="span4" Height=""
                                                        Width="290px" OnDataBound="drpdepartment_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpdepartment"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Department Name"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Designation Name <span class="star" style="color:red">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_branch_name" runat="server" CssClass="blue1" Width="276px" onkeypress="return isChar_Space_dash()"></asp:TextBox>
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Designation Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_branch_code" runat="server" CssClass="blue1" Width="276px" Height="50px" onkeypress="return isChar_Space_dash()"
                                                        TextMode="MultiLine"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Update" CssClass="btn btn-primary"
                                                    ValidationGroup="c"></asp:Button>
                                                 <asp:Button ID="btncancel" OnClick="btncancel_Click" runat="server" Text="Cancel" CssClass="btn btn-primary"
                                                    ValidationGroup=""></asp:Button>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <span id="message" runat="server"></span>
                        </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

</body>
</html>
