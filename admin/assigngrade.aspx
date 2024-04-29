<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assigngrade.aspx.cs" Inherits="Admin_Company_assigngrade" Title=":: Assign Grade ::" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">


<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
<title>Admin Panel</title>



<style type="text/css" media="all">
@import "../../css/blue1.css";
@import "../../css/example.css";
</style>
<script type="text/javascript" src="../../js/tabber.js"></script>
<script type="text/javascript">
document.write('<style type="text/css">.tabber{display:none;}<\/style>');
</script>


<script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>
<script type="text/javascript" src="../../js/ddaccordion.js"></script>
<script type="text/javascript">
ddaccordion.init({
headerclass: "expandable", //Shared CSS class name of headers group
contentclass: "submenu", //Shared CSS class name of contents group
collapseprev: true, //Collapse previous content (so only one open at any time)? true/false 
defaultexpanded: [], //index of content(s) open by default [index1, index2, etc] [] denotes no content
animatedefault: false, //Should contents open by default be animated into view?
persiststate: true, //persist state of opened contents within browser session?
toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
togglehtml: ["suffix", "<img src='../../images/plus3.gif' class='statusicon' />", "<img src='../../images/minus3.gif' class='statusicon' />"], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
animatespeed: "normal" //speed of animation: "fast", "normal", or "slow"
})
</script>

<link href="../css/blue1.css" rel="stylesheet" /></head>

<body>

<div class="header">

