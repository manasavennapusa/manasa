<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createdocument.aspx.cs" Inherits="createdocument" %>

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
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Create Document</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <asp:Label ID="lblheader" runat="server" Text="CREATE DOCUMENT"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div class="control-group">
                                    <label class="control-label">Document Name</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_docname" runat="server" CssClass="span10" MaxLength="200" onkeypress="return isChar_Number_space()"> </asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_docname"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Document Name"
                                            ValidationGroup="doc" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_docname"
                                            ValidationGroup="r" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphabets,Numbers and (space)"
                                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_dec" runat="server" CssClass="span10" MaxLength="200" onkeypress="return isChar_Number_space()"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_dec"
                                            ValidationGroup="r" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphabets,Numbers and (space)"
                                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Mandatory</label>
                                    <div class="controls">
                                        <asp:CheckBox ID="chk_mandatory" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="form-actions no-margin" style="text-align: right">
                                <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-primary" ValidationGroup="doc" OnClick="btnadd_Click" />
                                <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="btn" OnClick="btnclear_Click" />
                            </div>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>DOCUMENT LIST
                                     
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grddocument" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        EmptyDataText="No Data Found" OnPreRender="grddocument_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="NAME">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubcode" runat="server" Text='<%# Eval("document_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DESCRIPTION">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblQUES" runat="server" Text='<%# Eval("description") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="MANDATORY">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblTIME" runat="server" Text='<%# Eval("mandatory").ToString()=="True"?"Yes":"No" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createdocument.aspx?Id={0}"
                                                Text="Edit"></asp:HyperLinkField>
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
            $('#grddocument').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
