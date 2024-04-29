<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sodexodeclerationform.aspx.cs" Inherits="onboarding_sodexodeclerationform" %>

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
            margin: 0px 0px 196px 120px;
            padding: 0px;
            border: none;
            width: 696px;
        }

            #page_1 #dimg1 {
                position: absolute;
                top: 0px;
                left: 405px;
                z-index: -1;
                width: 171px;
                height: 60px;
            }

                #page_1 #dimg1 #img1 {
                    width: 171px;
                    height: 60px;
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
            font: 16px 'Times New Roman';
            line-height: 19px;
        }

        .ft1 {
            font: bold 21px 'Times New Roman';
            line-height: 24px;
        }

        .ft2 {
            font: bold 16px 'Times New Roman';
            line-height: 19px;
        }

        .p0 {
            text-align: left;
            margin-top: 50px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            margin-top: 2px;
            margin-bottom: 0px;
        }

        .p3 {
            text-align: left;
            margin-top: 17px;
            margin-bottom: 0px;
        }

        .p4 {
            text-align: left;
            padding-left: 193px;
            margin-top: 36px;
            margin-bottom: 0px;
        }

        .p5 {
            text-align: left;
            padding-right: 184px;
            margin-top: 38px;
            margin-bottom: 0px;
        }

        .p6 {
            text-align: left;
            margin-top: 15px;
            margin-bottom: 0px;
        }

        .p7 {
            text-align: left;
            margin-top: 1px;
            margin-bottom: 0px;
        }

        .p8 {
            text-align: left;
            margin-top: 37px;
            margin-bottom: 0px;
        }

        .p9 {
            text-align: left;
            margin-top: 36px;
            margin-bottom: 0px;
        }

        .p10 {
            text-align: left;
            margin-top: 18px;
            margin-bottom: 0px;
        }

        .p11 {
            text-align: left;
            margin-top: 72px;
            margin-bottom: 0px;
        }
    </style>
    <script src="js/popup.js"></script>
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
                <div>
                    <img src="../upload/logo/client-logo.png" style="float: right; padding-top: 50px;">
                </div>
                <div class="dclr"></div>
                <p class="p0 ft0">The HR Manager</p>
                <p class="p1 ft0">AB Mauri India Pvt. Ltd.,</p>
                <p class="p2 ft0">Bangalore</p>
                <p class="p3 ft0">Dear Sir,</p>
                <p class="p4 ft1">Food Coupons Declaration</p>
                <p class="p5 ft0">I hereby authorize you to deduct Rs.1,300/= per month from my Supplementary Allowance in lieu of Food Coupons.</p>
                <p class="p6 ft2">
                    Emp. No. :
                    <asp:Label ID="txtempcode" runat="server" Font-Bold="true"></asp:Label>
                </p>
                <p class="p7 ft2">
                    Emp. Name :
                    <asp:Label ID="txtfirstname" runat="server" Font-Bold="true"></asp:Label>
                </p>
                <p class="p8 ft0">
                    You may commence deduction with effect from
                    <asp:TextBox ID="tt" runat="server" Style="border: none" Width="100px"></asp:TextBox>
                    (month & year).
                </p>
                <p class="p9 ft0">Thanking you.</p>
                <p class="p10 ft0">Yours truly</p>
                <p class="p11 ft2">Singature :</p>
                <p class="p10 ft2">Date :</p>
                <br />
                <br />
                <br />
                <br />


            </div>
        </asp:Panel>
    </form>
</body>
</html>
