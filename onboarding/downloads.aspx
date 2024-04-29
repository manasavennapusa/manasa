<%@ Page Language="C#" AutoEventWireup="true" CodeFile="downloads.aspx.cs" Inherits="onboarding_downloads" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="js/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>DownLoads </h2>
                        </div>
                      
                        <div class="clearfix"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>DownLoads
                                </div>
                                <a data-toggle="modal" id="lslink" visible="false" runat="server" href="#myModal" class="btn btn-info pull-right pull-right" onclick="return ValidateEmpcode();">Leave Status</a>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">EPF Transfer Form</label>
                                            <div class="controls span1">
                                                <a href="attachments/EPF Transfer Form.pdf" target="_blank">Download</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Nomination Form - Provident Fund</label>
                                            <div class="controls span1">
                                                <a href="attachments/Nomination Form - Provident Fund.pdf" target="_blank">Download</a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Nomination Forms - Gratuity Fund</label>
                                            <div class="controls span1">
                                                <a href="attachments/Nomination Forms - Gratuity Fund.pdf" target="_blank">Download</a>
                                            </div>
                                        </div>
                                    </div>
                                     <div class="control-group">
                                        <div class="controls controls-row">
                                            <label class="control-label span3 ">Form No. 11 - Declaration Form</label>
                                            <div class="controls span1">
                                                <a href="attachments/DeclarationForm.pdf" target="_blank">Download</a>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
