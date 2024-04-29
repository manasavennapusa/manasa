<%@ Page Language="C#" AutoEventWireup="true" CodeFile="countryedit.aspx.cs" Inherits="admin_countryedit" %>

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
                                <h2>Country </h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="tblcountry" runat="server" visible="false">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>

                                            <asp:Label ID="lblhead" Text="Edit Country" runat="server"></asp:Label>
                                            <span id="message" runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">ISO 3166 3C Code</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_iso_3c" runat="server" CssClass="span4" MaxLength="3" onkeypress="return isChar()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_iso_3c"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter ISO 3166 3C Code" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Country</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtcountry" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isChar()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcountry"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Country" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Capital</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtCapital" runat="server" CssClass="span4" MaxLength="100" onkeypress="return isChar()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtCapital"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Capital" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                           
                                            <div class="control-group">
                                                <label class="control-label">Currency Code</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlCurrCode" runat="server" CssClass="span4" OnSelectedIndexChanged="ddlCurrCode_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCurrCode" InitialValue="0"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Currency Code" ValidationGroup="c"
                                                        Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                             <div class="control-group">
                                                <label class="control-label">Currency Name</label>
                                                <div class="controls">
                                                  <%--  <asp:Label ID="txtCurrName" runat="server" CssClass="span4" style="border: 1px solid #ddd " ></asp:Label>--%>
                                                    <asp:TextBox ID="txtCurrName" runat="server" CssClass="span4"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtcountryDes" TextMode="MultiLine" MaxLength="150" runat="server" CssClass="span4" Width=""></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btncountry" runat="server" CssClass="btn btn-primary" Text="Save" ValidationGroup="c"
                                                    OnClick="btncountry_Click" />
                                                <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Cancel" ValidationGroup=""
                                                    OnClick="btncancel_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>


                        <div class="row-fluid" id="grujj" runat="server">
                            <div class="span12" >
                                <div class="widget no-margin" >
                                    <div class="widget-header" runat="server" visible="">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View 
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                             
                                            <asp:GridView ID="grdCountry" runat="server" AutoGenerateColumns="False" Width="100%"   OnPreRender="Grid_Emp_PreRender"
                                                CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ISO 3166  3C Codes">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbl3c" runat="server" Text='<%#Eval("ISO31663CCodes")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Country Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcountry" runat="server" Text='<%#Eval("countryname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Capital">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcapital" runat="server" Text='<%#Eval("capital")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Currency Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcurrencyname" runat="server" Text='<%#Eval("currencyname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />

                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Currency Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcurrencycode" runat="server" Text='<%#Eval("currency")%>'></asp:Label>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="15%" />

                                                    </asp:TemplateField>

                                                    <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="cid" DataNavigateUrlFormatString="~/admin/countryedit.aspx?Id={0}"
                                                        Text="&lt;img src='images/edit.png'/&gt;" HeaderStyle-Width="10%">
                                                        <ControlStyle CssClass="link05" Width="20%" />
                                                        <HeaderStyle />

                                                    </asp:HyperLinkField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnactive" runat="server" Text='<%#Eval("status").ToString()=="True"?"Active":"Inactive"%>' CssClass="link05" OnCommand="lbnt_Active_click" CommandArgument='<%#Eval("cid")%>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20%" />

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
                $('#grdCountry').dataTable({
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
