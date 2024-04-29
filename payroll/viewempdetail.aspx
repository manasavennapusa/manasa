<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewempdetail.aspx.cs" Inherits="Admin_company_empmaster"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Employee View" %>

<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
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
        @import "../css/ajax__tab_xp2.css";
    </style>

    <script type="text/javascript" src="../js/tabber.js"></script>

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>
    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:scriptmanager id="ScriptManager1" runat="server">
        </asp:scriptmanager>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td colspan="2">
                        <cc1:tabcontainer id="TabContainer1" runat="server" activetabindex="0" width="100%"
                            cssclass="ajax__tab_xp2">
                        <cc1:TabPanel ID="Tab_Job" runat="server" HeaderText="Job Detail">
                            <ContentTemplate>
                                <div>
                                    <!--.......................GENERAL TABLE.....................-->
                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">
                                                Employee Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        First Name
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtfirstname" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Middle Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtmiddlename" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        Last Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtlastname" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        Employee Code
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="txtempcode" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Employee Card No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_card_no" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        Gender
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_gender" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">
                                                Work Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        Employee Status
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="drpempstatus" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        Branch Name
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_branch_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Department
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_dept_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Designation
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_desigination" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Ext. Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtext" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        Date of Leaving
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtdol" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        Employee Role
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_emp_role" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="43%">
                                                                        Division
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="57%">
                                                                        <asp:Label ID="lbl_division_name" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Grade
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Date of Joining
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="doj" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">
                                                                        Salary Calculation From
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="txtsalary" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        Reason for Leaving
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="txtreason" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" class="txt02">
                                                Payroll Details
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="50%" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="33%">
                                                                        ESI Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="67%">
                                                                        <asp:Label ID="esino" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="33%" class="frm-lft-clr123">
                                                                        PF Number
                                                                    </td>
                                                                    <td width="67%" class="frm-rght-clr123">
                                                                        <asp:Label ID="pfno" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        PAN Number
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="panno" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td valign="top">
                                                            <table width="99%" border="0" align="right" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="43%" class="frm-lft-clr123">
                                                                        ESI Dispensary
                                                                    </td>
                                                                    <td width="57%" class="frm-rght-clr123">
                                                                        <asp:Label ID="esidesp" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" width="43%">
                                                                        PF Number for Dept File
                                                                    </td>
                                                                    <td class="frm-rght-clr123" width="57%">
                                                                        <asp:Label ID="pfno_dept" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">
                                                                        Ward/Circle
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="ward" runat="server"></asp:Label>
                                                                        &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel1" runat="server" HeaderText="Professional">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Educational Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="updatepannel2d" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4"
                                                                        AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="education"
                                                                        HorizontalAlign="Left" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px"
                                                                        CssClass="gvclass" Border="1px solid #ddd">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Education">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="20%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="School ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Grade / %">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                        ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                        </HeaderStyle>
                                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Professional Qualification :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:GridView ID="grid_Pro_education" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                        AllowSorting="True" CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left"
                                                                        CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px"
                                                                        CssClass="gvclass" Border="1px solid #ddd">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Education">
                                                                                <ItemTemplate>
                                                                                    <headerstyle width="15%" horizontalalign="Left" />
                                                                                    <itemstyle width="15%" horizontalalign="Left" />
                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Institute / University Name ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Grade / %">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label43" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                        ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                        </HeaderStyle>
                                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr-main">
                                                Experience Details :
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 1px;">
                                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                                    <ContentTemplate>
                                                        <table style="border-collapse: collapse" bordercolor="#c9dffb" cellspacing="0" cellpadding="4"
                                                            width="100%" border="1">
                                                            <tr>
                                                                <td colspan="4">
                                                                    <asp:GridView ID="grid_exp" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                        AllowSorting="True" CaptionAlign="Left" DataKeyNames="comp_name" HorizontalAlign="Left"
                                                                        CellPadding="4" EmptyDataText="no data found !" BorderStyle="Solid" BorderWidth="1px"
                                                                        CssClass="gvclass" Border="1px solid #ddd">
                                                                        <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="Company Name">
                                                                                <ItemTemplate>
                                                                                    <headerstyle horizontalalign="Left" />
                                                                                    <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="21%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Address / Location ">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" Width="10%" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="43%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Exp.">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Labewdl43" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Year">
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-<asp:Label
                                                                                        ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                <ItemStyle HorizontalAlign="Left" Width="13%"></ItemStyle>
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                        </HeaderStyle>
                                                                        <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                        <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel2" runat="server" HeaderText="Personal Detail">
                            <ContentTemplate>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <div>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="txt02" colspan="2">
                                                        Personal Information
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                Date of Birth
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="67%">
                                                                                <asp:Label ID="txt_DOB" runat="server" Width="100px"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                Payment Mode
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lblpaymentmode" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Religion
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtrelg" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                D.L. No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_dl_no" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <div id="paymentmode" runat="server" visible="true" align="center">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td align="left" class="frm-lft-clr123" width="18%">
                                                                        Bank Name for Salary
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123" width="32%">
                                                                        <asp:Label ID="txt_bank_name" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" class="frm-lft-clr123" width="18%">
                                                                        Account No for Salary
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123" width="32%">
                                                                        <asp:Label ID="txt_bank_ac" runat="server" Width="142px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                </tr>
                                                                <tr>
                                                                    <td align="left" class="frm-lft-clr123">
                                                                        Bank Name for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_bank_name_reimbursement" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td>
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" class="frm-lft-clr123">
                                                                        Account No for Reimbursement
                                                                    </td>
                                                                    <td align="left" class="frm-rght-clr123">
                                                                        <asp:Label ID="txt_bank_ac_reimbursement" runat="server" Width="142px"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" colspan="2">
                                                        <table valign="top" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">
                                                                                Mobile No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="txtmobileno" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                Blood Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txtbloodgrp" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 5px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                Email Id
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_email" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                Passport No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_passportno" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
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
                                                    <td class="txt02" colspan="2" height="5">
                                                        Relationship Details
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td valign="top" width="50%">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="33%">
                                                                                Father's Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_f_f_name" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="txt02" colspan="2" height="5">
                                                                                Employee Marital Status
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="33%">
                                                                                Marital Status
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="ddlpersonalstatus" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="43%">
                                                                                Mother's Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="txt_m_fname" runat="server"></asp:Label>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" height="5">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 12px" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td>
                                                                    <table id="tbl1" cellspacing="0" cellpadding="0" width="100%" border="0" runat="server"
                                                                        visible="false">
                                                                        <tr>
                                                                            <td colspan="2">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td style="height: 13px" class="txt02" colspan="2">
                                                                                                        Spouse Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="frm-lft-clr123" width="33%">
                                                                                                        Name
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="67%">
                                                                                                        &nbsp;<asp:Label ID="txt_sp_fname" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2" height="5">
                                                                                                        &nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 86px" class="frm-lft-clr123">
                                                                                                        Date of Anniversary
                                                                                                    </td>
                                                                                                    <td class="frm-rght-clr123" width="57%">
                                                                                                        <asp:Label ID="txt_doa" runat="server"></asp:Label>&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">
                                                                                                        Children Detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td class="txt02" colspan="2">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                            <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                                <tr>
                                                                                                    <td class="txt02" align="left" colspan="2">
                                                                                                        &nbsp;&nbsp;
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td colspan="2" height="5">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" colspan="2">
                                                                                            <asp:GridView ID="grid_child" runat="Server" Width="100%" AutoGenerateColumns="False"
                                                                                                AllowSorting="True" CaptionAlign="Left" DataKeyNames="Child_name" HorizontalAlign="Left"
                                                                                                CellPadding="4" BorderStyle="Solid" BorderWidth="1px" EmptyDataText="no data found !"
                                                                                                CssClass="gvclass" Border="1px solid #ddd">
                                                                                                <RowStyle CssClass="frm-rght-clr1234"></RowStyle>
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Child Name ">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("child_name") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="150px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Date of Birth">
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="Label4" runat="Server" Text='<%# Eval("child_dob") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123"></HeaderStyle>
                                                                                                        <ItemStyle HorizontalAlign="Left" Width="200px" CssClass="frm-rght-clr1234"></ItemStyle>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123">
                                                                                                </HeaderStyle>
                                                                                                <AlternatingRowStyle CssClass="frm-rght-clr12345"></AlternatingRowStyle>
                                                                                                <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td valign="top" width="50%">
                                                                                        </td>
                                                                                        <td valign="top">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" style="height: 14px">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel3" runat="server" HeaderText="Contact Detail">
                            <ContentTemplate>
                                <div>
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                    <ContentTemplate>
                                                        <div>
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td height="5">
                                                                                </td>
                                                                                <td class="txt02">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txt02" align="center">
                                                                                    Present Address
                                                                                </td>
                                                                                <td class="txt02" align="center">
                                                                                    Permanent Address
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="txt02">
                                                                                    &nbsp;
                                                                                </td>
                                                                                <td class="txt02">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tr>
                                                                                <td valign="top" width="50%">
                                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                                Address 1
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="67%">
                                                                                                <asp:Label ID="txt_pre_add1" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="33%">
                                                                                                Address 2
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="67%">
                                                                                                <asp:Label ID="txt_pre_add2" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                                Mode of Transport
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                <asp:Label ID="lblmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="2" height="5">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <table cellspacing="0" cellpadding="0" width="99%" align="right" border="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="43%">
                                                                                                Address 1
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123" width="57%">
                                                                                                <asp:Label ID="txt_per_add1" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Address 2
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_add2" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                City
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                State
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Country
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Zip Code
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123">
                                                                                                Phone No.
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123">
                                                                                                <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom">
                                                                                                Pick Up Point
                                                                                            </td>
                                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                                <asp:Label ID="txtmodeoftransport" runat="server"></asp:Label>&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel4" runat="server" HeaderText="Leave Details">
                            <ContentTemplate>
                                <div style="overflow-x: hidden; overflow-y: scroll; width: 100%; height: 193px;">
                                    <asp:GridView ID="balancegrid" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                        BorderWidth="0px" CellPadding="4" Font-Names="Arial" Font-Size="11px" Width="100%"
                                        EmptyDataText="No Data Available !" DataSourceID="SqlDataSource1" CssClass="gvclass"
                                        Border="1px solid #ddd">
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <RowStyle Height="5px" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Leave">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="25%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind("leavename")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Entitled Days">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="25%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind("entitled_days")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Used">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="25%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind("used") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Available">
                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="25%" />
                                                <ItemStyle CssClass="frm-rght-clr123" HorizontalAlign="Left" VerticalAlign="Top"
                                                    Width="25%" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="SqlDataSource1" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        runat="server" SelectCommand="sp_leave_myballeave" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:ControlParameter ControlID="hidd_empcode" Name="empcode" PropertyName="Value"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <asp:HiddenField ID="hidd_empcode" runat="server" />
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="TabPanel5" runat="server" HeaderText="Payroll Details">
                            <ContentTemplate>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td valign="middle" class="txt02" height="33px" colspan="2">
                                            Employee Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" valign="top" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" colspan="2">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="14%">
                                                        Code
                                                    </td>
                                                    <td class="frm-rght-clr123" width="10%">
                                                        <asp:Label ID="empCode" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="14%">
                                                        Name
                                                    </td>
                                                    <td class="frm-rght-clr123" colspan="3">
                                                        <asp:Label ID="empName" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" width="14%">
                                                        Branch
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:Label ID="empBranch" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="14%%">
                                                        Department
                                                    </td>
                                                    <td class="frm-rght-clr123" width="20%">
                                                        <asp:Label ID="empDepartment" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="15%">
                                                        Designation
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:Label ID="empDesignation" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" width="14%">
                                                        PF
                                                    </td>
                                                    <td class="frm-rght-clr123" width="15%">
                                                        <asp:Label ID="lbl_pf" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123" width="11%">
                                                        ESI
                                                    </td>
                                                    <td class="frm-rght-clr123" colspan="3">
                                                        <asp:Label ID="lbl_esi" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" width="14%">
                                                        Applied From
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" width="15%">
                                                        <asp:Label ID="lbl_mth_yr" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="frm-lft-clr123 border-bottom" width="11%">
                                                        Applied To
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" colspan="3">
                                                        <asp:Label ID="lbl_mth_yr_t" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="middle" class="txt02" height="33px" colspan="2">
                                            Employee Pay Structure Details
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="head-2" valign="top" colspan="2">
                                            <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                CellPadding="4" DataKeyNames="Head_Name" Width="100%" AutoGenerateColumns="False"
                                                BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                                CssClass="gvclass" Border="1px solid #ddd">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Head Name">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l0" runat="server" Text='<%# Bind ("Head_Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Calculation Type">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("cal_type") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Rate (%)">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("Rate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("Amount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--<asp:TemplateField HeaderText="Basis">
                                       
                                       <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                                       
                                               <ItemStyle Width="12%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                                               
                                               <ItemTemplate>
                                                    
                                                    <asp:Label ID="l4" runat="server" Text ='<%# Bind ("Basis") %>'></asp:Label>
                                      
                                                </ItemTemplate>
                                
                                </asp:TemplateField> --%>
                                                    <asp:TemplateField HeaderText="Rounding Method">
                                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                        <ItemStyle Width="30%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind ("Rounding_Method") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                <RowStyle Height="5px" />
                                                <PagerStyle CssClass="frm-lft-clr123"></PagerStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:tabcontainer>
                    </td>
                </tr>
            </table>
        </form>
    </div>
</body>
</html>
