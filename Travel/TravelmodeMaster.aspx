<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TravelmodeMaster.aspx.cs" Inherits="Travel_TravelmodeMaster" %>

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
                                <span class="fs1" id="create1" runat="server"  ><h2>Create Travel Mode Master</h2></span>
                                <span class="fs1" id="edit1" runat="server"  ><h2>Edit Travel Mode Master</h2></span>
                            </div>
                            
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" id="create" runat="server" aria-hidden="true" data-icon="&#xe023;">Create Travel Mode Master</span>
                                            <span class="fs1" id="edit" runat="server" aria-hidden="true" data-icon="&#xe023;">Edit Travel Mode Master</span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">Travel Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_traveltype" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                        <asp:ListItem Value="I">International</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_traveltype" ToolTip="Select Travel Type" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Travel Mode</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtravelname" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isCharOrSpacedash()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtravelname"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Travel Mode" ValidationGroup="c"
                                                        Width="6px" ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtravelname"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s\-]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdesc" runat="server" CssClass="span4" MaxLength="100" TextMode="MultiLine"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtdesc"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\.\,\s]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btntier" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="c" OnClick="btntier_Click" />
                                                <asp:Button ID="btnupdate" runat="server" CssClass="btn btn-primary" Text="Update" ValidationGroup="c" OnClick="btnupdate_Click" />
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Travel Mode Master               
                                           
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="grdtravel" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data Exists" DataKeyNames="travelmodeId" OnRowDeleting="grdtravel_RowDeleting" OnPreRender="grdtravel_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Travel Mode Id" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltravelmodeid" runat="server" Text='<%#Eval("travelmodeId")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Mode" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltravelname" runat="server" Text='<%#Eval("travelmode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                      <asp:TemplateField HeaderText="Travel Type" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraveltype" runat="server" Text='<%#Eval("traveltype").ToString().Trim()=="I"?"International":"Domestic"%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Description" HeaderStyle-Width="25%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldescrition" runat="server" Text='<%#Eval("descripetion")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="travelmodeId" DataNavigateUrlFormatString="~/Travel/TravelmodeMaster.aspx?Id={0}"
                                                        Text="&lt;img src='images/edit.png'/&gt;">
                                                        <ControlStyle CssClass="link05" />
                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%">
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
                $('#grdtravel').dataTable({
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
