<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createcompany.aspx.cs" Inherits="Admin_Company_createcompany"
    Title="Create Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>

    <script type="text/javascript" src="../js/tabber.js"></script>

    <script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />

</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../images/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">
                                            Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div>
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tbody>
                                <tr>
                                    <td valign="top" class="blue-brdr-1" colspan="2">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                
                                                <td class="txt01">
                                                    Create Company
                                                </td>
                                                <td align="right">
                                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                            <tbody>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="22%">
                                                        Company Name<span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="25%">
                                                        <asp:TextBox ID="txtcmpname" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtcmpname"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Employee Code" ValidationGroup="c"
                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td width="1%" rowspan="11">
                                                        &nbsp;
                                                    </td>
                                                    <td class="frm-lft-clr123" width="22%">
                                                        Establishment Date
                                                    </td>
                                                    <td class="frm-rght-clr123" width="30%">
                                                        <asp:TextBox ID="txt_est_date" runat="server" CssClass="blue1" Width="100px">01/01/1950</asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" ToolTip="click to open calendar" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            TargetControlID="txt_est_date">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Company Type
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="drp_type" runat="server" CssClass="blue1" Width="145px">
                                                            <asp:ListItem Value="0">--Select Company Type--</asp:ListItem>
                                                            <asp:ListItem Value="1">Pvt</asp:ListItem>
                                                            <asp:ListItem Value="2">Pvt. Ltd.</asp:ListItem>
                                                            <asp:ListItem Value="3">Ltd.</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="frm-lft-clr123">
                                                        PAN Number
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_pan" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        TIN Number
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txttin" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-lft-clr123">
                                                        Registration Number
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtregno" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        TAN Number
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_tanno" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-lft-clr123">
                                                        TDS Circle
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_tds" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Company PF Trust
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:DropDownList ID="drp_pftrust" runat="server" CssClass="blue1" Width="145px"
                                                            Height="20px">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drp_pftrust"
                                                            ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                            ToolTip="Select PF"><img src="../images/../img/error1.gif" alt="" /></asp:CompareValidator>
                                                    </td>
                                                    <td class="frm-lft-clr123">
                                                        Company Engaged
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_comp_eng" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123">
                                                        Responsible Person
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txt_resppers" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                    <td class="frm-lft-clr123">
                                                        Company URL
                                                    </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtcmpurl" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">
                                                        Logo Image
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <File_Uploader:File_Uploader ID="f_upload_rep1" runat="server" FileTypeRange="bmp,jpg"
                                                            MaxWidth="300" Vgroup="c" />
                                                    </td>
                                                    <td colspan="3">
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" height="20" valign="top">
                                                        PF Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123" width="22%">
                                                                    EPF Employer Code.
                                                                </td>
                                                                <td class="frm-rght-clr123" width="25%">
                                                                    <asp:TextBox ID="txt_epfno" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                </td>
                                                                <td width="1%" rowspan="3">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123 border-bottom"  width="22%" id="e4" runat="server">
                                                                    Sub EPF Employer Code.
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" width="30%"  id="e1" runat="server">
                                                                    <asp:TextBox ID="txt_dbffile" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                           
                                                            <tr>
                                                                <td ID="e2" runat="server" class="frm-lft-clr123 border-bottom" visible="false">
                                                                    Extension
                                                                </td>
                                                                <td ID="e3" runat="server" class="frm-rght-clr123 border-bottom" visible="false">
                                                                    <asp:TextBox ID="txt_fileext" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td height="8">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" height="20" valign="top">
                                                        ESI Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom" width="22%">
                                                                     ESI Employer Code.
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" width="25%">
                                                                    <asp:TextBox ID="txt_esino" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                </td>
                                                                <td width="1%" rowspan="3">
                                                                    &nbsp;
                                                                </td>
                                                                <td class="frm-lft-clr123 border-bottom" width="22%">
                                                                    Sub ESI Employer Code.
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" width="30%">
                                                                    <asp:TextBox ID="txt_esilocalno" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td class="txt02" width="48%">
                                                                Corporate Address
                                                            </td>
                                                            <td class="txt02" width="52%">
                                                                Correspondance Address<asp:CheckBox ID="check1" runat="server" Text="Same as Above"
                                                                    AutoPostBack="True" Font-Bold="True" OnCheckedChanged="check1_CheckedChanged">
                                                                </asp:CheckBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2" height="5">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td class="frm-lft-clr123" width="22%">
                                                                            Address 1<span class="star"></span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="25%">
                                                                            <asp:TextBox ID="txt_pre_add1" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_pre_add1"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Address 1" ValidationGroup="c"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td width="1%" rowspan="13">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="frm-lft-clr123" width="22%">
                                                                            Address 1
                                                                        </td>
                                                                        <td class="frm-rght-clr123" width="30%">
                                                                            <asp:TextBox ID="txt_per_add1" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Address 2
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_pre_Add2" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Address 2
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_per_add2" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            City<span class="star"></span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_pre_city" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_pre_city"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter City Name" ValidationGroup="c"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            City
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_per_city" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                  
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            State<span class="star"></span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_pre_state" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_pre_state"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter State Name" ValidationGroup="c"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            State
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_per_state" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Country<span class="star"></span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_pre_country" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_pre_country"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Country Name" ValidationGroup="c"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Country
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_per_country" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                   
                                                                    <tr>
                                                                        <td class="frm-lft-clr123">
                                                                            Zip Code<span class="star"></span>
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_pre_zip" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_pre_zip"
                                                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Zip Code" ValidationGroup="c"
                                                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td class="frm-lft-clr123">
                                                                            Zip Code
                                                                        </td>
                                                                        <td class="frm-rght-clr123">
                                                                            <asp:TextBox ID="txt_per_zip" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    
                                                                    <tr>
                                                                        <td class="frm-lft-clr123 border-bottom">
                                                                            Phone No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                            <asp:TextBox ID="txt_pre_phone" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                        <td class="frm-lft-clr123 border-bottom">
                                                                            Phone No.
                                                                        </td>
                                                                        <td class="frm-rght-clr123 border-bottom">
                                                                            <asp:TextBox ID="txt_per_phone" runat="server" CssClass="blue1" Width=""></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <tr>
                                            <td height="10">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="right" width="80%">
                                                            <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Create" CssClass="button"
                                                                ValidationGroup="c"></asp:Button>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="7">
                                            </td>
                                        </tr>
                            </tbody>
                        </table>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        </form>
    </div>
</body>
</html>
