<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload_Year_Ending.aspx.cs" Inherits="leave_Upload_Year_Ending" %>

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
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

       <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <%--<asp:UpdatePanel ID="updatepanel1" runat="server">
                <ContentTemplate>--%>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                               <%--<h2>Upload Leave Balance</h2>--%>
                                 <h2>upload Year Ending Leave Balance</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            Upload
                                        </div>
                                        <div>
                                            <a href="../download/uploadYearEnding.xlsx" title="Download Format" class="pull-right"><span class="fs1" aria-hidden="true" data-icon=""></span>
                                            </a>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>

                                                <%--<div class="control-group">
                                                    <label class="control-label">Employee Leave Balance<span class="star"></span></label>
                                                    <div class="controls span3">
                                                        <asp:FileUpload ID="fupload" runat="server" CssClass="" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                            ControlToValidate="fupload" ValidationGroup="b" CssClass="txt-red" ErrorMessage="Only excel format(.xls,.xlsx)"
                                                            ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$"></asp:RegularExpressionValidator>

                                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Upload Policy"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>--%>

                                                <div class="control-group span8" style="margin-top:10px">
                                                    <label class="control-label" style="width:300px;text-align:center">Employee Leave Balance&nbsp;<span class="star"></span></label>
                                                    <div class="controls">
                                                        <asp:FileUpload runat="server" ID="fupload" ToolTip="Upload File here" style="text-align:left;margin-left:55px" />
                                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload"
                                                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Upload Policy"
                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="fupload"
                                                            ValidationGroup="v" runat="server" ValidationExpression="^([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$" ToolTip="Upload formate(.pdf|.docx|.doc) "
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator><p style="color: red;text-align:center">(Supported Files are PDF,Docx.Doc)</p>--%>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="fupload"   Display="Dynamic"
                                                            ValidationGroup="v" runat="server" ValidationExpression="^([a-zA-Z0-9\s_\\.\-:])+(.xlsx)$" ToolTip="Upload format (.xlsx) "
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>   <p style="color: red;text-align:left;margin-left:120px">(Supported Files is .xlsx)</p>
                                                    </div>
                                                </div>


                                                <div class="form-actions no-margin">
                                                    <asp:Button ID="btn_sbmit" runat="server" CssClass="btn btn-primary pull-right" style="text-align:center" Text="Upload" OnClick="btn_sbmit_Click" ValidationGroup="v"/>
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
                                            <button data-dismiss="alert" class="close" type="button">
                                            </button>
                                            <p runat="server" id="diverror">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                <%--</ContentTemplate>

            </asp:UpdatePanel>--%>
        </div>
    </form>
</body>
</html>
