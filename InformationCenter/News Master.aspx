<%@ Page Language="C#" AutoEventWireup="true" CodeFile="News Master.aspx.cs" Inherits="InformationCenter_News_Master" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<%--<html class="lt-ie9 lt-ie8 lt-ie7" lang="en">--%>
    
    
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

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
                                <h2>Buzz</h2>
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

                                        <div class="control-group">
                                            <label class="control-label">Type<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="span4" ToolTip="Select Type">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Employee"></asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ToolTip="Select Type" ControlToValidate="ddlcategory" ErrorMessage="Select Type" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="control-group">
                                            <label class="control-label">Status<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlrunstatusg" runat="server" CssClass="span4" ToolTip="Select Status">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1">Running</asp:ListItem>
                                                    <asp:ListItem Value="2">Stop</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ToolTip="Select Status" ControlToValidate="ddlrunstatusg" ErrorMessage="Select Status" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Status" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="control-group">
                                            <label class="control-label">Priorty<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlpriorityg" runat="server" CssClass="span4" ToolTip="Select Priorty">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1">Low</asp:ListItem>
                                                    <asp:ListItem Value="2">Medium</asp:ListItem>
                                                    <asp:ListItem Value="3">High</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ToolTip="Select Priorty" ControlToValidate="ddlpriorityg" ErrorMessage="Select Priorty" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Priorty" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Heading<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtheading" size="40" CssClass="span4" runat="server" ToolTip="Enter Heading" onkeypress="return isKey(event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtheading" ErrorMessage=" Enter Heading" runat="server" ToolTip="Enter Heading" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>


                                        <div class="control-group">
                                            <label class="control-label">Description</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtdescription" CssClass="span4" runat="server" ToolTip="Enter Description" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ControlToValidate="txtdescription" ToolTip="Enter Description" ErrorMessage="Enter Description " runat="server"  ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>--%>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="updpnl" runat="server">
                                            <ContentTemplate>
                                                <div class="control-group">
                                                    <label class="control-label">Attach Document</label>
                                                    <div class="controls">
                                                        <asp:FileUpload ID="fupload" runat="server" ToolTip="Attach Document here" Width="287px" />
                                                        <%--<asp:RequiredFieldValidator ID="rfvupload" runat="server" ControlToValidate="fileupload" Display="Dynamic" ErrorMessage="Attach Document" ToolTip="Attach Document" ValidationGroup="v"><img src="../images/error1.gif" alt=""></asp:RequiredFieldValidator>--%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                            CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />' ToolTip="file is Invalid" SetFocusOnError="true"
                                                            ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT|.png|.PNG|.jpg|.JPG)$"
                                                            ValidationGroup="v"><img src="../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator><p style="color: red">(Supported Files are PDF,Docx,Doc,JPG,PNG)</p>
                                                        <a id="dftlink1" runat="server" class="link05">
                                                            <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                                            <%--<asp:LinkButton ID="lbl_file" runat="server" Text="View" OnClick="View" CommandArgument='<%# Eval("Id") %>'></asp:LinkButton>--%>
                                                        </a>
                                                    </div>
                                                </div>

                                                 <div class="form-actions no-margin">
                                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSave_Click" ValidationGroup="v" />
                                                <asp:Button ID="btnclear" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnclear_Click" />
                                            </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnSave" />
                                            </Triggers>
                                        </asp:UpdatePanel>                                                      
                                           
                                                
                                           
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
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="newsdetails" runat="server" Width="100%" AutoGenerateColumns="False" AllowSorting="true" SkinID="Fun"
                                            DataKeyNames="id" BorderWidth="0px" CellPadding="4" OnRowDataBound="newsdetails_RowDataBound" style="border-top:1px solid #e0e0e0"
                                            OnPageIndexChanging="newsdetails_PageIndexChanging" OnRowDeleting="newsdetails_RowDeleting"
                                            OnRowCancelingEdit="newsdetails_RowCancelingEdit" OnRowEditing="newsdetails_RowEditing"
                                            OnRowUpdating="newsdetails_RowUpdating" ToolTip="News Details" OnPreRender="newsdetails_PreRender"
                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Category">
                                                    <ItemTemplate>
                                                        <%--   <%#DataBinder.Eval(Container.DataItem, "category")%>--%>
                                                        <asp:Label ID="l1" runat="server" Text='<%# Eval("category").ToString()=="1"?"General":"Employee" %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%--   <EditItemTemplate>
                                                         <asp:DropDownList ID="ddlcategoryg" runat="server" Width="120" CssClass="span4" Text='<%# Eval("category") %>'>
                                                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                                                        <asp:ListItem Value="General">General</asp:ListItem>
                                                                                                                        <asp:ListItem Value="Employee">Employee</asp:ListItem>
                                                                                                                    </asp:DropDownList>

                                                       <%-- <asp:DropDownList ID="ddlcategoryg" runat="server" CssClass="blue1" Width="75px"
                                                            Height="20px" DataSourceID="SqlDataSource1" DataTextField="categoryname" DataValueField="categoryname"
                                                            SelectedValue='<%#Bind("category")%>'>
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct [categoryname] FROM [category]"></asp:SqlDataSource>--%
                                                    </EditItemTemplate>--%>
                                                    <%-- <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Heading">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "heading")%>
                                                    </ItemTemplate>
                                                    <%-- <EditItemTemplate>
                                                        <asp:TextBox ID="txtheadingg" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "heading")%>'
                                                            runat="server" Width="75px"></asp:TextBox>
                                                    </EditItemTemplate>--%>
                                                    <%-- <ItemStyle Width="13%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Description">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                    </ItemTemplate>
                                                    <%--      <EditItemTemplate>
                                                        <asp:TextBox ID="txtdescriptiong" CssClass="blue1" Text='<%#DataBinder.Eval(Container.DataItem, "description")%>'
                                                            runat="server" Width="190px" Height="41px" TextMode="MultiLine"></asp:TextBox>
                                                    </EditItemTemplate>--%>
                                                    <%-- <ItemStyle Width="29%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status">
                                                    <%--<ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
                                                    <ItemTemplate>
                                                        <%--  <%#DataBinder.Eval(Container.DataItem, "run_status")%>--%>
                                                        <asp:Label ID="l2" runat="server" Text='<%# Eval("run_status").ToString()=="1"?"Running":"Stop" %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%--    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlrunstatusg" runat="server" Width="75px" SelectedValue='<%#Bind("run_status1")%>'
                                                            CssClass="blue1" Height="20px">
                                                            <asp:ListItem Value="0">Running</asp:ListItem>
                                                            <asp:ListItem Value="1">Stop</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>--%>
                                                    <%--<HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Priority">
                                                    <%--<ItemStyle Width="9%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
                                                    <ItemTemplate>
                                                        <%-- <%#DataBinder.Eval(Container.DataItem, "priority")%>--%>
                                                        <asp:Label ID="l3" runat="server" Text='<%# Eval("priority").ToString()=="1"?"Low":Eval("priority").ToString()=="2"?"Medium":"High" %>'></asp:Label>
                                                    </ItemTemplate>
                                                    <%--  <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlpriorityg" runat="server" SelectedValue='<%#Bind("priority1")%>'
                                                            Width="55px" CssClass="blue1" Height="20px">
                                                            <asp:ListItem Value="0">Low</asp:ListItem>
                                                            <asp:ListItem Value="1">Medium</asp:ListItem>
                                                            <asp:ListItem Value="2">High</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </EditItemTemplate>--%>
                                                    <%--<HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                                <%--   <asp:TemplateField HeaderText="Updated Date">
                                                    <ItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                    </ItemTemplate>
                                                  <%--  <EditItemTemplate>
                                                        <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                                    </EditItemTemplate>--%>
                                                <%-- <ItemStyle Width="14%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="10%">
                                                    <%--<EditItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')"
                                                            CommandName="Update" CssClass="btn btn-primary btn-small hidden-phone" Text="Update" ToolTip="Update" />
                                                        |
                                            <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                CssClass="btn btn-primary btn-small hidden-phone" Text="Cancel" ToolTip="Cancel" />
                                                    </EditItemTemplate>--%>
                                                    <%--<ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
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
                                                    <%--<HeaderStyle CssClass="frm-lft-clr123" />--%>
                                                </asp:TemplateField>
                                            </Columns>
                                            <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                        </asp:GridView>
                                        <div class="clearfix"></div>
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
            $('#newsdetails').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
