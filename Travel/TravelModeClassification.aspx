<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelModeClassification.aspx.cs" Inherits="Travel_TravelModeClassification" %>

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
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../img/loading.gif" />
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
                                <span class="fs1" id="create1" runat="server"><h2>Create Binding Master</h2></span>
                                <span class="fs1" id="edit1" runat="server" ><h2>Edit Binding Master</h2></span>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" id="create" runat="server" aria-hidden="true" data-icon="&#xe023;">Create Binding Master</span>
                                             <span class="fs1" id="edit" runat="server" aria-hidden="true" data-icon="&#xe023;">Edit Binding Master</span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group" style="display:none">
                                                <label class="control-label">Select Grade</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="drpgrade" runat="server" CssClass="span4" DataSourceID="sql_data_grade"
                                                        DataTextField="gradename" DataValueField="id" OnDataBound="drpgrade_DataBound">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator23" runat="server" ControlToValidate="drpgrade"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                        SetFocusOnError="True" ToolTip="Select Grade" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="sql_data_grade" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [gradename] FROM [tbl_intranet_grade]"></asp:SqlDataSource>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Select Tier</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddltier" runat="server" CssClass="span4" OnDataBound="ddltier_DataBound"
                                                        DataSourceID="sql_data_tier" DataTextField="tier" DataValueField="tierID">
                                                    </asp:DropDownList>
                                                    
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddltier"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="c" InitialValue="0"
                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>  

                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddltier"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                        SetFocusOnError="True" ToolTip="Select Tier" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="sql_data_tier" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [tierID], [tier] FROM [tbl_travel_Tier]"></asp:SqlDataSource>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Travel Mode</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddltravelmode" runat="server" CssClass="span4" OnDataBound="ddltravelmode_DataBound" OnSelectedIndexChanged="ddltravelmode_SelectedIndexChanged" AutoPostBack="true"
                                                        DataSourceID="sql_data_travelmode" DataTextField="travelmode" DataValueField="travelmodeId">
                                                    </asp:DropDownList>

                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddltravelmode"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="c" InitialValue="0"
                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>  

                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddltravelmode"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                        SetFocusOnError="True" ToolTip="Select Travel Mode" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="sql_data_travelmode" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT [travelmodeId], [travelmode] FROM [tbl_travel_travelmode]"></asp:SqlDataSource>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Travel Class</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddltravelmodeclass" runat="server" CssClass="span4" OnDataBound="ddltravelmodeclass_DataBound"></asp:DropDownList>
                                                    
                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddltravelmodeclass"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="c" InitialValue="0"
                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>  

                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddltravelmodeclass"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' Operator="NotEqual"
                                                        SetFocusOnError="True" ToolTip="Select Travel Class" ValidationGroup="v" ValueToCompare="0"></asp:CompareValidator>
                                                </div>
                                            </div>

                                            <div class="control-group" style="display:none">
                                                <label class="control-label">Amount</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtAmount" runat="server" CssClass="span4" Text="0"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAmount"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Amount" ValidationGroup="v"
                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtAmount"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only decimals upto 2 places"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btntier" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btntier_Click"   ValidationGroup="c"/>
                                                <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Text="Update" OnClick="btnupdate_Click" />
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btncancel_Click" />
                                                 <asp:Button ID="btncancel2" runat="server" CssClass="btn btn-primary" Text="Cancel" ValidationGroup="c" OnClick="btncancel2_Click" />
                                            </div>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="grid1" runat="server">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Binding Master 
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdtravelmodes" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="ID" OnRowDeleting="grdtravelmodes_RowDeleting" OnPreRender="grdtravelmodes_PreRender">
                                                <Columns>
                                                  <%--  <asp:TemplateField HeaderText="Grade" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltiername" runat="server" Text='<%#Eval("gradename")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Tier ID" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltier" runat="server" Text='<%#Eval("tier")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Mode" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltravelmode" runat="server" Text='<%#Eval("travelmode")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Mode Class" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltravelclass" runat="server" Text='<%#Eval("travelmodeclass")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="20%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltravelamount" runat="server" Text='<%#Eval("Amount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="~/Travel/TravelModeClassification.aspx?Id={0}"
                                                        Text="&lt;img src='images/edit.png'/&gt;" HeaderStyle-Width="5%">
                                                        <ControlStyle CssClass="link05" />
                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="5%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtndelete" runat="server" CssClass="link05" Text="&lt;img src='images/delete.png'/&gt;" CommandName="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')"></asp:LinkButton>
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
                    </div>

                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                </ContentTemplate>
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
                $('#grdtravelmodes').dataTable({
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
