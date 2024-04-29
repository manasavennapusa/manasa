<%@ Page Language="C#" AutoEventWireup="true" CodeFile="insurancenomform.aspx.cs" Inherits="onboarding_insurancenomform" %>

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
            margin: 0px 0px 78px 91px;
            padding: 0px;
            border: none;
            width: 900px;
            height: 918px;
        }

            #page_1 #dimg1 {
                position: absolute;
                top: 0px;
                left: 60px;
                z-index: -1;
                width: 557px;
                height: 918px;
            }

                #page_1 #dimg1 #img1 {
                    width: 557px;
                    height: 918px;
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
            font: bold 19px 'Century Gothic';
            text-decoration: underline;
            line-height: 23px;
        }

        .ft1 {
            font: bold 14px 'Century Gothic';
            line-height: 17px;
        }

        .ft2 {
            font: 1px 'Century Gothic';
            line-height: 1px;
        }

        .ft3 {
            font: bold 11px 'Calibri';
            line-height: 13px;
        }

        .ft4 {
            font: 1px 'Century Gothic';
            line-height: 7px;
        }

        .ft5 {
            font: bold 10px 'Calibri';
            line-height: 13px;
        }

        .ft6 {
            font: 14px 'Century Gothic';
            line-height: 19px;
        }

        .p0 {
            text-align: left;
            padding-left: 268px;
            margin-top: 37px;
            margin-bottom: 0px;
        }

        .p1 {
            text-align: left;
            padding-left: 62px;
            margin-top: 47px;
            margin-bottom: 0px;
        }

        .p2 {
            text-align: left;
            padding-left: 62px;
            margin-top: 15px;
            margin-bottom: 0px;
        }



        .p4 {
            text-align: left;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p5 {
            text-align: left;
            padding-left: 24px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p6 {
            text-align: left;
            padding-left: 29px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p7 {
            text-align: left;
            padding-left: 18px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p8 {
            text-align: left;
            padding-left: 8px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p9 {
            text-align: left;
            padding-left: 3px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p10 {
            text-align: left;
            padding-left: 9px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p11 {
            text-align: left;
            padding-left: 1px;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p12 {
            text-align: center;
            margin-top: 0px;
            margin-bottom: 0px;
            white-space: nowrap;
        }

        .p13 {
            text-align: left;
            padding-left: 62px;
            margin-top: 61px;
            margin-bottom: 0px;
        }

        .p14 {
            text-align: left;
            padding-left: 62px;
            padding-right: 110px;
            margin-top: 16px;
            margin-bottom: 0px;
        }

        .p15 {
            text-align: left;
            padding-left: 62px;
            margin-top: 11px;
            margin-bottom: 0px;
        }

        .p16 {
            text-align: left;
            padding-left: 68px;
            margin-top: 15px;
            margin-bottom: 0px;
        }

        .td0 {
            border-left: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td1 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 82px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td2 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 7px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td3 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td4 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 135px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td5 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 94px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td6 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td7 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 51px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td8 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 67px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td9 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td10 {
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td11 {
            border-right: #000000 1px solid;
            border-top: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td12 {
            border-left: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td13 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 7px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td14 {
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td15 {
            padding: 0px;
            margin: 0px;
            width: 94px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td16 {
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td17 {
            padding: 0px;
            margin: 0px;
            width: 51px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td18 {
            border-right: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td19 {
            padding: 0px;
            margin: 0px;
            width: 82px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td20 {
            padding: 0px;
            margin: 0px;
            width: 135px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td21 {
            padding: 0px;
            margin: 0px;
            width: 67px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td22 {
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td23 {
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td24 {
            border-left: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td25 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 82px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td26 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 7px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td27 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td28 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 135px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td29 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 94px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td30 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td31 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 51px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td32 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 67px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td33 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td34 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td35 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
            background: #fcd5b4;
        }

        .td36 {
            border-left: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
        }

        .td37 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 82px;
            vertical-align: bottom;
        }

        .td38 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 7px;
            vertical-align: bottom;
        }

        .td39 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
        }

        .td40 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 135px;
            vertical-align: bottom;
        }

        .td41 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 94px;
            vertical-align: bottom;
        }

        .td42 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 5px;
            vertical-align: bottom;
        }

        .td43 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 51px;
            vertical-align: bottom;
        }

        .td44 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 67px;
            vertical-align: bottom;
        }

        .td45 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 53px;
            vertical-align: bottom;
        }

        .td46 {
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 87px;
            vertical-align: bottom;
        }

        .td47 {
            border-right: #000000 1px solid;
            border-bottom: #000000 1px solid;
            padding: 0px;
            margin: 0px;
            width: 6px;
            vertical-align: bottom;
        }

        .tr0 {
            height: 24px;
        }

        .tr1 {
            height: 31px;
        }

        .tr2 {
            height: 7px;
        }

        .tr3 {
            height: 14px;
        }

        .tr4 {
            height: 13px;
        }

        .tr5 {
            height: 22px;
        }

        .tr6 {
            height: 21px;
        }

        .t0 {
            width: 850px;
            margin-top: 82px;
            font: bold 11px 'Calibri';
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
</head>
<body>
    <form id="form1" runat="server" style="background-color: white">

        <div >
            <table cellpadding="5" cellspacing="3" style="padding: 20px">
                <tr >
                    <td style="display:none">Employee Code/Name
                    </td>

                    <td style="display:none">
                        <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                    </td>

                    <td style="display:none">
                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                    </td>
                    <td>
                        <asp:Button style="display:none" ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Details" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
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
                <p style="font: bold 19px 'Century Gothic'; text-decoration: underline; line-height: 23px;" align="center">INSURANCE NOMINATION FORM</p>
                <p class="p1 ft1">To:</p>
                <p class="p2 ft1">Manager – HR</p>
                <p class="p2 ft1">AB Mauri India</p>
                <p class="p3 ft1 ">Bangalore</p>
                <table cellpadding="3" cellspacing="3" width="100%" border="1px">
                    <tr>
                        <td>Emp ID
                        </td>

                        <td>Employee Name
                        </td>

                        <td>Name of the Dependent
                        </td>


                        <td>Date Of Joining
                        </td>

                        <td>Date of Birth
                        </td>

                        <td>Gender
                        </td>

                        <td>Relationship Type
                        </td>

                    </tr>
                    <tr>
                        <td>

                            <asp:TextBox ID="dd" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox1" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox2" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>


                        <td>

                            <asp:TextBox ID="TextBox3" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox4" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox5" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox6" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td>

                            <asp:TextBox ID="TextBox7" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox8" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox9" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>


                        <td>

                            <asp:TextBox ID="TextBox10" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox11" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox12" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox13" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td>

                            <asp:TextBox ID="TextBox14" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox15" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox16" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>


                        <td>

                            <asp:TextBox ID="TextBox17" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox18" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox19" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox20" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td>

                            <asp:TextBox ID="TextBox21" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox22" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox23" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                        </td>


                        <td>

                            <asp:TextBox ID="TextBox24" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox25" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox26" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                        <td>

                            <asp:TextBox ID="TextBox27" runat="server" Style="border: none" Width="100"></asp:TextBox>

                        </td>

                    </tr>
                </table>
                <p class="p13 ft1">Note:</p>
                <p class="p14 ft6">Please note below details of my family for coverage under the Company’s Insurance Plan for Hospitalisation.</p>
                <p class="p15 ft6">Family = self, spouse & children up age of 25 only</p>
                <p class="p16 ft6">Personal accident coverage for self is up to 48 times gross per month.</p>
            </div>
        </asp:Panel>
    </form>
</body>
</html>
