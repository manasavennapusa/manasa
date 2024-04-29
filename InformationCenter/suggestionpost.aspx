<%@ Page Language="C#" AutoEventWireup="true" CodeFile="suggestionpost.aspx.cs" Inherits="InformationCenter_suggestionpost" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server"><meta charset="utf-8"/>
    <title>SmartDrive Labs</title>

        <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet"/>
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet"/>

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet"/>

        <!-- fullcalendar css -->
        <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
        <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <%-- this will make the asterisk red in color --%>
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
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="main-container">
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2></h2>
                                </div>

                                <div class="clearfix"></div>
                            </div>

                            <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Suggestion Post
                 
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>

                                            

                                            <div class="control-group">
                                                <label class="control-label">Subject<span class="star"></span></label>
                                                <div class="controls">
                                                   <asp:TextBox ID="txtsubject" CssClass="span4" runat="server" ToolTip="Enter Subject" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox> &nbsp;<asp:RequiredFieldValidator
                                                ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsubject" ErrorMessage="Subject"
                                                ValidationGroup="a"><img src="images\error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                   
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Description<span class="star"></span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdescription" CssClass="span4" runat="server" ToolTip="Enter Description" TextMode="MultiLine" onkeypress="return isKey(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtdescription" ErrorMessage="Enter Description" ToolTip="Enter Description" runat="server"  ValidationGroup="a" ForeColor="Red"> <img src="../images/error1.gif" alt="Enter Description" /></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                             <div class="control-group">
                                               
                                                
                                                 <div class="control-group">
                                                <label class="control-label"></label>
                                                <div class="form-actions no-margin">
                                                     <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="a" />&nbsp;
                                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" />

                                                </div>

                                            </div>
                                                 <%-- this grid view is added, backend coding is not yet dont, the view will be visible when there is data in database. --%>

                                                 
                                            </div>


                                         <%--   <div class="form-actions no-margin">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click" ValidationGroup="c" />
                                                <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" ValidationGroup="c" />
                                            </div>--%>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                           
                            
                        </div>
                    </ContentTemplate>
                     <Triggers>
                        <asp:PostBackTrigger ControlID="btnsubmit" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>

        </form>
</body>
    <script type="text/javascript">
        function WatermarkFocus(txtElem, strWatermark) {
            if (txtElem.value == strWatermark)
                txtElem.value = '';
        }
        function WatermarkBlur(txtElem, strWatermark) {
            if (txtElem.value == '')
                txtElem.value = strWatermark;
        }
    </script>
</html>
