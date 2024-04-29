<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bankdetailsform.aspx.cs" Inherits="onboarding_bankdetailsform" %>

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
            margin: 45px 0px 187px 0px;
            padding: 0px;
            border: none;
            width: 750px;
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
            font: 23px 'Cambria';
            color: #808080;
            line-height: 27px;
        }

        .ft1 {
            font: bold 16px 'Cambria';
            line-height: 19px;
        }

        .ft2 {
            font: 16px 'Cambria';
            line-height: 55px;
        }

        .ft3 {
            font: 16px 'Cambria';
            line-height: 19px;
        }

        .ft4 {
            font: bold 16px 'Cambria';
            line-height: 11px;
        }

        .ft5 {
            font: 14px 'Cambria';
            line-height: 16px;
        }

        .p0 {
            text-align: center;
            padding-left: 25%;
            margin-top: 23px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            padding-left: 125px;
            margin-top: 50px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            padding-left: 125px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p3 {
            text-align: left;
            padding-left: 125px;
            padding-right: 125px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p4 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p5 {
            text-align: right;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p6 {
            text-align: right;
            padding-right: 124px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p7 {
            text-align: left;
            padding-left: 531px;
            margin-top: 3px;
            margin-bottom: 0px;
        }

        .td0 {
            padding: 0px;
            margin: 0px;
            width: 149px;
            vertical-align: bottom;
        }

        .td1 {
            padding: 0px;
            margin: 0px;
            width: 36px;
            vertical-align: bottom;
        }

        .tr0 {
            height: 35px;
        }

        .tr1 {
            height: 38px;
        }

        .tr2 {
            height: 66px;
        }

        .tr3 {
            height: 11px;
        }

        .tr4 {
            height: 68px;
        }

        .tr5 {
            height: 57px;
        }

        .tr6 {
            height: 39px;
        }

        .tr7 {
            height: 91px;
        }

        .t0 {
            /*width: 185px;*/
            margin-left: 125px;
            font: 16px 'Cambria';
        }
    </style>
    <script src="js/popup.js"></script>
    <script type="text/javascript">
        function ValidateEmpcode() {
            var empcode = document.getElementById('<%=txt_employee.ClientID %>');
            if (empcode.value == "") {
                empcode.focus();
                alert("Please select empcode");
                return false;
            }
           
        }
        function isKey(keyCode) {

            return false;

        }
    </script>
</head>
<body>
    <form id="Form1" runat="server" style="background-color: white">

        <table cellpadding="5" cellspacing="3" style="padding: 20px">
            <tr>
                <td>Employee Code/Name
                </td>

                <td>
                    <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                </td>

                <td>
                    <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Details" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
                    &nbsp;&nbsp;
                         <asp:Button ID="btnprint" runat="server" CssClass="btn btn-info pull-right " Text="Print" OnClick="btnprint_Click" OnClientClick="return ValidateEmpcode();" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnl1" runat="server">
            <div id="page_1">
                <div>
                    <img src="../upload/logo/client-logo.png" style="float: right;">
                </div>

                <div class="dclr"></div>
                <p align="center" style="font: 23px 'Cambria'; color: #808080; line-height: 27px;">Bank Account Details Form</p>
                <p class="p1 ft1">To</p>
                <p class="p2 ft1">H. R. Department</p>
                <p class="p2 ft1">A B Mauri India Pvt. Ltd.,</p>
                <p class="p2 ft1">Bangalore</p>
                <p class="p3 ft2 " style="width: 1000px">I would like my salary to be paid directly into my bank account, bank details given below:‐</p>
                <table cellpadding="10" cellspacing="10" class="t0">
                    <tr>
                        <td>Employee Name</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txtfirstname" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Employee Code</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txtempcode" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Contact No</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txtmobileno" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <br />
                <p class="p2 ft1 ">BANK DETAILS</p>
                <br />
                <table cellpadding="10" cellspacing="10" class="t0">
                    <tr>
                        <td>Name of Bank</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txt_bank_name" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Address of Bank</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox Style="border: none" ID="txt" runat="server" Font-Bold="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>Bank Account No.</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txt_bank_ac" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Branch</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox Style="border: none" ID="txt_bankbrachname" runat="server" Font-Bold="true"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td>IFSC Code</td>
                        <td>:</td>
                        <td>
                            <asp:Label ID="txt_ifsc" runat="server" Font-Bold="true"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>MICR Code</td>
                        <td>:</td>
                        <td>
                            <asp:TextBox Style="border: none" ID="TextBox1" runat="server" Font-Bold="true"></asp:TextBox></td>
                    </tr>
                </table>
                <br />
                <br />
                <p class="p6 ft3">‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐</p>
                <p class="p7 ft5">SIGNATURE</p>
                <br />
                <br />
                <br />
                <br />
            </div>
        </asp:Panel>

    </form>
</body>
</html>
