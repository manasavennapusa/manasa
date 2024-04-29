<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ptslabmaster.aspx.cs" Inherits="payroll_admin_ptslabmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Information</title>



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
                                                                            <td class="txt01">Create PT Slab</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="27%" class="txt02"></td>
                                                                            <td width="73%" align="right" class="txt-red">
                                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" class="txt02">
                                                                    <table  border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width:40%">Select State</td>
                                                                            <td class="frm-rght-clr123 border-bottom">&nbsp;<asp:DropDownList ID="ddl_state" runat="server" CssClass="span4" OnDataBound="ddl_state_DataBound" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">From Date  <span class="star"></span></td>

                                                                            <td class="frm-rght-clr123 border-bottom" width="40%" style="border-top: none;">
                                                                                <asp:TextBox ID="txtfromdate" runat="server" CssClass="span4" onkeypress="return enterdate()" onkeydown="return enterdate()"></asp:TextBox>&nbsp;
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True"></cc1:CalendarExtender>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">To Date</td>

                                                                            <td class="frm-rght-clr123" width="40%" style="border-top: none;">
                                                                                <asp:TextBox ID="txttodate" runat="server" CssClass="span4" onkeypress="return enterdate()" onkeydown="return enterdate()"></asp:TextBox>&nbsp;
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate" Enabled="True"></cc1:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">From Amount <span class="star"></span></td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txtamountfrom" runat="server" CssClass="span4" size="30" ToolTip="Amount From" MaxLength="9" onfocus="if(this.value=='0.00')this.value=''" value="0.00" onblur="if(this.value=='')this.value='0.00'"></asp:TextBox>

                                                                            </td>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123">To Amount</td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txtamountto" runat="server" CssClass="span4" MaxLength="9" onblur="if(this.value=='')this.value='0.00'" onfocus="if(this.value=='0.00')this.value=''" size="30" ToolTip="Amount To" value="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123">Tax Rate</td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txtrate" runat="server" CssClass="span4" MaxLength="9" onblur="if(this.value=='')this.value='0.00'" onfocus="if(this.value=='0.00')this.value=''" size="30" ToolTip="Amount From" value="0.00"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-rght-clr123 border-bottom" width="40%">
                                                                                    <asp:Button ID="btnAdd" runat="server" CssClass="button" OnClick="btnAdd_Click" OnClientClick="return ValidateData();" Text="Add" />
                                                                                    <asp:Button ID="btnsave" runat="server" CssClass="button" OnClick="btnsave_Click" OnClientClick="return ValidateData();" Text="Save" />
                                                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" OnClick="btnreset_Click" Text="Reset" />
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">

                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="left" colspan="2"></td>
                                                                            </tr>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" valign="top"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td height="5" class="txt02">View PT Details</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-rght-clr123 border-bottom" colspan="2">&nbsp;&nbsp;
                                                   <asp:GridView ID="grd_ptslabs" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left" DataKeyNames="autoID" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                                       AllowSorting="True" PageSize="100" BorderWidth="0px" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                       OnRowDeleting="grd_ptslabs_RowDeleting" EmptyDataText="No Data Found For The Selected State">
                                                       <PagerSettings PageButtonCount="100"></PagerSettings>

                                                       <Columns>
                                                           <asp:BoundField DataField="State" HeaderText="State" SortExpression="StateId"></asp:BoundField>
                                                           <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" SortExpression="FromDate"></asp:BoundField>
                                                           <asp:BoundField DataField="ToDate" HeaderText="To Date" SortExpression="ToDate"></asp:BoundField>
                                                           <asp:BoundField DataField="Amountfrom" HeaderText="From Amount" SortExpression="Amountfrom"></asp:BoundField>
                                                           <asp:BoundField DataField="AmountTo" HeaderText="To Amount" SortExpression="AmountTo"></asp:BoundField>
                                                           <asp:BoundField DataField="TaxRate" HeaderText="Tax Rate" SortExpression="TaxRate"></asp:BoundField>
                                                           <asp:TemplateField>
                                                               <ItemTemplate>
                                                                   <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" CssClass="link05" CommandName="Delete"></asp:LinkButton>
                                                               </ItemTemplate>
                                                           </asp:TemplateField>
                                                       </Columns>
                                                   </asp:GridView>

                                                                </td>

                                                            </tr>
                                                            <tr>
                                                                <td align="left" colspan="2"></td>
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
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
