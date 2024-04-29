<%@ Page Language="C#" AutoEventWireup="true" CodeFile="today.aspx.cs" Inherits="InformationCenter_today" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
       <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet"/>
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet"/>

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet"/>

        <!-- fullcalendar css -->
        <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
        <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <%-- this will make the asterisk red in color --%>
    <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>
</head>
<link href="../css/blue1.css" rel="stylesheet" />
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>

                <div class="main-container" >
                     <div class="clearfix"></div>
                     <div class="widget">
                          <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Information	
                 
                                        </div>
                                    </div>
                     <div class="widget-body">
                                        <fieldset>
                    <table width="100%" >
                        <tr>
                            <td height="20" valign="top" class="txt02">
                                
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">Employee Name</td>
                                        <td width="31%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_emp_name" runat="server" Text="Label"></asp:Label></td>
                                        <td width="1%" rowspan="7">&nbsp;</td>
                                        <td width="18%" class="frm-lft-clr123">Gender</td>
                                        <td width="31%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_gender" runat="server" Text="Label"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td width="19%" class="frm-lft-clr123">Employee Code </td>
                                        <td width="31%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_emp_code" runat="server" Text="Label"></asp:Label></td>
                                        <td width="18%" class="frm-lft-clr123">Branch</td>
                                        <td width="31%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_branch" runat="server" Text="Label"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td width="19%" class="frm-lft-clr123" style="height: 27px">Department</td>
                                        <td width="31%" class="frm-rght-clr123" style="height: 27px">
                                            <asp:Label ID="lbl_department" runat="server" Text="Label"></asp:Label></td>
                                        <td width="18%" class="frm-lft-clr123" style="height: 27px">D.O.J</td>
                                        <td width="31%" class="frm-rght-clr123" style="height: 27px">
                                            <asp:Label ID="lbl_doj" runat="server" Text="Label"></asp:Label></td>
                                    </tr>

                                    <tr>
                                        <td width="19%" class="frm-lft-clr123 border-bottom">Designation</td>
                                        <td width="31%" class="frm-rght-clr123 border-bottom">
                                            <asp:Label ID="lbl_designation" runat="server" Text="Label"></asp:Label></td>
                                        <td width="18%" class="frm-lft-clr123 border-bottom">Status</td>
                                        <td width="31%" class="frm-rght-clr123 border-bottom">
                                            <asp:Label ID="lbl_emp_status" runat="server" Text="Label"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                    <table cellspacing="0" cellpadding="0" align="center" border="0" width="100%">
                      <%--  <tbody>--%>
                            <tr>
                                <td valign="top" class="blue-brdr-1" colspan="2" width="100%">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">EMPLOYEE SASTISFACTION SURVEY
                                            </td>
                                            <td align="right">
                                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top"></td>
                            </tr>


                            <tr>
                                <td valign="top" width="100%">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" >1.   Overall, how satisfied are you with MACTAY as an employer? (Please circle one number-out of 5)  
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">2.	MACTAY's leadership and planning.
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="border-bottom">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="30%">I have confidence in the leadership of MACTAY</td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                                        </td>


                                                        <td class="frm-lft-clr123" width="30%">There is adequate planning of corporate objectives </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="30%">Management does not play favorites</td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                                        </td>

                                                        <td class="frm-lft-clr123" width="30%">Management does not “say one thing and do another”</td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>


                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px"></td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">3.Corporate Culture  
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="border-bottom">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="30%">Quality is a top priority with MACTAY</td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
                                                        </td>


                                                        <td class="frm-lft-clr123 border-bottom" width="30%">Individual initiative is encouraged at MACTAY  </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="20%">
                                                            <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123"  width="30%"">Nothing at MACTAY keeps me from doing my best every day</td>
                                                        <td class="frm-rght-clr123" width="20%"">
                                                            <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
                                                        </td>


                                                    </tr>


                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px"></td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">4.Communications 
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="border-bottom">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="30%">MACTAY’s corporate communications are frequent enough </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label11" runat="server" Text="Label"></asp:Label>
                                                        </td>


                                                        <td class="frm-lft-clr123 border-bottom" width="30%">I feel I can trust what MACTAY tells me</td>
                                                        <td class="frm-rght-clr123 border-bottom" width="20%">
                                                            <asp:Label ID="Label12" runat="server" Text="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123 " width="30%" >There is adequate communication between departments </td>
                                                        <td class="frm-rght-clr123  " width="20%" >
                                                            <asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
                                                        </td>


                                                    </tr>


                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px"></td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">5.Career Development  
                                            </td>

                                        </tr>
                                        <tr>
                                            <td class="border-bottom">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="30%">I have a clearly established career path at MACTAY</td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>

                                                        </td>


                                                        <td class="frm-lft-clr123" width="30%">I have opportunities to learn and grow </td>
                                                        <td class="frm-rght-clr123" width="20%">
                                                            <asp:Label ID="Label15" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>


                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5px"></td>
                                        </tr>



                                        <tr>
                                            <td height="20px"></td>
                                        </tr>

                                        <tr>
                                            <td valign="top" colspan="4">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123">
                                                            <b>If you have been here at least six months, please respond to these Performance appraisal items</b>

                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">My last performance appraisal accurately reflected my performance</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label16" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">The performance appraisal system is fair</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>


                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">6. Your Role  
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I am given enough authority to make decisions I need to make</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label18" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123 border-bottom" width="30%">I feel I am contributing to MACTAY’s mission</td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="20%">
                                                                        <asp:Label ID="Label19" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I have the materials and equipment I need to do my job well </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label20" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                </tr>


                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">7. Recognition and Rewards
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">If I do good work I can count on making more money</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label21" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">If I do good work I can count on being promoted</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label22" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I feel I am valued at MACTAY</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label23" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123  border-bottom" width="30%">MACTAY gives enough recognition for work that's well done </td>
                                                                    <td class="frm-rght-clr123  border-bottom" width="20%">
                                                                        <asp:Label ID="Label24" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">My salary is fair for my responsibilities</td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="Label25" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                </tr>


                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">8. Teamwork and Cooperation
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I feel part of a team working toward a shared goal  </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label26" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">"Politics" at this company are kept to a minimum </td>
                                                                    <td class="frm-rght-clr123" width="30%">
                                                                        <asp:Label ID="Label27" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>



                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">9.Working Conditions   
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom" width="">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I believe my job is secure</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label28" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">My physical working conditions are good </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label29" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">Deadlines at MACTAY are realistic </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label30" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">My workload is reasonable</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">I can keep a reasonable balance between work and personal life</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label32" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>

                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">10.	Your Immediate Supervisor 
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">My supervisor treats me fairly</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label33" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">My supervisor treats me with respect</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label34" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">My supervisor handles my work-related issues satisfactorily</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label35" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">My supervisor asks me for my input to help make decisions </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label36" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">My supervisor is an effective manager</td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label37" runat="server" Text="Label"></asp:Label>

                                                                    </td>




                                                                </tr>

                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">11.	MACTAY's Training Program 
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="border-bottom">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="30%">MACTAY provided as much initial training as I needed </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label38" runat="server" Text="Label"></asp:Label>

                                                                    </td>


                                                                    <td class="frm-lft-clr123" width="30%">MACTAY provides as much ongoing training as I need </td>
                                                                    <td class="frm-rght-clr123" width="20%">
                                                                        <asp:Label ID="Label39" runat="server" Text="Label"></asp:Label>

                                                                    </td>
                                                                </tr>



                                                            </table>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">12.	How long do you plan to continue your career with MACTAY?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label40" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">13.	Would you recommend employment at MACTAY to a friend?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label41" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">14. What I like best about working in MACTAY?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label42" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">15. Things that MACTAY should do to make it a better workplace?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label43" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">16. What I like best about working in my Department?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label44" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="frm-lft-clr123">17. Things that my Department should do to make it a better place to work?
                                                        </td>

                                                    </tr>
                                                    <tr>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="Label45" runat="server" Text="Label"></asp:Label>

                                                        </td>
                                                    </tr>
                                                </table>
                                    </table>
                                </td>
                            </tr>
                        </td>
                            </tr>
                        </tr>
                    </table>
                    </td>
            </table>

  </fieldset>
                </div>
                    </div>
                     </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

