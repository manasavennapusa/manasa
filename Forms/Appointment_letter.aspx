<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Appointment_letter.aspx.cs" Inherits="Forms_Appointment_letter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <style>
        table.a
        {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }

        .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
        }

        .letterHead
        {
            padding-top: 140px;
            padding-bottom: 120px;
        }

        .letterHeadExtra
        {
            padding-top: 100px;
        }

        .letterHeadMoreExtra
        {
            padding-top: 200px;
        }
        .letterHeadCustom
        {
            padding-top: 200px;
            padding-bottom: 120px;
        }
    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }

        function letterHead() {
            document.getElementById("letterHeadOne").setAttribute("class", "letterHead");
            document.getElementById("letterHeadTwo").setAttribute("class", "letterHead");
            document.getElementById("letterHeadThree").setAttribute("class", "letterHead");
            document.getElementById("thirdDiv").setAttribute("class", "letterHeadExtra");
            document.getElementById("letterHeadFour").setAttribute("class", "letterHead");
            document.getElementById("letterHeadFive").setAttribute("class", "letterHead");
            document.getElementById("letterHeadSix").setAttribute("class", "letterHead");
            document.getElementById("letterHeadSeven").setAttribute("class", "letterHeadCustom");
            document.getElementById("thirdDiv").setAttribute("class", "letterHeadExtra");
            document.getElementById("extra").setAttribute("class", "letterHeadExtra");
            document.getElementById("letterHeadEight").setAttribute("class", "letterHead");
        }

    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <asp:ScriptManager ID="rr" runat="server"></asp:ScriptManager>
                <asp:Panel ID="pnl1" runat="server" Style="margin-top: 20px">

                    <div class="row-fluid" style="padding-left: 20px; padding-right: 20px;">
                        <div class="span11">
                            <div>
                                <div class="widget-body">
                                    <fieldset>


                                        <div class="control-group" style="padding-right: 10px;">

                                            <div id="letterHeadOne">

                                                <table class="body">
                                                    <tr>
                                                        <td>
                                                            <input type="text" id="Text14" title="Please Enter Date of Issuance" runat="server" placeholder="Date of Issuance" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <input id="Text1" placeholder="Name" type="text" title="Please Enter Employee Name" runat="server" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <input id="Text2" type="text" title="Please Enter Permanent Address" runat="server" placeholder="Door Number, Cross " style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                            <br />
                                                            <input id="Text26" type="text" title="Please Enter Permanent Address" runat="server" placeholder="Street, Landmark" style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                            <br />
                                                            <input id="Text3" type="text" title="Please Enter Place" runat="server" placeholder="City, State, Pin." style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <input type="text" id="Text13" title="Please Enter Employee ID" runat="server" placeholder="Employee ID" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        </td>
                                                    </tr>




                                                    <tr>
                                                        <td style="padding-left: 10px"></td>
                                                    </tr>

                                                    <tr>
                                                        <td style="height: 20px"></td>
                                                    </tr>
                                                </table>
                                                <span style="margin-left: 7px; font-size: 14px;"><b>Dear </b>&nbsp;&nbsp;&nbsp;&nbsp
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name" style="padding-top: 13px; width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" /></span>
                                                <br />
                                                <br />
                                                <br />


                                                <div>
                                                    <span style="margin-left: 4px; text-align: justify">With reference to your application for employment in the Company and the subsequent interview you had with us,
we are pleased to appoint you a position with Escalon Business Services Pvt. Ltd.(“Company”) on the following
terms and conditions:-</span>
                                                </div>
                                                <br />
                                                <%-- 1 --%>
                                                <div>
                                                    <b>1. Position</b>
                                                    <ol style="text-align: justify">
                                                        1.1 You shall be joining in the position of
                                                    <input type="text" id="Text15" title="Please enter Designation & Department" runat="server" placeholder=" Designation & Department" style="padding-top: 13px; width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                        and shall assume
responsibilities assigned to you in line with your position.
Your appointment will take effect from your date of joining which should not be later than
                                                    <input type="text" id="Text5" title="Please enter Date of Joining" runat="server" placeholder=" Date of Joining" style="width: 150px; padding-top: 13px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        1.2 Although the Company does not have any immediate plans to modify your defined job responsibilities or
