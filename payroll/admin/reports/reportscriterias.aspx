<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reportscriterias.aspx.cs"
    Inherits="payroll_admin_reports_reportscriterias" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Criterias</title>
    <style type="text/css" media="all">
        @import "../../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

    <script type="text/javascript" src="../../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../../js/ddaccordion.js"></script>

    <script type="text/javascript" src="../../../js/timepicker.js"></script>

    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group
            contentclass: "submenu", //Shared CSS class name of contents group
            collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
            animatedefault: false, //Should contents open by default be animated into view?
            persiststate: true, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["suffix", "<img src='../images/plus3.gif' class='statusicon' />", "<img src='../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
        })

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Selection Criterias for
                                        <asp:Label ID="lblfrmname" runat="server" CssClass="txt01"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 123px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 200px">
                                        Year
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        &nbsp;<asp:DropDownList ID="drpYear" runat="server" Width="221px" CssClass="blue1">
                                            <asp:ListItem Value="0">---Select Year---</asp:ListItem>
                                            <asp:ListItem Value="1">1990</asp:ListItem>
                                            <asp:ListItem Value="2">1991</asp:ListItem>
                                            <asp:ListItem Value="3">1992</asp:ListItem>
                                            <asp:ListItem Value="4">1993</asp:ListItem>
                                            <asp:ListItem Value="5">1994</asp:ListItem>
                                            <asp:ListItem Value="6">1995</asp:ListItem>
                                            <asp:ListItem Value="7">1996</asp:ListItem>
                                            <asp:ListItem Value="8">1997</asp:ListItem>
                                            <asp:ListItem Value="9">1998</asp:ListItem>
                                            <asp:ListItem Value="10">1998</asp:ListItem>
                                            <asp:ListItem Value="11">1999</asp:ListItem>
                                            <asp:ListItem Value="12">2000</asp:ListItem>
                                            <asp:ListItem Value="13">2001</asp:ListItem>
                                            <asp:ListItem Value="14">2002</asp:ListItem>
                                            <asp:ListItem Value="15">2003</asp:ListItem>
                                            <asp:ListItem Value="16">2004</asp:ListItem>
                                            <asp:ListItem Value="17">2005</asp:ListItem>
                                            <asp:ListItem Value="18">2006</asp:ListItem>
                                            <asp:ListItem Value="19">2007</asp:ListItem>
                                            <asp:ListItem Value="20">2008</asp:ListItem>
                                            <asp:ListItem Value="21" Selected="True">2009</asp:ListItem>
                                            <asp:ListItem Value="22">2010</asp:ListItem>
                                            <asp:ListItem Value="23">2011</asp:ListItem>
                                            <asp:ListItem Value="24">2012</asp:ListItem>
                                            <asp:ListItem Value="25">2013</asp:ListItem>
                                            <asp:ListItem Value="26">2014</asp:ListItem>
                                            <asp:ListItem Value="27">2015</asp:ListItem>
                                            <asp:ListItem Value="28">2016</asp:ListItem>
                                            <asp:ListItem Value="29">2017</asp:ListItem>
                                            <asp:ListItem Value="30">2018</asp:ListItem>
                                            <asp:ListItem Value="31">2019</asp:ListItem>
                                            <asp:ListItem Value="32">2020</asp:ListItem>
                                            <asp:ListItem Value="33">2021</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:CompareValidator ID="compareYear" runat="server" CssClass="blue1" ErrorMessage="Please Select Year"
                                            Width="189px" ControlToValidate="drpYear" Type="Integer" ValueToCompare="0" Operator="NotEqual"></asp:CompareValidator>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 200px">
                                        Month
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        &nbsp;<asp:DropDownList ID="drpMonth" runat="server" Width="221px" CssClass="blue1">
                                            <asp:ListItem Value="0">---Select Month---</asp:ListItem>
                                            <asp:ListItem Value="1">January</asp:ListItem>
                                            <asp:ListItem Value="2">February</asp:ListItem>
                                            <asp:ListItem Value="3" Selected="True">March</asp:ListItem>
                                            <asp:ListItem Value="4">April</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">June</asp:ListItem>
                                            <asp:ListItem Value="7">July</asp:ListItem>
                                            <asp:ListItem Value="8">August</asp:ListItem>
                                            <asp:ListItem Value="9">September</asp:ListItem>
                                            <asp:ListItem Value="10">October</asp:ListItem>
                                            <asp:ListItem Value="11">November</asp:ListItem>
                                            <asp:ListItem Value="12">December</asp:ListItem>
                                        </asp:DropDownList>
                                        &nbsp;<asp:CompareValidator ID="compareMonth" runat="server" ControlToValidate="drpMonth"
                                            CssClass="blue1" ErrorMessage="Please Select Month" Type="Integer" ValueToCompare="0"
                                            Width="189px" Operator="NotEqual"></asp:CompareValidator>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 200px">
                                        PF Group
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        &nbsp;<asp:DropDownList ID="drppfgroup" runat="server" Width="221px" CssClass="blue1"
                                            DataSourceID="SqlDataSource" DataTextField="group_name" DataValueField="id">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="select id, group_name from tbl_payroll_pfgroup_details">
                                        </asp:SqlDataSource>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 200px">
                                        Order By
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        &nbsp;<asp:DropDownList ID="drporderby" runat="server" Width="221px" CssClass="blue1">
                                            <asp:ListItem Value="empcode">Employee Code</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" style="width: 200px">
                                        &nbsp;
                                    </td>
                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit the created leave"
                                            OnClick="btnsbmit_Click" />&nbsp;
                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2" style="height: 34px">
                                        Mandatory Fields (<img src="../../../images/error1.gif" alt="" />)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divesihalfyearlychallanmessage" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    ESI Half Yearly Challan
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divpfmonthlyreportmessage" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Monthly PF Report
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton7" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divesimonthlyreportmessage" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Monthly ESI Report
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divesiform6message" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Monthly ESI Form - 6
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divesiform5message" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Monthly ESI Form - 5
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divpfform12Amessage" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Details of Contribution of employee, month by 25th
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divpfform6Amessage" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Yearly Statement of Contribution with Form 3A
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divform5message" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 617px; height: 24px;">
                                                                    Details of Newly Enrolled Employees
                                                                </td>
                                                                <td align="right" style="height: 24px;">
                                                                    <asp:LinkButton ID="lnkshowreport" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="head-2" valign="top" colspan="2">
                                        <div id="divform5details" runat="server" style="width: 712px">
                                            <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GridViewform5" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="Records not found for newly enrolled employees !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Father/Husband">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("Husband_Father") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PF Acont No.">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("pf_no") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DOB">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="11%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("dob") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DOJ">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="11%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("doj") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PF Group">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("group_name") %>'></asp:Label>
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
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table width="712px" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td valign="middle" class="txt02" colspan="1" style="width: 712px">
                                                    <div id="divform10message" runat="server" style="width: 712px" visible="false">
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 712px">
                                                            <tr>
                                                                <td valign="middle" class="txt02" style="width: 606px; height: 23px;">
                                                                    Details of Resign Employees
                                                                </td>
                                                                <td align="right" style="height: 23px;">
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="lnkshowreport_Click">Show Report</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="head-2" valign="top" colspan="2">
                                        <div id="divfrom10details" runat="server" style="width: 712px">
                                            <table width="711" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td>
                                                        <asp:GridView ID="GridViewform10" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="Records not found for newly enrolled employees !"  CssClass="gvclass" Border="1px solid #ddd">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Code">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PF Acont No.">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="14%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("pf_no") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Name">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Father/Husband">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="22%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("Husband_Father") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Leaving Date">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind ("emp_doleaving") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Leaving Reason">
                                                                    <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                    <ItemStyle Width="21%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind ("reason_leaving") %>'></asp:Label>
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
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 14px">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate> 
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
