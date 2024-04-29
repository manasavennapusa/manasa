<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createpaper.aspx.cs" Inherits="createpaper" %>

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
                        <%--<h2>Create Interview</h2>--%>
                        <h2>Interview Type</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                    <%--<asp:Label ID="lblheader" runat="server" Text="CREATE INTERVIEW"></asp:Label>--%>
                                    <asp:Label ID="lblheader" runat="server" Text="CREATE"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div class="control-group" id="trpapercode" runat="server" visible="false">
                                    <label class="control-label">Paper Code</label>
                                    <div class="controls">
                                        <asp:Label ID="lblpaperid" runat="server"></asp:Label>

                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Function Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_papername" runat="server" CssClass="span4"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Function Area<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_subject" runat="server" CssClass="span4">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_subject"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Function Area" InitialValue="0"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Maximum Marks<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_maximummarks" runat="server" CssClass="span4" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_maximummarks"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Maximum Marks"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_maximummarks"
                                            ValidationGroup="p" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                       
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_maximummarks" Type="Integer"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter max 200 Questions (1-200)" MinimumValue="1" MaximumValue="200"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RangeValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Interview Duration (in Mins)<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_duration" runat="server" CssClass="span4" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_duration"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Duration"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_duration"
                                            ValidationGroup="p" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                       
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_duration" Type="Integer"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter valid Time(1-200 mins)" MinimumValue="1" MaximumValue="200"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RangeValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Cut off Marks<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_passmarks" runat="server" CssClass="span4" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_passmarks"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Cut off Marks"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_passmarks"
                                            ValidationGroup="p" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        
                                        <asp:RangeValidator ID="RangeValidator6" runat="server" ControlToValidate="txt_passmarks" Type="Integer"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter valid Marks" MinimumValue="1" MaximumValue="500"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RangeValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Interview Type<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddl_type" runat="server" CssClass="span4">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="1">Face to Face</asp:ListItem>
                                            <asp:ListItem Value="2">Telephonic</asp:ListItem>
                                            <%--<asp:ListItem Value="3">Hard</asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_type"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Interview Type" InitialValue="0"
                                            ValidationGroup="p" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions no-margin">
                                <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-info" OnClick="btnadd_Click" ValidationGroup="p" style="margin-left:80px" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btnclear_Click" />&nbsp;
                            </div>

                        </div>
                    </div>
                </div>

                <div class="row-fluid" id="viewgrid" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>LIST OF PAPERS--%>
                                     <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdpaper" runat="server" DataKeyNames="id" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdpaper_PreRender"
                                        EmptyDataText="No data Found" OnRowDeleting="grdpaper_RowDeleting" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Interview Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpapercode" runat="server" Text='<%# Eval("papercode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Function Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpapername" runat="server" Text='<%# Eval("papername") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Function Area">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubcode" runat="server" Text='<%# Eval("subjectid") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Max. Marks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQUES" runat="server" Text='<%# Eval("maximummarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Interview Duration">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTIME" runat="server" Text='<%# Eval("duration") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Cut off Marks">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMARKS" runat="server" Text='<%# Eval("passmarks") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Interview Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTYPE" runat="server" Text='<%# Eval("papertype").ToString()=="1"?"Simple":Eval("papertype").ToString()=="2"?"Medium":"Hard" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createpaper.aspx?Id={0}"
                                                Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="10%">
                                                <ControlStyle CssClass="link05"/>
                                            </asp:HyperLinkField>
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
            $('#grdpaper').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>

</body>
</html>
