<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Press Release.aspx.cs" Inherits="InformationCenter_Press_Release" %>

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
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Press Release</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span> 
                                            <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>        
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>

                                            <%--<div class="control-group">
                                                <label class="control-label">Type<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_type" runat="server" CssClass="span4">
                                                        <asp:ListItem Value="0" Text="-Select-"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Employee"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="General"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>--%>

                                            <div class="control-group">
                                                <label class="control-label">Heading<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtsubject" size="40" CssClass="span4" runat="server" ToolTip="Enter Heading" onkeypress="return isKey(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtsubject" runat="server" ErrorMessage="Enter Heading" ValidationGroup="a" ForeColor="Red" ToolTip="Enter Heading"><img src="../images/error1.gif" alt="Enter Heading" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdescription" CssClass="span4" runat="server" ToolTip="Enter Description" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ToolTip="Enter Description" ControlToValidate="txtdescription" runat="server" ErrorMessage="Enter Description" ValidationGroup="a" ForeColor="Red"><img src="../images/error1.gif" alt="Enter Description" /></asp:RequiredFieldValidator>--%>
                                                </div>
                                            </div>


                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="a" />
                                                <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click"/>
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
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <div class="widget-content">
                                        <asp:GridView ID="griddetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                            DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="griddetails_RowDataBound"
                                            OnPageIndexChanging="griddetails_PageIndexChanging" OnRowDeleting="griddetails_RowDeleting"
                                            OnRowCancelingEdit="griddetails_RowCancelingEdit" OnRowEditing="griddetails_RowEditing"
                                            OnRowUpdating="griddetails_RowUpdating" ToolTip="Catalog Details" AllowPaging="True"
                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Heading">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                    </ItemTemplate>
                                                 <%--   <EditItemTemplate>
                                                        <asp:TextBox ID="txtgsubject" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                            runat="server" Width="100px"></asp:TextBox>
                                                    </EditItemTemplate>--%>
                                                    <%-- <ItemStyle Width="25%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <%--<ItemStyle Width="62%" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                    </ItemTemplate>
                                                  <%--  <EditItemTemplate>
                                                        <asp:TextBox ID="txtgdescription" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                            TextMode="MultiLine" runat="server" Width="220px" Height="47px"></asp:TextBox>
                                                    </EditItemTemplate>--%>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnupdate" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                            CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                        |
                                                <asp:LinkButton ID="lnkbtncancel" runat="server" CausesValidation="false" CommandName="Cancel"
                                                    CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                    </EditItemTemplate>--%>
                                                    <%--  <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            CssClass="link05" Text="&lt;img src='images/edit.png'/&gt;" ToolTip="Edit" />
                                                </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                    CommandName="Delete" CssClass="link05" Text="&lt;img src='images/delete.png'/&gt;" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                            <PagerStyle CssClass="frm-lft-clr123" />
                                        </asp:GridView>
                                    </div>
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
