<%@ Page Language="C#" AutoEventWireup="true" CodeFile="veiwPostedVacancies.aspx.cs" Inherits="recruitment_veiwPostedVacancies" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
    <script language="JavaScript" type="text/javascript" src="js/popup1.js"></script>
</head>
<body>

    <form id="form1" runat="server">
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">

                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:GridView ID="grdRRF" runat="server" AutoGenerateColumns="False" Width="95%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found." CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText="Vacancies">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="txt02" width="25%">Designation:
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="txt02" width="25%">Education:
                                                </td>
                                                 <td>
                                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("educational_qualifications") %>'></asp:Label>
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td class="txt02">Experience:
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("experience") %>'></asp:Label>
                                                </td>
                                            </tr>
                                          
                                            <tr>
                                                <td class="txt02">Job Location:
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="txt02">Job Description:
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("job_description") %>'></asp:Label>
                                                </td>
                                            </tr>
                                             <tr>
                                                <td class="txt02">CTC:
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ctc") %>'></asp:Label>
                                                </td>
                                            </tr>
                                            
                                            <tr>
                                                <td class="txt02">Walk-in Address:
                                                </td>
                                                 <td>
                                                    <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("location") %>'></asp:Label>
                                                </td>
                                            </tr>

                                            
                                            <tr>
                                                <td height="15px" colspan="2" style="background-color:white">

                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
