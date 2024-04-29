<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reademployeesatisfactionform.aspx.cs" Inherits="admin_reademployeesatisfactionform" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <link href="../css/blue1.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .gvclass th {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }
    </style>
    <style type="text/css">
        .star:before {
            content: " *";
        }
    </style>

    <link href="../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../js/main.css" rel="stylesheet" type="text/css" />
    <link href="../css/blue1.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                    DisplayAfter="1">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div>
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <%--<td width="3%">
                                            <img src="../images/employee-icon.jpg" width="16" height="16" />
                                        </td>--%>
                                        <td class="txt01">View Employee Satisfaction Survey
                                        </td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" align="left" valign="middle"></td>
                        </tr>
                        <tr>
                            <td valign="top" height="10">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td class="frm-lft-clr123" width="19%">Year  <span class="star"></span></td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="drp_year" runat="server" AutoPostBack="True" CssClass="blue1" Width="109px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="drp_year" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="19%">Term <span class="star"></span></td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="drphalfyear" runat="server" CssClass="blue1" Width="109px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="First Half">First Half </asp:ListItem>
                                                <asp:ListItem Value="Selecond Half ">Second Half </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="drphalfyear" ErrorMessage="&lt;img src=&quot;../img/error1.gif&quot; alt=&quot;&quot; /&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="19%">&nbsp; </td>
                                        <td class="frm-rght-clr123 border-bottom" width="19%">
                                            <asp:Button ID="btn_submit" runat="server" class="button" OnClick="btn_submit_Click" Text="Submit" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="20"></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <div class="widget-content">
                                    <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="sno" BorderWidth="0px" CellPadding="4" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found"
                                        ToolTip="Read Feedback" CssClass="table table-hover table-striped table-bordered table-highlight-head" OnPageIndexChanging="suggestionsgrid_PageIndexChanging">
                                        <%--   OnRowDeleting="suggestions_RowDeleting" OnRowCancelingEdit="suggestions_RowCancelingEdit" OnRowEditing="suggestions_RowEditing" 
          OnRowUpdating="suggestions_RowUpdating"  --%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Empcode">
                                                <ItemTemplate>
                                                    <a href="viewemployeesatisfactionform.aspx?sno=<%#DataBinder.Eval(Container.DataItem, "sno")%>"
                                                        target="_self" class="link05">
                                                        <%#DataBinder.Eval(Container.DataItem, "empcode")%></a>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Overall Satisfaction">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "overallsatisfaction")%>
                                                </ItemTemplate>
                                                <%--  <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Feel of Validate Trimedx">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "IfeelIamvaluedatTriMedx")%>
                                                </ItemTemplate>
                                                <%--<ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "createddate")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Status">
       <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <%#DataBinder.Eval(Container.DataItem, "status")%>
       </ItemTemplate>
       <EditItemTemplate>
       <asp:DropDownList id="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>' CssClass="blue1" Height="20px">
       <asp:ListItem Value="0">Not Approved</asp:ListItem>
       <asp:ListItem Value="1">Approved</asp:ListItem></asp:DropDownList>
       </EditItemTemplate>
        <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                            <%--                                        <asp:TemplateField HeaderText="Posted Date">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>--%>
                                            <%--<asp:TemplateField>                                                
       <EditItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
       </EditItemTemplate>
                                                  
       <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" CssClass="link05" Text="Edit" ToolTip="Edit" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
       </ItemTemplate>                                                       
           <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                        </Columns>
                                        <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                        <PagerStyle CssClass="frm-lft-clr123" />
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                        <div>
                        </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>