<form id="cmaster" runat="server">


                <TABLE cellSpacing=0 cellPadding=0 width="100%" align=center border=0>

                            <TBODY>
                        
                                        <TR>
                                        
                                                    <TD  class="txt03" colSpan=2 style="height: 22px">
                                                        Grade Master</TD>
                                                    
                                       </TR>
                                       
                                       <TR>
                                        
                                                    <TD class="frm-lft-clr123" width="20%">Grade Name<span style="color: #ff0033">*</span></TD>
                                                    
                                                    <TD class="frm-rght-clr123" width="80%">
                                                    
                                                                <asp:TextBox id="txtgradename" tabIndex=2 runat="server" Height="14px" Width="200px" CssClass="blue1"></asp:TextBox>&nbsp;
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgradename"
                                                            ErrorMessage='<img src="images\error1.gif" alt="*" />' ToolTip="Enter Grade Name" ValidationGroup="v" SetFocusOnError="True"></asp:RequiredFieldValidator></TD>
                                                                
                                       </TR>
                                       
                                       <TR>
                                       
                                                    <TD style="HEIGHT: 5px" colSpan=2><IMG height=5 src="images/5x5.gif" width=5 /></TD>
                                                    
                                       </TR>
                                       
                                       <TR>
                                       
                                                    <TD class="frm-lft-clr123" width="20%">Description</TD>
                                                    
                                                    <TD class="frm-rght-clr123" width="80%">
                                                    
                                                                <asp:TextBox id="txtgradedescription" tabIndex=4 runat="server" Height="55px" Width="200px" TextMode="MultiLine" CssClass="blue1"></asp:TextBox>
                                                                
                                                    </TD>
                                                    
                                       </TR>
                                       
                                       <TR>
                                       
                                                    <TD style="HEIGHT: 5px" colSpan=2><IMG height=5 src="images/5x5.gif" width=5 /></TD>
                                                    
                                       </TR>
                                <tr>
                                    <td class="frm-rght-clr123" colspan="2">
                                        <span style="color: #ff0033">(*)Mandatory Fields</span></td>
                                </tr>
                                       
                                       <TR>
                                       
                                                    <TD style="HEIGHT: 5px" colSpan=2><IMG height=5 src="images/5x5.gif" width=5 /></TD>
                                                    
                                       </TR>
                                       
                                       <TR>
                                       
                                                    <TD vAlign=top colSpan=2>
                                                    
                                                                <TABLE cellSpacing=0 cellPadding=0 width=260 align=right border=0>
                                                                
                                                                            <TBODY>
                                                                            
                                                                                        <TR>
                                                                                        
                                                                                                  <TD align="right">
                                                                                                 
                                                                                                            <TABLE cellSpacing=0 cellPadding=0 width=70 border=0>
                                                                                                            
                                                                                                                        <TBODY>
                                                                                                                        
                                                                                                                                    <TR>
                                                                                                                                    
                                                                                                                                                <TD style="WIDTH: 1%"></TD>
                                                                                                                                                
                                                                                                                                                <TD style="WIDTH: 98%" class="text4" align=center>
                                                                                                                                                
                                                                                                                                                            <asp:Button id="btnsave" onclick="btnsave_Click" runat="server" CssClass="button" Text="Save" ValidationGroup="v"></asp:Button>
                                                                                                                                                            
                                                                                                                                                </TD>
                                                                                                                                                
                                                                                                                                                <TD style="WIDTH: 1%" align=right></TD>
                                                                                                                                                
                                                                                                                                    </TR>
                                                                                                                                    
                                                                                                                        </TBODY>
                                                                                                                        
                                                                                                            </TABLE>
                                                                                                            
                                                                                                
                                                                                                </TD>
                                                                                                
                                                                                                <TD align="center">
                                                                                                
                                                                                                            <TABLE cellSpacing=0 cellPadding=0 width=70 border=0>
                                                                                                            
                                                                                                                        <TBODY>
                                                                                                                        
                                                                                                                                    <TR>
                                                                                                                                    
                                                                                                                                                <TD style="WIDTH: 1%"></TD>
                                                                                                                                                
                                                                                                                                                <TD style="WIDTH: 98%" class="text4" align=center background="images/button-middle.jpg">
                                                                                                                                                
                                                                                                                                                            <asp:Button id="brnrs" runat="server" CssClass="button" Text="Reset" ValidationGroup="v" OnClick="brnrs_Click"></asp:Button>
                                                                                                                                                            
                                                                                                                                                </TD>
                                                                                                                                                
                                                                                                                                                <TD style="WIDTH: 1%" align=right></TD>
                                                                                                                                                
                                                                                                                                   </TR>
                                                                                                                                   
                                                                                                                        </TBODY>
                                                                                                                        
                                                                                                           </TABLE>
                                                                                                           
                                                                                               </TD>                                                                                             
                                                                                               
                                                                                           
                                                                                              
                                                                                     </TR>
                                                                                     
                                                                             </TBODY>
                                                                             
                                                                   </TABLE>
                                                        <span id="message" runat="server" enableviewstate="false" class="txt02"></span>
                                                        
                                                        </TD>
                                                             
                                                       </TR>
                                <TR>
                                       
                                                    <TD style="HEIGHT: 5px" colSpan=2><IMG height=5 src="images/5x5.gif" width=5 /></TD>
                                                    
                                       </TR>
                                            <tr>
                                                <td class="frm-rght-clr123" colspan="2">
                                                    Grade View Details</td>
                                </tr>            
                                                       
                                                      <tr>
                                                      
                                                             <td colspan="2">           
                                            
                                                                    <asp:GridView
                                                                     ID="grid_hierarchy"
                                                                      runat="Server"
                                                                       AllowSorting="True"
                                                                        AutoGenerateColumns="False"
                                                                         cellpadding="4"
                                                                           EmptyDataText="No Data Available"
                                                                            BorderWidth="1px"
                                                                             bordercolor="#C1C1C1"
                                                                              style="border-collapse:collapse;"
                                                                               DataKeyNames="id"
                                                                                Width="100%"
                                                                                 CssClass="wht-clr-1"
                                                                                  OnPageIndexChanging="grid_hierarchy_PageIndexChanging"
                                                                                   OnRowCancelingEdit="grid_hierarchy_RowCancelingEdit"
                                                                                    OnRowDeleting="grid_hierarchy_RowDeleting"
                                                                                     OnRowEditing="grid_hierarchy_RowEditing"
                                                                                      OnRowUpdating="grid_hierarchy_RowUpdating"
                                                                                       OnRowDataBound="grid_hierarchy_RowDataBound"
                                                                                        AllowPaging="True" ToolTip="Grade View Details">
        
                                                                        <Columns>
                                                                
                                                                                <asp:TemplateField HeaderText="Grade Name">
                                                                                            
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem, "gradename") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                
                                
                                                                                            <EditItemTemplate>
                                                                                            
                                                                                                    <asp:TextBox ID="txt_gname" Text='<%#DataBinder.Eval(Container.DataItem, "gradename") %>' size="30" ValidationGroup="update" CssClass="blue1"  runat="server"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_gname" Display="Dynamic" ErrorMessage='<img src="images/action_delete.gif" alt="Required Field" border="0"  />' ValidationGroup="update"></asp:RequiredFieldValidator>
                                                                                            
                                                                                            </EditItemTemplate>
                            
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField HeaderText="Description">
                                                                                            
                                                                                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                    
                                                                                                    <asp:Label ID="Label5" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem, "description") %>'></asp:Label>
                                                                                            
                                                                                            </ItemTemplate>
                                                                                            
                                                                                            <EditItemTemplate>
                                                                                                    
                                                                                                    <asp:TextBox ID="txt_description" Text='<%#DataBinder.Eval(Container.DataItem, "description") %>' ValidationGroup="update" CssClass="blue1"  runat="server"></asp:TextBox>
                                                                                                    
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_description" Display="Dynamic" ErrorMessage='<img src="images/action_delete.gif" alt="Required Field" border="0"  />' ValidationGroup="update"></asp:RequiredFieldValidator>
                                                                                                    
                                                                                                    
                                                                                            
                                                                                            </EditItemTemplate>
                                                                                
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField HeaderText="Created Date">
                                                                                            
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%" />
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                    
                                                                                                    <asp:Label ID="lblcreateddate" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem, "createddate") %>'></asp:Label>
                                                                                            
                                                                                            </ItemTemplate>
                                                                                
                                                                                </asp:TemplateField>
                                                                                
                                                                                <asp:TemplateField HeaderText="Created By">
                                                                                            
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%" />
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                    
                                                                                                    <asp:Label ID="lblcreatedby" runat="Server" Text='<%#DataBinder.Eval(Container.DataItem, "createdby") %>'></asp:Label>
                                                                                            
                                                                                            </ItemTemplate>
                                                                                            
                                                                                           
                                                                                
                                                                                </asp:TemplateField>
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                                                                                
                            
                                                                                <asp:TemplateField>
                                                                                            
                                                                                            <ItemStyle HorizontalAlign="Left" Width="28%" />
                                                                                            
                                                                                            <ItemTemplate>
                                                                                                    
                                                                                                    <asp:Button ID="Button3" runat="server" CssClass="button"  CommandName="Edit" Text="Edit" />
                                                                                                    
                                                                                                    <asp:Button ID="Button2" runat="server" CssClass="button" OnClientClick="return confirm('Are you sure to delete grade')" CommandName="Delete" Text="Delete" />
                                
                                                                                            </ItemTemplate>
                                                                                            
                                                                                            <EditItemTemplate>
                                                                                                    
                                                                                                    <asp:Button ID="Button4" runat="server" ValidationGroup="update" CssClass="button" OnClientClick="return confirm('Are you sure to update grade entry')" CommandName="Update" Text="Update" />
                                                                                                    
                                                                                                    <asp:Button ID="Button5" runat="server" CssClass="button" CommandName="Cancel" Text="Cancel" />
                                                                                            
                                                                                            </EditItemTemplate>
                                                                                
                                                                                </asp:TemplateField>
                                                                   
                                                                          </Columns>
                                                        
                                                                          <AlternatingRowStyle CssClass="light-gray" />
                                                        
                                                                          <HeaderStyle CssClass="nav-head-1" HorizontalAlign="Left"/>
                                                        
                                                                          <EmptyDataRowStyle CssClass="blue-brdr-1" HorizontalAlign="Left" />   
             
                                                                    </asp:GridView>
                                                                
                                                                    
                                                            </td>
                                                       
                                                       </tr>
                                                       
                                                       <tr>
                                                 
                                                            <TD style="HEIGHT: 5px" vAlign=top colSpan=2></TD>
                                                            
                                                       </tr>
                                                       
                                             </TBODY>
                                             
                                    </TABLE>

</form>

</div>
<div class="footer">
<div class="main">
Powered by SmartDrive Labs Technologies India Pvt. Ltd.
</div>

</div>
</body>
</html>



