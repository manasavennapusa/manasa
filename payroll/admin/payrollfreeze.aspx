<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payrollfreeze.aspx.cs" Inherits="payroll_admin_payrollfreeze" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" height="463px">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td height="20" valign="top" class="txt02">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="27%" class="txt01">Freeze Payroll
                                                                                </td>
                                                                                <td width="73%" align="right" class="txt-red">
                                                                                    <span id="message" runat="server"></span>&nbsp;
                                                                                </td>
                                                                            </tr>

                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>

                                                                                <td class="frm-lft-clr123 border-bottom" width="11%">Financial Year</td>
                                                                                <td class="frm-rght-clr123 border-bottom" width="28%">
                                                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="span3"
                                                                                        OnDataBound="dd_branch_DataBound" OnSelectedIndexChanged="dd_branch_SelectedIndexChanged" AutoPostBack="true">
                                                                                    </asp:DropDownList>

                                                                                </td>

                                                                            </tr>
                                                                        </table>
                                                                        <b>
                                                                            <p style="color: red;">* Please Note that the system will not allow to make any changes to payroll data once it freezed !</p>
                                                                        </b>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div class="widget-content">
                                                                            <asp:GridView ID="payheadgird"
                                                                                runat="server"
                                                                                CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                DataKeyNames="MONTH"
                                                                                AutoGenerateColumns="False"
                                                                                EmptyDataText="Sorry no record found"
                                                                                AllowPaging="True"
                                                                                PageSize="15" OnPageIndexChanged="payheadgird_PageIndexChanged">
                                                                                <Columns>

                                                                                    <asp:BoundField DataField="YEAR" HeaderText="YEAR" SortExpression="YEAR"></asp:BoundField>
                                                                                    <asp:BoundField DataField="MONTH" HeaderText="MONTH" SortExpression="MONTH"></asp:BoundField>
                                                                                    <asp:BoundField DataField="branch_name" HeaderText="Branch" SortExpression="branch_name"></asp:BoundField>
                                                                                    <asp:BoundField DataField="branch_id" HeaderText="Branch Id" SortExpression="branch_id"></asp:BoundField>

                                                                                   
                                                                                    <asp:TemplateField HeaderText="Status" HeaderStyle-Width="20%">
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("status") %>' class="label label-info" Visible='<%#Eval("status").ToString()=="Unfreezed"?true:false%>'></asp:Label>
                                                                                            <asp:Label ID="Label9" runat="server" Text='<%# Bind("status") %>' class="label label-success" Visible='<%#Eval("status").ToString()=="Freezed"?true:false%>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Freeze" HeaderStyle-Width="20%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="LinkButton1" runat="server" EnableTheming="True" OnClick="LinkButton1_Click" ForeColor="#2e86de">Freeze</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    <asp:TemplateField HeaderText="Unfreeze" HeaderStyle-Width="20%">
                                                                                        <ItemTemplate>
                                                                                            <asp:LinkButton ID="lnknunfreez" runat="server" EnableTheming="True" OnClick="lnknunfreez_Click" ForeColor="#2e86de">UnFreeze</asp:LinkButton>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                </Columns>
                                                                                <PagerSettings Mode="NumericFirstLast" />

                                                                            </asp:GridView>

                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
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

    </form>
</body>
</html>
