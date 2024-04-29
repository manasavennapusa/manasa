<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holdrrfdetails.aspx.cs" Inherits="recruitment_holdrrfdetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
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

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <script type="text/javascript">
        function validate() {
            if (document.getElementById("txtcomments").value == "") {
                alert("Comments should not be empty");
            }
        }
    </script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>RECRUITMENT REQUISITION FORM</h2>--%>
                        <h2>RRF Details</h2>
                    </div>
                 
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>RECRUITMENT REQUISITION FORM DETAILS--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View
                                </div>
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>

                                    <tr>
                                        <th class="span3">RRF Code</th>
                                        <td class="span4">
                                            <asp:Label ID="lbl_rrfcode" runat="server"></asp:Label>
                                        </td>
                                        <th class="span3">Requested By</th>
                                        <td class="span4">
                                            <asp:Label ID="lbl_requestedby" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                   

                                    <tr>
                                        <th>Total No of Posts</th>
                                        <td>
                                            <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
                                        </td>
                                        <th>Request Type</th>
                                        <td>
                                            <asp:Label ID="lbl_requestType" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Vacancy Type</th>
                                        <td>
                                            <asp:Label ID="lbl_vacancyType" runat="server"></asp:Label>
                                        </td>
                                        <th>Expected CTC</th>
                                        <td>
                                            <asp:Label ID="lbl_incentive" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr runat="server" visible="false">                                       
                                         <th>Temporary(in days)</th>
                                        <td>
                                            <asp:Label ID="lbl_temparary" runat="server"></asp:Label>
                                        </td>
                                        <th>Working Hours</th>
                                        <td>
                                            <asp:Label ID="lbl_workinghours" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Reasons of Request</th>
                                        <td>
                                            <asp:Label ID="lbl_reasons" runat="server"></asp:Label>
                                        </td>
                                       <th>Location</th>
                                        <td>
                                            <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Shift Hours</th>
                                        <td>
                                            <asp:Label ID="lbl_shifthours" runat="server"></asp:Label>
                                        </td>

                                          <th>Department Type</th>
                                        <td>
                                            <asp:Label ID="lbl_costcenter" runat="server"></asp:Label>
                                        </td>
                                       
                                    </tr>
                                     <tr>
                                        <th>Department</th>
                                        <td>
                                            <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                        </td>
                                        <th>Designation</th>
                                        <td>
                                            <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr1" runat="server" visible="false">
                                        <th>Gross Salary</th>
                                        <td>
                                            <asp:Label ID="lbl_grosssalary" runat="server"></asp:Label>
                                        </td>
                                        <th>TCTC</th>
                                        <td>
                                            <asp:Label ID="lbl_tctc" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   

                                    <tr>
                                        <th>Job Description</th>
                                        <td>
                                            <asp:Label ID="lbl_jobdesc" runat="server"></asp:Label>
                                        </td>

                                        <th>Skills</th>
                                        <td>
                                            <asp:Label ID="lbl_skills" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Educational Qualification</th>
                                        <td>
                                            <asp:Label ID="lbl_edu" runat="server"></asp:Label>
                                        </td>

                                        <th>Experience</th>

                                        <td>
                                            <asp:Label ID="lbl_Exp" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <th>Additional Qualification</th>
                                        <td>
                                            <asp:Label ID="lblQualifiers" runat="server"></asp:Label>
                                        </td>
                                        <th>Industries Preferred</th>
                                        <td>
                                            <asp:Label ID="lbl_industries" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Comments
                                        </th>
                                        <td colspan="3">
                                            <asp:TextBox ID="txtcomments" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtcomments"
                                                Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Comments"
                                                ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                        </td>
                                    </tr>

                                </tbody>
                            </table>
                             <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Hold Logs</span>
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example" class="example_alt_pagination">
                                                <asp:GridView ID="grdrrfholddetails" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                    EmptyDataText="No data Found" CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Hold Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblholddate" runat="server" Text='<%#Eval("holddate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("comments")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Hold By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblholdby" runat="server" Text='<%#Eval("createdby")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Active Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactivedate" runat="server" Text='<%#Eval("activedate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Active By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactiveby" runat="server" Text='<%#Eval("updatedby")%>'></asp:Label>
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
                            <div class="form-actions no-margin" style="text-align:right">
                                <asp:Button ID="btnhold" runat="server" Text="Hold RRF" CssClass="btn btn-info" ValidationGroup="rrf" OnClick="btnhold_Click" />&nbsp;
                  
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
