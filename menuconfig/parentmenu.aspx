<%@ Page Language="C#" AutoEventWireup="true" CodeFile="parentmenu.aspx.cs" Inherits="menuconfig_parentmenu" %>

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
<head>
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
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
        .star 
        {
            color:red;
        }
    </style>


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
                                <h2>Parent Menu</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Create
                 
                                    </div>
                                </div>
                                <div class="widget-body">

                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label" style="float: left">Module<span class="star">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlModule" runat="server" class="span4" DataSourceID="SqlDataSource2" OnSelectedIndexChanged="ddlModule_SelectedIndexChanged" AutoPostBack="true"
                                                    DataTextField="modulename" DataValueField="modulecode">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                      </asp:DropDownList>                                                   
                                                   
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlModule"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Module" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                              
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Parent Menu Name<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtParentMenu" type="text" runat="server" class="span4" maxlength="50"  title="Parent menu"/><%--pattern="^[a-zA-Z ]*$"--%>
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtParentMenu"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Parent Menu Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Parent Order<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtParentorder" type="text" runat="server" class="span4" maxlength="5" title="Parent menu"  onkeypress="return IsNumeric(event);" />
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtParentorder"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Parent Order" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit"  OnClick="btnsv_Click" ValidationGroup="c" /><%--OnClientClick="return validate()" --%>
                                             <asp:Button ID="btncancle" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btncancle_Click" ValidationGroup="" />
                                           <%-- <button type="button" class="btn">Cancel</button>--%>
                                        </div>
                                    </fieldset>

                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View                                    
                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="gvParentMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="menucode"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="gvParentMenu_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Parent Menu Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menudesc")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditParentMenuName" runat="server"  Width="160px"    Text='<%# DataBinder.Eval(Container.DataItem, "menudesc")%>'
                                                                MaxLength="50"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Parent Menu Code">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menucode")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Module">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "modulename")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Menu Order">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menu_order")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditParentorder" Width="80px" onkeypress="return IsNumeric(event);" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "menu_order")%>'
                                                                MaxLength="50"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CausesValidation="false" 
                                                                 Text="&lt;img src='images/edit.png'/&gt;"></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                           
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CausesValidation="false" CssClass="btn btn-primary btn-small hidden-phone"
                                                                Text="Update"></asp:LinkButton>
                                                             <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CausesValidation="false" CssClass="btn btn-primary btn-small hidden-phone"
                                                                Text="Cancel"></asp:LinkButton>

                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                         <ItemTemplate>
                                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are You Sure? You Want To Delete');"
                                                                Text="&lt;img src='images/delete.png'/&gt;" ></asp:LinkButton>
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

                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="select '0' as modulecode,'--Select--' as modulename union select modulecode,modulename from module"
                            SelectCommandType="Text" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/moment.js" type="text/javascript"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js" type="text/javascript"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js" type="text/javascript"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js" type="text/javascript"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js" type="text/javascript"></script>
        <script src="../js/custom.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gvParentMenu').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>



        <script type="text/javascript">
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>

        <script type="text/javascript">
            function IsNumeric(eventObj) {

                var keycode;

                if (eventObj.keyCode) //For IE
                    keycode = eventObj.keyCode;
                else if (eventObj.Which)
                    keycode = eventObj.Which;  // For FireFox
                else
                    keycode = eventObj.charCode; // Other Browser

                if (keycode != 8) //if the key is the backspace key
                {
                    if (keycode < 48 || keycode > 57) //if not a number
                        return false; // disable key press
                    else
                        return true; // enable key press
                }
            }

            function isAlpha(keyCode) {

                return ((keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9)

            }

            function isAddress(keyCode) {

                return ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 90) || keyCode == 8 || keyCode == 32 || keyCode == 190 || keyCode == 9 || keyCode == 13 || keyCode == 51 || keyCode == 50)
            }

            function validateEmail(obj) {
                var x = obj.value;
                if (x != '') {
                    var atpos = x.indexOf("@");
                    var dotpos = x.lastIndexOf(".");
                    if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                        obj.focus();
                        alert("Not a valid e-mail address");
                        return false;
                    }
                }
            }

            function capitalizeMe(obj) {
                val = obj.value;
                newVal = '';
                val = val.split(' ');
                for (var c = 0; c < val.length; c++) {
                    newVal += val[c].substring(0, 1).toUpperCase() + val[c].substring(1, val[c].length).toLowerCase() + ' ';
                }
                obj.value = newVal.trim();
            }

        </script>

        <script type="text/javascript">
            function validate() {

                var module = $('#txtModule').val();
                var moduledesc = $('#txtModuleDesc').val();

                var regModuleName = document.getElementById('txtModuleName').pattern;
                var regModuleDesc = document.getElementById('txtModuleDesc').pattern;


                if (module == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (!document.getElementById('txtModuleName').value.match(regModuleName)) {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (moduledesc == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModuleDesc').focus();
                    return false;
                }

            };
        </script>
    </form>

</body>
</html>
