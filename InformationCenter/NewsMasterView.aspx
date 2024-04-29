<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewsMasterView.aspx.cs" Inherits="InformationCenter_NewsMasterView" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>MacTay</title>
    <style type="text/css">
        .star:before {
            color: red !important;
            content: " *";
        }
    </style>
    <style type="text/css" media="all">
        @import "css/blue.css";
        @import "css/home.css";
    </style>

    <link href="js/A.bootstrap.min.css.pagespeed.cf.oYSzO0tvx-.css" rel="stylesheet" />
    <link href="css/blue1.css" rel="stylesheet" />

    <script type="text/javascript">
        function WatermarkFocus(txtElem, strWatermark) {
            if (txtElem.value == strWatermark)
                txtElem.value = '';
        }
        function WatermarkBlur(txtElem, strWatermark) {
            if (txtElem.value == '')
                txtElem.value = strWatermark;
        }
    </script>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>
<body>
    <%--<form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

                <ContentTemplate>

                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>News Master</h2>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row-fluid">
                            <div class="widget">
                                <%--<div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search                
                                    </div>
                                </div>--%
                                <%-- <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <a href="NewsMasterView.aspx" class="link-red1">Today's News</a> &nbsp;l&nbsp;
                    <a href="NewsMasterView.aspx?news=1" class="link-red1">Date Wise News</a>&nbsp;l&nbsp;
                    <a href="NewsMasterView.aspx?news=2" class="link-red1">Priority Wise News</a> &nbsp;&nbsp;<asp:TextBox
                        ID="txtsearch" CssClass="blue1" Text="" runat="server" MaxLength="150" Width="241px" placeHolder="Search Your News"></asp:TextBox>
                                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />

                                        </div>

                                        <div class="control-group">
                                            <img src="../images/date-icon.gif" width="10" height="10" alt="" runat="server"
                                                id="img1" />&nbsp;
                    <asp:Label ID="lbldate" runat="server" Text=""></asp:Label>
                                        </div>



                                    </fieldset>

                                </div>--%
                            </div>
                        </div>
                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                        <div class="row-fluid">

                            <div class="widget">

                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View          
                                    </div>
                                </div>

                                <div class="control-group">
                                    <a href="NewsMasterView.aspx" class="link-red1">Today's News</a> &nbsp;l&nbsp;
                                    <a href="NewsMasterView.aspx?news=1" class="link-red1">Date Wise News</a>&nbsp;l&nbsp;
                                </div>
                                <div class="widget-content">
                                     <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="Newsgrid" runat="server" AutoGenerateColumns="False"  ShowHeader="true" Width="100%" DataKeyNames="id"
                                        EmptyDataText="No news has been posted today. Click on Datewise link to view more news" OnPreRender="Newsgrid_PreRender"
                                        ToolTip="News posted" AllowPaging="True"
                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:BoundField DataField="heading" HeaderText="Heading" HeaderStyle-Width="30%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="30%"></asp:BoundField>

                                            <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="35%"></asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>

                                <div class="widget-content">
                                     <div id="dt_example1" class="example_alt_pagination">
                                    <asp:GridView ID="newsdatewise" runat="server" AutoGenerateColumns="False"  ShowHeader="true" Width="100%"
                                        EmptyDataText="No news has been posted" ToolTip="News posted" AllowPaging="True" DataKeyNames="id" OnPreRender="newsdatewise_PreRender"
                                        CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:BoundField DataField="heading" HeaderText="Heading" HeaderStyle-Width="30%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="30%"></asp:BoundField>

                                            <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="35%"></asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>

                               <%-- <div class="widget-content" >
                                    <asp:GridView ID="priority" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%"
                                        EmptyDataText="No news has been posted in priority category" ToolTip="News posted" DataKeyNames="id" OnPreRender="priority_PreRender"
                                        AllowPaging="True" OnPageIndexChanging="priority_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:BoundField DataField="heading" HeaderText="Heading" HeaderStyle-Width="30%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="30%"></asp:BoundField>

                                            <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="35%"></asp:BoundField>
                                        </Columns>
                                        <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                    </asp:GridView>
                                </div>--%

                                <div class="widget-content">
                                    <asp:GridView ID="searchgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                        CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="true" Width="100%"
                                        EmptyDataText="No news has been found" ToolTip="News posted" AllowPaging="True"
                                        OnPageIndexChanging="searchgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:BoundField DataField="heading" HeaderText="Heading" HeaderStyle-Width="30%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="30%"></asp:BoundField>

                                            <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="35%"></asp:BoundField>



                                        </Columns>

                                    </asp:GridView>
                                </div>


                                <td colspan="2" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                        <tr>
                                            <td width="14%" class="txt01">Select Category
                                            </td>
                                            <td width="40%">
                                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="blue1" ToolTip="Select Type">
                                                    <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Employee"></asp:ListItem>

                                                </asp:DropDownList>
                                            </td>
                                            <td width="68%">
                                                <asp:Button ID="btngo" runat="server" Text="Go" OnClick="btngo_Click"
                                                    CssClass="btn btn-primary" />
                                                <span id="Span4" runat="server" enableviewstate="false" class="txt02"></span>
                                            </td>
                                        </tr>
                                    </table>
                                </td>

                            </div>
                        </div>
                </ContentTemplate>
                <%--  <Triggers>
                    <asp:PostBackTrigger ControlID="btnsearch" />
                </Triggers>--%
            </asp:UpdatePanel>

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
                $('#Newsgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

          <script type="text/javascript">
              //Data Tables
              $(document).ready(function () {
                  $('#newsdatewise').dataTable({
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


    </form>--%>



     <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Buzz</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                 
                                </div>
                            </div>

                            <div class="control-group">
                                    <a href="NewsMasterView.aspx" class="link-red1" >Today's Buzz</a> &nbsp;l&nbsp;
                                    <a href="NewsMasterView.aspx?news=1" class="link-red1" >Date Wise Buzz</a>&nbsp;&nbsp;
                                </div>

                            <div class="widget-body">

                                <div class="widget-content">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="Newsgrid" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%" DataKeyNames="id"
                                            EmptyDataText="No news has been posted today. Click on Datewise link to view more news" OnPreRender="Newsgrid_PreRender"
                                            ToolTip="News posted" AllowPaging="True"
                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:BoundField DataField="heading" HeaderText="Heading" ></asp:BoundField>
                                                <asp:BoundField DataField="description" HeaderText="Description"></asp:BoundField>

                                                <asp:BoundField DataField="postedby" HeaderText="Posted By"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Uploads">
                                                    <ItemTemplate>

                                                        <a href="../InformationCenter/upload/<%#DataBinder.Eval(Container.DataItem,"Upload")%>"
                                                            target="_blank">Download News Buzz</a>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>
                                </div>

                                <div class="widget-content">
                                    <div id="dt_example1" class="example_alt_pagination">
                                        <asp:GridView ID="newsdatewise" runat="server" AutoGenerateColumns="False" ShowHeader="true" Width="100%"
                                            EmptyDataText="No news has been posted" ToolTip="News posted" AllowPaging="True" DataKeyNames="id" OnPreRender="newsdatewise_PreRender"
                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                            <Columns>
                                                <asp:BoundField DataField="heading" HeaderText="Heading"></asp:BoundField>
                                                <asp:BoundField DataField="description" HeaderText="Description"></asp:BoundField>

                                                <asp:BoundField DataField="postedby" HeaderText="Posted By"></asp:BoundField>
                                                 <asp:TemplateField HeaderText="Uploads">
                                                    <ItemTemplate>

                                                        <a href="../InformationCenter/upload/<%#DataBinder.Eval(Container.DataItem,"Upload")%>"
                                                            target="_blank">Download News Buzz</a>

                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                            <PagerStyle CssClass="paging" HorizontalAlign="Center" />
                                        </asp:GridView>
                                    </div>


                                    <div class="clearfix"></div>
                                </div>

                                <div class="widget-content">
                                    <asp:GridView ID="searchgrid" runat="server" AutoGenerateColumns="False" CellPadding="2"
                                        CellSpacing="0" GridLines="None" PageSize="5" ShowHeader="true" Width="100%"
                                        EmptyDataText="No news has been found" ToolTip="News posted" AllowPaging="True"
                                        OnPageIndexChanging="searchgrid_PageIndexChanging" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                        <Columns>
                                            <asp:BoundField DataField="heading" HeaderText="Heading" HeaderStyle-Width="30%"></asp:BoundField>
                                            <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-Width="30%"></asp:BoundField>

                                            <asp:BoundField DataField="postedby" HeaderText="Posted By" HeaderStyle-Width="35%"></asp:BoundField>



                                        </Columns>

                                    </asp:GridView>
                                </div>

                                </br>
                                </br>

                                   <td colspan="2" valign="top">
                                       <table width="100%" border="0" cellspacing="0" cellpadding="2">
                                           <tr>
                                               <td width="14%" class="txt01">Select Category
                                               </td>
                                               <td width="40%">
                                                   <asp:DropDownList ID="ddlcategory" runat="server" CssClass="blue1" ToolTip="Select Type">
                                                       <asp:ListItem Value="0" Text="--Select Type--"></asp:ListItem>
                                                       <asp:ListItem Value="1" Text="General"></asp:ListItem>
                                                       <asp:ListItem Value="2" Text="Employee"></asp:ListItem>

                                                   </asp:DropDownList>
                                               </td>
                                               <td width="68%">
                                                   <asp:Button ID="btngo" runat="server" Text="Go" OnClick="btngo_Click"
                                                       CssClass="btn btn-primary" />
                                                   <span id="Span4" runat="server" enableviewstate="false" class="txt02"></span>
                                               </td>
                                           </tr>
                                       </table>
                                   </td>
                            </div>
                    </div>
                    
                </div>
                <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT tbl_internate_departmentdetails.departmentid, tbl_internate_departmentdetails.department_name,tbl_internate_departmentdetails.department_code, tbl_internate_departmentdetails.estt_date, tbl_intranet_branch_detail.branch_name FROM tbl_intranet_branch_detail INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_branch_detail.Branch_Id = tbl_internate_departmentdetails.branchid"
                    DeleteCommand="DELETE FROM tbl_internate_departmentdetails WHERE departmentid = @departmentid" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>--%>

            </div>
            <span id="message" runat="server"></span>
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
                $('#Newsgrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>


          <script type="text/javascript">
              //Data Tables
              $(document).ready(function () {
                  $('#newsdatewise').dataTable({
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