alter your specific job assignment, the Company retains the right to make such modifications in the future to
satisfy ongoing business needs.
                                                    

                                                    <br />
                                                        <br />
                                                </div>
                                                <%-- 2 --%>
                                                <div>
                                                    <b>2. Compensation</b>

                                                    <ol style="text-align: justify">
                                                        2.1 Your Compensation has been outlined in the Exhibit attached to this Appointment Letter. All
Compensation (Salary, Perquisites, Benefits, Bonuses, Rewards etc.) shall be subject to applicable statutory
deductions.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        2.2 The terms of your employment are strictly confidential between you and the Company. Discussion of
your compensation with any other party or employee is grounds for dismissal.
                                                    </ol>
                                                    <br />
                                                </div>



                                                <%-- 3 --%>

                                                <b>3. Places of Posting, Training, Transfer & Legal Right</b>
                                                <ol style="text-align: justify">
                                                    3.1 Your initial place of employment will be 
                                                    <input type="text" id="Text6" title="Please enter Location" runat="server" placeholder=" Location" style="width: 150px; padding-top: 13px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                        , India. However, based on the needs of the
Company, you may be transferred or may have to travel to other locations on work. The Company reserves its
right to decide the place and kind of training to be imparted to you.
                                                </ol>
                                            </div>
                                             <div id="letterHeadTwo">
                                            <ol style="text-align: justify">
                                                The Company reserves its right to send you on
training/ deputation/ secondment/ transfer/ assignments to its Subsidiaries/ Affiliates/ Associate companies, Subcontractors
and client’s locations. In such an event, you would be governed by the terms and conditions of service
applicable to the new assignment, without any financial loss.
                                            </ol>


                                           
                                                <ol style="text-align: justify">
                                                    3.2 You warrant that you have the legal right to enter into this contract and that you have all the necessary
permits, licenses, registrations, visa etc. as applicable, in order to perform your duties under this contract.
                                                </ol>
                                                <br />


                                                <%-- 4 --%>
                                                <div>
                                                    <b>4. Probationary Period</b>
                                                    <ol style="text-align: justify">
                                                        4.1 Your employment will be on probation for six (6) months, which may be reduced or extended at the sole
discretion of the Company depending upon your performance and / or conduct. On successful completion of the
probationary period, you may be considered for confirmation as a permanent employee. You will be deemed to be on
probation till you are provided with a written communication of your confirmation of employment.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        4.2 Details of rules applicable to you during the probationary period are outlined in the Company’s HR policy.
                                                    </ol>
                                                    <br />
                                                </div>
                                                <%-- 5 --%>
                                                <div>
                                                    <b>5. Commitment Document</b>
                                                    <ol style="text-align: justify">
                                                        5.1 A Commitment Document is required to be deposited with the Company as per the Commitment Policy, which
will be refunded at the time of your leaving the Company, subject to your adherence of applicable Company policies.
                                                    </ol>

                                                    <br />
                                                </div>
                                                <%-- 6 --%>
                                                <div>
                                                    <b>6. Code of Conduct</b>
                                                    <ol style="text-align: justify">
                                                        6.1 During the period of your employment, you will serve honestly, faithfully, diligently and efficiently for the
growth of the Company. You shall conduct yourself in conformity with the code of conduct, as in force from time to time.
You would be required to apply and maintain the highest standards of personal conduct and integrity and comply with all
the policies and procedures of the Company with punctuality.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        6.2 Details of the code of conduct are outlined in the “HR Policy” of the Company.
                                                    </ol>
                                                    <br />
                                                </div>

                                                <%-- 7 --%>

                                                <b>7. Secrecy</b>
                                                <ol style="text-align: justify">
                                                    7.1 You shall maintain and ensure utmost confidentiality and secrecy with regard to the affairs of the Company, its
subsidiaries, associates and clients and will not use, divulge or make known, directly or indirectly, to any person or firm
or company, any of the trade secrets or other confidential or proprietary information of the Company, its subsidiaries,
associates and clients, including, but not limited to the operations, methods or processes involved or employed in its
business or any information, whether written or oral, which directly or indirectly relates to internal controls, computer or
data processing programs, algorithms, electronic data processing, applications routines, subroutines, techniques or
systems, or information concerning the business or proposed transactions, security procedures, trade secrets, know-how,
or inventions.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    7.2 Breach of this provision shall be treated as a gross violation of the terms stipulated herein and may be treated as
serious offense resulting to prosecution, in addition to your services being liable to be terminated without notice.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    7.3 Such proprietary information, trade secrets and confidential information shall at all times, remain the property of
the Company.
                                                </ol>
                                            </div>
                                            <div id="letterHeadThree">
                                                <div id="thirdDiv">
                                                    <ol style="text-align: justify">
                                                        7.4 Information is available on need to know basis for specified groups. You have the responsibility to ensure that
