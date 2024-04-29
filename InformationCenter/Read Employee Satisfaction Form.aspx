<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Read Employee Satisfaction Form.aspx.cs" Inherits="InformationCenter_Read_Employee_Satisfaction_Form" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Read Employee Satisfaction Form	
                 
                                    </div>
                                </div>

                                <div class="widget-body">
                                    <fieldset>

                                        <div class="control-group">
                                            <label class="control-label">Year<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="drp_year" runat="server" AutoPostBack="True" CssClass="blue1" Width="109px">
                                                </asp:DropDownList>
                                                <%--<asp:DropDownList ID="ddl_type" runat="server" CssClass="span4">
                                                        <asp:ListItem Value="0" Text="-Select Type-"></asp:ListItem>
                                                        <asp:ListItem Value="1" Text="Employee"></asp:ListItem>
                                                        <asp:ListItem Value="2" Text="General"></asp:ListItem>
                                                    </asp:DropDownList>--%>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Term<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="drphalfyear" runat="server" CssClass="blue1" Width="109px">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="First Half">First Half </asp:ListItem>
                                                    <asp:ListItem Value="Selecond Half ">Second Half </asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <%--<div class="control-group">
                                            <label class="control-label">Description<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_desc" CssClass="span4" runat="server" ToolTip="Employee Code" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                            </div>
                                        </div>--%>
                                        <div class="control-group">
                                            <%--<div class="controls">
                                                <asp:FileUpload ID="fupload" runat="server" CssClass="blue1" ToolTip="Attach Document here"
                                                    Width="287px" />
                                                <asp:RequiredFieldValidator ID="rfvupload" runat="server" ControlToValidate="fupload"
                                                    Display="Dynamic" ErrorMessage="Attach Document" ToolTip="Attach Document" ValidationGroup="v"><img src="../images/error1.gif" alt=""></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                    CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                                    ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$"
                                                    ValidationGroup="v"><img src="../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator>
                                                <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                            </div>--%>
                                            <div class="control-group">
                                                <label class="control-label"></label>
                                                <div class="controls">
                                                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="v" />&nbsp;
                                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" />

                                                </div>

                                            </div>
                                            <%-- this grid view is added, backend coding is not yet dont, the view will be visible when there is data in database. 
                                        </div>


                                        <%--   <div class="form-actions no-margin">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="c" />
                                                <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" ValidationGroup="c" />
                                            </div>--%>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                        <div class="row-fluid">

                            <div class="widget">

                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Satidfaction Forms                
                                    </div>
                                </div>

                                <div class="widget-body">
                                    <div class="widget-content">
                                        <asp:GridView ID="griddetails" runat="server" Width="100%" AutoGenerateColumns="False"
                                            DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="griddetails_RowDataBound"
                                            OnPageIndexChanging="griddetails_PageIndexChanging" OnRowDeleting="griddetails_RowDeleting"
                                            OnRowEditing="griddetails_RowEditing" ToolTip="Catalog Details" AllowPaging="True"
                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Type">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "type")%>
                                                    </ItemTemplate>
                                                    <%-- <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Subject">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "subject")%>
                                                    </ItemTemplate>
                                                    <%-- <ItemStyle Width="22%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <%--<ItemStyle Width="35%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Attached Document">
                                                    <%--<ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "upload")%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <%-- <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                            <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit"
                                                            CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                        |
                                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')"
                                                                CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                            <FooterStyle CssClass="frm-lft-clr123" />
                                            <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                            <PagerStyle CssClass="frm-lft-clr123" />
                                        </asp:GridView>
                                    </div>
                                    <%--<fieldset>
                                            <asp:GridView ID="grid_vision" runat="server" DataKeyNames="ID" Width="100%" AutoGenerateColumns="False"
                                                CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                EmptyDataText="No such employee exists !" OnPreRender="grid_vision_PreRender"
                                                OnRowEditing="grid_vision_RowEditing" OnRowDeleting="grid_vision_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("type") %>'></asp:Label>
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
                                                           <asp:LinkButton ID="lbtnEdit" runat="server" CssClass="link05" CommandName="Edit"> <i class="icon-pencil"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="link05" CommandName="Delete"><i class="icon-remove"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>

                                            </asp:GridView>
                                        </fieldset>--%>
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
