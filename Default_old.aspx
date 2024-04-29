<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default_old.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
    <!-- bootstrap css -->
    <link href="css/main.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/erp_login.css" />
    <link rel="stylesheet" href="plugins/choosen/prism.css" />
    <link rel="stylesheet" href="plugins/choosen/chosen.css" />
    <style type="text/css">
        .my_select
        {
            width: 100%;
        }
    </style>
</head>
<body>

    <div class="container-fluid" style="background-color: white">
        <div class="row-fluid">
            <div class="span8">
                <a href="http://www.abmauri.in/">
                    <img src="img/abmauri login-Recovered.jpg" style="height: 100%" /></a>
            </div>
            <div class="span4 ">
                <form runat="server" class="signin-wrapper" style="padding: 25% 15% 0% 5%">
                    <h2 class="center-align-text">
                        <img src="upload/logo/smarthrsmall.png" alt="" style="padding: 0% 0% 5% 0%; width: 45%;" /></h2>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <asp:UpdatePanel ID="updatePannel1" runat="server">
                        <ContentTemplate>
                            <div class="content">
                                <input id="txtUserName" type="text" runat="server" class="input input-block-level" maxlength="50" title="Module description" required placeholder="Enter Employee Code" />
                                <input id="txtPassword" type="password" runat="server" class="input input-block-level" maxlength="50" title="Module description" required placeholder="Enter PassWord" />

                                <%-- <input id="txtUserName" runat="server"  class="input input-block-level" placeholder="Email" type="text" value="" />
                            <input id="txtPassword" runat="server" class="input input-block-level" placeholder="Password" type="password" />--%>
                            </div>
                            <div class="actions">
                                <%--  <button id="btnSubmit" type="button" class="btn btn-info pull-right" >Login</button>--%>
                                <asp:Button ID="btn_logon" runat="server" OnClick="btn_logon_Click" Text="Login" class="btn btn-info pull-right" />
                                <span class="checkbox-wrapper">
                                    <asp:LinkButton ID="lnkReset" runat="server" CssClass="forgot-password-link" OnClick="Forget_Click" Text="Forget Password?"></asp:LinkButton>
                                </span>
                                <span id="lbl_message" style="color: #1a7f02" class="link02" runat="server"></span>
                                <div class="clearfix"></div>
                            </div>
                            <div style="padding: 13% 5% 5% 5%">
                                <br />

                                <p align="center">
                                    &nbsp;
                                </p>
                            </div>

                            <%--                        <div class="content drop_delt">
                            <!--company detail goes here-->
                            <asp:DropDownList ID="ddlCompanyDetails" runat ="server" CssClass ="my_select" data-placeholder="Company Details" OnSelectedIndexChanged="ddlCompanyDetails_SelectedIndexChanged">
                                
                            </asp:DropDownList>

                           
                            <!--End of the company details-->
                            <!--company location-->
                            <asp:DropDownList ID="ddlLocation" runat ="server" CssClass ="my_select" data-placeholder="Location">
                                
                            </asp:DropDownList>
                            <!--End of the location-->
                            <!--company location-->
                            <asp:DropDownList ID="ddlFinancialYear" runat ="server" CssClass ="my_select" data-placeholder="Financial Year">
                               
                            </asp:DropDownList>
                            <!--End of the location-->
                            <!--company location-->
                            
                            <input id="txtDate" runat="server" class="input input-block-level" placeholder="Date" type="date" value="" />
                            <!--End of the location-->

                        </div>--%>
                            <%--<div class="actions">
                            <asp:Button ID="btnContinue" runat="server" Text="Continue" CssClass ="btn btn-info pull-right" OnClick="btnContinue_Click" />
                            <div class="clearfix"></div>
                        </div>--%>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </form>

            </div>

        </div>
    </div>

    <div id="loader" style="display: none;">
        <img src="img/loader.gif" style="width: 25%; height: 25%" />
    </div>

    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>

    <script type="text/javascript">
        $(window).load(function () {

            $('#btnSubmit').click(function () {

                $('body').attr('style', 'opacity:0.4');

                var username = $('#txtUserName').val();
                var password = $('#txtPassword').val();

                $('#loader').attr('style', 'display:block;position:absolute;top:41%;left:45%;opacity:1');

                if (username == '' && password == '') {
                    $('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtUserName').focus();
                    alert('Please enter username and password.');

                }
                else if (username == '') {
                    $('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtUserName').focus();
                    alert('Please enter username.');
                }
                else if (password == '') {
                    $('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtPassword').focus();
                    alert('Please enter password.');
                }

                else {

                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/ValidateUserCredentials",
                        data: JSON.stringify({ 'userName': username, 'password': password }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (msg) {

                            $('body').attr('style', 'opacity:1');
                            $('#loader').attr('style', 'display:none');


                            // alert(msg.d);
                            if (msg.d == 'True') {
                                window.location.assign('Default3.aspx');
                            }
                            else {
                                alert(msg.d);
                            }
                        },
                        failure: function (msg) {

                            $('body').attr('style', 'opacity:1');
                            $('#loader').attr('style', 'display:none');
                        }
                    });
                }

            });
        });
    </script>

</body>
</html>
