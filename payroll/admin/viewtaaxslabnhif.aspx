<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtaaxslabnhif.aspx.cs" Inherits="payroll_admin_viewtaaxslabnhif" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />

    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
     <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
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
                <div id="divapply">
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
                                                                    <td height="5" valign="top"></td>
                                                                </tr>
                                                                <tr id="Tr1" runat="server" visible="false">
                                                                    <td height="20" valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td width="29%" class="txt01" style="height: 13px">Tax Details
                                                                                </td>
                                                                                <td width="71%" align="right" class="txt-red" style="height: 13px">
                                                                                    <span id="message" runat="server"></span>&nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                              
                                                                <tr>
                                                                    <td height="5"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">NHIF
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td height="0" colspan="5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="tax_grid"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="min_amount"
                                                                                            Width="100%"
                                                                                            EmptyDataText="No record found"
                                                                                            
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Slab for NHIF">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("slab")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Manimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("min_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("max_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Fixed Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("fixed_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Start Date of Slab">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("start_date")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="End Date of Slab">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("end_date")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                               <%-- <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>
                                                                                            </Columns>

                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="5px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="txt02" align="left" height="22" valign="middle">Tax Slab 
                                                                    </td>
                                                                </tr>
                                                              
                                                                            <tr>
                                                                                <td height="0" colspan="5"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td height="10px"></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td colspan="5">
                                                                                    <div class="widget-content">
                                                                                        <asp:GridView ID="grid_tax"
                                                                                            runat="server"
                                                                                            AutoGenerateColumns="False"
                                                                                            DataKeyNames="min_amount"
                                                                                            Width="100%"
                                                                                            EmptyDataText="No record found"
                                                                                           
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">

                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Slab No.">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="a" runat="server" Text='<%# Bind("slab_no")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Manimum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="b" runat="server" Text='<%# Bind("min_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Maximum Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("max_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="Tax Percentage">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("fixed_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="Fixed Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("tax_pre")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                 <asp:TemplateField HeaderText="MRP Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="c" runat="server" Text='<%# Bind("mrp_amount")%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>

                                                                                             <%--   <asp:TemplateField>

                                                                                                    <ItemTemplate>
                                                                                                        <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                                                            CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>--%>
                                                                                            </Columns>

                                                                                        </asp:GridView>
                                                                                    </div>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                               
                                                           
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                             
                                                                <%-- <tr>
                                        <td>Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                        </td>
                                    </tr>--%>
                                                            </table>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:HiddenField ID="HiddenField2" runat="server" />
                </div>
                </table>
            </ContentTemplate>
          
        </asp:UpdatePanel>
    </form>
</body>
</html>
