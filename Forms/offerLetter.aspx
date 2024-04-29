<%@ Page Language="C#" AutoEventWireup="true" CodeFile="offerLetter.aspx.cs" Inherits="Forms_offerLetter" %>

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
        .letterHead
        {
            padding-top: 140px;
            padding-bottom: 100px;
        } 
         .letterHeadCustom
        {
            padding-top: 280px;
            padding-bottom: 100px;
        } 
         .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
        }
    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }
        function letterHead() {
            document.getElementById("letterHead").setAttribute("class", "letterHead");
            document.getElementById("letterHeadOne").setAttribute("class", "letterHead");
            document.getElementById("letterHeadTwo").setAttribute("class", "letterHeadCustom");
            document.getElementById("letterHeadThree").setAttribute("class", "letterHeadCustom");
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
                                        <div class="control-group" style="padding-right: 10px; margin: 20px 20px 20px 20px;">
                                            <div id="letterHead">
                                                
                                                <table class="body">
                                                    <tr>
                                                        <td>
                                                            <input type="text" id="Text14" title="Please Enter Date " runat="server" placeholder="Date:" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" /></span>
                                                <br />
                                                <br />
                                                <br />
                                                <p>
                                                    We are pleased to offer you a position as 
                                                    <input type="text" id="Text15" title="Please enter Designation & Department" runat="server" placeholder=" Designation & Department" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    with Escalon Business Services Pvt. Ltd(“Company”) with effect from 
                                                        <input type="text" id="Text5" title="Please enter Date of Joining" runat="server" placeholder=" Date of Joining" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    .
                                                </p>
                                                <p>
                                                    As a consumer based Internet Company focused primarily on human expressions, we’ve transformed a
regular place of work to make it a melting pot of cultures from around the world that defines human
relationships through online content. Such an environment needs the freedom to innovative and the
space for personal growth whilst keeping the system dynamic and ready to set new standards in the
world of online expressions.
                                                </p>
                                                <p>
                                                    We are an equal opportunity employer and believe that we provide the right support to all our
employees to excel and bring out the best in what they do. Our teams are versatile, dynamic and
talented and have established within themselves the coherent passion to reach higher levels of
creative excellence, which is indispensable in the pursuance of a shared dream. Our employees are
passionate about the company’s future and believe in the common goal. Aware of their own
contribution towards the achievement of the same, they set up their own personal and team
objectives in sync with the company’s vision.
                                                </p>
                                                <p>
                                                    As we continue to grow and evolve, our family grows along. Each individual in this Company adds a
little bit of their own to give the Company a unique and diversified character. It is this uniqueness that
gives us a competitive edge over the others in this dynamically changing environment. It is our
endeavor to provide each employee with the creative space to grow as a professional as well as an
individual.
                                                </p>
                                                <p>
                                                    We believe we can provide you with an atmosphere in which you can develop your professional talents
to the fullest. If the attached terms are agreeable, please sign this letter acknowledging your
acceptance. Please do not hesitate to contact us if you need any further assistance.
We look forward to having you in the team.
                                                </p>
                                                <p>
                                                    Yours sincerely,
                                                </p>
                                                <p><b>For Escalon Business Services Pvt. Ltd. </b></p>
                                                <br />
                                                <br />
                                                <br />
                                                <p><b>Authorized Signatory </b></p>

                                            </div>
                                            <br />
                                            <br />
                                            <div id="letterHeadOne">
                                                <p></p>
                                                This offer is subject to the following terms &conditions. Final terms & conditions regarding your
employment will be detailed in the Appointment Letter and will be treated as the final document for all
interpretation.</p><p>
                                                    1. Your initial place of employment will be 
    <input type="text" id="Text6" title="Please enter Location of Employment" runat="server" placeholder=" Location of Employment" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    , India.</p>
<p>2. Your employment will be considered on probation for six (6) months. On successful completion
of the probationary period, you may be for confirmation as a permanent employee. The Company may
terminate your services without notice during the probation period. In case you resign on your own
behalf during this period, you will be required to serve 30 calendar days’ notice subject to completion
of Knowledge Transfer process.
                                                </p>
                                                <p>
                                                    3. During the period of your employment, you will serve honestly, faithfully, diligently and
efficiently for the growth of the Company. You shall conduct yourself in conformity with the code of
conduct, as in force from time to time. You would be required to apply and maintain the highest
standards of personal conduct and integrity and comply with all the policies and procedures of the
Company with punctuality.
                                                </p>
                                                <p>
                                                    4. Your position with the Company calls for whole time employment and you shall devote
yourself exclusively to the functions/operations/business of the Company. You will not take up any
other work for remuneration (part time or otherwise) or work on advisory capacity or be interested
directly or indirectly in any other trade or business, during your employment with the Company,
without written permission from the Company. You additionally warrant that you are not currently
studying for any courses/degrees/classes and that you will not make major time commitments outside
work during your employment with the Company, without written permission from the Company. You
would be required to sign a warranty to this effect after you join us.
                                                </p>
                                                <p>
                                                    5. You will be covered under performance review as per the Company policy guidelines and any
promotions or increments will be made on the basis of performance and will be at the sole discretion
of the Company.
                                                </p>
                                                <p>
                                                    6. Notice Period/Termination — Confirmed employees may terminate their employment with the
Company by giving 60 calendar Days' notice at time of termination/resignation. The company may
terminate this agreement by giving a 30 calendar Days’ notice or basic pay in lieu thereof.
</p>
                                                <p>7. In the event of fraud, theft, misrepresentation or any form of misconduct, your employment
may be terminated by the Company without notice.
                                                </p>
                                                <p>
                                                    8. Confidentiality — The terms of your employment are strictly confidential between you and the
Company. Discussion of your compensation with any other party or employee is grounds for dismissal.
</p>
                                                <p>9. Condition of Hire — All appointments are based on the information furnished by you in your
employment application and all further declarations and undertakings. Hence, any false statement or
information furnished as above will lead to your dismissal without notice.</p>
                                                <p>
10. You hereby warrant that you are not in breach of any contract with any third party or
restricted in any way in your ability to undertake or perform the duties of your employment.</p>
                                                <p>
11. Please note that in case you join after 20th of the month, your first salary will be processed
with following month’s payroll cycle.
                                                </p>
                                                <p>
                                                    12. Non-Competition — In the event that you leave the Company either initiated by yourself or the
Company, you shall not recruit / help recruit any employee from our Company for a period of 12
months commencing the last day of your employment with the Company.</p>
                                                <p>
                                                    13. Governing Law — the terms and conditions as stipulated above shall be interpreted in accordance with the laws of India. In the event of any dispute, the parties shall submit to the exclusive jurisdiction of the Courts of Mohali, India.
                                                </p>
                                            </div>

                                            <div id="letterHeadTwo">
                                                 <br/>       
                                            <b>Your Compensation Package is as follows:-</b> <br/>  
                                            <br /><br />
                                            <%-- table --%>
                                            <div  >
                                            <table class="a">
                                                <tr>
                                                    <td style="flex-align:center;font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px;"><b>Compensation Structure</b> </td>
                                                </tr>
                                            </table>
                                                <table class="a">
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px; width:40%;"><b></b> </td>
                                                     <td style="font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px; width:60%;"><b>Without EPF/PF</b> </td>
                                                </tr>
                                            </table>
                                            <table class="a">
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px; width:40%; "> <B>Description </B></td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px; width:30%;"> <B>Yearly (Rs)</B> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: center; padding: 8px; width:30%;"><B> Monthly (Rs)</B> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b>Base Pay CTC</b> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b> Variable Pay CTC</b></td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b>Total CTC </b></td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b>FIXED </b></td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Basic Salary </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                

                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Housing Rent Allowance </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Medical Reimbursement </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Transportation Allowance </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                
                                                
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Special Allowance </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b>BENEFITS, ANNUITY & RETIRALS</b> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; ">Company Bonus </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "> Leave Encashment</td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b> Total Base CTC</b> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b> Total Variable CTC</b> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>
                                                <tr>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:40%; "><b> Total Annual CTC</b> </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;">  </td>
                                                    <td style="font-size:16px;border: 1px solid #dddddd;text-align: left; padding: 8px; width:30%;"> </td>
                                                
                                                </tr>

                                            </table>

                                            </div>
                                                 </div>
                                            <br /><br /><br />
                                            <div id="letterHeadThree">
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
                                                   4. Gratuity is paid on separation of employee from the Company, on completion of minimum 5
years of continuous service with the Company. 
                                                </ol>
                                                <ol style="text-align: justify">
                                                    5. Personal Tax — the payments described above will not be further grossed up for taxes
and you will be responsible for the payment of all taxes due with respect to such payments,
which will be deducted at source as per the prevailing rules.
                                                </ol>
                                                <ol style="text-align: justify">
                                                    6. Variable Pay, if applicable, will be paid on hitting specific Milestones as outlined in Exhibit B.
                                                </ol>
                                             

                                                <br />
                                            </div>
                                            </div>
                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide(); window.print();" class="btn btn-info pull-right" /><br />
                                       

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
