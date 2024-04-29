<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employeeidcard.aspx.cs" Inherits="onboarding_employeeidcard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/popup.js"></script>
     <script type="text/javascript">
         function ValidateEmpcode() {
             var empcode = document.getElementById('<%=txt_employee.ClientID %>');
            if (empcode.value == "") {
                FName.focus();
                alert("Please select empcode");
                return false;
            }
         }
         function isKey(keyCode) {
             return false;
         }
    </script>
</head>
<body>
    <form id="form1" runat="server" style="background-color: white; padding: 25px">
        <table cellpadding="5" cellspacing="3" style="padding: 20px">
            <tr>
                <td>Employee Code/Name
                </td>

                <td>
                    <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                </td>

                <td>
                    <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                </td>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Get Details" OnClick="btnSubmit_Click" OnClientClick="return ValidateEmpcode();" />
                    &nbsp;&nbsp;
                         <asp:Button ID="btnprint" runat="server" CssClass="btn btn-info pull-right " Text="Print" OnClick="btnprint_Click" OnClientClick="return ValidateEmpcode();" />
                </td>
            </tr>
        </table>
        <asp:Panel ID="pnl1" runat="server">
            <div>
                <p>
                    <u></u>
                </p>
                <p align="center">
                    <u><b>Employee ID Card Application </b></u>
                </p>
                <p>
                    <u></u>
                </p>
                <p align="center">
                    <u></u>
                </p>
                <table border="1" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td width="250" height="200px" valign="top">
                                <p>
                                    <b>Affix Photograph here</b>
                                </p>
                                <p>
                                    <b>(White background only)</b>
                                </p>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <br />
                <br />
                <table border="1" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td width="319" valign="top">
                                <p>
                                    <strong>&nbsp;NAME (In Capitals &amp; as per HR records)</strong>
                                </p>
                            </td>
                            <td width="319" valign="top">
                                <p>
                                    <strong>
                                        <asp:Label Style="border: none" ID="txtfirstname" runat="server" Text=""></asp:Label></strong>
                                </p>

                            </td>
                        </tr>
                        <tr>
                            <td width="319" valign="top">
                                <p>
                                    <strong>&nbsp;Employee Number</strong>
                                </p>
                            </td>
                            <td width="319" valign="top">
                                <p>
                                    <strong>
                                        <asp:Label Style="border: none" ID="txtempcode" runat="server" Text="" Font-Bold="true"></asp:Label></strong>
                                </p>
                            </td>
                        </tr>
                        <tr>
                            <td width="319" valign="top">
                                <p>
                                    <strong>&nbsp;Blood Group</strong>
                                </p>
                            </td>
                            <td width="319" valign="top">
                                <p>
                                    <strong>
                                        <asp:Label Style="border: none" ID="txtbloodgrp" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label></strong>
                                </p>

                            </td>
                        </tr>
                        <tr>
                            <td width="319" valign="top">
                                <p>
                                    <strong>&nbsp;Emergency Contact Number, Name &amp; Relationship with the person</strong>
                                </p>
                            </td>
                            <td width="319" valign="top">

                                 <asp:Label Style="border: none" ID="lblemgcontact" runat="server" Text="" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="319" valign="top">
                                <p>
                                    <strong>&nbsp;Residential Address </strong>
                                </p>

                            </td>
                            <td width="319" valign="top">
                                <asp:Label Style="border: none" ID="txt_pre_add1" runat="server" Text="" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <p>
                    Signature of Employee
                </p>
                <p>
                    Date:
                </p>

            </div>
        </asp:Panel>
    </form>
</body>
</html>
