<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinancialsView.aspx.cs" Inherits="InformationCenter_FinancialsView" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
    <html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <meta charset="utf-8"/>
        <title>MacTay</title>
        <style type="text/css">
            .star:before
            {
                color: red !important;
                content: " *";
            }
        </style>

        <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet"/>
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet"/>

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet"/>

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
                                <div class="clearfix"></div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Financials Details                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <asp:TextBox ID="txtsearch"  CssClass="blue1" Text="" runat="server"
                                                     MaxLength="150" Width="241px"></asp:TextBox>
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnsearch_Click" ValidationGroup="c" />
                                            </div>
                                           
                                           
                                                
                                                     </fieldset>
                                                
                                     </div>
                                </div>
                            </div>
                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Financials            
                                        </div>
                                    </div>
                                    <div class="widget-content">
                                        <asp:GridView ID="griddetails" runat="server" AutoGenerateColumns="False" CellPadding="2"
                            CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="true" Width="100%"
                            EmptyDataText="No product information has been posted" ToolTip="Product Information Posted"
                            AllowPaging="True" OnPageIndexChanging="griddetails_PageIndexChanging"
                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                            <Columns>

                                <asp:BoundField DataField="heading" HeaderText="heading" HeaderStyle-Width="20%"></asp:BoundField>
                                <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="40%"></asp:BoundField>

                                <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="10%"></asp:BoundField>
                                <asp:BoundField DataField="posteddate" HeaderText="Posted Date" HeaderStyle-Width="10%"></asp:BoundField>


                                
                            </Columns>

                        </asp:GridView>
                                    </div>
                                </div>
                            </div>                        
                            
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnsubmit" />
                    </Triggers>
                   
                </asp:UpdatePanel>
               
            </div>
        </form>
    </body>
    </html>
