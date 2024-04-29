<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferLetterDetails.aspx.cs" Inherits="Forms_OfferLetterDetails" EnableEventValidation="false" %>

<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>--%>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <%--<link id="lnk_style_css" href="../icomoon/style.css" rel="stylesheet" />--%>
    <%--<link id="lnk_style_css" href="style.css" rel="stylesheet" />--%>
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <%--<link href="../css/nvd-charts.css" rel="stylesheet" />--%>
    <%--<link href="nvd-charts.css" rel="stylesheet" />--%>

    <!-- Bootstrap css -->
    <%--<link href="../css/main.css" rel="stylesheet" />--%>
    <%--<link href="main.css" rel="stylesheet" />--%>

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

    </style>
    <script type="text/ecmascript">
        function hide() {
            var x = document.getElementById('btn_print');
            x.style.display = 'none';
            var y = document.getElementById('div_letter');
            y.style.display = 'block';
            var z = document.getElementById('btn_back');
            z.style.display = 'none';
            var e = document.getElementById('btn_export');
            e.style.display = 'none';
        }
        function show() {
            var y = document.getElementById('div_letter');
            
            y.style.display = 'block';
        }
        function style()
        {
            var firstLink = document.getElementsByTagName('lnk_style_css')[0];
            firstLink.parentNode.removeChild(firstLink)
        }
    </script>
    
