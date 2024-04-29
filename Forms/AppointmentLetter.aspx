<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppointmentLetter.aspx.cs" Inherits="Forms_AppointmentLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
     <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }
</script>
</head>
<body >
    <form id="form1" runat="server">
         <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                   
        <asp:ScriptManager ID="rr" runat="server"></asp:ScriptManager>
        <asp:Panel ID="pnl1" runat="server" Style="margin-top: 120px">
            
             <div class="row-fluid" style="padding-left:20px; padding-right:20px;">
                 <div class="span11">
                                <div class="widget">
                                   <div class="widget-body">
                                       <fieldset>
                                            <div class="control-group">
                                                
            
            
            <table class="body">
                <tr style="margin-left: 10px">
                <td style="padding-left: 10px">
                <input type="text" id="Text14" runat="server" placeholder="Date" style="width: 150px; height: 20px; float: right; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />                             
                     </td>
                <td style="padding-left: 10px">
            <input type="text" id="Text13" runat="server" placeholder="EmpCode" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                    </td>
                
                    <td style="padding-left: 10px">
                        <input id="Text1" placeholder="Name" type="text" runat="server" style="width: 160px; height: 20px; border-top: none; border-left: none; border-right: none" />,
                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <input id="Text2" type="text" placeholder="Address" runat="server" style="width: 160px; height: 20px; border-top: none; border-left: none; border-right: none" />,
                        <br />
                        <input id="Text26" type="text" placeholder="" runat="server" style="width: 160px; height: 20px; border-top: none; border-left: none; border-right: none" />,

                    </td>
                </tr>
                <tr>
                    <td style="padding-left: 10px">
                        <input id="Text3" type="text" placeholder="Place" runat="server" style="width: 160px; height: 20px; border-top: none; border-left: none; border-right: none" />,
                    </td>
                </tr>

                <tr>
                    <td style="height: 20px"></td>
                </tr>
            </table>
            <span style="margin-left: 7px">Dear &nbsp;&nbsp;&nbsp;&nbsp
                <input id="Text4" type="text" placeholder="Name" runat="server" style="width: 150px; height: 20px; border-top: none; border-left: none; border-right: none" /></span>
            <br />
            <br />
            <br />
            <span style="margin-left: 35%; font-size: 18px; font-weight: bold">Sub: Letter of Appointment</span>
            <br />
            <br />

            <div>
                <span style="margin-left: 4px; text-align: justify">We welcome you to TriMedx India Private Limited (the “Healthcare Equipment Services”). We believe that you will be a valuable addition to the TriMedx team and wishes you all success in this assignment. We are pleased to appoint you on the following terms and conditions
            </div>
            <br />

            <ul style="list-style: none; text-align: justify; margin-right: 15px; margin-left: 15px;">
                <li>A.	Designation
                         <input id="Text5" type="text" placeholder="Designation" runat="server" style="width: 150px; height: 20px; border: none; margin-left: 70px" /></li>
                <li style="height: 10px"></li>

                <li>B.	Date of Joining
                         <input id="Text15" type="text" placeholder="Date Of Joining" runat="server" style="width: 150px; border: none; height: 20px; margin-left: 50px" />

                </li>
                <li style="height: 10px"></li>
                <li>C.	Location        
                         <label style="margin-left: 85px">TriMedx India Pvt. Ltd. No 258/A, </label>
                    <br />
                    <label style="margin-left: 160px">Bommasandra Industrial Area, </label>
                    <br />
                    <label style="margin-left: 160px">Anekal Taluk, Bangalore, Karnataka-560099.</label>
                    <li style="height: 10px"></li>

                    <li>D.	Compensation
                          <input id="Text16" type="text" placeholder="Compensation" runat="server" style="width: 150px; border: none; border: none; height: 20px; margin-left: 50px" />
                    </li>
                    <li style="height: 10px"></li>
                    <li>E.	Deputation
                          <input id="Text24" type="text" placeholder="Deputation" runat="server" style="width: 150px; border: none; border: none; height: 20px; margin-left: 75px" /></li>
                    <li style="height: 10px"></li>
            </ul>

            <ul style="list-style: decimal; text-align: justify; margin-right: 20px; margin-left: 0px">

                <b>1.	General Terms and Conditions</b>
                    <ol style="text-align: justify">
                        a. This letter contains broad terms and conditions of service governing this employment which are subject to change from 
                        time to time as per operational requirements. Hence you are requested to contact Human Resources / your reporting authority
                        for policies / rules / regulations, which are applicable to you. 
                    </ol>
                    <ol style="text-align: justify">
                        b.	We trust that you have not provided us with any false declaration or willfully suppressed any material information. 
                        If you have, the company reserves the right to initiate appropriate action, up to and including the termination of employment
                         without notice or any compensation in-lieu of. It must be specifically understood that this offer is made based on your 
                        proficiency in the technical / professional skills you have declared to possess as per your application for employment with 
                        the company, and on your ability to handle any assignment / job independently anywhere in India or overseas. In the event, 
                        at a later date, any of the statements/particulars furnished by you to the company are found to be false or misleading, or
                         your work performance falls short of the minimum standards required by the company, the company shall have the right to 
                        terminate your services, without any notice or compensation in-lieu of, notwithstanding any other terms and conditions 
                        stipulated herein.

                    </ol>
                    <ol style="text-align: justify">
                        c.	You warrant that you are not prevented by a court or by any other administrative or judicial order from providing the 
                        services required under this employment. It is contingent on you to update us on any likely change of your immigrant
                         status at the location of service, as applicable.
                    </ol>
                    <ol style="text-align: justify">
                        d.	Your employment is governed by this letter and the applicable rules and policies provided in the “Employee 
                        Manual” available with Human Resources. In case of a conflict between terms of this letter and any other policy 
                        document, the offer letter shall prevail.
                    </ol>
                    <ol style="text-align: justify">
                        e. 	This offer is being made to you subject to your producing the relevant documents as intimated to you.
                    </ol>
                    <ol style="text-align: justify">
                        f.	Fitness to Work: At any time during the tenure of service, the management has right to refer you for medical examination to 
                        the appropriate authority to ascertain the fitness for service continuation.  
                    </ol>
                    <ol style="text-align: justify">
                        g.	Transfer: You may be transferred to any of other offices/branches or subsidiaries/affiliates of the company, either domestic
                          or abroad, should the business need arise. You will be subject to and hereby confirm that you will abide by the applicable 
                         Employee Manual as may be in effect from time to time with respect to your function or the location to which you are so relocated.
                    </ol>
                    <ol style="text-align: justify">
                        h.	Retirement: An employee shall retire from the services of the company at the end of the month in which he/she 
                        attains the age of 60 years, which is the age of retirement for all employees. The age of retirement shall be 
                        reckoned in accordance with the Gregorian calendar.
                    </ol>
                    <ol style="text-align: justify">
                        i.	This letter is made on the clear understanding that your employment is on a full time basis and that you shall 
                        not engage yourself directly or indirectly in any business or service or monetary position other than that of the 
                        company. In specific cases, e.g. writing for a magazine / journal, speaking at various forums, etc., explicit 
                        permission from the company has to be taken prior to your engaging in such activity. At any time, if it is found 
                        that there is any breach of this condition on your part, your services are liable to be immediately terminated at 
                        the sole discretion of the company. 
                    </ol>

                
               <br/>

                <b>2. Key Result Areas:</b>

                    <ol style="text-align: justify">
                        You shall be briefed upon your Key Result Area (KRA) milestones and the applicable timelines for review within a month (30 days). This document shall be submitted to Human Resource department after a sign off is obtained from both parties and will set guiding principles for your performance. 
                    </ol>

               
               <br/>
                <b>3. Date of Commencement and Working Hours:</b>
                    <ol style="text-align: justify">
                        Your appointment with the company will be effective on your joining date. The company operates 24 hours across 7 days a week. Your work hours will be intimated to you by your reporting authority. Please note that the work hours applicable to you, TriMedx as a service organization, accords high priority to customer service levels and therefore depending upon criticality of the requirements you shall be required to accommodate all changes to your work schedule as decided and communicated to you by the management from time to time. 
                    </ol>

                
                <br/>
                <b>4. Probation and Notice Period</b>
                    <ol style="text-align: justify">
                        a.	You will be on probation for an initial period of six months from the date of your joining. In case your performance is found unsatisfactory during the probation period, the company may, at its option, terminate your service on giving one month notice or payment of salary in lieu thereof or extend the probation period. Similarly, you will be at liberty to resign from services of the company on giving one month notice or forfeiture of salary in lieu thereof. 
                        <br />
                        It is understood that the company would be fully entitled to terminate your services one month during the probation period without assigning any reason. Similarly you may leave the services of the company without assigning any reason at any time during the probation period.
                    </ol>
                    <ol style="text-align: justify">
                        b.	On completion of your probation successfully you may be observed on the rolls of the company; however the 
                        company reserves the right to terminate your service on giving one month notice or payment of salary in lieu 
                        thereof. Similarly, you will be at liberty to resign from services of the company on giving one month notice or 
                        forfeiture of salary in lieu thereof. The prerogative to ask the employee to serve the notice period or recover 
                        salary in lieu of rests with the company. In case you leave the employment of the company without serving the 
                        prescribed notice period, the management will have the right to recover an amount equivalent to one month notice 
                        salary. Company shall also be entitled to make deductions from your other dues to the extent of the damage or loss
                         to the company or Company’s property if any, and also to the extent of any advance made to you by the company.

                    </ol>
                    <ol>
                        c.	You will continue to be governed by Employee Manual during the notice period. In case of any indiscipline or misconduct on your part during the notice period or otherwise, the company reserves the right not to accept your resignation and/or consider the earlier acceptance of resignation as null and void and terminate your services with immediate effect. In such an event, the company will not be liable to pay you any dues whatsoever.

                    </ol>
                    <ol style="text-align: justify">
                        d.	Notwithstanding anything contained herein, in case of any misconduct, or indiscipline on your part during the course of your employment, breach of terms and conditions referred in this letter of appointment, breach of any or all the clauses of applicable Employee Manual or any other applicable policies governing your employment, including unauthorized absence / leave, the management may terminate your employment immediately. 
                    </ol>
                    <ol style="text-align: justify">
                        e.	On cessation of employment on whatsoever grounds, an employee shall return to the office all articles of the company issued to him/her by the office and his/her custody. The company shall have the right to claim compensation from you for the damage or loss of such articles.
                    </ol>

                
                <br/>
                <b>5. Compensation</b>
                    <ol style="text-align: justify">
                        a.	You will be eligible to receive the compensation as per the details in the Annexure.
                    </ol>
                    <ol style="text-align: justify">
                        b.	You may be entitled to other compensation and benefits in accordance with the company’s relevant employment policies, rules and regulations as modified and intimated to you from time to time.  The Policies are subject to change at any point on company’s discretion.
                    </ol>
                    <ol style="text-align: justify">
                        c.	Your compensation will be reviewed periodically as per the company’s policy. Changes in your compensation are carried out at the sole discretion of the company and will be subject to and based on effective performance and results during the period and other relevant criteria.
                    </ol>
                    <ol style="text-align: justify">
                        d.	You are solely responsible for declarations and implications arising thereof for all Income Tax purposes.
                    </ol>
                    <ol style="text-align: justify">
                        e.	Your remuneration has been arrived at on the basis of your specific background and professional merit. We expect you to keep the Compensation details confidential at all times. 
                    </ol>
               
               <br/>
                <b>6. Other Benefits</b>
                    <ol style="text-align: justify">
                        You will be entitled to the following as per company’s policies:
                    </ol>
                    <ol style="text-align: justify">
                        a.	Leave and Holidays as applicable to your category of employees and the location where you are posted

                    </ol>
                    <ol style="text-align: justify">
                        b.	Perquisites, if any, as applicable to your category of employees and/or based on functional / operational requirements as determined by the company.

                    </ol>
                    <ol style="text-align: justify">
                        c.	Participation in the Employee Provident Fund Scheme as per rules and policies is applicable to your category of employees.

                    </ol>
                    <ol style="text-align: justify">
                        d.	Enrolment in the company’s medical assistance program and Contributory Insurance and benefits program for your category of employees.
                    </ol>
               
                <br/>
                <b>7. Responsibilities</b>
                    <ol style="text-align: justify">
                        a.	You must effectively, diligently and to the best of your ability perform all responsibilities and ensure results that meet company’s objectives. 

                    </ol>
                    <ol style="text-align: justify">
                        b.	You will keep the management informed of any change in your residential address or in your civil status.

                    </ol>
                    <ol style="text-align: justify">
                        c.	You must not engage in activities that have an adverse impact on the reputation/image and business of the company, whether directly or indirectly. If you / your dependent family member have a financial / gainful interest in any business with the company/ its subsidiaries, then it would be obligatory on your part to tender a written declaration to the Management to the above effect, before such a deal is entered into. 

                    </ol>
                    <ol style="text-align: justify">
                        d.	You may be required to undertake travel for company’s work for which you will be reimbursed travel expenses as per the company policy applicable to your category of employees.

                    </ol>
                    <ol style="text-align: justify">
                        e.	All employees of the company are required to ensure integrity in all aspects of the functioning and operations. You are expected to comply with all the Employee Manual and policies of the company including the Code of Conduct, Information Security Policy and all other policies as they form an integral part of the terms and conditions of your employment. 

                    </ol>
                    <ol style="text-align: justify">
                        f.	Any matter or situation or incident that may arise and that could potentially result or has resulted in any violation of the policies of this letter, shall immediately be brought to the notice of your Manager or Human Resources Department.

                    </ol>
                    <ol style="text-align: justify">
                        g.	You will be responsible for the safe keeping and return, in good condition and order of all the properties and equipment of the company which may be in your use, custody or charge. 

                    </ol>
                
                <br/>
                <b>8. Confidentiality and Copyright</b>
                    <ol style="text-align: justify">
                        You agree to sign and abide by the provisions of the enclosed “Confidential Information, Intellectual Property Rights and Non Compete agreement” at all times during your employment
                        
                    </ol>
                
                <b>9.   Force Majeure:  </b>Neither of the parties will be in breach of any or all of the terms and conditions of your letter of appointment  to the extent that such party is unable to perform due to any event of “force majeure”, including, without limitation, fire, explosion, earthquake, epidemic, war, strike, riot, civil disobedience, Act of God or any governmental law, decree or ordinance, and neither party shall be liable to the other for any of its obligations hereunder during the period that such “force majeure” event remains in effect.  
               <b>10.</b> This offer shall be governed by and construed in accordance with the laws of India.  The courts at Bangalore City- India alone shall have jurisdiction in the event of any dispute. 
                

               <b>11.</b> In the absence of our receiving your signed acceptance of this letter of appointment, this will be deemed to have been rejected by you and shall lapse automatically. This letter of appointment along with your acceptance constitutes a binding agreement between yourself and the Company.                

                
                <br/>

                Welcome to TriMedx India Private Limited and I wish you all the 
                
                <br />

                <div>
                    For TriMedx India Private Limited,
                </div>
                <br />
                <div>
                    <b>Sathish Kumar M</b>
                </div>
                <div>
                    <b>Director – Operations </b>
                </div>
                <br />
                <br />
                <div>
                    <b>Annexure to letter of appointment No &nbsp;
                        <input id="Text21" type="text" runat="server" style="width: 100px; height: 20px; border-top: none; border-left: none; border-right: none; font-weight: 500" placeholder="Appointment No." />&nbsp;
                        Dated: &nbsp;
                        <input id="Text9" type="text" runat="server" style="width: 100px; height: 20px; border-top: none; border-left: none; border-right: none; font-weight: 500" placeholder="Date" />
                    </b>
                </div>

            </ul>

            <table>
                <tr>
                    <td>Name
                    </td>
                    <td>:
                    </td>
                    <td>
                        <input id="Text6" type="text" placeholder="Name" runat="server" style="width: 150px; height: 20px; border: none; font-weight: 500" />
                    </td>
                </tr>
                <tr>
                    <td>Effective Date
                    </td>
                    <td>:
                    </td>
                    <td>
                        <input id="Text7" type="text" placeholder="Date" runat="server" style="width: 150px; height: 20px; border: none; font-weight: 500" />
                    </td>
                </tr>
            </table>

            <br />
            <span>Your total annual compensation will be INR.
                <input type="text" runat="server" placeholder="Amount" id="Text25" style="width: 80px; border: none; font-weight: bold" />
                p.a.  Your compensation will be subject to deduction of tax at source as per statutory regulations. The break-up of the compensation is as under. </span>
            <br />
            <br />
            <table id="Table1" class="table" style="width: 100%; border-collapse: collapse;" runat="server" border="1">
                <tr>
                    <td style="width: 50px">
                        <b>#</b>
                    </td>
                    <td>
                        <b>Components</b>
                    </td>
                    <td>
                        <b>In INR p.a.</b>
                    </td>
                    <td>
                        <b>In INR p.m.</b>
                    </td>
                </tr>

                <tr>
                    <td>1
                    </td>
                    <td>Basic and Dearness Allowance (DA)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text8" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text10" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>2</td>
                    <td>House Rent Allowance (HRA)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text11" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text12" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>3</td>
                    <td>Conveyance Allowance (CA)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text22" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text23" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>4</td>
                    <td>City Compensatory Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text17" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text18" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>4
                    </td>
                    <td>Washing Allowance 
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text27" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text28" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>6</td>
                    <td>Medical Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text29" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text30" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>7</td>
                    <td>Education Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text31" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text32" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>8</td>
                    <td>Furnishing Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text33" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text34" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>9
                    </td>
                    <td>Car Maintenance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text35" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text36" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>10</td>
                    <td>Car Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text37" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text38" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>11</td>
                    <td>Fixed Incentive Pay
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text39" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text40" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>12</td>
                    <td>Leave Travel Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text41" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text42" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>13</td>
                    <td>Special Allowance
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text43" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text44" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr style="height: 10px;">
                    <td colspan="4"></td>
                </tr>

                <tr>
                    <td>
                        <b>14</b>
                    </td>
                    <td>
                        <b>Gross Salary</b>
                    </td>
                    <td>
                        <b>
                            <input type="text" runat="server" id="Text45" style="width: 100%; height: 100%; border: none" /></b>
                    </td>
                    <td>
                        <b>
                            <input type="text" runat="server" id="Text46" style="width: 100%; height: 100%; border: none" /></b>
                    </td>
                </tr>

                <tr style="height: 10px;">
                    <td colspan="4"></td>
                </tr>

                <tr>
                    <td>15
                    </td>
                    <td>Company’s contribution to Provident Fund 
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text47" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text48" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>16</td>
                    <td>Company’s contribution to ESIC
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text49" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text50" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>17</td>
                    <td>Food coupons
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text51" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text52" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>18</td>
                    <td>Bonus (Annually)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text53" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text54" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>19
                    </td>
                    <td>Performance Based Incentives (Quarterly) 
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text55" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text56" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>20</td>
                    <td>Gratuity (On completion of required period)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text57" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text58" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr>
                    <td>21</td>
                    <td>Superannuation Fund (On completion of required period)
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text59" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text60" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>

                <tr style="height: 10px;">
                    <td colspan="4"></td>
                </tr>

                <tr>
                    <td>22</td>
                    <td>
                        <b>Total CTC</b>
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text61" style="width: 100%; height: 100%; border: none" />
                    </td>
                    <td>
                        <input type="text" runat="server" id="Text62" style="width: 100%; height: 100%; border: none" />
                    </td>
                </tr>


            </table>

            <br />
            <br />
            <div>
                You will be entitled for statutory benefits such as PF, ESIC, Bonus, and Gratuity strictly as per the applicable statute.                     
            </div>
            <br />
            <br />
            <br />
            <br />
            <div>
                Group Medical Insurance coverage of INR 200,000/- per annum for self and the family, Group Term Life Insurance coverage of 
                    INR 500, 000/- per annum for self and Group Personal Accident Insurance coverage of INR 200, 000/- per annum for self will be 
                    provided by the Company. The sum assured can be enhanced to Rs.10,00,000 per annum on payment of additional premium. The HR 
                    Department can provide further details on the same.
            </div>
            <br />
            <br />
            <div>
                I have read and understood the terms and conditions of the letter contained herein and I am happy to accept them for employment at
                 the Company. 
            </div>
            <br />
            <table style="float: left">
                <tr>
                    <td>Signature
                    </td>
                    <td>:
                    </td>
                    <td>
                        <input id="Text20" type="text" runat="server" style="width: 150px; height: 20px; border: none; font-weight: 500" />
                    </td>
                </tr>
            </table>
            <table style="float: right">
                <tr>
                    <td>Date
                    </td>
                    <td>:
                    </td>
                    <td>
                        <input id="Text19" type="text" runat="server" style="width: 150px; height: 20px; border: none; font-weight: 500" />
                    </td>
                </tr>
            </table>

            <br />
        <asp:Button ID="printButton" runat="server" Text="Print" OnClick="btnPrint_Click" class="btn btn-info pull-right" /><br />
             </div>
                                                
                                           </fieldset>
                                       </div></div>
              </div></div>
       
        </asp:Panel>
        
       
              </div>
             </div>
              
    </form>
</body>
</html>
