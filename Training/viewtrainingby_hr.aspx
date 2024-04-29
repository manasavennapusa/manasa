<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtrainingby_hr.aspx.cs" Inherits="Training_viewtrainingby_hr" %>

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

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Training Schedule by MD</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>                        

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Training Schedule
                                           
                                        </div>
                                    </div>
                                   <%-- <div class="widget-body">--%>
                                        <%--<div id="Div1" class="example_alt_pagination">--%>
                                            <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="gridtraining" runat="server" AutoGenerateColumns="false" CellSpacing="0"   EmptyDataText="No such employee exists !"
                                            CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="gridtraining_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.NO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Training Scheduld by">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("createdby") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Training Id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("id") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField  HeaderText="Training Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltrainingcode" runat="server" Text='<%#Eval ("training_code") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField  HeaderText="Training Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltrainingname" runat="server" Text='<%#Eval ("training_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField  HeaderText="Department Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldepartment" runat="server" Text='<%#Eval("department_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                                                                                                         
                                                <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="id" DataNavigateUrlFormatString="trainingapproveby_HR.aspx?id={0}"
                                                    Text="View">
                                                    <ControlStyle CssClass="btn btn-primary" Width="27%" />
                                                </asp:HyperLinkField>                                               
                                            </Columns>
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--  <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gridtraining').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
