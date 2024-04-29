<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InterviewAnalysis.aspx.cs" Inherits="recruitment_InterviewAnalysis" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
     <script src="js/popup1.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Interview Rating </h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>CANDIDATES SELECTED IN ROUND 2
                                </div>
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>
                                    <tr>
                                        <td>
                                            Select RRF Code
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlrrfcode" runat="server" CssClass="span4" OnSelectedIndexChanged="ddlrrfcode_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </td>
                                      
                                    </tr>
                                </tbody>
                            </table>

                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">

                                    <asp:GridView ID="grdcandidates" runat="server" AutoGenerateColumns="False" AllowSorting="True" EmptyDataText="No data Found"
                                         CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPreRender="grdcandidates_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Candidate ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RRF CODE">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblrrf" runat="server" Text='<%#Eval("rrf_code")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Designation Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldisg" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Candidate Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblname" runat="server" Text='<%#Eval("candidate_name")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Skills">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblskills" runat="server" Text='<%#Eval("skills")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Experience (in Months)" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexp" runat="server" Text='<%#Eval("experience")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qualification">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqualification" runat="server" Text='<%#Eval("Qualification")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="DOB">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldob" runat="server" Text='<%# Eval("dob", "{0:MM/dd/yyyy}")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No.">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcontactno" runat="server" Text='<%#Eval("mobile")%>'></asp:Label>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemail" runat="server" Text='<%#Eval("emailid")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Salary Expected" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblexpectedsalary" runat="server" Text='<%#Eval("expectedsalary")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Profile">
                                                <ItemTemplate>
                                                    <%-- <a href='EditUser.aspx?uid=<%# Eval("Userid")%>&other=<%# Eval("Other")%>'>Text</a>--%>
                                                    <a href="JavaScript:newPopup1('Candidatedetails.aspx?id=<%# Eval("id") %>&rrf_id=<%# Eval("rrf_id")%>')" class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                    <%--  <a href="#advanced" role="button" class="btn btn-primary pull-right" data-toggle="modal">Details</a>--%>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText=" Interview Analysis">
                                                <ItemTemplate>
                                                    <%--<a href='InterviewAnalysis1.aspx?id=<%# Eval("id") %>' class="link05">Evaluate</a>--%>
                                                    <a href='InterviewAnalysis1.aspx?id=<%# Eval("id") %>' class="link05"><img src="../images/Evaluate.png"></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>
                                <%-- <div class="form-actions no-margin">
                                    <asp:Button ID="btnFinalround" runat="server" Text="Final Round" CssClass="btn btn-primary" OnClick="btnFinalround_Click" />&nbsp;
                                </div>--%>
                            </div>
                        </div>

                    </div>

                </div>
                
            </div>
        </div>
    </form>
      <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdcandidates').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
