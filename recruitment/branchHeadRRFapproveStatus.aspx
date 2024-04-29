<%@ Page Language="C#" AutoEventWireup="true" CodeFile="branchHeadRRFapproveStatus.aspx.cs" Inherits="recruitment_branchHeadRRFapproveStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top" class="blue-brdr-1" colspan="4">
                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3%">
                                <img src="../images/employee-icon.jpg" width="16" height="16" />
                            </td>
                            <td class="txt01">VIEW STATUS - RECRUITMENT REQUISITION FORM
                            </td>
                            <td align="right">
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="4" height="10px"></td>
            </tr>
            <tr>
                <td>
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="100%"
                        CssClass="ajax__tab_xp2" Style="border-bottom: 1px;border-bottom-style: solid;border-color: #ddd;">
                        <cc1:TabPanel ID="Tab_RRF1" runat="server" HeaderText="Approved Forms">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="grdRRF" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                                                EmptyDataText="No Data Found." CssClass="gvclass">
                                                <%--<PagerSettings Mode="NextPreviousFirstLast"   FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"/> --%>
                                                <Columns>
                                                    <%-- <asp:HyperLinkField HeaderText="Select" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/approveRequistionForm.aspx?Id={0}"
                                    Text="Select">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>--%>
                                                   <%-- <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:CheckBox ID="chkselect" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText=" Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No Of Posts">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requested By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requisition Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" View">
                                                        <ItemTemplate>
                                                            <a href='viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>

                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="Tab_RRF2" runat="server" HeaderText="Pending Forms">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="grdPendingRRF" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                                                EmptyDataText="No Data Found." CssClass="gvclass">
                                                <%--<PagerSettings Mode="NextPreviousFirstLast"   FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"/> --%>
                                                <Columns>
                                                    <%-- <asp:HyperLinkField HeaderText="Select" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/approveRequistionForm.aspx?Id={0}"
                                    Text="Select">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>--%>
                                                    <%--<asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:CheckBox ID="chkselect" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText=" Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No Of Posts">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requested By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requisition Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" View">
                                                        <ItemTemplate>
                                                            <a href='viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>

                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="Tab_RRF3" runat="server" HeaderText="Rejected Forms">
                            <ContentTemplate>
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td colspan="6">
                                            <asp:GridView ID="grdRejectedRRF" runat="server" AutoGenerateColumns="False" Width="100%"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                                                EmptyDataText="No Data Found." CssClass="gvclass">
                                                <%--<PagerSettings Mode="NextPreviousFirstLast"   FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous"/> --%>
                                                <Columns>
                                                    <%-- <asp:HyperLinkField HeaderText="Select" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/approveRequistionForm.aspx?Id={0}"
                                    Text="Select">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>--%>
                                                   <%-- <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:CheckBox ID="chkselect" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText=" Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No Of Posts">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requested By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requisition Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" View">
                                                        <ItemTemplate>
                                                            <a href='viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>

                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </cc1:TabPanel>

                    </cc1:TabContainer>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
