<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generateforms.aspx.cs" Inherits="admin_generateforms" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <link href="css/bankform.css" rel="stylesheet" />
    <link href="css/employeeinfo.css" rel="stylesheet" />
    <link href="css/inductionform.css" rel="stylesheet" />
    <link href="css/insurance.css" rel="stylesheet" />
    <link href="css/sodexo.css" rel="stylesheet" />
    <link href="css/vpf.css" rel="stylesheet" />
    <script type="text/javascript">
        function isKey(keyCode) {
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Forms
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="wizard">
                                        <ol>
                                            <li>Personal Info. </li>
                                            <li>Bank Details </li>
                                            <li>Induction Completion </li>
                                            <li>Insurance Nomination </li>
                                            <li>Sodexho Form </li>
                                            <li>VPF Declaration </li>
                                            <li>ID Card </li>
                                            <%--    <li>Account &Hardware Req. </li>--%>
                                        </ol>
                                        <div>
                                            <p>
                                                <asp:Button ID="btnprint" runat="server" Text="Print" OnClick="btnprint_Click1" />
                                                <asp:Panel ID="pnlperinfo" runat="server">
                                                    <div id="page_1" runat="server">
                                                        <div>
                                                            <img src="../upload/logo/client-logo.png" style="float: right;">
                                                        </div>


                                                        <div class="dclr"></div>
                                                        <p align="center" style="font: bold 16px 'Century Gothic'; text-decoration: underline; line-height: 19px;">PERSONAL INFORMATION FORM</p>
                                                        <table cellpadding="0" cellspacing="0" class="t0">
                                                            <tr>
                                                                <td class="tr0 td0">
                                                                    <p class="p1 ft1">Name in Full</p>
                                                                </td>
                                                                <td colspan="7" class="tr0 td1">
                                                                    <p class="p2 ft1">
                                                                        : (First) &nbsp;&nbsp;<asp:Label Style="border: none" ID="txtfirstname" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                                                                        (Middle)&nbsp;&nbsp;<asp:Label Style="border: none" ID="txtmiddlename" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr1 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td colspan="7" class="tr1 td1">
                                                                    <p class="p3 ft1">(Last)&nbsp;&nbsp;<asp:Label Style="border: none" ID="txtlastname" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr2 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td2">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td3">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td4">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td5">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td6">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td7">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr2 td8">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr3 td0">
                                                                    <p class="p1 ft1">Gender</p>
                                                                </td>
                                                                <td class="tr3 td5">
                                                                    <p class="p4 ft1">: Male</p>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="ck" runat="server" />
                                                                </td>

                                                                <td class="tr3 td5">
                                                                    <p class="p5 ft1">Female</p>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="tr1 td0">
                                                                    <p class="p1 ft1">Date of Birth</p>
                                                                </td>
                                                                <td colspan="7" class="tr1 td1">
                                                                    <p class="p2 ft1">: (Day) &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_day" runat="server" Text="" Font-Bold="true" Width="50px"></asp:Label>/ (Month)&nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_month" runat="server" Text="" Font-Bold="true" Width="50px"></asp:Label>/ (Year) &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_year" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft1">Blood Group</p>
                                                                </td>
                                                                <td colspan="4" class="tr5 td14">
                                                                    <p class="p2 ft1">
                                                                        :&nbsp;&nbsp;<asp:Label Style="border: none" ID="txtbloodgrp" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                                                                        RH type: Positive
                            <input type="checkbox" runat="server" id="ckbldtype" groupname="blood" />
                                                                        Negative
                                <input type="checkbox" runat="server" id="Checkbox2" groupname="blood" />
                                                                    </p>
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="tr6 td0">
                                                                    <p class="p1 ft1">Nationality</p>
                                                                </td>
                                                                <td colspan="7" class="tr6 td1">
                                                                    <p class="p2 ft1">:&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label7" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>( Country) &nbsp;&nbsp;<asp:Label Style="border: none" ID="Label8" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>(State)</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr1 td0">
                                                                    <p class="p1 ft1">Father’s Name</p>
                                                                </td>
                                                                <td colspan="7" class="tr1 td1">
                                                                    <p class="p2 ft3">: &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_f_f_name" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>DOB & Age&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label10" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft1">Mother Name</p>
                                                                </td>
                                                                <td colspan="7" class="tr5 td1">
                                                                    <p class="p6 ft3">
                                                                        : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_m_fname" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                                                                        DOB & Age &nbsp;&nbsp;<asp:Label Style="border: none" ID="Label12" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft1">Marital Status</p>
                                                                </td>
                                                                <td colspan="2" class="tr5 td16">
                                                                    <p class="p2 ft1">:&nbsp;&nbsp;<asp:Label Style="border: none" ID="ddlpersonalstatus" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td colspan="5" class="tr5 td17">
                                                                    <p class="p1 ft1">Date of Marriage &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_doa" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft1">If Married,</p>
                                                                </td>
                                                                <td class="tr5 td2">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td3">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td4">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td5">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td6">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td7">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr5 td8">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr1 td0">
                                                                    <p class="p1 ft1">Spouse Name</p>
                                                                </td>
                                                                <td colspan="7" class="tr1 td1">
                                                                    <p class="p2 ft1">
                                                                        : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_sp_fname" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                                                                        DOB & Age &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_sp_dob" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            
                                                            <tr>
                                                                <td colspan="3">
                                                                    <asp:GridView ID="grid_child" runat="Server" Width="100%" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                        AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name"
                                                                        HorizontalAlign="Left" CellPadding="4" EmptyDataText="No Data Found">
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Child Name" HeaderStyle-Width="30%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Style="border: none" ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Gender" HeaderStyle-Width="30%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Style="border: none" ID="Labelgender" runat="Server" Text='<%# Eval("gender") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Date of Birth" HeaderStyle-Width="30%">
                                                                                <ItemTemplate>
                                                                                    <asp:Label Style="border: none" ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                         
                                                            <tr>
                                                                <td class="tr7 td0">
                                                                    <p class="p1 ft1">Present Address</p>
                                                                </td>
                                                                <td colspan="6" class="tr7 td18">
                                                                    <p class="p7 ft3">: &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_pre_add1" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td class="tr7 td8">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td colspan="7" class="tr5 td1">
                                                                    <p class="p8 ft1">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label22" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr1 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td colspan="7" class="tr1 td1">
                                                                    <p class="p8 ft1">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label23" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td0">
                                                                    <p class="p1 ft2">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label25" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td colspan="2" class="tr4 td16">
                                                                    <p class="p9 ft1">City:</p>
                                                                </td>
                                                                <td class="tr4 td4">
                                                                    <p class="p1 ft2">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label26" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td colspan="4" class="tr4 td19">
                                                                    <p class="p5 ft1">Pin Code:</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr8 td0">
                                                                    <p class="p1 ft1">Telephone No</p>
                                                                </td>
                                                                <td colspan="4" class="tr8 td14">
                                                                    <p class="p2 ft1">: &nbsp;&nbsp;<asp:Label Style="border: none" ID="Label24" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td class="tr8 td6">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr8 td7">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr8 td8">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="8" class="tr9 td20">
                                                                    <p class="p1 ft1">Permanent Address:&nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_per_add" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td colspan="7" class="tr5 td1">
                                                                    <p class="p2 ft1">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label28" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr5 td0">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td colspan="7" class="tr5 td1">
                                                                    <p class="p2 ft1">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label29" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr9 td0">
                                                                    <p class="p1 ft2">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label30" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td colspan="2" class="tr9 td16">
                                                                    <p class="p10 ft1">City:</p>
                                                                </td>
                                                                <td class="tr9 td4">
                                                                    <p class="p1 ft2">&nbsp;&nbsp;<asp:Label Style="border: none" ID="Label31" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td colspan="4" class="tr9 td19">
                                                                    <p class="p5 ft1">Pin Code:</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr9 td0">
                                                                    <p class="p1 ft1">Telephone No</p>
                                                                </td>
                                                                <td colspan="4" class="tr9 td14">
                                                                    <p class="p2 ft1">:&nbsp;&nbsp;<asp:Label Style="border: none" ID="txttelephone" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                                <td class="tr9 td6">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr9 td7">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr9 td8">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                        <div class="dclr"></div>
                                                        <p class="p11 ft1">Primary Contact Number (Mobile): &nbsp;&nbsp;<asp:Label Style="border: none" ID="txtmobileno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p12 ft1">Secondary contact Number ( Landline /Mobile ):&nbsp;&nbsp;<asp:Label Style="border: none" ID="txtlandno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <table cellpadding="0" cellspacing="0" class="t1">
                                                            <tr>
                                                                <td class="tr10 td21">
                                                                    <p class="p1 ft1">
                                                                        <nobr>E-mail</nobr>
                                                                        ID
                                                                    </p>
                                                                </td>
                                                                <td class="tr10 td22">
                                                                    <p class="p13 ft1">:&nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_email" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <p class="p14 ft1">Permanent Account Number (PAN)*:&nbsp;&nbsp;<asp:Label Style="border: none" ID="panno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p15 ft1">Passport details:</p>
                                                        <p class="p16 ft1">Passport Number: &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportno" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p17 ft1">Place of Issue :&nbsp;&nbsp;<asp:Label Style="border: none" ID="placeissue" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p16 ft1">Date of Issue : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportissueddate" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p17 ft1">Date of Expiry : &nbsp;&nbsp;<asp:Label Style="border: none" ID="txt_passportexpdate" runat="server" Text="" Font-Bold="true" Width="200px"></asp:Label></p>
                                                        <p class="p15 ft1">Emergency Contact Details:</p>
                                                        <table cellpadding="0" cellspacing="0" class="t3" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            AutoGenerateColumns="False" AllowSorting="True" Style="border-top: 1px solid #e0e0e0"
                                                                            CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Emg. Contact Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Emg. Contact Relation">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Emg. Contact No. ">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Emg. LandLine No.">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <p class="p15 ft1" style="display: none">Languages Known: (Tick whichever applicable)</p>
                                                        <table style="display: none" class="t3">

                                                            <tr>
                                                                <td class="tr4 td35">
                                                                    <p class="p20 ft5">Language</p>
                                                                </td>
                                                                <td class="tr4 td36">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td37">
                                                                    <p class="p1 ft5">Read</p>
                                                                </td>
                                                                <td class="tr4 td38">
                                                                    <p class="p21 ft5">Write</p>
                                                                </td>
                                                                <td class="tr4 td39">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td40">
                                                                    <p class="p1 ft5">Speak</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr13 td41">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                                <td class="tr13 td30">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                                <td class="tr13 td42">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                                <td class="tr13 td43">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                                <td class="tr13 td33">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                                <td class="tr13 td44">
                                                                    <p class="p1 ft6">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr11 td41">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td30">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td42">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td43">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td33">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td44">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr11 td41">
                                                                    <p class="p1 ft2"></p>
                                                                </td>
                                                                <td class="tr11 td30">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td42">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td43">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td33">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td44">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr11 td41">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td30">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td42">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td43">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td33">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td44">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr11 td41">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td30">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td42">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td43">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td33">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td44">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr11 td41">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td30">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td42">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td43">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td33">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr11 td44">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <p class="p15 ft1">Educational Qualifications:</p>
                                                        <table cellpadding="0" cellspacing="0" class="t3" style="display: none">
                                                            <tr>
                                                                <td class="tr3 td45">
                                                                    <p class="p22 ft5">Qualification</p>
                                                                </td>
                                                                <td class="tr3 td46">
                                                                    <p class="p23 ft5">Course/</p>
                                                                </td>
                                                                <td class="tr3 td47">
                                                                    <p class="p24 ft5">Year of</p>
                                                                </td>
                                                                <td class="tr3 td48">
                                                                    <p class="p2 ft5">Institution /University</p>
                                                                </td>
                                                                <td class="tr3 td49">
                                                                    <p class="p23 ft5">Percentag</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr14 td50">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td51">
                                                                    <p class="p23 ft7">Specialisation</p>
                                                                </td>
                                                                <td class="tr14 td52">
                                                                    <p class="p25 ft5">Passing</p>
                                                                </td>
                                                                <td class="tr14 td53">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td54">
                                                                    <p class="p23 ft5">e</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td55">
                                                                    <p class="p26 ft1">X Std.</p>
                                                                </td>
                                                                <td class="tr4 td56">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td58">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr15 td50">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td51">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td52">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td53">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td54">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr16 td55">
                                                                    <p class="p26 ft9">10+2 /</p>
                                                                </td>
                                                                <td class="tr16 td56">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td58">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr16 td50">
                                                                    <p class="p26 ft9">Intermediate</p>
                                                                </td>
                                                                <td class="tr16 td51">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td53">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr16 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td55">
                                                                    <p class="p26 ft1">Graduation</p>
                                                                </td>
                                                                <td class="tr4 td56">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td58">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr17 td50">
                                                                    <p class="p1 ft10">&nbsp;</p>
                                                                </td>
                                                                <td class="tr17 td51">
                                                                    <p class="p1 ft10">&nbsp;</p>
                                                                </td>
                                                                <td class="tr17 td52">
                                                                    <p class="p1 ft10">&nbsp;</p>
                                                                </td>
                                                                <td class="tr17 td53">
                                                                    <p class="p1 ft10">&nbsp;</p>
                                                                </td>
                                                                <td class="tr17 td54">
                                                                    <p class="p1 ft10">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr10 td55">
                                                                    <p class="p26 ft1">Post Graduation</p>
                                                                </td>
                                                                <td class="tr10 td56">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr10 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr10 td58">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr10 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td50">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td51">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td53">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td55">
                                                                    <p class="p26 ft1">Others</p>
                                                                </td>
                                                                <td class="tr4 td56">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td58">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr15 td50">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td51">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td52">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td53">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                                <td class="tr15 td54">
                                                                    <p class="p1 ft8">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="0" cellspacing="0" class="t3" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            AutoGenerateColumns="False" AllowSorting="True"
                                                                            CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Specialization">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="School / Institute / University Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Grade / %">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label Style="border: none"
                                                                                            ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                    <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <p class="p15 ft1">Professional Qualification :</p>

                                                        <table cellpadding="0" cellspacing="0" class="t3" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                            HorizontalAlign="Left" CellPadding="4" BorderWidth="0px">

                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Education" HeaderStyle-Width="21%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Specialization" HeaderStyle-Width="21%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Institute / University Name" HeaderStyle-Width="30%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Grade / %" HeaderStyle-Width="13%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year" HeaderStyle-Width="13%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton
                                                                                            CssClass="link04" ID="LinkButton1" runat="server" CommandName="Delete" Text="Delete"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                        <div class="dclr"></div>
                                                        <p class="p11 ft1">List the technical Skills that qualify you for this job:</p>
                                                        <p class="p27 ft1">
                                                            <asp:TextBox ID="txt" runat="server" TextMode="MultiLine" Rows="10" Columns="50" Style="border: none"></asp:TextBox>
                                                        </p>
                                                        <p class="p28 ft1">Previous Employment details: (Start with the most recent employment)</p>
                                                        <table cellpadding="0" cellspacing="0" class="t4" style="display: none">
                                                            <tr>
                                                                <td class="tr3 td60">
                                                                    <p class="p18 ft5">Name and Address of the</p>
                                                                </td>
                                                                <td class="tr3 td61">
                                                                    <p class="p24 ft5">Start</p>
                                                                </td>
                                                                <td class="tr3 td47">
                                                                    <p class="p23 ft7">Relieving</p>
                                                                </td>
                                                                <td class="tr3 td61">
                                                                    <p class="p29 ft5">No. of</p>
                                                                </td>
                                                                <td class="tr3 td62">
                                                                    <p class="p23 ft7">Last</p>
                                                                </td>
                                                                <td class="tr3 td49">
                                                                    <p class="p23 ft7">Last drawn</p>
                                                                </td>
                                                                <td class="tr3 td49">
                                                                    <p class="p23 ft5">Reason for</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr16 td63">
                                                                    <p class="p18 ft5">Company</p>
                                                                </td>
                                                                <td class="tr16 td64">
                                                                    <p class="p25 ft5">Date</p>
                                                                </td>
                                                                <td class="tr16 td57">
                                                                    <p class="p23 ft5">Date</p>
                                                                </td>
                                                                <td class="tr16 td64">
                                                                    <p class="p30 ft5">Years</p>
                                                                </td>
                                                                <td class="tr16 td65">
                                                                    <p class="p23 ft7">Designation</p>
                                                                </td>
                                                                <td class="tr16 td59">
                                                                    <p class="p23 ft7">Salary</p>
                                                                </td>
                                                                <td class="tr16 td59">
                                                                    <p class="p23 ft7">leaving</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr14 td66">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td68">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr14 td54">
                                                                    <p class="p31 ft5">(P.A )</p>
                                                                </td>
                                                                <td class="tr14 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td63">
                                                                    <p class="p18 ft1">1.</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td65">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr18 td66">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td68">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td63">
                                                                    <p class="p18 ft1">2.</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td65">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr19 td66">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td68">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td63">
                                                                    <p class="p18 ft1">3.</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td65">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr18 td66">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td68">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr18 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr4 td63">
                                                                    <p class="p18 ft1">4.</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td57">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td64">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td65">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr4 td59">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="tr19 td66">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td52">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td67">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td68">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                                <td class="tr19 td54">
                                                                    <p class="p1 ft2">&nbsp;</p>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table cellpadding="0" cellspacing="0" class="t4">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div class="widget-content">
                                                                        <asp:GridView ID="grid_exp" runat="Server" Width="100%" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                                            AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left"
                                                                            HorizontalAlign="Left" CellPadding="4">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="10%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Start Date" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label style="border:none"  ID="lblstartdate" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Reliving Date" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Designation" HeaderStyle-Width="18%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label Style="border: none" ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label Style="border: none" ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Last Drawn Salary(P.A)" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Reason for Leaving" HeaderStyle-Width="5%">
                                                                                    <ItemTemplate>
                                                                                        <%-- <asp:Label style="border:none"  ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>--%>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                            <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                        <p class="p32 ft1">Professional references:</p>
                                                        <table cellpadding="0" cellspacing="0" class="t5" border="1">
                                                            <thead>
                                                                <tr>
                                                                    <td class="tr16 td69">
                                                                        <p class="p33 ft5">Name</p>
                                                                    </td>
                                                                    <td class="tr16 td70">
                                                                        <p class="p34 ft5">Address , mail id & Telephone No</p>
                                                                    </td>
                                                                    <td class="tr16 td71">
                                                                        <p class="p35 ft5">Occupation</p>
                                                                    </td>
                                                                    <td class="tr16 td72">
                                                                        <p class="p36 ft5">No. Of years of Acquaintance</p>
                                                                    </td>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <tr>
                                                                    <td class="tr4 td73">
                                                                        <p class="p38 ft1">1.</p>
                                                                    </td>
                                                                    <td class="tr4 td74">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                    <td class="tr4 td75">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                    <td class="tr4 td76">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="tr4 td73">
                                                                        <p class="p38 ft1">2.</p>
                                                                    </td>
                                                                    <td class="tr4 td74">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                    <td class="tr4 td75">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                    <td class="tr4 td76">
                                                                        <p class="p1 ft2">&nbsp;</p>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <p class="p12 ft1">
                                                            Are you related to any employee at AB Mauri : Yes/No
                    <asp:TextBox ID="tt" runat="server" Style="border: none"></asp:TextBox>
                                                        </p>
                                                        <p class="p39 ft1">
                                                            If Yes, Name:
                    <asp:TextBox ID="TextBox1" runat="server" Style="border: none"></asp:TextBox>
                                                            Relationship:<asp:TextBox ID="TextBox2" runat="server" Style="border: none"></asp:TextBox>
                                                        </p>
                                                        <p class="p40 ft1">I do hereby declare that the information furnished as above by me is true and correct to the best of my knowledge and belief. If any information furnished by me is proved to be incorrect and false, the management may take appropriate action against me including termination of my employment.</p>
                                                        <br />
                                                        <br />
                                                        <p class="p14 ft11">Signature of the candidate</p>
                                                        <br />
                                                        <br />
                                                        <p class="p41 ft1">
                                                            <span class="ft12">Date of Joining: </span>
                                                            <asp:Label ID="lbldoj" runat="server" Font-Bold="true"></asp:Label>
                                                        </p>

                                                        <br />
                                                        <br />

                                                        <br />
                                                        <br />

                                                        <br />
                                                        <br />
                                                    </div>
                                                </asp:Panel>
                                            </p>
                                        </div>
                                        <div>
                                            <p>
                                                <asp:Button ID="Button1" runat="server" Text="Print" OnClick="Button1_Click" />
                                                <asp:Panel ID="pnlbank" runat="server">
                                                    <div id="page_11">
                                                        <div>
                                                            <img src="../upload/logo/client-logo.png" style="float: right;">
                                                        </div>

                                                        <div class="dclr1"></div>
                                                        <p align="center" style="font: 23px 'Cambria'; color: #808080; line-height: 27px;">BankAccountDetailsForm</p>
                                                        <p class="p1 ft111">To</p>
                                                        <p class="p2 ft111">H. R. Department</p>
                                                        <p class="p2 ft111">A B Mauri India Pvt. Ltd.,</p>
                                                        <p class="p2 ft111">Bangalore</p>
                                                        <p class="p3 ft21 " style="width: 1000px">I would like my salary to be paid directly into my bank account, bank details given below:‐</p>
                                                        <table cellpadding="10" cellspacing="10" class="t01">
                                                            <tr>
                                                                <td>Employee Name</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txtfirstname1" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Employee Code</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txtempcode" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Contact No</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txtmobileno1" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <br />
                                                        <p class="p211 ft111 ">BANK DETAILS</p>
                                                        <br />
                                                        <table cellpadding="10" cellspacing="10" class="t01">
                                                            <tr>
                                                                <td>Name of Bank</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txt_bank_name" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Address of Bank</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox Style="border: none" ID="TextBox3" runat="server" Font-Bold="true"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Bank Account No.</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txt_bank_ac" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>Branch</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox Style="border: none" ID="txt_bankbrachname" runat="server" Font-Bold="true"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td>IFSC Code</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:Label ID="txt_ifsc" runat="server" Font-Bold="true"></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <td>MICR Code</td>
                                                                <td>:</td>
                                                                <td>
                                                                    <asp:TextBox Style="border: none" ID="TextBox4" runat="server" Font-Bold="true"></asp:TextBox></td>
                                                            </tr>
                                                        </table>
                                                        <br />
                                                        <br />
                                                        <p class="p61 ft31">‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐‐</p>
                                                        <p class="p71 ft51">SIGNATURE</p>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </div>
                                                </asp:Panel>
                                            </p>
                                        </div>
                                        <div>
                                            <p>
                                                <asp:Button ID="Button2" runat="server" Text="Print" OnClick="Button2_Click" />
                                                <asp:Panel ID="pnlind" runat="server">
                                                    <div id="page_1222">
                                                        <div>
                                                            <img src="../upload/logo/client-logo.png" style="margin-top: 10px; float: right">
                                                        </div>
                                                        <div class="dclr222"></div>
                                                        <p style="font: bold 16px 'Cambria'; text-decoration: underline; line-height: 19px;" align="center">NEW JOINEES INDUCTION COMPLETION FORM</p>
                                                        <br />
                                                        <p class="p1222 ft1222">
                                                            HR Induction Completed for NewJoinee :  
                    <asp:TextBox ID="TextBox5" runat="server" Style="border: none"></asp:TextBox>
                                                        </p>

                                                        <table cellpadding="0" cellspacing="0" class="t0">
                                                            <tr>
                                                                <td class="tr0222 td0222">
                                                                    <p class="p2222 ft1222">
                                                                        HR Induction Conducted by:
                                <asp:TextBox ID="ss" runat="server" Style="border: none"></asp:TextBox>
                                                                    </p>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="tr1222 td0222">
                                                                    <p class="p2222 ft1222">
                                                                        Date of Joining :
                                <asp:TextBox ID="TextBox6" runat="server" Style="border: none"></asp:TextBox>
                                                                    </p>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td class="tr2222 td0222">
                                                                    <p class="p2222 ft1222">
                                                                        Dat eof Completion : 
                                <asp:TextBox ID="TextBox7" runat="server" Style="border: none"></asp:TextBox>
                                                                    </p>

                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <p class="p1222 ft1222">The following forms and Policies have been handed over to the new joinee</p>
                                                        <p class="p5222 ft1222"><span class="ft1222">1.</span><span class="ft2222">JOINING FORMS</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">2.</span><span class="ft2222">ANTI BRIBERY POLICY</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">3.</span><span class="ft2222">ANTI FRAUD POLICY</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">4.</span><span class="ft2222">TRAVEL POLICY</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">5.</span><span class="ft2222">IT POLICY</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">6.</span><span class="ft2222">WHISTLE BLOWER POLICY</span></p>
                                                        <p class="p5222 ft1222"><span class="ft1222">7.</span><span class="ft2222">CEO’S STATEMENT ON HEALTH & SAFETY</span></p>
                                                        <p class="p6222 ft1222"><span class="ft1222">8.</span><span class="ft2222">TRAVEL REIMBURSMENT FORMS</span></p>

                                                        <p class="p7222 ft1222">The new joinee,here by agrees that he has readand agreed to abide by the above policies</p>
                                                        <table cellpadding="0" cellspacing="0" class="t1222">
                                                            <tr>
                                                                <td class="tr3222 td2222">
                                                                    <p class="p2222 ft1222">Signature of NewJoinee</p>
                                                                    <p class="p1222 ft1222">Date: </p>
                                                                    <p class="p1222 ft1222">Name:</p>
                                                                </td>
                                                                <td>&nbsp;&nbsp;&nbsp;</td>
                                                                <td class="tr3222 td3222">
                                                                    <p class="p2222 ft1222">Signature of Inductor</p>
                                                                    <p>Date: </p>
                                                                    <p class="p1222 ft1222">Name:</p>
                                                                </td>
                                                            </tr>
                                                        </table>


                                                        <br />
                                                        <br />
                                                        <br />
                                                        <br />
                                                    </div>
                                                </asp:Panel>
                                            </p>
                                        </div>
                                        <div>
                                            <p>
                                                <asp:Button ID="Button3" runat="server" Text="Print" OnClick="Button3_Click" />
                                                <asp:Panel ID="pnlnomone" runat="server">
                                                    <div id="page_14444">
                                                        <div>
                                                            <img src="../upload/logo/client-logo.png" style="float: right; padding-top: 50px;">
                                                        </div>
                                                        <div class="dclr4444"></div>
                                                        <p style="font: bold 19px 'Century Gothic'; text-decoration: underline; line-height: 23px;" align="center">INSURANCE NOMINATION FORM</p>
                                                        <p class="p14444 ft14444">To:</p>
                                                        <p class="p24444 ft14444">Manager – HR</p>
                                                        <p class="p24444 ft14444">AB Mauri India</p>
                                                        <p class="p24444 ft14444">Bangalore</p>
                                                        <table cellpadding="3" cellspacing="3" width="100%" border="1px">
                                                            <tr>
                                                                <td>Emp ID
                                                                </td>

                                                                <td>Employee Name
                                                                </td>

                                                                <td>Name of the Dependent
                                                                </td>


                                                                <td>Date Of Joining
                                                                </td>

                                                                <td>Date of Birth
                                                                </td>

                                                                <td>Gender
                                                                </td>

                                                                <td>Relationship Type
                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:TextBox ID="dd" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox8" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox9" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>


                                                                <td>

                                                                    <asp:TextBox ID="TextBox10" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox11" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox12" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox13" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:TextBox ID="TextBox14" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox15" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox16" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>


                                                                <td>

                                                                    <asp:TextBox ID="TextBox17" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox18" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox19" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox20" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:TextBox ID="TextBox21" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox22" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox23" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>


                                                                <td>

                                                                    <asp:TextBox ID="TextBox24" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox25" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox26" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox27" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td>

                                                                    <asp:TextBox ID="TextBox28" runat="server" Style="border: none" Width="50px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox29" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox30" runat="server" Style="border: none" Width="100px"></asp:TextBox>

                                                                </td>


                                                                <td>

                                                                    <asp:TextBox ID="TextBox31" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox32" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox33" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                                <td>

                                                                    <asp:TextBox ID="TextBox34" runat="server" Style="border: none" Width="100"></asp:TextBox>

                                                                </td>

                                                            </tr>
                                                        </table>
                                                        <p class="p134444 ft14444">Note:</p>
                                                        <p class="p144444 ft64444">Please note below details of my family for coverage under the Company’s Insurance Plan for Hospitalisation.</p>
                                                        <p class="p154444 ft64444">Family = self, spouse & children up age of 25 only</p>
                                                        <p class="p164444 ft64444">Personal accident coverage for self is up to 48 times gross per month.</p>
                                                    </div>
                                                </asp:Panel>
                                            </p>

                                        </div>
                                        <div>
                                            <asp:Button ID="Button4" runat="server" Text="Print" OnClick="Button4_Click" />
                                            <asp:Panel ID="pnlsudox" runat="server">
                                                <div id="page_1555">
                                                    <div>
                                                        <img src="../upload/logo/client-logo.png" style="float: right; padding-top: 50px;">
                                                    </div>
                                                    <div class="dclr555"></div>
                                                    <p class="p0555 ft0">The HR Manager</p>
                                                    <p class="p1555 ft0555">AB Mauri India Pvt. Ltd.,</p>
                                                    <p class="p2555 ft0555">Bangalore</p>
                                                    <p class="p3555 ft0555">Dear Sir,</p>
                                                    <p class="p4555 ft1555">Sodexho Declaration</p>
                                                    <p class="p5555 ft0555">I hereby authorize you to deduct Rs.1,300/= per month from my Supplementary Allowance in lieu of Sodexho Pass Food Coupons.</p>
                                                    <p class="p6555 ft2555">
                                                        Emp. No. :
                    <asp:Label ID="Label3" runat="server" Font-Bold="true"></asp:Label>
                                                    </p>
                                                    <p class="p7555 ft2555">
                                                        Emp. Name :
                    <asp:Label ID="Label5" runat="server" Font-Bold="true"></asp:Label>
                                                    </p>
                                                    <p class="p8555 ft0555">
                                                        You may commence deduction with effect from
                    <asp:TextBox ID="TextBox35" runat="server" Style="border: none" Width="100px"></asp:TextBox>
                                                        (month & year).
                                                    </p>
                                                    <p class="p9555 ft0555">Thanking you.</p>
                                                    <p class="p10555 ft0555">Yours truly</p>
                                                    <p class="p11555 ft2555">Singature :</p>
                                                    <p class="p10555 ft2555">Date :</p>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <br />


                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div>
                                            <asp:Button ID="Button5" runat="server" Text="Print" OnClick="Button5_Click" />
                                            <asp:Panel ID="pnlpf" runat="server">
                                                <div id="page_16666">
                                                    <p class="p06666 ft06666">Date:</p>
                                                    <p class="p16666 ft06666">The Trustees</p>
                                                    <p class="p06666 ft06666">Burns Philp India Pvt. Ltd. Employees’ Provident Fund</p>
                                                    <p class="p06666 ft16666">Azimganj House, 7 Camac Street</p>
                                                    <p class="p06666 ft06666">Block 7, 3<span class="ft2">rd </span>Floor,</p>
                                                    <p class="p26666 ft06666">Kolkata 700017</p>
                                                    <p class="p36666 ft06666">Dear Sirs,</p>
                                                    <p class="p46666 ft36666">Sub: Notice for the deduction of Voluntary Contribution under Rule – 12©</p>
                                                    <p class="p56666 ft46666">
                                                        I,
                                                        <asp:TextBox ID="txtname" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:TextBox>
                                                        member of the Burns Philp India Pvt. Ltd., Employees’ Provident Fund intend to make voluntary contribution @ (12) % or Rupees
                                                    </p>
                                                    <p class="p66666 ft46666">
                                                        <asp:TextBox ID="TextBox36" runat="server" Style="border: none" Width="200px" Font-Bold="true"></asp:TextBox>only per month with effect from
                                                        <asp:TextBox ID="TextBox37" runat="server" Style="border: none" Width="150px" Font-Bold="true"></asp:TextBox>
                                                        from my salary in respect of the Voluntary Contribution with effect from the month of
                                                        <asp:TextBox ID="TextBox38" runat="server" Style="border: none" Width="150px" Font-Bold="true"></asp:TextBox>until further instructions, and to pay the same to the Trustees of the Provident Fund vide Rules 12 © and 13 (a) & (c) of the Rules and Regulations of the Provident Fund
                                                    </p>
                                                    <p class="p76666 ft06666">Yours faithfully</p>
                                                    <p class="p86666 ft36666">Signature of the Member</p>
                                                    <p class="p06666 ft36666">
                                                        Empl No:
                                                        <asp:Label ID="lblempno" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:Label>
                                                    </p>
                                                    <p class="p96666 ft36666">
                                                        Name:
                                                        <asp:Label ID="lblempname3" runat="server" Style="border: none" Width="250px" Font-Bold="true"></asp:Label>
                                                    </p>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                        <div>
                                            <asp:Button ID="Button6" runat="server" Text="Print" OnClick="Button6_Click" />
                                            <asp:Panel ID="pnlidcard" runat="server">
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
                                                                            <asp:Label Style="border: none" ID="lblempname" runat="server" Text=""></asp:Label></strong>
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
                                                                            <asp:Label Style="border: none" ID="lblempcode" runat="server" Text="" Font-Bold="true"></asp:Label></strong>
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
                                                                            <asp:Label Style="border: none" ID="lblblooodgroup" runat="server" Text="" Font-Bold="true" Width="100px"></asp:Label></strong>
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
                                                                    <asp:Label Style="border: none" ID="lblresadd" runat="server" Text="" Font-Bold="true"></asp:Label>
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
                                        </div>
                                        <%-- <div>
                                            <ul>
                                                <li>Lorem ipsum dolor sit amet, consectetuer adipiscing elit.</li>
                                                <li>Aliquam tincidunt mauris eu risus.</li>
                                                <li>Vestibulum auctor dapibus neque.</li>
                                            </ul>
                                        </div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>

</body>
</html>