computerized data is accurate and kept secret. Unauthorized disclosure of the Company’s data is serious offence and can
result in prosecution. Therefore you are required to ensure that you:<br />
                                                         Do not disclose office data without authority.<br />
                                                         Do not access information or systems not directly relevant to each task.<br />
                                                         Do not treat office data carelessly.<br />
                                                         Lock all printouts away when not in use.<br />
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        7.5 The provisions of this Clause 7 will survive the termination or expiry of this Appointment Letter.
                                                    </ol>

                                                    <br />

                                                    <%-- 8 --%>
                                                    <div>
                                                        <b>8. Conflict of Interest and & Non-compete</b>
                                                        <ol style="text-align: justify">
                                                            8.1 Your position with the Company calls for whole time employment and you shall devote yourself exclusively to
the functions/operations/business of the Company. You will not take up any other work for remuneration (part time or
otherwise) or work on advisory capacity or be interested directly or indirectly in any other trade or business, during your
employment with the Company, without prior written permission from the Company. You additionally warrant that you
are not currently studying for any courses/degrees/classes and that you will not make major time commitments outside
work during your employment with the Company, without written permission from the Company. You would be
required to sign a warranty to this effect after you join us.
                                                        </ol>

                                                        <br />
                                                    </div>
                                                    <%-- 9 --%>
                                                    <div>
                                                        <b>9. Hours of Work, Shifts, Holidays, Leave & Attendance</b>

                                                        <ol style="text-align: justify">
                                                            9.1 The Company follows five & half (5 ½) working days a week schedule for most of its positions, barring few
exceptions. Based on your position and job requirement, a time shift will be allotted to you.
                                                        </ol>
                                                        <ol style="text-align: justify">
                                                            9.2 You will be eligible for paid leaves and holidays as outlined in the HR policy, as in force from time to time. All
leave requests must be submitted to your Immediate Reporting Manager & Human Resources Department (“HR”), in
advance as per the policy guidelines.
                                                        </ol>
                                                        <br />
                                                    </div>
                                                    <%-- 10 --%>

                                                    <b>10. Termination of Employment</b>
                                                    <ol style="text-align: justify">
                                                        10.1 You will be governed by the Company’s Code of Conduct / other policies governing attendance and leaves,
commitment document, secrecy, conflict of interest etc as may be applicable in the company from time to time. Your
employment is contingent to your continued acceptance of these policies.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        10.2 During your probation period, the Company will have the right to terminate your employment without any notice
and/or without assigning any reason whatsoever.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        10.3 On completion of the probation period, the Company can terminate your employment by giving 30 calendar days
notice or on payment of basic salary in lieu of notice, irrespective of the level.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        10.4 However, in the event your employment is terminated on account of criminal activities, fraud, misrepresentation
or any form of misconduct, breach of Intellectual Properties, and activities of similar nature, your employment may be
terminated with immediate effect without notice or payment in lieu thereof. In such cases, the Company further reserves
its right to invoke other legal remedies as it deems fit, to protect its legitimate interests.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        10.5 If you do not wish to continue with the Company, you can terminate your employment by serving a notice period
as specified in the Company policy and as applicable to your employment. During probation this period is 30 calendar
days. Confirmed employees may terminate their employment with the Company by giving 60 calendar Days' notice. In
the event that you terminate your employment within 12 months, you will fully reimburse any relocation expenses paid to
you.
                                                    </ol>
                                                </div>
                                            </div>
                                            <div id="letterHeadFour">
                                                <ol style="text-align: justify">
                                                    10.6 This appointment is made based on the skills and educational qualifications you have declared to possess as per
