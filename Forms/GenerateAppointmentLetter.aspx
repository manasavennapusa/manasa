<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GenerateAppointmentLetter.aspx.cs" Inherits="Forms_GenerateAppointmentLetter" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star {
            color: red;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>
    <script type="text/javascript">
        function MakeReadOnly(elmnt, e) {
            e = e || window.event;
            ch = e.which || e.keyCode;
            if (ch == 13 || ch == 9) {
                event.keyCode = 9;
            }
            else {
                return false;
            }

        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>HR Letters</h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;">Appointment Letter Details</span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <div>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom" width="24%">Candidate ID<span class="star"></span></td>
                                                <td class="frm-rght-clr123 border-bottom" width="26%">
                                                    <asp:TextBox ID="txt_candidate_id" runat="server" CssClass="span10" Width="" Height="31px" MaxLength="1000" placeholder="Max 100 Chars.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>      
                                                    <a href="JavaScript:newPopup1('PickCandidate.aspx?role=13&candidate=<%=txt_candidate_id.Text.ToString() %>');" title="Pick Candidate"><i class="icon-user"></i></a>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_candidate_id"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Candidate ID"
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txt_candidate_id"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Candidate ID"
                                                        ValidationGroup="vn" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt_candidate_id"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Candidate ID"
                                                        ValidationGroup="v1" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                                <td style="width: 54%">
                                                    <asp:Button ID="btngetempdetails" runat="server" CssClass="btn btn-primary" Text="Get Details" title="Get Employee" Style="margin-left: 20px" OnClick="btngetempdetails_Click" ValidationGroup="vn" />
                                                </td>
                                                <td>
                                                    <asp:Label ID="tb_emp_id" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                        <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td colspan="2" width="100%">
                                                    <table style="width: 100%; height: 180px" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="50%" valign="top">
                                                                <asp:UpdatePanel ID="kk" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                              <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Appointment Letter Number<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_appoint_ltr_numbr" runat="server" CssClass="span10" Width="" Height="35px" MaxLength="1000" placeholder="Enter Number.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_appoint_ltr_numbr"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Appointment Letter Number"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">HR Number<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_hr_1" runat="server" CssClass="span5" Width="" Height="35px" MaxLength="5" placeholder="Max 5 Chars.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_hr_1"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter HR First Box Number"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:TextBox ID="txt_hr_2" runat="server" CssClass="span5" Width="" Height="35px" MaxLength="5" placeholder="Max 5 Chars.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_hr_2"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter HR Second Box Number"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Candidate Name<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="TextBox1_name" runat="server" CssClass="span10" Width="" Height="35px" MaxLength="1000" placeholder="Enter Name.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="TextBox1_name"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Employee Name"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Candidate Address<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="tbemployeeaddress" runat="server" CssClass="span10" TextMode="MultiLine" MaxLength="1000" placeholder="Max 1000 Chars.." Style="border: 1px solid #ddd; font-size: 14px"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="tbemployeeaddress"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Employee Address"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Date Of Join<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_join_date" runat="server" CssClass="span10" AutoPostBack="true" DataFormatString="{'dd'-'MMM'-'yyyy'}" placeholder="dd-mmm-yyyy" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                                                    
                                                                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/img/clndr.gif" />
                                                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender4" runat="server" PopupButtonID="Image4" TargetControlID="txt_join_date" Enabled="True"></cc1:CalendarExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_join_date"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Date Of Join"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">CTC<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_ctc" runat="server" CssClass="span10" AutoPostBack="true" placeholder="Enter CTC"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_ctc"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter CTC"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Issued Date<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123" width="52%" style="border-bottom: 1px solid #d5d5d5">
                                                                                    <asp:TextBox ID="tbissueddate" runat="server" CssClass="span10" AutoPostBack="true" placeholder="dd-mmm-yyyy" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>                                                       
                                                                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/img/clndr.gif" placeholder="Select Date" />
                                                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender1" runat="server" PopupButtonID="Image3" TargetControlID="tbissueddate" Enabled="True"></cc1:CalendarExtender>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="tbissueddate"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Issued Date"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                           
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>

                                                            <td valign="top">
                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                    <ContentTemplate>
                                                                        <table><tr><td><br /></td></tr></table>

                                                                        <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                           
                                                                             <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Terminated Service Days<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <%--<asp:TextBox ID="txt_trmnted_service_days" runat="server" CssClass="span10" placeholder="Enter Days"></asp:TextBox>--%>
                                                                                    <asp:DropDownList ID="ddl_trmnted_service_dys" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_trmnted_service_dys_SelectedIndexChanged">
                                                                                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                                                        <asp:ListItem Value="1">30</asp:ListItem>
                                                                                        <asp:ListItem Value="2">45</asp:ListItem>
                                                                                        <asp:ListItem Value="3">60</asp:ListItem>
                                                                                        <asp:ListItem Value="4">90</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddl_trmnted_service_dys" InitialValue="0"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Terminated Service Days"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Sum Not Exceeding Days<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_sum_nt_excding_days" runat="server" CssClass="span10" AutoPostBack="true" placeholder="Enter Days" onkeydown=" return MakeReadOnly(this,event);"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_sum_nt_excding_days"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Sum Not Exceeding Days"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Job Location<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="span10"></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpbranch" InitialValue="0"
                                                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Job Location"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                             <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Department<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:DropDownList ID="drpdepartment" runat="server" CssClass="span10"></asp:DropDownList> 
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="drpdepartment" InitialValue="0"
                                                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Department"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>             
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Designation<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                   <asp:DropDownList ID="drpdesignation" runat="server" CssClass="span10" ></asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="drpdesignation" InitialValue="0"
                                                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Designation"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>             
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Issued By<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="tbIssuedby" runat="server" CssClass="span10" placeholder="Select Issued By" onkeydown=" return MakeReadOnly(this,event);" style="background-color:#eaeaea"></asp:TextBox>      
                                                                            <a href="JavaScript:newPopup1('pickIssuedBy.aspx?role=13&empcode=<%=tbIssuedby.Text.ToString() %>');" title="Pick Issued By"><i class="icon-user"></i></a>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="tbIssuedby"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Issued By"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom" width="48%">Email Id<span class="star"></span></td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                                    <asp:TextBox ID="txt_email" runat="server" CssClass="span10" AutoPostBack="true" placeholder="Enter Email Id"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_email"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email"
                                                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                                        ValidationGroup="v" ToolTip="Invalid Email Id" SetFocusOnError="True" Display="Dynamic"
                                                                                        ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txt_email"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email"
                                                                                        ValidationGroup="v1" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                                                        ValidationGroup="v1" ToolTip="Invalid Email Id" SetFocusOnError="True" Display="Dynamic"
                                                                                        ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>

                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                    </table>
                                                </td>

                                            </tr>
                                        </table>
                                        <br />
                                        <div class="form-actions no-margin">
                                            <div>
                                                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                                                <asp:Button ID="btngenerateletter" runat="server" CssClass="btn btn-primary pull-right" Text="Generate Letter" title="Generate" Style="margin-left: 10px" OnClick="btngenerateletter_Click" ValidationGroup="v" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-primary pull-right" Text="Reset" title="Clear" Style="margin-left: 10px" OnClick="btn_reset_Click" />
                                                <asp:Button ID="btnSend" runat="server" CssClass="btn btn-primary pull-right" Text="Send Mail" Style="margin-left: 10px" OnClick="btnSend_Click" ValidationGroup="v1" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript">
            function ValidateData() {
                var CandidateName = document.getElementById('<%=txt_candidate_id.ClientID %>');
                var appointmentletternumber = document.getElementById('<%=txt_appoint_ltr_numbr.ClientID %>')
                var hr1 = document.getElementById('<%=txt_hr_1.ClientID %>');
                var hr2 = document.getElementById('<%=txt_hr_2.ClientID %>');
                var address = document.getElementById('<%=tbemployeeaddress.ClientID %>');
                var joindate = document.getElementById('<%=txt_join_date.ClientID %>');
                var ctc = document.getElementById('<%=txt_ctc.ClientID %>');
                var issueddate = document.getElementById('<%=tbissueddate.ClientID %>');

                var Terminated_Service_Days = document.getElementById('<%=ddl_trmnted_service_dys.ClientID %>');
                var Sum_Not_Exceeding_Days = document.getElementById('<%=txt_sum_nt_excding_days.ClientID %>');

                var location = document.getElementById('<%=drpbranch.ClientID %>');
                var department = document.getElementById('<%=drpdepartment.ClientID %>');
                var designation = document.getElementById('<%=drpdesignation.ClientID %>');
                var issuedby = document.getElementById('<%=tbIssuedby.ClientID %>');
                var email = document.getElementById('<%=txt_email.ClientID %>');


                if ((IsEmpty(CandidateName))) {
                    CandidateName.focus();
                    alert("Please Select Candidate Name from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(appointmentletternumber))) {
                    appointmentletternumber.focus();
                    alert("Please Enter Appointment Letter Number from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(hr1))) {
                    hr1.focus();
                    alert("Please Enter HR First Box Number from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(hr2))) {
                    hr2.focus();
                    alert("Please Enter HR Second Box Number from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(address))) {
                    address.focus();
                    alert("Please Enter Address from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(joindate))) {
                    joindate.focus();
                    alert("Please Select Date Of Join from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(ctc))) {
                    ctc.focus();
                    alert("Please Enter CTC from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(issueddate))) {
                    issueddate.focus();
                    alert("Please Select Issued Date from Appointment Letter Details Tab");
                    return false;
                }

                if ((IsEmpty(Terminated_Service_Days))) {
                    Terminated_Service_Days.focus();
                    alert("Please Enter Terminated Service Days from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(Sum_Not_Exceeding_Days))) {
                    Sum_Not_Exceeding_Days.focus();
                    alert("Please Enter Sum Not Exceeding Days from Appointment Letter Details Tab");
                    return false;
                }


                if (location.value == 0) {
                    location.focus();
                    alert("Please Select Job Location from Appointment Letter Details Tab");
                    return false;
                }
                if (department.value == 0) {
                    department.focus();
                    alert("Please Select Department from Appointment Letter Details Tab");
                    return false;
                }
                if (designation.value == 0) {
                    designation.focus();
                    alert("Please Select Designation from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(issuedby))) {
                    issuedby.focus();
                    alert("Please Select Issued By from Appointment Letter Details Tab");
                    return false;
                }
                if ((IsEmpty(email))) {
                    email.focus();
                    alert("Please Enter Email from Appointment Letter Details Tab");
                    return false;
                }


                function IsEmpty(aTextField) {
                    if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }

            function ValidateCandidateName() {
                var candidatename = document.getElementById('<%=txt_candidate_id.ClientID %>');

                if ((IsEmpty(candidatename))) {
                    candidatename.focus();
                    alert("Please Select Candidate Name from Appointment Letter Details Tab");
                    return false;
                }
                function IsEmpty(aTextField) {
                    if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
            function ValidateEmail() {
                var email = document.getElementById('<%=txt_email.ClientID %>');

                if ((IsEmpty(candidatename))) {
                    candidatename.focus();
                    alert("Please Enter Email from Confirmation Letter Details Tab");
                    return false;
                }
                function IsEmpty(aTextField) {
                    if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }

        </script>
        <script type="text/javascript">
            function ValidateEmail() {
                var mail = document.getElementById('<%=txt_email.ClientID %>');
                if ((IsEmpty(mail))) {
                    mail.focus();
                    alert("Please Enter Email");
                    return false;
                }

                function IsEmpty(aTextField) {
                    if ((aTextField.value.length == 0) || (aTextField.value == null) || aTextField.value.charAt(0) == ' ') {
                        return true;
                    }
                    else {
                        return false;
                    }
                }
            }
        </script>
        <script type="text/javascript">
            function IsNumeric(eventObj) {

                var keycode;

                if (eventObj.keyCode) //For IE
                    keycode = eventObj.keyCode;
                else if (eventObj.Which)
                    keycode = eventObj.Which;  // For FireFox
                else
                    keycode = eventObj.charCode; // Other Browser

                if (keycode != 8) //if the key is the backspace key
                {
                    if (keycode < 48 || keycode > 57) //if not a number
                        return false; // disable key press
                    else
                        return true; // enable key press
                }
            }

            function isAlpha(keyCode) {
                return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9)
            }

            function isAddress(keyCode) {
                return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9 || keyCode == 13 || keyCode == 51 || keyCode == 50)
            }

            function validateEmail(obj) {
                var x = obj.value;
                if (x != '') {
                    var atpos = x.indexOf("@");
                    var dotpos = x.lastIndexOf(".");
                    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                        obj.focus();
                        alert("Not a valid e-mail address");
                        return false;
                    }
                }
            }

            function capitalizeMe(obj) {
                val = obj.value;
                newVal = '';
                val = val.split(' ');
                for (var c = 0; c < val.length; c++) {
                    newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
                }
                obj.value = newVal.trim();
            }

        </script>
    </form>
</body>
</html>
