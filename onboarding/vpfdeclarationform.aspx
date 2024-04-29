<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vpfdeclarationform.aspx.cs" Inherits="onboarding_vpfdeclarationform" %>

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
            margin: 95px 0px 335px 120px;
            padding: 0px;
            border: none;
            width: 696px;
        }





        .ft0 {
            font: 16px 'Times New Roman';
            line-height: 19px;
        }

        .ft1 {
            font: 16px 'Times New Roman';
            line-height: 18px;
        }

        .ft2 {
            font: 11px 'Times New Roman';
            line-height: 14px;
            position: relative;
            bottom: 7px;
        }

        .ft3 {
            font: bold 16px 'Times New Roman';
            line-height: 19px;
        }

        .ft4 {
            font: 16px 'Times New Roman';
            line-height: 27px;
        }

        .p0 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            margin-top: 33px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            margin-top: 2px;
            margin-bottom: 0px;
        }

        .p3 {
            text-align: left;
            margin-top: 36px;
            margin-bottom: 0px;
        }

        .p4 {
            text-align: left;
            padding-left: 32px;
            margin-top: 36px;
            margin-bottom: 0px;
        }

        .p5 {
            text-align: justify;
            padding-right: 120px;
            margin-top: 36px;
            margin-bottom: 0px;
        }

        .p6 {
            text-align: justify;
            padding-right: 120px;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p7 {
            text-align: left;
            margin-top: 22px;
            margin-bottom: 0px;
        }

        .p8 {
            text-align: left;
            margin-top: 71px;
            margin-bottom: 0px;
        }

        .p9 {
            text-align: left;
            margin-top: 1px;
            margin-bottom: 0px;
        }
    </style>
     <script type="text/javascript">
         function ValidateEmpcode() {
             var empcode = document.getElementById('<%=txt_employee.ClientID %>');
            if (empcode.value == "") {
                FName.focus();
                alert("Please select empcode");
                return false;
            }
         }
         function isKey(keyCode) {
             return false;
         }
    </script>
      <script src="js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">

        <div>
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
        </div>
        <asp:Panel ID="pnl1" runat="server">
            <div id="page_1">
                <p class="p0 ft0">Date:</p>
                <p class="p1 ft0">The Trustees</p>
                <p class="p0 ft0">Burns Philp India Pvt. Ltd. Employees’ Provident Fund</p>
                <p class="p0 ft1">Azimganj House, 7 Camac Street</p>
                <p class="p0 ft0">Block 7, 3<span class="ft2">rd </span>Floor,</p>
                <p class="p2 ft0">Kolkata 700017</p>
                <p class="p3 ft0">Dear Sirs,</p>
                <p class="p4 ft3">Sub: Notice for the deduction of Voluntary Contribution under Rule – 12©</p>
                <p class="p5 ft4">I,  <asp:TextBox ID="txtname" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:TextBox> member of the Burns Philp India Pvt. Ltd., Employees’ Provident Fund intend to make voluntary contribution @ (12) % or Rupees</p>
                <p class="p6 ft4"> <asp:TextBox ID="TextBox1" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:TextBox> only per month with effect from  <asp:TextBox ID="TextBox2" runat="server" Style="border: none" Width="150px" Font-Bold="true"></asp:TextBox> from my salary in respect of the Voluntary Contribution with effect from the month of  <asp:TextBox ID="TextBox3" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:TextBox> until further instructions, and to pay the same to the Trustees of the Provident Fund vide Rules 12 © and 13 (a) & (c) of the Rules and Regulations of the Provident Fund</p>
                <p class="p7 ft0">Yours faithfully</p>
                <p class="p8 ft3">Signature of the Member</p>
                <p class="p0 ft3">Empl No:</p>
                <p class="p9 ft3">Name:</p>
            </div>
        </asp:Panel>

    </form>
</body>
</html>
