<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Appointmentletterfinal.aspx.cs" Inherits="Forms_Appointmentletterfinal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>

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
    <script type="text/javascript">
        function disableBtn(btnID, newText) {

            var btn = document.getElementById(btnID);
            setTimeout("setImage('" + btnID + "')", 60000);
            btn.disabled = true;
            btn.value = newText;
        }

        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(12501270608.gif)';
        }
    </script>
    <script src="js/validation.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="dt_example" class="example_alt_pagination">
          

        <div class="dashboard-wrapper"  style="margin-left: 0px;">

            <div class="main-container" runat="server" id="dash" style="border-top:0px  ">
                  <div id="Div1" runat="server" style="margin-left:13px">
         <div class="page-header">
                    <div class="pull-left">
                        <h2> </h2>
                    </div>
                   
                   
                    <div class="clearfix">
                        <asp:Button ID="print" runat="server" OnClientClick="hide(); show(); window.print();" class="btn btn-info pull-right"  Text="Print" style="float:right"/>
                    </div>
                </div>
        
    <p> <b> </b>
          <asp:Image runat="server" ID="img"  Style="margin-left:25px"  ImageUrl="~/images/esclon.jpg" />
        
        <br />
        </p>

          <div class="control-group" style="padding-right: 10px;">

                                            <div id="letterHeadOne">

                                                <table class="body">
                                                    <tr>
                                                        <td>
                                                          
                                                              &nbsp;&nbsp;&nbsp;  <p> <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Letter of Appointment:</b><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;____________________________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date:_____________________ <asp:Label ID="lbldatetime" runat="server"></asp:Label></p>
                                                          <%--  <input type="text" id="Text14" title="Please Enter Letter of Appointment" runat="server" placeholder="Letter of Appointment" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />--%>
                                                        </td>
                                                    </tr>

                                                    <tr>
                                                        <td>
                                                            <p> <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; HR/_____/_____</b>
                                                                <br />
                                                                <br />
                                                                                     
                                                                                     <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ___________________________________ <br />
                                                                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                           ____________________________________<br />
                                                                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                           ____________________________________<br />
                                                                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                           ____________________________________<br />
                                                                                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                           ___________________<b>PIN- </b>_____________<br />
                                                                                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                                                            <%--<input id="Text1" placeholder="HR" type="text" title="Please Enter Employee Name" runat="server" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />--%>
                                                        </td>
                                                    </tr>

                                                  
                                                  



                                                    
                                                </table>
                                               
                                             
                                                    


                                                
                                            
                                                <%-- 1 --%>
                                                <div>
                                                    
                                                    <ol style="text-align: justify">
                                                        <p>  Subject:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Appointment Letter </p>
                                                        <br />
                                                     
                                                        <p><b> Dear______________________</b> </p>
                                                        <br />
                                                        <p>   Congratulations! We are pleased to inform you that you have been appointed as _______________<b>with Escalon  Business Services Pvt. Ltd.  </b>  on the following terms and conditions. </p><br />
                                                       
                                                <p>     
                                                     <b>Designation:</b>
                                                       You have been designated as ____________________. However, your ability and expertise can be utilized in any other field/function in the best interest of the company and there upon you shall be re-designated/promoted accordingly. </p><br />
                                                   <%-- <input type="text" id="Text15" title="Please enter Designation & Department" runat="server" placeholder=" Designation & Department" style="padding-top: 13px; width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />--%>

                                                   <%-- <input type="text" id="Text5" title="Please enter Date of Joining" runat="server" placeholder=" Date of Joining" style="width: 150px; padding-top: 13px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />--%>
                                                    </ol>
                                                   
                                                    

                                                </div>
                                                <%-- 2 --%>
                                                <div>
                                                    

                                                    <ol style="text-align: justify">
                                                        <b>Date of Joining: </b>
                                                       you have joined us on ___________________and this would be considered as your effective Date of Joining in the company. You will be on probation for first six months. Completion of probation period will automatically confirm your regular employment with Escalon; any other condition will be informed. 
                                                    </ol>
                                                    
                                                  
                                                </div>



                                                <%-- 3 --%>

                                           
                                                <ol style="text-align: justify">
                                                         <b>Salary:</b> 
                                                    Your annual cost to company be __________________. Your salary is confidential and should not be disclosed or discussed to any other employee of the organization. In case of disclosure strict actions would be taken.
                                                    <%--<input type="text" id="Text6" title="Please enter Location" runat="server" placeholder=" Location" style="width: 150px; padding-top: 13px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                        , India. However, based on the needs of the
Company, you may be transferred or may have to travel to other locations on work. The Company reserves its
right to decide the place and kind of training to be imparted to you.--%>
                                                </ol>
                                                    
                                                    <ol style="text-align:justify">
                                                        <b> Notice Period: </b>
                                                        Either party may terminate this contract of employment by giving a written notice of ____calendar days without assigning any reasons after confirmation. Before that probation clause will be applicable as per offer letter issued earlier.
                                                    </ol>
                                                   
                                            <ol style="text-align:justify">
                                                  <b> Other terms & Conditions- </b>
                                                you will be on probation for first six months.The other terms and conditions of the employment have been shared in attached format. 
                                                <br />
                                                
