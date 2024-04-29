<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createleaverule.aspx.cs" Inherits="leave_createleaverule" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
        <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
      <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
<%--<script type="text/javascript">
        function Validate() {
            var lpolicy = document.getElementById('<%=dd_policy.ClientID%>');
            var leave = document.getElementById('<%=ddleave.ClientID%>');
            if (lpolicy.value == 0) {
                alert("Please select leave policy");
                return false;
            }
            if (leave.value == 0) {
                alert("Please select leave type");
                return false;
            }
            return true;
        }
    </script>--%>

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
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Leave Rule</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label span3">Select Policy<span class="star"></span></label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="dd_policy" runat="server" CssClass="span3" Width="220px" OnDataBound="dd_policy_DataBound">
                                                </asp:DropDownList>
                                                 <asp:RequiredFieldValidator ID="requiredgender" runat="server" ValidationGroup="v" ControlToValidate="dd_policy"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Policy" InitialValue="0"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label span3">Leave Name<span class="star"></span></label>
                                            <div class="controls span3">
                                                <asp:DropDownList ID="ddleave" runat="server" CssClass="span3" Width="220px" OnDataBound="ddleave_DataBound" OnSelectedIndexChanged="ddleave_SelectedIndexChanged" AutoPostBack="true">
                                                </asp:DropDownList>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="v" ControlToValidate="ddleave"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Leave Name" InitialValue="0"></asp:RequiredFieldValidator>
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
                                                <div id="entitledid" runat="server">
                                                    <label id="lable entitleddays" class="control-label span3">Entitled days per year</label>
                                                    <asp:TextBox ID="txt_entitled" style="margin-left:36px" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                </div>
                                                <%--  <div id="postid" runat="server">
                                                    <div class="control-group">
                                                        <div class="controls controls-row">
                                                            <label class="control-label span3 ">Post delivery</label>
                                                            <div class="span3">
                                                                <asp:TextBox ID="postdelivery" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
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
                                                    <asp:TextBox ID="lb.predelivery" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                </div>--%>
                                            </div>
                                        </div>
                                        <div class="control-group" id="postid" runat="server">
                                            <div class="controls controls-row">
                                                            <label class="control-label span3 ">Post delivery</label>
                                                            <div class="span3">
                                                                <asp:TextBox ID="postdelivery" runat="server" CssClass="span3" Width="60px">0</asp:TextBox>
                                                            </div>
                                                            <label class="control-label span3">Pre delivery</label>
                                                            <div class="span3">
                                                                <asp:TextBox ID="predelivery" runat="server" CssClass="span3" Width="60px" OnTextChanged="predelivery_TextChanged" AutoPostBack="true">0</asp:TextBox>
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
                                                        <asp:RadioButton ID="opt_backdate_no" runat="server" Text="No" GroupName="c" Checked="True" AutoPostBack="True" OnCheckedChanged="RadioButton4_CheckedChanged" />
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
                                                        <asp:RadioButton ID="RadioButton2" runat="server" Text="No" GroupName="d" />
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
                                                        <asp:RadioButton ID="rd_workdays_yes" runat="server" Text="Yes" GroupName="ccc" Checked="True" AutoPostBack="True" OnCheckedChanged="rd_workdays_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_workdays_no" runat="server" Text="No" GroupName="ccc" AutoPostBack="True" OnCheckedChanged="rd_workdays_no_CheckedChanged" />
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
                                                        <asp:RadioButton ID="rd_last_year_work_days_no" runat="server" Text="No" GroupName="lw" AutoPostBack="True" OnCheckedChanged="rd_last_year_work_days_no_CheckedChanged" />
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
                                                        <asp:RadioButton ID="rd_Esi_Applicable_no" runat="server" Text="No" GroupName="esi" AutoPostBack="True" OnCheckedChanged="rd_Esi_Applicable_no_CheckedChanged" />
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
                                                        <asp:RadioButton ID="rd_month_leave_applicable_yes" runat="server" Text="Yes" GroupName="mla" AutoPostBack="true" Checked="True" OnCheckedChanged="rd_month_leave_applicable_yes_CheckedChanged" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_month_leave_applicable_no" runat="server" Text="No" GroupName="mla" AutoPostBack="True" OnCheckedChanged="rd_month_leave_applicable_no_CheckedChanged" />
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
                                                <label class="control-label span3 ">Gender<span class="star"></span></label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkMale" runat="server" checked="checked" />
                                                        Male

                                                    </label>
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkFemale" runat="server" checked="checked" />
                                                        Female
                                                    </label>
                                                  <asp:CustomValidator ID="Custom1"  CssClass="errorTop"  ClientValidationFunction=""  runat="server" ToolTip="Select Gender" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                 ValidationGroup="v" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /> </asp:CustomValidator>


                                                     <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="rbtnlactive"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Active"
                                                        ValidationGroup="c" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>



                                                </div>
                                                <label class="control-label span3">Marital Status<span class="star"></span></label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkmarried" runat="server" checked="checked" />
                                                        Married
                                                    </label>
                                                    <label class="radio inline">
                                                        <input type="checkbox" id="chkunmarried" runat="server" checked="checked" />
                                                        Unmarried 
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Select Employee Status<span class="star"></span></label>
                                                <div class="span9">
                                                    <asp:UpdatePanel ID="empstatus" runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" style="color:#990000;font:bold 11px verdana, Helvetica, sans-serif">Check All</asp:LinkButton>
                                                            |
                                            <asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click" style="color:#990000;font:bold 11px verdana, Helvetica, sans-serif">Uncheck All</asp:LinkButton>
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
                                               <label class="control-label span3" runat="server" style="display:none">Min. Accumulation days</label>
                                                <asp:TextBox ID="txt_min_accumulation" runat="server"  CssClass="span1" Width="60px" placeholder="Min"></asp:TextBox>
                                                <label class="control-label span2" style="margin-left:130px" >Max. Accumulation days</label>
                                                <asp:TextBox ID="txt_max_accumulation" runat="server" CssClass="span1"  Width="60px" placeholder="Max"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave Encashment Applicable</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_encash_app_yes" runat="server" AutoPostBack="True" Checked="True" GroupName="encash" OnCheckedChanged="rd_encash_app_yes_CheckedChanged" Text="yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_encash_app_no" runat="server" AutoPostBack="True" GroupName="encash" OnCheckedChanged="rd_encash_app_no_CheckedChanged" Text="No" />
                                                    </label>
                                                </div>
                                                <label class="control-label span3">Encashment Limit Days</label>
                                                <asp:TextBox ID="txt_EncashLimit" Text="0.0" runat="server" CssClass="span3" Width="60px"></asp:TextBox>
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
                                                <label class="control-label span3">Leave Apply for Next Year </label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_next_year_yes" runat="server" Text="Yes" GroupName="next" Checked="true" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="rd_next_year_no" runat="server" Text="No" GroupName="next" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="control-group" style="display: none">
                                            <div class="controls controls-row">
                                                <label class="control-label span3 ">Leave extension/shorten</label>
                                                <div class="controls span3">
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_modification_yes" runat="server" Checked="True" GroupName="g" Text="Yes" />
                                                    </label>
                                                    <label class="radio inline">
                                                        <asp:RadioButton ID="opt_modification_no" runat="server" CausesValidation="True" GroupName="g" Text="No" />
                                                    </label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnsbmit" runat="server" CssClass="btn btn-info " OnClick="btnsbmit_Click" Text="Submit" ValidationGroup="v" />
                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-info " OnClick="btnreset_Click" Text="Reset" />
                                            <asp:HiddenField ID="hidden_empcode" runat="server" />
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

