<%@ Page Language="C#" AutoEventWireup="true" CodeFile="preEmploymentContract.aspx.cs" Inherits="Forms_preEmploymentContract" %>

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
    </style>
    <style>
        .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
        }

        .letterHead
        {
            padding-top: 110px;
            padding-bottom: 100px;
        }
        .letterHeadExtra
        {
            padding-top: 190px;
            padding-bottom: 100px;
        }
        input.padding
        {
            padding-top:13px;
        }
        .auto-style1
        {
            width: 723px;
        }
        .auto-style2
        {
            width: 647px;
        }
        .auto-style3
        {
            width: 689px;
        }
    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }
        function letterHead() {
            document.getElementById("letterHead").setAttribute("class", "letterHead");
            document.getElementById("letterHeadOne").setAttribute("class", "letterHeadExtra");
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

                                                <br />
                                                <br />
                                                <br />

                                                <a style="font-size: 17px;">
                                                    <center><b>Pre-Employment Contract</b></center>
                                                </a>
                                                <br />
                                               
                                                <p>
                                                    This Pre – Employment Contract (“Agreement”) is made 
                                              <input class="padding" type="text" id="Text15" title="Please enter Date" runat="server" placeholder=" Date" style="width: 50px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    this day of, 
                                                  <input type="text" id="Text5" title="Please enter Year" runat="server" placeholder=" Year" style="width: 50px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    by and
between Escalon Business Services Pvt. Ltd, a company incorporated under the Companies Act, 1956 and
having its Registered Office at<b> 502 A Prathamesh, Raghuvanshi Mills Compound, S.B.Marg,
Lower Parel, Mumbai – 400013</b> (hereinafter called “the Company”, which name shall mean and
include its legal representatives and assigns of the first part);
                                              <br />
                                                    <br />
                                                   <center>  And</center>
                                              <br />
                                                    <br />

                                                    <input class="padding" type="text" id="Text6" title="Please enter Full name of candidate" runat="server" placeholder=" Full name of candidate" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    aged about 
                                                   <input class="padding" type="text" id="Text7" title="Please enter Age" runat="server" placeholder=" Age" style="width: 50px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    years, s/o 
                                                      <input class="padding" type="text" id="Text8" title="Please enter Fathers name" runat="server" placeholder=" Fathers name" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    resident of
                                                    <input class="padding" type="text" id="Text9" title="Please enter Full address as per address proof" runat="server" placeholder=" Full address as per address proof" style="width: 550px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    (Hereinafter called “the Candidate”).
                                                    <p>
                                                    </p>
                                                    <p>
                                                        WHEREAS, the Company is an IT Enabled Services Company, and constantly hires professionals for its business;
                                                    </p>
                                                    <p>
                                                        WHEREAS the Candidate is one such
                                                        <input class="padding" type="text" id="Text10" title="Please enter Designation & Department" runat="server" placeholder=" Designation & Department" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                        who has responded to the Company’s recruiting efforts and has attended an interview with the Company for a suitable position in the Company;
                                                    </p>
                                                    <p>
                                                        AND WHEREAS after the interview process, the Company has offered the Candidate, employment in the Company and the Candidate has accepted the employment offer on the following terms:
                                                    </p>
                                                    <p>
                                                        <b>COVENANTS OF THE CANDIDATE:</b>The Candidate hereby accepts the Company’s offer and undertakes as provided below;
                                                    </p>
                                                    <p>
                                                        Compensation (CTC) offered and agreed upon by both Parties: Rs<input class="padding" type="text" id="Text11" title="Please enter Rupees in numbers" runat="server" placeholder="Rupees" style="width: 50px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />.
                                                    </p>
                                                    <p>
                                                        Title/Designation offered and agreed upon by both Parties:
                                                        <input class="padding" type="text" id="Text12" title="Please enter Designation & Department" runat="server" placeholder=" Designation & Department" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                        Date of joining agreed upon by both Parties:
                                                        <input class="padding" type="text" id="Text14" title="Please enter Date of Joining" runat="server" placeholder=" Date of Joining" style="width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />
                                                    </p>
                                                    <p>
                                                        The Candidate has been explained about his/her key responsibilities about the job and the Candidate believes this job to be inline with his/her career growth;<br /> The Candidate has been given a one-time option not to take up the offer after the interview process was completed, if he/she was not satisfied with any of the offer components mentioned above. The Candidate asserts that he/she is satisfied with the offer and hence has not exercised that option and wishes to go ahead with the offer process;
                                                    </p>
                                                </p>
                                            </div>
                                            <div id="letterHeadOne">
                                                <p>
                                                    The Candidate understands that he/she will be required to join the Company as per the Company
offer issued to the Candidate, which is as per the Candidate’s expectations and what the Candidate
has agreed upon;<br />
                                                    If after signing this Agreement, the Candidate does not join the Company, for any reason whatsoever,
the Candidate understands that the Company will suffer substantial financial loss in making attempts
to find another suitable candidate to join in his/her place, in addition to revenue losses due to delays
in the finding another suitable candidate;<br />
                                                    The Candidate understands that promising the Company in writing that he/she will join the Company,
and not joining, is breach of this Agreement;.<br />
                                                </p>

                                                <p>
                                                    In such case when the Candidate does not join the Company, the Candidate understands that the
Company will have the right to initiate appropriate legal proceedings against the Candidate for
recovery of any loss caused to the Company equal to two months basic salary Rs<input class="padding"  type="text" id="Text16" title="Please enter Rupees in words" runat="server" placeholder="Rupees in words" style="width: 350px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />.(In
words)as agreed above;
                                                </p>
                                                <p>
                                                    The draft Appointment Letter is enclosed herewith and the Candidate understands that the same
needs to be accepted and signed when he joins the Company.<br />
                                                    In case of any dispute arising out of or in relation to this Agreement, the jurisdiction to entertain and
try such dispute shall vest exclusively with the courts in Kolkata.<br />
                                                    This Agreement will terminate automatically, on joining of the Candidate and signing of the
appointment letter.<br />
                                                    <br />
                                                    The Candidate accepts the above conditions, out of his/her own freewill, without any coercion.<br />
                                                    <br />
                                                    <b>IN WITNESS WHEREOF</b>, the Parties hereto have caused this Agreement to be executed as of the date
first written above.

                                                </p>
                                                <p>
                                                    Signed for and on behalf of Signed by 
    <input  class="padding" type="text" id="Text17" title="Please enter Full name of candidate" runat="server" placeholder=" Full name of candidate" style="width: 250px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />

                                                </p>
                                                <p>
                                                    <b>Escalon Business Services Pvt. Ltd.</b>
                                                </p>
                                               
                                                 </div>


                                                    <table>
                                                        <tr>
                                                            <td style="width: 60%">
                                                                <b>Authorised Signatory</b>
                                                            </td>
                                                            <td class="auto-style1">Signature
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                    <table>
                                                        <tr>
                                                            <td style="width: 60%">
                                                               Date:
                                                            </td>
                                                            <td class="auto-style2">Date:
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>
                                                <table>
                                                        <tr>
                                                            <td style="width: 60%">
                                                               1. Witness
                                                            </td>
                                                            <td class="auto-style3">2. Witness
                                                            </td>
                                                        </tr>
                                                        
                                                    </table>

                                             
                                           
                                            <br />
                                            <br />
                                            <br />
                                            <br />






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
