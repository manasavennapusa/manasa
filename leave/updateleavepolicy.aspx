<%@ Page Language="C#" AutoEventWireup="true" CodeFile="updateleavepolicy.aspx.cs" Inherits="leave_updateleavepolicy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
      <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>
    <script type="text/javascript">
        function validatedata() {

            var policyname = document.getElementById('<%=txt_policy.ClientID %>');
            var uploadfile = document.getElementById('<%=fupload.ClientID %>');
            if (policyname.value == "") {
                alert("Please enter policy name");
                return false;
            }
            //if (uploadfile.value == "") {
            //    alert("Please upload the leave policy");
            //    return false;
            //}
            //var myfile = uploadfile.value;
            //if (myfile.indexOf("pdf") <= 0 || myfile.indexOf("txt") <= 0) {
            //    alert("Please Upload .pdf or .txt files only");
            //    return false;
            //}
            return true;
        }
    </script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>--%>
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Leave Policy</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Edit
                            </div>
                        </div>
                        <div class="widget-body">
                            <fieldset>
                                <div class="control-group">
                                    <label class="control-label">Policy Name<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_policy" runat="server" CssClass="span4"></asp:TextBox>
                                           <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_policy"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Enter Policy Name"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Upload File<span class="star"></span></label>
                                    <div class="controls">
                                        <asp:FileUpload runat="server" ID="fupload" CssClass="span4" ToolTip="Upload File here" />
                                        <asp:Label ID="lbl_file" runat="server" CssClass="span2"></asp:Label>
                                      <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fupload"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip="Upload Policy"
                                                ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                        <%--  <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="fupload"
                                                ValidationGroup="v" runat="server" ValidationExpression="^([a-zA-Z0-9\s_\\.\-:])+(.doc|.docx|.pdf)$" ToolTip="Upload formate(.pdf|.docx|.doc) "
                                                ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator><p style="color: red">(Supported Files are PDF,Docx.Doc)</p>--%>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">Policy Description</label>
                                    <div class="controls">
                                        <asp:TextBox ID="txt_policy_desc" runat="server" CssClass="span4" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-actions no-margin">
                                  
                                    <asp:Button ID="btncancel" runat="server" Text="Cancel" CssClass="btn btn-info pull-left" OnClick="btncancel_Click" style="margin-left:60px"  ToolTip="Click to cancel the updation" />
                                     <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="btn btn-info pull-left" OnClick="btnsbmit_Click" style="margin-left:5px"     ValidationGroup="v"  ToolTip="Click to submit the updated leave policy" />
                                     <asp:HiddenField ID="prvimg" runat="server" />
                                    <asp:HiddenField ID="hdfiletype" runat="server" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
                <%-- </ContentTemplate>
                </asp:UpdatePanel>--%>
            </div>
        </div>
    </form>
</body>
</html>


