<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEmpFeedbackForm.aspx.cs" Inherits="InformationCenter_ViewEmpFeedbackForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
    
    
    <html xmlns="http://www.w3.org/1999/xhtml">
      <head id="Head1" runat="server"><meta charset="utf-8"><title>SmartDrive Labs</title>

        <script src="../js/html5-trunk.js"></script>
        <link href="../icomoon/style.css" rel="stylesheet">
        <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
          <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>

        <!-- NVD graphs css -->
        <link href="../css@vd-charts.css" rel="stylesheet">

        <!-- Bootstrap css -->
        <link href="../css/main.css" rel="stylesheet"/>

        <!-- fullcalendar css -->
        <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
        <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    </head>
    <body>
        <form id="myForm" runat="server" class="form-horizontal no-margin">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                         <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1"
                    DisplayAfter="1">
                    <ProgressTemplate>
                        <div class="divajax">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../images/loading.gif" />
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                        <div class="main-container">
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>MACTAY</h2>
                                </div>
                                <div class="clearfix"></div>
                            </div>
                             <div class="widget">
                            <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Satisfaction Survey
                 
                                        </div>
                                    </div>
                             <div>
                                <table class="table table-condensed table-striped  table-bordered pull-left">
                                    
                                    <tr>
                                        <td class="frm-lft-clr123" width="19%">Year  <span class="star"></span></td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="drp_year" runat="server" AutoPostBack="True" CssClass="blue1" Width="109px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" tooltip="Select Year" runat="server" ControlToValidate="drp_year" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123" width="19%">Term <span class="star"></span></td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="drphalfyear" runat="server" CssClass="blue1" Width="109px">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="First Half">First Half </asp:ListItem>
                                                <asp:ListItem Value="Selecond Half ">Second Half </asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" tooltip="Select Term" runat="server" ControlToValidate="drphalfyear" ErrorMessage="&lt;img src=&quot;../images/error1.gif&quot; alt=&quot;&quot; /&gt;" InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="19%">&nbsp; </td>
                                        <td class="frm-rght-clr123 border-bottom" width="19%">
                                            <asp:Button ID="btn_submit" runat="server" CssClass="btn btn-primary" OnClick="btn_submit_Click" Text="Submit" />
                                        </td>
                                    </tr>
                                    
                                 </table>
                             </div>
                            </div> 
                               <div class="widget">
                                   <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee Satisfaction Survey Repository
                                        </div>
                                    </div>
                            <div class="widget-content">
                                    <asp:GridView ID="suggestionsgrid" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="sno" BorderWidth="0px" CellPadding="4" AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found"
                                        ToolTip="Read Feedback" CssClass="table table-hover table-striped table-bordered table-highlight-head" OnPageIndexChanging="suggestionsgrid_PageIndexChanging">
                                        <%--   OnRowDeleting="suggestions_RowDeleting" OnRowCancelingEdit="suggestions_RowCancelingEdit" OnRowEditing="suggestions_RowEditing" 
          OnRowUpdating="suggestions_RowUpdating"  --%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="Empcode">
                                                <ItemTemplate>
                                                    <a href="ShowEmpFeedbackForm.aspx?sno=<%#DataBinder.Eval(Container.DataItem, "sno")%>"
                                                        target="_self" class="link05">
                                                        <%#DataBinder.Eval(Container.DataItem, "empcode")%></a>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Overall Satisfaction">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "overallsatisfaction")%>
                                                </ItemTemplate>
                                                <%--  <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Feel of Validate Trimedx">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "IfeelIamvaluedatTriMedx")%>
                                                </ItemTemplate>
                                                <%--<ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>

                                                    <%#DataBinder.Eval(Container.DataItem, "createddate")%>
                                                </ItemTemplate>
                                                <%-- <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <HeaderStyle CssClass="frm-lft-clr123" />--%>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Status">
       <ItemStyle Width="12%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <%#DataBinder.Eval(Container.DataItem, "status")%>
       </ItemTemplate>
       <EditItemTemplate>
       <asp:DropDownList id="ddlapprovalstatus" runat="server" Width="95px" SelectedValue='<%#Bind("status1")%>' CssClass="blue1" Height="20px">
       <asp:ListItem Value="0">Not Approved</asp:ListItem>
       <asp:ListItem Value="1">Approved</asp:ListItem></asp:DropDownList>
       </EditItemTemplate>
        <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                            <%--                                        <asp:TemplateField HeaderText="Posted Date">
                                            <ItemTemplate>
                                                <%#DataBinder.Eval(Container.DataItem, "posteddate")%>
                                            </ItemTemplate>
                                            <ItemStyle Width="20%" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                            <HeaderStyle CssClass="frm-lft-clr123" />
                                        </asp:TemplateField>--%>
                                            <%--<asp:TemplateField>                                                
       <EditItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to update this entry?')" CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel" CssClass="link05" Text="Cancel" ToolTip="Cancel" />
       </EditItemTemplate>
                                                  
       <ItemStyle Width="11%" VerticalAlign="Top" CssClass="frm-rght-clr1234"/>
       <ItemTemplate>
       <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" CssClass="link05" Text="Edit" ToolTip="Edit" /> | 
       <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />
       </ItemTemplate>                                                       
           <HeaderStyle CssClass="frm-lft-clr123" />
       </asp:TemplateField>--%>
                                        </Columns>
                                        <%--<HeaderStyle HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-lft-clr123"></HeaderStyle>--%>
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <EmptyDataRowStyle CssClass="head" HorizontalAlign="Left" />
                                        <PagerStyle CssClass="frm-lft-clr123" />
                                    </asp:GridView>
                                </div>
                        </div> 
                            </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </body>
</html>
