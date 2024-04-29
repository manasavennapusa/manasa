<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewleaverule.aspx.cs" Inherits="leave_viewleaverule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="page-header">
                            <div class="pull-left">
                               <%--<h2>View Leave Rule</h2>--%>
                                 <h2>Leave Rule</h2>
                            </div>
                          
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Leave Rule--%>
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Policy Name</label>
                                            <asp:Label ID="lbl_policy_name" class="control-label span3" runat="server"></asp:Label>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Name</label>
                                            <asp:Label ID="lblleave" runat="server" CssClass="control-label span3"></asp:Label>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>General Rule
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                              <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Monthly Process required</label>
                                                <div class="controls span3">
                                                   <div class="controls span3">
                                                    <asp:Label ID="label_processmonth" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                </div>
                                                <label class="control-label span3">Credit Days</label>
                                                <asp:Label ID="label_processmonth_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Entitled days is Required</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_entitled_required" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label id="entitleid" runat="server" class="control-label span3">Entitled days per year</label>
                                                <asp:Label ID="lbl_entitled_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>

                                              <%--  <label id="postid" runat="server" class="control-label span3">Post delivery </label>
                                                <asp:Label ID="lbl_post" runat="server" CssClass="span3"  Width="220px"></asp:Label>

                                                <label id="preid" runat="server" class="control-label span3">pre delivery </label>
                                                <asp:Label ID="lbl_pre" runat="server" CssClass="span3"  Width="220px"></asp:Label>--%>
                                            </div>
                                        </div>
                                         <div class="control-group" id="postid" runat="server">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Post delivery</label>
                                                <div class="controls span3">
                                                  <asp:Label ID="lbl_post" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
            
                                                <label id="Label8" runat="server" class="control-label span3">pre delivery </label>
                                                <div class="controls span3">
                                                <asp:Label ID="lbl_pre" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                    </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Days before leave to be apply</label>
                                                <div class="span3">
                                                    <asp:Label ID="lbl_days_before_leave" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Half day leave applicable</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_halfdays_leave" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Minimum number of days</label>
                                                <div class="span3">
                                                    <asp:Label ID="lbl_minimum_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Maximum number of days</label>
                                                <div class="span3">
                                                    <asp:Label ID="lbl_entitled_maxdays" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Document required</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_doc_required" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Document Required Days</label>
                                                <asp:Label ID="lbl_doc_required_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Back date leave applying</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_backdate_apply" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">With in how many days</label>
                                                <asp:Label ID="lbl_backdate_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Exclude Holiday</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="Label4" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Exclude Weekly off</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_weekly" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Working Days Required</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_workingdays_required" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">With in how many Working  days</label>
                                                <asp:Label ID="lbl_workingdays" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Last Year Working Days Required</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_lastwrk_day" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">With in how many Working  days</label>
                                                <asp:Label ID="lbl_last_work_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">ESI Applicable</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_esi_app" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">With in how much salary</label>
                                                <asp:Label ID="lbl_esi_cut_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Monthly Leave  Applicable</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_mon_applicable" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Maximum No. of Days/Max No. of Times</label>
                                                <asp:Label ID="lbl_mon_applicable_max_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                <asp:Label ID="lbl_mon_applicable_max_nooftimes" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Applicable To
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Gender</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_genderapplicable" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Marital Status</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_matrrialstatus" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Select Employee Status</label>
                                                <div class="span9">
                                                    <asp:Label ID="lbl1" runat="server">
                                                    </asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Accumulation/Carry Forward
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Carry forward for next year</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="Label3" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Carry forward days</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_carryforward" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Accumulation days</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_min_accumulation_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>

                                                    <asp:Label ID="lbl_accumulation_days" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave Encashment Applicable</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lblencashapplicable" runat="server"></asp:Label>
                                                </div>
                                                <label class="control-label span3" >Encashment Limit Days</label>
                                                <asp:Label ID="lblencashdays" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">ProRata Applicable</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lblprorata" runat="server"></asp:Label>
                                                </div>
                                                <label class="control-label span3">Leave Apply for Next Year </label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_last_year" runat="server"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group" style="display: none">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave extension/shorten</label>
                                                <div class="controls span3">
                                                    <asp:Label ID="lbl_modification" runat="server" CssClass="span3"  Width="220px"></asp:Label>
                                                </div>
                                            </div>
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
</body>
</html>
