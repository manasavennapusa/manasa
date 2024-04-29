<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConfirmationLetter.aspx.cs" Inherits="Forms_ConfirmationLetter" %>

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
            margin-top: 110px;
            margin-bottom: 100px;
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

                                            <div>
                                            
                                            <br />
                                            <br />
                                            <br />
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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name" style=" padding-top:12px; width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" /></span>
                                            <br />
                                            <br />
                                            <br />
                                                <a style="font-size: 17px;">
                                                <center><b>Sub: Confirmation of Employment</b></center>
                                            </a>
                                                <br />
                                            <br />
                                            <br />
                                          <p>
                                              We are pleased to inform you that after conducting a review of your performance during your probation period, your
services have been found to be satisfactory as per the requirements of the position.
                                          </p>
                                                 <p>
Accordingly, your services are hereby confirmed with the Company on completion of your probation period with effect
from <input title="please enter date in the format DD/MM/YYYY" type="text" style="border-top: none; border-left: none; border-right: none; padding-top:12px; width:100px;" />.
                                          </p>
                                                 <p>
You will be entitled to pay allowances and other perks as applicable as per your appointment letter with effect from the
above date. Other terms & conditions of your services remain the same.
                                          </p>
                                                 <p>
We are confident that you will continuously strive to achieve the Company’s growth plans with the same sincerity and
dedication in years to come.
                                          </p>
                                                <p>
                                                For <b>Escalon Business Services Pvt. Ltd.</b>
                                                    </p>
                                            </div>
                                            <br /><br /><br /><br />
                                            <div>
                                                <p style="font-size:14px">
                                                 <b>Authorised signature</b>
                                                    </p>
                                                

                                            </div>

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
