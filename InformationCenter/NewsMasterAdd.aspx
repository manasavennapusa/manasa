<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsMasterAdd.aspx.cs" Inherits="InformationCenter_NewsMasterAdd" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>
    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Buzz</h2>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                        <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Type<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="span4" ToolTip="Select Type">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Employee"></asp:ListItem>

                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" InitialValue="0" ToolTip="Select Type" ControlToValidate="ddlcategory" ErrorMessage="Select Type" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Status<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlrunstatusg" runat="server" CssClass="span4" ToolTip="Select Status">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1">Running</asp:ListItem>
                                                    <asp:ListItem Value="2">Stop</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="0" ToolTip="Select Status" ControlToValidate="ddlrunstatusg" ErrorMessage="Select Status" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Status" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Priorty<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlpriorityg" runat="server" CssClass="span4" ToolTip="Select Priorty">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1">Low</asp:ListItem>
                                                    <asp:ListItem Value="2">Medium</asp:ListItem>
                                                    <asp:ListItem Value="3">High</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" InitialValue="0" ToolTip="Select Priorty" ControlToValidate="ddlpriorityg" ErrorMessage="Select Priorty" runat="server" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Priorty" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Heading<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtheading" size="40" CssClass="span4" runat="server" ToolTip="Enter Heading" onkeypress="return isKey(event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtheading" ErrorMessage=" Enter Heading" runat="server" ToolTip="Enter Heading" ValidationGroup="v" ForeColor="Red"><img src="../images/error1.gif" alt="Select Type" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Description</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtdescription" CssClass="span4" runat="server" ToolTip="Enter Description" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="updpnl" runat="server">
                                            <ContentTemplate>
                                                <div class="control-group">
                                                    <label class="control-label">Attach Document</label>
                                                    <div class="controls">
                                                        <asp:FileUpload ID="fupload" runat="server" ToolTip="Attach Document here" Width="287px" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fupload"
                                                            CssClass="txt-red" Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="File not supported" />' ToolTip="file is Invalid" SetFocusOnError="true"
                                                            ValidationExpression="^.+(.doc|.DOC|.docx|.DOCX|.rtf|.RTF|.pdf|.PDF|.xls|.XLS|.ppt|.PPT|.png|.PNG|.jpg|.JPG)$"
                                                            ValidationGroup="v"><img src="../images/error1.gif" alt="File not supported" /></asp:RegularExpressionValidator><p style="color: red">(Supported Files are PDF,Docx,Doc,JPG,PNG)</p>
                                                        <a id="dftlink1" runat="server" class="link05">
                                                            <asp:Label ID="lbl_file" runat="server"></asp:Label>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="form-actions no-margin">
                                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="v" OnClick="btnSave_Click" />
                                                    <asp:Button ID="btnclear" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnclear_Click" />
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnSave" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
