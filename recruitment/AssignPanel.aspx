<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AssignPanel.aspx.cs" Inherits="recruitment_AssignPanel" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

     <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Assign Interview Panel</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid" visible="false" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Assign Panel
                                </div>
                                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>

                            <table class="table table-condensed table-bordered no-margin">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlcode" runat="server" CssClass="span6" OnSelectedIndexChanged="ddlcode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_search" runat="server" CssClass="span6" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btnSearch_Click" />
                                        </td>
                                        <%-- <td>
                                            <asp:Button ID="btnclear" runat="server" Text="Search Clear" CssClass="btn btn-primary" OnClick="btnclear_Click" />
                                        </td>--%>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                   <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview Panel Lists--%> 
                                     <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Panel List                                  
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdpanel" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" AllowSorting="True"
                                        EmptyDataText="No Data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Panel Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpcode" runat="server" Text='<%# Eval("panelcode") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Panel Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Panelname") %>'>></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubname" runat="server" Text='<%# Eval("subjectname") %>'>></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Resource Code  -  Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblresname" runat="server" Text='<%# Eval("resourcenames") %>'></asp:Label>&nbsp;&nbsp; - &nbsp;&nbsp;
                                                     <asp:Label ID="lblemp" runat="server" Text='<%# Eval("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createjobsite_consultancy.aspx?Id={0}"
                                                Text="Edit" Visible="false"></asp:HyperLinkField>
                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>
                                    <tr>
                                        <td>Select RRF</td>

                                        <td>
                                            <asp:DropDownList ID="ddlRRF" runat="server" Width="250px"></asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlRRF" InitialValue="0"
                                                Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select RRF"
                                                ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div class="form-actions no-margin" style="text-align:right">
                                <asp:Button ID="btnadd" runat="server" Text="Assign" CssClass="btn btn-info" OnClick="btnSelect_Click" ValidationGroup="rrf" />&nbsp;
                                 <%--  <asp:Button ID="btnselectall" runat="server" Text="Select All" CssClass="btn btn-primary" OnClick="btnselectall_Click" />&nbsp;
                                <asp:Button ID="btndeselectall" runat="server" Text="Deselect All" CssClass="btn btn-primary" OnClick="btnDeselectall_Click" />&nbsp;
                                <asp:Button ID="btndelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btnDelete_Click" OnClientClick="return confirm('Are you sure you want to delete selected records ')" Visible="false" />&nbsp;--%>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Assigned Panel                                
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="Div1" class="example_alt_pagination">
                                    <asp:GridView ID="grdassigned" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" AllowSorting="True"
                                        EmptyDataText="No Data Found" CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="RRF Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designationname") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Panle Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblpcode" runat="server" Text='<%# Eval("panelcode") %>'>></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Panel Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%# Eval("Panelname") %>'>></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Subject Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsubname" runat="server" Text='<%# Eval("subjectname") %>'>></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Resource Code    -     Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblresname" runat="server" Text='<%# Eval("resourcenames") %>'></asp:Label> &nbsp;&nbsp;-&nbsp;&nbsp;
                                                     <asp:Label ID="lblempf" runat="server" Text='<%# Eval("emp_fname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createjobsite_consultancy.aspx?Id={0}"
                                                Text="Edit" Visible="false"></asp:HyperLinkField>

                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/analytics.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdpanel').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
  
</body>
</html>
