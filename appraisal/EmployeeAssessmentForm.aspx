<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmployeeAssessmentForm.aspx.cs" Inherits="appraisal_EmployeeAssessmentForm" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

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

    <script type="text/javascript" language="javascript">
        function RefeshWindow() {
            window.opener.location.reload();
        }
    </script>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>My E-Evaluation Status</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                    <asp:Label ID="Label1" runat="server" Text="View"></asp:Label>--%>
                                   <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div runat="server" id="empdetails">



                                    <table style="width: 100%;">
                                        <tr>
                                            <td class="txt01" style="height: 40px"><strong>Rating System</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gridratings" runat="server" Width="100%" AutoGenerateColumns="False"
                                                    DataKeyNames="rating_id" BorderWidth="0px" CellPadding="4" AllowPaging="True"
                                                    CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Rating">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "rating")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>


                                    <table style="width: 100%;" runat="server" visible="false">
                                        <tr>
                                            <td class="txt01" style="height: 40px"><strong>Smart Goals</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                    CaptionAlign="Left" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                    DataKeyNames="asd_id,empcode" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" ShowFooter="true"
                                                    EmptyDataText="No Data Found">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Sl.No">
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex +1 %>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="5%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Title">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("title") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Description">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="20%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Weightage(%)">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Goal Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelempgoalcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Manager Goal Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Labelmnggoalcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Employee Ratings">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblemprating" runat="Server" Text='<%# Eval("emprating") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Average Rating :</b>
                                                                <asp:Label ID="lblGoalsAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Emp Rating Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblempcomments" runat="Server" Text='<%# Eval("empcomments") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Supervisor  Rating">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblrating" runat="Server" Text='<%#Eval("mgrrating")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                <b>Average Rating :</b><asp:Label ID="lblmgrAvgRating" runat="Server" Font-Bold="true"></asp:Label>
                                                            </FooterTemplate>
                                                            <HeaderStyle Width="10%" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Supervisor Rating  Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="Server" Text='<%#Eval("mgrcomments")%>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="15%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="Table2" runat="server">

                                        <tr id="trgoal1">
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="goalcycle1" runat="server" visible="false">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-right: 1px solid #e0e0e0"><b>Cycle 1 : </b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border: 1px solid #e0e0e0 ;border-right: 0px solid #e0e0e0">Goal  cycle 1 Initiated Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border: 1px solid #e0e0e0">
                                                            <asp:Label ID="lblcyl1intdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #e0e0e0;">
                                                            <asp:Label ID="Label3" runat="server" Text="Employee OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #e0e0e0">
                                                            <asp:Label ID="lblgoal1empcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #e0e0e0">
                                                            <asp:Label ID="Label5" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #e0e0e0">
                                                            <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%; border-bottom: 1px solid #e0e0e0">
                                                            <asp:Label ID="Label4" runat="server" Text="Business Head OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%; border-bottom: 1px solid #e0e0e0">
                                                            <asp:Label ID="lblgoal1byBHcmnts" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal Freezed Date
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdate" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered " id="goalcycle2" runat="server" visible="false">
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="border-right: 1px solid #e0e0e0; width: 20%;"><b>Cycle 2 :</b>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal  Cycle 2 Initiated Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgol2intdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label2" runat="server" Text="Employee OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lbempcmts" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="lblcmtsText" runat="server" Text="Line Manager OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="txtmgrComments" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            <asp:Label ID="Label6" runat="server" Text="Business Head OverAll Comments"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgoal1byBHcmntscycle2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                     <tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">
                                                            Goal Freezed Date 
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdatecycle2" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td class="frm-lft-clr123 " style="width: 20%;">Goal Freezed Date:
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 80%;">
                                                            <asp:Label ID="lblgolfrzdate" runat="server"></asp:Label>

                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                    <table id="trTraining1" runat="server" visible="false" style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                            <td class="txt01" style="height: 40px"><b>Training Requirement</b>
                                            </td>
                                            <td id="trTraining2" runat="server">
                                                <asp:Label ID="txttraining" runat="Server" Width="550px" Height="60px" CssClass="frm-rght-clr123 border-bottom"></asp:Label>

                                            </td>
                                        </tr>
                                    </table>
                                    <table class="table table-condensed table-striped  table-bordered pull-left" runat="server" visible="false">

                                        <tr>
                                            <td>
                                                <br />
                                                <table style="width: 100%;" class="table table-condensed table-striped  table-bordered pull-left">
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%; border-bottom: 1px #ddd solid;"><b>Rating</b> - Initiated Date
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%; border-right: 1px #ddd solid; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="lblratintdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Smart Goals
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 15%; display: none;">
                                                            <asp:Label ID="GoalAvgRating" runat="server"></asp:Label>
                                                        </td>

                                                        <td class="frm-lft-clr123" style="width: 20%; display: none;">Average Rating of Competencies
                                                        </td>
                                                        <td class="frm-rght-clr123 " style="width: 15%; display: none;">
                                                            <asp:Label ID="CompAvgRating" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr id="troverall1" runat="server">
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 15%;border-bottom:1px solid #ddd; border-top: none;">Employee Overall Rating
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 15%; border-top: none;border-bottom:1px solid #ddd; ">
                                                            <asp:Label ID="lblOverallRating" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 20%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;">Employee Overall Comments
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 40%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="txtOverallComments" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 10%; border-top: none; border-top: 1px #ddd solid; border-bottom: 1px #ddd solid;" id="tdcolor1" runat="server">Performance and Behavior
                                                        </td>
                                                    </tr>
                                                    <tr id="troverall2" runat="server">
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 15%;border-bottom:1px solid #ddd; ">Manager  Overall Rating
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 15%;">
                                                            <asp:Label ID="lblMgrOverallRating" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-lft-clr123 border-bottom" style="width: 20%; border-bottom: 1px #ddd solid;">Manager  Overall Comments
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" style="width: 40%; border-bottom: 1px #ddd solid;">
                                                            <asp:Label ID="txtMgrOverallComments" runat="server"></asp:Label>
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 10%; border-bottom: 1px #ddd solid;" id="tdcolor2" runat="server">
                                                            <asp:Label ID="lblBehavior" runat="server" Width="80px" Height="40px"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" style="width: 20%;">Cycle Closed Date
                                                        </td>
                                                        <td class="frm-rght-clr123" style="width: 15%; border: 1px solid #e0e0e0;">
                                                            <asp:Label ID="cycleclosedate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>

                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="tabpreinc" runat="server" visible="false">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Previous Increment Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">DOJ</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lbldoj" runat="server"></asp:Label>
                                                        </td>


                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Designation(Current)</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lbldes" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Grade(Current)</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblpregrade" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Previous CTC/PA </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblprectc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Previous Year Hike(%) </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblprehike" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Previous Bonus</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblprebonus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered " id="tabcurinc" runat="server" visible="false">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Current Increment Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">Revised Location</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblrevloc" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Department</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdept" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Designation</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdes" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Grade</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevgrade" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevcostcenter" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Hike(%) </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblcurhike" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Increased Amount</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblincramount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current CTC/PA</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurctc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current Bonus</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurbonus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised W.E.F</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <div class="clearfix"></div>
                                    <asp:HiddenField ID="hdinccycle" runat="server" Value="0" />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>

    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>
</body>
</html>

