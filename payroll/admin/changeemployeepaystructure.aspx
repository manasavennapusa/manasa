<%@ Page Language="C#" AutoEventWireup="true" CodeFile="changeemployeepaystructure.aspx.cs"
    Inherits="payroll_admin_editemployeepaystructure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="top: 160px;">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img alt="" src="../../images/loading.gif" />
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
                                                                            <%--     <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                            <td class="txt01">Employee New Pay Structure Master
                                                                            </td>
                                                                            <td align="right">
                                                                                <samp id="backid" runat="server" visible="false">
                                                                                    <a href="paystructureempview.aspx">Back</a></samp>
                                                                            </td>
                                                                            <td class="txt02" align="right">
                                                                                <asp:Label ID="lblCheckEmpRecords" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="4">
                                                                    <div id="Updatedconfirmationdiv" runat="server" visible="false">
                                                                        <table id="table3" border="0" cellpadding="0" cellspacing="4" width="100%px">
                                                                            <tr>
                                                                                <td height="10" colspan="4"></td>
                                                                            </tr>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" style="height: 123px">
                                                                    <div id="Divallhide" runat="server">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td class="frm-lft-clr123">Employee Code
                                                                                </td>
                                                                                <td class="frm-rght-clr123">
                                                                                    <asp:TextBox ID="txt_employee" size="40" CssClass="span4" runat="server" ToolTip="Employee Code"></asp:TextBox>
                                                                                    <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');"
                                                                                        class="link05">Pick Employee</a></span>
                                                                                </td>
                                                                            </tr>

                                                                            <tr>
                                                                            <td class="frm-lft-clr123">PF/ESI
                                                                            </td>
                                                                            <td class="frm-rght-clr123">&nbsp;
                                                                                <table style="width: 50%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chk_pf" runat="server" Text="PF" AutoPostBack="true" OnCheckedChanged="chk_pf_CheckedChanged" />
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chk_esi" runat="server" Text="ESI" /></td>
                                                                                         <td>
                                                                                            <asp:CheckBox ID="chk_pt" runat="server" Text="PT" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">PF Calculation Mode
                                                                            </td>
                                                                            <td class="frm-rght-clr123">&nbsp;
                                                                                 
                                                                                <table style="width: 50%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="chk_1500" runat="server" Text="PF on 15000" GroupName="r" Enabled="false" TextAlign="Right" /></td>
                                                                                        <td>
                                                                                            <asp:RadioButton ID="chk_basic" runat="server" Text="PF on Basic + Fixed Allowance" GroupName="r" Enabled="false" TextAlign="Right" /></td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table style="width: 50%;">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:CheckBox ID="chk_vpf" runat="server" Text="VPF" GroupName="a" TextAlign="Right" OnCheckedChanged="chk_vpf_CheckedChanged" AutoPostBack="true" /></td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="txt_vpf" runat="server" Enabled="false" Width="120px"  /><b></b></td>
                                                                                    </tr>
                                                                    </table>


                                                                </td>
                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123 border-bottom">Applied From
                                                                                </td>
                                                                                <td class="frm-rght-clr123 border-bottom">
                                                                                    <asp:DropDownList ID="dd_month_f" runat="server" CssClass="span4" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="dd_month_f_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    <asp:DropDownList ID="dd_year_f" runat="server" CssClass="span4" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="dd_year_f_SelectedIndexChanged">
                                                                                    </asp:DropDownList>
                                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month_f"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year_f"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year of Recovery"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="5" colspan="4"></td>
                                                                            </tr>
                                                                            <%--  <tr >
                   <td class="frm-lft-clr123">
                       Applied To</td>
                   <td class="frm-rght-clr123">
                   <asp:DropDownList id="dd_month_t" runat="server" Width="90px" CssClass="blue1">
                       <asp:ListItem Value="0">N/A</asp:ListItem>
                   </asp:DropDownList>
                   <asp:DropDownList id="dd_year_t" runat="server" Width="90px" CssClass="blue1">
                       <asp:ListItem Value="0">N/A</asp:ListItem>
                   </asp:DropDownList>&nbsp;</td>
               </tr>
                
                <tr>
                       <td height="5" colspan="4"></td>
                </tr>--%>
                                                                            <tr>
                                                                                <td colspan="4" height="5" valign="middle" class="txt02">View Old Structure
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" height="25" valign="middle" class="txt02">
                                                                                    <%--                        <div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">View Old Structure</a>
  <div class="categoryitems">
  <ul>
  <li>--%><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
          <td colspan="4" style="height: 5px"></td>
      </tr>
      <tr>
          <td class="frm-lft-clr123" width="17%">PF
          </td>
          <td class="frm-rght-clr123" width="18%">
              <asp:Label ID="lbl_pf" runat="server"></asp:Label>
          </td>
          <td class="frm-lft-clr123" width="16%">ESI
          </td>
          <td width="49%" class="frm-rght-clr123">
              <asp:Label ID="lbl_esi" runat="server"></asp:Label>
          </td>
      </tr>

      <tr>
          <td class="frm-lft-clr123 border-bottom" width="17%">Applied From
          </td>
          <td class="frm-rght-clr123 border-bottom" width="18%" colspan="3">
              <asp:Label ID="lbl_mth_yr" runat="server"></asp:Label>
          </td>
          <%-- <td class="frm-lft-clr123" width="16%">Applied To</td >
                 <td class="frm-rght-clr123" >
                     &nbsp;<asp:DropDownList id="dd_omth" runat="server" Width="90px" CssClass="blue1">
                         <asp:ListItem Value="0">N/A</asp:ListItem>
                     </asp:DropDownList> 
                     <asp:DropDownList id="dd_oyr" runat="server" Width="90px" CssClass="blue1">
                         <asp:ListItem Value="0">N/A</asp:ListItem>
                     </asp:DropDownList><asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_omth"
                         Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                         Operator="NotEqual" ToolTip="Select Month of Recovery" ValueToCompare="0" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator><asp:CompareValidator
                             ID="CompareValidator4" runat="server" ControlToValidate="dd_oyr" Display="Dynamic"
                             ErrorMessage='<img src="../../images/error1.gif" alt="" />' Operator="NotEqual"
                             ToolTip="Select Year of Recovery" ValueToCompare="0" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator></td>--%>
      </tr>
      <tr>
          <td class="frm-lft-clr123 border-bottom" width="17%">VPF
          </td>
          <td class="frm-rght-clr123 border-bottom" width="18%">
              <asp:Label ID="lbl_vpf" runat="server"></asp:Label>
          </td>
          <td class="frm-lft-clr123 border-bottom" width="16%">VPF Amount
          </td>
          <td width="49%" class="frm-rght-clr123 border-bottom">
              <asp:Label ID="lbl_vpf_p" runat="server"></asp:Label>
          </td>
      </tr>
      <tr>
          <td height="15" colspan="4"></td>
      </tr>
      <tr>
          <td colspan="4">
              <div class="widget-content">
                  <asp:GridView ID="grid_oldstructure"
                      runat="server"
                      AutoGenerateColumns="false"
                      DataKeyNames="payhead"
                      EmptyDataText="Sorry No Records Found"
                      CssClass="table table-hover table-striped table-bordered table-highlight-head">
                      <Columns>
                          <asp:TemplateField HeaderText="Pay Head">

                              <ItemTemplate>
                                  <asp:Label ID="l2" runat="server" Text='<%# Bind("head_name")%>' Font-Bold="false" Font-Size="13px"></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Pay Calculation Type">

                              <ItemTemplate>
                                  <asp:Label ID="l3" runat="server" Text='<%# Bind("cal_type")%>' Font-Bold="false" Font-Size="13px"></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Rate (%)">

                              <ItemTemplate>
                                  <asp:Label ID="l4" runat="server" Text='<%# Bind("rate")%>' Font-Bold="false" Font-Size="13px"></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Amount">

                              <ItemTemplate>
                                  <asp:Label ID="l5" runat="server" Text='<%# Bind("amount")%>' Font-Bold="false" Font-Size="13px"></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                          <asp:TemplateField HeaderText="Round Type">

                              <ItemTemplate>
                                  <asp:Label ID="l6" runat="server" Text='<%# Bind("rounding_method")%>' Font-Bold="false" Font-Size="13px"></asp:Label>
                              </ItemTemplate>
                          </asp:TemplateField>
                      </Columns>

                  </asp:GridView>
              </div>
          </td>
      </tr>
  </table>
                                                                                    <%--</li>
  </ul></div>
  </div>--%>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4" valign="middle" class="txt02">New Pay Structure
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" style="width: 11%">Pay Head
                                                                                </td>
                                                                                <td class="frm-rght-clr123" style="width: 27%">
                                                                                    <asp:DropDownList ID="drpPayHead" runat="server" OnSelectedIndexChanged="drpPayHead_SelectedIndexChanged"
                                                                                        AutoPostBack="True" ToolTip="Pay Head" CssClass="span4" DataSourceID="payheadsqldatasource"
                                                                                        DataTextField="payhead_name" DataValueField="id">
                                                                                    </asp:DropDownList>
                                                                                    <asp:SqlDataSource ID="payheadsqldatasource" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                        ProviderName="<%$ ConnectionStrings:intranetConnectionString.ProviderName %>"
                                                                                        SelectCommand="[sp_payroll_payheadname]"></asp:SqlDataSource>
                                                                                    <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="drpPayHead"
                                                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                        ToolTip="Select Pay Head"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    <asp:Label ID="lblpayHeadMsg" runat="server" Width="342px" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" style="width: 11%">Pay Calculation Type
                                                                                </td>
                                                                                <td class="frm-rght-clr123" style="width: 27%">
                                                                                    <asp:DropDownList ID="drpPayCalType" runat="server" AutoPostBack="True"
                                                                                        OnSelectedIndexChanged="drpPayCalType_SelectedIndexChanged" ToolTip="Pay Calculation Type"
                                                                                        CssClass="span4">
                                                                                        <asp:ListItem Value="0" Selected="True">Monthy Flat Rate</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Attendance</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Computed on Basis%</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Computed on Basic</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="reqPayCalType" runat="server" ControlToValidate="drpPayCalType"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                        ToolTip="Select Pay Calculation Type" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="4"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div id="valuebase" runat="server" visible="true">
                                                                                        <table id="TABLE1" width="100%" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" style="width: 11%">Value Basis
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" style="width: 27%">
                                                                                                    <asp:TextBox ID="txtValueBase" runat="server" CssClass="span4" size="40" ToolTip="Rate"
                                                                                                        AutoPostBack="True" OnTextChanged="txtValueBase_TextChanged"></asp:TextBox>&nbsp;
                                                                                       <asp:Label ID="lblpercent" runat="server" Text="%" ForeColor="Red" ToolTip="Percent"
                                                                                           Visible="False"></asp:Label>
                                                                                                    <asp:RequiredFieldValidator ID="reqRate" runat="server" ControlToValidate="txtValueBase"
                                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                                        ToolTip="Enter Rate" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <asp:RangeValidator ID="rngcheckpercentage" runat="server" ControlToValidate="txtValueBase"
                                                                                                        ErrorMessage="Value Range Should be 0.1 to 100 in %" MaximumValue="100" MinimumValue="0.1"
                                                                                                        Type="Double" Width="215px" ToolTip="Range Value"></asp:RangeValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="2">
                                                                                    <div id="divbasic" runat="server" visible="true">
                                                                                        <table id="TABLE2" width="100%" cellpadding="0" cellspacing="0">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" style="width: 11%">Amount
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" style="width: 27%">
                                                                                                    <asp:TextBox ID="txtamount" runat="server" CssClass="span4" size="40" ToolTip="Amount"></asp:TextBox>&nbsp;
                                                                    <asp:RequiredFieldValidator ID="reqamount" runat="server" ControlToValidate="txtamount"
                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                        ToolTip="Enter Amount" Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtamount"
                                                                                                        Display="Dynamic" ErrorMessage="Enter valid amount" MaximumValue="9999999" MinimumValue="0"
                                                                                                        Type="Currency"></asp:RangeValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4"></td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td class="frm-lft-clr123" style="width: 11%; border-bottom: 1px solid #d9d9d9;">Rounding Value
                                                                                </td>
                                                                                <td class="frm-rght-clr123" style="width: 27%; border-bottom: 1px solid #d9d9d9;">
                                                                                    <asp:DropDownList ID="drpRoundValue" runat="server" ToolTip="Rounding Value"
                                                                                        CssClass="span4">
                                                                                        <asp:ListItem Value="0" Selected="True">Higher Rupees</asp:ListItem>
                                                                                        <asp:ListItem Value="1">Nearest Rupees</asp:ListItem>
                                                                                        <asp:ListItem Value="2">Higher Five Paisa</asp:ListItem>
                                                                                        <asp:ListItem Value="3">Normal</asp:ListItem>
                                                                                    </asp:DropDownList>
                                                                                    <asp:RequiredFieldValidator ID="reqRoundValue" runat="server" ControlToValidate="drpRoundValue"
                                                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' SetFocusOnError="True"
                                                                                        ToolTip="Select Round Value"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="5" colspan="4"></td>
                                                                            </tr>
                                                                            <tr>

                                                                                <td colspan="2">
                                                                                    <div id="paydiv" runat="server">
                                                                                        <table width="100%">
                                                                                            <tr>
                                                                                                <td class="frm-lft-clr123" valign="top" style="width: 11%; border-bottom: 1px solid #d9d9d9;">
                                                                                                    <asp:Button ID="btnarrear" runat="server" Text="Cal Arrear" CssClass="button" OnClick="btnarrear_Click"
                                                                                                        ToolTip="Calculate Arrear" ValidationGroup="cal" />
                                                                                                </td>
                                                                                                <td class="frm-rght-clr123" valign="top" style="width: 27%; border-bottom: 1px solid #d9d9d9;">
                                                                                                    <asp:Button ID="Add" runat="server" Text="Add" CssClass="button" OnClick="Add_Click"
                                                                                                        ToolTip="Add Employee Pay Master Details" />
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <div class="widget-content">
                                                                                                        <asp:GridView ID="employeePayStructure" runat="server" AutoGenerateColumns="false" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                            DataKeyNames="PayheadID" CellSpacing="0"
                                                                                                            AllowPaging="true" PageSize="15" EmptyDataText="Sorry No Records Found"
                                                                                                            OnRowDeleting="employeePayStructure_RowDeleting">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="EmpCode">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind("Empcode")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Pay Head">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind("PayheadName")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Pay Calculation Type">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("PayCalculationType")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Rate (%)">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("ValueBase")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Amount">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Round Type">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l6" runat="server" Text='<%# Bind("RoundMethod")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField>

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>

                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="4" style="height: 5px"></td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 25px; width: 48px;" valign="top">&nbsp;
                                                                                                </td>

                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td colspan="2">
                                                                                                    <div class="widget-content">
                                                                                                        <asp:GridView ID="paygrid" runat="server" AutoGenerateColumns="false" DataKeyNames="payheadid"
                                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                                            AllowPaging="true" PageSize="15" EmptyDataText="Sorry No Records Found">
                                                                                                            <Columns>
                                                                                                                <asp:TemplateField HeaderText="Pay Head Name">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind("payheadname")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Amount">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                                <asp:TemplateField HeaderText="Total Amount">

                                                                                                                    <ItemTemplate>
                                                                                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("totamount")%>'></asp:Label>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:TemplateField>
                                                                                                            </Columns>

                                                                                                        </asp:GridView>
                                                                                                    </div>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <%--<td colspan="4" height="25" valign="middle" class="txt02">--%>
                                                                                                <%--div class="glossymenu1">
  <a class="menuheader1 expandable" href="#">Salary Arrear Detail if any</a>
  <div class="categoryitems">
  <ul>  <li>--%>
                                                                                                <tr style="display: none;">
                                                                                                    <td colspan="4" valign="middle" class="txt02">Reimbursement detail
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="display: none;">
                                                                                                    <tr>
                                                                                                        <td colspan="4"></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td colspan='6' width="100%">
                                                                                                            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                                                                                <tr style="border-bottom: 1px solid #d9d9d9">
                                                                                                                    <td class="frm-lft-clr123" width="29%">Reimbursement Year
                                                                                                                    </td>
                                                                                                                    <td class="frm-rght-clr123" width="71%">
                                                                                                                        <asp:DropDownList ID="ddl_reimbursement_year" runat="server" CssClass="span4">
                                                                                                                        </asp:DropDownList>
                                                                                                                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddl_reimbursement_month"
                                                                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                                            Operator="NotEqual" ToolTip="Select Month of Reimbursement" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                                                    </td>
                                                                                                                </tr>

                                                                                                                <tr>
                                                                                                                    <td class="frm-lft-clr123" width="29%">Reimbursement Month
                                                                                                                    </td>
                                                                                                                    <td class="frm-rght-clr123" width="71%">
                                                                                                                        <asp:DropDownList ID="ddl_reimbursement_month" runat="server" CssClass="span4">
                                                                                                                        </asp:DropDownList>
                                                                                                                        <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddl_reimbursement_year"
                                                                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                                                            Operator="NotEqual" ToolTip="Select Year of Reimbursement" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                                                                                    </td>
                                                                                                                </tr>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                        </table>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                            <%--</li>
  </ul></div>--%>
                                                                    </div>
                                                                    <%-- </td>--%>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                                        <tr>

                                                                            <td class="frm-lft-clr123" colspan="2" style="border-bottom: 1px solid #d9d9d9; border-right: 1px solid #d9d9d9;">
                                                                                <asp:Button ID="btn_submit" runat="server" CssClass="button" Text="Submit" OnClick="btn_submit_Click"
                                                                                    ValidationGroup="v" />
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                    </div>
                                    </td>
                    </tr>
                </table>
                </td> </tr> </table>
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
