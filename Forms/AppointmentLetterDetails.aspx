<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppointmentLetterDetails.aspx.cs" Inherits="Forms_AppointmentLetterDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>Appointment Letter</title>

    <script src="../js/html5-trunk.js"></script>
   
    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
                .btn {
    display: inline-block;
    *display: inline;
    /* IE7 inline-block hack */
    *zoom: 1;
    padding: 4px 12px;
    margin-bottom: 0;
    font-size: 14px;
    line-height: 20px;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    color: #333333;
    text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
    background-color: #e6e6e6;
    /* Fallback Color */
    background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#e6e6e6));
    /* Saf4+, Chrome */
    background-image: -webkit-linear-gradient(top, white, #e6e6e6);
    /* Chrome 10+, Saf5.1+, iOS 5+ */
    background-image: -moz-linear-gradient(top, white, #e6e6e6);
    /* FF3.6 */
    background-image: -ms-linear-gradient(top, white, #e6e6e6);
    /* IE10 */
    background-image: -o-linear-gradient(top, white, #e6e6e6);
    /* Opera 11.10+ */
    background-image: linear-gradient(top, white, #e6e6e6);
    background-repeat: repeat-x;
    border-color: #f0f0f0 #f0f0f0 #e6e6e6;
    border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
    border: 1px solid #f0f0f0;
    *border: 0;
    border-bottom-color: #e6e6e6;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    border-radius: 2px;
    *margin-left: .3em;
    -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
    -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
    box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
}
        .btn-info {
    color: white;
    text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
    background-color: #337ead;
    /* Fallback Color */
    background-image: -webkit-gradient(linear, left top, left bottom, from(#4a98c9), to(#337ead));
    /* Saf4+, Chrome */
    background-image: -webkit-linear-gradient(top, #4a98c9, #337ead);
    /* Chrome 10+, Saf5.1+, iOS 5+ */
    background-image: -moz-linear-gradient(top, #4a98c9, #337ead);
    /* FF3.6 */
    background-image: -ms-linear-gradient(top, #4a98c9, #337ead);
    /* IE10 */
    background-image: -o-linear-gradient(top, #4a98c9, #337ead);
    /* Opera 11.10+ */
    background-image: linear-gradient(top, #4a98c9, #337ead);
    border-color: #4a98c9 #4a98c9 #337ead;
    border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
}
        .gridviewrow 
        {
            border-bottom:none;
        }   
    </style>
    <script type="text/ecmascript">
        function hide() {
            var x = document.getElementById('btn_print');
            x.style.display = 'none';
            var y = document.getElementById('div_letter');
            y.style.display = 'block';
            var z = document.getElementById('btn_back');
            z.style.display = 'none';
            var q = document.getElementById('btn_export');
            q.style.display = 'none';
        }
        function show() {
            var y = document.getElementById('div_letter');

            y.style.display = 'block';
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>--%>
        <div class="" style="margin-left: 0px; padding: 10px 0px 10px 0px; background-color: white; border-color: #1b478e">
            <div class="main-container" id="div_letter" runat="server">
                <div>
                    <table id="tbl_btn" runat="server" style="width: 90%;">
                        <tr>
                            <td style="width: 30%">
                                <asp:Image ID="img_logo" runat="server" ImageUrl="~/images/Escalon_logo.png" Width="150px" Style="padding-left: 210px" />
                            </td>
                            <td style="width: 70%; text-align: center">
                                <asp:Button ID="btn_back" runat="server" class="btn btn-info pull-right" Text="Back" title="Go Back" Style="margin-left: 10px" OnClick="btn_back_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btn_print" runat="server" OnClientClick="hide(); window.print();" Text="Print" title="print" CssClass="btn btn-info" />&nbsp;&nbsp;
                                <asp:Button ID="btn_export" runat="server" Text="Export To Word" title="Export to Word" OnClick="btn_export_Click" CssClass="btn btn-info" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </div>

                <div>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 14px; font-weight: 800; width: 20%;text-decoration:underline">Letter Of Appointment
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                       
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 14px; font-weight: 800;">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 50%">HR&nbsp;/&nbsp;<asp:Label ID="txt_HR_1" runat="server" Style="border: none;padding: 0px 0px 4px 3px; font: bold; font-size: 12px; font-weight: 600;"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_HR_2" runat="server" Style="border: none;padding: 0px 0px 4px 1px; font-size: 12px; font-weight: 600;"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_appointment_letter" runat="server" Style="border: none;padding: 0px 0px 4px 3px; font-size: 12px; font-weight: 600;" placeholder="Enter offer letter"></asp:Label>
                                        </td>
                                        <td style="width: 50%; text-align: right">Date:
                                            <asp:Label ID="txt_date" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="">
                                <asp:Label ID="txt_address" runat="server" Style="border: none; text-decoration: underline; padding: 0px 0px 4px 3px;" placeholder="Enter offer letter"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td class="auto-style1">Mr.<asp:Label ID="txt_emp_name" runat="server" Style="border: none;padding: 0px 0px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 13px; font-weight: 600">
                                <asp:Label ID="txt_address" runat="server" Style="border: none;padding: 0px 0px 3px 0px" Width="170px"></asp:Label>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 14px; font-weight: 500;">Subject&nbsp;&nbsp;:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Appointment Letter
                            </td>
                        </tr>
                    </table>
                </div>

                <div>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 14px; font-weight: 800; width: 20%">Dear
                                <b><asp:Label ID="txt_employee_name" runat="server" Style="border: none;padding: 0px 0px 3px 3px; font-size: 14px"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Congratulations! We are pleased to inform you that you have been appointed as<asp:Label ID="txt_desg" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label><b>with Escalon Business Services Pvt. Ltd</b>. on the following terms and conditions.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Designation:</b> You have been designated as
                                <asp:Label ID="txt_desg_1" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>. However, your ability and expertise can be utilized in any other field/function in the best interest of the company and there upon you shall be re-designated/promoted accordingly.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Date of Joining:</b> You have joined us on
                                <asp:Label ID="txt_doj" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>
                                and this would be considered as your effective Date of Joining in the company. You will be on probation for first six months. Completion of probation period will automatically confirm your regular employment with Escalon; any other condition will be informed.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Salary:</b> Your annual cost to company be
                                <asp:Label ID="txt_ctc" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>. Your salary is confidential and should not be disclosed or discussed to any other employee of the organization. In case of disclosure strict actions would be taken.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Notice Period:</b> Either party may terminate this contract of employment by giving a written notice of&nbsp;<asp:Label ID="lbl_year" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>&nbsp;calendar days without assigning any reasons after confirmation. Before that probation clause will be applicable as per offer letter issued earlier.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Other terms & Conditions-</b> You will be on probation for first six months.The other terms and conditions of the employment have been shared in attached format. 

                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>

                        <tr>
                            <td>We hope to have a long successful professional relationshipwith you and wish you all the very best.                             </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>For <b>Escalon Business Services Pvt Ltd </b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Brush Script MT; font-size: 20px">Ritu Chitra 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Ritu Chitra 
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 14px; font-weight: 700;">HR Manager
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 13px;">Authorized Signatory
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">
                                Page-1
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br /><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-decoration: underline; font: bold; font-size: 16px; font-weight: 600;">Important points:
                            </td>
                        </tr>
                        <tr><td><br /></td></tr>
                        <tr>
                            <td>1.	This offer of appointment is valid only till the date of joining you have accepted and committed as above and it will automatically cease in the event of your not joining us by the said date. ( same as above) 
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>2.	The Employee is liable to be transferred from one job to another job or from one department to another department or from one shift to another or from one establishment to another establishment if required by the Management. Any such changes in assignment or transfer will not automatically entitled to any additional remuneration, allowance, compensation, or other sum in respect thereof.
                            </td>
                        </tr>
                        <tr>
                            <td>3.	<b>Company Property:</b> The Employee will always maintain in good condition company property, which may be entrusted for official use during the term of the agreement and shall return all such property to the company prior to relinquishment of the charge, failing which the damages of the same will be recovered from the employee by the company. 
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>4.	<b>Leave Policy:</b> The Employee is entitled to leave as per leave policy of the company. This will be provided at the time of joining.
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>5.	<b>Non-Discloser Of Information:</b> The Employee understands and agree that he shall not, at any time during the continuance or for a period of five years after the termination of the employment here under, divulge either directly or indirectly to any person, firm or Company or use for himself or for another any knowledge, information, end-customer information (names, personal or financial information), formulae, processes, methods, compositions, ideas or documents, concerning the business and affairs of the company or any of its dealings, transactions or affairs which the employee may acquire from the company or any of its dealings, transactions or affairs which he may acquire or have gained knowledge during the course of and incidental to the employment.
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>6.	<b>Termination :</b>
                            </td>
                        </tr>
                        <tr>
                            <td>6.1.	For Separation/Termination the following Terms and Conditions will hold:
                            </td>
                        </tr>
                        <tr>
                            <td>6.1.1.	Either party may terminate the services with
                                <asp:Label ID="txt_terminated_days" runat="server" Style="border: none;padding: 0px 0px 4px 3px;" placeholder="Enter offer letter"></asp:Label>&nbsp;days’ notice without assigning reasons.
                            </td>
                        </tr>
                        <tr>
                            <td>6.1.2.	Notice period is meant to ensure completion of jobs already taken, transfer ongoing jobs, smooth transition and provide for time to get suitable replacement. Failing to fulfill this commitment and purely at the discretion of the employer, for any risk whatsoever, the employee will be required to pay to the employer without demur, and on demand, a sum not exceeding
                                <asp:Label ID="txt_sum_not_exceeding" runat="server" Style="border: none;padding: 0px 2px 4px 3px;" placeholder="Enter offer letter"></asp:Label>&nbsp; days Gross Salary as was being received by the employee at the time of said notice, as compensation. In the same manner, if the employer wants to dispense with the services of the employee, both notice period and compensation clauses apply to employer. 
                            </td>
                        </tr>
                        <tr>
                            <td>6.2.	Notwithstanding anything to the contrary contained herein, the Company shall be entitled to forthwith terminate the appointment without any notice or payment of any kind whatsoever in lieu of notice or otherwise in case of: 
                            </td>
                        </tr>
                        <tr>
                            <td>6.2.1.	Any act of dishonesty, disobedience, insubordination, incivility, intemperance, irregularity in attendance or other misconduct or neglect of duty, or incompetence in the discharge of duty or breach of any of the terms, conditions and stipulations contained herein.
                            </td>
                        </tr>
                        <tr>
                            <td>6.2.2.	On Discovery of any intentional and willful incorrect information provided by the employee to the company in the application for job or during the course of employment.
                            </td>
                        </tr>
                        <tr>
                            <td>6.2.3.	If any declaration given or furnished by the employee to the company in any document submitted for employment proves to be false or if the employee has willfully suppressed any material information, the employee will be liable to be terminated without notice.
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>

                    </table>
                </div>
                <div>
                    <table style="width: 90%; text-align: justify; margin: 0px 5px 10px 15px">
                        <tr>
                            <td style="font-size: 14px;font-weight:600;width:45%;text-align:left">(Employee's Signature)
                            </td>
                            <td style="font-size: 14px;font-weight:600;width:45%;text-align:right">(Employer's Signature)
                            </td>
                        </tr>
                    </table>
                    <table style="width: 90%; text-align: right; margin:5px 5px 10px 15px">
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                       <tr>
                            <td>
                                Page-2
                            </td>
                        </tr>
                    </table>
                </div>
                 
                <table>
                    <tr>
                        <td style="height:70px">
                        </td>
                    </tr>
                </table>
                <div>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="text-decoration: underline; font: bold; font-size: 14px; font-weight: 800; text-align: center;">IT Department Acceptable Use Policy
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>•	Employees are responsible for exercising good judgment regarding the reasonableness of personal use. Individual departments are responsible for creating guidelines concerning personal use of Internet/Intranet/Extranet systems.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>•	For security and network maintenance purposes, authorized individuals within Escalon may monitor equipment, systems and network traffic at any time, per IT Department's Audit Policy. 
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>•	Under no circumstances is an employee of Escalon authorized to engage in any activity that is illegal under local, state, federal or international law while utilizing Escalon-owned resources.
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>• Unauthorized copying of copyrighted material including, but not limited to, digitization and distribution of photographs from magazines, books or other copyrighted sources, copyrighted music, and the installation of any copyrighted software for which Escalon or the end user does not have an active license is strictly prohibited. 
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>• Revealing your account password to others or allowing use of your account by others. This includes family and other household members when work is being done at home.
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>•	Providing information about, or lists of, Escalon employees to parties outside Escalon.
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>•	The official sites and accounts like Skype, Outlook, and Share file, Basecamp or any other are not to be used for personal use. They are strictly to be used for official purpose.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;&nbsp; <b>Enforcement</b>
                            </td>
                        </tr>
                        <tr>
                            <td>Any employee found to have violated this policy may be subject to disciplinary action, up to and including termination of employment. The Company shall be entitled to initiate civil and criminal proceedings relevant under the Indian laws for the time being in force.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </div>
                <table><tr><td><br /></td></tr></table>
                <div>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font-size: 14px;font-weight:600;width:45%;text-align:left">(Employee's Signature)
                            </td>
                            <td style="font-size: 14px;font-weight:600;width:45%;text-align:right">(Employer's Signature)
                            </td>
                        </tr>
                    </table>
                </div>
                <table style="width: 90%; text-align: right; margin: 10px 5px 10px 15px">
                    <tr>
                        <td style="height:220px"></td>
                    </tr>
                    <tr>
                        <td>
                            Page-3
                        </td>
                    </tr>
                </table>
                <div>
                    <table style="width: 90%; text-align: justify; margin: 30px 5px 10px 15px">
                        <tr>
                            <td style="text-decoration: underline; font: bold; font-size: 15px; font-weight: 800; text-align: center;">ANNEXURE TO THE OFFER OF APPOINTMENT
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-decoration: underline">Annexure 1
                            </td>
                        </tr>

                    </table>
                <%--</div>
                <div>--%>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700;">Employee Name :
                                <asp:Label ID="txt_employee_name_1" runat="server" Style="border: none; padding: 0px 3px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700;">Designation :
                                <asp:Label ID="txt_desg_3" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700;">Location :
                                <asp:Label ID="txt_location" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700;">Date Of joining :
                                <asp:Label ID="txt_doj_1" runat="server" Style="border: none;padding: 0px 3px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr id="tr123" runat="server" visible="false">
                            <td style="font: bold; font-size: 13px; font-weight: 700;">Breakup of the monthly salary is given below: 
                            </td>
                        </tr>
                    </table>
               
                 <table><tr><td><br /></td></tr></table>
                <div id="dv_salary_structure" runat="server" visible="false">
                    <div style="width: 90%; *zoom: 1; border: 1px solid rgba(0, 0, 0, 0.10); margin-left: 20px; background-color:#f7f7f7">
                        <div style="width: 100%; *width: 99.94680851063829%;">
                            <div style="background-color: #c4c4c4; background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#f2f2f2)); background-image: -webkit-linear-gradient(top, white, #f2f2f2); background-image: -moz-linear-gradient(top, white, #f2f2f2); background-image: -ms-linear-gradient(top, white, #f2f2f2); background-image: -o-linear-gradient(top, white, #f2f2f2); background-image: linear-gradient(top, white, #f2f2f2); -webkit-border-radius: 3px 3px 0 0; -moz-border-radius: 3px 3px 0 0; border-radius: 3px 3px 0 0; border-bottom: 1px solid #d9d9d9; height: 30px; line-height: 30px; padding: 5px 10px;">
                                <div style="font-weight: 900; font-size: 19px;text-align:center; font: bold;">
                                    <b style="icon:auto">Salary Structure Details</b>
                                </div>
                            </div>
                            <div>
                                <div style="padding: 10px;">

                                    <table style="width: 100%; text-align: justify;padding:5px 5px 5px 5px;">
                                        <tr>
                                            <td>
                                                <table style="width: 100%; border: none" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="width: 50%;padding:5px 5px 5px 5px" valign="top">
                                                            <asp:GridView ID="earning_grid" runat="server"
                                                                CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                                BorderWidth="1px" AllowPaging="False" PageSize="5">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Particulars" ItemStyle-Width="60%">
                                                                        <HeaderStyle BorderStyle="Solid" BorderColor="#cccccc" />
                                                                        <ItemStyle BorderColor="#cccccc" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l11" runat="server" Text='<%# Bind ("payhead_name") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Monthly" ControlStyle-Width="20%">
                                                                        <HeaderStyle BorderStyle="Solid" BorderColor="#cccccc" />
                                                                        <ItemStyle BorderColor="#cccccc" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l12" runat="server" Text='<%# Bind("monthly")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Annual" ControlStyle-Width="20%">
                                                                        <HeaderStyle BorderStyle="Solid" BorderColor="#cccccc" />
                                                                        <ItemStyle BorderColor="#cccccc" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l13" runat="server" Text='<%# Bind("Annual")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                               
                                                            </asp:GridView>
                                                            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False" Visible="false" ShowHeader="false" style="border-right:1px solid rgba(0, 0, 0, 0.2);border-top:0px solid white;font-size:15px;font-weight:700;border-left:1px solid rgba(0, 0, 0, 0.20);border-bottom:1px solid rgba(0, 0, 0, 0.20)" CellPadding="4" >
                                                                <Columns>
                                                                    <asp:TemplateField ItemStyle-Width="60%" ControlStyle-BorderWidth="0" ItemStyle-BorderWidth="0" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Left" >
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l14" runat="server" Text="Total Cash Benefits"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ControlStyle-Width="20%" ControlStyle-BorderWidth="0" ItemStyle-BorderWidth="0" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_total_earning_monthly" runat="server" Text='<%# Bind("MonthlyTotal")%>' style="padding-left:7px"></asp:Label></b>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField ControlStyle-Width="20%" ControlStyle-BorderWidth="0" ItemStyle-BorderWidth="0" ItemStyle-HorizontalAlign="Left">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lbl_total_earning_annual" runat="server" Text='<%# Bind("AnnualTotal")%>' style="padding-left:7px"></asp:Label></b>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                        <td id="td_deduction" runat="server" style="width: 50%;padding:5px 5px 5px 5px" visible="false" valign="top">
                                                            <table style="width: 100%; border: 1px solid rgba(0, 0, 0, 0.25);" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td style="border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);font-size: 16px; font-weight: 700;text-align:left;padding:5px;width:60%">
                                                                        <b>Particulars</b>
                                                                    </td>
                                                                    <td style="border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);font-size: 16px; font-weight: 700;text-align:center;padding:5px;width:20%">
                                                                        <b>Monthly</b>
                                                                    </td>
                                                                    <td style="border-bottom: 1px solid rgba(0, 0, 0, 0.25);font-size: 16px; font-weight: 700;text-align:center;padding:5px;width:20%">
                                                                        <b>Annual</b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 60%; border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);text-align:left;padding:5px">Employee Share PF
                                                                    </td>
                                                                    <td style="width: 20%; border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);text-align:center;padding:5px">
                                                                        <asp:Label ID="lbl_pf" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 20%; border-bottom: 1px solid rgba(0, 0, 0, 0.25); padding: 4px 4px 4px 4px;text-align:center;padding:5px">
                                                                        <asp:Label ID="lbl_annual_pf" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 60%; border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);text-align:left;padding:5px">Employee Share ESI
                                                                    </td>
                                                                    <td style="width: 20%; border-right: 1px solid rgba(0, 0, 0, 0.25); border-bottom: 1px solid rgba(0, 0, 0, 0.25);text-align:center;padding:5px">
                                                                        <asp:Label ID="lbl_esi" runat="server"></asp:Label>
                                                                    </td>
                                                                    <td style="width: 20%; border-bottom: 1px solid rgba(0, 0, 0, 0.25);text-align:center;padding:5px">
                                                                        <asp:Label ID="lbl_annual_esi" runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="width: 60%;border-right: none;text-align:left;padding:5px">
                                                                        <b>Total</b>
                                                                    </td>
                                                                    <td style="width: 20%; border-right: none;text-align:center;padding:5px">
                                                                        <b>
                                                                            <asp:Label ID="lbl_total_deduction_monthly" runat="server"></asp:Label></b>
                                                                    </td>
                                                                    <td style="width: 20%;text-align:center;padding:5px">
                                                                        <b>
                                                                            <asp:Label ID="lbl_total_deduction_annual" runat="server"></asp:Label></b>
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
                            </div>
                        </div>
                    </div>
                </div>
                 <table><tr><td><br /></td></tr></table>
                <div>
                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: right">Company Confidential 
                            </td>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: center">Escalon Business Services Pvt Ltd.
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: right"></td>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: center">Plot No-40A, SP Info city , Phase 8B 
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: right"></td>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: center">Mohali- Punjab
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: right"></td>
                            <td style="font: bold; font-size: 15px; font-weight: 700; text-align: center">+91 172 4643839
                            </td>
                        </tr>
                    </table>
                </div>
               </div>
                
                <table>
                    <tr>
                        <td style="height:150px"></td>
                    </tr>
                </table>
            </div>
            <table style="width: 90%; text-align: right; margin: 10px 5px 10px 15px">
                <tr>
                    <td>Page-4</td>
                </tr>
            </table>  
        </div>
    </form>

    <script src="../js/analytics.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
</body>
</html>
