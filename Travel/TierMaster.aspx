<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TierMaster.aspx.cs" Inherits="Travel_TierMaster" %>

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

    <%--<link href="../css/table.css" rel="stylesheet" type="text/css" />--%>
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
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
                               <span class="fs1" id="create1" runat="server" aria-hidden="true"><h2>Create Domestic Tier Master</h2></span>  
                             <span class="fs1" id="edit1" runat="server" aria-hidden="true">Edit Domestic Tier Master</span>  
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" id="create" runat="server" aria-hidden="true" data-icon="&#xe023;">Create Domestic Tier Master</span>  
                                             <span class="fs1" id="edit" runat="server" aria-hidden="true" data-icon="&#xe023;">Edit Domestic Tier Master</span>                                          
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group">
                                                <label class="control-label">Tier</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txttier" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isCharOrSpace()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txttier"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Tier" ValidationGroup="c"
                                                        Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txttier"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txttierDes" TextMode="MultiLine" MaxLength="250" runat="server" CssClass="span4" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttier"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Country" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txttierDes"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btntier" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="c" OnClick="btntier_Click" />
                            <%--btn-warning--%> <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="c" OnClick="btnupdate_Click" />
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Domestic Tier Master                
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdtiers" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                EmptyDataText="No Data Exists" OnPreRender="grdtiers_PreRender" DataKeyNames="tierID" OnRowDeleting="grdtiers_RowDeleting">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Tier Name" HeaderStyle-Width="40%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltiername" runat="server" Text='<%#Eval("tier")%>'></asp:Label>

                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tier Description" HeaderStyle-Width="40%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldescription" runat="server" Text='<%#Eval("tierdesc")%>'></asp:Label>                                                           
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="tierID" DataNavigateUrlFormatString="~/Travel/TierMaster.aspx?Id={0}"  
                                                         Text="&lt;img src='images/edit.png'/&gt;">                                                      
                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtndelete" runat="server" CssClass="link05" Text="&lt;img src='images/delete.png'/&gt;"  CommandName="Delete" OnClientClick="return confirm('Are you sure to Delete this entry?')" ></asp:LinkButton>
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
                $('#grdtiers').dataTable({
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
    </form>
</body>
</html>
