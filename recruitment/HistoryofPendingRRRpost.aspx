<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HistoryofPendingRRRpost.aspx.cs" Inherits="recruitment_HistoryofPendingRRRpost" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>

    <script type="text/javascript" src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <meta name="author" content="SDLGlobe Technologies India Pvt. Ltd." />
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport" />
    <meta name="description" content="SDLGlobe Technologies India Pvt. Ltd." />
    <meta name="keywords" content="SDLGlobe Technologies India Pvt. Ltd." />
    <script type="text/javascript" src="../js/html5-trunk.js"></script>
    <script type="text/javascript" src="js/popup.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
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

</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Recruitment Status</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid" id="tbl_list" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Search
                                </div>
                            </div>

                           <%-- <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>
                                    <tr>
                                        <td>Select RRF Code
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlrrfcode" runat="server" CssClass="span4" OnSelectedIndexChanged="ddlrrfcode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>--%>

                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdposts" OnPreRender="grdposts_PreRender"
                                        runat="server"
                                        AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !"
                                        class="table table-condensed table-striped table-hover table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="RRF ID" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RRF Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrrfID" runat="server" Text='<%#Eval("rrf_code")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total No Of Post ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbltotal" runat="server" Text='<%#Eval("total_no_posts")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Filled Posts">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblfilled" runat="server" Text='<%#Eval("filled")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Open Posts">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblbalance" runat="server" Text='<%#Eval("total_no_posts")%>'></asp:Label>--%>
                                                    <asp:Label ID="lblbalance" runat="server" Text='<%#Eval("opened_post")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("status").ToString()=="1"?"Active":"Hold"%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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

    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdposts').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>

