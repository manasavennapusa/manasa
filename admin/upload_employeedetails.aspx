<%@ Page Language="C#" AutoEventWireup="true" CodeFile="upload_employeedetails.aspx.cs" Inherits="admin_upload_employeedetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script src="js/timepicker.js"></script>
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
  
</head>
<body>
    <form id="myForm" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
              
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Upload Employee Information</h2>
                        </div>

                        <div class="clearfix"></div>
                    </div>
                    <div class="row-fluid">
                        <div class="widget" style="width: 49%; float: left; clear: none">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="Label1" runat="server" Text="Upload Job Details"></asp:Label>
                                </div>
                                <a style="float: right;" href="../download/EmployeeJobDetails.xlsx">Download</a>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                   
                                     <div class="control-group">
                                        <label class="control-label"></label>
                                        <div class="controls">
                                           <%-- <asp:FileUpload ID="fileupload1" CssClass="form-control" runat="server" />--%>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Choose File</label>
                                        <div class="controls">
                                            <asp:FileUpload ID="fileuploadJob" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-actions" style="margin-top: 140px">
                                        <asp:Button ID="btnJobdetails" runat="server" CssClass="btn btn-primary pull-right"
                                            Text="Submit" OnClick="btnJobdetails_Click"></asp:Button>&nbsp;
                                    </div>
                                </fieldset>
                            </div>
                        </div>

                        <div class="widget" style="width: 49%; float: right; clear: none;">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Upload All Details"></asp:Label>
                                </div>
                                <a style="float: right;" href="../download/EmpolyeeDetails.xlsx">Download</a>
                            </div>
                            <div class="widget-body">

                                <fieldset>
                                   
                                     <div class="control-group">
                                        <label class="control-label"></label>
                                        <div class="controls">
                                           <%-- <asp:FileUpload ID="fileupload1" CssClass="form-control" runat="server" />--%>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Choose File</label>
                                        <div class="controls">
                                            <asp:FileUpload ID="fileUpload" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>

                                    <div class="form-actions" style="margin-top: 140px">
                                        <asp:Button ID="btnsbmit" runat="server" CssClass="btn btn-primary pull-right"
                                            Text="Submit" OnClick="btnsbmit_Click"></asp:Button>&nbsp;
                                    </div>
                                </fieldset>

                            </div>
                        </div>
                    </div>


                    <div>
                        <br />
                    </div>
                </div>

            </div>
        </div>
      
        
    </form>
</body>
</html>
