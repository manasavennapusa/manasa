<%@ Page Language="C#" AutoEventWireup="true" CodeFile="experienceCertificate.aspx.cs" Inherits="Forms_experienceCertificate" %>

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
                                                    <td style="padding-left: 10px"></td>
                                                </tr>

                                                <tr>
                                                    <td style="height: 20px"></td>
                                                </tr>
                                            </table>
                                            <a style="text-align: center"><h4>Experience Certificate</h4></a>
                                            
                                            <br />
                                             <a style="text-align: center"><h4>To Whomsoever It May Concern</h4></a>
                                            <br />
                                            <br />

                                            <div>
                                                 <span style="margin-left: 4px; text-align: justify">This is to certify that <input type="text" id="Text1" title="Please enter Name" runat="server" placeholder="  Name" style="width: 150px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" /> 
                                                      (Employee ID:<input type="text" id="Text2" title="Please enter Employee ID" runat="server" placeholder="Employee ID" style="width: 150px; padding-left: 10px; height: 20px; border-right: none; padding-top:13px; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />) was working with our organization from

                                                    <input type="text" id="Text3" title="Please enter From Date " runat="server" placeholder=" From Date" style="width: 80px; padding-left: 10px; height: 20px; border-right: none; border-left: none; padding-top:13px; border-top: none; font-family: Times New Roman; font-size: 14px;" /> to 
                                                     <input type="text" id="Text4" title="Please enter To Date" runat="server" placeholder=" To Date" style="width: 80px; padding-left: 10px; height: 20px; border-right: none; border-left: none; padding-top:13px; border-top: none; font-family: Times New Roman; font-size: 14px;" />.

                                                </span>

                                                <span style="margin-left: 4px; text-align: justify"> At the time of his release, he was working in the capacity of 
                                                    <input type="text" id="Text6" title="Please enter Capacity" runat="server" placeholder=" Capacity" style="width: 80px; padding-top:13px; padding-left: 10px; height: 20px; border-right: none; border-left: none; border-top: none; font-family: Times New Roman; font-size: 14px;" />
                                                     in our organization.
                                                </span>
                                                <br />
                                                <span style="margin-left: 4px; text-align: justify">
                                                This certificate is being issued on his request as proof of his experience with our organization.
                                                    </span>
                                                <br />
                                                 <span style="margin-left: 4px; text-align: justify">
                                                 We wish him the best for his future endeavors.
                                                    </span>
                                                <br />

                                               
                                            </div>
                                          <br/>
                                           

                                            <%-- signature --%>
                                            <div>
                                               
                                             <b>  For Escalon Business Services Pvt. Ltd.</b>
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
