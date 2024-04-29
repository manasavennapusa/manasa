<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createsubject.aspx.cs" Inherits="createsubject" %>


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
                        <%--<h2>Create Function Area</h2>--%>
                        <h2>Function</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <%--<asp:Label ID="lblheader" runat="server" Text="Create Function Area"></asp:Label>--%>
                                    <asp:Label ID="lblheader" runat="server" Text="Create"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <div class="control-group">

                                    <label class="control-label">Function Area<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_subname" runat="server" CssClass="span4" MaxLength="200" ></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_subname"
                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Function Area"
                                            ValidationGroup="r" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_subname"
                                            ValidationGroup="r" runat="server" ValidationExpression="^[a-zA-Z0-9\.\&\/\-\#\s\:\,\(\)\']+$" ToolTip="Enter only Alphabets,Numbers and special characters(. , /- # : ( ) ' space)"
                                            ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        

                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_sub_subject" runat="server" CssClass="span4" MaxLength="200" TextMode="MultiLine"></asp:TextBox>

                                    </div>
                                </div>

                            </div>
                            <div class="form-actions no-margin">
                                <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-primary" ValidationGroup="r" OnClick="btnadd_Click" style="margin-left:80px" />&nbsp;&nbsp;&nbsp;
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
                                   <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Function Area List--%>  
                                     <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View                                
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdsubject" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        EmptyDataText="No Data Found" OnPreRender="grdsubject_PreRender" OnRowDeleting="grdsubject_RowDeleting">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Subject Code" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubcode" runat="server" Text='<%# Eval("subject_code") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Function Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubname" runat="server" Text='<%# Eval("subject_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbls_subname" runat="server" Text='<%# Eval("sub_subject_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createsubject.aspx?Id={0}"
                                               Text="&lt;img src='../images/edit.png'/&gt;">
                                                <ControlStyle CssClass="link05" Width="10%" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
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
            $('#grdsubject').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
