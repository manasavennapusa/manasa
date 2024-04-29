<%@ Page Language="C#" AutoEventWireup="true" CodeFile="printemp.aspx.cs" Inherits="admin_printemp" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <style type="text/css">
        .frm-lft-clr123
        {
            font-size: 9px;
            padding: 6px;
        }

        .frm-rght-clr123
        {
            font-size: 10px;
        }

        body
        {
            line-height: 6px;
        }

        .table th
        {
            font: bold 11px verdana, Helvetica, sans-serif;
            font-size: 9px;
            color: #4d4d4d;
            padding: 5px;
        }

        .table td
        {
            padding: 5px;
        }

        span
        {
            color: #4d4d4d;
        }

        .table td span
        {
            font-size: 10px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:Panel ID="panlprint" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container" style="border-top: 0px;">

                    <div class="row-fluid">
                        <div class="span8">
                            <div>
                                <img src="../upload/logo/client_logo.png" style="width: 184px;" />
                                &nbsp;&nbsp;&nbsp;
                                <%--<asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click1" style="float: right;"/>--%>
                                <%-- <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="javascript:window.print();" />--%>
                                <table style="float: right; width: 20%" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="frm-rght-clr123 border-bottom">
                                            <asp:Image ID="empimg" runat="server" ImageUrl="Upload/photo/image.jpg" Style="width: 100%"></asp:Image>
                                            <br />

                                        </td>
                                        <td style="padding: 10px 10px 10px 30px" valign="top">
                                            <input type="button" id="btnprint" runat="server" value="Print" onclick="hide(); return false;" style="float: right;" />
                                        </td>
                                    </tr>
                                </table>
                            </div>


                            <div class="widget-body">

                                <div>
                                    <!-- Job Details -->

                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">Employee Information :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Title
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="lblSalutation" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Employee Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Gender
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr id="Tr1" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123">Middle Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtmiddlename" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr id="Tr2" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123 border-bottom">Last Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="40%" class="frm-lft-clr123 ">Employee Code
                                                                    </td>
                                                                    <td width="40%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Employee No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>


                                                                <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10" colspan="2">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">Work Information :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                <tr runat="server" visible="false">
                                                                    <td class="frm-lft-clr123"><%--Broad Group--%>Business Unit
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_broadgroup" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="">
                                                                    <td width="40%" class="frm-lft-clr123"><%--Branch Name--%>Work Location
                                                                    </td>
                                                                    <td width="40%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_branch_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr style="height: 36px;">
                                                                    <td class="frm-lft-clr123">Department Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_dept_type" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr style="">
                                                                    <td class="frm-lft-clr123">Department
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr style="">
                                                                    <td class="frm-lft-clr123">Designation
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_desigination" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <%--</tr>--%>
                                                                <tr id="Tr3" style="" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123">Grade Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_gradetype" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">Sub Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_subgroup" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>

                                                                <%--<tr>
                                                                            <td class="frm-lft-clr123">Entity
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_entity" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>


                                                                <tr>
                                                                    <td width="48%" class="frm-lft-clr123">Employee Role
                                                                    </td>
                                                                    <td width="52%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>


                                                                <tr style="">
                                                                    <td class="frm-lft-clr123 border-bottom">Employee Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>


                                                                <tr id="tr4" runat="server" visible="False">
                                                                    <td colspan="2" style="height: 5px"></td>
                                                                </tr>
                                                                <tr id="trprobationperiod" runat="server" visible="False" style="">
                                                                    <td class="frm-lft-clr123" style="border-top: none;">Probation Period (in months)
                                                                    </td>
                                                                    <td id="Td1" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                        <asp:Label ID="txt_probationperiod" runat="server" MaxLength="2"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr id="trduptstart" runat="server" visible="False" style="">
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Deputation Start Date
                                                                    </td>
                                                                    <td id="Td4" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                        <asp:Label ID="txt_deput_start_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr id="tr5" runat="server" visible="False">
                                                                    <td colspan="2" style="height: 5px"></td>
                                                                </tr>
                                                                <tr id="trconforimdate" runat="server" visible="False" style="">
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        <asp:Label ID="lblprob" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_confirmationdate" runat="server" Width="120px"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <%--<tr>
                                                                            <td colspan="2" height="5"></td>
                                                                        </tr>--%>
                                                                <tr id="trDOL" runat="server" visible="False" style="">
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Date of Leaving
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                        <asp:Label ID="txtdol" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr id="trReasonL" runat="server" visible="False" style="">
                                                                    <td class="frm-lft-clr123 border-bottom" style="border-top: none;">Reason for Leaving
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" style="border-top: none;">
                                                                        <asp:Label ID="txtreason" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">EXT Number </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="Label3" runat="server"></asp:Label>
                                                                        &nbsp; </td>
                                                                </tr>

                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Date of Joining
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="doj" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr id="Tr6" style="" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123">Salary Calculation From
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtsalary" runat="server" Width="100px"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 ">Official Mobile No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtoff_mobileno" runat="server" MaxLength="10"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Official Email Id
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_officialemail" runat="server" MaxLength="50"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 36px;">
                                                                    <td class="frm-lft-clr123">Employee Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txremployee_type" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr style="height: 36px;">
                                                                    <td class="frm-lft-clr123">Sub Employee Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtsubemployeetype" runat="server" Width="142px" MaxLength="50"></asp:Label>
                                                                    </td>
                                                                </tr>


                                                                <tr runat="server" visible="false">
                                                                    <td class="frm-lft-clr123" width="48%"><%--Sub Department--%>Cost Center
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lbl_division_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" visible="false">
                                                                    <td class="frm-lft-clr123 border-bottom">Grade
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr runat="server" visible="false">
                                                                    <td class="frm-lft-clr123 border-bottom">Notice Period
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_notice" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>


                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom">Group Mobile CPN No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtext" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>


                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123"><%--Immediate Supervisor Name--%>Reporting Manager
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_supervisor" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 "><%--Corporate Reporting Name--%>Functional Manager
                                                                    </td>
                                                                    <td class="frm-rght-clr123 ">
                                                                        <asp:Label ID="lbl_corp_report_name" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom"><%--Manager Name --%>Unit Head
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_hod" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>




                                                                <%--<tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Salary Calculation From
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:Label ID="txtsalary" runat="server"></asp:Label>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" height="5">
                                                                        </td>
                                                                    </tr>--%>

                                                                <tr id="trprobationdate" runat="server" visible="False" style="">
                                                                    <td id="Td5" class="frm-lft-clr123" runat="server" style="border-top: none;">Notice Period During Probation (in days)
                                                                    </td>
                                                                    <td id="Td6" class="frm-rght-clr123" runat="server" style="border-top: none;">
                                                                        <asp:Label ID="txt_probation_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr id="trduptenddate" runat="server" visible="False" style="">
                                                                    <td id="Td7" class="frm-lft-clr123 border-bottom" runat="server" style="border-top: none;">Deputation End Date
                                                                    </td>
                                                                    <td id="Td8" class="frm-rght-clr123 border-bottom" runat="server" style="border-top: none;">
                                                                        <asp:Label ID="txt_deput_end_date" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr id="trnoticepriod2" runat="server" style="">
                                                                    <td class="frm-lft-clr123 border-bottom">Notice Period
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_noticePeriod" runat="server" MaxLength="2"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr id="tab1" runat="server" visible="false">
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="2" class="txt02">Cost Center
                                                                    </td>
                                                                </tr>
                                                                <%-- <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>--%>
                                                                <tr id="trcc1" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="lbl_cc_groupid" runat="server">
                                                                        </asp:Label>

                                                                    </td>
                                                                </tr>

                                                                <tr id="trcc2" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_cc_code" runat="server">
                                                                        </asp:Label>

                                                                    </td>
                                                                </tr>

                                                                <tr id="trcc" runat="server" visible="false">
                                                                    <td colspan="2">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="52%" style="border-top: none;">
                                                                                    <asp:Label ID="lbl_cc_country" runat="server" Height="20px">
                                                                                    </asp:Label>

                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123">State
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_cc_state" runat="server" Height="20px">
                                                                                    </asp:Label>

                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123">City
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_cc_city" runat="server" Height="20px">
                                                                                    </asp:Label>

                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Location
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Label ID="lbl_cc_location" runat="server"
                                                                                        Width="147px">
                                                                                    </asp:Label>

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2" height="5"></td>
                                                                            </tr>
                                                                        </table>

                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" cellspacing="0" cellpadding="0" align="right" runat="server" visible="false">
                                                                <tr>
                                                                    <td colspan="2" class="txt02">Additional Cost Center
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Cost Center Group
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="51%">
                                                                        <asp:Label ID="lbl_acc_groupid" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Cost Center Code
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_acc_code" runat="server">
                                                                        </asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr id="traddcc" runat="server" visible="false">
                                                                    <td colspan="2">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" width="48%" style="border-top: none;">Country
                                                                                </td>
                                                                                <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                                                                                    <asp:Label ID="lbl_acc_country" runat="server" Height="20px">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123">State
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_acc_state" runat="server" Height="20px">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123">City
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:Label ID="lbl_acc_city" runat="server" Height="20px">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Location
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:Label ID="lbl_acc_location" runat="server" Height="20px">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <%--  <tr >
                                        <td colspan="2" class="txt02">Payroll Details
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" runat="server">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td colspan="2" class="txt02">Payroll Details
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">CTC Per Annum
                                                                    </td>
                                                                    <td class="frm-rght-clr123  border-bottom" width="52%">
                                                                        <asp:Label ID="ward" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">PF Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lblpf" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <%-- <tr runat="server" visible="false">
                                                                    <td width="43%" class="frm-lft-clr123">ESI Dispensary
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="pfno" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>--%>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">PAN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="panno" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">UAN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="uanno" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td height="5" colspan="2"></td>
                                                                </tr>

                                                                <tr id="sss" runat="server" visible="false">
                                                                    <td class="frm-lft-clr123">PT No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_ptno" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                        <td width="50%" valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td style="height: 12px"></td>
                                                                </tr>
                                                                <tr id="Tr19" runat="server">
                                                                    <td width="43%" class="frm-lft-clr123">ESI Dispensary
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">PF Region Office</td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                        &nbsp; </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="esino" runat="server"></asp:Label>
                                                                        &nbsp; </td>
                                                                </tr>
                                                                <%--  <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">ESI Number </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="esino" runat="server"></asp:Label>
                                                                        &nbsp; </td>
                                                                </tr>--%>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>

                                </div>

                                <div runat="server" visible="true">
                                    <!-- Approver Details -->
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">

                                        <tr>
                                            <td colspan="2" class="txt02" style="height: 25px">Approver's Information :
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2" width="100%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Line Manager
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="txtreportmanager" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Dotted Line Manager
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="txtdottedlinemanager" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">Business Head
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="txtbusinesshead" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Finance Manager
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="txtfncmang" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Network Administration Clearance
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="txtnetworkclr" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                 <tr style="">
                                                                            <td class="frm-lft-clr123 border-bottom" width="40%">Virtual Head
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                <asp:Label ID="txtdeptclr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                            </table>
                                                        </td>
                                                        <td width="50%" valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123 " width="48%">Admin
                                                                    </td>
                                                                    <td class="frm-rght-clr123 " width="52%">
                                                                        <asp:Label ID="txtadmin" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">HR 
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="txthr" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">HR-C&B 
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="txthrcb" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="48%">HRD 
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="52%">
                                                                        <asp:Label ID="txthrd" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="48%">Management/MD
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="52%">
                                                                        <asp:Label ID="txtmng" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>

                                        <tr runat="server" visible="false">
                                            <td colspan="2" class="txt02">Clearance Information :
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td colspan="2" width="100%">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                                                <ContentTemplate>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                       

                                                                        <tr style="">
                                                                            <td class="frm-lft-clr123">General Administration Clearance
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtadminclr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>
                                                                        <tr style="">
                                                                            <td class="frm-lft-clr123 border-bottom">Accounts Department Clearance
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txtaccdeptclr" runat="server"></asp:Label>

                                                                            </td>
                                                                        </tr>


                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr style="">
                                                                    <td class="frm-lft-clr123" width="40%">Network Administration Clearance
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="txtnetworkclr1" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>

                                                                <tr style="">
                                                                    <td class="frm-lft-clr123 border-bottom">User Account Deletion Request
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtaccdeleclr" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="10" colspan="2"></td>
                                        </tr>

                                    </table>

                                </div>
                                <div>
                                    <!-- Contact Details -->
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <div>
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td height="5"></td>
                                                                                <td class="txt02"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txt02" align="left" style="width: 49%">Present Address :
                                                                                </td>
                                                                                <td class="txt02" align="left">&nbsp;&nbsp;&nbsp;&nbsp;Permanent Address :
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txt02">&nbsp;
                                                                                </td>
                                                                                <td class="txt02">&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="40%">Address 
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                                <span id="txt_pre_add1" runat="server" style="line-height: 15px;"></span>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr7" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Address 2
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <span id="txt_pre_add2" runat="server" style="line-height: 15px;"></span>&nbsp;                                                                    
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr8" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr9" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr10" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr11" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr12" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>


                                                                                        <tr>
                                                                                            <td colspan="2" height="5"></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="40%">Address 
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                                <span id="txt_per_add1" runat="server" style="line-height: 15px;"></span>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr13" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Address 2
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <span id="txt_per_add2" runat="server" style="line-height: 15px;"></span>&nbsp;                                                                                           
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr14" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr15" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr16" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr17" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>

                                                                                        <tr id="Tr18" runat="server" visible="false">
                                                                                            <td class="frm-lft-clr123">Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>



                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="txt02">Emergency Contact Details:
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td height="10"></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <div class="widget-body">
                                                                                                    <div id="dt_example" class="example_alt_pagination">
                                                                                                        <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                                                            AutoGenerateColumns="False" AllowSorting="True" Style="border-top: 1px solid #e0e0e0"
                                                                                                            CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">

                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Name">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="15%"></HeaderStyle>
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Relation">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left" Width="10%"></HeaderStyle>
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Contact No. ">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Residential Address">
                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                                    <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>
                                                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="40%">Mode of Transport
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                                <asp:Label ID="lblmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5"></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="40%">Pick Up Point
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                                <asp:Label ID="txtmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                                <div>
                                    <!-- Professional Details -->
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">Educational Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True"
                                                                            CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Location of Institute ">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Specialization">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <%--     <asp:TemplateField HeaderText="Grade / %">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                            </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Year of Graduation">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label><%--&nbsp;-&nbsp;<asp:Label
                                                                                        ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">Professional / Technical Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                            HorizontalAlign="Left" CellPadding="4" BorderWidth="0px">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education" HeaderStyle-Width="21%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Specialization" HeaderStyle-Width="21%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Institute / University Name" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Grade / %" HeaderStyle-Width="13%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year" HeaderStyle-Width="13%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">Experience Details :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_exp" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" EmptyDataText="No Data found"
                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Employer" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Employer’s address" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%--<asp:TemplateField HeaderText="Business Type" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labeldes" runat="Server" Text='<%# Eval("bussiness_type") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Employment date" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>

                                                                                        <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Exit date" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:TemplateField HeaderText="Department" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("departmenet") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                <%-- <asp:TemplateField HeaderText="Position starting" HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("postion_starting") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                <%-- <asp:TemplateField HeaderText="Position on exit" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("postion_end") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                                <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Experience" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("totalexperience") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <%-- <asp:TemplateField HeaderText="Salary on exit" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("salary_end") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>--%>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="txt02">Training Details :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="GridTraning" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="trainingname"
                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblTraning" runat="Server" Text='<%# Eval("trainingname")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Conducted By" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblConductedBy" runat="Server" Text='<%# Eval("personname")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="From" HeaderStyle-Width="16%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("fromdate")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="To" HeaderStyle-Width="16%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbltodate" runat="Server" Text='<%# Eval("todate")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <%--   <tr>
                                        <td class="txt02">Visa Details :
                                        </td>
                                    </tr>--%>

                                        <%--  <%-- <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>--%>
                                        <%-- <tr>
                                        <td class="txt02">Insurance Details :
                                        </td>
                                    </tr>--%>
                                        <tr style="display: none">
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="GridInsurance"
                                                                            runat="server"
                                                                            Width="100%"
                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False"
                                                                            AllowSorting="True"
                                                                            CaptionAlign="Left"
                                                                            DataKeyNames="Id"
                                                                            HorizontalAlign="Left"
                                                                            CellPadding="4">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Id" HeaderStyle-Width="18%" Visible="false">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblId" runat="Server" Text='<%# Eval("Id")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Insurance Number" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInsuranceNumber" runat="Server" Text='<%# Eval("InsuranceNumber")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Insurance Issue Date" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInsuranceIssueDate" runat="Server" Text='<%# Eval("InsuranceIssueDate")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Insurance Expiry Date" HeaderStyle-Width="16%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblInsuranceExpiryDate" runat="Server" Text='<%# Eval("InsuranceExpiryDate")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>

                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>--%>
                                    </table>

                                </div>
                                <div>
                                    <!-- Personal Details -->
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td colspan="2" height="5"></td>
                                        </tr>
                                        <tr>
                                            <td class="txt02" colspan="2">Personal Information :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Date of Birth
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="txt_DOB" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Payment Mode
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lblpaymentmode" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                        <td align="left" class="frm-lft-clr123" width="40%">Bank Name for Salary
                                                                        </td>
                                                                        <td align="left" class="frm-rght-clr123" width="40%">
                                                                            <asp:Label ID="txt_bank_name" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>


                                                                    <tr>
                                                                        <td align="left" class="frm-lft-clr123 border-bottom">Bank Branch Name
                                                                        </td>
                                                                        <td align="left" class="frm-rght-clr123 border-bottom">
                                                                            <asp:Label ID="txt_bankbrachname" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                 <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Mobile No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="txtmobileno" runat="server" MaxLength="10"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">LandLine No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="land" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Passport No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_passportno" runat="server" MaxLength="50"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123 ">Passport Expiry Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123 ">
                                                                        <asp:Label ID="txt_passportexpdate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Passport Issued Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_passportissueddate" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="0" cellpadding="0" width="99%" border="0" align="right">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Religion
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="txtrelg" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 ">Blood Group
                                                                    </td>
                                                                    <td class="frm-rght-clr123 ">
                                                                        <asp:Label ID="txtbloodgrp" runat="server" MaxLength="50"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 37px; display: none">
                                                                    <td class="frm-lft-clr123">D.L. No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_dl_no" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                        <td align="left" class="frm-lft-clr123" width="40%">Account No. for Salary
                                                                        </td>
                                                                        <td align="left" class="frm-rght-clr123" width="40%">
                                                                            <asp:Label ID="txt_bank_ac" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <td align="left" class="frm-lft-clr123">IFSC code</td>
                                                                        <td align="left" class="frm-rght-clr123">
                                                                            <asp:Label ID="txt_ifsc" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123 ">Personal Email Id
                                                                        </td>
                                                                        <td class="frm-rght-clr123 ">
                                                                            <asp:Label ID="txt_email" runat="server" MaxLength="50"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                     <tr>
                                                                    <td class="frm-lft-clr123" width="40%">Driving Licence No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="40%">
                                                                        <asp:Label ID="txt_drli_no" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Driving Licence Issued Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_dr_iss_date" runat="server">

                                                                        </asp:Label>

                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Driving Licence Expiry Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txt_dr_exp_date" runat="server"></asp:Label>

                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                <div id="paymentmode" runat="server" visible="true" align="center">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="50%" style="display:none">
                                                                <table cellspacing="0" cellpadding="0" width="100%" align="right" border="0">

                                                                    
                                                                    <tr style="display: none">
                                                                        <td align="left" class="frm-lft-clr123">Salary Type
                                                                        </td>
                                                                        <td align="left" class="frm-rght-clr123">
                                                                            <asp:Label ID="lblSalaryType" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                </table>
                                                            </td>
                                                            
                                                        </tr>

                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" colspan="2">
                                                <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                               
                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom" style="display: none">Residential City/State
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_Tshirt" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td align="left" class="frm-lft-clr123">Bank Region
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="lblBankRegion" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">


                                                                


                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom" style="display: none">City
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_ShirtSize" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>

                                                                <tr style="display: none">
                                                                    <td align="left" class="frm-lft-clr123">Amount (OMR)<span class=""></span>
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="lblBasicSalary" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom">Shoes Size
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_ShoesSize" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5"></td>
                                        </tr>
                                        <%--  <tr>
                                        <td class="txt02">Guarantor Details :
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#d9d9d9" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td>
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_gurn" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="name"
                                                                            HorizontalAlign="Left" CellPadding="4" EmptyDataText="No Data Found">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Name" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Residential Address" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelgender" runat="Server" Text='<%# Eval("Res_address") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Phone Number" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labephone" runat="Server" Text='<%# Eval("Phone_Num") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Name of Company/Employer" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelcompany" runat="Server" Text='<%# Eval("emp_company") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Relationship with staff" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelrel" runat="Server" Text='<%# Eval("Relation_staff") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Company/Employer’s address" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelcomadrs" runat="Server" Text='<%# Eval("emp_comp_adrs") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="txt02" colspan="2" height="5">Relationship Details :
                                            </td>
                                        </tr>

                                        <tr>
                                            <td colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top" width="50%">
                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="40%">Father/Husband Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                        <asp:Label ID="txt_f_f_name" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td class="frm-lft-clr123 border-bottom" width="40%" style="display: none">Dependant date of birth
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                        <asp:Label ID="lbl_dep_dob" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                                <tr style="display: none">
                                                                    <td class="txt02" colspan="2" height="5">Employee Marital Status :
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" width="40%">Mother Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                        <asp:Label ID="txt_m_fname" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2" height="5"></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                               
                                                <tr>
                                                    <td class="txt02" colspan="2" height="5">Employee Marital Status :
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <%--<table cellspacing="0" cellpadding="0" width="100%" border="0">--%>
                                                                    <tr>
                                                                        <td class="frm-lft-clr123 border-bottom">Marital Status
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                            <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                        </td>
                                                                    </tr>


                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 12px" colspan="2"></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td>
                                                                                <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                                    visible="false">
                                                                                    <tr>
                                                                                        <td colspan="2">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td valign="top" width="50%">
                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                            <tr>
                                                                                                                <td class="txt02" colspan="2">Spouse Name:
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" height="5"></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123 " width="40%">Name
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 " width="40%">&nbsp;<asp:Label ID="txt_sp_fname" runat="server"></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td width="40%" class="frm-lft-clr123 border-bottom">Date of Anniversary
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                                    <asp:Label ID="txt_doa" runat="server"></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>




                                                                                                        </table>
                                                                                                    </td>

                                                                                                    <td valign="top" width="50%">
                                                                                                        <table cellspacing="0" cellpadding="0" width="100%" align="right" border="0">

                                                                                                            <tr>
                                                                                                                <td class="txt02" colspan="2" height="5">&nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" height="5"></td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123 border-bottom" width="40%">Date of Birth
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                                    <asp:Label ID="txt_sp_dob" runat="server"></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>



                                                                                                            <tr>
                                                                                                                <td class="frm-lft-clr123 border-bottom" width="40%">Gender
                                                                                                                </td>
                                                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                                                    <asp:Label ID="txt_sp_gender" runat="server"></asp:Label>&nbsp;
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td colspan="2" height="5"></td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">Children Detail:
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" align="left" colspan="2">&nbsp;&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2"></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5"></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" colspan="2">
                                                                                            <table style="border-collapse: collapse; border:#d9d9d9" cellspacing="0" cellpadding="4" width="100%" border="1">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <div class="widget-content">
                                                                                                            <asp:GridView ID="grid_child" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                                AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                                                                HorizontalAlign="Left" CellPadding="4">
                                                                                                                <Columns>
                                                                                                                    <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                    <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                                                                                                        <ItemTemplate>
                                                                                                                            <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:TemplateField>
                                                                                                                </Columns>
                                                                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                                            </asp:GridView>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" width="50%"></td>
                                                                                        <td valign="top"></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 14px"></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                    </table>
                                    </td>
                                            </tr>
                                        </table>

                                </div>
                                <div>
                                    <!-- Employee Upload Details -->
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">Upload Documents 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                        <tr style="display: none">
                                            <td class="frm-lft-clr123" width="40%" style="display: none">Employee Photo
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lblphoto" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">10th Standard Pass Certificate
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft1" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">12th Standard Pass Certificate
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Graduation Degree Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft3" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Professional Qualification Certificate/Degree Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft4" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Post Graduation Degree/Diploma/Certification Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft5" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Technical Qualification Degree/Diploma/Certificate Course Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">PAN Card Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft7" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Driving License Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft8" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Passport Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Current Address Proof Copy
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft10" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Permanent Address proof copy (if different than current address/Passport address)
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft11" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Copy of Signed cancelled check/Bank statement for bank details
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft12" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Relieving Letters
                                            </td>
                                            <td class="frm-rght-clr123" width="60%">

                                                <asp:Label ID="lbldft13" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="40%">Other
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="60%">

                                                <asp:Label ID="lbldft14" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="40%">Adhar Card 
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="60%">

                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                    </table>
                                </div>
                                <%--  <div id="Div1" class="controls" runat="server">
                                                        <asp:CheckBox ID="declareation" runat="server" CssClass="span4" Text="<b>Declaration:</b> I hereby declare that the details furnished above are true and correct to the best of my knowledge and belief and I undertake to inform you of any changes therein, immediately" />                      
                                                    </div>--%>
                                <%-- </div>--%>
                            </div>

                        </div>
                    </div>
                    <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
                </div>
            </div>
        </asp:Panel>
    </form>

    <script type="text/javascript">
        function hide() {
            var x = document.getElementById('btnprint');
            x.style.display = 'none';
            window.print();
            x.style.display = 'block';

        }

    </script>
</body>
</html>


