<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dDDChangeLetter.aspx.cs" Inherits="Forms_dDDChanceLetter" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <style >
table.a {
    font-family: arial, sans-serif;
    border-collapse: collapse;
    width: 100%;
}
.letterHead
        {
            margin-top: 140px;
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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name"" style="padding-top:12px; width: 100px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight:bold " />,</span>
                                            <br />
                                            <br />
                                            <br />


                                            <div>
                                                <span style="margin-left: 4px; text-align: justify">We are pleased to inform you that with effect from <input type="text" id="Text6" title="Please enter Date" runat="server" placeholder=" Date" style="width: 80px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; padding-top:12px; font-size: 14px;" />,
                                                     your current designation / department
                                                     <input type="text" id="currentDesignation" title="Please enter Current Designation t" runat="server" placeholder=" Designation" style="padding-top:12px; width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" /> ,
                                                     <input type="text" id="currentDept" title="Please enter Current Department" runat="server" placeholder=" Department" style="width: 150px; padding-top:12px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />,
                                                     has been revised to<input type="text" id="newDesignation" title="Please enter Current Designation t" runat="server" placeholder=" Designation" style="padding-top:12px;  width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" /> ,
                                                     <input type="text" id="newDept" title="Please enter Current Department" runat="server" placeholder=" Department" style="width: 150px; padding-left: 10px; padding-top:12px; height: 20px; border: none; font-family: Times New Roman; font-size: 14px;" />.

                                                </span>
                                            </div>
                                          <br/>

                                            <%-- signature --%>
                                            <div>
                                                <b>Thanking You,</b>
                                                <br/><br/>
                                          <b>  Yours sincerely, </b>
                                            <br/><br/>
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
