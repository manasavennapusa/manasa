<%@ Page Language="C#" AutoEventWireup="true" CodeFile="process_attendance_salary.aspx.cs"
    Inherits="payroll_admin_process_attendance_salary" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";

        .star:before {
            content: " *";
        }
    </style>
   <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
     <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <%-- <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" />
                                    </td>
                                    <td valign="bottom">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>--%>
         <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="../../attendance/images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                 <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <%--    <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                    <td class="txt01" runat="server" style="width: 350px">Process Salary Single Employee Wise / Branch Wise
                                    </td>
                                    <td runat="server" align="right" class="txt02">
                                        <asp:Label ID="lbl_message" runat="server" Enabled="true" Text="" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td height="5">
                            <asp:RadioButton ID="rbtnemp" runat="server" AutoPostBack="True" GroupName="p" Text="Employee"
                                OnCheckedChanged="rbtnemp_CheckedChanged" />  <asp:RadioButton ID="rbtnbranch"
                                    runat="server" AutoPostBack="True" Checked="True" GroupName="p" Text="Branch"
                                    OnCheckedChanged="rbtnbranch_CheckedChanged" />
                        </td>
                    </tr>

                    <tr>
                        <td colspan="5" width="100%">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                <tr>
                                    <td class="frm-lft-clr123" width="25%">Financial Year
                                    </td>
                                    <td class="frm-rght-clr123" width="75%">&nbsp;<asp:DropDownList ID="lbl_fyear" runat="server" CssClass="span4"></asp:DropDownList>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123" width="25%">Select Month
                                    </td>

                                    <td class="frm-rght-clr123" width="75%">&nbsp;
                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="span4" AutoPostBack="True" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                </tr>

                                <tr>
                                    <td valign="top" colspan="3" id="divbranch" runat="server">
                                        <%-- <div  runat="server" style="margin-left: -2px">--%>
                                        <%-- <table width="100%">--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="25%">Select Branch  <span class="star"></span>
                                            </td>
                                            <td align="left" class="frm-rght-clr123" width="75%">&nbsp;
                                                <asp:DropDownList ID="ddlbranch" runat="server" CssClass="span4" DataSourceID="SqlDataSource21"
                                                    DataTextField="branch_name" DataValueField="branch_id" OnDataBound="ddlbranch_DataBound"
                                                    Width="">
                                                </asp:DropDownList>
                                                &nbsp;
                                                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlbranch"
                                                                    ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="v" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource21" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [branch_id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>

                                            </td>
                                        </tr>
                                        <%-- </table>--%>
                                        <%--</div>--%>
                                       <%-- <div id="divemp" visible="false" runat="server" style="margin-left: -2px">
                                            <table width="100%">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="20%">Emp Code <span class="star"></span>
                                                    </td>
                                                    <td align="left" class="frm-rght-clr123" colspan="2">
                                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="140px"
                                                            onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="reqEmpcode" runat="server" ControlToValidate="txt_employee"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                            ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <span id="pickemp" runat="server"><a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');"
                                                            class="link05">Pick Employee</a></span>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>--%>
                                    </td>
                                </tr>

               <tr id="divemp" visible="false" runat="server">
                                              <td class="frm-lft-clr123" width="20%">Emp Code <span class="star"></span>
                                                    </td>
                                                    <td align="left" class="frm-rght-clr123" colspan="2">
                                                        &nbsp;&nbsp;<asp:TextBox ID="txt_employee" runat="server" CssClass="span4" Width=""
                                                            onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ToolTip="Enter Employee Code"
                                                            ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        <span id="Span1" runat="server"><a href="JavaScript:newPopup1('../../leave/pickemployee.aspx');"
                                                            class="link05">Pick Employee</a></span>&nbsp;
                                                    </td>
                                                </tr>



                                <tr>
                                    <td class="frm-lft-clr123 border-bottom">Process Salary
                                    </td>
                                    <td align="left" class="frm-rght-clr123 border-bottom" colspan="2">&nbsp;<asp:Button ID="btn_procs_salary" runat="server" CssClass="button" Text="Process Salary"
                                        ValidationGroup="v" OnClick="btn_procs_salary_Click" />&nbsp;
                                                <asp:Button ID="btn_reprocs_salary" runat="server" CssClass="button" Text="Reprocess Salary"
                                                    ValidationGroup="v" OnClick="btn_reprocs_salary_Click" Visible="False" />
                                        <asp:Button ID="btn_reprocs_att" runat="server" CssClass="button" Text="Reprocess Attendance"
                                            ValidationGroup="v" OnClick="btn_reprocs_att_Click" Visible="False" />
                                        <asp:Button ID="btn_procs_att" runat="server" CssClass="button" Text="Process Attendance"
                                            ValidationGroup="v" OnClick="btn_procs_att_Click" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="7"></td>
                    </tr>
                    <tr>
                        <td valign="top"></td>
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
