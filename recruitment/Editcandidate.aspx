<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Editcandidate.aspx.cs" Inherits="recruitment_Editcandidate" %>



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
    <script src="../Travel/js/popup1.js"></script>
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
     <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2><asp:Label ID="lblheader" runat="server"></asp:Label></h2>--%>
                        <h2>Candidate Details</h2>
                    </div>
                    
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>CANDIDATE REGISTRATION FORM--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Edit
                                </div>
                                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Email Id<span class="star"></span>
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_email" runat="server" CssClass="span8" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email Id"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:Button ID="btn_check_email" runat="server" Text="Check" CssClass="btn btn-info" OnClick="btn_check_email_Click" />

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Candidate Name<span class="star"></span>
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_candidateName" runat="server" CssClass="span10" MaxLength="200"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_candidateName"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Candidate Name"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_candidateName"
                                                ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only Alphabets"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Applied Date<span class="star"></span>
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_Applied_Date" runat="server" CssClass="span10" MaxLength="200"></asp:TextBox>&#160;
                                             <asp:Image ID="Image2" runat="server" ImageUrl="images/clndr.gif" style="margin-top:8px" />
                                            <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                TargetControlID="txt_Applied_Date" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_Applied_Date"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Applied Date format dd/MMM/yyyy"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Alternate Phone No.
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_phoneno" runat="server" CssClass="span10" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_phoneno"
                                                ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only Numbers Min(10 digits)"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Qualifications
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_Qualifications" runat="server" CssClass="span10" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Date Of Birth<span class="star"></span>
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_Dob" runat="server" CssClass="span10" placeholder="DD/MMM/YYYY"></asp:TextBox>&#160;
                                             <asp:Image ID="Image3" runat="server" ImageUrl="images/clndr.gif" style="margin-top:8px" />
                                            <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Image3"
                                                TargetControlID="txt_Dob" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                            &nbsp;
                                           <%-- <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                                TargetControlID="txt_Dob" Enabled="True">
                                            </cc1:CalendarExtender>--%>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Dob"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter DOB format dd/MMM/yyyy"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                          <%--  <asp:CompareValidator ID="CompareValidatordob" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                ValidationGroup="v" Display="Dynamic" ControlToValidate="txt_Dob" ToolTip="Future Date is not allowed"
                                                Operator="LessThan" Type="Date"></asp:CompareValidator>--%>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="country">
                                            Upload Resume
                                        </label>
                                        <div class="controls">
                                            
                                             <asp:Label ID="lbl_file1" runat="server"  Text=""></asp:Label><br />
                                            <asp:FileUpload ID="fp_resume" runat="server" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Referred By</label>

                                        <div class="controls">
                                            <table class="radio inline">
                                                <tr>
                                                    <td>
                                                        <asp:RadioButtonList ID="rbtnl_refferred" runat="server" RepeatDirection="Horizontal" Width="200px" OnSelectedIndexChanged="rbtnl_refferred_SelectedIndexChanged" AutoPostBack="true">
                                                            <asp:ListItem Selected="True">Internal</asp:ListItem>
                                                            <asp:ListItem>Consultancy</asp:ListItem>
                                                        </asp:RadioButtonList>

                                                    </td>
                                                </tr>
                                            </table>
                                            <asp:TextBox ID="txt_referredby" runat="server" CssClass="span10" MaxLength="100"></asp:TextBox>
                                            <asp:DropDownList ID="ddlConsultancy" runat="server" CssClass="span10" Visible="false">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Address
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox runat="server" ID="txt_Address" CssClass="span10" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Notes
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_notes" runat="server" CssClass="span10" TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Mobile No.<span class="star"></span>
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox ID="txt_mobileno" runat="server" CssClass="span8" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_mobileno"
                                                ValidationGroup="v" runat="server" ValidationExpression="^[7-9][0-9]{9}$" ToolTip="Enter only Numbers and starts with 7,8,9 (10 digits)"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_mobileno"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Mobile No."
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                            <asp:Button ID="btn_check" runat="server" Text="Check" OnClick="btn_check_Click" CssClass="btn btn-info" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="email1">
                                            Designation Name
                                        </label>
                                        <div class="controls">
                                           <%-- <asp:TextBox ID="txt_designation" runat="server" CssClass="span10"></asp:TextBox>--%>
                                          <asp:DropDownList ID="drpdesig" runat="server" CssClass="span10" 
                                                OnDataBound="drpdesig_DataBound" OnSelectedIndexChanged="drpdesig_SelectedIndexChanged">
                                            </asp:DropDownList>
                                           <%--  <asp:SqlDataSource ID="sql_designation" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], designationname FROM tbl_intranet_designation"></asp:SqlDataSource>--%>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="drpdesig"
                                                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Select Designation" ValidationGroup="v"
                                                                                            InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="email1">
                                            Experience (in years)
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_experience" runat="server" CssClass="span10" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator" ControlToValidate="txt_experience" Type="Double"
                                                ValidationGroup="v" runat="server" MinimumValue="0" MaximumValue="60" ToolTip="Enter only Numbers(0-60)"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RangeValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">
                                            Gender<span class="star"></span>
                                        </label>
                                        <div class="controls">
                                            <asp:DropDownList ID="ddl_gender" runat="server" CssClass="span10">
                                                <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                <asp:ListItem Value="MALE">MALE</asp:ListItem>
                                                <asp:ListItem Value="FEMALE">FEMALE</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="requiredgender" runat="server" ValidationGroup="v" ControlToValidate="ddl_gender"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Please Select Gender" InitialValue="0"></asp:RequiredFieldValidator>
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
                                        <label class="control-label" for="repPassword">
                                            Passport Validity
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_passportvalidity" runat="server" CssClass="span10" MaxLength="50" onkeypress="return false;" onkeydown="return false;"></asp:TextBox>&#160;
                                            <asp:Image ID="Image1" runat="server" ImageUrl="images/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                TargetControlID="txt_passportvalidity" Enabled="True">
                                            </cc1:CalendarExtender>
                                            <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txt_passportvalidity"
                                                ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                ValidationGroup="v" ValueToCompare="MM/dd/yyyy"></asp:CompareValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Expected Salary
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_expSalary" runat="server" CssClass="span10" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                          <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_expSalary"
                                                ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>--%>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Skills
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:TextBox runat="server" ID="txt_skills" CssClass="span10" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="country">
                                            Achievements
                                        </label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_achievements" runat="server" CssClass="span10"
                                                TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                                <div class="clearfix">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions no-margin" style="text-align:right">
                    <asp:Button ID="btn_Submit" runat="server" Text="Update" CssClass="btn btn-info" ValidationGroup="v" OnClick="btn_Submit_Click"/>&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btn_clear" runat="server" Text="Cancel" CssClass="btn btn-info" OnClick="btn_clear_Click" />
                </div>
            </div>

        </div>
    </form>
</body>
</html>

