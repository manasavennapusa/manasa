<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pt_slab_master.aspx.cs" Inherits="payroll_admin_pt_slab_master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
      <link href="../../css/table.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>

</head>
<body>
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
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="27%" class="txt02">
                                                Create PT Slab
                                            </td>
                                            <td width="73%" align="right" class="txt-red">
                                                <span id="message" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
      
               
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                               Select State
                                            </td>
                                            <td width="75%" class="frm-rght-clr123  border-bottom">
                                               <asp:DropDownList ID="ddl_state" runat="server" CssClass="blue1"  DataSourceID="SqlDataSource1" DataTextField="state" DataValueField="id" OnDataBound="ddl_state_DataBound" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" AutoPostBack="true">   </asp:DropDownList>
                                              <%-- <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddl_state" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'  Operator="NotEqual" ValueToCompare="0" ToolTip="Select state" ValidationGroup="v"></asp:CompareValidator>--%>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_state" InitialValue="0" ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True" ValidationGroup="v"></asp:RequiredFieldValidator>
                                                 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" SelectCommand="select [ID],[state] from tbl_intranet_state_master where ID in(8,23,17,16,7,12,37,27,30,166)" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">From Date</td>
                                            <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                              <asp:TextBox ID="txtfromdate" runat="server" CssClass="blue1"  ></asp:TextBox>&nbsp;
                                              <asp:Image ID="Image5" runat="server" ImageUrl="~/images/clndr.gif" />
                                              <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True"> </cc1:CalendarExtender>
                                              <asp:RequiredFieldValidator ID="rev_fromdate" runat="server" ControlToValidate="txtfromdate" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter From Date"  ValidationGroup="v" Width="5px" SetFocusOnError="True">   </asp:RequiredFieldValidator>
                                             </td>
                                           </tr> <tr> 
                                            <td class="frm-lft-clr123">To Date</td>
                                             
                                             <td class="frm-rght-clr123 border-bottom" width="51%" style="border-top: none;">
                                              <asp:TextBox ID="txttodate" runat="server" CssClass="blue1"  ></asp:TextBox>&nbsp;
                                              <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                              <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate" Enabled="True"> </cc1:CalendarExtender>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter To Date "  ValidationGroup="v" Width="5px" SetFocusOnError="True">   </asp:RequiredFieldValidator>
                                              <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtfromdate" ControlToValidate="txttodate" ErrorMessage='<img src="../../images/error1.gif" alt="" />' Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date " ValidationGroup="v"></asp:CompareValidator>
                                             </td>
                                        </tr>
                                         <tr>
                                              <td class="frm-lft-clr123">From Ammount</td>
                                             <td class="frm-rght-clr123">
                                                 <asp:TextBox ID="txtamountfrom" runat="server" CssClass="blue1" size="30" ToolTip="Amount From" MaxLength="9"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtamountfrom" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator> 
                                             </td>
                                             <tr></tr>
                                              <td class="frm-lft-clr123"> To Ammount</td>
                                             <td class="frm-rght-clr123">
                                                 <asp:TextBox ID="txtamountto" runat="server" CssClass="blue1" size="30" ToolTip="Amount To" MaxLength="9"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtamountto" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator> 
                                             </td>
                                         </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">Tax Rate</td>
                                             <td class="frm-rght-clr123">
                                                 <asp:TextBox ID="txtrate" runat="server" CssClass="blue1" size="30" ToolTip="Amount From" MaxLength="9"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrate" Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RequiredFieldValidator> 
                                             </td>
                                            
                                         </tr>
                                     <tr><td colspan="2" class="frm-lft-clr123  border-bottom ">
                                          <asp:Button ID="btnupdate" runat="server" CssClass="button" Text="Update" OnClick="btnupdate_Click" ValidationGroup="v" Visible="false" />
                                         <asp:Button ID="btnsave" runat="server" CssClass="button" Text="Save" OnClick="btnsave_Click" ValidationGroup="v" />
                                         <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click" />
                                         </td></tr>
                                    </table>
                    
          

            <table  width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td>
                        <div class="widget-content">
                         <asp:GridView ID="grd_ptslabs" runat="server"  AllowPaging="True" Width="100%" HorizontalAlign="Left" DataKeyNames="ID" CellPadding="4" CaptionAlign="Left" AutoGenerateColumns="False" AllowSorting="True" PageSize="100" BorderWidth="0px"  CssClass="table table-hover table-striped table-bordered table-highlight-head" >
                         <PagerSettings PageButtonCount="100"></PagerSettings>

                          <Columns>
                         <asp:BoundField DataField="StateId" HeaderText="State" SortExpression="StateId"> </asp:BoundField>
                         <asp:BoundField DataField="FromDate" HeaderText="From Date" ReadOnly="True" SortExpression="FromDate"></asp:BoundField>
                         <asp:BoundField DataField="ToDate" HeaderText="To Date" SortExpression="ToDate"> </asp:BoundField>
                         <asp:BoundField DataField="Amountfrom" HeaderText="From Ammount" SortExpression="Amountfrom"> </asp:BoundField>
                         <asp:BoundField DataField="AmountTo" HeaderText="To Ammount" SortExpression="AmountTo"> </asp:BoundField>
                         <asp:BoundField DataField="TaxRate" HeaderText="Tax Rate" SortExpression="TaxRate"> </asp:BoundField>
                          <asp:TemplateField><ItemTemplate>
                          <a href="pt_slab_master.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id") %>" target="_self" class="link05">Edit</a>
                           </ItemTemplate></asp:TemplateField>                            
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