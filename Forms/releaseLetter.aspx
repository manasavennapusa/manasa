<%@ Page Language="C#" AutoEventWireup="true" CodeFile="releaseLetter.aspx.cs" Inherits="Forms_releaseLetter" %>

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
            margin-top: 180px;
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
                            <div id="letterHead">
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group" style="padding-right:10px;">



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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name"" style="padding-top:13px; width: 100px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight:bold " />,</span>
                                            <br />
                                            <br />
                                            <br />
                                            <a style="text-align: center"><h4> Release Letter</h4></a>
                                           
                                             <br />
                                            <br />
                                            <div>
                                                <span style="margin-left: 4px; text-align: justify">This has reference to your resignation letter dated 
                                                    <input type="text" id="Text5" title="Please enter Date " runat="server" placeholder=" Date" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />
                                                     tendering your resignation from the
                                                    services of the organization.
                                                </span>
                                                <br />

                                                <span style="margin-left: 4px; text-align: justify">This is to convey that your resignation has been accepted by the organization and you are released from
                                                     your responsibilities with effect from the close of working hours on
                                                    <input type="text" id="Text6" title="Please enter Date " runat="server" placeholder=" Date" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />,
                                                    subject to “No Dues
                                                        Clearance” from all concerned.
                                                </span>
                                                <br />
                                                 <span style="margin-left: 4px; text-align: justify">
                                                You are requested to contact the Accounts Department for full and final settlement of your dues.
                                                 </span>
                                                <span style="margin-left: 4px; text-align: justify">
                                                We wish you the best for your future endeavors.
                                                 </span>
                                                 
                                            </div>
                                          <br/>

                                            <%-- signature --%>
                                            <div>
                                                
                                             <b>  For Escalon Business Services Pvt. Ltd. </b>
                                            <br/><br/>
                                             
                                            <br/><br/>
                                             <b>  Authorized Signatory </b>
                                            <br/><br/>

                                                </div>

                                         
                                            <br />
                                            <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="letterHead(); hide(); window.print();" class="btn btn-info pull-right"/><br />
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
