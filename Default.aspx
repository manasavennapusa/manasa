<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <link href="css/dashboardcss/main.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />

    <style type="text/css">
        body {
            background: url(images/111.jpg) no-repeat;
            -webkit-background-size: cover;
            -moz-background-size: cover;
            -o-background-size: cover;
            background-size: cover;
            background-position: center;
            background-color: white;
            margin: 0;
        }

        .centered {
            text-align: center;
            position: absolute;
            top: 22%;
            left: 17%;
            transform: translate(-50%, -50%);
            color: white;
        }

        .TextBox {
            width: 100%;
            height: 30px;
            border: 1px solid #e2e2e2;
            background: #fbfbfb;
            padding: 3px 3px 3px 6px;
            color: #233145;
            border-radius: 0px 5px 5px 0px;
        }

        .imagebutton {
            width: 30px;
            height: 30px;
            -webkit-transition: 0.5s ease;
            transition: 0.5s ease;
            border-radius: 50%;
        }

            .imagebutton:hover {
                -webkit-transform: scale(1.2);
                transform: scale(1.2);
            }

        .link_1 {
            color: #808080;
            text-decoration: none;
            background-color: transparent;
            -webkit-text-decoration-skip: objects;
            font-size: 12px;
        }

            .link_1:hover {
                color: #0056b3;
                text-decoration: underline;
            }

        .topbar {
            overflow: hidden;
            background-color: #333;
            position: fixed;
            top: 0;
            width: 100%;
        }

        .bottombar {
            overflow: hidden;
            background-color: #fff;
            position: fixed;
            bottom: 0;
            width: 100%;
            height: 45px;
            font-family: Arial;
            text-align: center;
        }
    </style>

    <script type="text/javascript">
        var c = document.getElementById("<%=txtUserName.ClientID %>");
        c.select =
        function (event, ui)
        { this.value = ""; return false; }
    </script>
