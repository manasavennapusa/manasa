<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Suggestion.aspx.cs" Inherits="InformationCenter_Suggestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
    
    
    <html xmlns="http://www.w3.org/1999/xhtml">
      <head id="Head1" runat="server"><meta charset="utf-8"><title>SmartDrive Labs</title>

        <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet">
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
          <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet">

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
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" style="height: 28px">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                                 <div class="clearfix"></div>
                            
                <div class="widget">
                    <div class="widget-header">
                         <div class="title">
                            
                                  <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Suggestion
                             
                    </div>
                    </div> </div>
                
                <tr>
                    <td height="26" valign="middle">&nbsp;&nbsp;<a href="suggestionpost.aspx?view=1" class="link-red1">Suggestion Post
                    </a>&nbsp;l&nbsp; <span class="txt01">Suggestion View</span>
                    </td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;<span id="message" runat="server" enableviewstate="false" class="txt02"></span>
                    </td>
                </tr>
                <tr>
                    <td height="26" valign="bottom">&nbsp;&nbsp;<a href="suggestionview.aspx" class="link-red1">View All Suggestions</a>&nbsp;&nbsp;<asp:TextBox
                        ID="txtsearch" CssClass="blue1" Text="" runat="server" MaxLength="150" Width="241px"></asp:TextBox>
                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="button" OnClick="btnsearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td valign="top">&nbsp;
                    </td>
                </tr>

                <tr>
                    <td valign="top">

                        <div class="widget-content">
                            <asp:GridView ID="suggestiongrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="true" Width="100%"
                                EmptyDataText="No suggestion has been posted." ToolTip="Suggestions posted today"
                                AllowPaging="True" OnPageIndexChanging="suggestiongrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                <Columns>
                                    <asp:BoundField DataField="subject" HeaderText="Subjet" HeaderStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="40%"></asp:BoundField>
                                    <asp:BoundField DataField="department_name" HeaderText="Department Name" HeaderStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="10%"></asp:BoundField>
                                    <asp:BoundField DataField="posteddate" HeaderText="Posted Date" HeaderStyle-Width="10%"></asp:BoundField>

                                </Columns>
                                
                            </asp:GridView>
                        </div>

                        <div class="widget-content">
                            <asp:GridView ID="searchgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="true" Width="100%"
                                EmptyDataText="No such suggestion has been found." ToolTip="Suggestions posted"
                                AllowPaging="True" OnPageIndexChanging="searchgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                <Columns>
                                    <asp:BoundField DataField="subject" HeaderText="Subjet" HeaderStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="40%"></asp:BoundField>
                                    <asp:BoundField DataField="department_name" HeaderText="Department Name" HeaderStyle-Width="20%"></asp:BoundField>
                                    <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="10%"></asp:BoundField>
                                    <asp:BoundField DataField="posteddate" HeaderText="Posted Date" HeaderStyle-Width="10%"></asp:BoundField>

                                </Columns>
                                
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                            
            </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </form>
    </body>

</html>
