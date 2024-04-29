<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createjobsite_consultancy.aspx.cs" Inherits="createjobsite_consultancy" %>

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
    <form id="myForm" runat="server" class="form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <%--<h2>ADD CONSULTANCY</h2>--%>
                                <h2>Consultancy</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <%--<asp:Label ID="lblheader" runat="server" Text="ADD CONSULTANCY"></asp:Label>--%>
                                            <asp:Label ID="lblheader" runat="server" Text="ADD CONSULTANCY"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Name/Organisation<span class="star"></span>
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_orgname" runat="server" CssClass="span10"  ></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_orgname"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Name/Organisation"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_contactperson"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9,&\s]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Contact Person<span class="star"></span>
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_contactperson" runat="server" CssClass="span10"  onkeypress="return isCharOrSpace_dot()" onblur="return capitalizeMe(this)"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_contactperson"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Contact Person"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txt_contactperson"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s\.]+$" ToolTip="Enter only alphabets"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Email<span class="star"></span>                                                   
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_email" runat="server" CssClass="span10"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_email"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator13" runat="server" ValidationGroup="c" ToolTip="Not a Vaild Email ID"
                                                        SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_email"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Address<span class="star"></span>                                                    
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_address" runat="server" CssClass="span10" TextMode="MultiLine" ></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_address"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Address"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Type<span class="star"></span>
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_type" runat="server" CssClass="span10">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        <asp:ListItem>Job Site</asp:ListItem>
                                                        <asp:ListItem>Consultancy</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_type"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Type" InitialValue="0"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Contact Number<span class="star"></span>
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_contactno" runat="server" CssClass="span10" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_contactno"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Contact Number"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_contactno"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only numbers (Minimum 10 digits)"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    URL
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_url" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>
                                                    <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ValidationGroup="c"
                                                        ToolTip="Not a Vaild URL (http(s)://www.xyz.com)" SetFocusOnError="True" Display="Dynamic" ControlToValidate="txt_url"
                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationExpression="(http(s)?://)?([\w-]+\.)+[\w-]+[.com]+[.in]+(/[/?%&=]*)?"></asp:RegularExpressionValidator>
                                                    --%>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Active<span class="star"></span>
                                                </label>
                                                <div class="controls">
                                                    <asp:RadioButtonList ID="rbtnlactive" runat="server" CssClass="radio inline" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="true">Yes &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                    </asp:RadioButtonList>

                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rbtnlactive"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Active"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>

                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-primary" OnClick="btnadd_Click" ValidationGroup="c" style="margin-left:650px" />&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnclear" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnclear_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row-fluid"  id="viewgrid" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Consultancies and Jobsites--%>     
                                           <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdjobsites" runat="server" DataKeyNames="id" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                EmptyDataText="No Data Found" OnPreRender="grdjobsites_PreRender" OnRowDeleting="grdjobsites_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl2" runat="server" Text='<%# Eval("organizationname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl3" runat="server" Text='<%# Eval("orgtype") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Address">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbla" runat="server" Text='<%# Eval("address") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact Person">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl4" runat="server" Text='<%# Eval("contactperson") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Contact No.">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl5" runat="server" Text='<%# Eval("contactno") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Email">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl6" runat="server" Text='<%# Eval("email") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="URL">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl7" runat="server" Text='<%# Eval("url") %>'>></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createjobsite_consultancy.aspx?Id={0}"
                                                         Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="10%">
                                                        <ControlStyle CssClass="link05" />
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
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdjobsites').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
