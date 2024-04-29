<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrartionForm.aspx.cs" Inherits="RegistrartionForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="icomoon/style.css" rel="stylesheet" />
    <link href="css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function ValidateDate() {
            var empcode = document.getElementById("empcode");
            var emailid = document.getElementById("email");
            if (empcode.value == "") {
                alert("Please enter Empployee Code");
                return false;
            }
            if (emailid.value == "") {
                alert("Please enter Email Id.");
                return false;
            }
            return true;
        }

    </script>
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
            <div class="main-container">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" style="width:100%;height:70%">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="modal-backdrop fade in">
                                    <div>
                                        <%--   <img src="../img/loading.gif" alt=""/>--%>
                                        <asp:Image ID="imag1" runat="server" ImageUrl="~/img/loading.gif" Style="text-align: inherit" />
                                        Please Wait...
                                    </div>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>CANDIDATE REGISTRATION FORM</h2>
                            </div>
                            <div class="pull-right">
                                <ul class="stats">                                  
                                </ul>
                            </div>
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" ><%--style="width:90%;padding-left:100px;"--%>
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        Create 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <fieldset>                                       
                                        <div class="span6">
                                            <div class="control-group">
                                                <label class="control-label" for="repPassword">
                                                    Email
                                                </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_email" runat="server" CssClass="span7" MaxLength="50"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Email Id"
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                        ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                        ControlToValidate="txt_email"
                                                        ValidationExpression="^[a-z0-9_\+-]+(\.[a-z0-9_\+-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*\.([a-z]{2,4})$"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                     <asp:Button ID="Butncheckemail" runat="server" Text="Check" OnClick="Butncheckemail_Click" CssClass="btn btn-info" />
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Candidate Name
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_candidateName" runat="server" CssClass="span7" MaxLength="200"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_candidateName"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Candidate Name"
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txt_candidateName"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only Alphabets"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                               <div class="control-group">
                                                    <label class="control-label" for="repPassword">
                                                   Applied Date
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_Applied_date" runat="server" CssClass="span7" MaxLength="50" onkeypress="return false;" onkeydown="return false;"></asp:TextBox>
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                            TargetControlID="txt_Applied_date" Enabled="True"  Format="dd-MMM-yyyy">
                                                        </cc1:CalendarExtender>
                                                      
                                                    </div>
                                                </div>
                                            <div class="control-group">
                                                <label class="control-label">
                                                    Alternate Phone No.
                                                </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_phoneno" runat="server" CssClass="span7" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_phoneno"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[0-9]{10,11}$" ToolTip="Enter only Numbers Min(10 digits)"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Qualifications
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_Qualifications" runat="server" CssClass="span7" MaxLength="50"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="control-group">
                                                <label class="control-label" for="DateofBirthMonth">
                                                    Date Of Birth
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_Dob" runat="server" CssClass="span7" placeholder="dd-mmm-yyyy"></asp:TextBox>&#160;
                                                        <asp:Image ID="Image3" runat="server" ImageUrl="images/clndr.gif" style="margin-top:8px" />
                                                
                                       <cc1:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="Image3"
                                                TargetControlID="txt_Dob" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_Dob"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter DOB format dd/MM/yyyy"
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                     <%-- <asp:CompareValidator ID="CompareValidatordob" runat="server" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                ValidationGroup="v" Display="Dynamic" ControlToValidate="txt_Dob" ToolTip="Future Date is not allowed"
                                                Operator="LessThan" Type="Date"></asp:CompareValidator>--%>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label" for="country">
                                                    Upload Resume
                                                </label>
                                                <div class="controls">
                                                    <asp:FileUpload ID="fp_resume" runat="server" />

                                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="fp_resume"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Upload Resume"
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator6" Display="Dynamic"  ControlToValidate="fp_resume"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$" ToolTip="Upload formate(.pdf|.docx|.doc)"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                    
                                                   
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
                                                    <asp:TextBox ID="txt_referredby" runat="server" CssClass="span7" MaxLength="100"></asp:TextBox>
                                                    <asp:DropDownList ID="ddlConsultancy" runat="server" CssClass="span10" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Address
                                                </label>
                                                <div class="controls">
                                                    <asp:TextBox runat="server" ID="txt_Address" CssClass="span7" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">
                                                    Notes
                                                </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_notes" runat="server" CssClass="span7" TextMode="MultiLine" MaxLength="200"></asp:TextBox>
                                                </div>
                                            </div>

                                        </div>

                                        <div class="span6">

                                            <div class="control-group">
                                                <label class="control-label" for="DateofBirthMonth">
                                                    Mobile No.
                                                </label>
                                                <div class="controls controls-row">
                                                    <asp:TextBox ID="txt_mobileno" runat="server" CssClass="span7" MaxLength="10" onkeypress="return isNumber()"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_mobileno"
                                                        ValidationGroup="v" runat="server" ValidationExpression="^[7-9][0-9]{9}$" ToolTip="Enter only Numbers and starts with 7,8,9 (10 digits)"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_mobileno"
                                                        Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Mobile No."
                                                        ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                     <asp:Button ID="btn_check" runat="server" Text="Check" OnClick="btn_check_Click" CssClass="btn btn-info" />
                                                </div>
                                            </div>

                                                <div class="control-group">
                                                    <label class="control-label" for="email1">
                                                        Designation Name
                                                    </label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="txt_designation" runat="server" CssClass="span7"></asp:DropDownList>
                                                       <%-- <asp:DropDownList ID="desdrop" runat="server" CssClass="span7" DataSourceID="sql_designation" DataTextField="designationname" DataValueField="id"></asp:DropDownList>
                                                        <asp:SqlDataSource ID="sql_designation" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], designationname FROM tbl_intranet_designation"></asp:SqlDataSource>--%>
                                                    </div>
                                                   
                                                </div>

                                                <div class="control-group">
                                                    <label class="control-label" for="email1">
                                                        Experience (in years)
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_experience" runat="server" CssClass="span7" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                                        <asp:RangeValidator ID="RangeValidator" ControlToValidate="txt_experience" Type="Double"
                                                            ValidationGroup="v" runat="server" MinimumValue="0" MaximumValue="60" ToolTip="Enter only Numbers(0-60)"><img src="images/error1.gif" /></asp:RangeValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">
                                                        Gender
                                                    </label>
                                                    <div class="controls">
                                                        <asp:DropDownList ID="ddl_gender" runat="server" CssClass="span7">
                                                            <asp:ListItem Value="0">-Select-</asp:ListItem>
                                                            <asp:ListItem Value="MALE">MALE</asp:ListItem>
                                                            <asp:ListItem Value="FEMALE">FEMALE</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="requiredgender" runat="server" SetFocusOnError="true" ValidationGroup="v" ControlToValidate="ddl_gender" ToolTip="Please Select Gender" InitialValue="0"><img src="images/error1.gif" /></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label" for="repPassword">
                                                        Join Status(in days)
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_joinstatus" runat="server" CssClass="span7" MaxLength="3" onkeypress="return isNumber()"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txt_joinstatus"
                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label" for="country">
                                                        Passport No.
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_passportno" runat="server" CssClass="span7" MaxLength="10" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator64" ControlToValidate="txt_passportno"
                                                            ValidationGroup="v" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only alphanumeric"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label" for="repPassword">
                                                        Passport Validity
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_passportvalidity" runat="server" CssClass="span7" MaxLength="50" onkeypress="return false;" onkeydown="return false;"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="images/clndr.gif" />
                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                            TargetControlID="txt_passportvalidity" Enabled="True">
                                                        </cc1:CalendarExtender>
                                                        <asp:CompareValidator ID="CompareValidator21" runat="server" ControlToValidate="txt_passportvalidity"
                                                            ToolTip="Check date format(MM/dd/yyyy)" Operator="DataTypeCheck" Type="Date"
                                                            ValidationGroup="v" ValueToCompare="MM/dd/yyyy"><img src="images/error1.gif" /></asp:CompareValidator>
                                                    </div>
                                                </div>

                                                <div class="control-group">
                                                    <label class="control-label" for="repPassword">
                                                        Expected Salary
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_expSalary" runat="server" CssClass="span7" MaxLength="6" onkeypress="return isNumber()"></asp:TextBox>
                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" ControlToValidate="txt_expSalary"
                                                            ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"><img src="images/error1.gif" /></asp:RegularExpressionValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label" for="DateofBirthMonth">
                                                        Skills
                                                    </label>
                                                    <div class="controls controls-row">
                                                        <asp:TextBox runat="server" ID="txt_skills" CssClass="span7" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label" for="country">
                                                        Achievements
                                                    </label>
                                                    <div class="controls">
                                                        <asp:TextBox ID="txt_achievements" runat="server" CssClass="span7"
                                                            TextMode="MultiLine" MaxLength="50"></asp:TextBox>
                                                    </div>
                                                </div>

                                            </div>
                                    </fieldset>
                                </div>

                            </div>
                        </div>

                        <div class="form-actions no-margin">
                            <asp:Button ID="btn_Submit" runat="server" Text="Submit" CssClass="btn btn-info" ValidationGroup="v" OnClick="btn_Submit_Click" />&nbsp;
                                <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="btn btn-info" OnClick="btn_clear_Click" />
                             <%-- <a href="javascript: window.close ()">--%>                               

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    
</body>
</html>

