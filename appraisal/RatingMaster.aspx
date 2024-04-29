<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RatingMaster.aspx.cs" Inherits="appraisal_RatingMaster" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Rating Master</h2>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                            <ProgressTemplate>
                                <div class="divajax">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <img src="../images/loading.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Create Rating "></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div class="row">
                                            <div class="control-group">
                                                <label class="control-label">Rating</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_Rating" runat="server" CssClass="blue1" Width="235px" MaxLength="1"
                                                        onkeypress="return isNumber()"></asp:TextBox>&nbsp;<asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_Rating" ErrorMessage="Subject"
                                                            Display="Dynamic" ValidationGroup="r"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator4" ControlToValidate="txt_Rating"
                                                        ValidationGroup="r" runat="server" MinimumValue="1" MaximumValue="5" ToolTip="Enter only 1-5" Type="Integer"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtdescription" runat="server" CssClass="blue1" Width="238px" Height="59px" MaxLength="8000"
                                                        TextMode="MultiLine" Style="resize: none"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtdescription"
                                                        Display="Dynamic" ErrorMessage="Description" ValidationGroup="r"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets"
                                                                    ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\'\,]+$" ControlToValidate="txtdescription"
                                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="r">
                                                                    <img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="r" OnClick="btnsubmit_Click" />&nbsp;
                                        <asp:Button ID="btnreset" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btnreset_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Rating
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gridratings" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="rating_id"  OnPreRender="gridratings_PreRender"
                                        OnRowCancelingEdit="gridratings_RowCancelingEdit" OnRowEditing="gridratings_RowEditing" OnRowUpdating="gridratings_RowUpdating"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Rating">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "rating")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtrating" runat="server" Text='<%# Eval("rating")%>'></asp:TextBox>
                                                    <asp:RequiredFieldValidator
                                                        ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtrating" ErrorMessage="Enter rating"
                                                        Display="Dynamic" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtrating"
                                                        ValidationGroup="v" runat="server" MinimumValue="1" MaximumValue="5" ToolTip="Enter only 1-5" Type="Integer"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Description">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem, "description")%>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtratingdesc" runat="server" Text='<%# Eval("description")%>' TextMode="MultiLine" MaxLength="8000"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtratingdesc"
                                                        Display="Dynamic" ErrorMessage="Enter Description" ValidationGroup="v"><img src="../images/error1.gif" alt="*" /></asp:RequiredFieldValidator>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-#',)"
                                                                            ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\'\,]+$" ControlToValidate="txtratingdesc" 
                                                                            ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                        </asp:RegularExpressionValidator>--%>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="false" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"
                                                        CssClass="link05" Text="Edit" ToolTip="Edit" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnkbtnedit" runat="server" CausesValidation="true"
                                                        CommandName="Update" CssClass="link05" Text="Update" ToolTip="Update" ValidationGroup="v" />
                                                    <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                        CssClass="link05" Text="Cancel" ToolTip="Cancel" />
                                                </EditItemTemplate>
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
                $('#gridratings').dataTable({
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
