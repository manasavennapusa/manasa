<%@ Page Language="C#" AutoEventWireup="true" CodeFile="candidatereport.aspx.cs" Inherits="recruitment_candidatereport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
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
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header" id="header" runat="server">
                    <div class="pull-left">
                        <h2>Candidate History</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid" id="fullrep" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>CANDIDATE RECRUITMENT HISTORY
                                </div>
                            </div>
                            <div class="form-actions no-margin">
                                <b>Select RRF:&nbsp;</b>
                                <asp:DropDownList ID="ddlrrfcode" runat="server" CssClass="span5" OnSelectedIndexChanged="ddlRRF_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="widget-body">

                                <div id="wizard">
                                    <ol>
                                        <li>Confirmed Candidates</li>
                                        <li>Rejected Candidates</li>
                                        <li>Declined Candidates</li>
                                         <li>Hold Candidates</li>
                                    </ol>

                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <p>
                                                    <div class="widget-body">
                                                        <div id="dt_example" class="example_alt_pagination" >
                                                            <asp:GridView ID="grdConfirmed" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdConfirmed_PreRender1"
                                                                EmptyDataText="No data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnRowDeleting="grdConfirmed_RowDeleting">
                                                                <Columns>
                                                                     <asp:TemplateField HeaderText=" RRF_ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrrfid" runat="server" Text='<%# Eval("rrf_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" RRF Code ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designationname") %>'>></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Join Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                                            Days
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="RRF ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_rrf_id" runat="server" Text='<%# Eval("Candidate_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Profile">
                                                                        <ItemTemplate>
                                                                            <a href='candidatehistorydetails.aspx?id=<%# Eval("Candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>' class="link05">
                                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                            <%--<a href='candidateHistory.aspx?id=<%# Eval("Candidate_id") %>' class="link05">View</a>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-Width="4%" ItemStyle-Width="10px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to reject');"
                                                                                Text="Decline" CssClass="btn btn-info"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                </p>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:UpdatePanel ID="updpnl" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <p>
                                                    <div class="widget-body">
                                                        <div id="dt_example3" class="example_alt_pagination" >
                                                            <asp:GridView ID="grdRejectedcandidates" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdRejectedcandidates_PreRender1"
                                                                EmptyDataText="No Data Found." DataKeyNames="id" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnRowDeleting="grdRejectedcandidates_RowDeleting">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText=" RRF Code">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designationname") %>'>></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Join Status">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbljoinstatus" runat="server" Text='<%# Eval("joinstatus") %>'></asp:Label>
                                                                            Days
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Profile">
                                                                        <ItemTemplate>
                                                                            <a href='candidatehistorydetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>' class="link05">
                                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                            <%-- <a href='candidateHistory.aspx?id=<%# Eval("Candidate_id") %>' class="link05">View</a>--%>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton
                                                                                ID="LinkButton1" runat="server" CommandName="Delete" CssClass="btn btn-info" Text="Delete" OnClientClick="return confirm('Are you sure, you want to delete');"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                        <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                </p>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <p>
                                                    <div class="widget-body">
                                                        <div id="dt_example4" class="example_alt_pagination" >
                                                            <asp:GridView ID="grd_declined_candidates" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grd_declined_candidates_PreRender" OnRowDeleting="grd_declined_candidates_RowDeleting"
                                                                EmptyDataText="No data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Candidate ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcandidate_id" runat="server" Text='<%# Eval("candidate_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="RRF Code ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designation") %>'>></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile_no") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("email_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="RRF ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_rrf_id" runat="server" Text='<%# Eval("Candidate_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Profile">
                                                                        <ItemTemplate>
                                                                            <a href='candidatehistorydetails.aspx?id=<%# Eval("candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>' class="link05">
                                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                            <a href='candidateHistory.aspx?id=<%# Eval("Candidate_id") %>' class="link05"></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderStyle-Width="4%" ItemStyle-Width="10px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                                Text="Delete" CssClass="btn btn-info"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                </p>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                           <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <div>
                                                <p>
                                                    <div class="widget-body">
                                                        <div id="divhold" class="example_alt_pagination" >
                                                            <asp:GridView ID="gridhold" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="gridhold_PreRender"
                                                                EmptyDataText="No Data Found."  CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" >
                                                               <Columns>
                                                                    <asp:TemplateField HeaderText="Candidate ID">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblcandidate_id" runat="server" Text='<%# Eval("candidate_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="RRF Code ">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Candidate Name">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("candidate_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Designation">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designationname") %>'>></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Mobile No.">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblmobileno" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Email Id">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblemailid" runat="server" Text='<%# Eval("emailid") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Qualification">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblqualification" runat="server" Text='<%# Eval("Qualification") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="RRF ID" Visible="false">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_rrf_id" runat="server" Text='<%# Eval("Candidate_id") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText=" Profile">
                                                                        <ItemTemplate>
                                                                            <a href='candidatehistorydetails.aspx?id=<%# Eval("candidate_id") %>&rrf_id=<%# Eval("rrf_id")%>' class="link05">
                                                                                <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                            <a href='candidateHistory.aspx?id=<%# Eval("Candidate_id") %>' class="link05"></a>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                         <asp:TemplateField HeaderText="Interview Result3">
                                                <ItemTemplate>
                                                    <a href='candidatereport.aspx?cid=<%# Eval("Candidate_id") %>&rrfhid=<%#Eval("rrf_code")%>' class="link05"><img src="../images/Evaluate.png" width="25" height="25"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                                  <%--  <asp:TemplateField HeaderStyle-Width="4%" ItemStyle-Width="10px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are you sure, you want to delete');"
                                                                                Text="Delete" CssClass="btn btn-info"></asp:LinkButton>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                    <p>
                                                    </p>
                                                </p>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                                  
                            </div>

                            
                        </div>
                    </div>
                </div>
                 <div id="Interviewdetails" runat="server" visible="false">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Candidate Information
                                    </div>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </div>
                                <table class="table table-condensed table-striped  table-bordered pull-left">
                                    <tbody>
                                        <tr>
                                            <th class="span3">RRF Code
                                            </th>
                                            <td class="span4">
                                                <asp:Label ID="lblrrfcode" runat="server"></asp:Label>
                                            </td>
                                            <th class="span3">Candidate Name
                                            </th>
                                            <td class="span4">
                                                <asp:Label ID="lblCandidatename" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Qualification</th>
                                            <td>
                                                <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                            </td>
                                            <th>Skills
                                            </th>
                                            <td>
                                                <asp:Label ID="lblSkills" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <th>Experience
                                            </th>
                                            <td>
                                                <asp:Label ID="lblExperience" runat="server"></asp:Label>
                                            </td>
                                            <th></th>
                                            <td></td>
                                        </tr>

                                        <asp:HiddenField ID="hdcandidatecode" runat="server" />
                                    </tbody>
                                </table>

                            </div>

                        </div>

                    </div>

                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon=""></span>Interview Rating
                                    </div>
                                </div>
                                <div class="widget-body" id="radiobuttons">
                                    <table class="table table-condensed table-bordered no-margin">

                                        <thead>
                                            <tr>
                                                <th style="width: 3%">Functional</th>
                                                <th style="width: 5%">UnSatisfactory</th>
                                                <th style="width: 5%">Satisfactory</th>
                                                <th style="width: 5%">Good</th>
                                                <th style="width: 5%">Excellent</th>
                                                <th style="width: 5%">Exceptional</th>
                                                <th style="width: 3%">Not Applicable</th>
                                                <th>Particulars</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>General/ Basic Knowledge</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="optionsRadios2" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio1" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio2" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio3" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio4" value="2" /></td>
                                                   <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio47" value="1" /></td>
                                                <td>
                                                    <p>
                                                       Basic knowledge of work related to the field as applicable (Accounting/ Payroll/Benefit/ US HR/ HR/PHP/Finance/ Taxation)
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Concepts and Standards</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio5" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio6" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio7" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio8" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio9" value="2" /></td>
                                                   <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio48" value="1" /></td>
                                                <td>
                                                    <p>
                                                        Understanding of concepts and standards as applicable
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Advance Knowledge</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio10" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio11" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio12" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio13" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio14" value="2" /></td>
                                                 <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio49" value="1" /></td>
                                                <td>
                                                    <p>
                                                        Advance level of knowledge in respective field
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Software knowledge</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio15" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio16" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio17" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio18" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio19" value="2" /></td>
                                                   <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio50" value="1" /></td>
                                                <td>
                                                    <p>
                                                        Software knowledge in respective field
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Decision Making/ Trouble Shooting</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio20" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio21" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio22" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio23" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio24" value="2" /></td>
                                                    <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio51" value="1" /></td>
                                                <td>
                                                    <p>
                                                        Demonstrate decision making and trouble shooting skills in respective field
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Review/Analytical skills</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio25" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio26" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio27" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio28" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio29" value="2" /></td>
                                                       <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio52" value="1" /></td>
                                                <td>
                                                    <p>
                                                        Demonstrate review and analytical skills in respective field
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td>Customer Orientation</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio30" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio31" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio32" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio33" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio34" value="2" /></td>
                                                     <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio53" value="1" /></td>
                                                <td>
                                                    <h6>Customer Orientation:
                                                    </h6>
                                                    <p>
                                                        Alert to customer needs, develop & maintain relationships.
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server" visible="false">
                                                <td>Culter Fit</td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio35" value="6" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio36" value="5" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio37" value="4" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio38" value="3" /></td>
                                                <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio39" value="2" /></td>
                                                    <td>
                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio54" value="1" /></td>
                                                <td>
                                                    <h6>Culter Fit:
                                                    </h6>
                                                    <p>
                                                        Ability to fit himself/herself to the Escalon Business Services Pvt Ltd
                                                    </p>
                                                </td>
                                            </tr>
                                            <tr id="Tr3" style="background-color:#f2f2f2" runat="server">
                                            <td id="Td8" style="background-color:#f2f2f2" runat="server"><b>HR</b></td>
                                            <td id="Td9" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td10" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td11" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td12" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td13" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td14" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td15" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                        </tr>
                                        <tr>
                                            <td>Behavior</td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio57" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio58" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio59" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio60" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio61" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio62" value="1" onclick="avg();" /></td>
                                            <td id="Td16" runat="server" style="border-bottom:none">
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Stability</td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio63" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio64" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio65" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio66" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio67" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio68" value="1" onclick="avg();" /></td>
                                            <td id="Td17" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Relevant Experience</td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio69" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio70" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio71" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio72" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio73" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio74" value="1" onclick="avg();" /></td>
                                            <td id="Td18" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Interest in Profile</td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio75" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio76" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio77" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio78" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio79" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio80" value="1" onclick="avg();" /></td>
                                            <td id="Td19" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Communication Skills</td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio81" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio82" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio83" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio84" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio85" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio86" value="1" onclick="avg();" /></td>
                                            <td id="Td20" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Need</td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio87" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio88" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio89" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio90" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio91" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio92" value="1" onclick="avg();" /></td>
                                            <td id="Td21" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Self Development</td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio93" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio94" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio95" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio96" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio97" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio98" value="1" onclick="avg();" /></td>
                                            <td id="Td22" runat="server" style="border-bottom:none; border-top:none">
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Team Co-ordination/ Management</td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio99" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio100" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio101" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio102" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio103" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio104" value="1" onclick="avg();" /></td>
                                            <td id="Td23" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Package Budget</td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio105" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio106" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio107" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio108" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio109" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio110" value="1" onclick="avg();" /></td>
                                            <td id="Td24" runat="server" style="border-top:none">
                                                
                                            </td>
                                        </tr>
                                        </tbody>

                                    </table>
                                    <table class="table table-condensed table-bordered no-margin" >
                                        <tr id="Tr4" runat="server">
                                            <td>Overall Assessment</td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio40" value="6" />Exceptional
                                                </label>
                                            </td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio41" value="5" />Excellent
                                                </label>
                                            </td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio42" value="4" />Good</label></td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio43" value="3" />Average</label></td>
                                                <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio55" value="2" />Satisfactory</label></td>
                                                <td>
                                                <label class="radio inline">
                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio56" value="1" />Unsatisfactory </label></td>

                                        </tr>
                                        <tr id="Tr5" runat="server">
                                            <td>Panel's Recomendation</td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio44" value="3" />
                                                    Selected</label></td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio45" value="2" />Not Selected</label></td>
                                            <td>
                                                <label class="radio inline">
                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio46" value="1" />Put On Hold</label></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>

                                        <tr>
                                            <td>Remarks:</td>
                                            <td colspan="6">
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="span7" disabled="disabled" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Comments:</td>
                                            <td colspan="6">
                                                <asp:TextBox ID="txt_comments" runat="server" CssClass="span7" TextMode="MultiLine" ValidationGroup="rrf"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_comments"
                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Comments"
                                                    ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                    </table>

                                    <div class="form-actions no-margin">
                                        <%--<asp:Button ID="btnInsert" runat="server" Text="Save Details" CssClass="btn btn-primary" OnClick="btnInsert_Click" />&nbsp;--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions no-margin" style="text-align:right">
                    <asp:Button ID="btn_confirmed" runat="server" Text="Confirm Candidate" CssClass="btn btn-info" ValidationGroup="rrf" OnClick="btn_confirmed_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btn_Rejected" runat="server" Text="Reject Candidate" CssClass="btn btn-info" ValidationGroup="rrf" OnClick="btn_rejected_Click" />&nbsp;&nbsp;
                        
                       
                        
                          <asp:Button ID="btn_Back" runat="server" Text="Back" CssClass="btn btn-info" ValidationGroup="rrf" OnClick="btn_back_Click" />  

                    </div>
                </div>

            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdConfirmed').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        $(document).ready(function () {
            $('#grdRejectedcandidates').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        $(document).ready(function () {
            $('#grd_declined_candidates').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

    </script>
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
