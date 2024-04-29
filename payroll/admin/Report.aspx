<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="payroll_admin_Report" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Employee Pay Structure</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        @import "../../css/example.css";
        @import "../../css/ajax__tab_xp2.css";
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <script language="JavaScript" type="text/javascript" src="../js/JavaScriptValidations.js"></script>
    <style type="text/css">
        .star:before {
            content: " *";
        }
    </style>

    <link href="../../js/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../js/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="top" class="blue-brdr-1" style="width: 100%">
                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="4"></td>
                                </tr>
                                <tr>
                                    <td height="20" valign="top" style="width: 100%">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02" style="height: 13px">View Employee Pay Slip
                                                </td>
                                                <td class="txt02" align="right">
                                                    <span id="message" runat="server"></span>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr>
                                    <td valign="top" style="height: 123px; width: 100%;">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 22%">Financial Year
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 30%">
                                                    <asp:DropDownList ID="dd_year" runat="server" Width="150px" ToolTip="Financial Year"
                                                        CssClass="blue1" DataTextField="year" DataValueField="year" AutoPostBack="True"
                                                        OnSelectedIndexChanged="dd_year_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dd_year"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Financial Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123" style="width: 22%">Month
                                                </td>
                                                <td class="frm-rght-clr123" style="width: 30%">
                                                    <asp:DropDownList ID="dd_month" runat="server" Width="150px" ToolTip="Month" CssClass="blue1"
                                                        DataTextField="month " DataValueField="month" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Select Month"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="22%">Department
                                                </td>
                                                <td class="frm-rght-clr123" width="30%">
                                                    <asp:DropDownList ID="dd_designation" runat="server" Width="150px" CssClass="blue1" >
                                                    </asp:DropDownList>

                                                    <%--<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], department_name  FROM [tbl_internate_departmentdetails] ">
                                                        <SelectParameters>
                                                            <asp:ControlParameter ControlID="dd_designation" DefaultValue="0" Name="branch" PropertyName="SelectedValue" />
                                                        </SelectParameters>
                                                    </asp:SqlDataSource>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom" style="width: 11%">&nbsp;
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                    <asp:Button ID="btnReport" runat="server" CssClass="button" Text="Get Report" OnClick="btnReport_Click" />
                                                    <asp:Button ID="btnprint" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr style="height: 10px"></tr>

                    <tr>
                        <td colspan="2">

                            <div class="widget-content" style="overflow-x: scroll; width: 1050px">
                                <asp:GridView ID="grdPayrollReport" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="" Width="150%" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblemployeename" runat="server" Text='<%# Eval("Employee Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="15%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblissueddate" runat="server" Text='<%# Eval("Employee Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Gender">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrecivedby" runat="server" Text='<%# Eval("Gender") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Father Name" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFathername" runat="server" Text='<%#Eval("Father Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date Of Joining">
                                            <ItemTemplate>
                                                <asp:Label ID="lblapprovedby" runat="server" Text='<%# Eval("Date of Join","{0:M-dd-yyyy}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Department Name" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblissueddate" runat="server" Text='<%# Eval("Department") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation Name" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFathername" runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Branch Name" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblemployeename" runat="server" Text='<%# Eval("Branch") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ESI No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrecivedby" runat="server" Text='<%# Eval("ESI No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PF No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFathername" runat="server" Text='<%#Eval("PF No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pan No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblapprovedby" runat="server" Text='<%# Eval("PAN No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Account No." HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblaccountno" runat="server" Text='<%# Eval("Account No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Bank Name" HeaderStyle-Width="5%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBankName" runat="server" Text='<%# Eval("Bank Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Basic">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBasic" runat="server" Text='<%# Eval("Basic") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="HRA">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHRA" runat="server" Text='<%# Eval("HRA") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTDR" runat="server" Text='<%# Eval("TDS") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Medical Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMedical" runat="server" Text='<%# Eval("Medical Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Provident Fund">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPF" runat="server" Text='<%# Eval("Provident Fund") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Professional Tax">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPT" runat="server" Text='<%# Eval("Professional Tax") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ESI">
                                            <ItemTemplate>
                                                <asp:Label ID="lblESI" runat="server" Text='<%# Eval("ESI") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LWF">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLWF" runat="server" Text='<%# Eval("LWF") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Special Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSA" runat="server" Text='<%# Eval("Special Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Helper Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHA" runat="server" Text='<%# Eval("Helper Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Education Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEA" runat="server" Text='<%# Eval("Education Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Car Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCA" runat="server" Text='<%# Eval("Car Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Car Maintenance Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCMA" runat="server" Text='<%# Eval("Car Maintenance Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="City Comp. Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCCA" runat="server" Text='<%# Eval("City Comp Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Furnishing Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFA" runat="server" Text='<%# Eval("Furnishing Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Washing Allowance">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWA" runat="server" Text='<%# Eval("Washing Allowance") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>

                        </td>
                    </tr>

                </table>

            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnprint" />
            </Triggers>
        </asp:UpdatePanel>
    </form>
</body>
</html>
