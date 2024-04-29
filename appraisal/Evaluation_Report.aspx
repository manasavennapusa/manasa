<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Evaluation_Report.aspx.cs" EnableEventValidation = "false" Inherits="appraisal_Evaluation_Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/nvd-charts.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container" style="width: 2500px">
                <div class="row-fluid" style="width: 2500px">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;">Employee Overall Details</span>

                                     
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdgeneratereport" runat="server" AutoGenerateColumns="true" AllowSorting="True" OnPreRender="grdgeneratereport_PreRender"
                                        EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <div class="form-actions no-margin" style="text-align: left;">
                               <asp:Button ID="btnExport" runat="server" Text="Export" style="text-align: right;" CssClass="btn btn-info" title="Export" OnClick="btnExport_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
