<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QueryReportDetails.aspx.cs" Inherits="Query_QueryReportDetails" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/main.css" rel="stylesheet">

    <style type="text/css">
        .frm-lft-clr123 {
            font-family: 'lucida grande',tahoma,verdana,arial,sans-serif;
            font-weight: 500;
            font-size: 12px;
            background: #fafafa;
            padding: 9px;
            border: 1px solid #e0e0e0;
            border-bottom: none;
            border-right: none;
            color: #4d4d4d;
        }

        .frm-rght-clr123 {
            -webkit-border-radius: 2px 0 0 0;
            -moz-border-radius: 2px 0 0 0;
            border-radius: 2px 0 0 0;
            background: #ffffff;
            border: 1px solid #e0e0e0;
            border-bottom: none;
            padding: 9px;
        }

        .frm-lft-clr-main {
            background: #ffffff;
            border: 1px solid #e0e0e0;
            padding: 4px 0 4px 4px;
            border-bottom: none;
            font-weight: bold;
        }

        .txt02 {
            font-weight: bold;
        }

        .border-bottom {
            border-bottom: 1px solid #e0e0e0;
        }

        .star {
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
                        <asp:Label ID="lblheadingcreate" runat="server"><h2>View Query Report</h2></asp:Label>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Query Report
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="2" width="100%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">

                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Employee Code
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblEmpCode" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Employee Name<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="lblEmpName" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Query Type<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblQueryType" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                 <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Ticket Type<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lbltickettype" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Priority<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblpriority" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Posted Date<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblPostedDate" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Reference Number<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblRefNo" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Description<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblDescription" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Closed Date<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblApprovedDate" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Closed By<span class="star"></span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lblApprovedby" runat="server" Text=""></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clearfix"></div>
                                    <div class="form-actions no-margin">
                                        <div style="text-align: right">
                                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary" ValidationGroup="v" OnClick="btnBack_Click" />
                                        </div>
                                    </div>
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
