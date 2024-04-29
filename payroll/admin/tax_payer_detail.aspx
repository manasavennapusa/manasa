<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tax_payer_detail.aspx.cs"
    Inherits="payroll_admin_tax_payer_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>YKK Employee Information</title>
   <style type="text/css">
       .auto-border-right {
            border-right-style:solid;
            border-right-color:lightblue;
            border-right-width:0.1px;   
        }


          </style>
   
     <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
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
                                        <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01">
                                            Tax PayerDetail Master</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top">
                            </td>
                        </tr>
                        <tr>
                            <td height="20" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td class="txt02" style="width: 41%">
                                            Update Tax Payer Detail Master</td>
                                        <td width="73%" align="right" class="txt-red">
                                            <span id="message" runat="server"></span>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <td width="49%" height="22" valign="top" class="txt02">
                                            Employer Details</td>
                                        <td width="2%">
                                        </td>
                                        <td width="49%" height="22" valign="top" class="txt02">
                                            Responsible Person Details</td>
                                    </tr>
                                    
                                  <%--  <tr>
                                        <td colspan="3">
                                            &nbsp;</td>
                                    </tr>--%>
                                    <tr>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="40%" class="frm-lft-clr123">
                                                        &nbsp;Name</td>
                                                    <td width="60%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtempname" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address1</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        <asp:TextBox ID="txtempadd1" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td class="frm-lft-clr123" width="25%">
                                                        Address2</td>
                                                    <td class="frm-rght-clr123" width="75%">
                                                        <asp:TextBox ID="txtempadd2" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address3</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtempadd3" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address4</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtempadd4" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address5</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtempadd5" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                             
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        State</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:DropDownList ID="ddlempstate" runat="server" CssClass="span10" 
                                                            DataSourceID="SqlDataSource1" DataTextField="state_name" DataValueField="state_code">
                                                        </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                                                            SelectCommand="select state_code,state_name from tbl_intranet_incometax_state"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Pin</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtemppin" runat="server" CssClass="span10"
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Telephone</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtemptel" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Std</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                         &nbsp;<asp:TextBox ID="txtempstd" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Emailid</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtempemail" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        EPF No</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtepfno" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        ESI No</td>
                                                    <td width="75%" class="frm-rght-clr123">
                                                        &nbsp;<asp:TextBox ID="txtesino" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123 border-bottom">
                                                        ESI Local No</td>
                                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                                        &nbsp;<asp:TextBox ID="txtesilocalno" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" colspan="2">
                                                        Mandatory Fields (<img src="../../images/error1.gif" alt="" />)</td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td width="40%" class="frm-lft-clr123">
                                                        &nbsp;Name</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        <asp:TextBox ID="txtrespname" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="40%" class="frm-lft-clr123">
                                                        &nbsp;Father'sName</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        <asp:TextBox ID="txtrespfname" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="40%" class="frm-lft-clr123">
                                                        &nbsp;Designation</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        <asp:TextBox ID="txtrespdesig" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address1</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        <asp:TextBox ID="txtrespadd1" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123" width="25%">
                                                        Address2</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        <asp:TextBox ID="txtrespadd2" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address3</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtrespadd3" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address4</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtrespadd4" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Address5</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtrespadd5" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        State</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:DropDownList ID="ddlrespstate" runat="server" CssClass="span10" 
                                                            DataSourceID="SqlDataSource2" DataTextField="state_name" DataValueField="state_code">
                                                        </asp:DropDownList>
                                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
                                                            ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>"
                                                            SelectCommand="select state_code,state_name from tbl_intranet_incometax_state"></asp:SqlDataSource>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Pin</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtresppin" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Telephone</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtresptel" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               
                                                
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123">
                                                        Std</td>
                                                    <td class="frm-rght-clr123" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtrespstd" runat="server" CssClass="span10"  MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td width="25%" class="frm-lft-clr123 border-bottom">
                                                        Emailid</td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 75%">
                                                        &nbsp;<asp:TextBox ID="txtrespemail" runat="server" CssClass="span10" 
                                                            MaxLength="50"></asp:TextBox>
                                                    </td>
                                                </tr>
                                               <%-- <tr>
                                                    <td height="5" colspan="2">
                                                    </td>
                                                </tr>--%>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top">
                                &nbsp;<asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="button" OnClick="btnsbmit_Click"
                                    ValidationGroup="v" ToolTip="Click here to update tax payer detail" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
                  </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        <%--</ContentTemplate> 
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
