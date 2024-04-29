<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpAssessment.aspx.cs" Inherits="appraisal_EmpAssessment" %>

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
    <script src="js/validation.js"></script>
    <script type="text/javascript">
        function disableBtn(btnID, newText) {

            var btn = document.getElementById(btnID);
            setTimeout("setImage('" + btnID + "')", 60000);
            btn.disabled = true;
            btn.value = newText;
        }

        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(12501270608.gif)';
        }
    </script>
    <style>
        .center
        {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="images/loader.gif" alt="" />
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Self Assessment Form</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Self Assessment Form"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div>


                                            <table style="width: 100%" id="table" runat="server">
                                                <tr>
                                                    <td class="txt01" style="height: 40px"><strong>Set Goals</strong></td>
                                                    <td class="txt-red" style="text-align: right; width: 80%">
                                                        <span id="Span1" runat="server">&nbsp;</span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="vertical-align: top">
                                                        <asp:GridView ID="gvGoals" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                                            CaptionAlign="Left" CellPadding="4" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                            DataKeyNames="asd_id" HorizontalAlign="Left" Width="100%" EnableModelValidation="True" OnRowEditing="gvGoals_RowEditing"
                                                            OnRowDataBound="gvGoals_RowDataBound" ShowFooter="True" OnRowCancelingEdit="gvGoals_RowCancelingEdit" OnRowUpdating="gvGoals_RowUpdating"
                                                            EmptyDataText="No Data Found">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Sl.No">
                                                                    <ItemTemplate>
                                                                        <%# Container.DataItemIndex +1 %>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="5%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Title">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Label1" runat="Server" Text='<%# Eval("title") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txttitle" runat="Server" Text='<%# Eval("title") %>' Enabled='<%# Eval("IsEditable").ToString()=="E"?true:false %>' palceholder="Max. 200 chars." MaxLength="200"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Labelspe" runat="Server" Text='<%# Eval("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtdesc" runat="Server" Text='<%# Eval("Description") %>' onkeypress="return IsNumericDot(event)" Enabled='<%# Eval("IsEditable").ToString()=="E"?true:false %>' MaxLength="8000" palceholder="Max. 8000 chars." TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <b>Total Weightage :</b>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Weightage(%)">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblweightage" runat="Server" Text='<%# Eval("weightage") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtweightage" runat="Server" Text='<%# Eval("weightage") %>' MaxLength="5" Width="100px" CssClass="blue1" palceholder="Max. 5 chars."></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator15" ControlToValidate="txtweightage"
                                                                            ValidationGroup="p" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                            ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <asp:Label ID="lblTotalWeightage" runat="Server" Font-Bold="true"></asp:Label>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="10%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Emp. Comments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblcomm" runat="Server" Text='<%# Eval("emp_comments") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:TextBox ID="txtcomm" runat="Server" Text='<%# Eval("emp_comments") %>' palceholder="Max. 8000 chars." MaxLength="200" TextMode="MultiLine"></asp:TextBox>
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Manager Comments">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblmngcomm" runat="Server" Text='<%# Eval("mng_comments") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="20%" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Edit">
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server" CommandName="Edit" OnClientClick="return confirm('Are you sure to Edit this entry?')"
                                                                            CssClass="btn btn-primary" Text="Edit" ToolTip="Edit" />
                                                                        <asp:Label ID="lbledit" CssClass="link05" runat="Server" Text="" Visible='<%# Eval("IsEditable").ToString()=="E"?false:true %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <EditItemTemplate>
                                                                        <asp:LinkButton ID="lnkbtnedit" runat="server"
                                                                            CommandName="Update" CssClass="btn btn-primary" Text="Update" ToolTip="Update" ValidationGroup="p" />
                                                                        <asp:LinkButton ID="lnkbtndelete" runat="server" CausesValidation="false" CommandName="Cancel"
                                                                            CssClass="btn btn-primary" Text="Cancel" ToolTip="Cancel" />
                                                                    </EditItemTemplate>
                                                                    <HeaderStyle Width="15%" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="trbtns" runat="server" visible="false">
                                                    <td colspan="2" style="text-align: right; height: 50px; vertical-align: top">
                                                        <asp:Button ID="AddGoals" runat="server" Text="Add Goals" OnClick="AddGoals_Click" CssClass="btn btn-primary" />
                                                    </td>
                                                </tr>
                                                <tr id="traddGoals" runat="server" visible="false">
                                                    <td colspan="2">
                                                        <table style="width: 100%; border: 0">
                                                            <tr>
                                                                <td class=" frm-lft-clr123 border-bottom" width="25%">Title<span class="star"></span>
                                                                </td>
                                                                <td class=" frm-lft-clr123 border-bottom" width="30%">Description<span class="star"></span>
                                                                </td>
                                                                <td class=" frm-lft-clr123 border-bottom" width="15%">Weightage(%)<span class="star"></span>
                                                                </td>
                                                                <td class=" frm-lft-clr123 border-bottom" width="15%">Comments<span class="star"></span>
                                                                </td>
                                                                <td class=" frm-lft-clr123 border-bottom" width="15%"></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="width: 150px" class="frm-rght-clr12345">
                                                                    <asp:TextBox ID="txtTitle" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" placeholder="Max 200 chars." MaxLength="200"></asp:TextBox>
                                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtTitle"
                                                ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only alphanumeric and space"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Title"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                </td>
                                                                <td style="width: 200px" class="frm-rght-clr12345">
                                                                    <asp:TextBox ID="txtDesc" runat="server" Width="85%" CssClass="blue1" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txtDesc"
                                                ValidationGroup="g" runat="server" ValidationExpression="^[a-zA-Z0-9_&quot;\/\.\-\,\(\)\'\&\?\!\:\s]+$" ToolTip="Enter only alphanumeric and(!.,/doulbe_quot()': space ? -) "
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDesc"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter Description"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                </td>
                                                                <td style="width: 100px" class="frm-rght-clr12345">
                                                                    <asp:TextBox ID="txtWeightage" runat="server" CssClass="blue1" Width="120px" MaxLength="3" onkeypress="return IsNumericDot(event)" placeholder="Max 5 chars."></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtWeightage"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                    <asp:RangeValidator ID="RangeValidator5" ControlToValidate="txtWeightage"
                                                                        ValidationGroup="g" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                </td>
                                                                <td style="width: 100px" class="frm-rght-clr12345">
                                                                    <asp:TextBox ID="txtgoalcomm" runat="server" CssClass="blue1" Width="150px" TextMode="MultiLine" MaxLength="8000" placeholder="Max 8000 chars."></asp:TextBox>
                                                                   <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtgoalcomm"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="g" Display="Dynamic" ToolTip="Enter weightage"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                                </td>
                                                                <td class="frm-rght-clr12345">
                                                                    <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSaveGoals_Click" OnClientClick="disableBtn(this.id, 'Submitting...')" UseSubmitBehavior="false"
                                                                        CssClass="btn btn-primary" ToolTip="Click here to add Goals" ValidationGroup="g"></asp:Button>
                                                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                                                                        CssClass="btn btn-primary" ToolTip="Click here to Cancel"></asp:Button>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trgoal1" runat="server">
                                                    <td colspan="2">
                                                        <table width="100%" class="table table-condensed table-striped  table-bordered" id="tbl_gc1" runat="server">
                                                            <tr id="tr_gc1_heading" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%; border-right: 1px solid #e0e0e0">
                                                                    <b>Cycle 1 : Goal Setting</b>
                                                                </td>
                                                            </tr>

                                                            <tr id="tr_gc1_employeecomments" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%;">
                                                                    <asp:Label ID="Label3" runat="server" Text="Overall Employee Comments"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 80%;">
                                                                    <asp:Label ID="lblgoal1empcomm" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr_gc1_managercomments" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%;">
                                                                    <asp:Label ID="Label5" runat="server" Text="Overall Manager Comments"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 80%;">
                                                                    <asp:Label ID="lblgoal1mngcomm" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" class="table table-condensed table-striped  table-bordered " id="tbl_gc2" runat="server">
                                                            <tr id="tr_gc2_heading" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%; border-right: 1px solid #e0e0e0"><b>Cycle 2 : Mid Year Assessment</b>
                                                                </td>
                                                            </tr>

                                                            <tr id="tr_gc2_employeecomments" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%;">
                                                                    <asp:Label ID="Label4" runat="server" Text="Overall Employee Comments"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 80%;">
                                                                    <asp:Label ID="lblgoal2empcomm" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr_gc2_managercomments" runat="server">
                                                                <td class="frm-lft-clr123 " style="width: 20%;">
                                                                    <asp:Label ID="Label7" runat="server" Text="Overall Manager Comments"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123 " style="width: 80%;">
                                                                    <asp:Label ID="lblgoal2mngcomm" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>


                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <table width="100%" class="table table-condensed table-striped  table-bordered" id="tbl_overallcomments" runat="server">
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom" style="width: 20%;">
                                                                    <asp:Label ID="lblcmtsText" runat="server" Text="Overall Employee Comments"></asp:Label>
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom" style="width: 80%;">
                                                                    <asp:TextBox ID="txtComments" runat="server" MaxLength="8000" CssClass="span11" palceholder="Max. 8000 chars." TextMode="MultiLine" Style="width: 100%;"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="txtCommentsRequired" runat="server" ControlToValidate="txtComments" ErrorMessage='<img src="../images/error1.gif" alt="" /> <b style="color:red;">Please Enter the Comments</b>' ValidationGroup="v" />
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="only enter alphabets, numbers,space and (.:\/-# % ,)"
                                                                        ValidationExpression="^[a-zA-Z0-9.:\/\-\#\s\%\,]+$" ControlToValidate="txtComments"
                                                                        ErrorMessage='<img src="../images/error1.gif" alt="" />' ValidationGroup="v">
                                                                    </asp:RegularExpressionValidator>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="display: none">

                                                <tr>
                                                    <td valign="middle" class="txt01" style="height: 24px">&nbsp;View Competencies</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div class="widget-content">
                                                            <asp:GridView ID="gv_comp" runat="server" Width="100%" AutoGenerateColumns="False"
                                                                DataKeyNames="com_id,apc_id" BorderWidth="0px" CellPadding="4"
                                                                CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                                ShowFooter="true" OnRowDataBound="gvcompentencies_RowDataBound" EmptyDataText="No Data Found">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Sl.No" HeaderStyle-Width="5%">

                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex +1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Title" HeaderStyle-Width="25%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="clbltitle" runat="server" Text='<%#Eval("title")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="ctxtTitle" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "title")%>'
                                                                                MaxLength="100" CssClass="blue1"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40%">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="clbldesc" runat="server" Text='<%#Eval("description")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="ctxtDesc" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "description")%>'
                                                                                MaxLength="8000" CssClass="blue1"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <b>Total Weightage :</b>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Weightage(%)" HeaderStyle-Width="10%">

                                                                        <ItemTemplate>
                                                                            <asp:Label ID="clblweightage" runat="server" Text='<%#Eval("weightage")%>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="ctxtweightage" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "weightage")%>'
                                                                                MaxLength="5" CssClass="blue1"></asp:TextBox>

                                                                            <asp:RangeValidator ID="RangeValidator5" ControlToValidate="ctxtweightage"
                                                                                ValidationGroup="p" runat="server" MinimumValue="1" MaximumValue="100" ToolTip="Enter only 1-100" Type="Double"
                                                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblTotalWeightage" runat="Server" Font-Bold="true"></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>

                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="trRevertComments" runat="server">
                                                    <td></td>
                                                </tr>

                                            </table>

                                            <div class="form-actions no-margin" id="btns" runat="server">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit To Manager" CssClass="btn btn-success" ValidationGroup="v" OnClick="btnSubmit_Click" /><%--CssClass="btn btn-success"--%>
                                                <asp:Button ID="btn_SendToHR" runat="server" Text="Submit To HR" CssClass="btn btn-primary" CausesValidation="false" OnClick="btn_SendToHR_Click" />
                                            </div>

                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

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

