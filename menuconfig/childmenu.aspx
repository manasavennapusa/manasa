<%@ Page Language="C#" AutoEventWireup="true" CodeFile="childmenu.aspx.cs" Inherits="menuconfig_childmenu" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8" content="" />
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
                                <h2> Child Menu</h2>
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
                                            <label class="control-label">Parent Menu Name<span class="star">*</span></label>
                                            <div class="controls">

                                                <asp:DropDownList ID="ddlParentMenu" runat="server" CssClass="span4" AutoPostBack="true" OnSelectedIndexChanged="ddlParentMenu_OnSelectedIndexChanged" ToolTip="Parent Menu" DataSourceID="SqlDataSource1" DataTextField="menudesc" DataValueField="menucode">
                                                    <asp:ListItem Value="0" Text="--Select--"></asp:ListItem>
                                                </asp:DropDownList>
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlParentMenu"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Parent Menu Name" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Child Menu Name<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtChildMenu" type="text" runat="server" class="span4" maxlength="50" title="Child Menu Name" >
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtChildMenu"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Child Menu Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">File Path<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtFileName" type="text" runat="server" class="span4" maxlength="50" title="File Path" >
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFileName"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter File Path" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Child Menu Order<span class="star">*</span></label>
                                            <div class="controls">
                                                <input id="txtchildmenuorder" type="text" runat="server" class="span4" maxlength="50"  title="Child Menu Name" onkeypress="return IsNumeric(event);">
                                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtchildmenuorder"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Child Menu Order" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">Module<span class="star">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlModule" runat="server" class="span4" DataSourceID="SqlDataSource2"
                                                    DataTextField="modulename" DataValueField="modulecode">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlModule"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Module" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="c" OnClick="btnSubmit_Click" />
                                          <%--  <button type="button" class="btn">Cancel</button>--%>
                                            <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Reset" ValidationGroup="" OnClick="btncancel_Click1" />
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

                                            <asp:GridView ID="gvChildMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="menucode"
                                                 CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="gvChildMenu_PreRender">
                                                <Columns>

                                                    <asp:TemplateField HeaderText="Child Menu Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menudesc")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditChildMenuName"  Width="160px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "menudesc")%>'
                                                                MaxLength="50"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Child Menu Code">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menucode")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="File Path">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "filepath")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditFilePath"  Width="160px" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "filepath")%>'
                                                                MaxLength="100"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Child Menu Order">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menu_order")%>
                                                        </ItemTemplate>
                                                        <EditItemTemplate>
                                                            <asp:TextBox ID="txtEditOrder"  Width="80px"  onkeypress="return IsNumeric(event);" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "menu_order")%>'
                                                                MaxLength="100"></asp:TextBox>
                                                        </EditItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Module">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "modulename")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="Edit" CausesValidation="false"
                                                                Text="&lt;img src='images/edit.png'/&gt;" ></asp:LinkButton>
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

                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="select '0' as modulecode,'--Select--' as modulename union select modulecode,modulename from module"
            SelectCommandType="Text" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="select '0' as menucode,'--Select--' as menudesc union select menucode,menudesc from menumaster where pmenucode is null"
            SelectCommandType="Text" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>

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
                $('#gvChildMenu').dataTable({
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
            function validate() {

                var parentmenu = $('#ddlParentMenu').val();
                var childmenu = $('#txtChildMenu').val();
                var filename = $('#txtFileName').val();
                var module = $('#ddlModule').val();

                var regParentMenu = document.getElementById('txtChildMenu').pattern;

                if (parentmenu == '0') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#ddlParentMenu').focus();
                    alert('Please select parent menu.');
                    return false;
                }
                if (childmenu == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtChildMenu').focus();
                    // alert('Please enter child menu name.');
                    return false;
                }

                if (!document.getElementById('txtChildMenu').value.match(regParentMenu)) {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtChildMenu').focus();
                    return false;
                }

                if (filename == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtFileName').focus();
                    //   alert('Please enter file name.');
                    return false;
                }
                if (module == '0') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#ddlModule').focus();
                    alert('Please select the module.');
                    return false;
                }

            }
        </script>

    </form>

</body>
</html>
