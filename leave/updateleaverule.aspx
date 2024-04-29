<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateleaverule.aspx.cs" Inherits="leave_updateleaverule" %>

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
                                <h2> Leave Rule</h2>
                            </div>
                          
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span> Edit
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Policy Name</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_policy_name" runat="server" Text="Label"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Name</label>
                                            <div class="controls span3">
                                                <asp:Label ID="lbl_leave" runat="server" Text="Label"></asp:Label>
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>General Rule
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <%--<div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Entitled days is Required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Entitled_yes" runat="server" AutoPostBack="True" Checked="True"
                                                            GroupName="abc" Text="Yes" OnCheckedChanged="rd_Entitled_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Entitled_no" runat="server" AutoPostBack="True" GroupName="abc"
                                                            Text="No" OnCheckedChanged="rd_Entitled_no_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Entitled days per year</label>
                                                <asp:TextBox ID="txt_entitled" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>--%>
                                                   <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Monthly Process required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="RadMonthly_yes" runat="server" Text="Yes" GroupName="MD" OnCheckedChanged="RadMonthly_yes_CheckedChanged" AutoPostBack="true" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="RadMonthly_no" runat="server" Text="No" GroupName="MD" Checked="True"  OnCheckedChanged="RadMonthly_no_CheckedChanged" AutoPostBack="true" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Credit Days</label>
                                                <asp:TextBox ID="txt_month_days" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Entitled days is Required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Entitled_yes" runat="server" AutoPostBack="True" Checked="True"
                                                            GroupName="abc" Text="Yes" OnCheckedChanged="rd_Entitled_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Entitled_no" runat="server" AutoPostBack="True" GroupName="abc"
                                                            Text="No" OnCheckedChanged="rd_Entitled_no_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <div id="entitledid" runat="server" >
                                                    <label id="lable entitleddays" class="control-label span3">Entitled days per year</label>
                                                    <asp:TextBox ID="txt_entitled" style="margin-left:36px"  runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                </div>
                                                <div id="postid" runat="server">
                                                    <div class="control-group">
                                                        <div class="controls controls-row">
                                                            <label class="control-label span3 ">Post delivery</label>
                                                            <div class="span3">
                                                                <asp:TextBox ID="postdelivery" runat="server" OnTextChanged="postdelivery_TextChanged" AutoPostBack="true" CssClass="span3" Width="60px">0</asp:TextBox>
                                                            </div>
                                                            <label class="control-label span3">Pre delivery</label>
                                                            <div class="span3">
                                                                <asp:TextBox ID="predelivery" runat="server" CssClass="span3" Width="60px" OnTextChanged="predelivery_TextChanged" AutoPostBack="true">0</asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <%-- <label class="control-label span3">post delivery</label>
                                                    <asp:TextBox ID="lblpostdelivery" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                    <label class="control-label span3">pre delivery</label>
                                                    <asp:TextBox ID="lb.predelivery" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>--%>
                                                </div>
                                            </div>
                                        </div>
                                         
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Days before leave to be apply</label>
                                                <div class="span3">
                                                    <asp:TextBox ID="txt_days_before_leave" runat="server" CssClass="span3" Width="60px" OnTextChanged="txt_days_before_leave_TextChanged" AutoPostBack="true">0</asp:TextBox>
                                                </div>
                                                <label class="control-label span3">Half day leave applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_halfdays_yes" runat="server" Checked="True" GroupName="z"
                                                            Text="Yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_halfday_no" runat="server" GroupName="z" Text="No" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Minimum number of days</label>
                                                <div class="span3">
                                                    <asp:TextBox ID="txt_minimum" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                </div>
                                                <label class="control-label span3">Maximum number of days</label>
                                                <div class="span3">
                                                    <asp:TextBox ID="txt_maximum" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Document required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_document_yes" runat="server" Text="Yes" GroupName="bbbb" Checked="True" OnCheckedChanged="opt_document_yes_CheckedChanged" AutoPostBack="true" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_document_no" runat="server" Text="No" GroupName="bbbb" OnCheckedChanged="opt_document_no_CheckedChanged" AutoPostBack="true" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Document Required Days</label>
                                                <asp:TextBox ID="txt_excess_days" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Back date leave applying</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_backdate_yes" runat="server" Text="Yes" GroupName="c" AutoPostBack="True" OnCheckedChanged="opt_backdate_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_backdate_no" runat="server" Text="No" GroupName="c" AutoPostBack="True" OnCheckedChanged="opt_backdate_yes_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">With in how many days</label>
                                                <asp:TextBox ID="txt_how_many" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Exclude Holiday</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_holidays_yes" runat="server" Text="Yes" GroupName="d" Checked="True" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_holidays_no" runat="server" Text="No" GroupName="d" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Exclude Weekly off</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_weekly_yes" runat="server" Checked="True" GroupName="1"
                                                            Text="Yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_weekly_no" runat="server" GroupName="1" Text="No" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Working Days Required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_workdays_yes" runat="server" Text="Yes" GroupName="ccc" Checked="True" AutoPostBack="True" OnCheckedChanged="rd_workdays_yes_CheckedChanged1" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_workdays_no" runat="server" Text="No" GroupName="ccc" Checked="false" AutoPostBack="True" OnCheckedChanged="rd_workdays_no_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">With in how many Working  days</label>
                                                <asp:TextBox ID="txt_working_days" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Last Year Working Days Required</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_last_year_work_days_yes" runat="server" Text="Yes" GroupName="lw" Checked="True" AutoPostBack="True" OnCheckedChanged="rd_last_year_work_days_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_last_year_work_days_no" runat="server" Text="No" Checked="false" GroupName="lw" AutoPostBack="True" OnCheckedChanged="rd_last_year_work_days_no_CheckedChanged1" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">With in how many Working  days</label>
                                                <asp:TextBox ID="txt_last_year_working_days" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">ESI Applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Esi_Applicable_yes" runat="server" Text="Yes" GroupName="esi" Checked="True" AutoPostBack="True" OnCheckedChanged="rd_Esi_Applicable_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_Esi_Applicable_no" runat="server" Text="No" Checked="false" GroupName="esi" AutoPostBack="True" OnCheckedChanged="rd_Esi_Applicable_no_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">With in how much salary</label>
                                                <asp:TextBox ID="txt_salary" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Monthly Leave  Applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_month_leave_applicable_yes" runat="server" Text="Yes" GroupName="mla" AutoPostBack="True" Checked="True" OnCheckedChanged="rd_month_leave_applicable_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_month_leave_applicable_no" runat="server" Checked="false" Text="No" GroupName="mla" AutoPostBack="True" OnCheckedChanged="rd_month_leave_applicable_no_CheckedChanged" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Maximum No. of Days/Max No. of Times</label>
                                                <asp:TextBox ID="txt_mon_max_days" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                <asp:TextBox ID="txt_mon_max_nooftimes" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
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
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkMale" runat="server" />
                                                        Male
                                                    </label>
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkFemale" runat="server" />
                                                        Female
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Marital Status</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkmarried" runat="server" />
                                                        Married
                                                    </label>
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkunmarried" runat="server" />
                                                        Unmarried 
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Select Employee Status</label>
                                                <div class="span9">
                                                    <asp:UpdatePanel ID="empstatus" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" style="color:#990000;font:bold 11px verdana, Helvetica, sans-serif">Check All</asp:LinkButton>
                                                            |
                                            <asp:LinkButton ID="lnkuncheckall" runat="server" OnClick="lnkuncheckall_Click" style="color:#990000;font:bold 11px verdana, Helvetica, sans-serif">Uncheck All</asp:LinkButton>
                                                            <asp:CheckBoxList ID="chkempstatus" runat="server" CellPadding="10" CellSpacing="10" RepeatColumns="8" RepeatDirection="Horizontal">
                                                            </asp:CheckBoxList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
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
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_carryforward_yes" runat="server" AutoPostBack="True" Checked="True" GroupName="e" OnCheckedChanged="opt_carryforward_yes_CheckedChanged" Text="Yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_carryforward_no" runat="server" AutoPostBack="True" GroupName="e" OnCheckedChanged="opt_carryforward_no_CheckedChanged" Text="No" />
                                                    </label>
                                                </div>
                                                <label class="control-label span2">Carry forward days</label>
                                                <div class="controls span2">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_carry_all" runat="server" AutoPostBack="True" Checked="True" GroupName="ac" OnCheckedChanged="opt_carry_all_CheckedChanged" Text="All" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_carry_days" runat="server" AutoPostBack="True" GroupName="ac" OnCheckedChanged="opt_carry_days_CheckedChanged" Text="Days" />
                                                    </label>
                                                </div>
                                                <div class="span1">
                                                    <asp:TextBox ID="txt_carry_maximumdays" runat="server" CssClass="span1" Width="60px">0</asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Accumulation days</label>
                                                <div class="controls span2">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_accumulation_all" runat="server" AutoPostBack="True" Checked="True" GroupName="ab" OnCheckedChanged="opt_accumulation_all_CheckedChanged" Text="All" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_accumulation_days" runat="server" AutoPostBack="True" GroupName="ab" OnCheckedChanged="opt_accumulation_days_CheckedChanged" Text="Days" />
                                                    </label>
                                                </div>
                                                <label class="control-label span1" style="display:none">Min. Accumulation days</label>
                                                <asp:TextBox ID="txt_min_accumulation" runat="server" CssClass="span2" Width="60px" placeholder="Min">0.0</asp:TextBox>
                                                <label class="control-label span1" style="margin-left:130px">Max. Accumulation days</label>
                                                <asp:TextBox ID="txt_max_accumulation" runat="server"  CssClass="span2" Width="60px" placeholder="Max">0.0</asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave Encashment Applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_encash_app_yes" runat="server" AutoPostBack="True" GroupName="encash" OnCheckedChanged="rd_encash_app_yes_CheckedChanged" Text="yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_encash_app_no" runat="server" AutoPostBack="True" GroupName="encash" OnCheckedChanged="rd_encash_app_no_CheckedChanged" Text="No" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3" >Encashment Limit Days</label>
                                                <asp:TextBox ID="txt_EncashLimit" runat="server" CssClass="span3" Width="60px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">ProRata Applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdprorata_yes" runat="server" Text="Yes" GroupName="pro" Checked="false" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rdprorata_no" runat="server" Text="No" GroupName="pro" Checked="true" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Leave Apply for Next Year</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_next_year_yes" runat="server" Text="Yes" GroupName="next" Checked="true" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_next_year_no" runat="server" Text="No" GroupName="next" Checked="false" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group" style="display: none">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave extension/shorten</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_extension_yes" runat="server" Checked="True" GroupName="g" Text="Yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_extension_no" runat="server" CausesValidation="True" GroupName="g" Text="No" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions no-margin" align="right">
                                            <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="btn btn-primary"
                                                OnClick="btnsbmit_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-info " OnClick="btnreset_Click" Text="Cancel" />
                                            <asp:HiddenField ID="hidden_leaveid" runat="server" />
                                            <asp:HiddenField ID="hidden_entitled" runat="server" />
                                            <asp:HiddenField ID="hidden_policyid" runat="server" />
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