the interview and your resume, and on the ability to handle assignment/job independently anywhere in India and overseas.
In case, at a later date, any of your statements/particulars furnished are found to be false or misleading, the company shall
have the right to terminate your services with immediate effect as mentioned in clause 10.4 above.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    10.7 Details of Termination are outlined in the HR policy, as in force from time to time.
                                                </ol>
                                                <br />

                                                <%-- 11 --%>
                                                <div>
                                                    <b>11. Superannuation</b>
                                                    <ol style="text-align: justify">
                                                        11.1 You will be retired on attaining the age of 58 years. Rules, regulations and policies as may be framed from time
to time by the Company would guide your services and superannuation. Company may grant extension of one or two
years purely at its discretion or due to the exigencies of services subject to your remaining physically and mentally fit.
Extension of service period cannot be claimed as matter of right or precedent.
                                                    </ol>
                                                    <br />
                                                </div>
                                                <%-- 12 --%>
                                                <div>
                                                    <b>12. Property of the Company</b>
                                                    <ol style="text-align: justify">
                                                        12.1 You shall take reasonable care in maintaining and protecting the assets and properties of the Company,
including, but not limited to its software, hardwares, books, files, documents (stored in whatever medium), laptops etc,
that you may have access to by virtue of your employment with the Company or that may be provided to you by the
Company from time to time, for your use. On termination of your employment and/or on demand, you shall take steps to
return such assets and properties back to the Company in the same condition as given, subject to normal wear and tear.
Failing this, the Company shall be entitled to recover such costs/ compensation as it may deem fit, keeping in view the
cost of such assets, and properties belonging to the Company.
                                                    </ol>
                                                    <br />
                                                </div>
                                                <%-- 13 --%>
                                                <div>
                                                    <b>13. Intellectual Property Right</b>
                                                    <ol style="text-align: justify">
                                                        13.1 The Company will be the owner of intellectual property right in all creations, adaptations, inventions,
innovations, patents, improvements and discoveries made by you during the course of your employment and in
connection with your employment with the Company. All creations, adaptations, inventions, improvements and
discoveries made solely by you or jointly while in the employment with the Company needs to be disclosed to the
Company and the Company has the sole right, title and interest on such creations, inventions, improvements and
discoveries. You hereby assign to the Company your worldwide and perpetual rights in the intellectual property right in
all such creations, adaptations, inventions, improvements and discoveries that shall be made by you during the course of
your employment and in connection with your employment with the Company. You will not do anything in conflict with
the Company’s intellectual property rights and will cooperate fully to protect such intellectual property rights of the
Company against misappropriation or infringement by third parties.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        13.2 If you come across any cases of infringement the Company’s intellectual property rights, you will promptly
notify the Company of such infringement and assist the Company in any and all ways to protect the intellectual property
rights.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        13.3 In this connection, the Company may require you to sign such assignment or waiver agreements and such other
agreements as may be necessary for it to register and protect its intellectual property rights worldwide.
                                                    </ol>
                                                    <ol style="text-align: justify">
                                                        13.4 You acknowledge that the information, observations and data concerning the Company and/ or its customers, is
and shall continue to be the property of the Company and/ or its customer’s, as the case may be and that you shall not be
entitled to any right or license in relation to the said information, nor shall you copy, reproduce, publish, distribute, adapt,
modify or amend any part thereof, without the prior written consent of the Company.
                                                    </ol>
                                                    <br />
                                                </div>
                                                 </div>
                                                <%-- 14 --%>
                                            <div id="extra">
                                            <div id="letterHeadFive">
                                                <div>
                                                    <b>14. Non Solicitation</b>
                                                    <ol style="text-align: justify">
                                                        14.1 During the term of your employment with the Company and for a period of one (1) year thereafter, you shall
not, directly or indirectly, solicit, induce, influence, or attempt to solicit, induce, or influence any other employee of the
Company to terminate his or her employment with the Company, nor shall you, directly or indirectly, on behalf of any
other person or business entity, hire or assign as an employee, consultant, or independent contractor, any individual who
was in the employment of the Company at any time during the last one (1) year of your employment with the Company.
                                                    </ol>
                                                    <br />
                                                </div>
                                           
                                            <%-- 15 --%>
                                            <div>
                                                <b>15. Dispute with Former Employer / Employee</b>
                                                <ol style="text-align: justify">
                                                    15.1 In the event you become a party to any proceeding brought by any former employer/ employee of yours at any
