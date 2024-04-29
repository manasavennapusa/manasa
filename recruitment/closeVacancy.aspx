<%@ Page Language="C#" AutoEventWireup="true" CodeFile="closeVacancy.aspx.cs" Inherits="recruitment_closeVacancy" %>

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
    <script src="../Travel/js/popup1.js"></script>
    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <%-- <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />--%>

    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Vacancy Status</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;">VACANCY STATUS </span>--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">View</span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">

                                    <asp:GridView ID="grdvacancy" runat="server" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id"
                                        EmptyDataText="No data Found" CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Requested By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreq" runat="server" Text='<%#Eval("requestedby")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldept" runat="server" Text='<%#Eval("department_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="view">
                                                <ItemTemplate>
                                                    <a href="JavaScript:newPopup1('RRFPopup.aspx?id=<%# Eval("id") %>')" class="link05"><%# Eval("rrf_code") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Filled By" Visible="false">
                                                <ItemTemplate>
                                                    <a href='fillApplicants.aspx?id=<%# Eval("id") %>' class="link05">Enter</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Select">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkclose" runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>

                            <div class="form-actions no-margin">
                                <asp:Button ID="btnSave" runat="server" Text="Close" CssClass="btn btn-info" OnClick="btnSave_Click" style="margin-left:650px" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Cancel" CssClass="btn btn-info" OnClick="btnClear_Click" />&nbsp;
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
