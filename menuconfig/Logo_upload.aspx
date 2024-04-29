<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logo_upload.aspx.cs" Inherits="menuconfig_Logo_upload" %>
 <%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
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
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Upload</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Upload Logo
                            </div>
                        </div>
                        <div class="widget-body">
                            <fieldset>
                                <div class="control-group">
                                    <label class="control-label">Attach Document</label>
                                    <div class="controls">
                                        <asp:FileUpload ID="logoupload" runat="server" ToolTip="upload logo here" CssClass="span3" />&nbsp;

                                                <asp:RequiredFieldValidator ID="rfvupload" runat="server" ControlToValidate="logoupload" SetFocusOnError="true"
                                                    Display="Dynamic" ToolTip="Upload Image" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Attach Logo" /></asp:RequiredFieldValidator>

                                                 <asp:RegularExpressionValidator ID="regphoto" runat="server" ControlToValidate="logoupload" SetFocusOnError="true" ToolTip="invalid image"
                                                     ValidationGroup="v" CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="image not supported" />' ValidationExpression="^.+(.png|.jpg|.JPG)$"></asp:RegularExpressionValidator>

                                        <asp:HiddenField ID="hdnphoto" runat="server" Value="" />
                                        <p style="color: red">(Supported images are .png , .jpeg)</p>
                                        <p style="color: red">(Image width must be 320px and Height 100px)</p>

                                    </div>
                                </div>
                                <div class="form-actions no-margin">
                                    <asp:Button ID="btnUpload" runat="server" CssClass="btn btn-primary" Text="Upload" OnClick="btnUpload_Click" ValidationGroup="v" />
                                    <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btncancel_Click" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
