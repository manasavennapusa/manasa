<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayHead.aspx.cs" Inherits="Reimbursement_PayHead" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
   <style type="text/css">
       .star
       {
           color:red;
       }

   </style>
    
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

        function isChar() {
            var ch = String.fromCharCode(event.keyCode);
            var filter = /[a-zA-Z\s]/;
            if (!filter.test(ch)) {
                alert('Please enter only Char')
                event.returnValue = false;
            }
        }

    </script>


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
                                <h2>Pay Head</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                           <asp:Label ID="lblhead" runat="server" Text="Create"></asp:Label>
                                            <span id="message" runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group">
                                                <label class="control-label">Category<span class="star">*</span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="span4">
                                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        <asp:ListItem Text="Business Reimbursement" Value="1"></asp:ListItem>
                                                        <asp:ListItem Text="Miscellaneous  Reimbursement" Value="2"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RFcategory" runat="server" ControlToValidate="ddlcategory" InitialValue="0" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                        ValidationGroup="app"  ToolTip="Select Category"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Name<span class="star">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtpayhead" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isChar()" Width=""></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpayhead" ToolTip="Enter Payhead Name"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="app"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="span4" MaxLength="2000" TextMode="MultiLine"></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Is Attachment Mandatory</label>
                                                <div class="controls">
                                                    <asp:CheckBox ID="chksubcat" runat="server" />
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="app" OnClick="btnsave_Click" />
                                                 <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset"  OnClick="btnreset_Click" />

                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="VIEW" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label3" runat="server" Text="View"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div id="dt_example" class="example_alt_pagination">
                                             <div style="  padding: 5px;  font-size: 16px;">
                                    Search : <asp:TextBox ID="TextBox1" runat="server" width="15%" Font-Size="15px" onkeyup="Search_Gridview(this, 'grdpayhead')"></asp:TextBox>
                                       </div>
                                            <asp:GridView ID="grdpayhead" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                DataKeyNames="PID" OnRowEditing="grdpayhead_RowEditing" OnRowDeleting="grdpayhead_RowDeleting" OnPreRender="grdpayhead_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="PID" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblPID" runat="server" Text='<%#Eval("PID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("Type")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText=" Name" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldesc" runat="server" Text='<%#Eval("Description")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Attachment" HeaderStyle-Width="30%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblIsAttach" runat="server" Text='<%#Eval("IsAttach")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnEdit" runat="server" Text="Edit" CssClass="link05" CommandName="Edit"><i class="icon-pencil"></i></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnDelete" runat="server" CssClass="link05" Text="Delete" CommandName="Delete"><i class="icon-remove"></i></asp:LinkButton>
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
                $('#grdpayhead').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

          <script type="text/javascript">
              function Search_Gridview(strKey, strGV) {
                  var strData = strKey.value.toLowerCase().split(" ");
                  var tblData = document.getElementById(strGV);
                  var rowData;
                  for (var i = 1; i < tblData.rows.length; i++) {
                      rowData = tblData.rows[i].innerHTML;
                      var styleDisplay = 'none';
                      for (var j = 0; j < strData.length; j++) {
                          if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                              styleDisplay = '';
                          else {
                              styleDisplay = 'none';
                              break;
                          }
                      }
                      tblData.rows[i].style.display = styleDisplay;
                  }
              }
    </script>

     <%--   <script>
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>--%>
    </form>
</body>
</html>
