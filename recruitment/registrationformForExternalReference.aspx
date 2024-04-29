<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registrationformForExternalReference.aspx.cs"
    Inherits="recruitment_registrationformForExternalReference" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
    <%--<link href="../css/blue1.css" rel="stylesheet" />--%>
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
                        <h2>REGISTRATION FORM FOR EXTERNAL REFERENCES</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Create Work Location
                                </div>
                                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">
                                <form class="form-horizontal no-margin">

                                    <div class="span6">
                                        <div class="control-group">
                                            <label class="control-label">
                                                Rules
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox runat="server" ID="txt_rules" CssClass="span10" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label">
                                                Candidate Name
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox ID="txt_candidateName" runat="server" CssClass="span10" MaxLength="200"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_candidateName"
                                                    Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Candidate Name"
                                                    ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_candidateName"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only Numbers"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="email1">
                                                Experience (in months)
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_experience" runat="server" CssClass="span10"  MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator" ControlToValidate="txt_experience" Type="Double"
                                                    ValidationGroup="v" runat="server" MinimumValue="0" MaximumValue="60" ToolTip="Enter only Numbers(0-60)"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="password5">
                                                Address
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox runat="server" ID="txt_Address" CssClass="span10" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Join Status(in days)
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_joinstatus" runat="server" CssClass="span10" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_joinstatus"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Phone No.
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_phoneno" runat="server" CssClass="span10" MaxLength="11" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_phoneno"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only Numbers Min(10 digits)"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Expected Salary
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_expSalary" runat="server" CssClass="span10" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_expSalary"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Email
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_email" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                    ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                    ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                    ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"></asp:RegularExpressionValidator>

                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Passport Validity
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_passportvalidity" runat="server" CssClass="span10" MaxLength="50" onkeypress="return isNumber_slash()"></asp:TextBox>
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                    TargetControlID="txt_passportvalidity" Enabled="True">
                                                </cc1:CalendarExtender>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="txt_passportvalidity"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                    ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="repPassword">
                                                Comments
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_comments" runat="server" CssClass="span10" TextMode="MultiLine"
                                                    MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="span6">
                                        <div class="control-group">
                                            <label class="control-label" for="DateofBirthMonth">
                                                Mobile No.
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox ID="txt_mobileno" runat="server" CssClass="span10" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_mobileno"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[7-9][0-9]{9}$" ToolTip="Enter only Numbers and starts with 7,8,9 (10 digits)"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="country">
                                                Relation to Referer
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_relation" runat="server" CssClass="span10" MaxLength="100"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="DateofBirthMonth">
                                                Qualifications
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox ID="txt_Qualifications" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="country">
                                                Achievements
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_achievements" runat="server" CssClass="span10" TextMode="MultiLine"
                                                    MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="DateofBirthMonth">
                                                Skills
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox runat="server" ID="txt_skills" CssClass="span10" TextMode="MultiLine"
                                                    Height="50px"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="country">
                                                Upload Resume
                                            </label>
                                            <div class="controls">
                                                <asp:FileUpload ID="fp_resume" runat="server" />
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="DateofBirthMonth">
                                                Date Of Birth
                                            </label>
                                            <div class="controls controls-row">
                                                <asp:TextBox ID="txt_Dob" runat="server" CssClass="span10" onkeypress="return isNumber_slash()"></asp:TextBox>
                                                <asp:Image ID="Image12" runat="server" ImageUrl="../images/clndr.gif" />
                                                <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12"
                                                    TargetControlID="txt_Dob" Enabled="True">
                                                </cc1:CalendarExtender>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txt_Dob"
                                                    ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                    ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="country">
                                                Passport No.
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_passportno" runat="server" CssClass="span10" MaxLength="10" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator64" ControlToValidate="txt_passportno"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                        <div class="control-group">
                                            <label class="control-label" for="country">
                                                Reasons Of Reference
                                            </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_reasonsofref" runat="server" CssClass="span10" TextMode="MultiLine" Height="50" MaxLength="50"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix">
                                    </div>

                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="form-actions no-margin">
                <asp:Button ID="btn_Submit" runat="server" Text="Submit" ValidationGroup="v" CssClass="btn btn-primary" OnClick="btn_Submit_Click" />&nbsp;
                    <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="btn" OnClick="btn_clear_Click" />

            </div>
        </div>

    </form>
</body>
</html>
