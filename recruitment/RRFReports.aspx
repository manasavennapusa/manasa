<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RRFReports.aspx.cs" Inherits="recruitment_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>RRF Candidate Report</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/table.css";

        .gvclass th {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }
    </style>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
    </style>
    <link href="../css/blue1.css" rel="stylesheet" />
    <link href="../css/table.css" rel="stylesheet" />
</head>

<body>
    <%-- <div class="header" style="background-color: black; padding: 10px; height: 650px">--%>
    <form id="cmaster" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:ScriptManager ID="SM1" runat="server"></asp:ScriptManager>--%>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                  <div class="page-header">
                            <div class="pull-left">
                                <h2>Recruitment Report</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>
                <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="frm-lft-clr123">From Date</td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="blue1" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" />
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="frm-lft-clr123">To Date </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="blue1" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate"
                                        Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123 border-bottom">Candidate Status</td>
                                <td class="frm-rght-clr123 border-bottom">
                                    <asp:DropDownList ID="dropstatus" runat="server" CssClass="blue1" Width="200px">
                                        <asp:ListItem Value="0" Text="All"></asp:ListItem>
                                        <asp:ListItem Value="S" Text="Confirmed"></asp:ListItem>
                                        <asp:ListItem Value="R" Text="Rejected"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 border-bottom"></td>
                                <td class="frm-rght-clr123 border-bottom"></td>
                            </tr>

                        </table>

                        <table width="100%">
                            <tr>
                                <td class="frm-lft-clr123 " style="border-right: 1px solid #ddd">Select Candidate Details 

                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="checkcaninfo" OnClick="checkcaninfo_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="uncheckcaninfo" runat="server" CssClass="txt-red" OnClick="uncheckcaninfo_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table1" cellspacing="5" cellpadding="5" border="0">
                                                        <tbody>

                                                            <asp:CheckBoxList ID="chkl_RRFdetails" runat="server" RepeatColumns="5" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="candidate_name" Text="Candidate Name"></asp:ListItem>
                                                                <asp:ListItem Value="designation_id" Text="Designation"></asp:ListItem>
                                                                <asp:ListItem Value="Qualification" Text="Education Qualification"></asp:ListItem>
                                                                <asp:ListItem Value="experience" Text="Experience"></asp:ListItem>
                                                                <asp:ListItem Value="expectedsalary" Text="Expected  Salary"></asp:ListItem>
                                                                <asp:ListItem Value="phone" Text="Phone No"></asp:ListItem>
                                                                <asp:ListItem Value="emailid" Text="Email ID"></asp:ListItem>
                                                                <asp:ListItem Value="locationid" Text="Location"></asp:ListItem>
                                                                <asp:ListItem Value="referredby" Text="Referred By"></asp:ListItem>
                                                            </asp:CheckBoxList>

                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>

                        <table width="100%">
                            <tr>
                                <td class="frm-lft-clr123 " style="border-right: 1px solid #ddd">Select RRF Information Of Candidate

                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="chechbtn" OnClick="chechbtn_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="uncheckbtn" runat="server" CssClass="txt-red" OnClick="uncheckbtn_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table2" cellspacing="10" cellpadding="10" border="0">
                                                        <tbody>
                                                            <asp:CheckBoxList ID="chk_payrolldetails" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="rrf_code" Text="RRF No"></asp:ListItem>
                                                                <asp:ListItem Value="designationname" Text="Designation"></asp:ListItem>
                                                                <asp:ListItem Value="round1_date" Text="Date"></asp:ListItem>
                                                                <asp:ListItem Value="ctc" Text="Expected CTC"></asp:ListItem>
                                                                <asp:ListItem Value="round_1_marks" Text="Round One Marks"></asp:ListItem>
                                                                <asp:ListItem Value="round_1_status" Text="Round_1_Status"></asp:ListItem>
                                                                <asp:ListItem Value="round_2_marks" Text="Round Two Marks"></asp:ListItem>
                                                                <asp:ListItem Value="round_2_status" Text="Round_2_Status"></asp:ListItem>
                                                                <asp:ListItem Value="OverallAssessment" Text="Overall Assessment"></asp:ListItem>
                                                                <asp:ListItem Value="PanelsRecomendation" Text="Panel Recommendation"></asp:ListItem>
                                                                <asp:ListItem Value="status" Text="Final_Status"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>

                        <table>
                            <tr>
                                <td style="text-align: center">
                                    <asp:Button ID="btnGenerate" runat="server" Text="Generate Report" OnClick="btnGenerate_Click" CssClass="button" />
                                </td>
                            </tr>
                        </table>
                        <asp:UpdatePanel runat="server" ID="export">
                            <ContentTemplate>
                                <div id="light" style="top: 5%; left: 2%;" class="pop1" align="center" runat="server">
                                    <table width="800px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="pop-brdr">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="width: 97%" valign="top" class="pop-tp-clr" align="left">&nbsp;Candidate Details 
                                                    <asp:Button ID="btnexport" runat="server" CssClass="btn btn-em" OnClick="btnexport_Click"
                                                        Text="Export" ToolTip="Export" Style="float: right;font-size:16px;font-weight:200" /></td>
                                                        <td style="width: 3%" align="right" valign="top" class="pop-tp-clr">
                                                            <a href="#" onclick="document.getElementById('light').style.display='none';">
                                                                <img src="../images/btn-close.gif" title="Close" width="16" height="19" border="0" /></a>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td colspan="2" height="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" valign="top">
                                                            <div id="policyframe" runat="server" frameborder="0" style="overflow-x: scroll; overflow-y: scroll; width: 1000px; height: 500px;">
                                                                <asp:GridView ID="gridview" runat="server" AutoGenerateColumns="true" Visible="true" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                    EmptyDataText="No Record Found !!">
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="10"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <%-- <asp:HiddenField ID="hdn_branchid" runat="server" Value="0" />--%>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btnGenerate" />
                        <asp:PostBackTrigger ControlID="btnexport" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <%--</div>--%>
</body>
</html>

