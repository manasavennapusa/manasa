<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employedataform.aspx.cs" Inherits="onboarding_employedataform" %>

<%--<%@ Register Assembly="System.Web.Extensions" Namespace="System.Web.UI" TagPrefix="asp" %>--%>
<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e"
    Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <link href="../css/blue1.css" rel="stylesheet" />
       <script src="js/popup.js"></script>

    <link href="../css/main.css" rel="stylesheet" />
    <style type="text/css">

 p.MsoNormal
	{margin-bottom:.0001pt;
	font-size:12.0pt;
	font-family:"Times New Roman","serif";
	        margin-left: 0in;
            margin-right: 0in;
            margin-top: 0in;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="navbar hidden-desktop">
                  
                </div>
                <div class="page-header">
                    <div class="pull-left">
                        <h2> EMPLOYEE DATA FORM</h2>
                        <br /> 
                        <br />
                       
                       
                      
                    </div>
               
                    <div class="clearfix"></div>
                </div>
                  <div class="widget-body">
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <div class="controls controls-row">
                                                    <label class="control-label span3 ">Employee Code</label>
                                                    <div class="controls span3">
                                                        <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    </div>
                                                    <div class="controls span3">
                                                        <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i></a>
                                                    </div>
                                                     <div class="controls span1">
                                                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-info pull-right " Text="Generate Report" OnClick="btnSubmit_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>

               <%-- <div class="row-fluid">

                                <div class="widget">

                                <%--    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>PICK EMPLOYEE
                                        </div>
                                    </div>--%>
                                   <%-- <br />----%>

                                    <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>EMPLOYEE DATA FORM	
                                        </div>
                                    </div>

                                  

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="48%">Employee Name 
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="52%">
                                                                                <asp:Label ID="lbl_em" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="43%" class="frm-lft-clr123">Job Title 
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_jbtitle" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                        <asp:Label ID="txt_login_id" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                       <%-- <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> Grade
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_grade" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123">Department
                                                                            </td>
                                                                            <td class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> Date of Joining  
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_doj" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> Email ID
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_emid" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>


                                                                         <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Date of Issue
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_doi" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">   Date of Expiry               
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_doe" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>

                                                                <td valign="top">
                                                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" align="left">
                                                                        <tr>
                                                                            <td width="48%" class="frm-lft-clr123 ">Position
                                                                            </td>
                                                                            <td width="50%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_position" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Blood Group
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_bg" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td width="48%" class="frm-lft-clr123 "> Location
                                                                            </td>
                                                                            <td width="51%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Date Of Birth 
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_dob" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Contact no 
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_cn" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                         <tr>
                                                                            <td width="48%" class="frm-lft-clr123 ">Anniversary
                                                                            </td>
                                                                            <td width="51%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_anniv" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <%--<tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>--%>
                                                                         <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Passport No
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_pn" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                                    </table>                                                                
                                                                </td>                  
                                                            </tr>
                                                          
                                                            



                                                        </table>







                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>                         
                                        </fieldset>
                                    </div>
                                </div>
                            </div>




<br />
                    <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            Address	
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="290px" height="80px">Current Home Address 
                                                                            <td class="frm-rght-clr123 border-bottom" width="290px ">
                                                                                <asp:Label ID="lbl_cha" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                       <%-- <tr>
                                                                            <td width="43%" class="frm-lft-clr123">Telephone No
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_tlpno" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                        <asp:Label ID="Label3" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> Email ID
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_emid" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>--%>
                                                                     
                                                                    </table>
                                                                </td>

                                                                <td valign="top">
                                                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" align="left">
                                                                        <tr>
                                                                            <td width="290px" height="80px" class="frm-lft-clr123 border-bottom ">Permanent Home Address 
                                                                            </td>
                                                                            <td width="50%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_phd" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                      <%--  <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Telephone No.
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_tno" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> Email ID
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_eid" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>--%>

                                                                    
                                                                       
                                                                    </table>                                                                
                                                                </td>                  
                                                            </tr>
                                                          
                                                            

                                                        </table>


                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>                         
                                        </fieldset>
                                    </div>
                                </div>
                            </div>


                                    <br />
                   <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            EMERGENCY   CONTACT   INFORMATION
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        
                                            <br />

                                            <asp:GridView ID="gvemgcontact" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                       AutoGenerateColumns="False" AllowSorting="True"
                                                                                        CaptionAlign="Left" DataKeyNames="emg_name" HorizontalAlign="Left" BorderWidth="0px">

                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label1" runat="Server" Text='<%# Eval("emg_name") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact Relation">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("emg_relation") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. Contact No. ">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("emg_contactno") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Emg. LandLine No.">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="Label48" runat="Server" Text='<%# Eval("emg_landlineno") %>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Left" Width="20%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField>
                                                                                                <ItemTemplate>
                                                                                                    <asp:LinkButton
                                                                                                        ID="LinkButton1" runat="server" CommandName="Delete" CssClass="link04" Text="Delete"></asp:LinkButton>
                                                                                                </ItemTemplate>
                                                                                                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                                <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                    </asp:GridView>



                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>   
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                                                  
                                        </fieldset>




                                    </div>
                                </div>
                            </div>
                <br />
                   <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            PERSONAL DETAILS 
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="290px" height="30px"> Marital Status 	 
                                                                            <td class="frm-rght-clr123" width="142px">
                                                                                <asp:Label ID="lbl_ms" runat="server" Width="142px" style="height: 18px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="43%" class="frm-lft-clr123"> Spouse Name 	
                                                                            </td>
                                                                            <td width="57%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_sn" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                        <asp:Label ID="Label15" runat="server" Visible="False"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom"> No of Children
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_noc" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                     
                                                                      
                                                                    </table>
                                                                </td>

                                                                <td valign="top">
                                                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" align="left">
                                                                        <tr>
                                                                            <td width="99PX" height="30px" class="frm-lft-clr123 ">Fathers Name
                                                                            </td>
                                                                            <td width="50%" class="frm-rght-clr123">
                                                                                <asp:Label ID="lbl_fn" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom">Monthers Name
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_mn" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    

                                                                    
                                                                       
                                                                    </table>                                                                
                                                                </td>                  
                                                            </tr>
                                                          
                                                            

                                                        </table>
                                            <br />





                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>   
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                                                  
                                        </fieldset>




                                    </div>
                                </div>
                            </div>
                <br />
                 


                  <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            &nbsp;
EMPLOYEE DATA FORM  (Total Experience:)
 
                                            </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        
                                            <br />

                                            <asp:GridView ID="grid_exp" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Company Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labesl1" runat="Server" Text='<%# Eval("comp_name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Address / Location" HeaderStyle-Width="30%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1sde" runat="Server" Text='<%# Eval("location") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labeldes" runat="Server" Text='<%# Eval("designation") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Total Exp." HeaderStyle-Width="10%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labewdl48" runat="Server" Text='<%# Eval("total_exp") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year" HeaderStyle-Width="15%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Lawecbel4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>-
                                                                                    <asp:Label ID="Labecxdl2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>



                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>   
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                                                  
                                        </fieldset>




                                    </div>
                                </div>
                            </div>
                <br />
                

                  <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            &nbsp;EDUCATION</div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        
                                            <br />

                                            <asp:GridView ID="grid_edu_education" runat="Server" Width="100%" CellPadding="4" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True"
                                                                                    CaptionAlign="Left" DataKeyNames="education" HorizontalAlign="Left" BorderWidth="0px">

                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Education">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1" runat="Server" Text='<%# Eval("education") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Specialization">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("specialization") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left" Width="18%"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="18%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="School / Institute / University Name">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label1e" runat="Server" Text='<%# Eval("school") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="30%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Grade / %">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label48" runat="Server" Text='<%# Eval("percentage") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Year">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Label4" runat="Server" Text='<%# Eval("from_year") %>'></asp:Label>&nbsp;-&nbsp;<asp:Label
                                                                                                    ID="Label2" runat="Server" Text='<%# Eval("to_year") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                                                                            <ItemStyle HorizontalAlign="Left" Width="15%"></ItemStyle>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                    <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                                </asp:GridView>



                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>   
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                                                  
                                        </fieldset>




                                    </div>
                                </div>
                            </div>
                <br />
                   <div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            &nbsp;TRAINING</div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                <%--   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>--%>
                                                </tr>      
                                            </table>  

                                                        
                                            <br />

                                            <asp:GridView ID="GridTraning" runat="Server" Width="100%" CssClass="table table-hover table-striped table-bordered table-highlight-head"
                                                                                    AutoGenerateColumns="False" AllowSorting="True" CaptionAlign="Left" DataKeyNames="trainingname"
                                                                                    HorizontalAlign="Left" CellPadding="4">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="Training Name" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTraning" runat="Server" Text='<%# Eval("trainingname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Conducted By" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblConductedBy" runat="Server" Text='<%# Eval("personname")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="From" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblfromdate" runat="Server" Text='<%# Eval("fromdate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="To" HeaderStyle-Width="16%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lbltodate" runat="Server" Text='<%# Eval("todate")%>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:TemplateField HeaderText="Remarks" HeaderStyle-Width="18%">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("remarks") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Top"></HeaderStyle>
                                                                                </asp:GridView>



                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>   
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                            
                                                                  
                                        </fieldset>




                                    </div>
                                </div>
                            </div>
                <br />
                           <%--<div class="row-fluid">

                                <div class="widget">

                                    <div class="widget-header">
                                        <div class="title">
                                            REFERENCES 
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <fieldset>
                                            <table>
                                                <tr>
                                                  <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Employee Name </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label1" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>      
                                            </table>  

                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="50%">
                                                                    <table width="99%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" width="290px" height="80px">Reference No 1                       
                                                                            <td class="frm-rght-clr123 border-bottom" width="290px">
                                                                                <asp:Label ID="lbl_rf2" runat="server" Width="142px"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                      
                                                                     
                                                                    </table>
                                                                </td>

                                                                <td valign="top">
                                                                    <table width="99%" border="0" cellpadding="0" cellspacing="0" align="left">
                                                                        <tr>
                                                                            <td width="290px" height="80px" class="frm-lft-clr123 border-bottom ">Reference No 1   
                                                                            </td>
                                                                            <td width="50%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Label ID="lbl_rf1" runat="server"></asp:Label>
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>

                                                                     
                                                                    
                                                                       
                                                                    </table>                                                                
                                                                </td>                  
                                                            </tr>
                                                          
                                                            

                                                        </table>


                                        
                                            
                              


                                          
                                               <%--<table>--%>
                                               <%-- <tr>
                                                   <td width="100%">
                                                        <table width="100%" border="0" cellpadding="0" cellspacing="0" style="height:20px">
                                                            <tr>
                                                              <td class="frm-lft-clr123 border-bottom" width="290px"> Passport No.  </td>
                                                              <td class="frm-rght-clr123 border-bottom" width="955px">
                                                                  <asp:Label ID="Label15" runat="server">                    
                                                                  </asp:Label>
                                                                   &nbsp;
                                                              </td>
                                                            </tr>
                                                            <tr>
                                                                            <td height="5" colspan="2"></td>
                                                                        </tr>
                                                        </table>
                                                   </td>
                                                </tr>--%>      
                                            <%--</table> --%>                         
                          <%--              </fieldset>
                                    </div>
                                </div>
                            </div>--%>
                <h5>The above details are true and best of my knowledge. I understand that any misrepresentation of facts may be called for disciplinary action.</h5><br />
                 <p> <b>Name:</b>&nbsp;__________________________________&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b> Date: </b> <asp:Label ID="lbldatetime" runat="server"></asp:Label></p>
                                    



                <asp:Label ID="lbl_msg" runat="server" EnableViewState="False"></asp:Label>
            </div>
        </div>

    </form>
   
</body>
</html>