We hope to have a long successful professional relationshipwith you and wish you all the very best.
                                                <br />
                                                <br />
                                             
                                                 <br />
                                                 <p> For <b> Escalon Business Services Pvt Ltd </b></p>
        <p style="font-style:oblique"> Ritu Chitra &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;  <l style="font-style:normal">Signature of Acceptance </l> </p>
        <p> <p> Ritu Chitra<br />
            <b> HR Manager</b> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Name:</p>
     <p>Authorized Signatory&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;  Date:</p>
                                               


                                            </ol>
                                            </div>
                                            <br />

                                           <p style="margin-left:33px"> <b> <u>Important points:</u> </b></p>
                                            <p style="margin-left:33px" >    1.	This offer of appointment is valid only till the date of joining you have accepted and committed as above and it will automatically cease in the event of your not joining us by the said date. ( same as above)<br />
                                      2.	The Employee is liable to be transferred from one job to another job or from one department to another     department or from one shift to another or from one establishment to another establishment if required by the Management. Any such changes in assignment or transfer will not automatically entitled to any additional remuneration, allowance, compensation, or other sum in respect thereof. <br />
                               <b> 3.	Company Property:  </b> The Employee will always maintain in good condition company property, which may be entrusted for official use during the term of the agreement and shall return all such property to the company prior to relinquishment of the charge, failing which the damages of the same will be recovered from the employee by the company. <br />
               <b>4.	Leave Policy: </b> The Employee is entitled to leave as per leave policy of the company. This will be provided at the time of joining.<br />
               <b> 5.	NON-DISCLOSURE OF INFORMATION: </b> The Employee understands and agree that he shall not, at any time during the continuance or for a period of five years after the termination of the employment here under, divulge either directly or indirectly  to any person, firm or Company or use for himself  or for  another any knowledge, information, end-customer information (names, personal or financial information), formulae, processes, methods, compositions, ideas or documents, concerning the business and affairs of the company or any of its dealings, transactions or affairs which the employee may acquire from the company or any of its dealings, transactions or affairs which he may acquire or have gained  knowledge during the course of and incidental to the employment.<br />
               <b> 6.	TERMINATION : </b><br />
             6.1.	For Separation/Termination the following Terms and Conditions will hold:<br />
               6.1.1.	Either party may terminate the services with ______ days’ notice without assigning reasons.<br />
               6.1.2.	Notice period is meant to ensure completion of jobs already taken, transfer ongoing jobs, smooth transition and provide for time to get suitable replacement. Failing to fulfill this commitment and purely at the discretion of the employer, for any risk whatsoever, the employee will be required to pay to the employer without demur, and on demand, a sum not exceeding ________ days Gross Salary as was being received by the employee at the time of said notice, as compensation. In the same manner, if the employer wants to dispense with the services of the employee, both notice period and compensation clauses apply to employer. <br />
              6.2.	Notwithstanding anything to the contrary contained herein, the Company shall be entitled to forthwith terminate the appointment without any notice or payment of any kind whatsoever in lieu of notice or otherwise in case of: <br />
              6.2.1.	Any act of dishonesty, disobedience, insubordination, incivility, intemperance, irregularity in attendance or other misconduct or neglect of duty, or incompetence in the discharge of duty or breach of any of the terms, conditions and stipulations contained herein.<br />     
             6.2.2.	On Discovery of any intentional and willful incorrect information provided by the employee to the company in the application for job or during the course of employment.<br />
              6.2.3.	If any declaration given or furnished by the employee to the company in any document submitted for employment proves to be false or if the employee has willfully suppressed any material information, the employee will be liable to be terminated without notice. </p>              

                                                <p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; ______________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;_____________________<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (Employee’s Signature)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Employer&#39;s Signature)</p>
                                      
                                                </div>
                                            </div>
                                            <div id="letterHeadFour">
                                                
                                                <div>
                                                     <center>  <p> <u>   <b>IT Department Acceptable Use Policy</b>  </u></p>   </center> 
                                                
                                                    <ol style="text-align: justify">
                                                        •	Employees are responsible for exercising good judgment regarding the reasonableness of personal use. Individual departments are responsible for creating guidelines concerning personal use of Internet/Intranet/Extranet systems.<br />
                                                        •	For security and network maintenance purposes, authorized individuals within Escalon may monitor equipment, systems and network traffic at any time, per IT Department's Audit Policy. <br />
                                                        •	Under no circumstances is an employee of Escalon authorized to engage in any activity that is illegal under local, state, federal or international law while utilizing Escalon-owned resources.<br />
                                                        •	Unauthorized copying of copyrighted material including, but not limited to, digitization and distribution of photographs from magazines, books or other copyrighted sources, copyrighted music, and the installation of any copyrighted software for which Escalon or the end user does not have an active license is strictly prohibited. <br />
                                                        •	Revealing your account password to others or allowing use of your account by others. This includes family and other household members when work is being done at home.<br />
                                                        •	Providing information about, or lists of, Escalon employees to parties outside Escalon.<br /> 
                                                        •	The official sites and accounts like Skype, Outlook, and Share file, Basecamp or any other are not to be used for personal use. They are strictly to be used for official purpose.<br />
                                                        <br />

                                                        <b> &nbsp; &nbsp;    Enforcement </b>
                                                        <br />

                                                    <p>Any employee found to have violated this policy may be subject to disciplinary action, up to and including termination of employment. The Company shall be entitled to initiate civil and criminal proceedings relevant under the Indian laws for the time being in force.</p>

                                                    <br />
                                                        <p>&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; ______________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;_____________________<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; (Employee’s Signature)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(Employer&#39;s Signature)</p>
                                               
                                                    </ol>
                                                    
                                                </div>
                                                <%-- 12 --%>
                                                <div>
                                                    <b></b>
                                                    <ol style="text-align: justify">
                                                       
                                                    </ol>
                                                    <br />
                                                </div>
                                                <%-- 13 --%>
                                                
                                                 </div>&nbsp;<div id="extra">
                                <div id="letterHeadFive">
                                    <div>
                                        <b></b>
                                        <ol style="text-align: justify">
                                        </ol>
                                        <br />
                                    </div>
                                    <%-- 15 --%>
                                    <div>
                                        <b></b>
                                        <ol style="text-align: justify">
                                        </ol>
                                        <br />
                                    </div>
                                    <%-- 16 --%>
                                   
                                    <%-- 17 --%>
                                
                                    <%-- 18 --%>
                                   
                                </div>
                            </div>
                                                <%-- 14 --%>
                                            <div id="letterHeadSix">
                                            <div>
                                                <b></b>
                                                <ol style="text-align: justify">
                                                </ol>
                                                <br />
                                                 </div>
                                                <%-- 20 --%>
                                                
                                                <%-- 21 --%>
                                               
                                                <%-- signature --%>
                                                <div>
                                                    
                                                    
                                                    
                          <center>                        <p> <u><b>  ANNEXURE TO THE OFFER OF APPOINTMENT </b></u>    </p>  </center>

                                                    <br />
                                                   
                                                    <br />
                                                                <p> <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<u>Annexure 1</u> </b> </p> <br />
                               &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <b> Employee Name:</b>_________________________________<br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Designation:&nbsp;&nbsp;&nbsp;&nbsp; </b> ___________________________________<br />
                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </b>  &nbsp;___________________________________<br />
                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;  <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date of Joining: </b>___________________________________<br />
                                                    <br />
                                                    <br />
                                                    <b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Breakup of the monthly salary is given below:</b>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />
                                              
                                                    <br />
                                                   
                                                  <center>  <p> <P style="font-size:13px;text-align:center;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%"> Company Confidential&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Escalon Business Services Pvt Ltd.<br />
                                                                                                                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                                  Plot No-40A, SP Info city , Phase 8B <br />
                                                                                                                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                                  Mohali- Punjab<br />
                                                                                                                                                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                                                                                  +91 172 4643839    </P></p></center>

                                                   
                                                    
                                                </div>
                                                </div>
                                             <div id="letterHeadSeven">
                                                 <center>
                                                     <b></b></center>
                                                
                                               
                                            <%-- 20 --%>
                                           
                                           <%-- <div>
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
                                                        <td style="font-size: 16px; border: 1px solid #dddddd; text-align: left; padding: 8px; width: 40%;"><b>BENEFITS, ANNUITY &amp; RETIRALS</b> </td>
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
                                            </div>--%>
                                            </div>
    
                                           
                                            
                                            <div id="letterHeadEight">
                                                <b</b>
                                                <ol style="text-align: justify">
                                                   
                                                </ol>
                                                <ol style="text-align: justify">
                                                   
                                                </ol>
                                                <ol style="text-align: justify">
                                                    
                                                </ol>
                                                <ol style="text-align: justify">
                                                    
                                                </ol>
                                                <ol style="text-align: justify">
                                                   
                                                </ol>
                                                <ol style="text-align: justify">
                                                    
                                                </ol>
                                                <ol style="text-align: justify">
                                                    
                                                </ol>
                                                <ol style="text-align: justify">
             
                                                </ol>


                                                <br />
                                            </div>

                                            <br />
                                            <br />
                <br />
                                        </div>

                                    </fieldset>
                                </div>
            </div>
                          <%--  </div>
                        </div>
         </div>--%>
                 <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#dvpage').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
        <script>
            function hide() {
                var x = document.getElementById('print');

                x.style.display = 'none';

                var y = document.getElementById('dash');

                x.style.display = 'none';

            }

            function show() {
                var y = document.getElementById('Div1');
                y.style.display = 'block';
            }
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
    </form>
 
</body>
</html>