time during or after your employment with the Company, you recognize and agree that you shall have full and sole
responsibility for responding to such action and the Company has no responsibility to participate in your response nor in
your cost of such response.
                                                </ol>
                                                <br />
                                            </div>
                                            <%-- 16 --%>
                                            <div>
                                                <b>16. Passwords, Security, Use of Resources, Unauthorized Software</b>
                                                <ol style="text-align: justify">
                                                    16.1 Access to Company’s network, development environment and email is through individual’s password. For
security reasons, it is essential to maintain confidentiality of the same. If the password is forgotten, the Information
Systems Department is to be contacted to reset and allow you to use the system with a new password.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    16.2 Information security is an important aspect of our communication and office infrastructure.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    16.3 You shall not install, download, copy, duplicate any unauthorized or unlicensed software, programs, games,
music, videos, movies, attachments on to your computer systems.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    16.4 You shall not use any and all Company’s resources for any purpose other than official. If it is found that you
have been using any of the Company’s resources for personal use, Company reserves its right to deduct the said expenses
from your salary and also the right to take suitable disciplinary action.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    16.5 For protection and security of its proprietary information, during the normal course of business, the Company
reserves its right to record and monitor all movements, calls made, IM conversations held by you and emails sent by you,
using office infrastructure. You understand and agree that such act of the Company does not amount to invading your
right to privacy and is only a legitimate right of the Company to protect its proprietary information and misuse of its
resources.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    16.6 All use of Company Resources must be in conformity with the information systems policy, as in force from time
to time.
                                                </ol>
                                                <br />
                                            </div>
                                            <%-- 17 --%>
                                            <div>
                                                <b>17. Governing Law and Jurisdictions</b>
                                                <ol style="text-align: justify">
                                                    17.1 The terms and conditions of this Appointment Letter shall be governed by the laws of India and in case of any
dispute arising out of your employment or under this Appointment Letter, the jurisdiction to entertain such dispute shall
vest exclusively with the courts in Kolkata.
                                                </ol>
                                                <br />
                                            </div>
                                            <%-- 18 --%>
                                            <div>
                                                <b>18. Performance Review</b>
                                                <ol style="text-align: justify">
                                                    18.1 You will be covered under performance review as per the Company policy guidelines and any promotions or
increments will be made on the basis of performance and will be at the sole discretion of the Company.
                                                </ol>
                                                <br />
                                            </div>
                                                 </div>
                                                </div>
                                            <%-- 19 --%>
                                             <div id="letterHeadSix">
                                            <div>
                                                <b>19. Change in Address</b>
                                                <ol style="text-align: justify">
                                                    19.1 Any changes in your residential address, telephone number and mobile number should be immediately informed
to the HR.
                                                </ol>
                                                <br />
                                            </div>
                                               
                                            <%-- 20 --%>
                                           
                                            <div>
                                                <b>20. Waiver</b>
                                                <ol style="text-align: justify">
                                                    20.1 The failure of either Party to enforce at any time any provision of this Appointment Letter, shall not constitute a
waiver thereof of such rights.
                                                </ol>
                                                <br />
                                            </div>
                                            <%-- 21 --%>
                                            <div>
                                                <b>21. Severability</b>
                                                <ol style="text-align: justify">
                                                    21.1 If any term or provision of this Appointment Letter shall be held to be invalid, illegal, or unenforceable in whole
or in part, the validity, legality and enforceability of the remaining provisions shall not in any way be affected or impaired
thereby.
                                                </ol>
                                                <br />
                                            </div>

                                            <%-- signature --%>
                                            <div>
                                                The contents of this Appointment Letter and your compensation details are confidential in nature and in case you require
any clarification, you shall not discuss its contents with anyone except the HR.<br />
                                                <br />
                                                By accepting this offer, you agree to comply with and abide by all rules and regulations of the Company as shall be in
force, from time to time. In all matters, including those not specifically covered herein, you will be governed by the rules
of the Company as may be framed from time to time.<br />
                                                <br />
                                                Kindly return the duplicate copy duly signed by you as your acceptance of the above terms and
conditions.<br />
                                                <br />
                                                Thanking you,
                                                <br />
                                                <br />
                                                <br />
                                                _____________________________________<br />
                                                <br />

                                                (Authorized Signatory)<br />
                                                Escalon Business Services Pvt. Ltd.
                                        
                      <br />
                                                <br />
                                                This is to certify that I have gone through and understood all the terms and conditions mentioned in this appointment
