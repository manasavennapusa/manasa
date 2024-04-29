<%@ Page Language="C#" AutoEventWireup="true" CodeFile="module.aspx.cs" Inherits="menuconfig_module" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
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

            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>

                        <div class="page-header">
                            <div class="pull-left">
                                <h2> Module</h2>
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
                                            <label class="control-label">Module Name<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtModule" type="text" runat="server" class="span4" title="Module name" />
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtModule"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Module Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Module Order<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtorder" type="text" runat="server" class="span4" title="Module name" onkeypress="return IsNumeric(event);" /> <%--maxlength="50" pattern="^[a-zA-Z ]*$"--%>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtorder"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Module Order" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="c" />
                                             <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btncancel_Click" ValidationGroup="" />
                                            <%--<button type="button" class="btn">Cancel</button>--%>
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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span> View 
                                    
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="Grid_Emp" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="modulecode" AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="Grid_Emp_PreRender" OnRowDeleting="Grid_Emp_RowDeleting">
                                                <Columns>
                                                    <asp:BoundField DataField="modulecode" HeaderText="Module Code" ReadOnly="True"
                                                        SortExpression="modulecode"></asp:BoundField>
                                                    <asp:BoundField DataField="modulename" HeaderText="Module Name" SortExpression="modulename"></asp:BoundField>
                                                    
                                                   <%-- <asp:TemplateField HeaderText="Module Order"  SortExpression="prorityorder">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="tb1" runat="server"
                                                        </EditItemTemplate>
                                                        
                                                    </asp:TemplateField>--%>
                                                 
                                                    <asp:TemplateField HeaderText="Module Order" SortExpression="prorityorder">
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="TextBox1" runat="server" onkeypress="return IsNumeric(event);" Text='<%# Bind("prorityorder") %>'></asp:TextBox>
                                                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic" Enabled="true"   ControlToValidate="TextBox1" ErrorMessage="Enter only digits." ForeColor="Red" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>--%>
                                                           <%-- <asp:RequiredFieldValidator ID="reeq1" runat="server" ErrorMessage="error" ForeColor="Red" Text="*" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>--%>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("prorityorder") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>


                                                    
                                                    <asp:TemplateField HeaderText="Edit">

                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" role="button"  CausesValidation="false" CommandName="Edit"   Text="&lt;img src='images/edit.png'/&gt;"></asp:LinkButton>
                                                        </ItemTemplate>                                                       
                                                        <EditItemTemplate>
                                                            <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" CssClass="btn btn-primary btn-small hidden-phone" Text="Update" OnClientClick="return confirm('Updated Successfully')" ></asp:LinkButton>
                                                            <asp:LinkButton ID="lnkCancel" runat="server" CommandName="Cancel" CssClass="btn btn-primary btn-small hidden-phone" Text="Cancel"></asp:LinkButton>
                                                           
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                         <ItemTemplate>
                                                            <asp:LinkButton ID="lnkdelete" runat="server" CommandName="Delete" CausesValidation="false" OnClientClick="return confirm('Are You Sure? You Want To Delete')"
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

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommandType="StoredProcedure" SelectCommand="getmoduledetails" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>" UpdateCommand="savemoduledetails" UpdateCommandType="StoredProcedure">
                            <UpdateParameters>
                                <asp:Parameter Name="ModuleCode" Type="Int32" />
                                <asp:Parameter Name="ModuleName" Type="String" />
                                <asp:SessionParameter Name="EmpCode" Type="String" SessionField="empcode" />
                                <asp:Parameter Name="action" Type="String" DefaultValue="Update" />
                                <asp:Parameter Name="prorityorder" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

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
                $('#Grid_Emp').dataTable({
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
