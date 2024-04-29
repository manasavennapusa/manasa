<%@ Page Language="C#" AutoEventWireup="true" CodeFile="candidateHistory.aspx.cs" Inherits="recruitment_candidateHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
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
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2><%--Candidate Details--%><asp:Label ID="lblheader" runat="server"></asp:Label></h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details                                     
                                </div>
                            </div>

                            <div class="widget-body">

                                <table class="table table-condensed table-striped  table-bordered pull-left">
                                    <tbody>
                                        <tr>
                                            <td>Candidate Name </td>
                                            <td>
                                                <asp:Label ID="txt_candidateName" runat="server"></asp:Label>
                                            </td>
                                            <td>Phone No.</td>
                                            <td>
                                                <asp:Label ID="txt_phoneno" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Email</td>
                                            <td>
                                                <asp:Label ID="txt_email" runat="server"></asp:Label>
                                            </td>
                                            <td>Mobile No.</td>
                                            <td>
                                                <asp:Label ID="txt_mobile" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Experience (in months) </td>
                                            <td>
                                                <asp:Label ID="txt_experience" runat="server"></asp:Label>
                                            </td>
                                            <td>Skills </td>
                                            <td>
                                                <asp:Label runat="server" ID="txt_skills"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Qualifications</td>
                                            <td>
                                                <asp:Label ID="txt_Qualifications" runat="server"></asp:Label>
                                            </td>
                                            <td>Join Status</td>
                                            <td>
                                                <asp:Label ID="txt_joinstatus" runat="server"> </asp:Label>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview History Details                                
                                </div>
                            </div>

                            <div class="widget-body">

                                <table class="table table-condensed table-striped  table-bordered pull-left">
                                    <tbody>
                                        <tr>

                                            <td>Round One Marks</td>
                                            <td>
                                                <asp:Label runat="server" ID="txtround1marks"></asp:Label>
                                            </td>
                                            <td>Round One Status</td>
                                            <td>
                                                <asp:Label runat="server" ID="txtround1status"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td>Round 2 Marks</td>
                                            <td>
                                                <asp:Label ID="lblround2marks" runat="server"></asp:Label>
                                            </td>
                                            <td>Round 2 Status</td>
                                            <td>
                                                <asp:Label runat="server" ID="txtround2status"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Interview Analysis </td>
                                            <td>
                                                <asp:Label runat="server" ID="txtianalysis"></asp:Label>
                                            </td>
                                            <td></td>
                                            <td></td>
                                        </tr>

                                    </tbody>
                                </table>

                                <div class="clearfix"></div>
                            </div>
                            <div class="form-actions no-margin">
                                <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btn_back_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

