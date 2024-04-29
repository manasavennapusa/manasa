<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fFSLetter.aspx.cs" Inherits="Forms_fFSLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <style >
        table.a
        {
            font-family: arial, sans-serif;
            border-collapse: collapse;
            width: 100%;
        }
        .letterHead
        {
            margin-top: 110px;
            margin-bottom: 100px;
        }

    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
        }

        function letterHead() {
            document.getElementById("letterHead").setAttribute("class", "letterHead");
        }

</script>

    <style>
        .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <asp:ScriptManager ID="rr" runat="server"></asp:ScriptManager>
                <asp:Panel ID="pnl1" runat="server" Style="margin-top: 20px">

                    <div class="row-fluid" style="padding-left: 20px; padding-right: 20px;">
                        <div class="span11">
                            <div >
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group" style="padding-right:10px;">
<div id="letterHead">


                                            <table class="body">
                                                <tr>
                                                    <td>
                                                        <input type="text" id="Text14" title="Please Enter Date " runat="server" placeholder="Date " style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name"" style="width: 100px; padding-top:13px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight:bold " />,</span>
                                            <br />
                                            <br />
                                            <br />
                                           
                                            <div>
                                                <span style="margin-left: 4px; text-align: justify"> With reference to your release, please find enclosed herewith cheque no.”
                                                    <input type="text" id="Text5" title="Please enter Cheque No " runat="server" placeholder=" Checque No" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />"
                                                    dated
                                                    <input type="text" id="Text7" title="Please enter Date " runat="server" placeholder=" Date" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />
                                                    for Rs.
                                                    <input type="text" id="Text8" title="Please enter Rupees " runat="server" placeholder=" Rupees" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />/-'
                                                       drawn on HDFC Bank Ltd.
Central Plaza Branch, Mohali-1600593, towards full & final settlement of all of your past,
present & future benefits, salary, compensations and / or any other dues /
entitlements concerning your employment, with Escalon Business Services Pvt. Ltd.
                                                </span>
                                                <br />

                                                <span style="margin-left: 4px; text-align: justify">You confirm that you have returned all the assets and information including but
not limited to equipments, files, emails, accounts, documents, data of
IntraSoft Technologies Limited and its associated companies and their clients that
were in your possession by virtue of your position in the organization. There are no
data, documents of the company in your possession and if you find anything
with you in the future, you will return the same to the company promptly and
will not use the same for any other purpose or benefits.
                                                </span>
                                                <br />
                                                 <span style="margin-left: 4px; text-align: justify">
                                                You shall not divulge any information of the company which passed on to
you during the course of your job in the company, to anyone. You, further confirm
that you are no longer entitled to any services and / or benefits that were made
available to you while you were working with us and you are not enjoying any
service and / or benefits provided to you during your employment post your
release.
                                                 </span>
                                               
                                                 
                                            </div>
                                          <br/>

                                            <%-- signature --%>
                                            <div>
                                                
                                             <b>  For Escalon Business Services Pvt. Ltd.</b>
                                            <br/><br/>
                                             
                                            <br/><br/>
                                             <b>  Authorized Signatory </b>
                                                 <br/>
                                                 <span style="margin-left: 4px; text-align: justify">
                                               This is to certify that I have gone through and understood all the above terms and
conditions mentioned in this settlement letter and I hereby accept and agree to abide by
them. I have also verified the settlement cheque amount and confirm that this amount is
in full & final settlement of all of my past, present & future benefits, salary,
compensations and / or any other entitlements concerning my employment, with
Escalon Business Services Pvt. Ltd. and that I confirm that there is nothing outstanding or
payable to me.
                                                 </span>
                                            <br/><br/>

                                                </div>
                                            <table>
                                                    <tr>
                                                        <td style="width:50%">
                                                            Date:
                                                        </td>
                                                        <td style="width:50%">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Signature:

                                                        </td>
                                                    </tr>

                                                    
                                            </table>
                                             <br />
                                             <table>
                                                    <tr>
                                                        <td style="width:50%">
                                                            Place: Kolkata
                                                        </td>
                                                        <td style="width:50%">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Name in full:

                                                        </td>
                                                    </tr>

                                                    
                                            </table>
                                         
                                            <br />
                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide(); window.print();" class="btn btn-info pull-right" /><br />
                                        </div>
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
