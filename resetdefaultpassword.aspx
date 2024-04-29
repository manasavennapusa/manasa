<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resetdefaultpassword.aspx.cs" Inherits="resetdefaultpassword" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>StartUp Admin</title>
    <meta name="author" content="Srinu Basava">
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport">
    <meta name="description" content="StartUp Admin UI">
    <meta name="keywords" content="StartUp Admin UI, Admin UI, Admin Dashboard, Srinu Basava, Best admin UI, Best backend UI, Best Dashboard, Responsive admin UI, Responsive dashboard, Responsive Backend, Mobile admin, Mobile Backend, Mobile Dashboard">
    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
    <link href="css/blue1.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function Validate() {
            var password = document.getElementById('<%=txt_password.ClientID %>');
            var cpassword = document.getElementById('<%=txt_cpassword.ClientID%>');
            if (password.value == "") {
                alert("Please Enter Password");
                return false;
            }
            if (password.value.length < 8) {
                alert("Password Should be minimum 8 characters!");
                password.focus();
                return false;
            }
            var re = /^[a-zA-Z0-9'@&#.\s]{7,}$/;
            if (!re.test(password.value)) {
                alert("Password Should be a combination of  alpha numeric and a special character!");
                password.focus();
                return false;
            }
            if (cpassword.value == "") {
                alert("Please Enter Confirmed Password");
                cpassword.focus();
                return false;
            }
            if (password.value != cpassword.value) {
                alert("The Password entered does not match the confirmed password!.");
                return false;
            }
            return true;
        }
    </script>
    <script src="js/validatepassword.js"></script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Reset Password</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr>
                                            <td height="5"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td class="frm-lft-clr123" valign="top">Employee Code
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lblcode" runat="server" Text="Label"></asp:Label>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" valign="top">Employee Name
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Label ID="lblname" runat="server" Text="Label"></asp:Label>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="25%" style="height: 29px">New Password
                                                            </td>
                                                            <td class="frm-rght-clr123" width="75%" style="height: 29px">
                                                                <asp:TextBox ID="txt_password" size="52" runat="server" onblur="return validatePassword(this);" TextMode="Password"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123" valign="top">Confirm Password
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_cpassword" runat="server" size="52" TextMode="Password" onblur="return validatePassword(this);"
                                                                    CssClass="form-control"></asp:TextBox>
                                                            </td>
                                                        </tr>

                                                        <tr>
                                                            <td class="frm-lft-clr123 border-bottom">&nbsp;
                                                            </td>
                                                            <td class="frm-rght-clr123 border-bottom">
                                                                <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Reset" CssClass="btn btn-primary" OnClientClick="return Validate();"></asp:Button>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="20" valign="bottom"></td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>

                            </div>

                        </div>
                    </div>
                </div>
                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>



            </div>
        </div>

    </form>
    <script src="../js/jquery.min.js"></script>
  
</body>
</html>


