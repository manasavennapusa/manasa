<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editempmachinecodeandip.aspx.cs" Inherits="attendance_editempmachinecodeandip" %>

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

    <script type="text/javascript">

        function Validate() {
            var Branch = document.getElementById('<%=dd_branch.ClientID%>')
            var ip = document.getElementById('<%=ddl_ip.ClientID%>');
            var empcode = document.getElementById('<%=txt_employee.ClientID%>');


            if (empcode.value == "") {
                alert("Please Select Empcode");
                return false;
            }
            return true;
        }
    </script>
    <script src="Js/popup.js"></script>

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>MachineCode & IP Address</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget" style="width:49%; float:left; clear:none">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Create/Update MachineCode & IP Address"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <fieldset>
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="control-group">
                                                <label class="control-label">Branch</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="dd_branch" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="dd_branch_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">IP Address</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_ip" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">EmpCode</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="form-control" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                                </div>
                                            </div>


                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="btn btn-primary pull-right"
                                            Text="Submit" OnClientClick="return Validate()"></asp:Button>
                                    </div>
                                </fieldset>

                            </div>
                        </div>

                        <div class="widget" style="width:49%; float:right; clear:none; height:280px">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            Upload Employee IP & Machine Code
                                        </div>
                                        <div>
                                            <a style="float:right;" href="../download/Machine%20Code%20and%20Employee%20Details.xlsx">Download</a>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group" style=" margin-top:20px">
                                                    <label class="control-label">Upload Employee Information</label>
                                                    <div class="controls">
                                                        <asp:FileUpload ID="EDBfileupload" runat="server" />
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                            ControlToValidate="EDBfileupload" ValidationGroup="b" CssClass="txt-red" ErrorMessage="Only excel format(.xls,.xlsx)"
                                                            ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$"></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="form-actions" style="margin-top:80px">
                                                    <asp:Button ID="btnSubmit" runat="server" Text="Upload" OnClick="btnUpload_Click" CssClass="btn btn-primary pull-right" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                    </div>
                </div>

                <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon=""></span>Upload Employee Information Warnings
                                        </div>
                                    </div>
                                    <div class="widget-body">

                                        <div class="alert alert-block alert-error fade in">
                                            <%--  <button class="close" type="button" data-dismiss="alert">
                                                ×
                                            </button>--%>
                                            <p runat="server" id="diverror">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
               
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">View Employee Machine Code & IP Address</span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="ipgrid" runat="server" EmptyDataText="Sorry No Records Found"
                                        AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive" OnPreRender="ipgrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="EmpCode">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Branch">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbranch" runat="server" Text='<%# Bind("branch_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="IP Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="ip" runat="server" Text='<%# Bind("deviceips")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Machine Code">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtenrollno" runat="server" Text='<%# Bind("machinecode") %>' Width="150px" CssClass="form-control col-md-6"></asp:TextBox>
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
                <div class="form-actions no-margin" id="update" runat="server" visible="false">
                    <asp:Button ID="btnupdate" OnClick="btnupdate_Click" runat="server" CssClass="btn btn-primary pull-right" Text="Update"></asp:Button>
                </div>
            </div>
                    </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnSubmit" />
                </Triggers>
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
                $('#Grid_Emp').dataTable({
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
