<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PickCandidate.aspx.cs" Inherits="recruitment_PickCandidate" %>

<!DOCTYPE html>
<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd. : Candidate Details</title>
    <script type="text/javascript" language="javascript">

        function returncandidate(val) {

            // hardcoded value used to minimize the code. 

            // ControlID can instead be passed as query string to the popup window
            var role = GetParameterValues('role');
            //  alert(role);
            if (role == "10")
                window.opener.document.getElementById("txtcandidatename").value = val;
            //window.opener.document.getElementById("tbaddress").value = val;
        else if (role == "11")         
            window.opener.document.getElementById("tbaddress").value = val;
        else if (role == "13")
            window.opener.document.getElementById("txt_candidate_id").value = val;
            window.opener.focus();
            window.close();
        }
        //function returncandidate_1(val) {
        //    var role = GetParameterValues('role');

        //    if (role == "20")
        //        window.opener.document.getElementById("txt_candidateid").value = val;
          
        //    window.opener.focus();
        //    window.close();
        //}
        function GetParameterValues(param) {
            var url = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
            for (var i = 0; i < url.length; i++) {
                var urlparam = url[i].split('=');
                if (urlparam[0] == param) {
                    return urlparam[1];
                }
            }
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
           
                <div class="row-fluid" style="border:1px solid rgba(0, 0, 0, 0.10);">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                     <%--datakeyname="candidatename"--%>
                                    <asp:GridView ID="candidategrid" runat="server"
                                        AutoGenerateColumns="False"
                                        CssClass="table table-striped table-bordered table-responsive datatable" EmptyDataText="No such candidate exists !" OnPageIndexChanging="candidategrid_PageIndexChanging" OnPreRender="candidategrid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="RRF Code" Visible="false">
                                                <ItemTemplate>
                                                   <asp:Label ID="l3" runat="server" Text='<%# Bind ("rrf_id") %>'></asp:Label>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "candidate_name") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "rrf_code") %></a>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Candidate ID">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="l3" runat="server" Text='<%# Bind ("id") %>'></asp:Label>--%>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "candidate_name") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "candidate_name") %></a>--%>
                                                    <a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "id") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "id") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("candidate_name") %>'></asp:Label>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "candidate_name") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "candidate_name") %></a>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Candidate Address">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("candidate_address") %>'></asp:Label>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "candidate_address") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "candidate_address") %></a>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Location">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("branch_name") %>'></asp:Label>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "branch_name") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "branch_name") %></a>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                    <%--<a href="javascript:returncandidate('<%# DataBinder.Eval(Container.DataItem, "designationname") %>'+'' )" class="link05"><%# DataBinder.Eval(Container.DataItem, "designationname") %></a>--%>
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
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#candidategrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        
    </form>
</body>
</html>
