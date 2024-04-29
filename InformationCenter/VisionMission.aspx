<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VisionMission.aspx.cs" Inherits="InformationCenter_VisionMission" %>

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
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta charset="utf-8">
        <title>SmartDrive Labs</title>

        <script src="../js/html5-trunk.js"></script>
          <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>
        <link href="../icomoon/style.css" rel="stylesheet">
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet">

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet">

        <!-- fullcalendar css -->
        <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
        <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    </head>
    <body>
        <form id="myForm" runat="server" class="form-horizontal no-margin">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="main-container">
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2></h2>
                                </div>
                             <span class="fs1"  runat="server" aria-hidden="true"><h2>Vision And Mission</h2></span>  
                            <%-- <span class="fs1"  runat="server" aria-hidden="true"><h2>Vision And Mission</h2></span> --%>
                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" id="create1" runat="server" aria-hidden="true" data-icon="&#xe14a;"></span>
                                              <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>
                                           <%--  <span class="fs1" id="edit1" runat="server" aria-hidden="true" data-icon="&#xe14a;"></span> Edit--%>
                                            <%--Vision/Mission Posting Form   --%>              
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group">
                                                <label class="control-label">Type<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_type" runat="server" CssClass="span4">
                                                        <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Vision"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="Mission"></asp:ListItem>
                                                    </asp:DropDownList>
                                                     <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddl_type"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Type"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Heading<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_heading" size="40" CssClass="span4" runat="server" ToolTip="Employee Code" onkeypress="return isKey(event);"></asp:TextBox>
                                                      <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_heading"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Heading" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                                
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_desc" CssClass="span4" runat="server" ToolTip="Employee Code" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="c" />
                                                <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" ValidationGroup="c" />
                                            </div>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            <div class="row-fluid">

                                <div class="widget" id="grid" runat="server">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                           <%-- Vission & Mission      --%>          
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <asp:GridView ID="grid_vision" runat="server" DataKeyNames="ID" Width="100%" AutoGenerateColumns="False"
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                EmptyDataText="No such employee exists !" OnPreRender="grid_vision_PreRender"
                                                OnRowEditing="grid_vision_RowEditing" OnRowDeleting="grid_vision_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                        <%--    <asp:Label ID="l0" runat="server" Text='<%# Bind ("type") %>'></asp:Label>--%>
                                                               <asp:Label ID="l0" runat="server" Text='<%# Eval("type").ToString()=="1"?"Vision ":"Mission" %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Heading">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("Heading") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("descs") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                           <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="link05" CommandName="Edit" Text="&lt;img src='images/edit.png'/&gt;"> </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="link05" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" Text="&lt;img src='images/delete.png'/&gt;"></asp:LinkButton><%--<i class="icon-remove"></i>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </form>
    </body>
    </html>
