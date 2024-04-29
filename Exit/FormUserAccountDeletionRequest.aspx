<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormUserAccountDeletionRequest.aspx.cs" Inherits="Exit_FormUserAccountDeletionRequest" %>

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
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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
    <link href="../css/table.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        function validateEmail(obj) {
            var x = obj.value;
            if (x != '') {
                var atpos = x.indexOf("@");
                var dotpos = x.lastIndexOf(".");
                if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                    obj.focus();
                    alert("Not a valid e-mail address");
                    return false;
                }
            }
        }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>User Account Deletion Request</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Code:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpCode" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Department:</label>
                                        <div class="controls">
                                            <asp:Label ID="Department" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Joining:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOJ" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Resignation:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOR" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Last Working Day:</label>
                                        <div class="controls">
                                            <asp:Label ID="LWD" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Permanent Address:</label>
                                        <div class="controls">
                                            <asp:Label ID="PA" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Mobile Number:</label>
                                        <div class="controls">
                                            <asp:Label ID="PMN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Email Id:</label>
                                        <div class="controls">
                                            <asp:Label ID="PEI" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Section - 1 User Details
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Business Unit</label>
                                        <div class="controls">
                                            <asp:TextBox ID="BusinessUnit" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="txtrequired" runat="server" ControlToValidate="BusinessUnit" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Building Address</label>
                                        <div class="controls">
                                            <asp:TextBox ID="BuildingAddress" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="BuildingAddress" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Telephone Extension of Leaver</label>
                                        <div class="controls">
                                            <asp:TextBox ID="TelephoneExtensionofLeaver" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TelephoneExtensionofLeaver" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Line Manager (Include Contact Telephone Number)</label>
                                        <div class="controls">
                                            <asp:TextBox ID="LineManager" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LineManager" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>

                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        Existing Equipment Asset Number / Computer name of PC or Laptop, All asset will be transferred to the Line Manager of the leaver while the cleanse procedure are in action                                           
                                       
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">PC/Laptop Asset Number</label>
                                        <div class="controls">
                                            <asp:TextBox ID="PCLaptopAssetNumber" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="PCLaptopAssetNumber" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <script type="text/javascript">
                                        function IsNumeric(evt) {
                                            var theEvent = evt || window.event;
                                            var key = theEvent.keyCode || theEvent.which;
                                            key = String.fromCharCode(key);
                                            var regex = /[0-9]/;
                                            if (!regex.test(key)) {
                                                theEvent.returnValue = false;
                                                if (theEvent.preventDefault) theEvent.preventDefault();
                                            }
                                        }
                                    </script>
                                    <div class="control-group">
                                        <label class="control-label">Mobile / Telephone Number</label>
                                        <div class="controls">
                                            <asp:TextBox ID="MobileTelephoneNumber" runat="server" CssClass="span4" MaxLength="12" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="MobileTelephoneNumber" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Section - 2 Business System Access
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Please list all business systems applications that the leaver has to access to</label>
                                        <div class="controls">
                                            <asp:TextBox ID="BusinessSystemsApplications" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="BusinessSystemsApplications" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Section - 3 Data Delegation
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        Please provide the details of a colleague / Manager whom you wish to allocate the employee's data to:
                                        <br />
                                        (Note: This Access is given for a maximum 2 weeks only).
                                    </div>
                                    <script type="text/javascript">
                                        function IsAlPha(evt) {
                                            var theEvent = evt || window.event;
                                            var key = theEvent.keyCode || theEvent.which;
                                            key = String.fromCharCode(key);
                                            var regex = /[a-zA-z]|\./;
                                            if (!regex.test(key)) {
                                                theEvent.returnValue = false;
                                                if (theEvent.preventDefault) theEvent.preventDefault();
                                            }
                                        }
                                    </script>
                                    <div class="control-group">
                                        <label class="control-label">Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="Name" runat="server" CssClass="span4" onkeypress="return IsAlPha(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="Name" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Log On Id</label>
                                        <div class="controls">
                                            <asp:TextBox ID="LogOnId" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="LogOnId" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Access To</label>
                                        <div class="controls">
                                            <asp:TextBox ID="AccessTo" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="AccessTo" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Email</label>
                                        <div class="controls">
                                            <asp:TextBox ID="Email" runat="server" CssClass="span4" onblur="return validateEmail(this);"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="Email" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        It is the responsibility of the user who had been given access to back up any data from the leavers account as all accounts rearchived after 2 week access. For further data recovery a restore request will need to be raised.
                                    </div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click"  Visible="false"/>
                                        <asp:Button ID="btnInitiate" runat="server" CssClass="btn btn-primary" Text="Initiate" OnClick="btnApprove_Click" ValidationGroup="g"/>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Reject" OnClick="btnCancel_Click" />
                                    </div>
                                </fieldset>
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
                $('#grdstaytype').dataTable({
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

