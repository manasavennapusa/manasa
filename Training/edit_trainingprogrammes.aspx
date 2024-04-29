<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="edit_trainingprogrammes.aspx.cs" Inherits="training_edit_trainingprogrammes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->

<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../Leave/Js/popup.js"></script>
    <script src="Js/popup.js"></script>
    <script type="text/javascript">
        //function enterdate(evt) {

        //    // alert('Please use calender icon to enter date')
        //    return false;
        //}



    </script>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />


</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Edit Work Location</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit Work Location
                                        </div>
                                    </div>

                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                        <tbody>
                                            <tr>
                                                <td class="frm-lft-clr123" width="22%">Training Code:
                                                </td>
                                                <td class="frm-rght-clr123" width="25%">

                                                      <%--<asp:Label ID="txt_approver" runat="server"></asp:Label>--%>

                                                    <asp:TextBox ID="txt_approver" 
                                                    runat="server"
                                                     class="span6"></asp:TextBox>

                                                <a href="JavaScript:newPopup1('picktrainingcode.aspx');"><i class="icon-user"></i>Pick TrainingCode</a>
                                                </td>

                                                <td class="frm-lft-clr123" width="22%">Batch Code:
                                                </td>
                                                <td class="frm-rght-clr123" width="30%">                                                                                                       
                                                    <input type="Text"
                                                           id="txt_bachcode" 
                                                           runat="server"
                                                           CssClass="span10" />
                                          
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Training Name:  *
                                                </td>
                                                <td class="frm-rght-clr123">

                                                    <asp:DropDownList ID="ddl_trainingname" runat="server" AutoPostBack="true">
                                                </asp:DropDownList>
                                                </td>
                                                <td class="frm-lft-clr123">Training Type:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddl_trainingtype" runat="server">
                                                    <asp:ListItem Selected="True">----Selected Training type</asp:ListItem>                                                    
                                                    <asp:ListItem Text="Long training" ></asp:ListItem>
                                                    <asp:ListItem Text="Short training" ></asp:ListItem>
                                                    <asp:ListItem Text="Week End Batch training" ></asp:ListItem>
                                                </asp:DropDownList>  
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Module Name:
                                                <td class="frm-rght-clr123">
                                                      <input type="text"
                                                    id="txt_module_name"
                                                    runat="server"
                                                   CssClass="span10" />
                                                </td>
                                                <td class="frm-lft-clr123">Training Short Name:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                     <input type="text"
                                                    id="txt_training_short_name"
                                                    runat="server"
                                                    CssClass="span10" />
                                                   
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Description:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                     <asp:TextBox ID="txt_description" runat="server" TextMode="MultiLine"  CssClass="span8"></asp:TextBox>
                                                </td>
                                                <td class="frm-lft-clr123">year
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddl_yearedit" runat="server"  AutoPostBack="true">
                                                    <asp:ListItem Selected="True">---Select year---</asp:ListItem>
                                                   <asp:ListItem Text="2010" ></asp:ListItem>
                                                    <asp:ListItem Text="2011"></asp:ListItem>
                                                    <asp:ListItem Text="2012" ></asp:ListItem>
                                                    <asp:ListItem Text="2013" ></asp:ListItem>
                                                    <asp:ListItem Text="2014" ></asp:ListItem>
                                                    <asp:ListItem Text="2015" ></asp:ListItem>
                                                    <asp:ListItem Text="2016" ></asp:ListItem>
                                                    <asp:ListItem Text="2017" ></asp:ListItem>
                                                    <asp:ListItem Text="2018" ></asp:ListItem> 
                                                    <asp:ListItem Text="2019" ></asp:ListItem>  
                                                    <asp:ListItem Text="2020" ></asp:ListItem>  
                                                    <asp:ListItem Text="2021" ></asp:ListItem>                                                                                                      
                                              </asp:DropDownList> 
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Month:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="ddl_monthedit" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Selected="True">---Select month---</asp:ListItem>                                                  
                                                     <asp:ListItem Text="Jan"></asp:ListItem>
                                                    <asp:ListItem Text="Feb" ></asp:ListItem>
                                                    <asp:ListItem Text="Mar"></asp:ListItem>
                                                    <asp:ListItem Text="Apr"></asp:ListItem>
                                                    <asp:ListItem Text="May" ></asp:ListItem>
                                                    <asp:ListItem Text="Jun" ></asp:ListItem>
                                                    <asp:ListItem Text="Jul"></asp:ListItem>
                                                    <asp:ListItem Text="Aug" ></asp:ListItem>
                                                    <asp:ListItem Text="Sap"></asp:ListItem>
                                                    <asp:ListItem Text="Oct"></asp:ListItem>
                                                    <asp:ListItem Text="Nov" ></asp:ListItem>
                                                    <asp:ListItem Text="Dec"></asp:ListItem>
                                                </asp:DropDownList>
                                                   
                                                </td>
                                                <td class="frm-lft-clr123">To Date
                                                </td>
                                                <td class="frm-rght-clr123">
                                                   <asp:TextBox 
                                                     ID="txt_todate" 
                                                     runat="server" 
                                                     CssClass="span10" 
                                                     onkeypress="return enterdate(event);" 
                                                     onkeydown="return enterdate(event);">
                                                 </asp:TextBox>
                                                     <asp:Image 
                                                        ID="Image1" 
                                                        runat="server" 
                                                        ImageUrl="~/img/clndr.gif" 
                                                        ToolTip="click to open calender" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txt_todate" Enabled="True" Format="dd MMM yyyy">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">From Date:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                   <asp:TextBox 
                                                     ID="txt_fromdate" 
                                                     runat="server" 
                                                     CssClass="span10" 
                                                     onkeypress="return enterdate(event);" 
                                                     onkeydown="return enterdate(event);">
                                                 </asp:TextBox>
                                                    <asp:Image 
                                                        ID="Image2" 
                                                        runat="server" 
                                                        ImageUrl="~/img/clndr.gif" 
                                                        ToolTip="click to open calender" />
                                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                        TargetControlID="txt_fromdate" Enabled="True" Format="dd MMM yyyy">
                                                    </cc1:CalendarExtender>  
                                                </td>
                                                <td class="frm-lft-clr123">Time/Venue of Training:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                      <input type="Text"
                                                    id="txt_time_of_training"
                                                    runat="server"
                                                    CssClass="span10"/>
                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Source:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                           <asp:RadioButton ID="rd_internal" runat="server" Text="Internal" AutoPostBack="True" GroupName="ab"/>

                                                           <asp:RadioButton ID="rd_external" runat="server" Text="External" AutoPostBack="True" GroupName="ab"/>
                                                       <%-- ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>--%>
                                                </td>
                                                <td class="frm-lft-clr123">Organisation:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                       <input type="text"
                                                    id="txt_organisation"
                                                    runat="server"
                                                   CssClass="span10" />

                                                </td>
                                            </tr>

                                            <tr>
                                                <td class="frm-lft-clr123">Faculty:
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input type="Text"
                                                    id="txt_faculty"
                                                    runat="server"
                                                     CssClass="span10" />
                                                    <td class="frm-lft-clr123 border-bottom">Cost of Training:
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                   <input type="text"
                                                    id="txt_cost_of_training"
                                                    runat="server"
                                                    CssClass="span10" />    
                                                </td>
                                                 
                                                  
                                                </td>

                                                
                                            </tr>

                                            <tr>
                                              <td class="frm-lft-clr123 border-bottom">Total No of Participents:
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <input type="text"
                                                    id="txt_total_noof_participents"
                                                    runat="server"
                                                    CssClass="span10" />
                                                </td>
                                                
                                                 <td class="frm-lft-clr123 border-bottom"> Cost of training per head:
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                 <input type="text"
                                                    id="txt_cost_of_training_perhead"
                                                    runat="server"
                                                    CssClass="span10" />
                                                </td>
                                            </tr>

                                            <tr>   
                                                <td class="frm-lft-clr123">No of Hours: (if required)
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <input type="Text"
                                                    id="txt_noofhours"
                                                    runat="server"
                                                    CssClass="span10"/>
                                                </td>                                                                               
                                            </tr>  
                                         </tbody>  
                                      </table> 
                                   </div>
                                </div>
                             </div>       
                        
                                    <table class="table table-condensed table-striped  table-bordered pull-left">

                                        <tr>
                                             <td width="50%">                                                
                                                 Select Training Effectiveness To Be Conducted:</td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_training_effectiveness_yes" runat="server" Text="Yes" GroupName="te" AutoPostBack="True" Checked="true"/>
                                                 </td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_training_effectiveness_no" runat="server" Text="No" GroupName="te" AutoPostBack="True"/>
                                                </td>
                                         </tr>

                                        <tr>
                                             <td width="25%">
                                                Select Training Feedback To Be Conducted:
                                                </td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_training_feedback_yes" runat="server" Text="Yes" GroupName="tf" AutoPostBack="True"  />
                                                 </td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_training_feedback_no" runat="server" Text="No" GroupName="tf" AutoPostBack="True" />
                                                </td>
                                        </tr>

                                        <tr>
                                             <td width="25%">
                                                 Select participants Action plan:
                                             </td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_participants_action_yes" runat="server" Text="Yes" GroupName="pa" AutoPostBack="True"/>
                                                </td>
                                             <td width="25%">
                                                 <asp:RadioButton ID="rd_participants_action_no" runat="server" Text="No" GroupName="pa" AutoPostBack="True" />
                                               </td>
                                        </tr>

                                        <tr>
                                            <td width="25%">Programe:
                                            </td>
                                            <td width="25%">
                                                <%--   <asp:RadioButton ID="RadioButton1" runat="server" Text="Yes" GroupName="pa" AutoPostBack="True"/>--%>
                                                <asp:RadioButton ID="programe_yes" runat="server" Text="Yes" GroupName="pr" AutoPostBack="true" />    
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButton ID="programe_no" runat="server" Text="No" GroupName="pr" AutoPostBack="true" />
                                       </td>

                                       <tr>
                                            <td width="25%">Faculty Description
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButton ID="facultydescription_yes" runat="server" Text="Yes" GroupName="fd" AutoPostBack="true" />
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButton ID="facultydescription_no" runat="server" Text="No" GroupName="fd" AutoPostBack="true" />
                                            </td>
                                        </tr>

                                      <tr>
                                            <td width="25%">Any Other
                                            </td>
                                            <td width="25%">                                              
                                                <asp:RadioButton ID="anyother_yes" runat="server" Text="Yes" GroupName="ao" AutoPostBack="true" />
                                            </td>
                                            <td width="25%">
                                                <asp:RadioButton ID="anyother_no" runat="server" Text="No" GroupName="ao" AutoPostBack="true" />
                                            </td>
                                        </tr>
                                        </tr>
                                       
                                   </table>

                        <div class="form-actions no-margin">
                            <asp:Button ID="btnsv" OnClick="btnsv_Click1" runat="server" Text="Save" CssClass="btn btn-info pull-right"></asp:Button>
                        </div>
              
                 
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>

</body>
</html>


