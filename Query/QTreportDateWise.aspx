<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QTreportDateWise.aspx.cs" Inherits="Query_QTreportDateWise" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

    <style type="text/css">
        .star {
            content: " *";
            margin-left: 5px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" />

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>Query Report</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Query Report Date wise
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">From Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtFromDate" runat="server" Width="20%" CssClass="span4" onkeypress="return false;" placeholder="Select Date" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="imgFromDate" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                             <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="imgFromDate"
                                                    TargetControlID="txtFromDate" Format="MM/dd/yyyy">
                                                </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txtToDate" runat="server" Width="20%" CssClass="span4" onkeypress="return false;" placeholder="Select Date" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="imgToDate" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                             <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="imgToDate"
                                                    TargetControlID="txtToDate" Format="MM/dd/yyyy">
                                                </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <div style="padding-left: 110px; padding-right: 95px;">
                                            <asp:Button ID="btnSearch"
                                                runat="server"
                                                Text="Search"
                                                CssClass="btn btn-primary"
                                                ValidationGroup="v" OnClick="btnSearch_Click"></asp:Button>
                                            <%--<asp:Button ID="btnExport"
                                                runat="server"
                                                Text="Export"
                                                CssClass="btn btn-primary"
                                                ValidationGroup="v" OnClick="btnExport_Click"></asp:Button>--%>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Query Reports                                                          
                                </div>
                                <asp:LinkButton ID="lnkbtnExport" Style="float: right;" runat="server" OnClick="lnkbtnExport_Click">Export</asp:LinkButton>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <div style="padding: 5px; font-size: 16px;">
                                        Search :
                                        <asp:TextBox ID="TextBox1" runat="server" Width="15%" Font-Size="15px" onkeyup="Search_Gridview(this, 'gvQueryReport')"></asp:TextBox>
                                    </div>
                                    <asp:GridView ID="gvQueryReport" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="id" BorderWidth="0px" CellPadding="4" EmptyDataText="No records found!"
                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "empCode")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "postedby")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Query Type">
                                                <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "queryTypeName")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="QueryReportDetails.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&page=<%# Eval("Other")%>"
                                                        target="_self">View</a>
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
    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }
    </script>
</body>
</html>
