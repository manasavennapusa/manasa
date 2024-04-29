<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CatalogEdit.aspx.cs" Inherits="InformationCenter_CatalogEdit" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <%-- this will make the asterisk red in color --%>
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>News Details</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                <asp:Label ID="lblhead" runat="server" Text="Edit"></asp:Label>
                            </div>
                        </div>

                        <div class="widget-body">
                            <fieldset>

                                <div class="control-group">
                                    <label class="control-label">Type<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:DropDownList ToolTip="Select Type" ID="ddltype" runat="server" CssClass="span4">
                                            <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="Employee"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddltype"
                                            ErrorMessage="Select Type" InitialValue="0" ValidationGroup="v"
                                            Display="Dynamic" ForeColor="Red" ToolTip="Select Type"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>

                                <div class="control-group">
                                    <label class="control-label">Subject<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtsubject" size="40" CssClass="span4" runat="server" ToolTip="Enter Subject" onkeypress="return isKey(event);"></asp:TextBox>
                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator1" ToolTip="Enter Subject" runat="server" ControlToValidate="txtsubject" ErrorMessage="Enter Subject"
                                            Display="Dynamic" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Enter Heading" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txtdescription" CssClass="span4" runat="server" ToolTip="Enter Description" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Upload News Details<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:FileUpload ID="fupload" runat="server" CssClass="blue1" ToolTip="Attach Document here"
                                            Width="287px" />
                                      <%--  <asp:RequiredFieldValidator ID="rfvupload" runat="server" ControlToValidate="fupload"
                                            Display="Dynamic" ErrorMessage="Attach Document" ToolTip="Attach Document" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Attach Document" />
                                        </asp:RequiredFieldValidator>--%>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                            CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />'
                                            ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT)$"
                                            ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="File Not Supported" /></asp:RegularExpressionValidator><p style="color: red">(Supported Files are PDF,Docx.Doc)</p>
                                        <a id="dftlink1" runat="server" class="link05">
                                            <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                        </a>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label"></label>
                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="v" OnClick="btnupdate_Click" />&nbsp;
                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" />
                                        </div>
                                    </div>
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

