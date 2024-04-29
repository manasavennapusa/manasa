<%@ Page Language="C#" AutoEventWireup="true" CodeFile="commitmentPolicyThree.aspx.cs" Inherits="Forms_commitmentPolicyThree" %>

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
        div.letterHead
        {
            padding-top: 110px;
            padding-bottom: 110px;
        }

        .dashboard-wrapper .main-container
        {
            min-height: 570px;
            border-top: 5px solid white;
            background: white;
            border-radius: 0px 3px 3px;
            padding: 10px 15px;
        }
    </style>
    <script>
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
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

                            <div class="letterHead">
                                <div class="widget-body">
                                    <fieldset>

                                        <div class="control-group" style="padding-right: 10px; margin: 20px 20px 20px 20px;">

                                            <table class="body">
                                                <tr>
                                                    <td>
                                                        <input type="text" id="Text14" title="Please Enter Date of Issue as Per Applicable Date of Refund or Release " runat="server" placeholder="Date of Issue :" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="padding-left: 10px"></td>
                                                </tr>
                                                <tr>
                                                    <td><b>To,</b></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <input id="Text2" placeholder="Employee Name" type="text" title="Please Enter Employee Name" runat="server" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <input id="Text3" type="text" title="Please Enter Permanent Address" runat="server" placeholder="Door Number, Cross " style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        <br />
                                                        <input id="Text26" type="text" title="Please Enter Permanent Address" runat="server" placeholder="Street, Landmark" style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                        <br />
                                                        <input id="Text4" type="text" title="Please Enter Place" runat="server" placeholder="City, State, Pin." style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                    </td>
                                                </tr>





                                                <tr>
                                                    <td style="height: 20px"></td>
                                                </tr>
                                            </table>
                                            <div>
                                                <a style="font-size: 17px; font-weight: 600;">
                                                    <center>Ref: Acknowledgment Receipt of Commitment Document dated 
                                                    <input type="text" placeholder="Date" style="width: 97px; border: none; font-size:17px; padding-top: 13px; font-weight:600" title="Please Enter Date of Issue of Acknowledgement Receipt " />
                                                        
                                                        </center>
                                                </a>
                                                <br />

                                                <p><b>Sub:</b> Sub: Return of Commitment Document.</p>
                                                <br />
                                                <br />

                                                <p><b>Dear
                                                    <input type="text" placeholder="Employee First Name " style="width: 150px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Employee First Name" />,</b></p>
                                                <p>
                                                    With Reference to the above we are returning back your Original Certificate 
                                                    <input id="nameMarksSheetA" type="text" placeholder="Name of Original Educational Mark Sheet" style="width: 300px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Name of Original Educational Mark Sheet"  onblur="dup()" />
                                                    having 
                                                        <input type="text" placeholder="Ref No. " style="width: 150px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Ref No. as stated in Original Education Mark sheet" />
                                                    submitted against Acknowledgment Receipt 
                                                            <input type="text" placeholder="Date " style="width: 150px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Date of Acknowledgment Receipt" />
                                                    .
                                                </p>




                                                <p><b>Your’s sincerely</b></p>
                                                <br />
                                                <br />
                                                <p><b>Authorized Signatory</b></p>


                                            </div>
                                            <hr />
                                            <br />
                                            <div>
                                                <p>
                                                    I 
                                                <input type="text" placeholder="Employee Full Name " style="width: 250px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Employee Full Name" />
                                                    , hereby confirm and acknowledge receipt of my Original
Commitment Document 
                                                    <input id="nameMarksSheet" type="text" placeholder="Name of Original Educational Mark Sheet" style="width: 300px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Name of Original Educational Mark Sheet"  />
                                                   
                                                    having 
    <input type="text" placeholder="Ref No. " style="width: 150px; padding-top: 13px; border-top: none; border-right: none; border-left: none;" title="Please Enter Ref No. as stated in Original Education Mark sheet" />
                                                    . I do not have any “Commitment Document”
pending to be received from the Company.
                                                </p>
                                                <table>
                                                    <tr>
                                                        <td style="padding-right: 450px">
                                                            <b>Date: </b>
                                                        </td>
                                                        <td>
                                                            <b>Signature: </b>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <br />
                                                <br />
                                                <table>
                                                    <tr>
                                                        <td style="padding-right: 400px">
                                                            <b>Place:</b> Mohali
                                                        </td>
                                                        <td>
                                                            <b>Name in full:</b>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                        <div id="hidden-div ">
                                            
                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="hide(); window.print();" class="btn btn-info pull-right" /><br />
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
