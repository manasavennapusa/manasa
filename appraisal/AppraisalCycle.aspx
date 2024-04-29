<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AppraisalCycle.aspx.cs" Inherits="appraisal_AppraisalCycle" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server" >
<title>SmartDrive Labs</title>
<meta charset="utf-8" />

<script src="../js/html5-trunk.js"></script>
<link href="../icomoon/style.css" rel="stylesheet" />

<!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

<!-- NVD graphs css -->
<link href="../css/nvd-charts.css" rel="stylesheet" />

<!-- Bootstrap css -->
<link href="../css/main.css" rel="stylesheet" />

<!-- fullcalendar css -->
<link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
<link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

   <style type="text/css">
       .star:before {
           color: red !important;
           content: " *";
       }
   </style>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>E-Evaluation Cycle</h2>
                    </div>
                 
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <fieldset>
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                             <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">Financial Year<span class="star"></span></label>
                                                    <div class="controls">
                                                       <asp:DropDownList
                                                ID="ddlFinYear"
                                                runat="server"
                                               width="246px"
                                                AppendDataBoundItems="true">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="ddlFinYear"
                                                            ValidationGroup="v" runat="server" ToolTip="Financial Year Required" InitialValue="0"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                     </div>
                                                </div>
                                            
                                           
                                                <div class="control-group">
                                                        <label class="control-label">Quarter<span class="star"></span></label>
                                                      <div class="controls">
                                                        <asp:DropDownList ID="dd_Quater" runat="server" width="246px" AppendDataBoundItems="true" >
                                                       <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                         <asp:ListItem Value="Q1" Text="Q1"></asp:ListItem>
                                                         <asp:ListItem Value="Q2" Text="Q2"></asp:ListItem>
                                                             </asp:DropDownList>
                                                    
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="dd_Quater"
                                                            ValidationGroup="v" runat="server" ToolTip="Quarter Required" InitialValue="0" Display="Dynamic"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">From<span class="star"></span></label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddl_Fmonth" runat="server" CssClass="span2">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldor4" ControlToValidate="ddl_Fmonth"
                                                            ValidationGroup="v" runat="server" ToolTip="From Month Required" InitialValue="0"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                
                                                        <asp:DropDownList ID="ddl_From_Year" runat="server" CssClass="span2" OnSelectedIndexChanged="ddl_From_Year_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="ddl_From_Year"
                                                            ValidationGroup="v" runat="server" ToolTip="From Year Required" InitialValue="0"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="control-group">
                                                    <label class="control-label">To<span class="star"></span></label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddl_Tmonth" runat="server" CssClass="span2">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddl_Tmonth"
                                                            ValidationGroup="v" runat="server" ToolTip="To Month Required" InitialValue="0"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                   
                                                        <asp:DropDownList ID="ddl_To_Year" runat="server" CssClass="span2" AutoPostBack="true" OnSelectedIndexChanged="ddl_To_Year_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                       <%-- <asp:CompareValidator ID="CompareValidator16" runat="server" ControlToCompare="ddl_From_Year"
                                                            ControlToValidate="ddl_To_Year" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                            Operator="GreaterThanEqual" SetFocusOnError="True" Type="Integer" ToolTip="Invalid Year"
                                                            ValidationGroup="v" Display="Dynamic"></asp:CompareValidator>--%>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="ddl_To_Year"
                                                            ValidationGroup="v" runat="server" ToolTip="To Year Required" InitialValue="0" Display="Dynamic"
                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>

                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnsubmit_Click"
                                            ValidationGroup="v" />&nbsp;
                                            <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" CausesValidation="false" />
                                    </div>
                                </fieldset>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid" id="abc" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">

                                    <asp:GridView ID="gridappcycle" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="appcycle_id" OnPreRender="gridappcycle_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left" OnDataBound="gridappcycle_DataBound" OnRowDeleting="gridappcycle_RowDeleting" OnPageIndexChanging="gridappcycle_PageIndexChanging">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Financial Year">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "APP_year")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="From">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "from_month")%>
                                                    <%#DataBinder.Eval(Container.DataItem, "from_year")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="To">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "to_month")%>
                                                    <%#DataBinder.Eval(Container.DataItem, "to_year")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Quarter">
                                                <ItemTemplate>
                                                     <%#DataBinder.Eval(Container.DataItem, "quater")%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("freeze").ToString()=="True"?"Freezed":Eval("status").ToString()=="True"?"Active":"Not Active" %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mark Active">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgDeleteButton" CausesValidation="False" ToolTip='<%#Eval("status").ToString()=="True"?"":"Mark Active" %>' CommandName="Delete" runat="server" ImageUrl='<%#Eval("status").ToString()=="True"?"../images/10.png":"../images/mark.png" %>' OnClientClick="return confirm('Are You Sure To Active This Cycle?')" Visible='<%#Eval("freeze").ToString()=="True"?false:true %>'></asp:ImageButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Freeze">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkEdit" runat="server" OnCommand="lnkEdit_Command" class="btn btn-primary" CommandArgument='<%#Eval("appcycle_id") %>' Text="Freeze" Visible='<%#Eval("freeze").ToString()=="True"?false:true %>' OnClientClick="return confirm('Are You Sure To Freeze This Cycle?')"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="20%"  >
                                                <ItemTemplate>
                                                    <a href="AppraisalCycle.aspx?sno=<%# Eval("appcycle_id")%>" <%#Eval("freeze").ToString()=="True"?"none":"block" %>"><img src="../images/edit.png" width="16" height="16" border="0"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="clearfix"></div> <%--CssClass="link05"--%><%--class="link05"--%><%--style="display:--%>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>


        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gridappcycle').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>



        <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>
    </form>
</body>
</html>
