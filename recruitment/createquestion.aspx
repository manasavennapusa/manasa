<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createquestion.aspx.cs" Inherits="recruitment_createquestion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
    <script language="javascript" type="text/javascript" src="js/JavaScriptValidations.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" colspan="4">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" alt="" width="16" height="16" />
                                </td>
                                <td class="txt01">
                                    <asp:Label ID="lblheader" runat="server" Text="ADD QUESTION"></asp:Label>
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Question code
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <%--<asp:TextBox ID="TextBox1" runat="server" CssClass="blue1" MaxLength="200"  ></asp:TextBox>--%>
                    </td>
                </tr>

                <tr>
                    <td class="frm-lft-clr123" width="30%">Subject
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:DropDownList ID="ddl_subject" runat="server" CssClass="blue1"
                            Height="20px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_subject"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Subject" InitialValue="0"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Category
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:DropDownList ID="ddl_category" runat="server" CssClass="blue1" Height="20px">
                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                            <asp:ListItem Value="Written">Written</asp:ListItem>
                            <asp:ListItem Value="Online">Online</asp:ListItem>
                            <asp:ListItem Value="Interview">Interview</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_category"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Category" InitialValue="0"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Sub Subject
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:DropDownList ID="ddl_sub_subject" runat="server" CssClass="blue1"
                            Height="20px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_sub_subject"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Sub Subject" InitialValue="0"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Questin Description
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_ques_dec" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_ques_dec"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Questin Description"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Option A
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_optionA" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_optionA"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Option A"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="frm-lft-clr123" width="30%">Option B
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_optionB" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_optionB"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Option B"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                    <td class="frm-lft-clr123" width="30%">Option C
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_optionC" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="frm-lft-clr123" width="30%">Option D
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_optionD" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td class="frm-lft-clr123" width="30%">Option E
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_optionE" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Correct Answer
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <%--<asp:CheckBoxList ID="chklAns" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="A" Text="A"></asp:ListItem>
                            <asp:ListItem Value="B" Text="B"></asp:ListItem>
                            <asp:ListItem Value="C" Text="C"></asp:ListItem>
                            <asp:ListItem Value="D" Text="D"></asp:ListItem>
                            <asp:ListItem Value="E" Text="E"></asp:ListItem>
                        </asp:CheckBoxList>--%>
                         
                        <asp:CheckBox ID="chk_A" runat="server" Text="A" />&nbsp;
                    <asp:CheckBox ID="chk_B" runat="server" Text="B" />&nbsp;
                    <asp:CheckBox ID="chk_C" runat="server" Text="C" />&nbsp;
                    <asp:CheckBox ID="chk_D" runat="server" Text="D" />&nbsp;
                    <asp:CheckBox ID="chk_E" runat="server" Text="E" />
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Marks
                    </td>
                    <td class="frm-rght-clr123" width="25%">
                        <asp:TextBox ID="txt_marks" runat="server" CssClass="blue1" MaxLength="2" onkeypress="return isNumber()"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_marks"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Marks"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_marks" MaximumValue="20" MinimumValue="1"
                            Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Numbers(1-20)" Type="Integer"
                            ValidationGroup="v" Width="6px" SetFocusOnError="True"></asp:RangeValidator>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123 border-bottom" width="30%">Active
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%" align="left">
                        <table  border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="rbtnlactive" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="true">Yes</asp:ListItem>
                                        <asp:ListItem Value="false">No</asp:ListItem>
                                    </asp:RadioButtonList></td>
                                <td>
                                   &nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="rbtnlactive" 
                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Select Active"
                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td colspan="2" align="right" >
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" ValidationGroup="v" OnClick="btnadd_Click" />&nbsp;
                               <asp:Button ID="btnclear" runat="server" Text=" Clear" CssClass="button" OnClick="btnclear_Click" />&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdQuestion" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <%-- <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                        <asp:CheckBox ID="chkselect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Question Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQues_code" runat="server" Text='<%# Eval("question_code") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sub-Subject Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSub_s_name" runat="server" Text='<%# Eval("sub_subject_name") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="12%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblcategoryname" runat="server" Text='<%# Eval("category_name") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="10%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblques_desc" runat="server" Text='<%# Eval("question_desc") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="20%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option A">
                                    <ItemTemplate>
                                        <asp:Label ID="lblA" runat="server" Text='<%# Eval("option_a_desc") %>'>></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option B">
                                    <ItemTemplate>
                                        <asp:Label ID="lblB" runat="server" Text='<%# Eval("option_b_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option C">
                                    <ItemTemplate>
                                        <asp:Label ID="lblC" runat="server" Text='<%# Eval("option_c_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option D">
                                    <ItemTemplate>
                                        <asp:Label ID="lblD" runat="server" Text='<%# Eval("option_d_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Option E">
                                    <ItemTemplate>
                                        <asp:Label ID="lblE" runat="server" Text='<%# Eval("option_e_desc") %>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createquestion.aspx?Id={0}"
                                    Text="Edit">
                                    <ControlStyle CssClass="link05" Width="6%" />
                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:HyperLinkField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
