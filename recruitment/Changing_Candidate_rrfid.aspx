<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Changing_Candidate_rrfid.aspx.cs" Inherits="recruitment_Changing_Candidate_rrfid" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>RECRUITMENT REQUISITION FORMS</h2>--%>
                        <h2>Edit RRF</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>RECRUITMENT REQUISITON FORM - STATUS--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details 
                                </div>
                            </div>
                            <div class="widget-body">
                               

                                    <div>
                                        <p>
                                            <div class="widget-body">
                                                <div id="dt_example" class="example_alt_pagination">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="GridView1_PreRender"
                                        EmptyDataText="No data Found"  OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" OnRowCancelingEdit="GridView1_RowCancelingEdit"  OnRowDataBound="GridView1_RowDataBound"  CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Candidate ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCID" runat="server" Text='<%#Eval("candidateid")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="RRF ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbrrfid" runat="server" Text='<%#Eval("rrf_id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField> 
                                          
                                            <asp:TemplateField HeaderText="RRF Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrrfID" runat="server" Text='<%#Eval("rrf_code")%>'></asp:Label>
                                                </ItemTemplate>
                                                  <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlrrf"    runat="server" Width="95px"   CssClass="blue1" Height="30px">
                                                       
                                                    </asp:DropDownList>

                    
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Designation Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Skills" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblskills" runat="server"  Text='<%#Eval("skills")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Experience" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexp" runat="server" Text='<%#Eval("experience")%>'></asp:Label>
                                                    Months
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                         
                                            <asp:TemplateField HeaderText="Contact No." >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcontactno" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email" >
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("emailid")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                       
                                            <asp:TemplateField HeaderText="Profile">
                                                <ItemTemplate>
                                                    <%-- <a href='EditUser.aspx?uid=<%# Eval("Userid")%>&other=<%# Eval("Other")%>'>Text</a>--%>
                                                    <%--<a href="JavaScript:newPopup1('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>')" 'height="550",width' class="link05">View</a>--%>
                                                    <a href="javascript:void(window.open('Candidatedetails.aspx?id=<%# Eval("candidateid") %>&rrf_id=<%# Eval("rrf_id")%>','title','height=550,width=1100,left=100,top=30'));" class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%-- <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="Changing_Candidate_rrfid.aspx?candidateid=<%#DataBinder.Eval(Container.DataItem, "candidateid")%>"
                                                        target="_self">Edit</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                             
                                        </Columns>
                                                          <Columns>
                                                                                                            <asp:CommandField ShowEditButton="true"  HeaderText="Edit" ButtonType="Button" ControlStyle-CssClass="btn btn-info" EditText="Edit" UpdateText="Update" CancelText="Cancel" />
                                                                                                        </Columns>
                                    </asp:GridView>
                                                   
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
      
    </form>
    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#GridView1').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        //$(document).ready(function () {
        //    $('#grdRejectedRRF').dataTable({
        //        "sPaginationType": "full_numbers"
        //    });
        //});

        //$(document).ready(function () {
        //    $('#grdclosedrrf').dataTable({
        //        "sPaginationType": "full_numbers"
        //    });
        //});

        //$(document).ready(function () {
        //    $('#grdRRF').dataTable({
        //        "sPaginationType": "full_numbers"
        //    });
        //});
    </script>
    <script type="text/javascript">
        $("#wizard").bwizard();
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
</body>
</html>
