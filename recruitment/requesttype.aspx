<%@ Page Language="C#" AutoEventWireup="true" CodeFile="requesttype.aspx.cs" Inherits="recruitment_requesttype" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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


    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
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

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../images/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>--%>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Request Type</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <%--<asp:Label ID="lblhead" runat="server" Text="Create Request Type"></asp:Label>--%>
                                            <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div class="control-group">
                                            <label class="control-label">Request Type<span class="star"></span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtrequesttype" runat="server" CssClass="span4" ></asp:TextBox> <%--onkeypress="return isCharOrSpace()"--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtrequesttype"
                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Request Type" ValidationGroup="c"
                                                    Width="6px"><img 
                                                            src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator
                                                    ID="RegularExpressionValidator13" runat="server" ValidationGroup="c" ToolTip="Enter only Alphabets and space"
                                                    SetFocusOnError="True" Display="Dynamic" ControlToValidate="txtrequesttype"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationExpression="^[a-zA-Z,&\s]+$"></asp:RegularExpressionValidator>

                                              <%--  ^[a-zA-Z0-9_,\s-]+$--%>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label" style="text-align:right">Description</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtdesc" runat="server" CssClass="span4" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="c"
                                            OnClick="btnSubmit_Click" style="margin-left:80px" />&nbsp;&nbsp;
                                         <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>

                            <div class="row-fluid" id="viewgrid" runat="server">
                                <div class="span12">
                                    <div class="widget no-margin">
                                        <div class="widget-header">
                                            <div class="title">
                                                <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Request Type--%>
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example" class="example_alt_pagination">
                                                <asp:GridView ID="grdRequesttype" runat="server" AutoGenerateColumns="False" DataKeyNames="id" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                    EmptyDataText="No Data Found" OnPreRender="grdRequesttype_PreRender" OnRowDeleting="grdRequesttype_RowDeleting">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Request Type">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrequesttype" runat="server" Text='<%#Eval("requesttype")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcountry" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/requesttype.aspx?Id={0}"
                                                            Text="&lt;img src='../images/edit.png'/&gt;" HeaderStyle-Width="10%">
                                                            <ControlStyle CssClass="link05" />
                                                        </asp:HyperLinkField>

                                                        <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10px" ItemStyle-Width="10px">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                    Text="&lt;img src='../images/download_delete.png'/&gt;">

                                                                </asp:LinkButton>
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

                    <%-- <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>--%>
                    </span>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdRequesttype').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>

