<%@ Page Language="C#" AutoEventWireup="true" CodeFile="other-source-income.aspx.cs" Inherits="payroll_admin_other_source_income" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>

    <style type="text/css" media="all">
        @import "../../css/blue1.css";
         .star:before {
            content:" *";
        }
    </style>
     <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="leave" runat="server">
        </asp:ScriptManager>

        <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>

        <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
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
                                       <%-- <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>--%>
                                       <%-- <td class="txt01">Other Source Income Master</td>--%>

                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top"></td>
                        </tr>
                        <tr>
                            <td height="20" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="27%" class="txt02"></td>
                                        <td width="73%" align="right" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td valign="top" class="txt02">Create Other Source Income
                                
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">

                                <tr>
                                    <td width="25%" class="frm-lft-clr123">Other Source Inc. Head  <span class="star"></span></td>
                                    <td width="75%" class="frm-rght-clr123">&nbsp;<asp:TextBox ID="txtothrsrcinc" runat="server" CssClass="span4" Width=""
                                        onkeypress="return isCharOrSpace()"></asp:TextBox>&nbsp;
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtothrsrcinc"
                      Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                      ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                            ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtothrsrcinc"
                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="s">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>

                                    </td>
                                </tr>

                                <tr>
                                    <td width="25%" class="frm-lft-clr123 border-bottom"><%--Mandatory Fields (<img src="../../images/error1.gif" alt="" />)&nbsp;--%></td>
                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click" ValidationGroup="s" ToolTip="Click to submit " />&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="2"></td>
                                </tr>
                            </table>

                            </td>
                        </tr>

                    </table>
                </td>
            </tr>
          
            <tr>
                <td>

                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="margin-top:10px">
                       <tr> <td  class="txt02" >View Other Source Income</td></tr>
                        <tr>
                         
                                  <td class="frm-rght-clr123 border-bottom" colspan="2">                               
                                <div class="widget-content" style="margin-top:10px">
                                     
                                <asp:GridView ID="othrsrcincgird" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                     DataKeyNames="id" DataSourceID="SqlDataSource1"
                                    EmptyDataText="Sorry no record found"  PageSize="30"
                                    OnRowUpdating="othrsrcincgird_RowUpdating" CssClass ="table table-hover table-striped table-bordered table-highlight-head">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Other Source Income Head">
                                            <ItemTemplate>
                                                <asp:Label ID="lblperquistenameg" runat="server" Text='<%#Bind("incomesource")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtothrsrcincg" runat="server" CssClass="span4" Text='<%#Bind("incomesource")%>' ValidationGroup="othrsrcincgird" Width="" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Othr source inc Head can not be blank" ControlToValidate="txtothrsrcincg" ValidationGroup="othrsrcincgird"></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txtothrsrcincg"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="s">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                            </EditItemTemplate>
                                           
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="lnkbtnupdate" runat="server" ValidationGroup="othrsrcincgird" OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" />
                                                | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                            </EditItemTemplate>

                                            
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" CssClass="link05" Text="Edit" ToolTip="Edit" />
                                            </ItemTemplate>
                                          
                                        </asp:TemplateField>
                                    </Columns>
                                  
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                    ProviderName="System.Data.SqlClient"
                                    DeleteCommand="DELETE FROM tbl_payroll_income_source_master WHERE id=@id"
                                    SelectCommand="SELECT id,incomesource from tbl_payroll_income_source_master ORDER BY id"
                                    InsertCommand="INSERT INTO tbl_payroll_income_source_master(incomesource) VALUES(@name)">
                                    <DeleteParameters>
                                        <asp:Parameter Name="id" Type="Int32" />
                                    </DeleteParameters>

                                    <InsertParameters>
                                        <asp:Parameter Name="name" Type="String" />
                                    </InsertParameters>
                                    <SelectParameters>
                                        <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                           </div> </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2"></td>
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
        <%-- </ContentTemplate>
        </asp:UpdatePanel>--%>
    </form>
</body>
</html>
