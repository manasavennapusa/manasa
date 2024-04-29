<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcomeLetter.aspx.cs" Inherits="Forms_welcomeLetter" %>

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
                                                        <input type="text" id="Text14" title="Please Enter Date " runat="server" placeholder="Date of Issuance" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <input id="Text1" placeholder="Employee Full Name" type="text" title="Please Enter Employee Full Name" runat="server" style="width: 150px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td>
                                                        <input id="Text2" type="text" title="Please Enter a Random Reference Number" runat="server" placeholder="Reference Number" style="width: 250px; padding-left: 10px; height: 20px; float: left; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" />
                                                       
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
                                                   <input id="Text4" type="text" placeholder="First Name" title="Please Enter First Name" style="padding-top:13px; width: 150px; padding-left: 10px; height: 20px; border: none; font-family: Times New Roman; font-size: 16px; font-weight: bold" /></span>
                                            <br />
                                            <br />
                                          <p>
                                             With the Internet came the opportunity to celebrate strategy, innovation and excellence. In a dynamic environment
that holds no limits on human imagination, it is possible to reach out to users across countries, cultures and beyond
traditional boundaries. We’ve specifically designed user centric and employee friendly systems that have resulted in
efficient work flow processes, an open culture that emphasizes on learning, automated processes, better productivity
and reliability through standardization.
                                          </p>
                                                 <p>
                                                     Our fundamentals are our people. With flexibility inherently inculcated into our employee management systems, talent
is given the perfect platform to outshine the rest. We’ve also, through our principles of work culture, ensured that
mediocrity is avoided while true value additions are identified and nurtured.
                                          </p>
                                                 <p>
With offices around the world and a family of more than 100 employees, a centralized philosophy of action now has
helped us develop and implement management decisions through which expertise is enhanced, knowledge is spread,
user needs are understood and expectations are exceeded through unmatched quality.
                                          </p>
                                                 <p>
We are an equal opportunity employer and believe that given the right support all our employees will excel to being
the best in what they do. Our teams are versatile, dynamic and talented and have established within themselves the
coherent passion to reach higher levels of creative excellence, which is indispensable in the pursuance of a shared
dream. Our employees are passionate about the company’s future and believe in the common goal. Aware of their own
contribution towards the achievement of the same, they set up their own personal and team objectives in sync with the
company’s vision.
                                          </p>
                                                <p> As we continue to grow and evolve, our family grows along. Each individual in this company adds a little bit of their
own to give us a unique and diversified character that is hard to describe. It is this uniqueness that gives us a
competitive edge over the others in this dynamically changing environment. It is our endeavor to provide each
employee with the creative space to grow as a professional as well as an individual. We would like to welcome you on
board to join our fraternity.</p>

                                                <p>
We have scheduled you for your Orientation on 1st March3,2017 at 11:00 a.m. on the First Floor, at 71J Hindustan
Park, Mohali – 1600593. Kindly ensure that you come along with all the proper documents as specified in the attached
sheet.
                                                </p>


                                                <p>
                                                 <b>This letter has been sent for the sole purpose of address verification. It should not be taken as an offer letter or
a confirmation of appointment.</b>
                                                    </p>
                                            </div>
                                            <br /><br /><br /><br />
                                            <div>
                                                <p style="font-size:14px">
                                                 Best Regards,<br/>
For Escalon Business Services Pvt. Ltd.
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
