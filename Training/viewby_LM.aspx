<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewby_LM.aspx.cs" Inherits="Training_viewby_LM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html lang="en">
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
                                <h2>Training Schedule</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>                        

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                           
                                        </div>
                                    </div>
                                    <%--<div class="widget-body">
                                        <div id="Div1" class="example_alt_pagination">--%>
                                            <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="gridtraining" runat="server" AutoGenerateColumns="false" CellSpacing="0"   EmptyDataText="No such employee exists !" DataKeyNames="id"
                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="gridtraining_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.NO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                 <%--<asp:TemplateField HeaderText="Training id">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("id") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

<%--                                                   <asp:TemplateField HeaderText="Empcode">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>

                                                <asp:TemplateField HeaderText="Scheduled by">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("createdby") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="From Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblfromdate" runat="server" Text='<%# Eval ("FromDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="To Date">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbltodate" runat="server" Text='<%# Eval ("ToDate") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Module Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmodulename" runat="server" Text='<%# Eval ("module_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Faculty">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblemfac" runat="server" Text='<%# Eval ("Faculty") %>'></asp:Label></a>
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
                                                <asp:HyperLinkField HeaderText="View" DataNavigateUrlFields="dept_name,FromDate,ToDate,module_name,training_code,training_name,id,Faculty" DataNavigateUrlFormatString="addparticipants.aspx?dept_name={0}&FromDate={1}&ToDate={2}&module_name={3}&training_code={4}&training_name={5}&id={6}&Faculty={7}"
                                                    Text="&lt;img src='../images/view.png' /&gt;">
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
