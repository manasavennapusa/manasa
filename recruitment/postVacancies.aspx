<%@ Page Language="C#" AutoEventWireup="true" CodeFile="postVacancies.aspx.cs" Inherits="recruitment_postVacancies" %>

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
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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


    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>

    <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
        .center
        {
            position: absolute;
            top: 448px;
            left: 500px;
        }
    </style>
     <%--<style type="text/css">
           .star {
            color: red;
        }
      </style>--%>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <%--<div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="../img/loading.gif" />"
                                    Please Wait...
                                </div>
                            </div>--%>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <%--<h2>CRITERIA FOR FORWARDING RRFS</h2>--%>
                                <h2>Consultancies And Employee Referrals</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" runat="server" visible="true">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <%--<asp:Label ID="lblheader" runat="server" Text="CRITERIA FOR FORWARDING RRFS"></asp:Label>--%>
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    From Date
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_fromdate" runat="server" CssClass="span10"></asp:TextBox>&#160;
                                                     <asp:Image ID="Image4" runat="server" ImageUrl="~/images/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Image4"
                                                        TargetControlID="txt_fromdate" Enabled="True" Format="MM/dd/yyyy">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Location Of Vacancy
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_location" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Raiser Of Vacancy                                         
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_raiser" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    To Date
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_todate" runat="server" CssClass="span10"></asp:TextBox>&#160;
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txt_todate" Enabled="True" Format="MM/dd/yyyy">
                                                    </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Department Of Vacancy
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="form-actions no-margin" style="text-align: right">
                                            <asp:Button ID="btn_Sumbit" runat="server" Text="Search" CssClass="btn btn-info" OnClick="btn_Sumbit_Click" />&nbsp;&nbsp;&nbsp;
                                            <asp:Button ID="btn_clear" runat="server" Text="Reset" CssClass="btn btn-info" OnClick="btn_clear_Click" />
                                        </div>
                                    </div>

                                </div>
                            </div>

                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>RRF List--%>     
                                           <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdRRF" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                EmptyDataText="No data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("id") %>' />
                                                            <asp:HiddenField ID="hfrrfcode" runat="server" Value='<%# Eval("rrf_code") %>' />
                                                            <asp:CheckBox ID="chkselect" runat="server" />
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="8%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText=" Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Designation">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No Of Posts">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requested By">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Requisition Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                       <asp:TemplateField HeaderText="RRF Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle CssClass="frm-lft-clr123" Width="15%" />
                                                        <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" View">
                                                        <ItemTemplate>
                                                            <%--<a href='ConsultancyRequisitionform.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>--%>
                                                            <a href='ConsultancyRequisitionform.aspx?id=<%# Eval("id") %>' class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <%--<asp:Label ID="Label1" runat="server" Text="Select Employees and Consultancies"></asp:Label>--%>
                                            <asp:Label ID="Label1" runat="server" Text="Select"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">
                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Select Employees<span class="star"></span>
                                                    </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="span9" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:HiddenField ID="hidd_empcode" runat="server" />
                                                    &nbsp;
                                            <a href="JavaScript:newPopup1('pickrecruiter.aspx');" class="btn btn-info">Select</a>  <%--class="link05"--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_employee"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip=" Please Select Employee"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label" style="text-align:center">
                                                    Select JobSite/Consultancies<span class="star"></span>
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txtjobconsult" runat="server" CssClass="span9" TextMode="MultiLine"></asp:TextBox>
                                                    
                                                    <asp:HiddenField ID="hfid" runat="server" />
                                                    &nbsp;
                                            <a href="JavaScript:newPopup1('viewConsultancies_jobsites.aspx');" class="btn btn-info">Select</a>  <%--class="link05"--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtjobconsult"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Please Select Consultancies"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="form-actions no-margin" style="text-align:right">
                                            <asp:Button ID="btnsend" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnsend_Click" ValidationGroup="rrf" />
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-info" style="margin-left:20px" OnClick="btnReset_Click" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </form>

    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->

    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/analytics.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdRRF').dataTable({
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
        })(window, document, 'script', '../js/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>
</body>
</html>
