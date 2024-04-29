<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelReport.aspx.cs" Inherits="Travel_TravelReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
 <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/table.css";

        .gvclass th {
            text-align: left;
            background-color: #F9F9F9;
            border: 1px solid #ddd;
        }
    </style>

     <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />

  <%--  <link href="../css/blue1.css" rel="stylesheet" />--%>
    <link href="../css/table.css" rel="stylesheet" />
</head>

<body>
    <div class="header" style="background-color: white; padding: 10px; height: 1500px">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td colspan="6">Travel Report</td>
                            </tr>
                            <tr>
                                <td colspan="6" style="height: 10px"></td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123 " width="15%">Employee Name/Code</td>
                                <td class="frm-rght-clr123 " width="15%">
                                    <asp:TextBox ID="txtfirstname" runat="server" CssClass="blue1" Width="206px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123 " width="15%">Work Location</td>
                                <td class="frm-rght-clr123 " width="15%">
                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="blue1" DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id" Width="210px"
                                        OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:CompareValidator ID="CompareValidator5" runat="server" ControlToValidate="drpbranch" ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                        SetFocusOnError="True" Display="Dynamic" ToolTip="Select branch name" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                    <asp:SqlDataSource ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                </td>
                                <td class="frm-lft-clr123" width="15%">Department Type</td>
                                <td class="frm-rght-clr1234" width="15%">
                                    <asp:DropDownList ID="dpttype" runat="server" CssClass="blue1" OnDataBound="dpttype_DataBound" Width="210px" OnSelectedIndexChanged="dpttype_SelectedIndexChanged" AutoPostBack="true">

                                    </asp:DropDownList>  
                                </td>
                                 </tr>
                             <tr>
                                <td class="frm-lft-clr123  border-bottom" width="15%">Department </td>
                                <td class="frm-rght-clr123  border-bottom" width="15%">
                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" OnDataBound="dd_branch_DataBound" Width="210px" OnSelectedIndexChanged="dd_branch_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                    <%-- <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>--%>
                                </td>
                                <td class="frm-lft-clr123 " width="15%" style="display: none">Emp Middle Name</td>
                                <td class="frm-rght-clr123 " width="15%" style="display: none">
                                    <asp:TextBox ID="txtmidlename" runat="server" CssClass="blue1" Width="206px"></asp:TextBox>
                                </td>
                                <td class="frm-lft-clr123 " width="15%" style="display: none">Emp Last Name</td>
                                <td class="frm-rght-clr123 " width="15%" style="display: none">
                                    <asp:TextBox ID="txtlastname" runat="server" CssClass="blue1" Width="206px"></asp:TextBox>
                                </td>
                           
                           
                                <td class="frm-lft-clr123 " width="15%">Designation</td>
                                <td class="frm-rght-clr123 " width="15%">
                                    <asp:DropDownList ID="dd_designation" runat="server" CssClass="blue1" Width="210px"
                                        OnDataBound="dd_designation_DataBound">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 " width="15%" Style="display: none">Grade</td>
                                <td class="frm-rght-clr123 " width="15%" Style="display: none">
                                    <asp:DropDownList ID="drpgrade" runat="server" CssClass="blue1" Width="210px"></asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">Employee Status</td>
                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                    <asp:DropDownList ID="drpempstatus" runat="server" CssClass="blue1" Height=""
                                        Width="" DataSourceID="sql_data_status" DataTextField="employeestatus" DataValueField="id"
                                        OnDataBound="drpempstatus_DataBound">
                                    </asp:DropDownList>
                                    <asp:SqlDataSource
                                        ID="sql_data_status" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id],[employeestatus] FROM tbl_intranet_employee_status"></asp:SqlDataSource>
                                </td>
                            </tr>
                            <tr style="display: none">

                                <td class="frm-lft-clr123 " width="15%">Cost Center Group</td>
                                <td class="frm-rght-clr123 " width="15%">
                                    <asp:DropDownList ID="ddl_cc_groupid" runat="server" CssClass="blue1" Height=""
                                        AutoPostBack="true" Width="210" OnSelectedIndexChanged="ddl_cc_groupid_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td class="frm-lft-clr123 " width="15%">Cost Center Code</td>
                                <td class="frm-rght-clr123 " width="15%">
                                    <asp:DropDownList ID="ddl_cc_code" runat="server" CssClass="blue1" Height=""
                                        AutoPostBack="true" Width="210" OnSelectedIndexChanged="ddl_cc_code_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-lft-clr123 border-bottom" width="15%">From Date</td>
                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="blue1" Width="100px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/img/clndr.gif" />
                                    <cc1:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="Image5" TargetControlID="txtfromdate" Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                </td>
                                <td class="frm-lft-clr123 border-bottom" width="15%">To Date </td>
                                <td class="frm-rght-clr123 border-bottom" width="15%">
                                    <asp:TextBox ID="txttodate" runat="server" CssClass="blue1" Width="100px" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>&nbsp;
                                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                    <cc1:CalendarExtender
                                        ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txttodate"
                                        Enabled="True" Format="dd-MMM-yyyy">
                                    </cc1:CalendarExtender>
                                    <%--<asp:CompareValidator ID="CompareValidator20" runat="server" ControlToCompare="txtfromdate"
                                                                                        ControlToValidate="txttodate" ErrorMessage='<img src="img/error1.gif" alt="" />'
                                                                                        Operator="GreaterThan" SetFocusOnError="True" Type="Date" ToolTip="Select valid date" 
                                                                                        ValidationGroup="v"></asp:CompareValidator>--%>
                                </td>

                            </tr>
                            <tr>
                                <td colspan="6" style="height: 10px"></td>
                            </tr>
                        </table>

                        <table width="100%">

                            <tr>
                                <td colspan="2" class="frm-lft-clr123 " style="border-right: 1px solid #ddd" width="100%">Select Travel Details
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123 border-bottom" colspan="2">
                                    <table width="100%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                    |<asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table id="Table1" cellspacing="5" cellpadding="5" border="0">
                                                        <tbody>

                                                            <asp:CheckBoxList ID="chkl_jobdetails" runat="server" RepeatColumns="4" Width="100%" RepeatDirection="Horizontal" CellSpacing="10">
                                                                <asp:ListItem Value="empname" Text="Employee Name"></asp:ListItem>
                                                                <asp:ListItem Value="empcode" Text="Employee Code"></asp:ListItem>
                                                                <asp:ListItem Value="accountcode" Text="Travel ID"></asp:ListItem>
                                                                <asp:ListItem Value="createddate" Text="Submitted Date"></asp:ListItem>
                                                                <asp:ListItem Value="DateofDeparture" Text="Date of Departure"></asp:ListItem>
                                                                <asp:ListItem Value="DateoofArrival" Text="Date of Arrival "></asp:ListItem>
                                                                <asp:ListItem Value="nooftrips" Text="Number of Trips"></asp:ListItem>
                                                                <asp:ListItem Value="LineManager" Text="Line Manager"></asp:ListItem>
                                                                <asp:ListItem Value="Management" Text="Management"></asp:ListItem>
                                                                <asp:ListItem Value="Admin" Text="Admin"></asp:ListItem>
                                                                <asp:ListItem Value="FinanceManager" Text="Finance Manager"></asp:ListItem>
                                                                <asp:ListItem Value="kitallowance" Text="Kit Allowance (INR)"></asp:ListItem>
                                                                <asp:ListItem Value="totalPrebooking" Text="Total Pre Booking Amount"></asp:ListItem>
                                                                <asp:ListItem Value="totalExpense" Text="Total Expense Sanctioned "></asp:ListItem>
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
                                <td colspan="6" style="height: 10px"></td>
                            </tr>
                            <tr>
                                <td style="text-align: center">

                                    <asp:Button ID="btngenerate" runat="server" Text="Generate Report" OnClick="btngenerate_Click" CssClass="button" /></td>
                            </tr>
                        </table>

                        <asp:UpdatePanel runat="server" ID="export">
                            <ContentTemplate>

                                <div id="light" style="top: 10%; left: 2%;" class="pop1" align="center" runat="server">
                                    <table width="800px" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="pop-brdr">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td style="width: 97%" valign="top" class="pop-tp-clr" align="left">&nbsp;Employee Details 
                                                    <asp:Button ID="btnexport" runat="server" CssClass="btn btn-sm" OnClick="btnexport_Click"
                                                        Text="Export" ToolTip="Export" Style="float: right" /></td>
                                                        <td style="width: 3%" align="right" valign="top" class="pop-tp-clr"><a href="#" onclick="document.getElementById('light').style.display='none';">
                                                            <img src="../img/btn-close.gif" title="Close" width="16" height="19" border="0" /></a></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" height="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="center" valign="top">
                                                            <div id="policyframe" runat="server" frameborder="0" style="overflow-x: scroll; overflow-y: scroll; width: 1000px; height: 500px">
                                                                <div id="tblResult" runat="server">
                                                                </div>

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
</body>
</html>
