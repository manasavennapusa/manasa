<%@ Page Language="C#" MasterPageFile="~/EmployeeMaster.master" AutoEventWireup="true" CodeFile="mycontact_important_old.aspx.cs" Inherits="mycontact_important" Title="SmartDrive Labs Technologies India Pvt. Ltd." %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
             <td width="777" valign="top" class="employee-section" style="padding:5px 0px 5px 0px; height: 416px;">
               <table width="99%"  border="0" align="center" cellpadding="0" cellspacing="0" style="height: 273px">
                  <tr>
                        <td class="frm-lft-clr-main">My Important Contacts</td>
                  </tr>
                  <tr>              
                    <td>
                        <asp:MultiView ID="MultiView1" runat="server">
                            
                            <asp:View ID="View1" runat="server">
                                <table width="99%"  border="0" align="center" cellpadding="0" cellspacing="0" style="height: 273px">
                                     <tr>
                                        <td class="frm-lft-clr-main">My Doctor's List</td>
                                     </tr>
                                     <tr>              
                                        <td>                     
                                         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" Width="100%" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="344px" AutoGenerateColumns="False" Font-Names="Arial" Font-Size="12px" CellPadding="3" ForeColor="DodgerBlue" BackColor="White" BorderColor="Gainsboro" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="example.css">
                                                       <PagerSettings PageButtonCount="5"></PagerSettings>
                                                       <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                                       <RowStyle CssClass="blue1" ForeColor="#000066"></RowStyle>
                                                       <Columns>
                                                           <asp:TemplateField HeaderText="Name">  
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("c_name") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("c_name") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                            
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Email ID">  
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("c_email") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("c_email") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Phone No">
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("c_phno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("c_phno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />                                                                
                                                           </asp:TemplateField>
                                                              
                                                           <asp:TemplateField HeaderText="Mobile No">
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("c_mobno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("c_mobno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>                                                                                                                               
                                                          
                                                       </Columns>
                                                       <PagerStyle HorizontalAlign="Left" Font-Names="Arial" Font-Size="11px" BackColor="White" ForeColor="#000066"></PagerStyle>
                                                       <SelectedRowStyle BackColor="#669999" CssClass="blue1" Font-Bold="True" ForeColor="White" Wrap="True"></SelectedRowStyle>
                                                       <HeaderStyle Wrap="True" BackColor="#006699" CssClass="blue1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                       <EditRowStyle CssClass="blue1"></EditRowStyle>
                                                       <AlternatingRowStyle CssClass="blue1"></AlternatingRowStyle>
                                                 </asp:GridView>
                                             </td>                
                                         </tr>
                                    </table>                                
                            </asp:View>
                            
                            <asp:View ID="View2" runat="server">
                               <table width="99%"  border="0" align="center" cellpadding="0" cellspacing="0" style="height: 273px">
                                     <tr>
                                        <td class="frm-lft-clr-main">My Lawyer's List</td>
                                     </tr>
                                     <tr>              
                                        <td>                     
                                         <asp:GridView ID="GridView2" runat="server" AllowPaging="True" Width="100%" OnSelectedIndexChanged="GridView2_SelectedIndexChanged" Height="344px" AutoGenerateColumns="False" Font-Names="Arial" Font-Size="12px" CellPadding="3" ForeColor="DodgerBlue" BackColor="White" BorderColor="Gainsboro" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="example.css">
                                                       <PagerSettings PageButtonCount="5"></PagerSettings>
                                                       <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                                       <RowStyle CssClass="blue1" ForeColor="#000066"></RowStyle>
                                                       <Columns>
                                                           <asp:TemplateField HeaderText="Name">  
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("c_name") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("c_name") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                            
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Email ID">  
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("c_email") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("c_email") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Phone No">
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("c_phno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("c_phno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />                                                                
                                                           </asp:TemplateField>
                                                              
                                                           <asp:TemplateField HeaderText="Mobile No">
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("c_mobno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("c_mobno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>                                                                                                                               
                                                          
                                                       </Columns>
                                                       <PagerStyle HorizontalAlign="Left" Font-Names="Arial" Font-Size="11px" BackColor="White" ForeColor="#000066"></PagerStyle>
                                                       <SelectedRowStyle BackColor="#669999" CssClass="blue1" Font-Bold="True" ForeColor="White" Wrap="True"></SelectedRowStyle>
                                                       <HeaderStyle Wrap="True" BackColor="#006699" CssClass="blue1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                       <EditRowStyle CssClass="blue1"></EditRowStyle>
                                                       <AlternatingRowStyle CssClass="blue1"></AlternatingRowStyle>
                                                 </asp:GridView>
                                             </td>                
                                         </tr>
                                    </table>
                            </asp:View>
                            
                            <asp:View ID="View3" runat="server">
                                  <table width="99%"  border="0" align="center" cellpadding="0" cellspacing="0" style="height: 273px">
                                     <tr>
                                        <td class="frm-lft-clr-main">My Family Advicers</td>
                                     </tr>
                                     <tr>              
                                        <td>                     
                                         <asp:GridView ID="GridView3" runat="server" AllowPaging="True" Width="100%" OnSelectedIndexChanged="GridView3_SelectedIndexChanged" Height="344px" AutoGenerateColumns="False" Font-Names="Arial" Font-Size="12px" CellPadding="3" ForeColor="DodgerBlue" BackColor="White" BorderColor="Gainsboro" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="example.css">
                                                       <PagerSettings PageButtonCount="5"></PagerSettings>
                                                       <FooterStyle BackColor="White" ForeColor="#000066"></FooterStyle>
                                                       <RowStyle CssClass="blue1" ForeColor="#000066"></RowStyle>
                                                       <Columns>
                                                           <asp:TemplateField HeaderText="Name">  
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("c_name") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("c_name") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                            
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Email ID">  
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("c_email") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("c_email") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>
                                                           
                                                           <asp:TemplateField HeaderText="Phone No">
                                                                 <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("c_phno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("c_phno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />                                                                
                                                           </asp:TemplateField>
                                                              
                                                           <asp:TemplateField HeaderText="Mobile No">
                                                                <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("c_mobno") %>'></asp:TextBox>
                                                                </EditItemTemplate>
                                                                <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("c_mobno") %>'  CssClass="blue1"></asp:Label> 
                                                                </ItemTemplate>                                                               
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" Width="155px" />
                                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Top" />
                                                           </asp:TemplateField>                                                                                                                               
                                                          
                                                       </Columns>
                                                       <PagerStyle HorizontalAlign="Left" Font-Names="Arial" Font-Size="11px" BackColor="White" ForeColor="#000066"></PagerStyle>
                                                       <SelectedRowStyle BackColor="#669999" CssClass="blue1" Font-Bold="True" ForeColor="White" Wrap="True"></SelectedRowStyle>
                                                       <HeaderStyle Wrap="True" BackColor="#006699" CssClass="blue1" Font-Bold="True" ForeColor="White"></HeaderStyle>
                                                       <EditRowStyle CssClass="blue1"></EditRowStyle>
                                                       <AlternatingRowStyle CssClass="blue1"></AlternatingRowStyle>
                                                 </asp:GridView>
                                             </td>                
                                         </tr>
                                    </table>
                            </asp:View>
                            
                        </asp:MultiView>
                    </td>
        
                  </tr>
               </table>
             </td>
         </tr>
        
    </table>

</asp:Content>

