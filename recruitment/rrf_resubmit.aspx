<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rrf_resubmit.aspx.cs" Inherits="recruitment_rrf_resubmit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
    <script src="../Travel/js/popup1.js"></script>
    <style>
        .center
        {
            position: absolute;
            top: 448px;
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
                            <%--<div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="../img/loading.gif" />"
                                    Please Wait...
                                </div>
                            </div>--%>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                               <%-- <h2>RECRUITMENT REQUISITION FORM RE-SUBMIT</h2>--%>
                                 <h2>RECRUITMENT REQUISITION FORM</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>RECRUITMENT REQUISITION FORM--%>
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Re-Submit
                                        </div>
                                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    </div>
                                    <div class="widget-body">

                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Total No of Posts
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_Posts" runat="server" CssClass="span10" MaxLength="4" onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_Posts"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter No of Posts"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_Posts"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                        ErrorMessage='<img src=" images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Vacancy Type
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_vacancy_type" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddl_vacancy_type" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Vacancy Type"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Expected CTC Range 
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddlexpectCTC" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                    <%-- <asp:TextBox ID="txt_incentive" runat="server" CssClass="span10" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_incentive"
                                                ValidationGroup="rrf" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                </div>
                                            </div>
                                            <div id="Div1" class="control-group" runat="server" visible="false">
                                                <label class="control-label">
                                                    Temporary(in days)
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_temparary" runat="server" CssClass="span10" onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_temparary"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                            <div id="Div2" class="control-group" visible="false" runat="server">
                                                <label class="control-label">
                                                    Budget
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:RadioButtonList ID="rbtn_budget" runat="server" RepeatDirection="Horizontal" CssClass="radio inline">
                                                        <asp:ListItem Value="true">Yes  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                        <asp:ListItem Value="false">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </div>
                                            </div>

                                            <div id="Div3" class="control-group" runat="server" visible="false">
                                                <label class="control-label">
                                                    Gross Salary
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_grosssalary" runat="server" CssClass="span10" MaxLength="10"></asp:TextBox>
                                                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_grosssalary"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only Numbers and decimals upto 2 places"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Shift Hours
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_shifthours" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator11" ControlToValidate="txt_shifthours"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[a-zA-Z0-9\s\-\.]+$" ToolTip="Enter only Alphanumeric and space - ."
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Reasons of Request
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_reasons" runat="server" CssClass="span10" TextMode="MultiLine"
                                                        onkeypress="return isChar_Number_space()"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator7" ControlToValidate="txt_reasons"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphanumeric and space"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_reasons"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Reasons of Request"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Industries Preferred
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_IndustriesPreferred" runat="server" CssClass="span10" MaxLength="200" TextMode="MultiLine"
                                                        onkeypress="return isChar_Number_space()"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator9" ControlToValidate="txt_IndustriesPreferred"
                                                ValidationGroup="rrf" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphanumeric and space"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                    --%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_IndustriesPreferred"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Industries Preferred"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Skills
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_skills" runat="server" CssClass="span10" MaxLength="200" TextMode="MultiLine" onkeypress="return false;" onkeydown="return false;"></asp:TextBox>
                                                    <a href="JavaScript:newPopup1('PickSkills.aspx');" class="btn btn-small btn-primary hidden-tablet hidden-phone" style="margin-left: 5px">Select</a>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txt_skills"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Skills"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Educational Qualifications
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_edu_qualification" runat="server" CssClass="span10" MaxLength="200" TextMode="MultiLine" onkeypress="return false;" onkeydown="return false;"></asp:TextBox>
                                                    &nbsp;  <a href="JavaScript:newPopup1('pickQualification.aspx');" class="btn btn-small btn-primary hidden-tablet hidden-phone" style="margin-left: 5px">Select </a>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txt_edu_qualification"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Educational Qualifications"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Request Type
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_request_type" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddl_request_type" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Request Type"
                                                        ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Location
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_location" runat="server" OnSelectedIndexChanged="ddl_location_SelectedIndexChanged" CssClass="span10" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <div class="control-group">
                                                <label class="control-label">
                                                    Department Type
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddldeptype" runat="server" CssClass="span10" OnSelectedIndexChanged="ddldeptype_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddldeptype" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Department type"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Department
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10" OnSelectedIndexChanged="ddl_dept_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dept" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Department"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Designation
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_designation" runat="server" CssClass="span10">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_designation" InitialValue="0"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Select Designation"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div id="Div4" class="control-group" runat="server" visible="false">
                                                <label class="control-label">
                                                    Working Hours
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_workinghours" runat="server" CssClass="span10" MaxLength="6"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" ControlToValidate="txt_workinghours"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_workinghours"
                                                Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Work Hours"
                                                ValidationGroup="rrf" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    --%>
                                                </div>
                                            </div>

                                            <div class="control-group" runat="server" visible="false">
                                                <label class="control-label">
                                                    Cost Center
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:DropDownList ID="ddl_costcenter" runat="server" CssClass="span10">
                                                    </asp:DropDownList>

                                                </div>
                                            </div>



                                            <div id="Div5" class="control-group" runat="server" visible="false">
                                                <label class="control-label">
                                                    TCTC
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_tctc" runat="server" CssClass="span10" MaxLength="8" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_tctc"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^\d+(\.\d{1,2})?$" ToolTip="Enter only Numbers and decimals upto 2 places"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Experience (In Years)
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_experience" runat="server" CssClass="span10"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" ControlToValidate="txt_experience"
                                                        ValidationGroup="rrf" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                        ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txt_experience"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Experience"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Additional Qualifiers
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_additionalqualifiers" runat="server" CssClass="span10" MaxLength="200" TextMode="MultiLine"
                                                        onkeypress="return isChar_Number_space()"></asp:TextBox>
                                                    <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator8" ControlToValidate="txt_additionalqualifiers"
                                                ValidationGroup="rrf" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphanumeric and space"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                    --%><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txt_additionalqualifiers"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Additional Qualifiers"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Job Description
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_jobDesc" runat="server" CssClass="span10" MaxLength="200" TextMode="MultiLine"
                                                        onkeypress="return isChar_Number_space()"></asp:TextBox>
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator10" ControlToValidate="txt_jobDesc"
                                                ValidationGroup="rrf" runat="server" ValidationExpression="^[a-zA-Z0-9\s]+$" ToolTip="Enter only Alphanumeric and space"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_jobDesc"
                                                        Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Job Description"
                                                        ValidationGroup="rrf" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Approval Details
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="grdapprovers" runat="server" AutoGenerateColumns="False"
                                                EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("ApproverCode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%#Eval("ApproverName")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevels" runat="server" Text='<%#Eval("Approvelevel")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Role">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrole" runat="server" Text='<%#Eval("ApproverRole")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblstatus" runat="server" Text='<%#Eval("ApproverStatus")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="form-actions no-margin" style="text-align:right">
                                <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-info" ValidationGroup="rrf" OnClick="btn_Submit_Click" />&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnback" runat="server" Text="Cancel" CssClass="btn btn-info" OnClick="btnback_Click" />
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btn_Submit" />
                    <asp:PostBackTrigger ControlID="btnback" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/analytics.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

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

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdapprovers').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