</head>
<body>
   <asp:Panel ID="pnl" runat="server" >

        <form id="myForm" runat="server" style="width: 100%">
            <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>--%>
            <div id="dv_content" runat="server" style="margin-left: 0px; padding: 10px 0px 10px 0px; background-color: white; border-color: #1b478e;">
                <div id="div_letter" runat="server">
                    <div>
                        <table id="tbl_btn" runat="server" style="width: 90%; text-align: justify; margin: 10px 5px 10px 5px">
                            <tr>
                                <td>
                                    <asp:Image ID="img_logo" runat="server" ImageUrl="~/images/Escalon_logo.png" Width="150px" />
                                </td>
                                <td id="td_btn" runat="server">
                                    <asp:Button ID="btn_back" runat="server" Text="Back" title="Go Back" OnClick="btn_back_Click" CssClass="btn btn-info" />&nbsp;&nbsp;
                                <asp:Button ID="btn_print" runat="server" OnClientClick="hide();window.print()" Text="Print" title="print" CssClass="btn btn-info" />&nbsp;&nbsp;
                                 <asp:Button ID="btn_export" runat="server" Text="Export To Word" title="Export to Word" OnClick="btn_export_Click" CssClass="btn btn-info" />&nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                        </table>
                        <table style="width: 95%; text-align: justify; font: bold; font-size: 15px; font-weight: 500; margin: 10px 5px 10px 15px">
                            <tr>
                                <td style="font: bold; font-size: 14px; font-weight: 800;text-decoration:underline">Offer Letter 
                                </td>
                            </tr>
                            <%--<tr>
                                <td>
                                    <asp:Label ID="txt_offer_letter" runat="server" Style="border: none; text-decoration: underline; padding: 0px 0px 4px 3px" placeholder="Enter offer letter"></asp:Label>
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>HR&nbsp;<asp:Label ID="txt_HR_1" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_HR_2" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_offer_letter" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter offer letter"></asp:Label> </b>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td>Date&nbsp;<asp:Label ID="txt_date_1" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter date"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px"><b>Hii&nbsp;<asp:Label ID="txt_candidate_name" runat="server" Style="border: none; padding: 0px 0px 3px 3px" placeholder="Enter name"></asp:Label></b>
                                </td>
                            </tr>
                            
                            <tr>
                                <td>Based on our recent discussions with you, we are pleased to extend you an offer to join Escalon Business Services Private Limited in India; Mohali. This letter will officially confirm your annual total earning potential and terms of your employment.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="">Date of Joining:
                                <asp:Label ID="txt_doj" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter date of join"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Timing’s: These will be as per the needs of the client and the company. 
                                </td>
                            </tr>
                            <tr>
                                <td>Role –
                                    <asp:Label ID="txt_role" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter role"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>Segment-<asp:Label ID="txt_segment" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter segment"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>Your annual total cash compensation will be INR
                                <asp:Label ID="annual_tot_cash" runat="server" Style="border: none; padding: 0px 0px 4px 2px" placeholder="Enter INR cash"></asp:Label>
                                    and will be structured as per the attached
                                </td>
                            </tr>
                            <tr>
                                <td>Annexure 1 – Compensation Details. This will continue to be applicable until further communication on the same. Your annual total earning potential includes:
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>- Annual fixed compensation of INR 
                                <asp:Label ID="txt_fixed_compensation" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter INR"></asp:Label>
                                    ; this includes allowances and statutory benefits and will be structured in accordance with the Company’s compensation guidelines. The said amount includes employer’s contribution to Provident Fund, as applicable.
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>On joining you may undergo a training program to acquire the knowledge to enable you to successfully perform to the expectations of the position for which you are being considered for employment. This offer and your employment with Escalon are contingent upon you successfully completing the training program, as per the satisfaction of Escalon standards. Failing which, Escalon may, in its sole discretion, elect to terminate or suspend your employment giving 15 days’ notice.
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>This offer is contingent on us working together to determine an appropriate start date for your employment. This letter and this offer are valid for seven (7) days from the date of this letter.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>You are required to provide copies of all mandatory documents required by the Company before joining with in first 7 days to close the position officially. The offer of employment and your employment with the Company is dependent on timely submission of such required documents. Non furnishing of mandatory document/s within the specified time shall result in termination of employment.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>We look forward to hearing from you regarding your decision to join our team. In the meantime, please feel free to call us.
                                </td>
                            </tr>
                           <%-- <tr>
                                <td>
                                    <br /><br /><br /><br /><br />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align:right">
                                    Page-1
                                </td>
                            </tr>--%>
                          
                        </table>
                    </div>

                    <div>
                        <table style="width: 95%; text-align: justify; font: bold; font-size: 15px; font-weight: 500; margin: 10px 5px 10px 15px">
                            <tr>
                                <td>Please send two references of previous employment for internal process (Reference check) and your acceptance in reply to this mailer to confirm us officially to close the opening.
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>We believe you have a successful career ahead of you and look forward to your joining us.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>For Escalon Business Services Pvt Ltd
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="font-family: Brush Script MT; font-size: 20px">Ritu Chitra
                                </td>
                            </tr>
                             <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>Ritu Chitra
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 13px; font-weight: 600">HR Manager 
                                </td>
                            </tr>
                            <tr>
                                <td style="font: bold; font-weight: 600">Authorized Signatory
                                </td>
                            </tr>
                            <%-- <tr>
                                <td style="text-align:right">
                                   Page-1
                                </td>
                            </tr>--%>
                          <%--  <tr>
                                <td><br /></td>
                            </tr>--%>
                            <tr>
                                <td style="font: bold; font-weight: 600">ACKNOWLEDGED AND AGREED:
                                </td>
                            </tr>
                           
                            <tr>
                                <td>
                                    <asp:Label ID="txt_fullname" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter full name"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="font: bold; font-weight: 600">[Insert full name] Candidate’s signature:&nbsp;<asp:Label ID="txt_signature" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr>
                                <td style="font: bold; font-weight: 600">Date:
                                <asp:Label ID="txt_date" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter date here"></asp:Label>
                                </td>
                            </tr>
                             <tr>
                                <td><br /></td>
                            </tr>
                              <tr>
                                <td style="text-align:right">
                                   Page-1
                                </td>
                            </tr> 
                            <tr>
                                <td><br /></td>
                            </tr>
                            <tr>
                                <td style="text-align: center; font-weight: 500; font-size: 14px">ANNEXURE 1
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>Your compensation is as mentioned below:
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>
                                    <table style="width: 100%; border: 1px solid #808080" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="border-bottom: 1px solid #808080; width: 50%; padding: 6px 5px 6px 10px; font-weight: 500; font-size: 12px">Total Cash Compensation
                                            </td>
                                            <td style="border-bottom: 1px solid #808080; width: 50%; padding: 6px 5px 6px 30px"></td>
                                        </tr>
                                        <tr>
                                            <td style="border: none; width: 50%; padding: 5px 5px 5px 50px"></td>
                                            <td style="border: none; width: 50%; padding: 5px 5px 5px 70px">Annual (INR )
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="border-top: 1px solid #808080; border-right: 1px solid #808080; width: 50%; padding: 2px 2px 2px 40px">A)	Annual Compensation
                                            </td>
                                            <td style="border-top: 1px solid #808080; width: 50%; padding: 2px 4px 2px 10px">INR
                                            <asp:Label ID="txt_compn_inr" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter INR here"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td>Any Shift allowance or facility availed will be add-on to CTC.In addition to your annual earning potential, you will be eligible for following benefits, which will be governed by Escalon Policies:
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">1.	Medical Insurance for self, spouse and 3 dependent children will be covered as per Escalon Policy. Premium for this 90% will be paid by Escalon. 
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">You have the option of availing Escalon negotiated rates to cover your parents and any additional child under a separate Insurance plan. The entirepremium for this will have to be borne by you.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">2.	Personal Accident Coverage of INR 5,00,000
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">3.	Gratuity as per The Payment of Gratuity Act, 1972, In case of Gratuity applicability one will also be applicable for Gratuity Multiplier of 5% on actual gratuity amount with every passing
                                   year.The Company may, at any time and in its sole and absolute discretion, amend, suspend, vary and modify any of the terms and conditions of the above mentioned benefits.
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 2px; font: bold; font-weight: 700">DECLARATION
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">I hereby represent and assure that I will be joining on mentioned date and I have not, during the course of any current/previous employer and any other employment or contractor relationships, entered into or agreed to any arrangement.
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">I also assure that I’ll not disclose the salary or bonus figures to anybody. If I do so, I’ll be liable for termination.
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px; font: bold; font-weight: 500">Candidate’s signature&nbsp;______________________<%--<asp:TextBox ID="txt_candidate_sign" runat="server" Style="border: none; text-decoration: underline; padding: 0px 0px 4px 3px"></asp:TextBox>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: 700">REQUIRED DOCUMENTATION:
                                </td>
                            </tr>
                           <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="font: bold; font-weight: 600">To be submitted 
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	2 Passport size photographs
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	2 copy of PAN Card
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	2 copy of Passport 
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	HDFC account #, if any.
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	Certificate of Educational Qualification (10th, +2 , Graduation and Masters If any)
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	Last 3 salary slips
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	Accepted copy of resignation (from Current employer) within 7 days of offer letter 
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 2px 2px 2px 35px">•	Relieving letter at the time of joining
                                </td>
                            </tr>

                        </table>
                    </div>
                    <%--<table>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>--%>
                    <div>
                        <table style="width: 95%; text-align: center; font: bold; font-family: Verdana; font-size: 15px; font-weight: 800; margin: 10px 5px 10px 15px">
                            <tr>
                                <td>---------------------Escalon Business Services Pvt Ltd.---------------------     
                                </td>
                            </tr>
                            <tr>
                                <td>Office: #40A,SP Info City 2nd Floor, Industrial Area, Phase 8B Mobile, Phone : 0172-5013839 Website:www.escalon.services
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br /><br /><br /><br /><br />
                    <div>
                        <table style="width: 95%; margin: 30px 5px 10px 15px">
                            <tr>
                                <td style="text-align:right">Page-2
                                </td>
                            </tr>
                        </table>
                    </div>
                    <br /><br />
                </div>
            </div>

        </form>

   </asp:Panel>
</body>
</html>

