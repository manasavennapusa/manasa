<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalEmployeeReport.aspx.cs" Inherits="appraisal_AppraisalEmployeeReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateData() {
            var quater = document.getElementById('<%=ddl_quarter.ClientID %>');
            var year = document.getElementById('<%=ddlAppraisalCycle.ClientID %>');


            if (year.value == 0) {
                alert("Please Select Appraisal Year");
                return false;
            }
            if (quater.value == 0) {
                alert("Please Select Quarter");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Employee Appraisal Report</h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Appraisal Report
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Appraisal Year</label>
                                                <div class="controls">
                                                    <asp:DropDownList
                                                        ID="ddlAppraisalCycle"
                                                        runat="server"
                                                        AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label span3">Quarter</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_quarter" runat="server" CssClass="span3">
                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                          <asp:ListItem Value="1">Q1</asp:ListItem>
                                                          <asp:ListItem Value="2">Q2</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnreport" runat="server" Text="Report" CssClass="btn btn-info" OnClick="btnreport_Click" OnClientClick="return ValidateData();" />&nbsp;
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>



