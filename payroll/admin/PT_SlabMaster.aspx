<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PT_SlabMaster.aspx.cs" Inherits="payroll_admin_PT_SlabMaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>

    <script type="text/javascript">

        function ValidateData() {
            var State = document.getElementById('<%=ddl_state.ClientID%>');
            var FromDate = document.getElementById('<%=txtfromdate.ClientID%>');
            var ToDate = document.getElementById('<%=txttodate.ClientID%>');
            var FromAmount = document.getElementById('<%=txtamountto.ClientID%>');
            var ToAmount = document.getElementById('<%=txtamountto.ClientID%>');
            var TaxRebate = document.getElementById('<%=txtrate.ClientID%>');

            if (State.value == 0) {
                alert("Please Select State");
                return false;
            }


            if ((FromDate.value.length == 0) || (FromDate.value == null) || FromDate.value.charAt(0) == ' ') {
                alert("Please Enter From Date")
                return false;
            }
            if ((ToDate.value.length == 0) || (ToDate.value == null) || ToDate.value.charAt(0) == ' ') {
                alert("Please Enter To Date")
                return false;
            }

            if ((FromAmount.value.length == 0) || (FromAmount.value == null) || FromAmount.value.charAt(0) == ' ') {

                alert("Please Enter From Amount");
                return false;
            }
            if ((TaxRebate.value.length == 0) || (TaxRebate.value == null) || TaxRebate.value.charAt(0) == ' ') {

                if (!(/^\d+(\.\d{1,2})?$/.test(TaxRebate.value))) {
                    alert("Please Enter Only decimals In TaxRebate");
                    return false;
                }
            }

            if ((FromAmount.value.length == 0) || (FromAmount.value == null) || FromAmount.value.charAt(0) == ' ') {
                if (!(/^\d+(\.\d{1,2})?$/.test(FromAmount.value))) {
                    alert("Please Enter Only decimals In TaxRebate");
                    return false;
                }
            }
            if ((ToAmount.value.length == 0) || (ToAmount.value == null) || ToAmount.value.charAt(0) == ' ') {
                if (!(/^\d+(\.\d{1,2})?$/.test(ToAmount.value))) {
                    alert("Please Enter Only decimals In To Amount");
                    return false;
                }
            }
            return true;
        }
    </script>

    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="27%" class="txt02">Create PT Slab
                        </td>
                        <td width="73%" align="right" class="txt-red">
                            <span id="message" runat="server"></span>&nbsp;
                        </td>
                    </tr>
                </table>


                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="25%" class="frm-lft-clr123">Select State <span class="star"></span>
                        </td>
                        <td width="75%" class="frm-rght-clr123  border-bottom">
                            <asp:DropDownList ID="ddl_state" runat="server" CssClass="blue1" OnDataBound="ddl_state_DataBound" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>


                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">From Date  <span class="star"></span></td>

                        <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                            <asp:TextBox ID="txtfromdate" runat="server" CssClass="blue1" onkeypress="return enterdate()" onkeydown="return enterdate()"></asp:TextBox>&nbsp;
                            <asp:Image ID="Image5" runat="server" ImageUrl="~/images/clndr.gif" />
                            <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True"></cc1:CalendarExtender>

                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">To Date</td>

                        <td class="frm-rght-clr123" width="51%" style="border-top: none;">
                            <asp:TextBox ID="txttodate" runat="server" CssClass="blue1" onkeypress="return enterdate()" onkeydown="return enterdate()"></asp:TextBox>&nbsp;
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate" Enabled="True"></cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">From Amount <span class="star"></span></td>
                        <td class="frm-rght-clr123">
                            <asp:TextBox ID="txtamountfrom" runat="server" CssClass="blue1" size="30" ToolTip="Amount From" MaxLength="9" onfocus="if(this.value=='0.00')this.value=''" value="0.00" onblur="if(this.value=='')this.value='0.00'"></asp:TextBox>

                        </td>
                        <tr></tr>
                        <td class="frm-lft-clr123">To Amount</td>
                        <td class="frm-rght-clr123">
                            <asp:TextBox ID="txtamountto" runat="server" CssClass="blue1" size="30" ToolTip="Amount To" MaxLength="9" onfocus="if(this.value=='0.00')this.value=''" value="0.00" onblur="if(this.value=='')this.value='0.00'"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123">Tax Rate</td>
                        <td class="frm-rght-clr123">
                            <asp:TextBox ID="txtrate" runat="server" CssClass="blue1" size="30" ToolTip="Amount From" MaxLength="9" onfocus="if(this.value=='0.00')this.value=''" value="0.00" onblur="if(this.value=='')this.value='0.00'"></asp:TextBox>

                        </td>

                    </tr>
                    <tr>
                        <td colspan="2" class="frm-lft-clr123  border-bottom " align="right">
                            <asp:Button ID="btnAdd" runat="server" CssClass="button" Text="Add" OnClick="btnAdd_Click" OnClientClick="return ValidateData();" />
                            <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click" OnClientClick="return ValidateData();" />
                            <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 10px"></td>
                    </tr>
                </table>



                <table width="100%" border="0" cellspacing="0" cellpadding="0">

                    <tr>
                        <td>
                            <div class="widget-content">
                                <asp:GridView ID="grd_ptslabs" runat="server" AllowPaging="True" Width="100%" HorizontalAlign="Left" DataKeyNames="autoID" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False"
                                    AllowSorting="True" PageSize="100" BorderWidth="0px" CssClass ="table table-hover table-striped table-bordered table-highlight-head"
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
                            </div>
                        </td>
                    </tr>

                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
