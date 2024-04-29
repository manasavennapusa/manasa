<%@ Page Language="C#" AutoEventWireup="true" CodeFile="currencymaster.aspx.cs" Inherits="admin_currencymaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Currency Master</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="tblcountry" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                            <asp:Label ID="lblhead" runat="server" Text="Currency Conversion"></asp:Label>
                                            <%--<span id="message" runat="server" class="txt-red" enableviewstate="false" style=""></span>--%>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">From Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtFromdate" runat="server" CssClass="span4" Width="" Enabled="false"></asp:TextBox>&nbsp;
                                                        <asp:Image ID="Image12" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtenderfrom" runat="server" PopupButtonID="Image12"
                                                        TargetControlID="txtFromdate" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromdate"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter From Date" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">To Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtTodate" runat="server" CssClass="span4" Width="" Enabled="false"></asp:TextBox>&nbsp;
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtenderto" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txtTodate" Enabled="True">
                                                    </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTodate"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter To Date" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Currency From</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_currencyfrom" runat="server" CssClass="span4" Width=""
                                                        Height="20px" AutoPostBack="true" OnSelectedIndexChanged="ddl_currencyfrom_OnSelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddl_currencyfrom" InitialValue="0"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Currency To</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_currencyTo" runat="server" CssClass="span4" Width=""
                                                        Height="20px">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_currencyTo" InitialValue="0"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Conversion From</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtConversionfrom" runat="server" CssClass="span4" Text="1" Width=""></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Conversion To</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtCoversionto" runat="server" CssClass="span4" onblur="return calculate()"
                                                        Width=""></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Reverse Conversion From</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtRevConversionfrom" runat="server" Enabled="false" CssClass="span4" Width=""></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Reverse Conversion To</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtRevconvesionto" runat="server" Enabled="false" CssClass="span4"
                                                        Width=""></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btncurrency" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="c"
                                                    OnClick="btncurrency_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Currency
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdState" runat="server" AutoGenerateColumns="False" Width="100%" DataKeyNames="slno" OnPreRender="Grid_Emp_PreRender"
                                                EmptyDataText="No Data  Found"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="slno" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("slno")%>'></asp:Label>
                                                        </ItemTemplate>


                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromdate" runat="server" Text='<%# Eval("fromdate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltodate" runat="server" Text='<%#Eval("todate","{0:MM/dd/yyyy}")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Currency">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromcurrency" runat="server" Text='<%#Eval("fromcurrency")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Currency ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltocurrency" runat="server" Text='<%#Eval("tocurrency")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Rate">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromrate" runat="server" Text='<%#Eval("fromrate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Rate ">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltorate" runat="server" Text='<%#Eval("torate")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="slno" DataNavigateUrlFormatString="~/admin/currencymaster.aspx?slno={0}"
                                                        Text="Edit">
                                                        <ControlStyle CssClass="link05" Width="10%" />
                                                        <HeaderStyle />

                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnactive" runat="server" Text='<%#Eval("status").ToString()=="True"?"Active":"Inactive"%>' CssClass="link05" OnCommand="lbnt_Active_click" CommandArgument='<%#Eval("slno")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="10%" />

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
                $('#grdState').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">

            function isChar() {
                var ch = String.fromCharCode(event.keyCode);
                var filter = /[a-zA-Z\s]/;
                if (!filter.test(ch)) {
                    alert('Please enter only Char')
                    event.returnValue = false;
                }
            }

            function calculate() {
                var fromrate = document.getElementById('<%=txtConversionfrom.ClientID %>').value;

                var torate = document.getElementById('<%=txtCoversionto.ClientID %>').value;
                if (fromrate != "" && torate != "") {
                    document.getElementById('<%=txtRevConversionfrom.ClientID %>').value = (fromrate / torate).toFixed(4);
                    document.getElementById('<%=txtRevconvesionto.ClientID %>').value = fromrate;
                }
            }

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

