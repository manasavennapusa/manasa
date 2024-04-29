<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CompensationConfidentialityCommitment.aspx.cs" Inherits="Forms_CompensationConfidentialityCommitment" %>

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

        .dashboard-wrapper .main-container
        {
            border-top: 0px solid white;
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <asp:ScriptManager ID="rr" runat="server"></asp:ScriptManager>
                <asp:Panel ID="pnl1" runat="server" Style="margin-top: 20px">

                    <div class="row-fluid" style="padding-left: 20px; padding-right: 20px;">
                        <div class="span11">
                            <div id="letterHead">
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group" style="padding-right: 10px; margin: 20px 20px 20px 20px;">
                                            <div>
                                                <a style="font-size: 17px;">
                                                    <center><b>Compensation Confidentiality Commitment</b></center>
                                                </a>
                                                <br />
                                                <br />
                                                <br />
                                                <p>
                                                    I,
                                                <input type="text" style="width: 150px; padding-top: 13px; border-right: none; border-left: none; border-top: none;" title="Please Enter Full Name" />
                                                    aged about
                                                <input type="text" style="width: 15px; padding-top: 13px; border-right: none; border-left: none; border-top: none;" title="Please Enter Age" />
                                                    years, daughter of
                                                <input type="text" style="width: 150px; padding-top: 13px; border-right: none; border-left: none; border-top: none;" title="Please enter Fathers Name" />
                                                    resident of
                                                <input type="text" style="width: 250px; padding-top: 13px; border-right: none; border-left: none; border-top: none;" title="Please Enter Permanent Address" />
                                                    do hereby warrant and pledge that
                                                </p>
                                                <p>
                                                    I understand and accept that all information as it relates to the status of my employment is
confidential and may not be shared with other employees and ex- employees. This includes, but is
not limited to salary, bonuses, and other types of compensation. Doing so is a violation of the
appointment agreement between me & the Company.
                                                </p>
                                                <p>
                                                    I understand and accept that possessing information regarding the compensation of other
employees is also a violation of the confidentiality agreement. Salary information is considered to be
a private matter, and what a person earns does, after all, have an effect on the way he or she lives.
People feel uncomfortable in having their private matters known publicly.
                                                </p>
                                                <p>
                                                    I understand that the people with whom I can discuss my employment terms have been given an
authorization letter from the Company explicitly allowing them to possess knowledge about my
employment terms and to discuss my employment terms. They should show me an authorization
letter, before I can discuss the terms of my employment with them.
                                                </p>
                                                <p>
                                                    I understand and accept that disregard or failure to comply could lead to disciplinary action,
including termination. Any employee aware of the possession or distribution of such information
should notify Human Resources as soon as they become aware of the situation. Withholding such
knowledge is also considered a violation of the policy.
                                                </p>
                                                <p>
                                                    I accept the above conditions, out of my own freewill, without any coercion.
                                                </p>
                                            </div>
                                            <br />
                                            <br />
                                            <div>
                                                <a style="font-size: 14px;"><b>Signed by</b></a><br />
                                                <a style="font-size: 14px;"><b>Name:</b><input type="text" style="width: 150px; border: none; font-size: 14px;" title="Please Enter Full Name" /></a><br />
                                                <a style="font-size: 14px;"><b>Employee ID:</b><input type="text" style="width: 150px; border: none; font-size: 14px;" title="Please Enter Employee ID" /></a><br />
                                                <a style="font-size: 14px;"><b>Date:</b><input type="text" style="width: 150px; border: none; font-size: 14px;" title="Please Enter Date" /></a><br />


                                            </div>

                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide(); window.print();" class="btn btn-info pull-right" /><br />
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