letter and I hereby accept and agree to abide by them. I have also gone through and understood all the terms and
conditions mentioned in the Probation Policy, Attendance Policy, Copyright Policy, Core Values, Education Policy, Exit
Policy, Information Systems Policy, Leave Policy and Office Decorum, made available to me on the Company Intranet
and have digitally accepted and agreed to abide by them. 
                           <br />
                                                <br />

                                                <b>I ACCEPT THE TERMS AND CONDITIONS OF MY APPOINTMENT AS STIPULATED IN THIS APPOINTMENT
LETTER. </b>
                                                <br />
                                                <br />

                                                <b>Name in full: </b>
                                                <br />
                                                <br />
                                                <b>Signature: </b>
                                                <br />
                                                <br />
                                                <b>Date: </b>
                                                <br />
                                                <br />
                                                <b>Place: </b>
                                                <br />
                                                <br />

                                            </div></div>
<div id="letterHeadSeven">
    
                                            <center><b>EXHIBIT- A</b></center>
                                            <br />
                                            <b>Your Compensation Package is as follows:-</b>
                                            <br />
                                            <br />
                                            <br />
                                            <%-- table --%>

                                            
                                                <div>
                                                <table class="a">
                                                    <tr>
                                                        <td style="flex-align: center; font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px;"><b>Compensation Structure</b> </td>
                                                    </tr>
                                                </table>
                                                <table class="a">
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px; width: 40%;"><b>Exhibit A</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px; width: 60%;"><b>Present Structure</b> </td>
                                                    </tr>
                                                </table>
                                                <table class="a">
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px; width: 40%;"><b>Description </b></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px; width: 30%;"><b>Yearly (Rs)</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: center; padding: 8px; width: 30%;"><b>Monthly (Rs)</b> </td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Base Pay CTC</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Variable Pay CTC</b></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Total CTC </b></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>FIXED </b></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Basic Salary </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>


                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Housing Rent Allowance </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Medical Reimbursement </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Transportation Allowance </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">E.P.F.</td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">E.S.I.F.</td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Special Allowance </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>BENEFITS, ANNUITY & RETIRALS</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Company Bonus </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Leave Encashment</td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Administrative Charges on E.P.F. </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;">Gratuity on accrual basis </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Total Base CTC</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Total Variable CTC</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>
                                                    <tr>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>Total Annual CTC</b> </td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 30%;"></td>

                                                    </tr>

                                                </table>

                                            </div>
                                                </div>
    
                                            <br />
                                            <br />
                                            <br />
                                            
                                            <div id="letterHeadEight">
                                                <b>Notes:</b>
                                                <ol style="text-align: justify">
                                                    Your Compensation Package is subject to the following Terms & Conditions:-
                                                </ol>
                                                <ol style="text-align: justify">
                                                    1. All Compensation will be paid by the Company in Indian Rupees, subject to statutory
deductions as applicable as per your employment.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    2. Leave Encashment—Leave entitlement is 30 Days; Unavailed leaves can be encashed at
the end of the Financial Year or carried over to the next year as per HR policy of the company.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    3. Annual Company Bonus (8.33% of Basic Salary) is paid in September every year based
on pro-rata payroll drawn in previous financial year.  
                                                </ol>
                                                <ol style="text-align: justify">
                                                    4. Provident Fund – Company will deduct Provident Fund every month as per the Employee’s
Provident Fund Act, 1952. 
                                                </ol>
                                                <ol style="text-align: justify">
                                                    5. Gratuity is paid on separation of employee from the Company, on completion of minimum 5
years of continuous service with the Company. 
                                                </ol>
                                                <ol style="text-align: justify">
                                                    6. Personal Tax — the payments described above will not be further grossed up for taxes
and you will be responsible for the payment of all taxes due with respect to such payments,
which will be deducted at source as per the prevailing rules.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    7. Variable Pay, if applicable, will be paid on hitting specific Milestones as outlined in Exhibit B.
                                                </ol>


                                                <br />
                                            </div>

                                            <br />
                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide();  window.print();" class="btn btn-info pull-right" /><br />
                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>


            </div>
        </div>

    </form>
</body>
</html>
