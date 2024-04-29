<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tax_declaration_Upload.aspx.cs" Inherits="tax_declaration_Upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server">
                <ContentTemplate>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Upload Tax Declaration</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            Upload Tax Declaration
                                        </div>
                                        <div>
                                            <a href="download/taxDeclaration_Upload_Format1.xlsx" title="Download Format" class="pull-right">Download
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group">
                                                    <label class="control-label">Upload Tax Declaration</label>
                                                    <div class="controls">
                                                        <asp:FileUpload ID="flEmployee" runat="server" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                            ControlToValidate="flEmployee" ValidationGroup="b" CssClass="txt-red" ErrorMessage="Only excel format(.xls,.xlsx)"
                                                            ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="form-actions no-margin">
                                                    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Upload" CssClass="btn btn-primary" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon=""></span>Warnings
                                        </div>
                                    </div>
                                    <div class="widget-body">

                                        <div class="alert alert-block alert-error fade in">
                                            <%--  <button class="close" type="button" data-dismiss="alert">
                                                ×
                                            </button>--%>
                                            <p runat="server" id="diverror">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
            </asp:UpdatePanel>
        </div>

    </form>
</body>
</html>
