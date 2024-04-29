<%@ Page Language="C#" AutoEventWireup="true" CodeFile="newsalarysheetreport.aspx.cs" Inherits="payroll_admin_newsalarysheetreport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title" style="margin-left:800px;margin-top:20px">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                            <asp:Label ID="Label1" runat="server" Text="Salary Sheet" Font-Bold="true"></asp:Label>
                                        </div>
                                        <br />
                                        <br />
                                         <div class="title" style="margin-left:50px;width:500%">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>
                                            <asp:Label ID="Label2" runat="server" Text="Name & address of the establishment:" Font-Bold="true"></asp:Label>&nbsp;&nbsp;
                                             <asp:Label ID="lbl_company" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                             <asp:Label ID="Label3" runat="server" Text="Payroll for the month of" Font-Bold="true"></asp:Label>
                                             <asp:Label ID="lblMonths" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination" style="margin-top: 100px; margin-left: 50px;margin-right:100px">
                                            <asp:GridView ID="leave_approval_grid" runat="server" AutoGenerateColumns="false"  EmptyDataText="no records found!!." Font-Size="12px" Width="1000%">

                                                <Columns>
                                                   <%--  <asp:TemplateField HeaderText="PAYDATE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DaysPayable") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="EMPCODE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EMPCODE") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="EMP NAME" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EMPNAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GENDER" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("GENDER") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="FATHER NAME" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("FATHER_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="DEPARTMENT" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DEPARTMENT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                 <%--   <asp:TemplateField HeaderText="COST NAME" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("COST_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="DESIGNATION" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DESIGNATION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                 <%--   <asp:TemplateField HeaderText="DOB" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOB") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="DOJ" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOJ") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                <%--    <asp:TemplateField HeaderText="DOL" HeaderStyle-Width="250px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="LOCATION" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("LOCATION") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EMAIL ID" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EMAIL_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="PAN NO" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PAN_NO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="ESI NO" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("ESI_NO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PF NO" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PF_NO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="UANO" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("UANO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BANK NAME" HeaderStyle-Width="200px"  ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("BANK_NAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BANK AC NO" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("BANK_ACNO") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IFSC" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("IFSC") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="BASIC" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount0") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="HRA" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount8") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="MEDICAL ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount10") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="CONVEYANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount11") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="SPECIAL ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount51") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

<%--                                                     <asp:TemplateField HeaderText="BOOKS AND PERIODIC ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="MONTHLY CTC" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#6699ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PSAmount") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="LEAVE WITHOUT PAY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("LWP") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  <%--   <asp:TemplateField HeaderText="MONTH DAYS" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DaysPayable") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="PAYDAYS" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#ffff00">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DaysPayable") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                      <asp:TemplateField HeaderText="ERN BASIC" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount0") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="ERN HRA" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount8") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="ERN CONVEYANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount11") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="ERN SPECIAL ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount51") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="ERN MEDICAL ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount10") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderText="BOOKS & PERIODIC ALLOWANCE" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount68") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="BONUS" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount30") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                <%--     <asp:TemplateField HeaderText="LTA" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount27") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                             <%--        <asp:TemplateField HeaderText="LEAVE ENCASHMENT" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount25") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <%-- <asp:TemplateField HeaderText="NOTICE PAY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                   <%--  <asp:TemplateField HeaderText="OTHER EARN" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount13") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="GROSS PAY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#74b9ff">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Earnings") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="PF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount2") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderText="VPF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount70") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="ESI" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount3") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="PT TAX" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount12") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="TDS" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount7") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <%-- <asp:TemplateField HeaderText="LOAN ADVANCE" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount69") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                   <%--  <asp:TemplateField HeaderText="OTHER DED" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount26") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="ELWF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount21") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="NOTICE DED" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount45") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="GROSS DED" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("TotalDeduction") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="NET PAY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#fa983a">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("NetPay") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                     <asp:TemplateField HeaderText="ESI SALARY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("ESLSALARY") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="ESI" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("ESI") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="EESI" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("ESI_E") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText=" ESIC TOTAL" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("ESIT") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                  <%--   <asp:TemplateField HeaderText="ELWF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("LWF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="CLWF" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="LWF TOTAL" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("LWF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="RPFC" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="PF SALARY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount0") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="FPF SALARY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PF_Salary") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="PF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PFVPF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                 <%--    <asp:TemplateField HeaderText="VPF" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                     <asp:TemplateField HeaderText="EPF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EPF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="EFPF" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EFPF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="PF ADMIN" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("PFADMIN") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="EDLI CONT" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("EDLI") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="EDLI ADMIN" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("DOL") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="TOTAL PF" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("TOTAL_PF") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    <asp:TemplateField HeaderText="PT SALARY" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Earnings") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="PT TAX" HeaderStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount12") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="ITAX" HeaderStyle-Width="200px" ItemStyle-Width="200px" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("TDS_ere") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="CESSPM" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("TDS_eque") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="TDS" HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="Center" HeaderStyle-BackColor="#78e08f">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("Amount7") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>
                                            </asp:GridView>

                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#leave_approval_grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>