</head>
<body>
    <form id="form" runat="server" class="body" autocomplete="off">

        <div class="topbar">
            <table class="width-100 height-100" style="background-color: white; text-align: center" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="width-33 pt-10px pl-60px text-left pb-5px">
                        <% if (ViewState["Logo"] != null) Response.Write(ViewState["Logo"].ToString()); %>
                    </td>
                    <td class="width-33 pt-10px text-center fs-20 fw-800 color-red">Welcome To HRMS Portal
                    </td>
                    <td class="width-33 text-right pt-10px pr-65px">
                        <img src="images/SmartH2R.png" alt="User" style="width: 200px; height: 60px" />
                    </td>
                </tr>
            </table>
        </div>


        <table class="width-100 height-500px mt-30px" cellspacing="0" cellpadding="0">
            <tr>
                <td class="width-100" style="vertical-align: central">
                    <div style="margin-left: 47%; border-radius: 50%; width: 8%; padding-bottom: 10px; padding-top: 60px">
                        <table class="width-100">
                            <tr>
                                <td>
                                    <%-- <img src="images/av_1.png" alt="" style="display: block; width: 100%; height: auto; border-radius: 50%; position: relative; top: 50px;" />--%>
                                    <div style="background-color: aliceblue; position: relative; top: 50px; border-radius: 52%;">
                                        <asp:Image ID="empimage" runat="server" Style="width: 100%; height: 105px; border-radius: 50%; border: none; padding: 8px 8px" onerror="this.src='images/av_1.png'" />
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div_1" runat="server">
                        <table class="width-30" style="background-color: aliceblue; margin-left: 36%; border-radius: 5px 5px; padding: 30px 30px 20px 20px;">
                            <tr>
                                <td class="width-50" style="color: #db4f4f; font-family: Arial; font-size: 22px; font-weight: 700; text-align: center; padding-left: 5px; padding-top: 20px;">
                                    <asp:Label ID="lbl_emprole" runat="server">e-Login</asp:Label>
                                </td>
                            </tr>
                            <tr id="tr_1" runat="server">
                                <td class="pt-15px pr-5px pb-5px pl-5px">
                                    <table class="width-100" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="color-333 fs-13 pb-5px">Employee Code
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" MaxLength="50" ToolTip="Enter Employee Code Here" placeholder="Employee Code" CssClass="TextBox" AutoPostBack="true" OnTextChanged="txtUserName_TextChanged" autocomplete="off"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_2" runat="server">
                                <td class="p-5px">
                                    <table class="width-100" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="color-333 fs-13 pb-5px">Password
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" MaxLength="50" ToolTip="Enter Password Here" placeholder="Password" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                            </tr>
                            <tr id="tr_3" runat="server">
                                <td class="no-padding">
                                    <table class="width-100">
                                        <tr>
                                            <td class="p-3px text-left">
                                                <asp:LinkButton ID="lnkReset" runat="server" CssClass="link_1" OnClick="Forget_Click" Text="Forgot Password?"></asp:LinkButton>
                                            </td>
                                            <td class="p-3px text-center">
                                                <asp:LinkButton ID="lnkRegistration" runat="server" OnClick="Registration_Click" CssClass="link_1" Text="Registration Form"></asp:LinkButton>
                                            </td>
                                            <td class="p-3px text-right">
                                                <asp:Button ID="btn_logon" runat="server" OnClick="btn_logon_Click" Text="Login" CssClass="button-red" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tr_mail_button" runat="server" visible="false">
                                <td class="width-100">
                                    <table class="width-100">
                                        <tr>
                                            <td class="width-35" style="vertical-align: central; text-align: left; color: #808080; width: 35%">or sign in using</td>
                                            <td class="width-65" style="vertical-align: central; text-align: left; width: 65%">
                                                <asp:ImageButton ID="btnmail" runat="server" ImageUrl="~/images/google.png" OnClick="btnmail_Click" CssClass="imagebutton" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div_OTP" runat="server" visible="false">
                        <table class="width-30" style="background-color: aliceblue; margin-left: 36%; border-radius: 5px 5px; padding: 50px 30px 20px 20px;">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100">
                                        <tr>
                                            <td class="p-5px">
                                                <table class="width-100" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="width-5px" style="background-color: #e2e2e2; padding: 3px 3px 3px 3px; border-radius: 5px 0px 0px 5px; text-align: center">
                                                            <i class="fa fa-envelope-o fa-fw"></i>
                                                        </td>
                                                        <td class="width-95px">
                                                            <asp:TextBox ID="txt_login_email" runat="server" MaxLength="50" ToolTip="Enter Email" placeholder="Enter Personal Email Id" CssClass="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="p-5px text-right">
                                                <asp:Button ID="btn_OTP" runat="server" Text="Send OTP" CssClass="button-blue-OTP" OnClick="btn_OTP_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div id="div_verify_OTP" runat="server" visible="false">
                        <table class="width-30" style="background-color: aliceblue; margin-left: 36%; border-radius: 5px 5px; padding: 50px 30px 20px 20px;">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100">
                                        <tr>
                                            <td class="p-5px">
                                                <table class="width-100" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="width-5px" style="background-color: #e2e2e2; padding: 3px 3px 3px 3px; border-radius: 5px 0px 0px 5px; text-align: center">
                                                            <i class="fa fa-envelope-o fa-fw"></i>
                                                        </td>
                                                        <td class="width-95px">
                                                            <asp:TextBox ID="txt_verify_OTP" runat="server" MaxLength="50" ToolTip="Enter OTP" placeholder="Enter OTP Code" CssClass="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="p-5px text-right">
                                                <asp:Button ID="btn_verify_OTP" runat="server" Text="Verify OTP" CssClass="button-blue-OTP" OnClick="btn_verify_OTP_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>


        <div class="bottombar">
            <p class="color-333 fs-11 fw-800">Powered By SmartDrive Labs&nbsp;<i class="fa fa-copyright" style="font-size: 12px; font-weight: 700"></i>&nbsp;All Rights Reserved</p>
        </div>

    </form>
</body>
</html>
