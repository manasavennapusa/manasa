<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createpanel.aspx.cs" Inherits="createpanel" %>

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
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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

    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
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
                        <h2>Interview Panel</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <%--<asp:Label ID="lblheader" runat="server" Text=" ADD PANEL"></asp:Label>--%>
                                    <asp:Label ID="lblheader" runat="server" Text="Create"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div class="control-group" id="trpanelcode" runat="server" visible="false">
                                    <label class="control-label">Panel Code</label>
                                    <div class="controls">
                                        <asp:Label ID="lbl_panelcode" CssClass="control-label" runat="server"></asp:Label>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Panel Name<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_panelname" runat="server" CssClass="span4" MaxLength="200" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_panelname"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Panel Name"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_panelname"
                                            ValidationGroup="p" runat="server" ValidationExpression="^[a-zA-Z0-9&\s]+$" ToolTip="Enter only Alphabets, Numbers and (space)"
                                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <%-- <div class="control-group">
                                    <label class="control-label">Subject</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_subject" runat="server" CssClass="span10" MaxLength="200" onkeypress="return isChar_Number_space()"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_subject"
                                            ValidationGroup="p" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphabets, Numbers and (space)"
                                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                    </div>
                                </div>--%>
                                <div class="control-group">
                                    <label class="control-label">Function Area</label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_subject" runat="server" CssClass="span4">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Employee Code - Name</label>
                                    <div class="controls">
                                        <asp:HiddenField ID="hidd_empcode" runat="server" />
                                        <asp:TextBox ID="txt_resourcename" runat="server" CssClass="span4" TextMode="MultiLine"></asp:TextBox>
                                        <a href="JavaScript:newPopup1('pickemployee.aspx');" class="btn btn-small btn-primary hidden-tablet hidden-phone" style="margin-left: 5px; margin-top:10px">Select </a>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_resourcename"
                                            Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Resources for Panel"
                                            ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                            </div>
                            <div class="form-actions no-margin">
                                <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnadd_Click" ValidationGroup="p" style="margin-left:80px" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-primary" OnClick="btnclear_Click" />
                            </div>

                        </div>
                    </div>
                </div>

                <div class="row-fluid" id="viewgrid" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview Panels--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View    
                                     
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdPanel" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        EmptyDataText="No Data Found" OnPreRender="grdPanel_PreRender" OnRowDeleting="grdPanel_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Panel Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpanelId" runat="server" Text='<%# Eval("panelcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Panel Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpanelname" runat="server" Text='<%# Eval("Panelname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Names">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubjectname" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Resource Code - Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblresourcename" runat="server" Text='<%# Eval("resourcenames") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createpanel.aspx?Id={0}"
                                                Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="10%"></asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                       Text="&lt;img src='../images/download_delete.png'/&gt;"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>

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
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdPanel').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
