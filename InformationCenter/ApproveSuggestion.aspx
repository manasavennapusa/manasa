<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproveSuggestion.aspx.cs" Inherits="InformationCenter_ApproveSuggestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server"><meta charset="utf-8"/>
    <title>SmartDrive Labs</title>

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

    <%-- this will make the asterisk red in color --%>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Suggestions 
                 
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>

                                            <%--<div class="control-group">
                                                <label class="control-label">Type<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_type" runat="server" CssClass="span4">
                                                        <asp:ListItem Value="0" Text="-Select Type-"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Employee"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="General"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>--%>

                                            <div class="control-group">
                                               
                                               


                                            </div>
                                            
                                             
                                            <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnPageIndexChanging="suggestions_PageIndexChanging"
                                        OnRowDeleting="suggestions_RowDeleting" OnRowCancelingEdit="suggestions_RowCancelingEdit"
                                        OnRowEditing="suggestions_RowEditing" OnRowUpdating="suggestions_RowUpdating"
                                        ToolTip="Suggestions for Approval" AllowPaging="True" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Posted By">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "postedby")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "department_name")%>
                                                </ItemTemplate>
                                                <%--<ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "subject")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" Visible="false">
                                                <%--<ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "status")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>'
                                                        CssClass="blue1" Height="20px">
                                                        <asp:ListItem Value="0">Not Approved</asp:ListItem>
                                                        <asp:ListItem Value="1">Approved</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                                <%--<HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Posted Date">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false">
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                        CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                    |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                </EditItemTemplate>
                                                <%--<ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                        CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                    |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                </ItemTemplate>
                                                <%--<HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                        </Columns>
                                        <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                        <PagerStyle CssClass="frm-lft-clr123" />
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
