<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewcompany.aspx.cs" Inherits="Admin_Company_createcompany"
    Title="Create Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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

<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
   <%-- <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
     
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star
        {
            color: red;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />--%>
      <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <%--   <script src="../js/html5-trunk.js" type="text/javascript"></script>--%>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <style type="text/css">
        .star
        {
            color: red;
        }
    </style>
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script src="../js/jquery.min.js" type="text/javascript"></script>
    <script src="../js/bootstrap.js" type="text/javascript"></script>
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js" type="text/javascript"></script>
    <script src="js/validatepassword.js"></script>
    <script src="../admin/js/popup.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>
    <script src="../js/JavaScriptValidations.js"></script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Company Details</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left" id="data-table">
                                <tbody>
                                    <tr>
                                        <td class="frm-lft-clr123" width="22%"> Company Name  <span class="star" style="color:red"></span> <%--<span class="star"></span>--%></td>
                                        <td width="25%">
                                            <asp:Label ID="txtcmpname" runat="server"></asp:Label>
                                        </td>
                                        <td class="frm-lft-clr123" width="22%">Establishment Date <span class="star" style="color:red"></span><%--<span class="star"></span>--%>
                                        </td>
                                        <td width="30%">
                                            <asp:Label ID="txt_est_date" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123">Company Type <%--<span class="star"></span>--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="drp_type" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="frm-lft-clr123">PAN Number
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_pan" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123">TIN Number
                                        </td>
                                        <td>
                                            <asp:Label ID="txttin" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="frm-lft-clr123">Registration Number
                                        </td>
                                        <td>
                                            <asp:Label ID="txtregno" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123">TAN Number
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_tanno" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="frm-lft-clr123">TDS Circle
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_tds" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123">Company PF Trust
                                        </td>
                                        <td>
                                            <asp:Label ID="drp_pftrust" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="frm-lft-clr123">Nature of Business<%--<span class="star"></span>--%>
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_comp_eng" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123">Responsible Person
                                        </td>
                                        <td>
                                            <asp:Label ID="txt_resppers" runat="server"></asp:Label>&nbsp;
                                        </td>
                                        <td class="frm-lft-clr123">Company URL<span class="star" style="color:red"></span>
                                        </td>
                                        <td>
                                            <asp:Label ID="txtcmpurl" runat="server"></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>PF Details
                                </div>
                            </div>


                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td class="frm-lft-clr123" width="22%">EPF Employer Code.
                                    </td>
                                    <td width="25%">
                                        <asp:Label ID="txt_epfno" runat="server"></asp:Label>&nbsp;
                                    </td>

                                    <td class="frm-lft-clr123" width="22%">Sub EPF Employer Code.
                                    </td>
                                    <td width="30%">
                                        <asp:Label ID="txt_dbffile" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <td visible="false" id="Td1" runat="server">Extension
                                </td>
                                <td visible="false" id="Td2" runat="server">
                                    <asp:Label ID="txt_fileext" runat="server"></asp:Label>&nbsp;
                                </td>

                            </table>


                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>ESI Details
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tr>
                                    <td class="frm-lft-clr123" width="22%">ESI Employer Code.
                                    </td>
                                    <td width="25%">
                                        <asp:Label ID="txt_esino" runat="server"></asp:Label>&nbsp;
                                    </td>

                                    <td class="frm-lft-clr123" width="22%">Sub ESI Employer Code.
                                    </td>
                                    <td width="30%">
                                        <asp:Label ID="txt_esilocalno" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>

                <div class="row-fluid">

                    <div class="span6">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Corporate Address
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">

                                <tr>
                                    <td class="frm-lft-clr123" width="22%">Address 1<span class="star" style="color:red"></span>
                                    </td>
                                    <td style="width: 28%; text-align: left">
                                        <asp:Label ID="txt_pre_add1" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Address 2
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_Add2" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Country<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_country" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">State<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_state" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">City<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_city" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Zip Code<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_zip" runat="server"></asp:Label>
                                    </td>

                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Phone No.
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_pre_phone" runat="server"></asp:Label>
                                    </td>

                                </tr>
                            </table>

                        </div>
                    </div>

                    <div class="span6">
                        <div class="widget no-margin">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Correspondance Address
                                </div>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left">

                                <tr>
                                    <td class="frm-lft-clr123" width="22%">Address 1<span class="star" style="color:red"></span>
                                    </td>
                                    <td width="30%">
                                        <asp:Label ID="txt_per_add1" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Address 2
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_add2" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Country<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_country" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">State<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_state" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">City<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_city" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Zip Code<span class="star" style="color:red"></span>
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_zip" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>

                                <tr>
                                    <td class="frm-lft-clr123">Phone No.
                                    </td>
                                    <td>
                                        <asp:Label ID="txt_per_phone" runat="server"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>

                    <div align="right">
                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Edit" CssClass="btn btn-primary"
                            ValidationGroup="c"></asp:Button>
                    </div>

                    <span id="message" runat="server" class="txt-red" enableviewstate="false">&nbsp;</span>


                </div>
            </div>
    </form>

</body>
</html>
