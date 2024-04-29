<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sectionmaster_detail.aspx.cs"
    Inherits="payroll_admin_sectionmaster_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
   

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
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

                 <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                <td class="txt01">
                                                    Section Master</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td height="20" valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="27%" class="txt02">
                                                </td>
                                                <td width="73%" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="txt02">
                                        Create Section<%--<div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">Create Section</a>
  <div class="categoryitems">
  <ul>
  <li>--%><table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td height="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Section Name</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    &nbsp;<asp:TextBox ID="txtsectionname" runat="server" CssClass="span4" 
                                                        MaxLength="50"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsectionname"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Section Description</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    &nbsp;<asp:TextBox ID="txtsectdescription" runat="server" CssClass="span4" 
                                                        TextMode="MultiLine"></asp:TextBox>&nbsp;
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsectionname"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                           
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123 border-bottom">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;</td>
                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                        ValidationGroup="s" ToolTip="Click to submit " />&nbsp;
                                                </td>
                                              
                                            </tr>
                                        </table>
                                        <%--</li>
                              </ul></div></div>--%>
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
                        <td>
                            <div class="glossymenu1">
                                <a class="menuheader1 expandable" href="#">View Section</a>
                                <div class="categoryitems">
                                    <ul>
                                        <li>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                  <%--  <td class="frm-rght-clr123" colspan="2">--%>
                                                        <caption>
                                                            &nbsp;&nbsp;
                                                            <asp:GridView ID="sectiongird" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered table-highlight-head" DataKeyNames="" DataSourceID="SqlDataSource1" EmptyDataText="Sorry no record found" PageSize="30">
                                                                <Columns>
                                                                    <asp:BoundField DataField="sname" HeaderText="Section Name" SortExpression="sname" />
                                                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT sname,description from tbl_payroll_sectionmaster"></asp:SqlDataSource>
                                                            <%-- </td>--%>
                                                    </caption>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td class="txt02">
                            Create Section Detail
                            <%--<div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">Create Section Detail</a>
  <div class="categoryitems">
  <ul>
  <li>--%>
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td height="5" valign="top">
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Section Name</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddlsectionname" runat="server"  CssClass="span4"
                                                        DataSourceID="SqlDataSource12" DataTextField="sname" DataValueField="sname">
                                                    </asp:DropDownList>
                                                    <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="select distinct sname from tbl_payroll_sectionmaster">
                                                    </asp:SqlDataSource>
                                                </td>
                                            </tr>
                                           
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    &nbsp;Section Details</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtsectiondetail" runat="server" CssClass="span4" 
                                                        MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtsectiondetail"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                           
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    &nbsp;Section Details Despt.</td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txtsecdetaildesc" runat="server" CssClass="span4" 
                                                        TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsectiondetail"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator></td>
                                            </tr>
                                            <%--<tr>
                                                <td align="left" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>--%>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123 border-bottom">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;</td>
                                                <td width="75%" class="frm-rght-clr123 border-bottom">
                                                    &nbsp;
                                                    <asp:Button ID="btncreatsection" runat="server" Text="Submit" CssClass="button" ValidationGroup="v"
                                                        ToolTip="Click to submit " OnClick="btncreatsection_Click" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                               <%-- <tr>
                                    <td>
                                    </td>
                                </tr>--%>
                            </table>
                            <%--</li></ul></div></div>--%>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="glossymenu1">
                                <a class="menuheader1 expandable" href="#">View Section Detail </a>
                                <div class="categoryitems">
                                    <ul>
                                        <li>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td height="5">
                                                    </td>
                                                </tr>
                                                <tr>
                                                   <%-- <td class="frm-rght-clr123" colspan="2">--%>
                                                        <caption>
                                                            &nbsp;&nbsp;
                                                            <asp:GridView ID="sectiondetailgrid" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="table table-hover table-striped table-bordered table-highlight-head" DataKeyNames="" DataSourceID="SqlDataSource2" EmptyDataText="Sorry no record found" PageSize="30">
                                                                <Columns>
                                                                    <asp:BoundField DataField="section_name" HeaderText="Section Name" SortExpression="section_name" />
                                                                    <asp:BoundField DataField="section_detail" HeaderText="Section Detail" SortExpression="section_detail" />
                                                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="System.Data.SqlClient" SelectCommand="SELECT section_name,section_detail,description from tbl_payroll_sectiondetail"></asp:SqlDataSource>
                                                            <%-- </td>--%>
                                                    </caption>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                                              </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnsbmit" />
                <asp:PostBackTrigger ControlID="btncreatsection" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
