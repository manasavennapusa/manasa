<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EDB_QueryBuilder.aspx.cs" Inherits="EDB_QueryBuilder" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Report</title>
    <style type="text/css" media="all">
        @import "css/blue1.css";
        @import "css/example.css";
        @import "css/table.css";

        .gvclass th
        {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }
    </style>
    <link href="css/blue1.css" rel="stylesheet" />
    <link href="css/table.css" rel="stylesheet" />
</head>
<body>
    <div style="border-top:5px solid #428bca">
    <div class="header" style="background-color: white; padding: 10px; height: 1500px">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
             <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>EDB Report</h2>
                    </div></div>
                </div>

                   <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Search
                                </td>
                            </tr>
                    <div class="clearfix"></div>
                </div>
            <div>
                <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">

                            <tr>
                                <td class="frm-lft-clr123 " width="15%">Employee Name/Code</td>
                                <td class="frm-rght-clr123 " width="240px">
                                    <asp:TextBox ID="txtfirstname" runat="server" CssClass="blue1" Width="175px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123 " width="15%">Work Location</td>
                                <td class="frm-rght-clr123 " width="240px">
                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="blue1" DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id" Width="175px"
                                        OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="drpbranch" ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                        SetFocusOnError="True" Display="Dynamic" ToolTip="Select branch name" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                    <asp:SqlDataSource ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">Department Type </td>
                                <td class="frm-rght-clr123 border-bottom" width="240px">
                                    <asp:DropDownList ID="dept_type" runat="server" CssClass="blue1" OnDataBound="dept_type_DataBound" Width="175px" OnSelectedIndexChanged="dept_type_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 " width="15%" style="display: none">Emp Middle Name</td>
                                <td class="frm-rght-clr123 " width="240px" style="display: none">
                                    <asp:TextBox ID="txtmidlename" runat="server" CssClass="blue1" Width="206px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123 " width="15%" style="display: none">Emp Last Name</td>
                                <td class="frm-rght-clr123 " width="240px" style="display: none">
                                    <asp:TextBox ID="txtlastname" runat="server" CssClass="blue1" Width="206px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                 <td class="frm-lft-clr123 border-bottom" width="15%">Department </td>
                                <td class="frm-rght-clr123 border-bottom" width="240px">
                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" OnDataBound="dd_branch_DataBound" Width="175px" OnSelectedIndexChanged="dd_branch_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>

                                <td class="frm-lft-clr123 " width="15%">Designation</td>
                                <td class="frm-rght-clr123 " width="240px">
                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="blue1" Width="175px"
                                        OnDataBound="dd_designation_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">Employee Status</td>
                                <td class="frm-rght-clr123 border-bottom" width="240px">
                                    <asp:DropDownList ID="drpempstatus" runat="server" CssClass="blue1" Height=""
                                        Width="175px" DataSourceID="sql_data_status" DataTextField="employeestatus" DataValueField="id"
                                        OnDataBound="drpempstatus_DataBound">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource
                                        ID="sql_data_status" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id],[employeestatus] FROM tbl_intranet_employee_status"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr style="display: none">

                                <td class="frm-lft-clr123 " width="15%">Cost Center Group</td>
                                <td class="frm-rght-clr123 " width="240px">
                                    <asp:DropDownList ID="ddl_cc_groupid" runat="server" CssClass="blue1" Height=""
                                        AutoPostBack="true" Width="175px" OnSelectedIndexChanged="ddl_cc_groupid_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 " width="15%">Cost Center Code</td>
                                <td class="frm-rght-clr123 " width="240px">
                                    <asp:DropDownList ID="ddl_cc_code" runat="server" CssClass="blue1" Height=""
                                        AutoPostBack="true" Width="175px" OnSelectedIndexChanged="ddl_cc_code_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123 border-bottom" width="15%">From Date</td>
                                <td class="frm-rght-clr123 border-bottom" width="240px">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="blue1" Width="172px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" style="position:absolute; padding-top:6px" />
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">To Date </td>
                                <td class="frm-rght-clr123 border-bottom" width="240px">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="blue1" Width="172px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" style="position:absolute; padding-top:6px" />
                                    <cc1:CalendarExtender
                                        ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate"
                                        Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="6" style="text-align: center; display: none">
                                    <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" /></td>
                            </tr>
                        </table>
                        </table>
                        <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Employee Job Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table1" cellspacing="5" cellpadding="5" border="0">
                                                        <tbody>

                                                            <asp:CheckBoxList ID="chkl_jobdetails" runat="server" RepeatColumns="5" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="emp_fname" Text="Employee Name"></asp:ListItem>
                                                                <asp:ListItem Value="card_no" Text="Employee No."></asp:ListItem>
                                                                <asp:ListItem Value="emp_gender" Text="Gender"></asp:ListItem>
                                                                <asp:ListItem Value="branch_id" Text="Work Location"></asp:ListItem>
                                                                <asp:ListItem Value="dept_id" Text="Department"></asp:ListItem>
                                                                <asp:ListItem Value="degination_id" Text="Designation"></asp:ListItem>
                                                                <asp:ListItem Value="emp_status" Text="Employee Status"></asp:ListItem>
                                                                <asp:ListItem Value="role" Text="Employee Role"></asp:ListItem>
                                                                <asp:ListItem Value="emp_doj" Text="Date of Joining"></asp:ListItem>
                                                                <asp:ListItem Value="official_mob_no" Text="Official Mobile No."></asp:ListItem>
                                                                <asp:ListItem Value="official_email_id" Text="Official Email Id"></asp:ListItem>
                                                                <asp:ListItem Value="ext_number" Text="Ext. Number"></asp:ListItem>
                                                                <asp:ListItem Value="emp_doleaving" Text="Date of Leaving"></asp:ListItem>
                                                                <asp:ListItem Value="reason_leaving" Text="Reason for Leaving"></asp:ListItem>
                                                                <asp:ListItem Value="dept_type_id" Text="Department Type"></asp:ListItem>
                                                                <asp:ListItem Value="emp_type_id" Text="Employee Type"></asp:ListItem>
                                                                <asp:ListItem Value="emp_subtype_id" Text="Employee Sub Type"></asp:ListItem>

                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Employee Payroll Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="LinkButton2" runat="server" CssClass="txt-red" OnClick="LinkButton2_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table2" cellspacing="10" cellpadding="10" border="0">
                                                        <tbody>
                                                            <asp:CheckBoxList ID="chk_payrolldetails" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="ward" Text="CTC Per Annum"></asp:ListItem>
                                                                <asp:ListItem Value="esi_no" Text="ESI Number"></asp:ListItem>
                                                                <asp:ListItem Value="esi_disp" Text="ESI Dispensary"></asp:ListItem>
                                                                <asp:ListItem Value="pf_no" Text="PF Number"></asp:ListItem>
                                                                <asp:ListItem Value="pf_no_dept" Text="PF Region"></asp:ListItem>
                                                                <asp:ListItem Value="pan_no" Text="PAN Number"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Employee Approver's Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton7" OnClick="LinkButton7_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="LinkButton8" runat="server" CssClass="txt-red" OnClick="LinkButton8_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table5" cellspacing="5" cellpadding="5" border="0">
                                                        <tbody>
                                                            <asp:CheckBoxList ID="chkapprover" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="app_reportingmanager" Text="Line Manager"></asp:ListItem>
                                                                <asp:ListItem Value="app_dotted_linemanager" Text="Dotted Line Manager"></asp:ListItem>
                                                                <asp:ListItem Value="app_businesshead" Text="Business Head"></asp:ListItem>
                                                                <asp:ListItem Value="app_finance" Text="Account Manager"></asp:ListItem>
                                                                <asp:ListItem Value="app_admin" Text="Admin"></asp:ListItem>
                                                                <asp:ListItem Value="app_hr" Text="HR-TA"></asp:ListItem>
                                                                <asp:ListItem Value="app_hr_cb" Text="HRC&B"></asp:ListItem>
                                                                <asp:ListItem Value="app_hrd" Text="HR-BP"></asp:ListItem>
                                                                <asp:ListItem Value="app_management" Text="Management/MD"></asp:ListItem>
                                                                <asp:ListItem Value="clr_department" Text="Virtual Head"></asp:ListItem>
                                                             <%--   <asp:ListItem Value="clr_generaladmin" Text="General Administration Clearance"></asp:ListItem>
                                                                <asp:ListItem Value="clr_accountsdept" Text="Accounts Department Clearance"></asp:ListItem>--%>
                                                                <asp:ListItem Value="clr_networkdept" Text="Network Administration Clearance"></asp:ListItem>
                                                             <%--   <asp:ListItem Value="clr_hr" Text="HR Department Clearance"></asp:ListItem>
                                                                <asp:ListItem Value="clr_useraccountdeletion" Text="User Account Deletion Request"></asp:ListItem>--%>
                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Employee Personal Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="LinkButton3" OnClick="LinkButton3_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |
                                            <asp:LinkButton ID="LinkButton4" runat="server" CssClass="txt-red" OnClick="LinkButton4_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table3" cellspacing="10" cellpadding="10" border="0">
                                                        <tbody>
                                                            <asp:CheckBoxList ID="chk_personalDetails" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="dob" Text="Date of Birth"></asp:ListItem>
                                                                <asp:ListItem Value="religion" Text="Religion"></asp:ListItem>
                                                                <asp:ListItem Value="paymentmode" Text="Payment Mode"></asp:ListItem>
                                                                <asp:ListItem Value="bank_name" Text="Bank Name for Salary"></asp:ListItem>
                                                                <asp:ListItem Value="ac_number" Text="Account No. for Salary"></asp:ListItem>
                                                                <asp:ListItem Value="bankbranch" Text="Bank Branch Name"></asp:ListItem>
                                                                <asp:ListItem Value="ifsc" Text="IFSC code"></asp:ListItem>
                                                                <asp:ListItem Value="mobile_no" Text="Personal Mobile No."></asp:ListItem>
                                                                <asp:ListItem Value="landlineno" Text="LandLine No."></asp:ListItem>
                                                                <asp:ListItem Value="email_id" Text="Personal Email Id"></asp:ListItem>
                                                                <asp:ListItem Value="passport_number" Text="Passport No."></asp:ListItem>
                                                                <asp:ListItem Value="passportissuedate" Text="Passport Issued Date"></asp:ListItem>
                                                                <asp:ListItem Value="passportexpiraydate" Text="Passport Expiry Date"></asp:ListItem>
                                                                <asp:ListItem Value="driving_lic_no" Text="Driving Licence No."></asp:ListItem>
                                                                <asp:ListItem Value="dribing_lic_iss_date" Text="Driving Licence Issued Date"></asp:ListItem>
                                                                <asp:ListItem Value="driving_lic_exp_date" Text="Driving Licence Expiry Date"></asp:ListItem>
                                                                <asp:ListItem Value="bloodgrp" Text="Blood Group"></asp:ListItem>
                                                                <asp:ListItem Value="f_fname" Text="Father Name"></asp:ListItem>
                                                                <asp:ListItem Value="m_fname" Text="Mother  Name"></asp:ListItem>
                                                                <asp:ListItem Value="maritalstatus" Text="Marital Status"></asp:ListItem>


                                                                <asp:ListItem Value="doa" Text="Date of Anniversary"></asp:ListItem>
                            <asp:ListItem Value="child_name" Text="Child Name"></asp:ListItem>
                            <asp:ListItem Value="childdob" Text="Child DOB"></asp:ListItem>
                            <asp:ListItem Value="gender" Text="Child Gender"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table width="100%">
                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Employee Contact Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    
                                                                        <asp:LinkButton ID="LinkButton5" OnClick="LinkButton5_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                                        |
                                            <asp:LinkButton ID="LinkButton6" runat="server" CssClass="txt-red" OnClick="LinkButton6_Click">Uncheck All</asp:LinkButton>
                                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table4" cellspacing="5" cellpadding="5" border="0">
                                                        <tbody>
                                                            <asp:CheckBoxList ID="chk_contactdetails" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="pre_add1" Text="Present Address"></asp:ListItem>
                                                                <asp:ListItem Value="per_add1" Text="Permanent Address"></asp:ListItem>
                                                                <asp:ListItem Value="mode" Text="Mode Of Transport"></asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <table>
                            <tr>
                                <td style="text-align: center">

                                    <asp:Button ID="btngenerate" runat="server" Text="Generate Report" OnClick="btngenerate_Click" CssClass="button" OnClientClick="openInNewTab();" /></td>
                            </tr>
                        </table>
                        <asp:UpdatePanel runat="server" ID="export">
                            <ContentTemplate>

                                <div id="light" style="top: -5px;right:2px;width:1300px;height:690px;background-color:white" align="center" runat="server"> 
                                    <table style="width:1370px;position:absolute;right:-25px;top:8px;height:1900px;background-color:#fff">
                                        <tr>
                                            <td class="pop-brdr">
                                                <table style="width:99.7%;position:absolute;right:1.2px;top:4px;" border="0">
                                                    <tr style="height:40px">
                                                        <td style="width: 97%;valign:top;align:left;background-color:#08486d">
                                                            <asp:Label ID="lbl" runat="server" style="position:absolute;right:600px;top:9px;color:#fff;font-size:22px; font-family: Arial">Employee Details</asp:Label>       
                                                            <asp:Label ID="Label1" runat="server" style="position:absolute;right:60px;top:9px;">
                                                                  <asp:Button ID="btnexport" runat="server" CssClass="btn btn-primary" OnClick="btnexport_Click"
                                                                  Text="Export" ToolTip="Export" Style="position:absolute;right:10px;top:-1px;width:80px;font-size:20px;color:black; font-family:Arial"  />
                                                            </asp:Label>      
                                                       </td>
                                                        <td style="width: 3%;border-bottom:2px solid #005bff" align="right" valign="top"> 
                                                            <asp:Label ID="lbl1" runat="server" style="position:absolute;right:12px;top:10px;">
                                                                 <a href="#" onclick="document.getElementById('light').style.display='none';" style="background-color:#fff">
                                                            <img src="img/Close_images.jpg" id="img" title="Close" style="position:absolute;right:-3px;width:26px;height:26px;top:-3px;" border="0" onmouseover="mouseOverImage()"  onmouseout="mouseOutImage()" onclick="window.close()" /></a>
                                                            </asp:Label>                                  
                                                        </td>                 </tr>
                                                     <tr>
                                                        <td colspan="2" height="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" valign="top">
                                                            <div id="policyframe" runat="server" frameborder="1" style="overflow-x: scroll; overflow-y: scroll; width: 1362px; height: 1849px;position:absolute;right:1px;top:44px">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="true" style="text-align:center; font-family:Arial" Visible="true" 
                                                                    EmptyDataText="No Record Found !!" >
                                                                </asp:GridView>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="10"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <asp:HiddenField ID="hdn_branchid" runat="server" Value="0" />
                                    </table>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                    <Triggers>
                        <asp:PostBackTrigger ControlID="btngenerate" />
                        <asp:PostBackTrigger ControlID="btnexport" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
        </div>

   <script type="text/javascript">
       function openInNewTab() {
           window.document.forms[0].target = '_blank';
           setTimeout(function () { window.document.forms[0].target = ''; }, 0);
       }
   </script>
    <script type="text/javascript">
        function OnMouseOver() {
            document.getElementById("btnexport").style.color = "yellow";
            document.getElementById("btnexport").style.backgroundColor = "#00e0ff";
        }
        function OnMouseOut() {
            document.getElementById("btnexport").style.color = "#fff";
            document.getElementById("btnexport").style.backgroundColor = "#00a1ff";
        }
    </script>
    <script language="javascript" type="text/javascript">
        function mouseOverImage() {
            document.getElementById("img").src = "img/close_images3.jpg";
            document.getElementById("img").style = "position:absolute;right:-3px;width:26px;height:26px;top:-3px";
        }
        function mouseOutImage() {
            document.getElementById("img").src = "img/Close_images.jpg";
            document.getElementById("img").style = "position:absolute;right:-3px;width:26px;height:26px;top:-3px";
        }
    </script> 
</body>
</html>
