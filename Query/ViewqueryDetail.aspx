<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewqueryDetail.aspx.cs" Inherits="Query_ViewqueryDetail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

    <style type="text/css">
        .star {
            content: " *";
            margin-left: 5px;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="hdnId" runat="server" />

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>View Query Detail</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div id="empqryDetail" runat="server" class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    My Query Detail
                                </div>
                                <div id="adminqryDetail" runat="server" class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    All Query Detail
                                </div>
                            </div>

                            <div class="widget-body">
                                <fieldset>
                                    <div id="divEmp" runat="server" class="control-group">
                                        <table>
                                            <tr>
                                                <td valign="top"><img src="../images/date-icon.gif" width="10" height="10" alt="" />&nbsp;
                                                    <asp:Label ID="lblPostedOn" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            </table>
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblQueryType" runat="server" Text="" Font-Bold="false" Style="margin-left: 8px" ></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblQueryDetail" runat="server" Text="" Style="margin-left: 8px"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <br />
                                        <table>
                                            <tr>
                                                <td>
                                                    <%--<asp:LinkButton ID="lnkbtnback" runat="server" Style="margin-left: 1025px;" OnClick="lnkbtnback_Click">Back</asp:LinkButton>--%>
                                                    <asp:Button ID="lnkbtnback" runat="server" style="margin-left: 1000px"  OnClick="lnkbtnback_Click"  Cssclass="btn btn-primary"  Text="Back" ></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <div id="divAdmin" runat="server" class="control-group">
                                        <table>
                                            <tr>
                                                <td valign="top"><img src="../images/date-icon.gif" width="10" height="10" alt="" />&nbsp;
                                                    <asp:Label ID="lblPostedONby" runat="server" Text=""></asp:Label>
                                                </td>
                                            </tr>
                                            </table>
                                        <br/>
                                        <table>
                                            <tr>
                                                <td>
                                                 <asp:Label ID="lblqrytypeAdmin" runat="server" Text=""  Style="margin-left: 8px"></asp:Label>
                                                </td>
                                            </tr>
                                            </table>
                                        <br/>
                                                <table>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblqryDetailAdmin" runat="server" Text="" Style="margin-left: 8px"></asp:Label>
                                                </td>
                                            </tr>
                                                    </table>
                                        <br/>
                                        <table>
                                            <tr>
                                                <td>
                                                    <%--<asp:LinkButton ID="lnkbtnbackbyAdmin" runat="server" Style="margin-left: 1025px;" OnClick="lnkbtnbackbyAdmin_Click">Back</asp:LinkButton>--%>
                                                    <asp:Button ID="lnkbtnbackbyAdmin" runat="server" style="margin-left: 1000px" OnClick="lnkbtnbackbyAdmin_Click" Cssclass="btn btn-primary"  Text="Back" ></asp:Button>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>
