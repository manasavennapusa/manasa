<%@ Page Language="C#" AutoEventWireup="true" CodeFile="report_tax_variance_employee.aspx.cs"
    Inherits="payroll_admin_report_tax_variance_employee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Untitled Document</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

    <script type="text/javascript" language="javascript">

        function returnempcode(val, val2) {
            window.opener.document.getElementById("txt_approver").value = val;
            window.opener.document.getElementById("hidd_name").value = val2;
            window.opener.focus();
            window.close();

        }
    </script>
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
               <div class="divajax">
                    <table width="100%">
                    <tr>
                    <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                    </tr>
                    <tr>
                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...</td>
                    </tr>
                    </table>
                    </div>
        </ProgressTemplate>
        </asp:UpdateProgress>--%>
    <table width="712" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="middle" class="txt02 blue-brdr-1">
                &nbsp;Report Tax Detail Employee Wise
            </td>
        </tr>
        <tr>
            <td height="5" valign="top">
            </td>
        </tr>
        <tr>
            <td valign="top">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="frm-lft-clr123" width="10%">
                            &nbsp;Name
                        </td>
                        <td class="frm-rght-clr123" width="18%">
                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="90"></asp:TextBox>
                            <a class="link05" href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');">
                                Pick Employee</a>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
                                ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                        </td>
                        <td class="frm-lft-clr123" width="10%">
                            Designation
                        </td>
                        <td class="frm-rght-clr123" colspan="4" width="14%">
                            <asp:DropDownList ID="dd_designation" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound"
                                Width="115px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]">
                            </asp:SqlDataSource>
                        </td>
                    </tr>
                    <tr>
                        <td class="frm-lft-clr123" width="10%">
                            Financial Year
                        </td>
                        <td class="frm-rght-clr123" width="18%">
                            <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="False" CssClass="blue1"
                                DataSourceID="SqlDataSource12" DataTextField="financialyear" DataValueField="financialyear"
                                OnDataBound="dd_year_DataBound" Width="115px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                Operator="NotEqual" ToolTip="Select Financial Year" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                            <asp:SqlDataSource ID="SqlDataSource12" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="select distinct [financial_year] as financialyear from tbl_payroll_tax_master">
                            </asp:SqlDataSource>
                        </td>
                        <td class="frm-lft-clr123" width="8%">
                            Department&nbsp;
                        </td>
                        <td class="frm-rght-clr123" width="12%">
                            &nbsp;<asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                Width="115px">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">
                            </asp:SqlDataSource>
                        </td>
                        <td class="frm-lft-clr123" colspan="2">
                            &nbsp;
                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click" />&nbsp;
                            <asp:Button ID="btnexport" runat="server" CssClass="button" Text="Export" OnClick="btnexport_Click"
                                Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td height="5" colspan="6" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table width="712" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td colspan="6" valign="top">
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="middle" class="txt02" style="height: 24px">
                                        Employee Tax Detail List
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="frm-lft-clr123" width="16%">
                                                    Est Total Tax(Y)
                                                </td>
                                                <td class="frm-rght-clr123" width="10%">
                                                    &nbsp;<asp:Label ID="lblesttottax" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="16%">
                                                    Est Balance Tax
                                                </td>
                                                <td class="frm-rght-clr123" width="10%">
                                                    &nbsp;<asp:Label ID="lblestbaltax" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="16%">
                                                    Gross Amt(M)
                                                </td>
                                                <td class="frm-rght-clr123" width="10%">
                                                    &nbsp;<asp:Label ID="lblegrossamt" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="10%">
                                                    HRA Exemption
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lblehraexemption" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    Est Gross Amt(Y)
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lblestgrossamt" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    Est Taxable Income(Y)
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lblesttaxincome" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80C
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80c" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80CCC
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80ccc" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80CCD
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80ccd" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80D
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80d" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80E
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80e" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80DD
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80dd" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123" width="10%">
                                                    80G
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lbl80g" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    Interest House
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lblinteresthouse" runat="server"></asp:Label>
                                                </td>
                                                <td class="frm-lft-clr123" width="10%">
                                                    Chapter 6A
                                                </td>
                                                <td class="frm-rght-clr123" width="16%">
                                                    &nbsp;<asp:Label ID="lblchapter6a" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    &nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="head-2" valign="top">
                                                    <asp:GridView ID="empgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellSpacing="0"
                                                        CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False"
                                                        BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="Employee has no paid tax in this financial year!"
                                                        OnPageIndexChanging="empgrid_PageIndexChanging" CssClass="gvclass" Border="1px solid #ddd">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Emp Code">
                                                                <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Wrap="False" Width="5%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Emp Name">
                                                                <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Wrap="False" Width="18%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Wrap="False" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Department">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Wrap="False" Width="15%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Month">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Wrap="False" Width="8%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("month") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField HeaderText="Est Total Tax(Y)">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("incometax") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField>  --%>
                                                            <asp:TemplateField HeaderText="Monthly Tax">
                                                                <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("total_tax") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- <asp:TemplateField  HeaderText="Est Balance Tax">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("balance") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField>
                               
                                <asp:TemplateField HeaderText="Gross Amt(M)">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("gross_amount") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField> 
                                       
                               
                               
                               <asp:TemplateField HeaderText="HRA Exemption">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("hra_exemption") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField>
                                                                                     
                                
                               
                               <asp:TemplateField HeaderText="Est Gross Amt(Y)">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("tgross") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField>
                               
                               <asp:TemplateField HeaderText="Est Taxable Income(Y)">
                               <HeaderStyle Wrap="False" CssClass="frm-lft-clr123" HorizontalAlign="Left"/>                  
                               <ItemStyle Width="5%"   HorizontalAlign="Left" VerticalAlign="Top" CssClass= "frm-rght-clr1234"  /> 
                              <ItemTemplate>
                                <asp:Label ID="l3" runat="server" Text ='<%# Bind ("ttaxable_amount") %>'></asp:Label>
                              </ItemTemplate>
                               </asp:TemplateField>  --%>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%-- </table></td>
    </tr>--%>
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>
    <%--</TD></TR></TABLE>--%>
    </form>
</body>
</html>
