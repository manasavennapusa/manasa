<%@ Page Language="C#" AutoEventWireup="true" CodeFile="inductioncomplectionform.aspx.cs" Inherits="onboarding_inductioncomplectionform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            margin-top: 0px;
            margin-left: 0px;
        }

        #page_1 {
            position: relative;
            overflow: hidden;
            margin: 37px 0px 70px 84px;
            padding: 0px;
            border: none;
            width: 732px;
        }

        .dclr {
            clear: both;
            float: none;
            height: 1px;
            margin: 0px;
            padding: 0px;
            overflow: hidden;
        }

        .ft0 {
            font: bold 16px 'Cambria';
            text-decoration: underline;
            line-height: 19px;
        }

        .ft1 {
            font: 16px 'Cambria';
            line-height: 19px;
        }

        .ft2 {
            font: 16px 'Cambria';
            margin-left: 11px;
            line-height: 19px;
        }

        .p0 {
            text-align: left;
            padding-left: 145px;
            margin-top: 145px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p3 {
            text-align: right;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p4 {
            text-align: right;
            padding-right: 47px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p5 {
            text-align: justify;
            padding-left: 24px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p6 {
            text-align: justify;
            padding-left: 24px;
            margin-top: 3px;
            margin-bottom: 0px;
        }

        .p7 {
            text-align: left;
            margin-top: 46px;
            margin-bottom: 0px;
        }

        .td0 {
            padding: 0px;
            margin: 0px;
            width: 235px;
            vertical-align: bottom;
        }

        .td1 {
            padding: 0px;
            margin: 0px;
            width: 98px;
            vertical-align: bottom;
        }

        .td2 {
            padding: 0px;
            margin: 0px;
            width: 376px;
            vertical-align: bottom;
        }

        .td3 {
            padding: 0px;
            margin: 0px;
            width: 146px;
            vertical-align: bottom;
        }

        .tr0 {
            height: 85px;
        }

        .tr1 {
            height: 38px;
        }

        .tr2 {
            height: 64px;
        }

        .tr3 {
            height: 117px;
        }

        .t0 {
            width: 333px;
            font: 16px 'Cambria';
        }

        .t1 {
            width: 522px;
            margin-top: 48px;
            font: 16px 'Cambria';
        }
    </style>
    
</head>
<body>

    <form id="form1" runat="server" style="background-color: white">

        <asp:Button ID="btnprint" runat="server" CssClass="btn btn-info pull-right " Style="margin: 10px; margin-left: 200px" Text="Print" OnClick="btnprint_Click"  />
        <asp:Panel ID="pnl" runat="server">
            <div id="page_1">
                <div>
                    <img src="../upload/logo/client-logo.png" style="margin-top: 10px; float: right">
                </div>
                <div class="dclr"></div>
                <p style="font: bold 16px 'Cambria'; text-decoration: underline; line-height: 19px;" align="center">NEW JOINEES INDUCTION COMPLETION FORM</p>
                <br />
                <p class="p1 ft1">HR Induction Completed for NewJoinee :  
                    <asp:TextBox ID="TextBox1" runat="server" Style="border: none"></asp:TextBox></p>

                <table cellpadding="0" cellspacing="0" class="t0">
                    <tr>
                        <td class="tr0 td0">
                            <p class="p2 ft1">
                                HR Induction Conducted by:
                                <asp:TextBox ID="ss" runat="server" Style="border: none"></asp:TextBox>
                            </p>

                        </td>

                    </tr>
                    <tr>
                        <td class="tr1 td0">
                            <p class="p2 ft1">
                                Date of Joining :
                                <asp:TextBox ID="TextBox2" runat="server" Style="border: none"></asp:TextBox>
                            </p>

                        </td>

                    </tr>
                    <tr>
                        <td class="tr2 td0">
                            <p class="p2 ft1">
                                Dat eof Completion : 
                                <asp:TextBox ID="TextBox3" runat="server" Style="border: none"></asp:TextBox>
                            </p>

                        </td>
                    </tr>
                </table>
                <p class="p1 ft1">The following forms and Policies have been handed over to the new joinee</p>
                <p class="p5 ft1"><span class="ft1">1.</span><span class="ft2">JOINING FORMS</span></p>
                <p class="p5 ft1"><span class="ft1">2.</span><span class="ft2">ANTI BRIBERY POLICY</span></p>
                <p class="p5 ft1"><span class="ft1">3.</span><span class="ft2">ANTI FRAUD POLICY</span></p>
                <p class="p5 ft1"><span class="ft1">4.</span><span class="ft2">TRAVEL POLICY</span></p>
                <p class="p5 ft1"><span class="ft1">5.</span><span class="ft2">IT POLICY</span></p>
                <p class="p5 ft1"><span class="ft1">6.</span><span class="ft2">WHISTLE BLOWER POLICY</span></p>
                <p class="p5 ft1"><span class="ft1">7.</span><span class="ft2">CEO’S STATEMENT ON HEALTH & SAFETY</span></p>
                <p class="p6 ft1"><span class="ft1">8.</span><span class="ft2">TRAVEL REIMBURSMENT FORMS</span></p>

                <p class="p7 ft1">The new joinee,here by agrees that he has readand agreed to abide by the above policies</p>
                <table cellpadding="0" cellspacing="0" class="t1">
                    <tr>
                        <td class="tr3 td2">
                            <p class="p2 ft1">Signature of NewJoinee</p>
                            <p class="p1 ft1">Date: </p>
                            <p class="p1 ft1">Name:</p>
                        </td> 
                        <td>&nbsp;&nbsp;&nbsp;</td>
                        <td class="tr3 td3">
                            <p class="p2 ft1">Signature of Inductor</p>
                            <p>Date: </p>
                            <p class="p1 ft1">Name:</p>
                        </td>
                    </tr>
                </table>


                <br />
                <br />
                <br />
                <br />
            </div>
        </asp:Panel>

    </form>
</body>
</html>
