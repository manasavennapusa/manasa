<%@ Page 
    Language="C#" 
    AutoEventWireup="false" 
    CodeFile="processleave.aspx.cs" 
    Inherits="leave_processleave" 
    ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html lang="en">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel 
                ID="updatepanel1" 
                runat="server">

                <ContentTemplate>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Process Leave</h2>
                            </div>
                          
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                            <asp:Label ID="lblhead" runat="server" Text="Process Leave"></asp:Label>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group">
                                                    <label class="control-label">Period Name</label>
                                                    <div class="controls">
                                                        <asp:DropDownList 
                                                            ID="ddlLeavePeriod" 
                                                            runat="server" 
                                                            CssClass="span4" 
                                                            ViewStateMode="Enabled"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                
                                                <div class="form-actions no-margin">
                                                   <asp:Button 
                                                       ID="btnProcess" 
                                                       runat="server" 
                                                       Text="Process" 
                                                       OnClick="btnProcess_Click" CssClass="btn btn-primary" ViewStateMode="Disabled" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                            <div class="row-fluid" style="display:none">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                            <asp:Label ID="label2" runat="server" Text="Update Employee leave Profile and Carryforward  for Next Finance Year"></asp:Label>
                                        </div>
                                    </div>
                                    <div id="Div1" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group">
                                                    <label class="control-label">Process Leave</label>
                                                    <div class="controls">
                                                        <asp:DropDownList 
                                                            ID="ddlperiodid" 
                                                            runat="server" 
                                                            CssClass="span4" 
                                                            ViewStateMode="Enabled"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                 <div class="control-group" style="display:none">
                                                    <label class="control-label">Policy Name</label>
                                                    <div class="controls">
                                                        <asp:DropDownList 
                                                            ID="ddlpolicy" 
                                                            runat="server" 
                                                            CssClass="span4" 
                                                            ViewStateMode="Enabled"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="form-actions no-margin">
                                                   <asp:Button 
                                                       ID="btnapply" 
                                                       runat="server" 
                                                       Text="Apply" 
                                                       ViewStateMode="Disabled" CssClass="btn btn-primary" OnClick="btnapply_Click" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
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
    </form>
</body>
</html>

